<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="VerEstadisticas.aspx.vb" Inherits="Centur.VerEstadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script src="Scripts/external/globalize.js"></script>
    <script src="Scripts/external/globalize.culture.de-DE.js"></script>
    <script src="Scripts/external/jquery.mousewheel.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <script type="text/javascript">

     $(function () {
         $("#MainContent_FechaDesde").datepicker({ dateFormat: 'dd/mm/yy' });
         $("#MainContent_FechaHasta").datepicker({ dateFormat: 'dd/mm/yy' });
         //            $("#MainContent_HoraDesde").timepicker({ 'timeFormat': 'H:i', 'step': 60 });
//         $("#MainContent_HoraHasta").timepicker({ 'timeFormat': 'H:i', 'step': 60 });
     });
      

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
         Globalize.culture("de-DE");
         $("#MainContent_HoraDesde").timespinner();
         $("#MainContent_HoraHasta").timespinner();
     });


    

</script>

<%-- <script type="text/javascript"> 
 $(function () {
     $('[id^="MainContent_HoraDesde"]').spinner({ max: 30, min: 1 });
 });
</script>--%>

<p align="left" class="tituloPrincipal" > Estadisticas</p>

<div class="anchoCompleto">
<p class="busqueda">Seleccione la estadistica</p>
<asp:RadioButtonList runat="server" ID="Estadistica">
    <asp:ListItem Value="A" Text="Cantidad de personas que llegaron al detalle del aviso" > </asp:ListItem>   
    <asp:ListItem Value="C" Text="Cantidad de personas que cancelaron un turno" > </asp:ListItem>   
    <asp:ListItem Value="P" Text="Porcentaje de ocupación del servicio" > </asp:ListItem>   
    <asp:ListItem Value="D" Text="Cantidad de dinero recaudado mediante el sistema" > </asp:ListItem>   
</asp:RadioButtonList>

<div class="Servicio">
     <p class="busqueda">Servicio</p>
    <asp:DropDownList ID="DDLServicios" runat="server" DataTextField="Nombre" DataValueField="ID">
    </asp:DropDownList>
</div>
</div>

<div class="EstadisticasFecha"> 
    <p class="busqueda">Fecha</p>
     <p>Desde: <asp:TextBox CssClass="txtDatePicker" runat="server" ID="FechaDesde"></asp:TextBox></p>
    <p>Hasta: <asp:TextBox CssClass="txtDatePicker" runat="server" ID="FechaHasta"></asp:TextBox></p>
</div>

<div class="EstadisticasHora">
    <p class="busqueda">Horario</p>
    <p>Desde: <asp:TextBox CssClass="txtDatePicker" runat="server" ID="HoraDesde" MaxLength="5" Text="09:00"></asp:TextBox></p>
    <p>Hasta: <asp:TextBox CssClass="txtDatePicker" runat="server" ID="HoraHasta" MaxLength="5" Text="18:00"></asp:TextBox></p>
</div>

<div class="EstadisticasLinks">
<asp:LinkButton ID="CalcularEstadisticas" runat="server">Calcular</asp:LinkButton>
<asp:LinkButton ID="BorrarEstadisticas" runat="server">Borrar</asp:LinkButton>
</div>

  <div class="failureNotification">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
  </div>

<div class="EstadisticasResultado">
<asp:Label runat="server" ID="lblResultado"></asp:Label>
</div>

</asp:Content>
