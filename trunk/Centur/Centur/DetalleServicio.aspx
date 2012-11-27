<%@ Page Title="Detalle Servicio" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.1.custom.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#MainContent_txtDatePicker").datepicker();
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
    <h1>
        Detalle Servicio
    </h1>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
        <asp:Label ID="NombreServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Descripcion:"></asp:Label>
        <asp:Label ID="DescripcionServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Categoria:"></asp:Label>
        <asp:Label ID="CategoriaServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Zona:"></asp:Label>
        <asp:Label ID="ZonaServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Precio:"></asp:Label>
        <asp:Label ID="PrecioServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Proveedor:"></asp:Label>
        <asp:Label ID="ProveedorServicio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Direccion:"></asp:Label>
        <asp:Label ID="DireccionServicio" runat="server"></asp:Label>
        <br />
        <asp:LinkButton ID="Favoritos" runat="server"> </asp:LinkButton>
        <asp:Label ID="Mensaje" runat="server"></asp:Label>
        <asp:Image runat="server" ID="ImagenServicio" />
        <div id="GruposAsociadosServ">
            <asp:Label ID="Label8" runat="server" Text="Grupos"></asp:Label>
            <asp:ListView ID="GruposAsociados" runat="server">
            </asp:ListView>
        </div>
    </div>
    <div>
        <asp:LinkButton ID="VolveraBusqueda" PostBackUrl="~/BuscarServicio.aspx" runat="server"> Volver </asp:LinkButton>
        <a href="#" id="PedirTurno">Pedir Turno</a>
    </div>
    <div id="DIVPedirTurno" style="height: 600px;">
        <asp:TextBox runat="server" ID="txtDatePicker"></asp:TextBox>
        <asp:LinkButton ID="VerHorarios" runat="server"> Ver Horarios </asp:LinkButton>
        <asp:GridView ID="HorariosxDia" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />
                <asp:BoundField DataField="horaInicio" HeaderText="Hora Inicio" />
                <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" />
                <asp:HyperLinkField Text="Reservar!" HeaderText="Accion" DataNavigateUrlFormatString="ReservarTurno.aspx?horaInicio={0}&horaFin={1}" DataNavigateUrlFields="horaInicio, horaFin"  />
            </Columns>
        </asp:GridView>
        <div id="DIVVerHorarios">
            <asp:ListView ID="HorariosxDia2" runat="server">
            </asp:ListView>
        </div>
    </div>
</asp:Content>
