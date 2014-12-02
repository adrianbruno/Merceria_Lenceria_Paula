<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menuEdi.aspx.cs" Inherits="menuEdi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color: #FFCCFF">
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="Medium" ForeColor="#990000" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#FFFBD6" />
            <DynamicSelectedStyle BackColor="#FFCC66" />
            <Items>
                <asp:MenuItem Text="VENTA" Value="VENTA">
                    <asp:MenuItem Text="Nueva" Value="Nueva"></asp:MenuItem>
                    <asp:MenuItem Text="Consulta" Value="Consutla">
                        <asp:MenuItem Text="Generales" Value="Generales"></asp:MenuItem>
                        <asp:MenuItem Text="Filtradas" Value="Filtradas"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="-" Value="-"></asp:MenuItem>
                <asp:MenuItem Text="STOCK" Value="STOCK">
                    <asp:MenuItem Text="ABM" Value="ABM" NavigateUrl="./frmStock.aspx" Target="abajo"></asp:MenuItem>
                    <asp:MenuItem Text="Consulta" Value="Consulta">
                        <asp:MenuItem Text="Generales" Value="Generales" NavigateUrl="./frmStock_Consulta_General.aspx" Target="abajo"></asp:MenuItem>
                        <asp:MenuItem Text="Filtradas" Value="Filtradas" NavigateUrl="./frmStock_Consulta_Filtrada.aspx" Target="abajo"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="-" Value="-"></asp:MenuItem>
                <asp:MenuItem Text="PROOVEDORES" Value="PROOVEDORES">
                    <asp:MenuItem Text="ABM" Value="ABM"></asp:MenuItem>
                    <asp:MenuItem Text="Consulta" Value="Consulta">
                        <asp:MenuItem Text="Generales" Value="Generales" NavigateUrl="frmStock_Consulta_General.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Filtradas" Value="Filtradas"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="-" Value="-"></asp:MenuItem>
                <asp:MenuItem Text="USUARIOS" Value="USUARIOS">
                    <asp:MenuItem Text="ABM" Value="ABM"></asp:MenuItem>
                    <asp:MenuItem Text="Consutlas" Value="Consutlas">
                        <asp:MenuItem Text="Generales" Value="Generales"></asp:MenuItem>
                        <asp:MenuItem Text="Filtradas" Value="Filtradas"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="-" Value="-"></asp:MenuItem>
                <asp:MenuItem Text="TABLAS AUXILIARES" Value="TABLAS AUXILIARES">
                    <asp:MenuItem Text="Provincias" Value="Provincias" NavigateUrl="~/frmProvincias.aspx" Target="abajo"></asp:MenuItem>
                    <asp:MenuItem Text="Localidades" Value="Localidades"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="frmFabricantes.aspx" Target="abajo" Text="Fabricantes" Value="Fabricantes"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="UTILES" Value="UTILES">
                    <asp:MenuItem Text="Copia de Resguardo" Value="Copia de Resguardo"></asp:MenuItem>
                    <asp:MenuItem Text="Restauracion de Copias" Value="Restauracion de Copias"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="AYUDA" Value="AYUDA">
                    <asp:MenuItem Text="Manual de Usuario" Value="Manual de Usuario"></asp:MenuItem>
                    <asp:MenuItem Text="Acerca de " Value="Acerca de "></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#990000" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#FFCC66" />
        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
