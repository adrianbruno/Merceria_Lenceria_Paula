using System;
using System.Data;

using dtlMerceria;
using wrlMerceria;


namespace brlMerceria
{
    public class brlStock
    {
      public string CalculateMD5Hash(string _input)
       {
           wrlGenerica cripto = new wrlGenerica();
           return cripto.CalculateMD5Hash(_input);
        }

      /// <summary>
      /// Obtiene los datos básico de STOCK
      /// </summary>
      public DataTable DatosStock_basico()
      {
          dtlStock obReg = new dtlStock();
          return obReg.DatosStock_basico();
      }

      /// <summary>
      /// Realiza el UPDATE de los datos en STOCK
      /// </summary>
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

      /// <summary>
      /// Realiza el INSERT de los datos en STOCK
      /// </summary>
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
