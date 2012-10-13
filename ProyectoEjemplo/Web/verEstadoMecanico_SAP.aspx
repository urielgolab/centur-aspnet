<%@ Page Language="C#" MasterPageFile="~/moebiusWeb.Master" AutoEventWireup="true" CodeBehind="verEstadoMecanico_SAP.aspx.cs" Inherits="Web.verEstadoMecanico_SAP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="EstadoMecanicoSAP" 
        GridLines="Horizontal" DataKeyNames="idEstado">
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <Columns>
            <asp:BoundField DataField="idEstado" HeaderText="idEstado" ReadOnly="True" 
                SortExpression="idEstado" />
            <asp:BoundField DataField="Entidad" HeaderText="Entidad" 
                SortExpression="Entidad" />
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" 
                SortExpression="Codigo" />
            <asp:BoundField DataField="CodigoAbreviado" HeaderText="CodigoAbreviado" 
                SortExpression="CodigoAbreviado" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                SortExpression="Nombre" />
            <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                SortExpression="Observaciones" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <AlternatingRowStyle BackColor="#F7F7F7" />
    </asp:GridView>
    <asp:LinqDataSource ID="EstadoMecanicoSAP" runat="server" 
        ContextTypeName="Datos.DC" onselecting="EstadoMecanicoSAP_Selecting" 
        TableName="Estados" Where="Entidad == @Entidad1">
        <WhereParameters>
            <asp:Parameter DefaultValue="EquiposMecanicaSAP" Name="Entidad1" 
                Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
    </form>
</asp:Content>