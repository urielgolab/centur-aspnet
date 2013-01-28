<%@ Page Title="Detalle Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
    <style>
        .article {
            border-top: 1px dotted #CCC;
            margin-bottom: 15px;
            overflow: hidden;
            clear: both;
        }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript"> 
        $(function () {
            $("#MainContent_txtDatePicker").datepicker({ dateFormat: 'dd/mm/yy', minDate: <%=servicio.MinOffset%>, maxDate: <%=servicio.MaxOffset%> });
        });
    </script>
    <%--<script type="text/javascript"> 
        $(document).ready(function () {
            //$('#DIVPedirTurno').hide();
            $('#DIVVerHorarios').hide();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#PedirTurno").click(function () {
                $("#DIVPedirTurno").show();
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#VerHorarios").click(function () {
                $("#DIVVerHorarios").show();
            });
        });
    </script>--%>
	<div id="Categoria" style="border-bottom: 1px solid #ccc;margin-top: 17px;overflow: hidden;padding: 5px 0;position: relative;width: 100%;">	
		<a href="links.aspx"><asp:Label ID="CategoriaServicio" runat="server"></asp:Label></a>
	</div>
	<div class="imagenServicio" style="float: left;padding: 10px;" >
		<asp:Image runat="server" ID="ImagenServicio" />
    </div>

    <div class="detalleServicio" style="float: left;padding: 10px;">
        <div id="nombreServicio" style="font-size: 28px;font-weight: bold;line-height: 33px;margin-top: 0;letter-spacing: -0.5px;color: #555;"><asp:Label ID="NombreServicio" runat="server" /></div>
        <div id="favorito">
            <a class="bookmark bookmark-add ch-points-ltlb" href="#" title="Agregar a favoritos" aria-describedby="ch-tooltip-1"><span class="ico fav-off"></span>
                <span class="bookmark-txt">Agregar a favoritos</span>	
            </a>
        </div>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label3" runat="server" Text="Zona:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ZonaServicio" runat="server"></asp:Label>
        </p>
        <div id="precioServicio" style="color: #900;font-size: 16px;font-weight: bold;"><asp:Label ID="PrecioServicio" runat="server" /></div>
        <div class="article reputation">	<h3>Reputación del vendedor</h3> <dl class="meter">	<dt> Reputación:</dt>	<dd class="repLay ch-points-ltlb" aria-describedby="ch-layer-1" style="cursor: pointer;">	<p class="meter rep5"><span class="valueRep">3</span>/5</p>	<span class="repDescrip">	<span title="MercadoLíder Platinum" class="ch-ico ch-mercadolider-platinum" id="mlP">MercadoLíder Platinum</span>	</span>	</dd> </dl> </div>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label6" runat="server" Text="Proveedor:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ProveedorServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label7" runat="server" Text="Direccion:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="DireccionServicio" runat="server"></asp:Label>
        </p>

        <p>
        <asp:Label CssClass="labelDetalle" ID="Label8" runat="server" Text="Telefono:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="TelefonoServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label10" runat="server" Text="Email:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="EmailServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label12" runat="server" Text="Observaciones:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ObservacionesServicio" runat="server"></asp:Label>
        </p>
        
        <asp:Label ID="Mensaje" runat="server"></asp:Label>
        
        <div class="linksDetalleServicio">  
        <asp:LinkButton ID="Favoritos" runat="server"> </asp:LinkButton>
        </div>

         <p class="busqueda">Grupos asociados</p>


        <div id="GruposAsociadosServ">
            <asp:GridView ID="GruposAsociados" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                <asp:HyperLinkField DataTextField="Nombre" HeaderText="Nombre" DataNavigateUrlFormatString="DetalleGrupo.aspx?id={0}"
                    DataNavigateUrlFields="ID" HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:HyperLinkField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" 
                                HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                            </asp:BoundField>
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
            <p class="failureNotificationNegrita">
            <asp:Label ID="ErrorMessageGruposAsoc" runat="server"></asp:Label>
            </p>
        </div>
    </div>
    <div style="clear:both;">
        <asp:Label CssClass="labelDetalleInfo" ID="DescripcionServicio" runat="server"></asp:Label>
    </div> 

   <div class="linksDetalleServicio2">   
   
   <asp:LinkButton ID="VolveraBusqueda" PostBackUrl="~/BuscarServicio.aspx" runat="server"> Volver </asp:LinkButton>
         <asp:LinkButton CssClass="MarginLeft30" ID="PedirTurno" runat="server"> Pedir Turno </asp:LinkButton>
        <%--<a href="#" class="MarginLeft30" id="PedirTurno">Pedir Turno</a>--%>
    </div>
          <p class="failureNotification">
            <asp:Label ID="ErrorMessageExterno" runat="server"></asp:Label>
        </p>

            <div id="DIVPedirTurno" runat="server">
        <asp:TextBox CssClass="txtDatePicker" runat="server" ID="txtDatePicker"></asp:TextBox>
        <asp:LinkButton CssClass="MarginLeft30" ID="VerHorarios" runat="server"> Ver Horarios </asp:LinkButton>
        <p class="failureNotification">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
        </p>
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
        <div id="DIVVerHorarios">
            <asp:ListView ID="HorariosxDia2" runat="server">
            </asp:ListView>
        </div>
    </div>

</asp:Content>
