<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMUsuarios.aspx.cs" Inherits="Web.ABMUsuarios" MasterPageFile="~/moebiusWeb.Master" %>

<asp:Content ContentPlaceHolderID="cphPrincipal" ID="ABMUsuariosPH" runat="server">
    <h1>Usuarios</h1>
    <table width="70%">
        <tr>
        <td colspan="2">
        <table width="100%"><tr><td>
        <asp:GridView ID="grdUsuarios" runat="server" DataSourceID="linqUsuarios" 
            AutoGenerateColumns="False" DataKeyNames="idUsuario" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal" AllowSorting="True" EnableModelValidation="True" 
                onselectedindexchanged="grdUsuarios_SelectedIndexChanged" 
                AllowPaging="True" PageSize="25" Width="100%">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ButtonType="Image" ShowSelectButton="True" 
                    SelectImageUrl="~/Imagenes/select.gif" />
                <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" 
                    InsertVisible="False" ReadOnly="True" SortExpression="idUsuario" 
                    Visible="False" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" >
                <HeaderStyle CssClass="linkNoUnderline" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" >
                <HeaderStyle HorizontalAlign="Left" CssClass="linkNoUnderline"  />
                </asp:BoundField>
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                    SortExpression="Apellido" >
                <HeaderStyle HorizontalAlign="Left"  CssClass="linkNoUnderline" />
                </asp:BoundField>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" 
                    SortExpression="Legajo" >
                <HeaderStyle HorizontalAlign="Right" CssClass="linkNoUnderline"  />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" >
                <HeaderStyle HorizontalAlign="Left" CssClass="linkNoUnderline"  />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        </td>
        </tr>
        <tr><td align="right">
            <asp:LinkButton ID="lnkNuevoUsuario" runat="server" 
                onclick="lnkNuevoUsuario_Click">Agregar Usuario</asp:LinkButton></td></tr></table>
        <asp:LinqDataSource ID="linqUsuarios" runat="server" 
            ContextTypeName="Datos.DC" EnableDelete="True" EnableInsert="True" 
            EnableUpdate="True" TableName="Usuarios">
        </asp:LinqDataSource>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <asp:DetailsView ID="dtvUsuario" runat="server" AutoGenerateRows="False" 
                DataKeyNames="idUsuario" DataSourceID="linqUsuario" Height="50px" 
                Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
                BorderWidth="1px" CellPadding="3" GridLines="Horizontal" 
                style="text-align: left" onitemdeleted="dtvUsuario_ItemDeleted" 
                oniteminserted="dtvUsuario_ItemInserted" onitemupdated="dtvUsuario_ItemUpdated"
                >
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <Fields>
                    <asp:BoundField DataField="idUsuario" HeaderText="idUsuario" 
                        InsertVisible="False" ReadOnly="True" SortExpression="idUsuario" />
                    <asp:TemplateField HeaderText="Login" SortExpression="Login">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLogin" runat="server" Text='<%# Bind("Login") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtLogin" Text="(*)" runat="server" id="reqLogin"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtLogin" runat="server" Text='<%# Bind("Login") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtLogin" Text="(*)" runat="server" id="reqLogin"></asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Login") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password" SortExpression="Password">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="******"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword" Text="(*)" runat="server" id="reqPass"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword" Text="(*)" runat="server" id="reqPass"></asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                        SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" 
                        SortExpression="Apellido" />
                    <asp:TemplateField HeaderText="Legajo" SortExpression="Legajo">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Legajo") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLegajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator
                            id="regLegajo"
                            ControlToValidate="txtLegajo"
                            Text="(*)"
                            ValidationExpression="(\d)*"
                            Runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtLegajo" runat="server" Text='<%# Bind("Legajo") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator
                            id="regLegajo"
                            ControlToValidate="txtLegajo"
                            Text="(*)"
                            ValidationExpression="(\d)*"
                            Runat="server" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="Email">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator
                            id="regEmail"
                            ControlToValidate="txtEmail"
                            Text="(*)"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Runat="server" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                            <asp:RegularExpressionValidator
                            id="regEmail"
                            ControlToValidate="txtEmail"
                            Text="(*)"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Runat="server" />                            
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ShowDeleteButton="True" 
                        ShowEditButton="True" ShowInsertButton="True"  />
                </Fields>
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:DetailsView>
            <asp:LinqDataSource ID="linqUsuario" runat="server" 
                ContextTypeName="Datos.DC" EnableDelete="True" EnableInsert="True" 
                EnableUpdate="True" TableName="Usuarios" Where="idUsuario == @idUsuario">
                <WhereParameters>
                    <asp:ControlParameter ControlID="grdUsuarios" Type="Int32" DefaultValue="0" Name="idUsuario" 
                        PropertyName="SelectedValue" />
                </WhereParameters>
            </asp:LinqDataSource>
            <br />
            <asp:Label ID="lblMensajeError" runat="server" ForeColor="#CC0000"></asp:Label>
        </td>
        <td valign="top">
            <table width="100%">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                            <asp:GridView ID="grdGrupos_Usuario" runat="server" AutoGenerateColumns="False" 
                                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" DataKeyNames="id" DataSourceID="linqUsuarios_Grupos" 
                                GridLines="Horizontal" AllowSorting="True" Visible="False">
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <EmptyDataTemplate>Sin perfiles asociados</EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="Perfiles del Usuario" 
                                        SortExpression="idGrupo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Grupos.Nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ShowDeleteButton="True" 
                                        DeleteImageUrl="~/Imagenes/delete.gif" />
                                </Columns>
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                            </asp:GridView>
                            <asp:LinqDataSource ID="linqUsuarios_Grupos" runat="server" 
                                ContextTypeName="Datos.DC" EnableDelete="True" EnableInsert="True" 
                                EnableUpdate="True" TableName="Usuarios_Grupos" Where="idUsuario == @idUsuario">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="grdUsuarios" Name="idUsuario" 
                                        PropertyName="SelectedValue" Type="Int32"  DefaultValue="0" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="dpGrupos" runat="server" DataSourceID="linqGrupos" 
                                    DataTextField="Nombre" DataValueField="idGrupo" 
                                AppendDataBoundItems="true" Visible="False" >
                                    <asp:ListItem Value="0" Text="Agregar Perfil" Selected="True"></asp:ListItem>
                                </asp:DropDownList>              
                                <asp:LinqDataSource ID="linqGrupos" runat="server" ContextTypeName="Datos.DC" 
                                    TableName="Grupos">
                                </asp:LinqDataSource>
                                <br />
                            </td>
                            <td align="right">
                                <asp:Button ID="btAgregarGrupo" runat="server" onclick="btAgregarGrupo_Click" 
                                    Text="Agregar" Visible="False" />                
                            </td>                
                    </tr>
                    <tr><td colspan="2"><asp:Label ID="lblMensajeGrupo" runat="server" ForeColor="#CC0000"></asp:Label></td></tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td>
            <asp:GridView ID="grdZonas" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataKeyNames="idReg" DataSourceID="linqUsuariosZonas" 
                GridLines="Horizontal" AllowSorting="True" Visible="False">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <EmptyDataTemplate>Sin Zonas Asociadas</EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Zonas del Usuario" 
                        SortExpression="idZonas">
                        <ItemTemplate>
                            <asp:Label ID="lblZona" runat="server" Text='<%# Eval("Zonas.Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ShowDeleteButton="True" 
                        DeleteImageUrl="~/Imagenes/delete.gif" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
            <asp:LinqDataSource ID="linqUsuariosZonas" runat="server" 
                ContextTypeName="Datos.DC" EnableDelete="True" TableName="Usuarios_Zonas" 
                    Where="idUsuario == @idUsuario">
                <WhereParameters>
                    <asp:ControlParameter ControlID="grdUsuarios" Name="idUsuario" 
                        PropertyName="SelectedValue" Type="Int32"  DefaultValue="0" />
                </WhereParameters>
            </asp:LinqDataSource>
            </td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="dpZonas" runat="server" DataSourceID="linqZonas" 
                    DataTextField="Descripcion" DataValueField="idZona" 
                AppendDataBoundItems="true" Visible="False">
                    <asp:ListItem Value="0" Text="Agregar Zona" Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnAgregarZona" runat="server" onclick="btnAgregarZona_Click" 
                    Text="Agregar" Visible="False" />
                <asp:LinqDataSource ID="linqZonas" runat="server" ContextTypeName="Datos.DC" 
                    TableName="Zonas">
                </asp:LinqDataSource>
                <br />
            <asp:Label ID="lblMensajeZona" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
            </tr>

            <tr><td>
            <asp:GridView ID="grdSectores" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" DataKeyNames="idReg" DataSourceID="linqUsuariosSectores" 
                GridLines="Horizontal" AllowSorting="True" Visible="False">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <EmptyDataTemplate>Sin Sectores Asociados</EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Sectores del Usuario" 
                        SortExpression="idSectorResponsable">
                        <ItemTemplate>
                            <asp:Label ID="lblSector" runat="server" Text='<%# Eval("Sectores_Responsables.Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ShowDeleteButton="True" 
                        DeleteImageUrl="~/Imagenes/delete.gif" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
            <asp:LinqDataSource ID="linqUsuariosSectores" runat="server" 
                ContextTypeName="Datos.DC" EnableDelete="True" TableName="Usuarios_Sectores" 
                    Where="idUsuario == @idUsuario">
                <WhereParameters>
                    <asp:ControlParameter ControlID="grdUsuarios" Name="idUsuario" 
                        PropertyName="SelectedValue" Type="Int32"  DefaultValue="0" />
                </WhereParameters>
            </asp:LinqDataSource>
            </td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="dpSectores" runat="server" DataSourceID="linqSectores" 
                    DataTextField="Descripcion" DataValueField="idSectorResponsable" 
                AppendDataBoundItems="true" Visible="False" >
                    <asp:ListItem Value="0" Text="Agregar Sector" Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btnAgregarSector" runat="server" 
                    Text="Agregar" Visible="False" onclick="btnAgregarSector_Click" />
                <asp:LinqDataSource ID="linqSectores" runat="server" ContextTypeName="Datos.DC" 
                    TableName="Sectores_Responsables">
                </asp:LinqDataSource>
                <br />
            <asp:Label ID="lblMensajeSector" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
            </tr>



            </table>
        </td>
    </tr>
    </table>
</asp:Content>