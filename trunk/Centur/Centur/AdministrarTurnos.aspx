<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdministrarTurnos.aspx.vb" Inherits="Centur.AdministrarTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Administrar turnos:
    <asp:Label runat="server" ID="LabelServicio"></asp:Label>
    </h1>

<h2>Turnos otorgados</h2>
<div id="tomados" runat="server" visible="False">
<br />
<asp:GridView ID="GridTomados" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idTurno">
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>
       
       <asp:BoundField DataField="clienteNombre" HeaderText="Nombre de usuario" SortExpression="clienteNombre"/>
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

    <asp:Label ID="LabelNoTurnosOtorgados" runat="server" 
        Text="Usted no ha otorgado turnos para este servicio"></asp:Label>
<br />
<br />

<h2>Turnos pendientes de aprobacion</h2>
<div id="pendientes" runat="server" visible="False">
<br />
<asp:GridView ID="GridPendientes" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idTurno">
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>
       
       <asp:BoundField DataField="clienteNombre" HeaderText="Nombre de usuario" SortExpression="clienteNombre"/>
       <asp:BoundField DataField="Fecha" HeaderText="Fecha turno" SortExpression="Fecha"/>
       <asp:BoundField DataField="horaInicio" HeaderText="Hora inicio" SortExpression="horaInicio"/>
       <asp:BoundField DataField="horaFin" HeaderText="Hora fin" SortExpression="horaFin"/>

       </Columns>
       </asp:GridView>
             
       <br />
       <asp:LinkButton ID="LinkButtonCancelAp" runat="server">Cancelar turnos</asp:LinkButton>
       <br />
       <asp:LinkButton ID="LinkButtonAcepAp" runat="server">Aceptar turnos</asp:LinkButton>
     </div>

    <asp:Label ID="LabelNoPendientes" runat="server" 
        Text="Usted no tiene turnos pendientes para este servicio"></asp:Label>


</asp:Content>
