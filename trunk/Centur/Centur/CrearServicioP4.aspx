<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP4.aspx.vb" Inherits="Centur.CrearServicioP4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
        $(function () {
            $("#tabs").tabs();
            $("#tabs").tabs('option', 'disabled', [1, 2, 0]);
            $("#tabs").tabs("select", 3)
            $ID("btnFinalizar").button();
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
	<div id="elige-la-categoria"></div>
	<div id="describe-el-servicio"></div>
	<div id="define-los-tiempos"></div>
    <div id="configuralo">
        
        <br />
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" />
    </div>
</div>
</asp:Content>
