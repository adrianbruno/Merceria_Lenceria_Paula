<%@ Page Language="C#" AutoEventWireup="true" CodeFile="c.aspx.cs" Inherits="c" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body style="background-color: #FFCCFF">
    <form id="form1" runat="server">
    <h1 style="font-family: 'Bodoni Bd BT'; font-size: xx-large; width: 641px; margin-left: 129px;">
        &nbsp;
        <asp:Image ID="Image1" runat="server" Height="66px" ImageUrl="~/imagenes/Logo_Paula_relleno.png" style="text-align: center" Width="325px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" Height="64px" ImageUrl="~/imagenes/salir.png" OnClick="ImageButton1_Click" Width="59px" />
        </h1>
    </form>
</body>
</html>
