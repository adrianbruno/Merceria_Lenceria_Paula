using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.IO;

using dtlMerceria;

namespace Merceria_Lenceria_Paula
{
    public partial class Venta : Form
    {
        // Para saber que usuario esta vendiendo y crear la tabla temporaria
        public string _Usuario;

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
        PrintDocument doc = new PrintDocument(); /*creas e instancias el objeto, imaginatelo como si fuera una hoja a imprimir.*/


        public void CargarDatosText()
        {
            // Carga la cantidad de STOCK disponible para el producto seleccionado
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM stock where id_codigo='" + cmbCodigo.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                //Codigo(0),Fabricante(1),Descripcion(2),Precio(3),Cantidad(7)
                txtDescripcion.Text = reader.GetSqlValue(2).ToString();
                txtFabricante.Text = reader.GetSqlValue(1).ToString();
                txtPrecio.Text = reader.GetSqlValue(3).ToString();

                int hasta=0;
                hasta= Convert.ToInt16(reader.GetSqlValue(7).ToString()) ;

                // Cierro la conexón para poder hacer la 2 consulta 
                sqlConnection1.Close();

                hasta = hasta - Cantid_Stock_Previo(cmbCodigo.Text);

                cmbCantidad.Items.Clear();

                if (hasta > 0)
                {
                    for (int i = 1; i <= hasta; i++)
                    {
                        cmbCantidad.Items.Add(i);
                    }

                    cmbCantidad.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("NO Existe STOCK para vender.",
                                    "Importante!!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand,
                                    MessageBoxDefaultButton.Button1);
                }
            }
         Cursor.Current = Cursors.Default;
        }


        int Cantid_Stock_Previo(string id_codigo)
        {
            // Obtiene la cantida de ventas PREVIAS para saber cuento stock existe
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT sum(cant_actual) FROM " + _Usuario.Trim() + "_tmpVenta where id_codigo='" + id_codigo + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                
                string temp = reader.GetValue(0).ToString();

                reader.Close();
                sqlConnection1.Close();

                // Si no tiene nada retorno CERO
                if (temp =="")  return 0;
                
                // Sino, develvo el valor 
                return Convert.ToInt16(temp);
                
            }
            Cursor.Current = Cursors.Default;
            reader.Close();
            sqlConnection1.Close();

            return 0;
        }

        void CargarDatosVentaPrevio()
        {
            // Ver si existe una venta previa y la carga
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM " + _Usuario.Trim() + "_tmpVenta ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dg.Rows.Add(reader.GetSqlValue(0),
                        reader.GetSqlValue(1),
                        reader.GetSqlValue(2),
                        reader.GetSqlValue(3),
                        reader.GetSqlValue(4).ToString().Replace('.', ','));

                        // Modifico la cant disponible
                        cmbCantidad.Items.Clear();

                        int st = Convert.ToInt16(reader.GetSqlValue(5).ToString());

                        for (int i = 1; i <= st; i++)
                        {
                            cmbCantidad.Items.Add(i);
                        }
                        
                    if (st == 0) cmbCantidad.Text = "";
                }
            }
            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }
            

        void ExistetmpVenta()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Tomado desde la clase dtlMerceria
            dtlVenta obReg = new dtlVenta();

            if (obReg.Existe_Venta_Tmp(_Usuario) == false)
            {
                obReg.Creo_Venta_Tmp(_Usuario);
            }

            Cursor.Current = Cursors.Default;

            /*
            // Ver si existe una venta previa, sino crea la tabla
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT name FROM sysobjects WHERE xtype='u' and name='" + _Usuario + "_tmpVenta'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            // Si no tiene registros es porque no existe la tabla temporal de venta para el usuario
            // Entonces la creo
            if (reader.HasRows== false) 
            {

                sqlConnection1.Close();

                cmd.CommandText = "CREATE TABLE " + _Usuario + "_tmpVenta " +
                    "([Id_codigo] VARCHAR (20) NOT NULL, " +
                    "[Descripcion] VARCHAR (50) NOT NULL, " +
                    "[fabricante] VARCHAR (50) NOT NULL, " +
                    "[cant_actual] INT NULL, " +
                    "[precio] DECIMAL (18, 2) NOT NULL," +
                    "[stock_actual] INT NULL) "; 

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                
                sqlConnection1.Open();
                reader = cmd.ExecuteReader();
            }

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
             */
        }

        void AgregotmpVenta(string Id_cod, String Desc, string Fabri, string Cant, string Monto, string Stock_ac)
        {
            // Agrego los datos seleccionados a la tambla TEMP de venta
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO " + _Usuario + "_tmpVenta VALUES (" +
                              "'" + Id_cod + "'," +
                              "'" + Desc + "'," +
                              "'" + Fabri + "'," +
                                    Cant + "," +
                              "'" + Monto.Replace(',', '.') + "'," +
                                    Stock_ac + ")";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }

        public void UpdateDatos()
        {
            // Una vez que la venta se concreta acrtualizo STOCK
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                foreach (DataGridViewRow row in dg.Rows)
                {
                    //Codigo(0),Fabricante(1),Descripcion(2),Precio(3),Cantidad(8)

                    string hash_precio = CalculateMD5Hash(row.Cells[6].Value.ToString() + row.Cells[5].Value.ToString());

                    cmd.CommandText = "update stock set cant_actual= "+ row.Cells[5].Value.ToString() +
                                                      ", hash='" + hash_precio + 
                                                      "' where id_codigo='" + row.Cells[0].Value.ToString() +"'";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    reader = cmd.ExecuteReader();

                    Cursor.Current = Cursors.Default;
                    sqlConnection1.Close();
                }

            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                sqlConnection1.Close();
                MessageBox.Show("{0} Exception caught." + e);
            }
        }
        void FinalizotmpVenta()
        {
            // TRUNCO la tabla temporal por venta finalizada correctamente
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "TRUNCATE TABLE " + _Usuario + "_tmpVenta";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }

        void CerrartmpVenta()
        {
            // ELIMINO la tabla temporal por salida del usuario
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "DROP TABLE " + _Usuario + "_tmpVenta";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }
        public void CargarDatosCombo()
        {
            // Carga los datos en la grid
            Cursor.Current = Cursors.WaitCursor;

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT id_codigo FROM stock";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmbCodigo.Items.Add(reader.GetSqlValue(0));
                }
            }

            Cursor.Current = Cursors.Default;
            sqlConnection1.Close();
        }

        public Venta()
        {
            InitializeComponent();
            
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            CargarDatosCombo();
        }

        private void doc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Font letra = new Font("Verdana", 12);
            string Texto = "";

            Texto = "=====================================";
            Texto = Texto + "\n Art: 1          Importe: 55.90";
            Texto = Texto + "\n Art: 1          Importe: 55.90\n";
            Texto = Texto + "\n Art: 3          Importe: 55.90";
            Texto = Texto + "\n =====================================\n";
            Texto = Texto + "\n Total: 55.90";

            e.Graphics.DrawString(Texto, letra, Brushes.Black, 1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cmbCodigo_SelectedValueChanged(object sender, EventArgs e)
        {
            CargarDatosText();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbCantidad.Text != "")
            {
                double precio = Convert.ToDouble(txtPrecio.Text) /100 ;
                double cant = Convert.ToInt16(cmbCantidad.Text) *  precio;
                double stock_actual=(cmbCantidad.Items.Count - Convert.ToInt32(cmbCantidad.Text));

                dg.Rows.Add(cmbCodigo.Text, 
                            txtDescripcion.Text, 
                            txtFabricante.Text, 
                            cmbCantidad.Text, 
                            cant,
                            stock_actual,
                            txtPrecio.Text);

                AgregotmpVenta(cmbCodigo.Text,
                            txtDescripcion.Text,
                            txtFabricante.Text,
                            cmbCantidad.Text,
                            cant.ToString(),
                            stock_actual.ToString());

                // Modifico la cant disponible
                cmbCantidad.Items.Clear();

                for (int i = 1; i <= stock_actual; i++)
                {
                    cmbCantidad.Items.Add(i);
                }

                if (stock_actual == 0) cmbCantidad.Text = "";

            }
        }

        private void CalculoMonto()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberGroupSeparator = ".";

            int counter;
            double resul = 0;

            // Iterate through all the rows and sum up the appropriate columns.
            for (counter = 0; counter < (dg.Rows.Count);
                counter++)
            {
                if (dg.Rows[counter].Cells["Precio"].Value != null)
                {
                    //hacemos la suma de la columna total 
                    resul = dg.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["Precio"].Value));
                }

            }
            txtGasto_Total.Text = resul.ToString(nfi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void dg_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculoMonto();
        }

        private void dg_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculoMonto();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            // Cargo tabla temporaria de venta del usuario
           ExistetmpVenta();
           CargarDatosVentaPrevio();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            CerrartmpVenta();
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            // Actualizar STOCK
            UpdateDatos();

            // Imprimir
            PrintDialog dlg = new PrintDialog();
            dlg.Document = doc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

            FinalizotmpVenta();

            CargarDatosText();

            // Limpia la grilla
            dg.Rows.Clear();
        }

    }
}
