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
using dtlMerceria;

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

        public void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            // Tomado desde la clase dtlMerceria
            dtlStock obReg = new dtlStock();
            gvDatos.DataSource = obReg.DatosStock_basico();

            Cursor.Current = Cursors.Default;
            
        }

        public void UpdateDatos()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Tomado desde la clase dtlMerceria
            dtlStock obReg = new dtlStock();
            obReg.UpdateDatosStock(txtCodigo.Text,
                              txtFabricante.Text,
                              txtDescripcion.Text,
                              txtPrecio.Text.Replace(',', '.'),
                              CalculateMD5Hash(txtPrecio.Text.Trim().Replace(',', '.') + txtCantidad.Text.Trim()),
                              txtCantidad.Text);
                                                    
            Cursor.Current = Cursors.Default;

        }

        public void InsertDatos()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Tomado desde la clase dtlMerceria
            dtlStock obReg = new dtlStock();
            obReg.InsertDatos(txtCodigo.Text,
                              txtFabricante.Text,
                              txtDescripcion.Text,
                              txtPrecio.Text.Replace(',', '.'),
                              CalculateMD5Hash(txtPrecio.Text.Replace(',', '.') + txtCantidad.Text),
                              txtCantidad.Text);

            Cursor.Current = Cursors.Default;

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
            txtCodigo.Text = gvDatos.CurrentRow.Cells[0].Value.ToString();
            txtFabricante.Text = gvDatos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = gvDatos.CurrentRow.Cells[2].Value.ToString();
            txtPrecio.Text = gvDatos.CurrentRow.Cells[3].Value.ToString();
            txtCantidad.Text = gvDatos.CurrentRow.Cells[4].Value.ToString();
            btnBorrar.Enabled = true;
        }


        private void btnAplicar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            gvDatos.Enabled = false;
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

        private void Limpiar_Controles()
        {
            gvDatos.ClearSelection();
            gvDatos.CurrentCell = null;
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
                txtPrecio.Text = String.Format("{0:0.00}", Convert.ToDecimal(txtPrecio.Text));
            }
            btnGuardar.Enabled = Todo_OK();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Tomado desde la clase dtlMerceria
            dtlStock obReg = new dtlStock();
            obReg.BorrarDatosStock(txtCodigo.Text);

            Limpiar_Controles();
            CargarDatos();

            Cursor.Current = Cursors.Default;
            
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
                CargarDatos();
            }
            else
            {
                // Sino es un INSERT
                InsertDatos();
                Limpiar_Controles();
                CargarDatos();
            }
            
            // Pongo los controles en flase para empezar de nuevo
            btnGuardar.Enabled = false;
            txtCodigo.Enabled = false;
            gvDatos.Enabled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Primero compruebo si es un signo de puntuación
            if (char.IsPunctuation(e.KeyChar))
            {
                // Referencio el control TextBox subyacente.
                //
                TextBox tb = (TextBox)sender;

                switch (e.KeyChar)
                {
                    case '.':
                    case ',':
                        // Obtengo el carácter separador decimal existente
                        // actualmente en la configuración regional de Windows.
                        //
                        string separadorDecimal = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                        e.KeyChar = Convert.ToChar(separadorDecimal[0]);

                        if (tb.Text.Contains(separadorDecimal))
                        {
                            // Ya existe el separador decimal
                            e.Handled = true;
                        }
                        break;
                    case '-':
                        e.Handled = true;
                        break;
                }
            }
            else if (Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Back))
            {
            }
            // Tecla de retroceso; sin implementación.
            else if (!char.IsNumber(e.KeyChar))
            {
                // Sólo se aceptan números
                e.Handled = true;
            }
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
            /*
            Reporte frm = new Reporte();
            frm.ShowDialog();
             */
        }

    }
}
