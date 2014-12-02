<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStock_Consulta_Filtrada.aspx.cs" Inherits="frmStock_Consulta_Filtrada" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            text-align: center;
            width: 825px;
            background-color: #000000;
        }
    </style>
</head>
<body style="background-color: #FFCCFF">
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <strong>REPORTE STOCK - Consutla Filtrada</strong></div>
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Seleccionar Fabricante
            <asp:DropDownList ID="cmbFabricantes" 
                runat="server" 
                Height="18px" 
                Width="168px"
                AutoPostBack="False">
            </asp:DropDownList>
            <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="filtrar" Width="98px" />
        </p>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" style="margin-right: 0px" Width="823px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
