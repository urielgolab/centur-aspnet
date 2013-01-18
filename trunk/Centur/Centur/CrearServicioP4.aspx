<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP4.aspx.vb" Inherits="Centur.CrearServicioP4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        *
        {
            border:0;
            margin:0;
            padding:0;    
        }    
    </style>
    <script language="javascript">
        $(function () {
            $("#tabs").tabs();
            $("#tabs").tabs('option', 'disabled', [1, 2, 0]);
            $("#tabs").tabs("select", 3)

            $('[id^="MainContent_txtDias"]').spinner({ max: 99, min: 0 });
            $ID("btnFinalizar").button();



            $(function () {
                $(document).tooltip({
                    position: {
                        my: "center bottom-20",
                        at: "center top",
                        using: function (position, feedback) {
                            $(this).css(position);
                            $("<div>")
            .addClass("arrow")
            .addClass(feedback.vertical)
            .addClass(feedback.horizontal)
            .appendTo(this);
                        }
                    }
                });
            });
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
            <table id="one-column-emphasis">
                <colgroup>
    	            <col class="oce-first">
                </colgroup>
                <thead>
                    <tr>
                      <th style="width:150px">Reglas personalizadas</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td title="Indica la anticipaci&oacute;n m&aacute;xima y m&iacute;nima requerida para reservar turnos">Configuraci&oacute;n general</td>
                        <td>
                            D&iacute;as antes:<asp:TextBox ID="txtDiasAntes" runat="server" MaxLength="2" Text="0" Width="30"></asp:TextBox>
                            &nbsp;&nbsp;
                            D&iacute;as desp&uacute;es:<asp:TextBox ID="txtDiasDespues" runat="server" MaxLength="2" Text="30" Width="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td title="Elige esta opci&oacute;n si deseas que s&oacute;lo un grupo de personas pueda realizar reservas"><asp:CheckBox ID="chkPrivado" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Privacidad</td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdPrivacidadGrupos" runat="server" Visible="False" 
                                            AutoGenerateColumns="False" DataKeyNames="idGrupo" 
                                            CssClass="tbHorariosDia" BorderWidth="0px">
                                            <Columns>
                                                <asp:BoundField DataField="idGrupo" 
                                                    HeaderText="idGrupo" InsertVisible="False" ReadOnly="True" 
                                                    SortExpression="idGrupo" Visible="False" />
                                                <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                                                <asp:TemplateField HeaderText="Acciones">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEliminar1" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="idGrupo" Visible="False" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Table ID="tbServicioGrupo" runat="server" Visible="False" Width="350px">
	                                        <asp:TableRow>
                                                <asp:TableCell>
			                                        Agregar grupo:
                                                    <asp:DropDownList ID="dpServicioGrupo" runat="server" DataTextField="nombre" DataValueField="IdGrupo" AppendDataBoundItems="true">
                                                        <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;<asp:Button ID="btAgregarGrupo" runat="server" Text="Agregar" />
		                                        </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                                    <td align="right" colspan="2">
                                        
                                        <asp:LinkButton ID="lnkAgregarOtroGrupo" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><%--<asp:Table ID="tb1" runat="server" Visible="False" Width="650px">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        Desde:
                                        <asp:TextBox ID="txtHoraDesde1" runat="server" Width="50" MaxLength="5" Text="09:00" />
                                    </asp:TableCell><asp:TableCell>
                                        Hasta:
                                        <asp:TextBox ID="txtHoraHasta1" runat="server" Width="50" MaxLength="5" Text="20:00"/>
                                    </asp:TableCell><asp:TableCell>
                                        Capacidad:
                                        <asp:TextBox ID="txtCapacidad1" runat="server" Width="15" MaxLength="2" Text="1" />
                                    </asp:TableCell><asp:TableCell>
                                        Duraci&oacute;n (min):
                                        <asp:TextBox ID="txtDuracion1" runat="server"  Width="35" MaxLength="3"  Text="30"/>
                                    </asp:TableCell></asp:TableRow>
                            </asp:Table>--%></td></tr><tr>
                        <td title="Elige esta opci&oacute;n si deseas aprobar los turnos para confirmarlos"><asp:CheckBox ID="chkConfirmarTurno" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Confirmar turno</td><td>
                            &nbsp; </td></tr><tr>
                        <td title="Elige esta opci&oacute;n si deseas que recordemos el turno al usuario"><asp:CheckBox ID="chkEnviarRecordatorio" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Enviar recordatorio</td><td>
                            &nbsp; </td></tr><tr>
                        <td title="Elige esta opci&oacute;n si admites solicitudes de sobreturnos"><asp:CheckBox ID="chkSobreturno" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Sobreturnos</td><td>
                            &nbsp; </td></tr><tr>
                        <td title="Elige esta opci&oacute;n si deseas cobrar por adelantado la reserva del turno.<br /> Requiere cuenta de MercadoPago"><asp:CheckBox ID="chkMercadoPago" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Cobrar turno</td><td>
                            &nbsp; </td></tr></tbody></table><br />
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" />
    </div>
</div>
</asp:Content>
