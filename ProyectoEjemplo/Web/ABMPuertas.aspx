<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ABMPuertas.aspx.cs" Inherits="Web.ABMPuertas" MasterPageFile="~/moebiusWeb.Master" %>

<asp:Content ContentPlaceHolderID="cphPrincipal" ID="ABMGruposPH" runat="server">
<form id="form1" runat="server">
    <table>
        <tr>
            <td>Perfil:</td>
            <td>
                <asp:TextBox ID="txtPerfil" runat="server"></asp:TextBox>
                <asp:HiddenField ID="intPerfil" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Descripción:</td>
            <td><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox></td>
        </tr>        
        <tr>
            <td valign="top">Perfiles:</td>
            <td>
                <asp:GridView ID="grdPuertas" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="idPuerta" DataSourceID="sqlPuertas" BackColor="White" 
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    GridLines="Horizontal">
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="idPuerta" HeaderText="idPuerta" 
                            InsertVisible="False" ReadOnly="True" SortExpression="idPuerta" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                            SortExpression="Descripcion" />
                        <asp:TemplateField HeaderText="Permitido">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkPuerta" runat="server"  checked='<%# Eval("Permitido")%>' ToolTip='<%# Eval("idPuerta")%>' />
                            </ItemTemplate>
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
                        <asp:ControlParameter ControlID="intPerfil" Name="idPerfil" PropertyName="Value" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button runat="server" ID="btnEnviar" 
                    onclick="btnEnviar_Click" Text="Almacenar Permisos" /></td>
        </tr>    
    </table>
</form>
</asp:Content>
