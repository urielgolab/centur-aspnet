<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="BuscarServicio.aspx.vb" Inherits="Centur.BuscarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
   <label id="Label"> Nombre </label>
<asp:TextBox runat="server" ID="nombre" />
</div>
    <div>
    <label id="Label1"> Categoria </label>
<asp:TextBox runat="server" ID="categoria" />
</div>
    <div>
    <label id="Label2"> Zona </label>
<asp:TextBox runat="server" ID="zona" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="idServicio" DataSourceID="LinqDataSource1" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="idServicio" HeaderText="idServicio" ReadOnly="True" 
                    SortExpression="idServicio" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" 
                    SortExpression="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                    SortExpression="Descripcion" />
                <asp:BoundField DataField="idCategoria" HeaderText="idCategoria" 
                    SortExpression="idCategoria" />
                <asp:BoundField DataField="idZona" HeaderText="idZona" 
                    SortExpression="idZona" />
                <asp:BoundField DataField="idProveedor" HeaderText="idProveedor" 
                    SortExpression="idProveedor" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" 
                    SortExpression="Observaciones" />
                <asp:BoundField DataField="Grillas" HeaderText="Grillas" 
                    SortExpression="Grillas" />
                <asp:BoundField DataField="Reglas" HeaderText="Reglas" 
                    SortExpression="Reglas" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="Datos.DC" EnableDelete="True" EnableInsert="True" 
            EnableUpdate="True" EntityTypeName="" TableName="Servicios">
        </asp:LinqDataSource>
        <br />
</div>
<div>
<asp:Button ID="buscar" Text="Buscar" runat="server" onclick="Buscar_Click"  />
</div>
    <div id="resultados"> Resultados:
    <asp:GridView runat="server" ID="gridResultados" AutoGenerateColumns="true" >
    </asp:GridView >
    
    </div>

</asp:Content>
