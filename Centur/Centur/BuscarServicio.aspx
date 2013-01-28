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
        
        .txtBusqueda {
            border: 1px solid black;
            width: 500px !important;
            height: 35px;
            font-size: 1.5em;
        }
        
        #filtrosBasicos
        {
            margin: 15px;
        }
        
        #filtrosAdicionales
        {
            padding: 10px;
            display:none;
        }    
        #hideFilters
        {
            background-image: url('Images/iconosVarios.png');
            width: 16px;
            height: 16px;
            display: inline-block;
            cursor:pointer;
            margin-left:4px;
            background-position:89px 81px;
        }    
        .resetFilters
        {
            background-image: url('Images/iconosVarios.png');
            width: 16px;
            height: 16px;
            margin-left:4px;
            background-position:62px -81px;
            display: inline-block;            
        }
    </style>
    <script src="Scripts/external/globalize.js"></script>
    <script src="Scripts/external/jquery.mousewheel.js"></script>

    <script type="text/javascript">
        $(function () {
            $ID("buscar").button();
            $('[id^="MainContent_precio"]').spinner({ max: 9999, min: 0 }); //, numberFormat: "C"
        });

        function toogleFilters() {
            if ($(filtrosAdicionales).css('display') != "none") {
                $(hideFilters).css('background-position', '89px 81px');
                $(filtrosAdicionales).css('display', 'none');
            }
            else {
                $(hideFilters).css('background-position', '224px 402px');
                $(filtrosAdicionales).css('display', 'block');
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1 align="left" class="tituloPrincipal" > Busqueda de Servicios</h1>
    <div id="filtrosBasicos"> 
        <p style="float: left;position: relative;">
            <label class="filtrosBusqueda">Nombre</label>
            <asp:TextBox ID="nombre"  runat="server" CssClass="txtBusqueda" />
        </p> 
    </div>
    <div style="float:left;margin-left: 10px;margin-top: 3px;">
        <asp:Button ID="buscar" Text="Buscar" runat="server" />
        <asp:LinkButton ID="reset" Text="" runat="server" CssClass="resetFilters" title="Borrar filtros" />
    </div>
    <div style="clear: both;"></div>
    <h2 style="float:left;">Filtros adicionales<div id="hideFilters" onclick="toogleFilters()"></div></h2>
    <div style="clear: both;"></div>
    <div id="filtrosAdicionales"> 
        <label class="filtrosBusqueda">Categorias</label>
        <asp:TreeView CssClass="arbol" ID="ArbolCategorias" runat="server"  
            ShowCheckBoxes="All" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" /> 
            </asp:TreeView>
        
        <label class="filtrosBusqueda">Zonas</label>
        <asp:TreeView CssClass="arbol" ID="ArbolZonas" runat="server" 
            ShowCheckBoxes="All" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
                HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <div style="float:left;">
            <label class="filtrosBusqueda"> Precio desde </label>
            <div style="float:left;">
                <asp:TextBox runat="server" ID="precioDesde" />
            </div>
            <label class="filtrosBusqueda"> hasta </label> 
            <div style="float:left;">
                <asp:TextBox runat="server" ID="precioHasta" />
            </div>
        </div>
        <div style="clear:both;"></div>
    </div>    
    <div id="resultados" runat="server">
        <p class="busqueda">Resultados</p>
        <asp:GridView runat="server" ID="gridResultados" 
            AutoGenerateColumns="False" CssClass="tbHorariosDia" style="border:0;width:650px;margin-left: auto;margin-right: auto;">
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
                <asp:TemplateField ShowHeader="false" ItemStyle-HorizontalAlign="Center"> 
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl =<%# String.Format("~/Images/publicaciones/thumb_{0}",Eval("Imagen"))%>  Visible='<%# (Not Eval("Imagen")="") %>' style="max-width:100px" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
