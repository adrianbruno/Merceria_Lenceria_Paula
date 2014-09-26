using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace dtlMerceria
{
    
    public class dtlStock
    {
        // Este valor debería obtenerse desde algún lugar fijo
        public SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
                                                                AttachDbFilename='C:\Merceria_DB\MerceriaLenceriaDB.mdf';
                                                                Integrated Security=True");
        /// <summary>
        /// Realiza el INSERT de los datos en Stock
        /// </summary>
        public void InsertDatos(string _Cod, 
                                string _Fab,
                                string _Desc,
                                string _Precio,
                                string _hash_precio,
                                string _Cant_Actual)
        {

                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "insert into stock values('" +
                                    _Cod + "','" +
                                    _Fab + "','" +
                                    _Desc + "','" +
                                    _Precio + "',null,null,null," +
                                    _Cant_Actual + ",null,null,null,'" +
                                    _hash_precio + "')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();

                conn.Close();
         }

        /// <summary>
        /// Obtiene los datos de Stock, de todos los campos y todos los registros (COMPLETOS)
        /// </summary>
        public DataTable DatosStock_Full()
        {
          conn.Open();
           using (SqlDataAdapter da = new SqlDataAdapter(
                  "SELECT * FROM stock", conn))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
               }
        }

        /// <summary>
        /// Obtiene los datos de Stock, de los campos principales y todos los registros (COMPLETOS)
        /// </summary>
        public DataTable DatosStock_basico()
        {
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(
                   "SELECT id_codigo, fabricante, descripcion, precio, cant_actual FROM stock", conn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
        /// <summary>
        /// BORRA el registro indicado de la tabla STOCK
        /// </summary>
        public void BorrarDatosStock(string _Cod)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "delete from stock where id_codigo='" + _Cod + "'";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            conn.Open();

            reader = cmd.ExecuteReader();

            conn.Close();

        }

        /// <summary>
        /// Realiza el UPDATE de la tabla STOCK
        /// </summary>
        public void UpdateDatosStock(string _Cod, 
                                string _Fab,
                                string _Desc,
                                string _Precio,
                                string _hash_precio,
                                string _Cant_Actual)
        {
         SqlCommand cmd = new SqlCommand();
         SqlDataReader reader;

         cmd.CommandText = "update stock set fabricante='" + _Fab + "'," +
                                "descripcion='" + _Desc + "'," +
                                " precio='" + _Precio.Replace(',', '.') + "'," +
                                " cant_actual=" + _Cant_Actual + "," +
                                " hash='" + _hash_precio + "'" +
                                " where id_codigo='" + _Cod + "'";

        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;
        conn.Open();

        reader = cmd.ExecuteReader();

        conn.Close();
        }
    }
}
