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

            return reader.HasRows;

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
