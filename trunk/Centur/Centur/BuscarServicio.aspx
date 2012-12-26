<%@ Page Title="Buscar Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="BuscarServicio.aspx.vb" Inherits="Centur.BuscarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
    
    <div class="filtrosBusqueda links">
        <asp:LinkButton ID="buscar" Text="Buscar" runat="server" />
        <asp:LinkButton ID="reset" Text="Nueva Búsqueda" runat="server" />
</div>

    <div class="filtrosBusqueda" id="resultados" runat="server">
        <p class="busqueda">Resultados</p>
        <asp:GridView CssClass="grillaResultados" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" ID="gridResultados" AutoGenerateColumns="False" >
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"   />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoria" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="Zona" HeaderText="Zona"  HeaderStyle-HorizontalAlign="Left"  />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
