<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP1.aspx.vb" Inherits="Centur.CrearServicioP1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
        $(function () {
            $("#tabs").tabs();
            $("#tabs").tabs('option', 'disabled', [1, 2, 3]);
            $ID("btnSiguiente").button();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="tabs">
	<ul>
		<li><a href="#elige-la-categoria">Elige la categoría</a></li>
		<li><a href="#describe-el-servicio">Describe el servicio</a></li>
		<li><a href="#define-los-tiempos">Define tiempos</a></li>
        <li><a href="#configuralo">Configuralo</a></li>
	</ul>
	<div id="elige-la-categoria">
        <br />
        <asp:LinkButton ID="lnkCategoriaPadre" runat="server"></asp:LinkButton>
        <br /><br />
        <asp:ListBox ID="lstCategoria" runat="server" AutoPostBack="True" style="background: white;width: 268px;padding: 5px;font-size: 16px;line-height: 1;border: 0;border-radius: 0;height: 200px;"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnSiguiente" runat="server" Text="Continuar" Enabled="False" />
    </div>
	<div id="describe-el-servicio"></div>
	<div id="define-los-tiempos"></div>
    <div id="configuralo"></div>
</div>
</asp:Content>
