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
            width: 102px;
            text-align: right;
        }
        .auto-style3 {
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style6 {
            width: 471px;
            height: 35px;
        }
        .auto-style7 {
            width: 494px;
        }
        .auto-style10 {
            height: 36px;
        }
        .auto-style11 {
            width: 102px;
            text-align: right;
            height: 36px;
        }
        .auto-style12 {
            width: 494px;
            height: 36px;
        }
        .auto-style14 {
            height: 35px;
        }
        .auto-style16 {
            width: 102px;
            text-align: right;
            height: 35px;
        }
        .auto-style17 {
            width: 494px;
            height: 35px;
        }
        .auto-style24 {
            width: 102px;
            text-align: right;
            height: 37px;
        }
        .auto-style25 {
            height: 37px;
        }
        .auto-style26 {
            width: 494px;
            height: 37px;
        }
        .auto-style27 {
            width: 102px;
            text-align: right;
            height: 34px;
        }
        .auto-style28 {
            height: 34px;
        }
        .auto-style29 {
            width: 494px;
            height: 34px;
        }
        </style>
</head>
<body style="background-color: #FFCCFF; height: 380px; width: 604px;">

    <form id="form1" runat="server">
        <div class="auto-style1" style="margin-left: 155px; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: large; width: 315px; height: 26px;">
            Venta productos</div>
        <div style="height: 416px; width: 568px">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style11">Codigo</td>
                    <td class="auto-style10">
<script language="JavaScript">
 function numbersonly(e)
  {
    var unicode=e.charCode? e.charCode : e.keyCode
    if (unicode!=8 && unicode!=44)
    {
      if (unicode<48||unicode>57) //if not a number
      { return false} //disable key press    
    }  
  }  
</script>
                        <asp:DropDownList ID="cmbCodigo" runat="server" Font-Size="Large" Height="30px" 
                            OnSelectedIndexChanged="cmbFabricantes_SelectedIndexChanged"
                            AutoPostBack="True"
                            style="margin-top: 0px" Width="140px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">Fabricante</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="txtFabricante" runat="server" Height="30px" Width="310px" ></asp:TextBox>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Descripción&nbsp; </td>
                    <td class="auto-style25">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="30px" Width="310px" ></asp:TextBox>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style16">Precio </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtPrecio" runat="server" Height="30px" Width="136px" ></asp:TextBox>
                    &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="auto-style27">Cantidad </td>
                    <td class="auto-style28">
                        <asp:DropDownList ID="cmbCant" runat="server" Font-Size="Large" Height="30px" 
                            OnSelectedIndexChanged="cmbFabricantes_SelectedIndexChanged"
                            AutoPostBack="True"
                            style="margin-top: 0px" Width="140px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">
                        
                        <asp:GridView ID="gvDatos" runat="server" 
                            CellPadding="4" AllowPaging="true" ForeColor="#333333" GridLines="Vertical" Height="135px" Width="463px" 
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
