<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MisTurnos.aspx.vb" Inherits="Centur.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Mis Turnos</h1>
<div id="propios" Runat="Server">
<h2>Turnos otorgados</h2>
<br />
        <asp:Label ID="Label1" runat="server" Text="Seleccionar servicio"></asp:Label>
        
<asp:DropDownList ID="DropDownListServiciosPropios" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee servicios</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton4" runat="server">Ver Turnos...</asp:LinkButton>
        
</div>
<div id="tomados">
<h2>Turnos inscriptos</h2>

</div>
</asp:Content>
