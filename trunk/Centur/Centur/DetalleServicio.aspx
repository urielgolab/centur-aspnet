<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        Detalle Servicio
    </h1>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
        <asp:label id="NombreServicio" runat="server"></asp:label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Descripcion"></asp:Label>
         <asp:label id="DescripcionServicio" runat="server"></asp:label>
        <br /> 
        <asp:Label ID="Label2" runat="server" Text="Categoria"></asp:Label>
        <asp:label id="CategoriaServicio" runat="server"></asp:label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Zona"></asp:Label>
        <asp:label id="ZonaServicio" runat="server"></asp:label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Precio"></asp:Label>
        <asp:label id="PrecioServicio" runat="server"></asp:label>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Proveedor"></asp:Label>
        <asp:label id="ProveedorServicio" runat="server"></asp:label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
        <asp:label id="DireccionServicio" runat="server"></asp:label>
        <br />
        <asp:Image runat="server" ID="ImagenServicio" />

        <div id="GruposAsociadosServ">
            <asp:Label ID="Label8" runat="server" Text="Grupos"></asp:Label>
            <asp:ListView ID="GruposAsociados" runat="server">
        </asp:ListView>
        </div>
        

    </div>
    <div>
           <asp:LinkButton ID="VolveraBusqueda" PostBackUrl="~/BuscarServicio.aspx" runat="server"> Volver </asp:LinkButton>
           <asp:LinkButton ID="PedirTurno" runat="server"> Pedir Turno </asp:LinkButton>
    </div>
    <div id="DIVPedirTurno" runat="server">
        <asp:Calendar ID="CalendarTurnos" SelectionMode="Day" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
        <asp:LinkButton ID="ConfirmarFechaTurno" Text="OK" runat="server" />

        <div id="DIVSeleccionHorario" runat="server">
              <asp:ListView ID="HorariosxDia" runat="server">
        </asp:ListView>
        </div><
    </div>
    
</asp:Content>
