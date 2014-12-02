using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

using wflMerceria;
public partial class frmStock_Consulta_Filtrada : System.Web.UI.Page
{
    private void CargarFabricante()
    {
        wflGenerica obReg = new wflGenerica();
        cmbFabricantes.DataSource = obReg.ObtenerFabricantes();
        cmbFabricantes.DataValueField = "id";
        cmbFabricantes.DataTextField = "descripcion";
        cmbFabricantes.DataBind();
        cmbFabricantes.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));
    }
    private void CargarReporte()
    {
        StockDataSet.sp_sel_stock_basicoDataTable dt = new StockDataSet.sp_sel_stock_basicoDataTable();
        StockDataSetTableAdapters.sp_sel_stock_basicoTableAdapter da = new StockDataSetTableAdapters.sp_sel_stock_basicoTableAdapter();
        // da.Fill(dt);
        da.FillBy(dt, cmbFabricantes.SelectedItem.Value);

        ReportDataSource RD = new ReportDataSource();
        RD.Value = dt;
        RD.Name = "DataSet1";

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(RD);
        ReportViewer1.LocalReport.ReportEmbeddedResource = "rptStock2.rdlc";
        ReportViewer1.LocalReport.ReportPath = @"rptStock2.rdlc";
        ReportViewer1.LocalReport.Refresh();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarFabricante();
        }
    }
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}