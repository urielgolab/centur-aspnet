<%@ Page Language="vb" MasterPageFile="~/Site.Master"  AutoEventWireup="false" CodeBehind="Favoritos.aspx.vb" Inherits="Centur.Favoritos" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">

<p align="left" class="tituloPrincipal" > Mis Favoritos</p>

    <asp:GridView ID="GridResultadosFavoritos" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ID" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoria" 
                SortExpression="Categoria" />
            <asp:BoundField DataField="Zona" HeaderText="Zona" SortExpression="Zona" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
        Text="No tiene servicios favoritos" Visible="False"></asp:Label>
    </asp:Content>

