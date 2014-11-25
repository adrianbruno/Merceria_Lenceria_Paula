using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using dtlMerceria;

namespace brlMerceria
{
    public class brlGenerica
    {
        public int Fab_Text_2_id(string _Fab)
        {
            dtlStock obReg = new dtlStock();
            return obReg.Fab_Text_2_ID(_Fab);
        }

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

      /// <summary>
      /// Obtiene los datos básico de STOCK
      /// </summary>
      public DataTable DatosStock_basico()
      {
          dtlStock obReg = new dtlStock();
          return obReg.ObtenerStock_basico();
      }
      public DataTable ObtenerFabricantes()
      {
          dtlStock obReg = new dtlStock();
          return obReg.ObtenerFabricantes_Full();
      }
      /// <summary>
      /// Realiza el UPDATE de los datos en STOCK
      /// </summary>
      public void UpdateDatosStock(string _cod, int _id_fab, string _desc, string _precio, string _MDC5, string _cant)
      {
          dtlStock obReg = new dtlStock();
          obReg.UpdateDatosStock(_cod,
                                 _id_fab,
                                 _desc,
                                 _precio,
                                 CalculateMD5Hash(_MDC5),
                                 _cant);
      }

      /// <summary>
      /// Realiza el INSERT de los datos en STOCK
      /// </summary>
      public void InsertDatosStock(string _cod, int _id_fab, string _desc,string _precio, string _MDC5, string _cant)
      {
          dtlStock obReg = new dtlStock();
          obReg.InsertDatos(_cod,
                            _id_fab,
                            _desc,
                            _precio,
                            CalculateMD5Hash(_precio + _cant),
                            _cant);
      }
      
      /// <summary>
      /// Borra los datos de STOCK
      /// </summary>
      public void BorrarDatosStock(string _cod)
      {
         dtlStock obReg = new dtlStock();
         obReg.BorrarDatosStock(_cod);
      }
    }
}
