<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmFabricantes.aspx.cs" Inherits="frmFabricantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            background-color: #000000;
            width: 807px;
        }
    </style>
</head>
<body style="background-color: #FFCCFF">
    <form id="form1" runat="server">
    <div>
    
        <div class="auto-style1">
            <strong>TABLA Auxiliares - FABRICANTES</strong></div>
        <asp:GridView ID="gvDatos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Height="145px" OnRowDataBound="gvDatos_RowDataBound" Width="426px">
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <br />
    
    </div>
        <asp:Button ID="btnSalir" runat="server" Height="63px" OnClick="btnSalir_Click" Text="Salir" Width="94px" />
    </form>
</body>
</html>
