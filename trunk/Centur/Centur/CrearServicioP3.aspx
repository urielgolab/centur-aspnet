<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CrearServicioP3.aspx.vb" Inherits="Centur.CrearServicioP3" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script src="Scripts/external/globalize.js"></script>
    <script src="Scripts/external/globalize.culture.de-DE.js"></script>
    <script src="Scripts/external/jquery.mousewheel.js"></script>
    <script src="Scripts/addressPicker.js"></script>
    <style>
        *
        {
            border:0;
            margin:0;
            padding:0;    
        }    
    </style>
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
            $ID("txtFechaExcep").datepicker(
                { minDate: new Date()
                , dateFormat: 'dd-mm-yy'
                , dayNamesShort: ["Dom", "Lun", "Mar", "Mier", "Jue", "Vie", "Sab"]
                , dayNames: ["Domingo", "Lunes", "Martes", "Mi&eacute;rcoles", "Jueves", "Viernes", "S&aacute;bado"]
                , monthNames: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"]
                });

            //$ID("txtFechaDesde").datepicker();
            //$ID("txtFechaHasta").datepicker();
            $('[id^="MainContent_txtCapacidad"]').spinner({ max: 30, min: 1 });
            $('[id^="MainContent_txtDuracion"]').spinner({ max: 999, min: 10 });
            Globalize.culture("de-DE");
            $('[id^="MainContent_txtHora"]').timespinner();
        });
    </script>
</asp:Content>
<asp:Content ID="contentBody" ContentPlaceHolderID="MainContent" runat="server">

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
            <asp:Label ID="lblMensajeErrror" Text="" Visible="false" runat="server"></asp:Label>

            <table id="one-column-emphasis">
                <colgroup>
    	            <col class="oce-first">
                </colgroup>
                <thead>
                    <tr>
                      <th>D&iacute;as</th>
                      <th style="text-align:left !important;" title="Selecciona esta opci&oacute;n si deseas compartir la agenda con otro serivicio">
                          <asp:DropDownList ID="dpGrillaAsociada" runat="server" 
                              AppendDataBoundItems="true" Visible="false" DataTextField="Nombre" 
                              DataValueField="idGrilla" AutoPostBack="True">
                            <asp:ListItem Text="Servicio asociado" Value="0"></asp:ListItem>
                          </asp:DropDownList>
                          <asp:LinkButton ID="lnkGrillaAsociada" runat="server">Utilizar grilla asociada</asp:LinkButton>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><asp:CheckBox ID="chkDia1" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Domingo</td>
                        <td>
                            <table border="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdHorarios1" runat="server" Visible="False" 
                                            AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
                                            <Columns>
                                                <asp:BoundField DataField="idConfiguracionHoraria" 
                                                    HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
                                                    SortExpression="idConfiguracionHoraria" Visible="False" />
                                                <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
                                                    SortExpression="idConfiguracionDia" Visible="False" />
                                                <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
                                                    SortExpression="horaInicio" DataFormatString="{0:t}" />
                                                <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
                                                    SortExpression="horaFin" DataFormatString="{0:t}" />
                                                <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
                                                    SortExpression="capacidad" />
                                                <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
                                                    SortExpression="duracion" />
                                                <asp:TemplateField HeaderText="Acciones">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEliminar1" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:LinkButton ID="lnkAgregarOtroHorario1" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton>
                                    </td>
                                </tr> 
                            </table> 
                            <asp:Table ID="tb1" runat="server" Visible="False" Width="650px">
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
                                    </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia2" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Lunes</td><td>
                            <table border="0">
	                            <tr>
		                            <td>
			                            <asp:GridView ID="grdHorarios2" runat="server" Visible="False" 
				                            AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				                            <Columns>
					                            <asp:BoundField DataField="idConfiguracionHoraria" 
						                            HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						                            SortExpression="idConfiguracionHoraria" Visible="False" />
					                            <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						                            SortExpression="idConfiguracionDia" Visible="False" />
					                            <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						                            SortExpression="horaInicio" DataFormatString="{0:t}" />
					                            <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						                            SortExpression="horaFin" DataFormatString="{0:t}" />
					                            <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						                            SortExpression="capacidad" />
					                            <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						                            SortExpression="duracion" />
					                            <asp:TemplateField HeaderText="Acciones">
						                            <ItemTemplate>
							                            <asp:LinkButton ID="lnkEliminar2" runat="server" CausesValidation="False" 
								                            CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		                            <td align="right" colspan="2">
			                            <asp:LinkButton ID="lnkAgregarOtroHorario2" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb2" runat="server" Visible="False" Width="650px">
	                            <asp:TableRow>
		                            <asp:TableCell>
			                            Desde:
			                            <asp:TextBox ID="txtHoraDesde2" runat="server" Width="50" MaxLength="5" Text="09:00" />
		                            </asp:TableCell><asp:TableCell>
			                            Hasta:
			                            <asp:TextBox ID="txtHoraHasta2" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		                            </asp:TableCell><asp:TableCell>
			                            Capacidad:
			                            <asp:TextBox ID="txtCapacidad2" runat="server" Width="15" MaxLength="2" Text="1" />
		                            </asp:TableCell><asp:TableCell>
			                            Duraci&oacute;n (min):
			                            <asp:TextBox ID="txtDuracion2" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		                            </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia3" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Martes</td><td>
<table border="0">
	<tr>
		<td>
			<asp:GridView ID="grdHorarios3" runat="server" Visible="False" 
				AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				<Columns>
					<asp:BoundField DataField="idConfiguracionHoraria" 
						HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						SortExpression="idConfiguracionHoraria" Visible="False" />
					<asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						SortExpression="idConfiguracionDia" Visible="False" />
					<asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						SortExpression="horaInicio" DataFormatString="{0:t}" />
					<asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						SortExpression="horaFin" DataFormatString="{0:t}" />
					<asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						SortExpression="capacidad" />
					<asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						SortExpression="duracion" />
					<asp:TemplateField HeaderText="Acciones">
						<ItemTemplate>
							<asp:LinkButton ID="lnkEliminar3" runat="server" CausesValidation="False" 
								CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		<td align="right" colspan="2">
			<asp:LinkButton ID="lnkAgregarOtroHorario3" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb3" runat="server" Visible="False" Width="650px">
	<asp:TableRow>
		<asp:TableCell>
			Desde:
			<asp:TextBox ID="txtHoraDesde3" runat="server" Width="50" MaxLength="5" Text="09:00" />
		</asp:TableCell><asp:TableCell>
			Hasta:
			<asp:TextBox ID="txtHoraHasta3" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		</asp:TableCell><asp:TableCell>
			Capacidad:
			<asp:TextBox ID="txtCapacidad3" runat="server" Width="15" MaxLength="2" Text="1" />
		</asp:TableCell><asp:TableCell>
			Duraci&oacute;n (min):
			<asp:TextBox ID="txtDuracion3" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		</asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia4" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Mi&eacute;rcoles</td><td>
                            <table border="0">
	                            <tr>
		                            <td>
			                            <asp:GridView ID="grdHorarios4" runat="server" Visible="False" 
				                            AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				                            <Columns>
					                            <asp:BoundField DataField="idConfiguracionHoraria" 
						                            HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						                            SortExpression="idConfiguracionHoraria" Visible="False" />
					                            <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						                            SortExpression="idConfiguracionDia" Visible="False" />
					                            <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						                            SortExpression="horaInicio" DataFormatString="{0:t}" />
					                            <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						                            SortExpression="horaFin" DataFormatString="{0:t}" />
					                            <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						                            SortExpression="capacidad" />
					                            <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						                            SortExpression="duracion" />
					                            <asp:TemplateField HeaderText="Acciones">
						                            <ItemTemplate>
							                            <asp:LinkButton ID="lnkEliminar4" runat="server" CausesValidation="False" 
								                            CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		                            <td align="right" colspan="2">
			                            <asp:LinkButton ID="lnkAgregarOtroHorario4" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb4" runat="server" Visible="False" Width="650px">
	                            <asp:TableRow>
		                            <asp:TableCell>
			                            Desde:
			                            <asp:TextBox ID="txtHoraDesde4" runat="server" Width="50" MaxLength="5" Text="09:00" />
		                            </asp:TableCell><asp:TableCell>
			                            Hasta:
			                            <asp:TextBox ID="txtHoraHasta4" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		                            </asp:TableCell><asp:TableCell>
			                            Capacidad:
			                            <asp:TextBox ID="txtCapacidad4" runat="server" Width="15" MaxLength="2" Text="1" />
		                            </asp:TableCell><asp:TableCell>
			                            Duraci&oacute;n (min):
			                            <asp:TextBox ID="txtDuracion4" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		                            </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia5" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Jueves</td><td>
                        <table border="0">
	                        <tr>
		                        <td>
			                        <asp:GridView ID="grdHorarios5" runat="server" Visible="False" 
				                        AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				                        <Columns>
					                        <asp:BoundField DataField="idConfiguracionHoraria" 
						                        HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						                        SortExpression="idConfiguracionHoraria" Visible="False" />
					                        <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						                        SortExpression="idConfiguracionDia" Visible="False" />
					                        <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						                        SortExpression="horaInicio" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						                        SortExpression="horaFin" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						                        SortExpression="capacidad" />
					                        <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						                        SortExpression="duracion" />
					                        <asp:TemplateField HeaderText="Acciones">
						                        <ItemTemplate>
							                        <asp:LinkButton ID="lnkEliminar5" runat="server" CausesValidation="False" 
								                        CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		                        <td align="right" colspan="2">
			                        <asp:LinkButton ID="lnkAgregarOtroHorario5" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb5" runat="server" Visible="False" Width="650px">
	                        <asp:TableRow>
		                        <asp:TableCell>
			                        Desde:
			                        <asp:TextBox ID="txtHoraDesde5" runat="server" Width="50" MaxLength="5" Text="09:00" />
		                        </asp:TableCell><asp:TableCell>
			                        Hasta:
			                        <asp:TextBox ID="txtHoraHasta5" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		                        </asp:TableCell><asp:TableCell>
			                        Capacidad:
			                        <asp:TextBox ID="txtCapacidad5" runat="server" Width="15" MaxLength="2" Text="1" />
		                        </asp:TableCell><asp:TableCell>
			                        Duraci&oacute;n (min):
			                        <asp:TextBox ID="txtDuracion5" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		                        </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia6" runat="server" AutoPostBack="True" />&nbsp;&nbsp;Viernes</td><td>
                        <table border="0">
	                        <tr>
		                        <td>
			                        <asp:GridView ID="grdHorarios6" runat="server" Visible="False" 
				                        AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				                        <Columns>
					                        <asp:BoundField DataField="idConfiguracionHoraria" 
						                        HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						                        SortExpression="idConfiguracionHoraria" Visible="False" />
					                        <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						                        SortExpression="idConfiguracionDia" Visible="False" />
					                        <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						                        SortExpression="horaInicio" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						                        SortExpression="horaFin" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						                        SortExpression="capacidad" />
					                        <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						                        SortExpression="duracion" />
					                        <asp:TemplateField HeaderText="Acciones">
						                        <ItemTemplate>
							                        <asp:LinkButton ID="lnkEliminar6" runat="server" CausesValidation="False" 
								                        CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		                        <td align="right" colspan="2">
			                        <asp:LinkButton ID="lnkAgregarOtroHorario6" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb6" runat="server" Visible="False" Width="650px">
	                        <asp:TableRow>
		                        <asp:TableCell>
			                        Desde:
			                        <asp:TextBox ID="txtHoraDesde6" runat="server" Width="50" MaxLength="5" Text="09:00" />
		                        </asp:TableCell><asp:TableCell>
			                        Hasta:
			                        <asp:TextBox ID="txtHoraHasta6" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		                        </asp:TableCell><asp:TableCell>
			                        Capacidad:
			                        <asp:TextBox ID="txtCapacidad6" runat="server" Width="15" MaxLength="2" Text="1" />
		                        </asp:TableCell><asp:TableCell>
			                        Duraci&oacute;n (min):
			                        <asp:TextBox ID="txtDuracion6" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		                        </asp:TableCell></asp:TableRow></asp:Table></td></tr><tr>
                        <td><asp:CheckBox ID="chkDia7" runat="server" AutoPostBack="True" />&nbsp;&nbsp;S&aacute;bado</td><td>
                        <table border="0">
	                        <tr>
		                        <td>
			                        <asp:GridView ID="grdHorarios7" runat="server" Visible="False" 
				                        AutoGenerateColumns="False" DataKeyNames="idConfiguracionHoraria" CssClass="tbHorariosDia" BorderWidth="0">
				                        <Columns>
					                        <asp:BoundField DataField="idConfiguracionHoraria" 
						                        HeaderText="idConfiguracionHoraria" InsertVisible="False" ReadOnly="True" 
						                        SortExpression="idConfiguracionHoraria" Visible="False" />
					                        <asp:BoundField DataField="idConfiguracionDia" HeaderText="idConfiguracionDia" 
						                        SortExpression="idConfiguracionDia" Visible="False" />
					                        <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						                        SortExpression="horaInicio" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						                        SortExpression="horaFin" DataFormatString="{0:t}" />
					                        <asp:BoundField DataField="capacidad" HeaderText="Capacidad" 
						                        SortExpression="capacidad" />
					                        <asp:BoundField DataField="duracion" HeaderText="Duraci&oacute;n" 
						                        SortExpression="duracion" />
					                        <asp:TemplateField HeaderText="Acciones">
						                        <ItemTemplate>
							                        <asp:LinkButton ID="lnkEliminar7" runat="server" CausesValidation="False" 
								                        CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		                        <td align="right" colspan="2">
			                        <asp:LinkButton ID="lnkAgregarOtroHorario7" runat="server" Visible="False">(+) Agregar otro</asp:LinkButton></td></tr></table><asp:Table ID="tb7" runat="server" Visible="False" Width="650px">
	                        <asp:TableRow>
		                        <asp:TableCell>
			                        Desde:
			                        <asp:TextBox ID="txtHoraDesde7" runat="server" Width="50" MaxLength="5" Text="09:00" />
		                        </asp:TableCell><asp:TableCell>
			                        Hasta:
			                        <asp:TextBox ID="txtHoraHasta7" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		                        </asp:TableCell><asp:TableCell>
			                        Capacidad:
			                        <asp:TextBox ID="txtCapacidad7" runat="server" Width="15" MaxLength="2" Text="1" />
		                        </asp:TableCell><asp:TableCell>
			                        Duraci&oacute;n (min):
			                        <asp:TextBox ID="txtDuracion7" runat="server"  Width="35" MaxLength="3"  Text="30"/>
		                        </asp:TableCell></asp:TableRow></asp:Table></td></tr></tbody></table></div><br />

<h2>Configuraci&oacute;n de excepciones</h2><table border="0">
	<tr>
		<td>
			<asp:GridView ID="grdExepciones" runat="server" Visible="True" 
				AutoGenerateColumns="False" DataKeyNames="idExepcion" CssClass="tbHorariosDia" BorderWidth="0">
				<Columns>
					<asp:BoundField DataField="idExepcion" 
						HeaderText="idExepcion" InsertVisible="False" ReadOnly="True" 
						SortExpression="idExepcion" Visible="False" />
					<asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" 
						SortExpression="horaInicio" DataFormatString="{0:t}" />
					<asp:BoundField DataField="horaFin" HeaderText="Hora fin" 
						SortExpression="horaFin" DataFormatString="{0:t}" />
					<asp:TemplateField HeaderText="Acciones">
						<ItemTemplate>
							<asp:LinkButton ID="lnkExcepcionEliminar1" runat="server" CausesValidation="False" 
								CommandName="Delete" Text="Eliminar"></asp:LinkButton></ItemTemplate></asp:TemplateField></Columns></asp:GridView></td></tr><tr>
		<td align="right" colspan="2">
			<asp:LinkButton ID="lnkAgregarOtraExcepcion" runat="server" Visible="True">(+) Agregar otra</asp:LinkButton></td></tr></table>
            <asp:Table ID="tbExcepcion" runat="server" Visible="False" Width="650px">
	<asp:TableRow>
		<asp:TableCell>
			Fecha:
			<asp:TextBox ID="txtFechaExcep" runat="server" Width="80" MaxLength="10" Text="" style="border:1px solid gray !important;" />
		</asp:TableCell><asp:TableCell>
			Desde:
			<asp:TextBox ID="txtHoraDesdeExcep" runat="server" Width="50" MaxLength="5" Text="09:00" />
		</asp:TableCell><asp:TableCell>
			Hasta:
			<asp:TextBox ID="txtHoraHastaExcep" runat="server" Width="50" MaxLength="5" Text="20:00"/>
		</asp:TableCell></asp:TableRow></asp:Table><br />
        <asp:Button ID="btnSiguiente" runat="server" Text="Continuar"  />
    </div>
    <div id="configuralo"></div>
</div>
</asp:Content>