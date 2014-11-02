/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace dtlMerceria
{
    public class dtlFabricante
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDB"].ConnectionString);

        /// <summary>
        /// RECUPERA un registro según el id proporcionado, tabla fabricantes
        /// </summary>   
        public DataTable ObtenerFabricante(int id_fabricante)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                
                try
                {
                    conn.Open();
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_sel_fabricante";
                    cmd.Parameters.Add("@id_fabricante", SqlDbType.Int).Value = id_fabricante;

                    DataTable tabla = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    return tabla;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            
        }

        /// <summary>
        /// INSERTA un registro a la tabla fabricante
        /// </summary>
        public void InsertaFabricante(int id_fabricante, string descripcion)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                
                try
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_ins_fabricante";
                    cmd.Parameters.Add("@id_fabricante", SqlDbType.Int).Value = id_fabricante;
                    cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        /// <summary>
        /// ELIMINA un registro según el id proporcionado, tabla fabricantes
        /// </summary>
        public void EliminaFabricante(int id_fabricante)
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                try
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_del_fabricante";
                    cmd.Parameters.Add("@id_fabricante", SqlDbType.Int).Value = id_fabricante;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public DataTable ObtListFab()
        {
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                try
                {
                    conn.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_list_fabricantes";
                     
                    DataTable tabla = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                     
                    return tabla;

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
