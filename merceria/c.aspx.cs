﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class c : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Form.Target = "_parent"; 
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./Default.aspx");
    }
}