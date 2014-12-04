<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmStock.aspx.cs" Inherits="frmStock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {            height: 199px;
            text-align: right;
        }
        .auto-style4 {
            height: 23px;
            text-align: center;
            width: 253px;
        }
        .auto-style31 {
            color: #FFFFFF;
            text-align: left;
            width: 607px;
            background-color: #000000;
        }
        .auto-style52 {
            text-align: right;
            height: 66px;
        }
        .auto-style58 {
            width: 846px;
            height: 406px;
            margin-right: 118px;
        }
        .auto-style64 {
            font-family: Verdana, Geneva, Tahoma, sans-serif;
            text-align: left;
        }
        .auto-style74 {
            height: 23px;
            width: 111px;
            text-align: center;
        }
        .auto-style75 {
            height: 42px;
            width: 99px;
            text-align: right;
        }
        .auto-style78 {
            height: 23px;
            width: 103px;
            text-align: center;
        }
        .auto-style83 {
            width: 87px;
            text-align: right;
            height: 42px;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
        .auto-style85 {
            height: 42px;
            width: 133px;
        }
        .auto-style87 {
            width: 99px;
            text-align: right;
            height: 42px;
            font-family: Verdana, Geneva, Tahoma, sans-serif;
        }
        .auto-style88 {
            height: 42px;
            width: 499px;
        }
        </style>
    <script type="text/javascript">
        function setHourGlass() {
            document.body.style.cursor = 'wait';
        }
</script>
</head>
<body  onbeforeunload="setHourglass();" onunload="setHourglass();" style="background-color: #FFCCFF; height: 811px; width: 854px;">
            <div class="auto-style31">
                <strong style="text-align: center">ABM de PRODUCTOS</strong></div>

    <form id="form1" runat="server">
        
            <table class="auto-style58">
                <tr>
                    <td class="auto-style83">Codigo</td>
                    <td class="auto-style85">
                        <asp:TextBox ID="txtCodigo" runat="server" Height="30px" Width="75px" 
                            Enabled="False" 
                            AutoPostBack="true" CssClass="auto-style64"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="&lt;- error" ForeColor="Red" ValidationExpression="[A-Z|0-9]{3,6}"></asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style87">Fabricante</td>
                    <td class="auto-style88">
                        <asp:DropDownList ID="cmbFabricantes" runat="server" Font-Size="Large" Height="30px" 
                            style="margin-top: 0px; text-align: right;" Width="248px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style83">Precio </td>
                    <td class="auto-style85">
                        <asp:TextBox ID="txtPrecio" runat="server" Height="30px" Width="74px" style="text-align: right" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="&lt;- error" ForeColor="Red" ValidationExpression="^\d{1,3}(?:,\s?\d{3})*(?:\,\d*)?$"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                    <td class="auto-style87">Descripción&nbsp; </td>
                    <td class="auto-style88">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="30px" Width="241px" style="text-align: left" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revDescrpcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="&lt;-Mayusculas" ForeColor="Red" ValidationExpression="[A-Z|0-9]{3,}"></asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style83">Cantidad </td>
                    <td class="auto-style85">
                        <asp:TextBox ID="txtCantidad" runat="server" Height="30px" Width="76px" style="text-align: right" ></asp:TextBox>
                        <asp:RangeValidator ID="rvCant" runat="server" ControlToValidate="txtCantidad" ErrorMessage="&lt;- error" ForeColor="Red" MaximumValue="99" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td class="auto-style75">
                    </td>
                    <td class="auto-style88">
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" colspan="4">
                        
                        <asp:GridView ID="gvDatos" runat="server" 
                            CellPadding="4" AllowPaging="true"  ForeColor="#333333" GridLines="Vertical" Height="135px" Width="472px" 
                            PageSize="5" 
                            OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" 
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                             OnRowDataBound="gvDatos_RowDataBound" style="margin-left: 86px"
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
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style52" colspan="4">
                        
                        <table style="width:52%;">
                            <tr>
                                <td class="auto-style74">
                <asp:Button ID="btnNuevo" runat="server" Height="58px" OnClick="btnAceptar_Click" Text="Nuevo" Width="111px" style="text-align: center" />
                                </td>
                                <td class="auto-style78">
                <asp:Button ID="btnGuardar" runat="server" Height="58px" OnClick="btnGuardar_Click" Text="Guardar" Width="103px" style="text-align: center" />
                                </td>
                                <td class="auto-style78">

                <asp:Button ID="btnBorrar" runat="server" Height="58px" Text="Borrar" Width="103px" style="text-align: center; margin-right: 0px;" 
                    OnClick="btnBorrar_Click" />
                                </td>
                                <td class="auto-style4">
                        
                <asp:Button ID="btnSalir" runat="server" Height="58px" Text="Salir" Width="103px" style="text-align: center" 
                    OnClick="btnSalir_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>

    </form>

</body>
</html>
