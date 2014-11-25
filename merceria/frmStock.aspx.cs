using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

using wflMerceria;


public partial class frmStock : System.Web.UI.Page
{
    private void CargarDatos()
    {
        // Carga los datos en la grilla para poder seleccionarlos
        wflGenerica obReg = new wflGenerica();
        gvDatos.DataSource = obReg.DatosStock_basico();
        gvDatos.DataBind();
    }
    private void CargarFabricante()
    {
        wflGenerica obReg = new wflGenerica();
        cmbFabricantes.DataSource = obReg.ObtenerFabricantes();
        cmbFabricantes.DataValueField = "id";
        cmbFabricantes.DataTextField = "descripcion";
        cmbFabricantes.DataBind();
        cmbFabricantes.Items.Insert(0, new ListItem("Elija una Opcion..", "0"));  
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarDatos();
        CargarFabricante();
        txtCodigo.Focus();
    }
    private int Fab_Text_2_Id(string _Fab)
    {
        wflGenerica obReg = new wflGenerica();
        return obReg.Fab_Text_2_id(_Fab);

    }
    private void InsertDatos()
    {
        // Realiza el insert de los datos en STOCK
        wflGenerica obReg = new wflGenerica();
        obReg.InsertDatosStock(txtCodigo.Text,
                               txtFabricante.Text,
                               txtDescripcion.Text,
                               txtPrecio.Text,
                               txtCantidad.Text);

     
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        txtCodigo.Enabled = true;
        gvDatos.Enabled = false;
        Limpiar_Controles();
    }

    protected void gvDatos_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigo.Text= gvDatos.SelectedRow.Cells[1].Text;
        txtFabricante.Text = gvDatos.SelectedRow.Cells[2].Text;
        cmbFabricantes.Items.FindByText(txtFabricante.Text).Selected = true;
        txtDescripcion.Text = gvDatos.SelectedRow.Cells[3].Text;
        txtPrecio.Text = gvDatos.SelectedRow.Cells[4].Text;
        txtCantidad.Text = gvDatos.SelectedRow.Cells[5].Text;
        btnBorrar.Enabled = true;
        txtFab.Text = cmbFabricantes.SelectedValue.ToString();
        //txtFab.Text = Fab_Text_2_Id(txtFabricante.Text).ToString();
    }
    private void Limpiar_Controles()
    {
        txtCodigo.Text = "";
        txtFabricante.Text = "";
        txtDescripcion.Text = "";
        txtPrecio.Text = "";
        txtCantidad.Text = "";
        txtCodigo.Focus();
        btnBorrar.Enabled = false;
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        
        // Realiza el borrado del registro de STOCK
        wflGenerica obReg = new wflGenerica();
        obReg.BorrarDatosStock(txtCodigo.Text);
        Limpiar_Controles();
        CargarDatos();

    }

    protected void gvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDatos.PageIndex = e.NewPageIndex;
        CargarDatos();
        gvDatos.DataBind();
    }
    private void UpdateDatos()
    {

        // Realiza el update de los datos en STOCK
        wflGenerica obReg = new wflGenerica();
        obReg.UpdateDatosStock(txtCodigo.Text,
                               cmbFabricantes.DataValueField.ToString(),
                               txtDescripcion.Text,
                               txtPrecio.Text,
                               txtCantidad.Text);

    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (Todo_OK())
        {
            if (!txtCodigo.Enabled)
            {
                // Si boton NUEVO no está habilitado es un UPDATE
                UpdateDatos();
                Limpiar_Controles();
                CargarDatos();
            }
            else
            {
                // Sino es un INSERT
                InsertDatos();
                Limpiar_Controles();
                CargarDatos();
            }
        }
        // Pongo los controles en flase para empezar de nuevo
        // btnGuardar.Enabled = false;
        txtCodigo.Enabled = false;
        gvDatos.Enabled = true;
    }
    private bool Todo_OK()
    {
        // Controla que TODOS los campos estén correctos
        if (txtCodigo.Text.Length > 0 &&
             txtFabricante.Text.Length > 0 &&
             txtDescripcion.Text.Length > 0 &&
             txtPrecio.Text.Length > 0 &&
             txtCantidad.Text.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void txtCodigo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtFabricante_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtDescripcion_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtPrecio_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtCantidad_TextChanged(object sender, EventArgs e)
    {

    }

    protected void cmbFabricantes_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFab.Text = cmbFabricantes.SelectedValue.ToString();
    }
}