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


namespace Merceria_Lenceria_Paula
{
    public partial class ControlStock : Form
    {
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

        // Conexion a la BD
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                                Integrated Security=True");

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

            if (reader.HasRows)
            {
                 while (reader.Read())
                {
                    //Codigo(0),Fabricante(1),Descripcion(2),Precio(3),Cantidad(8)
                    dataGridView1.Rows.Add(reader.GetSqlValue(0),
                                           reader.GetSqlValue(1),
                                           reader.GetSqlValue(2),
                                           reader.GetSqlValue(3),
                                           reader.GetSqlValue(7)
                                           );
                }
            }
            
            Cursor.Current = Cursors.Default ;
            sqlConnection1.Close();

        }
        
        public void InsertDatos()
        {
            // Agregad los datos nuevos
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                string hash_precio = CalculateMD5Hash(txtPrecio.Text.Replace(',', '.') + txtCantidad.Text);
                
                cmd.CommandText = "insert into stock values('" +
                                    txtCodigo.Text + "','" +
                                    txtFabricante.Text + "','" +
                                    txtDescripcion.Text + "','" +
                                    txtPrecio.Text + "',null,null,null," +
                                    txtCantidad.Text + ",null,null,null,'" +
                                    hash_precio +"')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();

                if (e.HResult == -2146232060)
                {
                      MessageBox.Show("CODIGO ya existe, No se puede dar de alta, intente nuevamente!",
                                    "Importante!!",
		                            MessageBoxButtons.OK,
		                            MessageBoxIcon.Hand,
                                    MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error comuniquese con Soporte." + e);
                }
            }
        }
        public void UpdateDatos()
        {
            // Actualizar datos nuevos
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                string hash_precio = CalculateMD5Hash(txtPrecio.Text.Replace(',', '.') + txtCantidad.Text);

                cmd.CommandText = "update stock set fabricante='" + txtFabricante.Text + "'," +
                                                    "descripcion='" + txtDescripcion.Text + "'," +
                                                    " precio='" + txtPrecio.Text.Replace(',','.') + "'," +
                                                    " cant_actual=" + txtCantidad.Text + "," + 
                                                    " hash='" + hash_precio + "'" +
                                                    " where id_codigo='" + txtCodigo.Text +"'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
                MessageBox.Show("{0} Exception caught." + e);
            }
        }
        public void BorrarDatos()
        {
            // Borra los registros
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "delete from stock where id_codigo='" + txtCodigo.Text +"'" ;

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            
            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();

        }
        public ControlStock()
        {
            // Comienzo...
            InitializeComponent();
            CargarDatos();
            txtCodigo.Focus();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Al hacer click en un valor los muestra
            txtCodigo.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            txtFabricante.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtDescripcion.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
            txtCantidad.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
            btnBorrar.Enabled = true;
        }


        private void btnAplicar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            dataGridView1.Enabled = false;
            Limpiar_Controles();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsLetter(e.KeyChar))
            {
                txtCodigo.Focus();
                e.Handled = true;
            }
        }

        private void txtCodigo_MouseHover(object sender, EventArgs e)
        {
            /*
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Valores admitibles solo NÚMEROS", TB, 0, 0, VisibleTime);
            */
        }

        private void txtFabricante_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Valores admitibles solo LETRAS", TB, 0, 0, VisibleTime);
             */
        }

        private void txtFabricante_KeyPress(object sender, KeyPressEventArgs e)
        {
         /*   if (!Char.IsLetter(e.KeyChar) )
            {
                txtFabricante.Focus();
                e.Handled = true;
            }
         */
        }

        private void txtDescripcion_MouseHover(object sender, EventArgs e)
        {
            /* 
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Valores sin restricciones", TB, 0, 0, VisibleTime);
        
            */
        }

        private void Limpiar_Controles()
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            txtCodigo.Text = "";
            txtFabricante.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtCodigo.Focus();
            btnBorrar.Enabled = false;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Controles();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Todo_OK()
        {
            if (txtCodigo.Text.Length > 0 &&
                 txtFabricante.Text.Length > 0 &&
                 txtDescripcion.Text.Length > 0 &&
                 txtPrecio.Text.Length > 0 &&
                 txtCantidad.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.TextLength > 0)
            {
                txtPrecio.Text = String.Format("{0:c}", txtPrecio.Text);
            }
            btnGuardar.Enabled = Todo_OK();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            BorrarDatos();
            Limpiar_Controles();
            dataGridView1.Rows.Clear();
            CargarDatos();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            btnGuardar.Enabled = Todo_OK();
        }

        private void txtFabricante_Leave(object sender, EventArgs e)
        {
            btnGuardar.Enabled = Todo_OK();
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            btnGuardar.Enabled = Todo_OK();
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            btnGuardar.Enabled = Todo_OK();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!txtCodigo.Enabled)
            {
                // Si boton NUEVO no está habilitado es un UPDATE
                UpdateDatos();
                Limpiar_Controles();
                dataGridView1.Rows.Clear();
                CargarDatos();
            }
            else
            {
                // Sino es un INSERT
                InsertDatos();
                Limpiar_Controles();
                dataGridView1.Rows.Clear();
                CargarDatos();
            }
            // Pongo los controles en flase para empezar de nuevo
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 46)
            {
                txtPrecio.Focus();
                e.Handled = true;
            }
            btnGuardar.Enabled = Todo_OK();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                txtPrecio.Focus();
                e.Handled = true;
            }
            btnGuardar.Enabled = Todo_OK();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.ShowDialog();
        }


    }
}
