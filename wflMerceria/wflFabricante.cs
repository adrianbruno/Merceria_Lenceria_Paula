using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using brlMerceria;
using System.Data;

namespace wflMerceria
{
    public class wflFabricante
    {

        public DataTable ObtListFab()
        {
            brlFabricante x = new brlFabricante();
            return x.ObtListFab();
        }

    }
}
