<%@ Page Language="C#" MasterPageFile="~/moebiusWeb.Master"  AutoEventWireup="true" CodeBehind="ABMTiposVias.aspx.cs" Inherits="Web.ABMTiposVias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">

<body>
    
    <div>
        <table>
        <tr>
            <td>
        
            <asp:GridView ID="grdTipoVias" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                DataKeyNames="idTipoVia" DataSourceID="lqTipoVias" GridLines="Horizontal" 
                    onselectedindexchanged="grdVias_SelectedIndexChanged">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <Columns>
                    <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ButtonType="Image" ShowSelectButton="True" 
                        SelectImageUrl="~/Imagenes/select.gif" />
                    <asp:BoundField DataField="idTipoVia" HeaderText="idTipoVia" InsertVisible="False" 
                        ReadOnly="True" SortExpression="idTipoVia" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" 
                        SortExpression="Descripcion" />                                             
                     <asp:TemplateField HeaderText="Estado Posición" SortExpression="idEstadoPosicion">
                        <ItemTemplate>
                            <asp:Label ID="lbEstadoPosicion" runat="server" Text='<%#Bind("Estados.Nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
            <asp:LinqDataSource ID="lqTipoVias" runat="server" ContextTypeName="Datos.DC" 
                TableName="Tipos_Via">
            </asp:LinqDataSource>
            
            </td>
        </tr>
        <tr>
            <td align=right>
            <asp:LinkButton ID="lnkNuevo" runat="server" 
                onclick="lnkNuevo_Click" Font-Bold="True" ForeColor="#1E21C0" 
                    Font-Names="Verdana" Font-Size="Small">Agregar Tipo de Vía</asp:LinkButton>   
            </td>
        </tr>
        </table>
        
    </div>
    <div>
        <asp:Panel ID="pnAlta" runat="server" Visible=false>
        
        <table>
            <tr>
                <td>Descripcion</td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="200" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Estado Posición</td>
                <td>
                    <asp:DropDownList ID="dropEstadoPosicion" runat="server">
                    </asp:DropDownList>                    
                </td>
            </tr>            
            <tr>
                <td colspan="2">
                    <table>
                    <tr>
                        <td>
                            <asp:LinkButton ID="linkInsertar" runat="server" onclick="linkInsertar_Click">Insertar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="linkModificar" runat="server" onclick="linkModificar_Click">Modificar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="linkEliminar" runat="server" onclick="linkEliminar_Click">Eliminar</asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="linkCancelar" runat="server" onclick="linkCancelar_Click">Cancelar</asp:LinkButton>
                        </td>
                    </tr>
                    </table>
                </td>
            </tr>
        </table>
                
        
        </asp:Panel>  
    </div>    
</body>
</html>
</asp:Content>
