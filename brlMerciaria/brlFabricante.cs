using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using dtlMerceria;

namespace brlMerceria
{
    public class brlFabricante
    {
        public DataTable ObtListFab()
        { 
          dtlFabricante x = new dtlFabricante();
          return x.ObtListFab();
        }
    }
}
