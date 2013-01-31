<%@ Page Title="Detalle Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <style type="text/css">
        .article {
            border-top: 1px dotted #CCC;
            margin-bottom: 15px;
            overflow: hidden;
            clear: both;
        }
        .iconoFavorito
        {
            background-image: url('Images/favorito.png');
            background-repeat: no-repeat;
            display: inline-block;
            width: 32px;
            height: 32px;
            text-indent: 99px;
            overflow: hidden;
            background-repeat: no-repeat;
            top: 0!important;
            vertical-align: middle;
            margin-left:10px;
            margin-top:2px;
        }
        .favOff{
            background-position: 0px -32px;
        }        
        .favOn{
            background-position: 0px 0px;
        }
        .article h3 {
            font-size: 14px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        #lblTelefono {
            background-image: url('Images/phone.png');
        }
        #lblEmail {
            background-image: url('Images/email.png');
        }
        #lblDireccion {
            background-image: url('Images/google-places.png');
        }        
        .lblIcon{
            display: inline-block;
            float: left;
            margin: 2px 5px 0 0;
            width: 16px;
            height: 16px;
        }                
        .labelDetalle {
            
        }
        .lblDatePicker
        {
            background: #fff url('Images/calendar-icon.png') 108px 50% no-repeat;
            border: 1px solid #bdc7d8;
            color: #4b6c9e;
            width: 130px;
            font-size: 1.5em;
        }
    </style>

    <script type="text/javascript">
        function toogleFilters() {
            if ($(filtrosAdicionales).css('display') != "none")
                $(hideFilters).css('background-position', '89px 81px');
            else
                $(hideFilters).css('background-position', '224px 402px');
            $(filtrosAdicionales).toggle('slow');
        }
        
        $(function () {
            $("#tabs").tabs();
            $ID("PedirTurno").button();
            $ID("txtDatePicker").datepicker({ dateFormat: 'dd/mm/yy', minDate: <%=servicio.MinOffset%>, maxDate: <%=servicio.MaxOffset%> });
            $ID("VerHorarios").button();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<div id="Categoria" style="border-bottom: 1px solid #ccc;margin-top: 17px;overflow: hidden;padding: 5px 0;position: relative;width: 100%;">	
		<a href="BuscarServicio.aspx"><asp:Label ID="CategoriaServicio" runat="server" CssClass="linksBusqueda"></asp:Label></a>
	</div>
	<div class="imagenServicio" style="float: left;padding: 10px;" >
		<asp:Image runat="server" ID="ImagenServicio" />
    </div>

    <div class="detalleServicio" style="float: left;padding: 10px;">
        <div id="nombreServicio" style="font-size: 28px;font-weight: bold;line-height: 33px;margin-top: 0;letter-spacing: -0.5px;color: #555;float:left;"><asp:Label ID="NombreServicio" runat="server" /></div>
        <div id="favorito">
            <asp:LinkButton ID="Favoritos" runat="server" CssClass="iconoFavorito favOff" title="Agregar a favoritos"/>
        </div>
        <p>
        <asp:Label CssClass="labelDetalle" ID="lblObservacionesServicio" runat="server" Text="Observaciones:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ObservacionesServicio" runat="server"></asp:Label>
        </p>
        <div id="precioServicio" style="color: #900;font-size: 16px;font-weight: bold;"><asp:Label ID="PrecioServicio" runat="server" /></div>
        <div id="detalleProveedor" class="article reputation">
            <h3 style="font-variant:normal;">Proveedor del servicio</h3>
            <asp:Label CssClass="labelDetalleInfo" ID="ProveedorServicio" runat="server" style="text-transform: uppercase;"></asp:Label>
            <div>
                <div id="lblDireccion" class="lblIcon"></div>
                <asp:Label CssClass="labelDetalleInfo" ID="DireccionServicio" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label CssClass="labelDetalle" ID="Label3" runat="server" Text="Zona:"></asp:Label>
                <asp:Label CssClass="labelDetalleInfo" ID="ZonaServicio" runat="server"></asp:Label>
            </div>
            <div>
                <div id="lblTelefono" class="lblIcon"></div>
                <asp:Label CssClass="labelDetalleInfo" ID="TelefonoServicio" runat="server"></asp:Label>
            </div>        
            <div style="clear: both;">
                <div id="lblEmail" class="lblIcon"></div>
                <asp:Label CssClass="labelDetalleInfo" ID="EmailServicio" runat="server"></asp:Label>
            </div>
        </div>
        <div id="reservarTurno" runat="server" class="article reputation">
            <h3 style="font-variant:normal;">Pedir turno</h3>
            Cuándo? <asp:TextBox CssClass="lblDatePicker" runat="server" ID="txtDatePicker"></asp:TextBox>
            <asp:Button ID="VerHorarios" runat="server" Text="Ver horarios" />
        </div>
    </div>
    <div style="clear:both;"></div>

    <div id="divMessage" runat="server">
        <asp:Literal ID="ErrorMessage" runat="server" Visible="false"></asp:Literal>
    </div>    
    <div id="DIVPedirTurno" runat="server">
        <asp:GridView CssClass="GrillaTurnosDisponibles" ID="HorariosxDia" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%--<asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />--%>
                <asp:BoundField DataField="horaInicio" HeaderText="Hora Inicio" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" HeaderStyle-HorizontalAlign="Left" />
                <asp:HyperLinkField Text="Reservar Turno" HeaderText="Accion" HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFormatString="ReservarTurno.aspx?horaInicio={0}&horaFin={1}&fecha={2}&servicioID={3}"  DataNavigateUrlFields="horaInicio, horaFin, fecha, servicioID" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>

    <div id="tabs" style="margin:10px;clear: both;">
	    <ul>
		    <li><a href="#descripcion">Descripci&oacute;n</a></li>
            <li><a href="#grupos-asociados">Grupos asociados</a></li>
	    </ul>
	    <div id="descripcion">
            <asp:Literal ID="DescripcionServicio" runat="server"></asp:Literal>
        </div>
        <div id="grupos-asociados">
            <div id="GruposAsociadosServ">
                <asp:GridView ID="GruposAsociados" runat="server" AutoGenerateColumns="False" 
                    CssClass="tbHorariosDia">
                    <Columns>
                        <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleGrupo.aspx?id={0}" DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" >
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Left" >
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>        
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            if ($ID('GruposAsociados').size() == 0) {
                $("#tabs").tabs('option', 'disabled', [1]);
                //$("#tabs ul :last-child").attr('title', 'No hay grupos asociados a este servicio')
            }
        });    
    </script>
</asp:Content>
