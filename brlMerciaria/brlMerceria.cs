using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using System.Data.SqlClient;
using System.Data;

using dtlMerceria;

namespace brlMerceria
{
    public class brlStock
    {
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
      
      public DataTable DatosStock_basico()
      {
          dtlStock obReg = new dtlStock();
          return obReg.DatosStock_basico();
      }

      public void UpdateDatosStock(string _cod, string _fab, string _desc, string _precio, string _cant)
      {
          dtlStock obReg = new dtlStock();
          obReg.UpdateDatosStock(_cod,
                                 _fab,
                                 _desc,
                                 _precio,
                                 CalculateMD5Hash(_precio + _cant),
                                 _cant);
      }

      public void InsertDatosStock(string _cod, string _fab, string _desc,string _precio, string _cant)
      {
          dtlStock obReg = new dtlStock();
          obReg.InsertDatos(_cod,
                            _fab,
                            _desc,
                            _precio,
                            CalculateMD5Hash(_precio + _cant),
                            _cant);
      }
      public void BorrarDatosStock(string _cod)
      {
         dtlStock obReg = new dtlStock();
         obReg.BorrarDatosStock(_cod);
      }
    }
}
