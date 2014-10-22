using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
 

namespace dtlMerceria
{
    
    public class dtlStock
    {

        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDB"].ConnectionString);

        /// <summary>
        /// Obtiene los ID de Stock
        /// </summary>
        public DataTable ListaIdStock()
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

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "sp_ins_item_stock";
                cmd.Parameters.Add("@id_cod", SqlDbType.VarChar).Value = _Cod;
                cmd.Parameters.Add("@fabricante", SqlDbType.VarChar).Value = _Fab;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = _Desc;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = _Precio;
                cmd.Parameters.Add("@cant_actual", SqlDbType.Int).Value = _Cant_Actual;
                cmd.Parameters.Add("@hash", SqlDbType.VarChar).Value = _hash_precio;

                cmd.Connection = conn;

                conn.Open();

                reader = cmd.ExecuteReader();

                conn.Close();
         }

        /// <summary>
        /// Obtiene los datos de Stock, de todos los campos y todos los registros (COMPLETOS)
        /// </summary>
        public DataTable ObtenerStock_Full()
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
        public DataTable ObtenerStock_basico()
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

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_del_item_stock";
            cmd.Parameters.Add("@id_codigo", SqlDbType.VarChar).Value = _Cod;
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

         cmd.CommandType = CommandType.StoredProcedure;

         cmd.CommandText = "sp_upd_item_stock";

         cmd.Parameters.Add("@id_cod", SqlDbType.VarChar).Value = _Cod;
         cmd.Parameters.Add("@fabricante", SqlDbType.VarChar).Value = _Fab;
         cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = _Desc;
         cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = _Precio;
         cmd.Parameters.Add("@cant_actual", SqlDbType.Int).Value = _Cant_Actual;
         cmd.Parameters.Add("@hash", SqlDbType.VarChar).Value = _hash_precio;

        cmd.Connection = conn;
        conn.Open();

        reader = cmd.ExecuteReader();

        conn.Close();
        }
    }
}
