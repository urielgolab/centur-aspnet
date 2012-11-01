<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="BuscarServicio.aspx.vb" Inherits="Centur.BuscarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div> Categorias
        <asp:TreeView ID="ArbolCategorias" runat="server" ShowCheckBoxes="All"> </asp:TreeView>
        </div>
        <div> Zonas
        <asp:TreeView ID="ArbolZonas" runat="server" ShowCheckBoxes="All"> </asp:TreeView>
        </div>
  
    
    <div>
        <label id="Label"> Nombre </label>
        <asp:TextBox runat="server" ID="nombre" />
        <br />
        <label id="Label1"> Precio desde </label>
        <asp:TextBox runat="server" ID="TextBox1" />
        <label id="Label2"> hasta </label> 
        <asp:TextBox runat="server" ID="TextBox2" />
    </div>
    
    <div>
        <asp:LinkButton ID="buscar" Text="Buscar" runat="server" />
        <asp:LinkButton ID="reset" Text="Nueva Búsqueda" runat="server" />

    <div id="resultados" runat="server">
        Resultados:
        <asp:GridView runat="server" ID="gridResultados" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField DataField="Zona" HeaderText="Zona" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
