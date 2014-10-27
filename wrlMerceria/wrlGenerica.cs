using System;
using System.Text;
using System.Data;

using brlMerceria;

namespace wrlMerceria
{
    public class wrlGenerica
    {
        /// <summary>
        /// Obtiene los datos básico de STOCK
        /// </summary>
        public DataTable DatosStock_basico()
        {
            brlGenerica obReg = new brlGenerica();
            return obReg.DatosStock_basico();
        }
        public void UpdateDatosStock(string _cod, string _fab, string _desc, string _precio, string _cant)
        {

            brlGenerica obReg = new brlGenerica();
            obReg.UpdateDatosStock(_cod,
                                   _fab,
                                   _desc,
                                   _precio,
                                   (_precio + _cant),
                                   _cant);
        }
        /// <summary>
        /// Realiza el INSERT de los datos en STOCK
        /// </summary>
        public void InsertDatosStock(string _cod, string _fab, string _desc, string _precio, string _cant)
        {
            brlGenerica obReg = new brlGenerica();
            obReg.InsertDatosStock(_cod,
                              _fab,
                              _desc,
                              _precio,
                              (_precio + _cant),
                              _cant);
        }
        /// <summary>
        /// Borra los datos de STOCK
        /// </summary>
        public void BorrarDatosStock(string _cod)
        {
            brlGenerica obReg = new brlGenerica();
            obReg.BorrarDatosStock(_cod);
        }
      
    }
}
