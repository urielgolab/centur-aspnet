<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP3.aspx.vb" Inherits="Centur.CrearServicioP3" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script src="Scripts/external/globalize.js"></script>
    <script src="Scripts/external/globalize.culture.de-DE.js"></script>
    <script src="Scripts/addressPicker.js"></script>

    <script language="javascript">
        $.widget("ui.timespinner", $.ui.spinner, {
            options: {
                // seconds
                step: 60 * 1000,
                // hours
                page: 60
            },

            _parse: function (value) {
                if (typeof value === "string") {
                    // already a timestamp
                    if (Number(value) == value) {
                        return Number(value);
                    }
                    return +Globalize.parseDate(value);
                }
                return value;
            },

            _format: function (value) {
                return Globalize.format(new Date(value), "t");
            }
        });
        
        $(function () {
            $("#tabs").tabs();
            $("#tabs").tabs('option', 'disabled', [0, 1, 3]);
            $("#tabs").tabs("select", 2)
            $ID("btnSiguiente").button();

            //$ID("txtFechaDesde").datepicker();
            //$ID("txtFechaHasta").datepicker();
            $('[id^="MainContent_txtCapacidad"]').spinner();
            $('[id^="MainContent_txtDuracion"]').spinner();
            $('[id^="MainContent_txtHora"]').timespinner();
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
	<div id="define-los-tiempos">
        <div id="configuracionDias">
            <table border="1px">
                <thead>
                    <tr>
                      <th>D&iacute;as</th>
<%--                      <th align="left">
                        <div>
                        <asp:Label ID="lblOtrasGrillas" runat="server" Text="Otras grillas:&nbsp;"></asp:Label>
                        <asp:DropDownList ID="dpOtrasGrillas" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:Label ID="lblOtrasGrillas2" runat="server" Text="<br />"></asp:Label>                        
                        Desde:<asp:TextBox ID="txtFechaDesde" runat="server" Width="75px"></asp:TextBox>
                        &nbsp;&nbsp;
                        Hasta:<asp:TextBox ID="txtFechaHasta" runat="server" Width="75px"></asp:TextBox>
                        </div>
                      </th>--%>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><asp:CheckBox ID="chkLunes" runat="server" AutoPostBack="true" />&nbsp;&nbsp;Lunes</td>
                        <td>
                            <asp:Table ID="tbLunes" runat="server" Visible="false">

                            </asp:Table>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkMartes" runat="server" />&nbsp;&nbsp;Martes</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkMiercoles" runat="server" />&nbsp;&nbsp;Mi&eacute;rcoles</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkJueves" runat="server" />&nbsp;&nbsp;Jueves</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkViernes" runat="server" />&nbsp;&nbsp;Viernes</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkSabado" runat="server" />&nbsp;&nbsp;S&aacute;bado</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox ID="chkDomingo" runat="server" />&nbsp;&nbsp;Domingo</td>
                        <td></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <asp:Button ID="btnSiguiente" runat="server" Text="Continuar"  />
    </div>
    <div id="configuralo"></div>
</div>
</asp:Content>
