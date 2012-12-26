<%@ Page Title="Detalle Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript"> 
        $(function () {
            $("#MainContent_txtDatePicker").datepicker({ dateFormat: 'dd/mm/yy', minDate: <%=servicio.MinOffset%>, maxDate: <%=servicio.MaxOffset%> });
        });
    </script>
    <script type="text/javascript"> 
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
    </script>

<p align="left" class="tituloPrincipal" > Detalle del Servicio</p>

    <div class="detalleServicio">
     <p class="busqueda">Informacion</p>
    <p>
        <asp:Label CssClass="labelDetalle" ID="Label4" runat="server" Text="Nombre:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="NombreServicio" runat="server"></asp:Label>
       </p>
       <p>
        <asp:Label CssClass="labelDetalle" ID="Label1" runat="server" Text="Descripcion:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="DescripcionServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label2" runat="server" Text="Categoria:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="CategoriaServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label3" runat="server" Text="Zona:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ZonaServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label5" runat="server" Text="Precio:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="PrecioServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label6" runat="server" Text="Proveedor:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="ProveedorServicio" runat="server"></asp:Label>
        </p>
        <p>
        <asp:Label CssClass="labelDetalle" ID="Label7" runat="server" Text="Direccion:"></asp:Label>
        <asp:Label CssClass="labelDetalleInfo" ID="DireccionServicio" runat="server"></asp:Label>
        </p>
        
        <asp:Label ID="Mensaje" runat="server"></asp:Label>

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
            
        </div>
    </div>



    <div class="imagenServicio">
    <asp:Image runat="server" ID="ImagenServicio" />
    </div>

   <div class="filtrosBusqueda links">   
   <asp:LinkButton ID="Favoritos" runat="server"> </asp:LinkButton>
        <asp:LinkButton ID="VolveraBusqueda" PostBackUrl="~/BuscarServicio.aspx" runat="server"> Volver </asp:LinkButton>
        <a href="#" id="PedirTurno">Pedir Turno</a>
    </div>

            <div id="DIVPedirTurno">
        <asp:TextBox runat="server" ID="txtDatePicker"></asp:TextBox>
        <asp:LinkButton ID="VerHorarios" runat="server"> Ver Horarios </asp:LinkButton>
        <asp:GridView ID="HorariosxDia" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />
                <asp:BoundField DataField="horaInicio" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" />
                <asp:HyperLinkField Text="Reservar!" HeaderText="Accion"  DataNavigateUrlFormatString="ReservarTurno.aspx?horaInicio={0}&horaFin={1}&fecha={2}&servicioID={3}"  DataNavigateUrlFields="horaInicio, horaFin, fecha, servicioID" />
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
