using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dtlMerceria;
using System.Windows.Forms;

namespace brlMerceria
{
    public class brlFabricante
    {
        public DataTable ObtListFab()
        { 
          dtlFabricante x = new dtlFabricante();
          return x.ObtListFab();
        }
        public int desc2id(string _Desc)
        {
            dtlFabricante x = new dtlFabricante();
            return x.desc2id(_Desc);
        }

    }
}
