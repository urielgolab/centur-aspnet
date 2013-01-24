<%@ Page Title="Buscar Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="BuscarServicio.aspx.vb" Inherits="Centur.BuscarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        *
        {
            border:0;
            margin:0;
            padding:0;    
        }    
    </style>
    <script src="Scripts/external/globalize.js"></script>
    <script src="Scripts/external/jquery.mousewheel.js"></script>

    <script>
        $(function () {
            $ID("buscar").button();
            $('[id^="MainContent_precio"]').spinner({ max: 9999, min: 0 }); //, numberFormat: "C"
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <p align="left" class="tituloPrincipal" > Busqueda de Servicios</p>
    <div class="arboles"> 
        <p class="busqueda">Categorias</p>
        <asp:TreeView CssClass="arbol" ID="ArbolCategorias" runat="server"  
            ShowCheckBoxes="All" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" /> 
            </asp:TreeView>
        
        <p class="busqueda">Zonas</p>
        <asp:TreeView CssClass="arbol" ID="ArbolZonas" runat="server" 
            ShowCheckBoxes="All" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        
  
    </div>
    <div class="filtrosBusqueda"> 
    <p class="busqueda">Filtros</p>
    <p class="busqueda">
        <label class="filtrosBusqueda" > Nombre </label>
        <asp:TextBox ID="nombre" CssClass="TextBoxFiltrosBusqueda"  runat="server"   />
       </p> 
       <p>
        <label class="filtrosBusqueda"> Precio desde </label>
        <asp:TextBox CssClass="TextBoxFiltrosBusqueda" runat="server" ID="precioDesde" />
        <label class="filtrosBusqueda2"> hasta </label> 
        <asp:TextBox CssClass="TextBoxFiltrosBusqueda" runat="server" ID="precioHasta" />
        </p>
    </div>
    
    <div class="filtrosBusqueda">
        <asp:Button ID="buscar" Text="Buscar" runat="server" />
        <asp:LinkButton ID="reset" Text="Nueva Búsqueda" runat="server" />
</div>

    <div class="filtrosBusqueda" id="resultados" runat="server">
        <p class="busqueda">Resultados</p>
        <asp:GridView runat="server" ID="gridResultados" 
            AutoGenerateColumns="False" CssClass="tbHorariosDia" style="border:0;">
            <Columns>
                <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:HyperLinkField>
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" 
                    HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Zona" HeaderText="Zona"  
                    HeaderStyle-HorizontalAlign="Left"  >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:BoundField>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl =<%# String.Format("~/Images/publicaciones/thumb_{0}",Eval("Imagen"))%>  Visible='<%# (Not Eval("Imagen")="") %>' style="max-width:100px" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
