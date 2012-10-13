<%@ Page Language="C#" MasterPageFile="~/moebiusWeb.Master" AutoEventWireup="true" CodeBehind="VerActividadesViaPrincipal .aspx.cs" Inherits="Web.VerActividadesViaPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="idActividad" DataSourceID="ActividadesViaPrincipal" 
        GridLines="Horizontal">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="idActividad" HeaderText="idActividad" 
                ReadOnly="True" SortExpression="idActividad" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                SortExpression="Descripcion" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" 
                SortExpression="Tipo" />
            <asp:BoundField DataField="Obs" HeaderText="Obs" SortExpression="Obs" />
            <asp:BoundField DataField="idActividadCFLEX" HeaderText="idActividadCFLEX" 
                SortExpression="idActividadCFLEX" />
            <asp:BoundField DataField="FechaAlta" HeaderText="FechaAlta" 
                SortExpression="FechaAlta" />
            <asp:BoundField DataField="UsuarioAlta" HeaderText="UsuarioAlta" 
                SortExpression="UsuarioAlta" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" 
                SortExpression="Estado" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <asp:LinqDataSource ID="ActividadesViaPrincipal" runat="server" 
        ContextTypeName="Datos.DC" TableName="Actividades">
    </asp:LinqDataSource>
    </form>
</asp:Content>

