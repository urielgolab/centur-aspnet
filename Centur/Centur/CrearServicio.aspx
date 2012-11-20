<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicio.aspx.vb" Inherits="Centur.CrearServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">   
    <script>
    $(function() {
        $("#tabs").tabs();
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <p>
        <br />
    </p>

    <div id="tabs">
	<ul>
		<li><a href="#tabs-1">Elige la categoría</a></li>
		<li><a href="#tabs-2">Describe el servicio</a></li>
		<li><a href="#tabs-3">Define tiempos</a></li>
        <li><a href="#tabs-4">Configuralo</a></li>
	</ul>
	<div id="tabs-1">
        <asp:Label ID="lblCategorias" runat="server" Text="Label"></asp:Label>
        <asp:HiddenField ID="hidCategoriaPadre" runat="server" Value="0" />
        <asp:ListBox ID="lstCategoria" runat="server" DataSourceID="linqCategorias" 
            DataTextField="idCategoria" DataValueField="descripcion"></asp:ListBox>
        <asp:LinqDataSource ID="linqCategorias" runat="server" 
            ContextTypeName="Datos.DC" EntityTypeName="" TableName="Categorias" 
            Where="raiz == @raiz">
            <WhereParameters>
                <asp:ControlParameter ControlID="hidCategoriaPadre" DefaultValue="0" 
                    Name="raiz" PropertyName="Value" Type="Boolean" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>
	<div id="tabs-2">Phasellus mattis tincidunt nibh. Cras orci urna, blandit id, pretium vel, aliquet ornare, felis. Maecenas scelerisque sem non nisl. Fusce sed lorem in enim dictum bibendum.</div>
	<div id="tabs-3">Nam dui erat, auctor a, dignissim quis, sollicitudin eu, felis. Pellentesque nisi urna, interdum eget, sagittis et, consequat vestibulum, lacus. Mauris porttitor ullamcorper augue.</div>
    <div id="tabs-4">Nam dui erat, auctor a, dignissim quis, sollicitudin eu, felis. Pellentesque nisi urna, interdum eget, sagittis et, consequat vestibulum, lacus. Mauris porttitor ullamcorper augue.</div>
</div>
</asp:Content>
