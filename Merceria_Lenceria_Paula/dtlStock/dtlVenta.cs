using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;


namespace dtlMerceria
{
    public class dtlVenta
    {
        // Este valor debería obtenerse desde algún lugar fijo
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                            AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                            Integrated Security=True");
        public void CargarDatosVentaPrevio(string _usuario)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM " + _usuario + "_tmpVenta ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            /*
             * VER!!!!
             * 
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
            */
            conn.Close();
        }
        /// <summary>
        /// Obtiene los ID de Stock
        /// </summary>
        public DataTable ListaID()
        {
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(
                   "SELECT id_codigo FROM stock", conn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
        public void Agregotmp(string _usuario,
                              string _cod,
                            string _desc,
                            string _fab,
                            string _cant,
                            string _monto,
                            string _stockAct)
        {
            // Agrego los datos seleccionados a la tambla TEMP de venta
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "INSERT INTO " + _usuario + "_tmpVenta VALUES (" +
                              "'" + _cod + "'," +
                              "'" + _desc + "'," +
                              "'" + _fab + "'," +
                                    _cant + "," +
                              "'" + _monto.Replace(',', '.') + "'," +
                                    _stockAct + ")";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            conn.Close();
        }
        public void FinalizarTmpVenta(string _usuario)
        {
            // TRUNCO la tabla temporal por venta finalizada correctamente
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "TRUNCATE TABLE " + _usuario + "_tmpVenta";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            conn.Close();

        }
        public void CerrarTmpVenta(string _usuario)
        {
            // ELIMINO la tabla temporal por salida del usuario
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "DROP TABLE " + _usuario + "_tmpVenta";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            conn.Close();

        }
        public Boolean Existe_Venta_Tmp(string _usuario)
        {
            // Ver si existe una venta previa, sino crea la tabla
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT name FROM sysobjects WHERE xtype='u' and name='" + _usuario + "_tmpVenta'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            // Devuelve TRUE si existe la tabla, FALSE sino
            Boolean existe = reader.HasRows;

            conn.Close();

            return existe;
        }
        public void Creo_Venta_Tmp(string _usuario)
        {
            // Ver si existe una venta previa, sino crea la tabla
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "CREATE TABLE " + _usuario + "_tmpVenta " +
                "([Id_codigo] VARCHAR (20) NOT NULL, " +
                "[Descripcion] VARCHAR (50) NOT NULL, " +
                "[fabricante] VARCHAR (50) NOT NULL, " +
                "[cant_actual] INT NULL, " +
                "[precio] DECIMAL (18, 2) NOT NULL," +
                "[stock_actual] INT NULL) ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
 
            conn.Open();

            reader = cmd.ExecuteReader();
            
            conn.Close();
        }

    }
}
