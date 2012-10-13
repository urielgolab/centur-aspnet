<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMPerfiles.aspx.cs" Inherits="Web.ABMGrupos" MasterPageFile="~/moebiusWeb.Master" %>
<asp:Content ContentPlaceHolderID="cphPrincipal" ID="ABMGruposPH" runat="server">
    <h1>Perfiles</h1>
    <script type="text/javascript" language="javascript">
    function CheckAllDataGridCheckBoxes(aspCheckBoxID, checkVal) {
        //re = new RegExp(':' + aspCheckBoxID + '$')  //generated control name starts with a colon
        for(i = 0; i < document.forms[0].elements.length; i++) {
            elm = document.forms[0].elements[i]
            if (elm.type == 'checkbox') {
                elm.checked = checkVal;
            }
        }
    }    
    </script>
    <table width="60%">
    <tr>    
        <td colspan="2" align="center">
        <asp:GridView ID="grdGrupos" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataKeyNames="idGrupo" DataSourceID="linqGrupos" 
            GridLines="Horizontal" Width="100%" AllowSorting="True" 
                onselectedindexchanged="grdGrupos_SelectedIndexChanged" 
                onrowdeleted="grdGrupos_RowDeleted">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  ButtonType="Image" 
                    SelectImageUrl="~/Imagenes/select.gif" 
                    CancelImageUrl="~/Imagenes/cancel.gif" DeleteImageUrl="~/Imagenes/delete.gif" 
                    EditImageUrl="~/Imagenes/edit.gif" InsertImageUrl="~/Imagenes/insert.gif" 
                    NewImageUrl="~/Imagenes/New.gif" 
                    UpdateImageUrl="~/Imagenes/update.gif" ShowSelectButton="True" />
                <asp:BoundField DataField="idGrupo" HeaderText="idGrupo" InsertVisible="False" 
                    SortExpression="idGrupo" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" >
                <HeaderStyle HorizontalAlign="Left" CssClass="linkNoUnderline"  />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Observaciones" HeaderText="Descripción" 
                    SortExpression="Observaciones" >
                <HeaderStyle HorizontalAlign="Left" CssClass="linkNoUnderline"  />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:LinqDataSource ID="linqGrupos" runat="server" ContextTypeName="Datos.DC" 
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Grupos">
        </asp:LinqDataSource>
        </td>
    </tr>
    <tr><td align="right" colspan="2"><asp:LinkButton ID="lnkNuevoPerfil" Text="Nuevo Perfil" 
            runat="server" onclick="lnkNuevoPerfil_Click"></asp:LinkButton> </td></tr>
    <tr>
    <td colspan="2">
        <asp:DetailsView ID="dtvPerfil" DataKeyNames="idGrupo" runat="server" Height="50px" Width="100%" 
            AutoGenerateRows="False" BackColor="White" BorderColor="#E7E7FF" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="linqPerfil" 
            GridLines="Horizontal" onitemcreated="dtvPerfil_ItemCreated" 
            onitemdeleted="dtvPerfil_ItemDeleted" oniteminserted="dtvPerfil_ItemInserted" 
            onitemupdated="dtvPerfil_ItemUpdated">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <Fields>
                <asp:CommandField  EditText="Editar" CancelText="Cancelar" InsertText="Insertar" DeleteText="Eliminar" SelectText="Seleccionar" UpdateText="Actualizar"  CancelImageUrl="~/Imagenes/cancel.gif" 
                    DeleteImageUrl="~/Imagenes/delete.gif" EditImageUrl="~/Imagenes/edit.gif" 
                    HeaderText="Acciones" InsertImageUrl="~/Imagenes/insert.gif" 
                    NewImageUrl="~/Imagenes/New.gif" ShowDeleteButton="True" ShowEditButton="True" 
                    ShowInsertButton="True" UpdateImageUrl="~/Imagenes/update.gif" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                    SortExpression="Observaciones" />
            </Fields>
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:DetailsView>    
        <asp:LinqDataSource ID="linqPerfil" runat="server" ContextTypeName="Datos.DC" 
            EnableDelete="True" EnableInsert="True" EnableUpdate="True" TableName="Grupos" 
            Where="idGrupo == @idGrupo">
            <WhereParameters>
                <asp:ControlParameter ControlID="grdGrupos" Name="idGrupo" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
            </WhereParameters>
        </asp:LinqDataSource>
    </td>
    </tr>
    <tr>
        <td align="left"><asp:Label ID="lblMensajePuertas" runat="server" ForeColor="#CC0000"></asp:Label></td>
        <td align="right">
            <asp:LinkButton runat="server" ID="btnEnviar" onclick="btnEnviar_Click" Text="Guardar Permisos" Visible="False" />
        </td>
    </tr>
    <asp:Literal ID="ltlTableHeader" runat="server" Visible="false" Text='<tr><th colspan="2" align="left">Puertas Asignadas</th></tr>' />
    <tr>
    <td colspan="2">
        <asp:GridView ID="grdPuertas" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="idPuerta" DataSourceID="sqlPuertas" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal" Width="100%" Visible="False">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="idPuerta" HeaderText="idPuerta" 
                    InsertVisible="False" ReadOnly="True" SortExpression="idPuerta" >
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" 
                    SortExpression="Descripcion" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Permitido">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkPuerta" runat="server"  checked='<%# Eval("Permitido")%>' 
                            ToolTip='<%# Eval("idPuerta")%>'  />
                    </ItemTemplate>
                    <HeaderTemplate>
                        Seleccionar Todos
                        <input type="checkbox" name="chkSeleccionarTodas" 
                        onclick="CheckAllDataGridCheckBoxes('chkPuerta',document.forms[0].chkSeleccionarTodas.checked)" />
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:SqlDataSource ID="sqlPuertas" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Moebius %>" 
            SelectCommand="
            SELECT p.[idPuerta], REPLICATE('.',(p.Nivel-1)*3)+p.[Descripcion] Descripcion,CAST(isnull(a.idAcceso,0) AS BIT) Permitido 
            FROM [Puertas] p 
            LEFT JOIN dbo.Accesos a ON p.idPuerta = a.idPuerta AND a.idGrupo=@idPerfil
            ORDER BY [Secuencia]">
            <SelectParameters>
                    <asp:ControlParameter ControlID="grdGrupos" Name="idPerfil" PropertyName="SelectedValue" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:SqlDataSource>   
    </td>
    </tr>
    </table>
</asp:Content>