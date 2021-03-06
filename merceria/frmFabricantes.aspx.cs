﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using wflMerceria;

public partial class frmFabricantes : System.Web.UI.Page
{
    private void CargarDatos()
    {
        // Carga los datos en la grilla para poder seleccionarlos
        wflFabricante obReg = new wflFabricante();
        gvDatos.DataSource = obReg.ObtListFab();
        gvDatos.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarDatos();
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("./b.aspx");
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