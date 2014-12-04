using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace dtlMerceria
{
    public class dtlProvLoc
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MerceriaDBConnectionString"].ConnectionString);
        
        /// <summary>
        /// RECUPERA un registro según el id proporcionado, tabla fabricantes
        /// </summary>   
        public DataTable ObtenerProvLoca()
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
                    //cmd.CommandText = "sp_sel_loc";

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