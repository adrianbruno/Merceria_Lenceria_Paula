using System;
using System.Text;
using System.Data;
using brlMerceria;

namespace wflMerceria
{
    public class wflusuario
    {
        public DataTable ObtenerProvLoca()
        {
            brlGenerica obReg = new brlGenerica();
            return obReg.DatosProvLoca();

        }
    }
}
