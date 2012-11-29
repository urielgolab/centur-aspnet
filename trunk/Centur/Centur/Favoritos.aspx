<%@ Page Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="Favoritos.aspx.vb" Inherits="Centur.Favoritos" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<h1>
    &nbsp;</h1>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetFavoritos" TypeName="Services.FavoritosService">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="idUsuario" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" 
                SortExpression="Categoria" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" SortExpression="Zona" />
        </Columns>
    </asp:GridView>
    </asp:Content>

