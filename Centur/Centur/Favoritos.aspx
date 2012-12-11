<%@ Page Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="Favoritos.aspx.vb" Inherits="Centur.Favoritos" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
<h1>
    &nbsp;</h1>
    <asp:GridView ID="GridResultadosFavoritos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" 
                SortExpression="Categoria" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" SortExpression="Zona" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="No tiene servicios favoritos" Visible="False"></asp:Label>
    </asp:Content>

