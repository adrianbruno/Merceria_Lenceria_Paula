using System;
using System.Text;
using System.Data;

using brlMerceria;

namespace wflMerceria
{
    public class wflGenerica
    {
        /// <summary>
        /// Obtiene los datos básicos de STOCK
        /// </summary>
        public DataTable DatosStock_basico()
        {
            brlGenerica obReg = new brlGenerica();
            return obReg.DatosStock_basico();
        }
        public void UpdateDatosStock(string _cod, int _id_fab, string _desc, string _precio, string _cant)
        {

            brlGenerica obReg = new brlGenerica();
            
            obReg.UpdateDatosStock(_cod,
                                   _id_fab,
                                   _desc,
                                   _precio,
                                   (_precio + _cant),
                                   _cant);
        }
        /// <summary>
        /// Realiza el INSERT de los datos en STOCK
        /// </summary>
        public void InsertDatosStock(string _cod, int _id_fab, string _desc, string _precio, string _cant)
        {
            brlGenerica obReg = new brlGenerica();

            obReg.InsertDatosStock(_cod,
                              _id_fab,
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

        /// <summary>
        /// FALTA CREAR FUNCION
        /// </summary>
        public bool ExisteVentaTemp(string _Usuario){ return false;}

        /// <summary>
        /// FALTA CREAR FUNCION
        /// </summary>
        public bool CreoVentaTemp(string _Usuario) { return false; }

    }
}
