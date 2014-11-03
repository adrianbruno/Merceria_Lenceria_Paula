using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wflMerceria;

namespace Merceria_Lenceria_Paula
{
    public partial class frmFabricante : Form
    {
        public frmFabricante()
        {
            InitializeComponent();
            ObtListFab();

        }
        
        private void ObtListFab()
        {
            Cursor.Current = Cursors.WaitCursor;

            // Carga los datos en la grilla para poder seleccionarlos
            wflFabricante x = new wflFabricante();
            DataTable dt = x.ObtListFab();
            this.gvDatos.DataSource = dt;

            Cursor.Current = Cursors.Default;
        }



        private void gvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.ObtListFab();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
