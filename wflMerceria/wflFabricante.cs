using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using brlMerceria;

namespace wflMerceria
{
    public class wflFabricante
    {

        public DataTable ObtListFab()
        {
            brlFabricante x = new brlFabricante();
            return x.ObtListFab();
        }
        public int desc2id(string _Desc)
        {
            brlFabricante x = new brlFabricante();
            return x.desc2id(_Desc);
        }

    }
}
