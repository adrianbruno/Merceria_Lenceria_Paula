<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStock_Consulta_General.aspx.cs" Inherits="frmStock_Consulta_General" %>

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
            width: 822px;
            background-color: #000000;
        }
    </style>
</head>
<body style="background-color: #FFCCFF">
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <strong>REPORTE STOCK - Consutla General</strong></div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="822px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
