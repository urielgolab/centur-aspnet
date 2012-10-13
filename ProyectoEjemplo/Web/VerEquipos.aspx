<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerEquipos.aspx.cs" Inherits="Web.VerEquipos" MasterPageFile="~/moebiusWeb.Master" %>
<asp:Content ContentPlaceHolderID="cphPrincipal" ID="VerEventosPH" runat="server">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" DataSourceID="sqlEquipos" GridLines="Horizontal" 
            AllowSorting="True">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="idEquipo" HeaderText="idEquipo" ReadOnly="True" 
                    SortExpression="idEquipo" Visible="False" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="idFisico" HeaderText="idFisico" ReadOnly="True" 
                    SortExpression="idFisico" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="idGPS" HeaderText="idGPS" ReadOnly="True" 
                    SortExpression="idGPS" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="idSAP" HeaderText="idSAP" ReadOnly="True" 
                    SortExpression="idSAP" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                    ReadOnly="True" SortExpression="Descripcion" />
                <asp:TemplateField HeaderText="TipoEquipo" SortExpression="idTipoEquipo">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" 
                            Text='<%# Bind("Tipos_Equipos.Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UsoEquipo" SortExpression="idUsoEquipo">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" 
                            Text='<%# Bind("Tipos_Uso_Equipos.Descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DescripcionAbreviada" HeaderText="DescripcionAbreviada" 
                    ReadOnly="True" SortExpression="DescripcionAbreviada" />
                <asp:BoundField DataField="Potencia" HeaderText="Potencia" ReadOnly="True" 
                    SortExpression="Potencia" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Peso" HeaderText="Peso" ReadOnly="True" 
                    SortExpression="Peso" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Largo" HeaderText="Largo" ReadOnly="True" 
                    SortExpression="Largo" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Propietario" HeaderText="Propietario" 
                    ReadOnly="True" SortExpression="Propietario" />
                <asp:BoundField DataField="Responsable" HeaderText="Responsable" 
                    ReadOnly="True" SortExpression="Responsable" />
                <asp:BoundField DataField="ResponsableFinal" HeaderText="ResponsableFinal" 
                    ReadOnly="True" SortExpression="ResponsableFinal" />
                <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" ReadOnly="True" 
                    SortExpression="Ubicacion" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                    ReadOnly="True" SortExpression="Observaciones" />
                <asp:BoundField DataField="Progresiva" HeaderText="Progresiva" ReadOnly="True" 
                    SortExpression="Progresiva" >
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Tren" HeaderText="Tren" ReadOnly="True" 
                    SortExpression="Tren" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    
    </div>
    <asp:LinqDataSource ID="sqlEquipos" runat="server" 
        ContextTypeName="Datos.DC" TableName="Equipos">
    </asp:LinqDataSource>
    </form>
</asp:Content>