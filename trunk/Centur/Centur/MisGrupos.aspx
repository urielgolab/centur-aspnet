﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisGrupos.aspx.vb" Inherits="Centur.MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Grupos</h1>
<div id="propios" Runat="Server">
<h2>Grupos Propios</h2>
    <div><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo"></asp:Label>
        <asp:DropDownList ID="DropDownListGruposPropios" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee grupos</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton4" runat="server">Ver Detalle...</asp:LinkButton>
        <br />
    </div>
    <div>
        <asp:LinkButton ID="CrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
         <asp:LinkButton ID="LinkButton6" runat="server">Solicitudes pendientes</asp:LinkButton>
    </div>
</div>

<div id="adheridos">
<h2>Grupos adheridos</h2>
    <div><asp:Label ID="Label2" runat="server" Text="Seleccionar grupo"></asp:Label>
        <asp:DropDownList ID="DropDownListGruposAdheridos" runat="server">
            <asp:ListItem Value="none">No tiene grupos adheridos</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton5" runat="server">Ver Detalle...</asp:LinkButton>
    </div>
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
         <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="DetalleGrupo.aspx">Modificar grupo</asp:LinkButton>
          <asp:LinkButton ID="LinkButton3" runat="server">Eliminar grupo</asp:LinkButton>
    </div>
</div>


</asp:Content>

