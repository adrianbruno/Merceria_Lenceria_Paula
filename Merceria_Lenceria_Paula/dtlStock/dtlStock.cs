using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
 

namespace dtlMerceria
{
    
    public class dtlStock
    {

        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDBConnectionString"].ConnectionString);

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
        /// Obtiene los ID de Stock
        /// </summary>
        public int Fab_Text_2_ID(string _Fab)
        {
            SqlCommand command = new SqlCommand("SELECT id FROM fabricantes where descripcion='" + _Fab + "'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
            }
            reader.Close();
            return 0;

        }          
        /// <summary>
        /// Realiza el INSERT de los datos en Stock
        /// </summary>
        public void InsertDatos(string _Cod, 
                                int _id_fab,
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
                cmd.Parameters.Add("@id_fabricante", SqlDbType.Int).Value = _id_fab;
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
        public DataTable ObtenerFabricantes_Full()
        {

            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(
                   "SELECT * FROM fabricantes", conn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
         public DataTable ObtenerStock_basico()
         {
             using (conn)
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = conn;
                 DataTable dt = new DataTable();
          
                 try
                 {
                     conn.Open();
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.CommandText = "sp_sel_stock_basico";
                     SqlDataAdapter da = new SqlDataAdapter(cmd);

                     da.Fill(dt);                    
                     return dt;
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                     return null;
                 }   
                 
             }
         }


        /// <summary>
        /// Obtiene los datos de Stock, de los campos principales y todos los registros (COMPLETOS)
        /// FUNCIONA - SE PASO A STORED PROCEDURE (Para cumplir con los basicos Insert, Select, Update, Delete segun el Ejemplo de Capas)
        /// </summary>
     /*   public DataTable ObtenerStock_basico()
        {
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(
<<<<<<< HEAD
                   "exec sp_sel_stock_basico", conn))
=======
                   "SELECT id_codigo, id_fabricante, descripcion, precio, cant_actual FROM stock", conn))
>>>>>>> 803e905e4e6b7f2c7c92cdc58540cf6a452228ff
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
      */   
    
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
                                int _id_fab,
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
         cmd.Parameters.Add("@id_fabricante", SqlDbType.Int).Value = _id_fab;
         cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = _Desc;
         cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = _Precio;
         cmd.Parameters.Add("@cant_actual", SqlDbType.Int).Value = _Cant_Actual;
         cmd.Parameters.Add("@hash", SqlDbType.VarChar).Value = _hash_precio;

        cmd.Connection = conn;
        conn.Open();

        reader = cmd.ExecuteReader();

        conn.Close();
        }

        public DataTable CargaCombo() 
        {
            using (conn) {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                try
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_list_fabricantes";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            
            
            }



        }


    }
}
