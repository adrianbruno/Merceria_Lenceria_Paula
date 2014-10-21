﻿using System;
using System.Text;
using System.Windows.Forms;

using brlMerceria;

namespace Merceria_Lenceria_Paula
{
    public partial class ControlStock : Form
    {
        public ControlStock()
        {
            // Comienzo...
            InitializeComponent();
            CargarDatos();
            txtCodigo.Focus();
        }

        private void CargarDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            // Carga los datos en la grilla para poder seleccionarlos
            brlStock obReg = new brlStock();
            gvDatos.DataSource = obReg.DatosStock_basico();

            Cursor.Current = Cursors.Default;
            
        }

        private void UpdateDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            
            // Realiza el update de los datos en STOCK
            brlStock obReg = new brlStock();
            obReg.UpdateDatosStock(txtCodigo.Text,
                                   txtFabricante.Text,
                                   txtDescripcion.Text,
                                   txtPrecio.Text,
                                   txtCantidad.Text);
                                                    
            Cursor.Current = Cursors.Default;

        }

        private void InsertDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            // Realiza el insert de los datos en STOCK
            brlStock obReg = new brlStock();
            obReg.InsertDatosStock(txtCodigo.Text,
                                   txtFabricante.Text,
                                   txtDescripcion.Text,
                                   txtPrecio.Text,
                                   txtCantidad.Text);

            Cursor.Current = Cursors.Default;

        }
      
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Al hacer click en un valor los muestra en los text
            txtCodigo.Text = gvDatos.CurrentRow.Cells[0].Value.ToString();
            txtFabricante.Text = gvDatos.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = gvDatos.CurrentRow.Cells[2].Value.ToString();
            txtPrecio.Text = gvDatos.CurrentRow.Cells[3].Value.ToString();
            txtCantidad.Text = gvDatos.CurrentRow.Cells[4].Value.ToString();
            btnBorrar.Enabled = true;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Todo_OK()
        {
         // Controla que TODOS los campos estén correctos
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

            // Realiza el borrado del registro de STOCK
            brlStock obReg = new brlStock();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            gvDatos.Enabled = false;
            Limpiar_Controles();
        }
    }
}
