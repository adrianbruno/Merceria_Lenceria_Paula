using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.Target = "topy"; 
    }
    protected void imgStock_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./frmStock.aspx");
    }
}