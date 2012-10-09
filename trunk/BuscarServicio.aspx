<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="BuscarServicio.aspx.vb" Inherits="BuscarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
   <label id="nombre"> Nombre </label>
<asp:TextBox runat="server" ID="nombre" />
</div>
    <div>
    <label id="Label1"> Categoria </label>
<asp:TextBox runat="server" ID="categoria" />
</div>
    <div>
    <label id="Label2"> Zona </label>
<asp:TextBox runat="server" ID="zona" />
</div>
<div>
<asp:Button ID="buscar" Text="Buscar" runat="server" onclick="Buscar_Click"  />
</div>
    <div id="resultados"> Resultados:
    <asp:GridView runat="server" ID="gridResultados" AutoGenerateColumns="false" >
        <Columns>
            <asp:HyperLinkField HeaderText="Nombre" DataTextField="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}" DataNavigateUrlFields="ID" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion"  />
        </Columns>
    </asp:GridView >
    
    </div>

</asp:Content>
