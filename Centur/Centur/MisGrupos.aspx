<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisGrupos.aspx.vb" Inherits="Centur.MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal" > Mis grupos</p>
<div id="propios" Runat="Server">
<p class="busqueda">Grupos Propios</p>
    <div><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposPropios" cssclass="GruposCombo" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee grupos</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton4" cssclass="MisGruposLinks" runat="server">Ver Detalle...</asp:LinkButton>
        <br />
    </div>
    
        <div class="DivGruposLinks">
        <asp:LinkButton ID="CrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx">Crear grupo</asp:LinkButton>
        <asp:LinkButton ID="LinkButton6" CssClass="LinkDerecho" runat="server">Solicitudes pendientes</asp:LinkButton>
        </div>
    </div>

<br />
<div id="adheridos" class="GruposAdheridos">
<p class="busqueda">Grupos Adheridos</p>
    <div><asp:Label ID="Label2" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposAdheridos" cssclass="GruposCombo" runat="server">
            <asp:ListItem Value="none">No tiene grupos adheridos</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton5" CssClass="MisGruposLinks" runat="server">Ver Detalle...</asp:LinkButton>
    </div>

</div>


</asp:Content>

