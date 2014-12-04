using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wflMerceria;

public partial class frmProvincias : System.Web.UI.Page
{
    private void CargarDatos()
    {
        // Carga los datos en la grilla para poder seleccionarlos
        wflusuario obReg = new wflusuario();
        gvDato.DataSource = obReg.ObtenerProvLoca();
        gvDato.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarDatos();
    }
    protected void gvDatos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
        }
    }
}