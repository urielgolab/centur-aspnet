<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MisTurnos.aspx.vb" Inherits="Centur.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Mis Turnos</h1>
<div id="propios" Runat="Server">
<h2>Turnos otorgados</h2>
<br />
        <asp:Label ID="Label1" runat="server" Text="Seleccionar servicio"></asp:Label>
        
<asp:DropDownList ID="DropDownListServiciosPropios" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee servicios</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton4" runat="server">Ver Turnos...</asp:LinkButton>
        
</div>
<h2>Turnos inscriptos</h2>
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
       
       <asp:BoundField DataField="ServicioNombre" HeaderText="Nombre servicio" SortExpression="ServicioNombre"/>
       <asp:BoundField DataField="Fecha" HeaderText="Fecha turno" SortExpression="Fecha"/>
       <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" SortExpression="horaInicio"/>
       <asp:BoundField DataField="horaFin" HeaderText="Hora fin" SortExpression="horaFin"/>

       </Columns>
       </asp:GridView>
       <br />     
       
            <asp:Label ID="Label5" runat="server" Text="Seleccione turnos a cancelar"></asp:Label>
     </div>
     <asp:Label ID="labelNoReservados" runat="server" 
        Text="Usted no posee turnos reservados" Visible="False"></asp:Label>
     <br />
</asp:Content>
