<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisGrupos.aspx.vb" Inherits="Centur.MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $ID("ButtonVerDetalle").button();
            $ID("ButtonCrearGrupo").button();
            $ID("ButtonSolPendientes").button();
            $ID("ButtonVerDetalleAd").button();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal" > Mis grupos</p>
<div id="propios" Runat="Server">
<p class="busqueda">Grupos Propios</p>
    <div><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposPropios" cssclass="GruposCombo" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee grupos</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonVerDetalle" cssclass="ButtonDerecho" runat="server" Text="Ver Detalle..."></asp:Button>
        <br />
    </div>
    
        <div class="DivGruposLinks">
        <asp:Button ID="ButtonCrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx" Text="Crear grupo"></asp:Button>
        <asp:Button ID="ButtonSolPendientes" CssClass="ButtonDerecho" runat="server" Text="Solicitudes pendientes"></asp:Button>
        </div>
    </div>

<br />
<div id="adheridos" class="GruposAdheridos">
<p class="busqueda">Grupos Adheridos</p>
    <div><asp:Label ID="Label2" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposAdheridos" cssclass="GruposCombo" runat="server">
            <asp:ListItem Value="none">No tiene grupos adheridos</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonVerDetalleAd" CssClass="ButtonDerecho" runat="server" Text="Ver Detalle..."></asp:Button>
    </div>

</div>


</asp:Content>

