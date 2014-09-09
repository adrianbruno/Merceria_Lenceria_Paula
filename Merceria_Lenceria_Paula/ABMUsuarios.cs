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
    public partial class ABMUsuarios : Form
    {
        // Conexion a la BD
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                                Integrated Security=True");
        private void Habilitado()
        {
            if (chkHabilitado.Checked)
            {
                chkHabilitado.Tag = "1";
            }
            else
            {
                chkHabilitado.Tag = "0";
            }
        }

        private void LimpioTextos()
        {
            txtApellido.Text = "";
            txtLogin.Enabled = true;
            txtLogin.Text = "";
            txtNombre.Text = "";
            chkHabilitado.Checked = false;
            radVenta.Checked = true;
            btnCambiarPass.Tag = null;
        }

        private void MuestroUsuario()
        {
            txtLogin.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim();

            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim();
            txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim();

            // Usuario Habilitado?
            string hab = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (hab == "1")
            {
                chkHabilitado.Checked = true;
                chkHabilitado.Tag = "1";
            }
            else
            {
                chkHabilitado.Checked = false;
                chkHabilitado.Tag = "0";
            }

            // Nivel
            string niv = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (niv == "1")
            {
                radVenta.Checked = true;
                grpNivel.Tag = "1";
            }
            if (niv == "3")
            {
                radSupervisor.Checked = true;
                grpNivel.Tag = "3";
            }
            if (niv == "7")
            {
                radManager.Checked = true;
                grpNivel.Tag = "7";
            }

        }

        private void CargarDatos()
        {
            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM usuarios";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                dataGridView1.Rows.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Login(0),Pass(1),Nombre(2),Apellido(3),Nivel(4),cuenta_activa(5),cant_intento_fallido(6)
                        dataGridView1.Rows.Add(reader.GetSqlValue(0),
                                               reader.GetSqlValue(2),
                                               reader.GetSqlValue(3),
                                               reader.GetSqlValue(4),
                                               reader.GetSqlValue(5));
                    }
                }

                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
                dataGridView1.Rows[0].Selected = false;
                // dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();

                if (e.HResult == -2146232060)
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!",
                                  "Importante!!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Hand,
                                  MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!" + e);
                }
            }
        }

        private void GuardaDatos(string id_usuario)
        {
            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                if (btnCambiarPass.Tag == null)
                {
                    // Si es null no se cambia la pass
                    cmd.CommandText = "update usuarios set nombre='" + txtNombre.Text.Trim() + "'," +
                                      "Apellido='" + txtApellido.Text.Trim() + "'," +
                                      "nivel =" + grpNivel.Tag.ToString().Trim() + "," +
                                      "cuenta_activa=" + chkHabilitado.Tag.ToString().Trim() +
                                      " where login='" + id_usuario + "'";
                }
                else
                {
                    // Si NO es null se cambia la pass
                    cmd.CommandText = "update usuarios set nombre='" + txtNombre.Text.Trim() + "'," +
                                      "Apellido='" + txtApellido.Text.Trim() + "'," +
                                      "nivel =" + grpNivel.Tag.ToString().Trim() + "," +
                                      "cuenta_activa=" + chkHabilitado.Tag.ToString().Trim() + "," +
                                      "pass='" + btnCambiarPass.Tag.ToString().Trim() + "'" +
                                      " where login='" + id_usuario + "'";
                }


                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();

                Cursor.Current = Cursors.Default;
                reader.Close();
                sqlConnection1.Close();
                
                MessageBox.Show("Los cambios se han guardado correctamente",
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
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!",
                                  "Importante!!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Hand,
                                  MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!" + e);
                }
            }
        }

        private void InsertarDatos(string id_usuario)
        {
            Habilitado();

            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;

            try
            {

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "insert usuarios values ('" + id_usuario + "','" + 
                                                            btnCambiarPass.Tag + "','" +    
                                                            txtNombre.Text.Trim() + "','" +
                                                            txtApellido.Text.Trim() + "'," +
                                                            grpNivel.Tag.ToString().Trim() + "," +
                                                            chkHabilitado.Tag.ToString().Trim() + ",0)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();

                if (e.HResult == -2146232060)
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!",
                                  "Importante!!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Hand,
                                  MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Error en la BD, No se puede dar de alta, comuniquelo a Soprorte!" + e);
                }
            }
        }

        public ABMUsuarios()
        {
            InitializeComponent();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MuestroUsuario();
        }

        private void btnEditarGuardar_Click(object sender, EventArgs e)
        {
            switch (btnEditarGuardar.Tag.ToString())
            {
                case "E":
                    // Habilito para que puedan modificar los datos
                    dataGridView1.Enabled = false;
                    grpGeneral.Enabled = true;
                    btnEditarGuardar.Text = "&Guardar";
                    btnEditarGuardar.Tag = "G";
                    btnCancelar.Enabled = true;
                    break;
                case "G":
                    // Guardo los cambios
                    dataGridView1.Enabled=true;
                    GuardaDatos(txtLogin.Text.Trim());
                    grpGeneral.Enabled = false;
                    btnEditarGuardar.Text = "&Editar";
                    btnEditarGuardar.Tag = "E";
                    btnCancelar.Enabled = false;
                    btnNuevo.Enabled = true;
                    break;
                case "I":
                    // Agregar usuario
                    if (btnCambiarPass.Tag != null)
                    {
                        InsertarDatos(txtLogin.Text.Trim());
                        txtLogin.Enabled = false;
                        grpGeneral.Enabled = false;
                        btnEditarGuardar.Text = "&Editar";
                        btnEditarGuardar.Tag = "E";
                        btnCancelar.Enabled = false;
                        btnNuevo.Enabled = true;
                        dataGridView1.Enabled = true;
                        LimpioTextos();
                    }
                    else
                    {
                        MessageBox.Show("Falta establecer una contraseña");
                    }
                    break;
            }
            CargarDatos();

        }

        private void radVenta_CheckedChanged(object sender, EventArgs e)
        {
            grpNivel.Tag = "1";
        }

        private void radSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            grpNivel.Tag = "3";
        }

        private void radManager_CheckedChanged(object sender, EventArgs e)
        {
            grpNivel.Tag = "7";
        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            Habilitado();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            grpGeneral.Enabled = false;
            btnEditarGuardar.Text = "&Editar";
            btnEditarGuardar.Tag = "E";
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            LimpioTextos();
        }

        private void btnCambiarPass_Click(object sender, EventArgs e)
        {
            inicio:

            frmCambioPassUsuario frm = new frmCambioPassUsuario();
            frm._Usuario = txtLogin.Text.Trim();
            frm.ShowDialog();
            
            if (frm._Nueva_Pass == null) goto inicio;

            if (frm._Nueva_Pass != "cancela") btnCambiarPass.Tag= frm._Nueva_Pass.Trim();

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpioTextos();
            dataGridView1.Enabled = false;
            grpGeneral.Enabled = true;
            btnEditarGuardar.Text = "&Guardar";
            btnEditarGuardar.Tag = "I";
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
        }

    }
}
