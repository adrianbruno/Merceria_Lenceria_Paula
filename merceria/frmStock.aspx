<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStock.aspx.cs" Inherits="frmStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FFFFFF;
            background-color: #000000;
        }
        .auto-style2 {
            width: 178px;
            text-align: right;
        }
        .auto-style3 {
            width: 471px;
        }
        .auto-style4 {
            height: 23px;
        }
        </style>
</head>
<body style="background-color: #FFCCFF; height: 380px; width: 604px;">

    <form id="form1" runat="server">
        <div class="auto-style1" style="margin-left: 155px; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: large; width: 315px; height: 26px;">
            ABM productos</div>
        <div style="height: 416px; width: 476px">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">Codigo</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCodigo" runat="server" Height="30px" Width="75px" 
                            Enabled="False" 
                            OnTextChanged="txtCodigo_TextChanged"
                            AutoPostBack="true">
                        </asp:TextBox>
                        <asp:TextBox ID="txtFabricante" runat="server" Height="30px" Width="64px" OnTextChanged="txtFabricante_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtFab" runat="server" Height="30px" Width="74px" OnTextChanged="txtFabricante_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Fabricante</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="cmbFabricantes" runat="server" Font-Size="Large" Height="49px" OnSelectedIndexChanged="cmbFabricantes_SelectedIndexChanged" style="margin-top: 0px" Width="310px">
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Descripción&nbsp; </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="30px" Width="310px" OnTextChanged="txtDescripcion_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Precio </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPrecio" runat="server" Height="30px" Width="136px" OnTextChanged="txtPrecio_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Cantidad </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="76px" OnTextChanged="txtCantidad_TextChanged"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        
                        <asp:GridView ID="gvDatos" runat="server" 
                            CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Vertical" Height="135px" Width="335px" 
                            PageSize="5" 
                            OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" 
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PageButtonCount="5" Position="Top" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style4">
                <asp:Button ID="btnNuevo" runat="server" Height="58px" OnClick="btnAceptar_Click" Text="Nuevo" Width="103px" style="text-align: center" />
                                </td>
                                <td class="auto-style4">
                <asp:Button ID="btnGuardar" runat="server" Height="58px" OnClick="btnGuardar_Click" Text="Guardar" Width="103px" style="text-align: center" />
                                </td>
                                <td class="auto-style4">

                <asp:Button ID="btnBorrar" runat="server" Height="58px" Text="Borrar" Width="103px" style="text-align: center" 
                    onclientclick="return confirm('¿Realmente desea borrar el registro?');"
                    OnClick="btnBorrar_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <p style="margin-left: 40px">
                &nbsp;</p>
        </div>
    </form>

</body>
</html>
