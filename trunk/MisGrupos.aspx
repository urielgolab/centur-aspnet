<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="MisGrupos.aspx.vb" Inherits="MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Grupos</h1>
    <p><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="none">Seleccione grupo...</asp:ListItem>
            <asp:ListItem Value="Edificio">Edificio</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:LinkButton ID="CrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
         <asp:LinkButton ID="ModificarGrupo" runat="server" PostBackUrl="VerGrupo.aspx">Modificar grupo</asp:LinkButton>
          <asp:LinkButton ID="EliminarGrupo" runat="server">Eliminar grupo</asp:LinkButton>
    </p>

</asp:Content>

