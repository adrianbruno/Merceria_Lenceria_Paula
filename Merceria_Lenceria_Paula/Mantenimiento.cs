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

namespace Merceria_Lenceria_Paula
{
    public partial class frmMantenimiento : Form
    {
        // Conexion a la BD
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                Integrated Security=True");


        void ListarBD()
        {
            SqlCommand cmd = new SqlCommand();

            SqlDataReader reader;

            cmd.CommandText = "sp_helpdb";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            
            reader.Read();

            MessageBox.Show(reader.GetSqlValue(0).ToString());
        }

        public void BackupBD()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SqlCommand cmd = new SqlCommand();

                SqlDataReader reader;

                cmd.CommandText = "BACKUP DATABASE MERCERIADB TO disk='" + txtPath.Text + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                Cursor.Current = Cursors.Default;
                reader.Close();
                sqlConnection1.Close();


                MessageBox.Show("El backup se ha realizado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
                MessageBox.Show("{0} Exception caught." + e);
            }
        }

        public void RestoreDB()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
            string connectionString1 = (@"Data Source=(LocalDB)\v11.0;Integrated Security=True");
            SqlConnection cn = new SqlConnection(connectionString1);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = @"use master alter database merceriadb set offline with rollback immediate";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            reader = cmd.ExecuteReader();
            reader.Close();

            cmd.CommandText = @"use master; RESTORE DATABASE merceriadb FROM DISK = '" + txtPath.Text + "' WITH REPLACE ";
            cmd.Connection = cn;
            reader = cmd.ExecuteReader();
            reader.Close();

            cmd.CommandText = @"use master alter database merceriadb set online with rollback immediate;";
            cmd.Connection = cn;
            reader = cmd.ExecuteReader();

            reader.Close();
            cn.Close();
            MessageBox.Show("La base de datos fue recuperarda correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
                MessageBox.Show("{0} Exception caught." + e);
            }
        }
       
        public frmMantenimiento()
        {
            InitializeComponent();
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            string _fecha = "";
            _fecha = DateTime.Now.Year.ToString() +
                     DateTime.Now.Month.ToString() +
                     DateTime.Now.Day.ToString() +
                     DateTime.Now.Hour +
                     DateTime.Now.Minute;

            //ListarBD();

            txtPath.Text = "c:\\backup\\" + _fecha + "-MerceriaLenceriaDB.bak";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (chkBackup.Checked)
            {
                BackupBD();
            }
            else
            {
                RestoreDB();
            }
        }

        private void btnBuscaArchivo_Click(object sender, EventArgs e)
        {

            string _fecha = "";
            _fecha = DateTime.Now.Year.ToString() +
                     DateTime.Now.Month.ToString() +
                     DateTime.Now.Day.ToString() +
                     DateTime.Now.Hour +
                     DateTime.Now.Minute;

            if (chkBackup.Checked)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Archivo de resguardo|*.bak";
                saveFileDialog1.Title = "Nombre del archivo para resguardar";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    txtPath.Text = saveFileDialog1.FileName;
                }
            }
            else
            {
                // Displays an OpenFileDialog so the user can select a Cursor.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Archivos de resguardo|*.bak";
                openFileDialog1.Title = "Selecione el archivo para recuperar";

                openFileDialog1.ShowDialog();

                if (openFileDialog1.FileName != "")
                {
                    txtPath.Text = openFileDialog1.FileName;
                }
            }
        }

    }
}
