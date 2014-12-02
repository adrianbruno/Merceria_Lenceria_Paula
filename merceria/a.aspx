<%@ Page Language="C#" AutoEventWireup="true" CodeFile="a.aspx.cs" Inherits="menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bicicleteria el Moquito</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
    </head>
<body style="background-color: #FFCCFF; height: 423px; width: 112px;">
    <form id="form1" runat="server">
        <div class="auto-style1" style="font-family: Verdana; font-size: small">
            <asp:ImageButton ID="imgVenta" runat="server" Height="91px" ImageAlign="Baseline" ImageUrl="~/imagenes/Button_Cyan.png" OnClick="imgStock_Click" style="text-align: center" Width="94px" />
            <br />
            VENTA</div>
        <div class="auto-style1" style="font-family: Verdana; font-size: small">
            <asp:ImageButton ID="imgStock" runat="server" Height="91px" ImageAlign="Baseline" ImageUrl="~/imagenes/Button_Purple.png" OnClick="imgStock_Click" style="text-align: center" Width="94px" />
            <br />
            STOCK</div>
        <div class="auto-style1" style="font-family: Verdana; font-size: small">
            <asp:ImageButton ID="imgUsuarios" runat="server" Height="91px" ImageAlign="Baseline" ImageUrl="~/imagenes/Button_Red.png" OnClick="imgStock_Click" style="text-align: center" Width="94px" />
            <br />
            USUARIOS</div>
    </form>
</body>
</html>
