<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdministrarTurnos.aspx.vb" Inherits="Centur.AdministrarTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Admini strar turnos:
    <asp:Label runat="server"></asp:Label>
    </h1>

<h2>Turnos otorgados</h2>
<div id="tomados" runat="server">
<br />
<asp:GridView ID="GridTomados" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idTurno">
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>
       
       <asp:HyperLinkField DataTextField="ServicioNombre" HeaderText="Nombre servicio" DataNavigateUrlFormatString="~/DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ServicioID" />
       <asp:BoundField DataField="Fecha" HeaderText="Fecha turno" SortExpression="Fecha"/>
       <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" SortExpression="horaInicio"/>
       <asp:BoundField DataField="horaFin" HeaderText="Hora fin" SortExpression="horaFin"/>

       </Columns>
       </asp:GridView>
       <br />     
       
            <asp:Label ID="Label5" runat="server" Text="Seleccione turnos a cancelar"></asp:Label>
       
       <br />
       <asp:LinkButton ID="Cancelar" runat="server">Cancelar turnos</asp:LinkButton>
     </div>

<br />
<br />


</asp:Content>
