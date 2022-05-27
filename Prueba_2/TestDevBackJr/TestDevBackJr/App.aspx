<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="TestDevBackJr.App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/CSS/Listas.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/Buttons.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="tabs-4" style="padding: 0px; padding-top: 4px;" class="Center">
            <div class="DivContenido ContenidoTitulo">
            <table class="Table">
                <tr>
                    <td colspan="2" align="center">
                        <h1><asp:Label ID="Label3" runat="server" Text="Usuarios" ForeColor="White"></asp:Label ></h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbluserId" runat="server" Text="userId:" Visible="false" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtuserId" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLogin" runat="server" Text="Login:" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPaterno" runat="server" Text="Paterno" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPaterno" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMaterno" runat="server" Text="Materno:" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMaterno" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSueldo" runat="server" Text="Sueldo:" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaIngreso" runat="server" Text="Fecha Ingreso:" Visible="false" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaIngreso" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAumento" runat="server" Text="% del Aumento:" Visible="false" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAumento" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnVerRegistros" runat="server" Text="Ver Registros" CssClass="button4" OnClick="btnVerRegistros_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button1" OnClick="btnAgregar_Click"/>
                        <asp:Button ID="btnGeneraAumento" runat="server" Text="Generar Aumento" CssClass="button2" Visible="false" OnClick="btnGeneraAumento_Click"/>
                        <asp:Button ID="btnGuardar" runat="server" Text="Genera .CVS" CssClass="button2" Visible="false" OnClick="btnGuardar_Click"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button1" OnClick="btnCancelar_Click"/>
                    </td>
                </tr>
            </table>
                </div>
        </div>
        <div >
            <asp:GridView ID="gvUsuario" CssClass="table_data" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="8" AllowSorting="true" ShowFooter="true" ForeColor="blue" BackColor="White" OnRowCommand="gvUsuario_RowCommand">
                    <PagerSettings Mode="NumericFirstLast" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10px" HeaderText="Cargar" >
                            <ItemTemplate>
                                <asp:Button ID="btnModificar" runat="server" CssClass="button2" Text='Cargar'  CommandName="Modificar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="userId" SortExpression="userId" HeaderText="userId" />
                        <asp:BoundField DataField="Login" SortExpression="Login" HeaderText="Login" />
                        <asp:BoundField DataField="Nombre" SortExpression="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Paterno" SortExpression="Paterno" HeaderText="Paterno" />
                        <asp:BoundField DataField="Materno" SortExpression="Materno" HeaderText="Materno" />
                        <asp:BoundField DataField="Sueldo" SortExpression="Sueldo" HeaderText="Sueldo" />
                        <asp:BoundField DataField="FechaIngreso" SortExpression="FechaIngreso" HeaderText="FechaIngreso" />
                    </Columns>
                    <AlternatingRowStyle CssClass="table_data_row2" />
                </asp:GridView>
           </div>
    </form>
</body>
</html>
