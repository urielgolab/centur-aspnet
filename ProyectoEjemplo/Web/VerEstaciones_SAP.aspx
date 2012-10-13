<%@ Page Title="" Language="C#" MasterPageFile="~/moebiusWeb.Master" AutoEventWireup="true" CodeBehind="VerEstaciones_SAP.aspx.cs" Inherits="Web.VerEstaciones_SAP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="idEstacionSAP" DataSourceID="estacionesSAP" 
        GridLines="Horizontal">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="idEstacionSAP" HeaderText="idEstacionSAP" 
                ReadOnly="True" SortExpression="idEstacionSAP" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" 
                SortExpression="Estado" />
            
            <asp:BoundField DataField="idPatio" HeaderText="idPatio" 
                SortExpression="idPatio" />            
            
            <asp:BoundField DataField="idFerrocarril" HeaderText="idFerrocarril" 
                SortExpression="idFerrocarril" />
                
            
            <asp:TemplateField HeaderText="Ferrocarril">
                <ItemTemplate>
                    <asp:Label ID="lblFerrocarril" runat="server" Text='<%# Eval("Ferrocarriles_SAP.Descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
                
            <asp:BoundField DataField="idZona" HeaderText="Zona" 
                SortExpression="idZona" />            
            
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <asp:LinqDataSource ID="estacionesSAP" runat="server" 
        ContextTypeName="Datos.DC" TableName="Estaciones_SAP">
    </asp:LinqDataSource>
    
    <ItemTemplate>
             <asp:Label ID="lblEstacion" runat="server" Text='<%# Eval("Estaciones.Nombre") %>'></asp:Label>
    </ItemTemplate>
    
    </form>
</asp:Content>
