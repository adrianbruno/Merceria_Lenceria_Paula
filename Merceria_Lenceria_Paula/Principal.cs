using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Net;


namespace Merceria_Lenceria_Paula
{
    public partial class frmPrincipal : Form 
    {
        string key = "ClaveUltraCompleta"; // tambien hay que cambiarla en el frmCambiarPass
        public string _Usuario;
        public int _Nivel;

        private void CambioPassUsuario(string id_usuario, string pass)
        {

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "update usuarios set pass='" + pass + "'" +
                                      " where login='" + id_usuario + "'";


                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                Cursor.Current = Cursors.Default;
                reader.Close();
                sqlConnection1.Close();
                MessageBox.Show("La contraseña se ha cambiado correctamente",
                                  "Correcto",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information,
                                  MessageBoxDefaultButton.Button1);
            }

            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();

                if (e.HResult == -2146232060)
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soporte!",
                                  "Importante!!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Hand,
                                  MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soporte!" + e);
                }
            }
        }
        private void DeshabilitoControles()
        {
            tooNivelAcceso.Text = "Nivel: ";
            tooUsuario.Text = "Usuario: ";
                
            btnFacturar.Enabled = false;
            btnControl_Stock.Enabled = false;
            btnProveedores.Enabled = false;
            btnUsuarios.Enabled = false;
            btnClientes.Enabled = false;
            btnMantenimiento.Enabled = false;

            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;

            btnCambiarContraseña.Enabled = false;

        }

        private void HabilitoControles(string UsuarioLogueado,int Nivel_Acceso)
        {

            tooUsuario.Text = "Usuario: " + UsuarioLogueado;
                
            txtUsuario.Enabled = false; txtUsuario.Text = "";
            txtContraseña.Enabled = false; txtContraseña.Text = "";

            // Establezco nivel de usuarios 
            if (Nivel_Acceso == 1)
            {
                tooNivelAcceso.Text = "Nivel: " + "Solo Venta";
                btnControl_Stock.Enabled = false;
                btnProveedores.Enabled = false;
                btnUsuarios.Enabled = false;
                btnClientes.Enabled = false;
                btnMantenimiento.Enabled = false;
                btnFacturar.Enabled = true;
            }
            if (Nivel_Acceso == 3)
            {
                tooNivelAcceso.Text = "Nivel: " + "Supervisor";
                btnFacturar.Enabled = true;
                btnControl_Stock.Enabled = true;
                btnProveedores.Enabled = true;
                btnUsuarios.Enabled = false;
                btnClientes.Enabled = true;
                btnMantenimiento.Enabled = true;
            }
            if (Nivel_Acceso == 7)
            {
                tooNivelAcceso.Text = "Nivel: " + "Manager";
                btnFacturar.Enabled = true;
                btnControl_Stock.Enabled = true;
                btnProveedores.Enabled = true;
                btnUsuarios.Enabled = true;
                btnClientes.Enabled = true;
                btnMantenimiento.Enabled = true;
            }
            
            btnCambiarContraseña.Enabled = true;
        }

        public static string CreateSHAHash512(string Text, string Salt)
        {
          /*
           * Rutina para encriptar en SHA usando 512 bytes
           */
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] HashAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Text, Salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(HashAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }

        private string GetIp()
        {
            /*
             * Rutina para obtener la IP del equipo 
             */
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 2].ToString() + "," + strHostName;
 
        }


        private int  ExisteDatosSQL(string usr, string pass)
        {
            /*
             * Rutina que devuelve un valor para saber en que estado se encuentra el usuario
             * 0= todo OK
             * 1= Error de contraseña
             * 2= No definido
             * 3= Cuenta del usuario bloqueada
             * 4= Usuario inexistente
             * Para los valores >0 las operaciones quedan logueadas en la tabla "logIntentoFallido"
             */
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM usuarios where login='" + usr + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();

            if (reader.HasRows) // Existe usuario
            {
                    reader.Read();

                    if (Convert.ToInt16(reader.GetSqlValue(5).ToString()) == 0) 
                    {
                        // Cuenta bloqueada
                        reader.Close();
                        sqlConnection1.Close();
                        Cursor.Current = Cursors.Default;
                        return 3;
                    }

                    if (pass == reader.GetSqlValue(1).ToString())
                    {
                        // Todo BIEN, Password CORRECTA
                        //0=login,1=Pass,2=Nombre,3=Apellido,4=Nivel  
                        _Usuario = reader.GetSqlValue(0).ToString();
                        _Nivel = reader.GetInt32(4);

                        reader.Close();
                        // Coloco el valor de intentos fallidos a CERO para resetear la cuenta del usuario
                        cmd.CommandText = "UPDATE usuarios set cant_intento_fallido=0 where login='" + usr + "'";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConnection1;
                        reader = cmd.ExecuteReader();
                        
                        reader.Close();
                        sqlConnection1.Close();
                        Cursor.Current = Cursors.Default;
                        return 0; 
                    }
                    else
                    {
                        // Usuario correcto pero no la pass, incremento la cantidad de intentos
                        reader.Close();
                        sqlConnection1.Close();
                        Cursor.Current = Cursors.Default;
                        ErrorPass(usr);
                        return 1;
                    }
                
            }
            else
            {
                // No existe el usuario, de todas maneras dejo logueado que escribio, para futuros reportes
                reader.Close();
                sqlConnection1.Close();
                Cursor.Current = Cursors.Default;
                return 4;
            }

        }
        
        private void ErrorPass(string usr)
        {
            /*
             * Rutina para incrementar la cantidad de intentos fallidos del usuario
             * Si la cuenta llega a 5 (valor hardodeado) le bloqueo la cuenta
             */
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "update usuarios set cant_intento_fallido = cant_intento_fallido+1 where login = '" + usr + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            reader.Close();

            cmd.CommandText = "select  cant_intento_fallido from usuarios where login = '" + usr + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            reader.Read();

            if (Convert.ToInt16(reader.GetSqlValue(0).ToString()) >= 5)
            {
                reader.Close();
                cmd.CommandText = "update usuarios set cuenta_activa=0 where login = '" + usr + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();
            }

            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();
            
        }

        private void logLoginUsuario(string usr, int accion)
        {
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            /*
             * CREATE SYMMETRIC KEY SYM_KEY WITH ALGORITHM = TRIPLE_DES ENCRYPTION BY PASSWORD ='ClaveUltraCompleta'
             * 
             * DROP SYMMETRIC KEY SYM_KEY
             */

            /*
             * OPEN SYMMETRIC KEY SYM_KEY DECRYPTION BY PASSWORD ='ClaveUltraCompleta'
             * SELECT CAST(DECRYPTBYKEY(login) AS VARCHAR(800)) FROM log_acceso_usuario
             * CLOSE SYMMETRIC KEY SYM_KEY
             */

            DateTime saveNow = DateTime.Now;
        cmd.CommandText = "DECLARE @KEYID UNIQUEIDENTIFIER SET @KEYID = KEY_GUID('SYM_KEY') " +
                              "OPEN SYMMETRIC KEY SYM_KEY DECRYPTION BY PASSWORD='" + key + "'" +
                              "INSERT log_acceso_usuario VALUES (ENCRYPTBYKEY(@KEYID,'" + usr + "'),'" +
                              saveNow.Year + "/" +
                              saveNow.Month + "/" +
                              saveNow.Day + " " +
                              saveNow.Hour + ":" +
                              saveNow.Minute + ":" +
                              saveNow.Second + "'," +
                              accion + ",'" +
                              GetIp() + "') " +
                              "CLOSE SYMMETRIC KEY SYM_KEY";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();
            
        }
        private void logIntentoFallido(string usr, string pass, int accion)
        {
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            // [Id],[login],[password],[fecha_accion],[accion_tipo],[ip_pc]
            DateTime saveNow = DateTime.Now;
            cmd.CommandText = "insert log_acceso_fallido values ('" + usr + 
                "','" + pass + "','" +
                saveNow.Year + "/" +
                saveNow.Month + "/" +
                saveNow.Day + " " +
                saveNow.Hour + ":" +
                saveNow.Minute + ":" +
                saveNow.Second + "'," +
                accion + ",'" +
                GetIp() + "')";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();

        }
        // Conexion a la BD
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                                Integrated Security=True");
        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public void CargarDatos()
        {
            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM stock";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            lblStatus.Text = "";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Controlo que los PRECIOS no estén alterados
                    string hash_precio = CalculateMD5Hash(reader.GetSqlValue(3).ToString() + reader.GetSqlValue(7).ToString());
                    string precio_hash = reader.GetSqlValue(11).ToString();
                    
                    if (precio_hash  != hash_precio)
                    {
                        lblStatus.Text = "Existen valores CORRUPTOS, no se podrá continuar!!!";
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        btnControl_Stock.Enabled = false;
                        btnFacturar.Enabled = false;
                    }
                }
            }
            
            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();
            
        }
        public frmPrincipal()
        {
            InitializeComponent();
            this.Text = "Mercería - Lencería";
            tooVersion.Text = "Versión: " + "2.1";
        }


        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Venta frm = new Venta();
            frm._Usuario = _Usuario;
            frm.ShowDialog();
        }


        private void btnControl_Stock_Click(object sender, EventArgs e)
        {
            ControlStock frm = new ControlStock();
            frm.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            Proveedores frm = new Proveedores();
            frm.ShowDialog();
        }


        private void frmPrincipal_Activated(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            frmMantenimiento frm = new frmMantenimiento();
            frm.ShowDialog();
        }

        private void btnLoginLogout_Click(object sender, EventArgs e)
        {
            switch (btnLoginLogout.Tag.ToString())
            {
                case "C":
                    string pass = CreateSHAHash512(txtContraseña.Text.Trim(), key);

                    switch (ExisteDatosSQL(txtUsuario.Text.Trim(), pass))
                    {
                        case 0: // Usuario y Password correctos
                            logLoginUsuario(_Usuario, 1);
                            HabilitoControles(_Usuario, _Nivel);
                            btnLoginLogout.Tag = "D";
                            btnLoginLogout.Text = "&Desconectarme";
                            break;
                        case 1:
                            logIntentoFallido(txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), 3);
                            MessageBox.Show("Password incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                            break;
                        case 3:
                            logIntentoFallido(txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), 5);
                            MessageBox.Show("Cuenta bloqueada, llame al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 4:
                            logIntentoFallido(txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), 6);
                            MessageBox.Show("No existe el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    break;

                case "D":
                    // (2 es Logout)
                    logLoginUsuario(_Usuario, 2);
                    DeshabilitoControles();
                    btnLoginLogout.Tag = "C";
                    btnLoginLogout.Text = "&Conectarme";
                    txtUsuario.Focus();
                    break;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ABMUsuarios frm = new ABMUsuarios();
            frm.ShowDialog();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            /*
             * Llama al formulario para que pueda cambiar la contraseña
             * Trabaja con las variables globales para determinar el uusario y su pass
             * En las variable globales del frmCambioPassusuario se le establecen los valores
             */
            inicio:

            frmCambioPassUsuario frm = new frmCambioPassUsuario();
            frm._Usuario = _Usuario;
            frm.ShowDialog();

            if (frm._Nueva_Pass == null) goto inicio;
            
            if (frm._Nueva_Pass != "cancela")  CambioPassUsuario(_Usuario, frm._Nueva_Pass.Trim());
        }
    }
}
