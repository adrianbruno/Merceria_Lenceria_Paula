using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string key = "ClaveUltraCompleta"; // tambien hay que cambiarla en el frmCambiarPass
    SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDB"].ConnectionString);

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

    private int ExisteDatosSQL(string usr, string pass)
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

            if (Convert.ToInt16(reader.GetSqlValue(6).ToString()) == 0)
            {
                // Cuenta bloqueada
                reader.Close();
                sqlConnection1.Close();
                return 3;
            }

            if (pass == reader.GetSqlValue(2).ToString())
            {
                // Todo BIEN, Password CORRECTA
                //0=login,1=Pass,2=nombre,3=apellido,4=Nivel  
                
                // Para almacenar el usuario y el NIVEL
                /*
                _Usuario = reader.GetSqlValue(1).ToString();
                _Nivel = reader.GetInt32(5);
                */

                reader.Close();
                // Coloco el valor de intentos fallidos a CERO para resetear la cuenta del usuario
                cmd.CommandText = "UPDATE usuarios set cant_intento_fallido=0 where login='" + usr + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();

                reader.Close();
                sqlConnection1.Close();
                return 0;
            }
            else
            {
                // Usuario correcto pero no la pass, incremento la cantidad de intentos
                reader.Close();
                sqlConnection1.Close();
                //ErrorPass(usr);
                return 1;
            }

        }
        else
        {
            // No existe el usuario, de todas maneras dejo logueado que escribio, para futuros reportes
            reader.Close();
            sqlConnection1.Close();
            return 4;
        }

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        //connect to our db
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\venta.mdf; Integrated Security=True");
        
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDBConnectionString"].ConnectionString);

        string pass = CreateSHAHash512(txtPassword.Text.Trim(), key);

        if (ExisteDatosSQL(txtUserName.Text.Trim(), pass) == 0)
        {
            //store the password from the db
            Label1.Text = "Todo OK";
            Response.Redirect("menuEdi_principal.html");
        }
        else
        {
            Response.Write("<script>window.alert('Contraseña incorrecta, intente nuevamente');</script>");
            Label1.Enabled = true;
            Label1.Text = "Contraseña o nombre de usuario incorrecto, intente nuevamente  !!!"; 
        }

        /*
        //sql command to add the user to the database
        SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE login=@UserName and password=HashBytes('MD5',@Password)", conn);
        cmd.CommandType = CommandType.Text;

        //selected where UserName is the current username in txtUserName
        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

        Label1.Enabled = false;

        using (conn)
        {
            //open the connection
            conn.Open();
            //execute query and store results in a sqldatareader
            SqlDataReader rdr = cmd.ExecuteReader();
            //read the data we have selected
            if (rdr.Read())
            {
                //store the password from the db
                Label1.Text = "Todo OK";
                Response.Redirect("menuEdi_principal.html");
            }
            else
            {
                Response.Write("<script>window.alert('Contraseña incorrecta, intente nuevamente');</script>");
                Label1.Enabled = true;
                Label1.Text = "Contraseña o nombre de usuario incorrecto, intente nuevamente  !!!"; 
            }
        }
         */

    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        txtPassword.Text = "";
        txtUserName.Text = "";

    }
}