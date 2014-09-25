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
        /// Obtiene los datos de Stock, COMPLETOS
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
        /// Obtiene los datos de Stock, BÁSICOS
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
        /// Realiza el UPDATE de la tabla STOCK
        /// </summary>
        public void UpdateDatos(string _Cod, 
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
