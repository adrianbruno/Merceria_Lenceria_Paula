<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Mercería Lencería Paula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>nuevo Login</title>
    <style type="text/css">
        #cabecera {
            height: 7px;
            width: 351px;
            background-color: #000000;
        }
        #final {
            height: 23px;
            width: 370px;
            color: #FFFFFF;
            text-align: right;
            margin-top: 22px;
            background-color: #000000;
        }
    </style>
    </head>
    <body style="height: 373px; background-color: #FFCCFF">
        
        <form id="form1" runat="server">
            <div id="principal" style="height: 357px; width: 371px; text-align: center; margin-left: 220px">
                <br />
                <div id="cabecera">
                    <h1 style="width: 285px">Pantalla de ingreso</h1>
                    <div id="controles" style="width: 371px; height: 254px; background-color: #FFFFFF; position: static; z-index: auto;">
                        <br />
                        <asp:Label ID="lblUsuario" runat="server" Font-Names="Verdana" Font-Size="Medium" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtUserName" runat="server" Height="27px" Width="148px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblPassword" runat="server" Font-Names="Verdana" Font-Size="Medium" Text="Contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtPassword" runat="server" Height="27px" TextMode="Password" Width="148px"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btnIngresar" runat="server" Height="35px" OnClick="btnIngresar_Click" Text="Ingresar" Width="110px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSalir" runat="server" Height="38px" OnClick="btnSalir_Click" Text="Limpiar Textos" Width="110px" />
                        <div id="final">
                            Mercería Lencería Paula, versión 1.2<br />
                        </div>
                    </div>
                </div>
            </div>
        </form>
        
    </body>
</html>
