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

namespace Merceria_Lenceria_Paula
{
    public partial class frmCambioPassUsuario : Form
    {
        public string _Usuario;
        public string _Nueva_Pass;

        // Conexion a la BD
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                                Integrated Security=True");
        
        string key = "ClaveUltraCompleta"; // tambien hay que cambiarla en el frmCambiarPass

        public Boolean TodoOK()
        {
            if (txtPass1.Text.Length > 3 && 
                txtPass2.Text.Length > 3 && 
                txtPass1.Text == txtPass2.Text) return true;
            return false;
        }

        public static string CreateSHAHash512(string Text, string Salt)
        {
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] HashAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Text, Salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(HashAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }


        private void CambioPassUsuario(string pass)
        {
            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;
            
            string nueva_pass;

            nueva_pass = CreateSHAHash512(txtPass2.Text.Trim(), key);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "update usuarios set pass='" + nueva_pass  + "' where login='" + _Usuario + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }

        private string CambioPassUsuario2(string pass)
        {
            _Nueva_Pass = CreateSHAHash512(txtPass2.Text.Trim(), key);

            return _Nueva_Pass;
        }

        public frmCambioPassUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // CambioPassUsuario(txtPass1.Text.Trim());
            if (TodoOK())
            {
                CambioPassUsuario2(txtPass1.Text.Trim());
            }
            else
            {
                MessageBox.Show("La contraseña no es correcta!!!, intente de nuevo");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            _Nueva_Pass = "cancela";
        }

    }
}
