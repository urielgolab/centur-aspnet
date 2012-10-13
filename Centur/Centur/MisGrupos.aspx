<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisGrupos.aspx.vb" Inherits="Centur.MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Grupos</h1>
<div id="propios">
<h2>Grupos Propios</h2>
    <div><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="none">Seleccione grupo...</asp:ListItem>
            <asp:ListItem Value="Edificio">Edificio</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:LinkButton ID="CrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
         <asp:LinkButton ID="ModificarGrupo" runat="server" PostBackUrl="DetalleGrupo.aspx">Modificar grupo</asp:LinkButton>
          <asp:LinkButton ID="EliminarGrupo" runat="server">Eliminar grupo</asp:LinkButton>
    </div>
</div>

<div id="adheridos">
<h2>Grupos adheridos</h2>
    <div><asp:Label ID="Label2" runat="server" Text="Seleccionar grupo"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="none">Seleccione grupo...</asp:ListItem>
            <asp:ListItem Value="Edificio">Edificio</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="DetalleGrupo.aspx">Modificar grupo</asp:LinkButton>
          <asp:LinkButton ID="LinkButton3" runat="server">Eliminar grupo</asp:LinkButton>
    </div>
</div>


</asp:Content>

