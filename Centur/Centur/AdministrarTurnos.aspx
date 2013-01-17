<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AdministrarTurnos.aspx.vb" Inherits="Centur.AdministrarTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p align="left" class="tituloPrincipal" > Administrar turnos: 
    <asp:Label runat="server" ID="LabelServicio"></asp:Label>
</p>

<p class="busqueda">Turnos otorgados</p>
<div id="tomados" class="DivTurnosTomados" runat="server">

<asp:GridView ID="GridTomados" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idTurno" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
       <AlternatingRowStyle BackColor="White" />
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
       <br />     
       
            <asp:Label ID="Label5" runat="server" Text="Seleccione turnos a cancelar"></asp:Label>
       
       <br />
       <asp:LinkButton ID="Cancelar" CssClass="TurnosModificarLinks" runat="server">Cancelar turnos</asp:LinkButton>
     </div>

    <asp:Label ID="LabelNoTurnosOtorgados" runat="server" 
        Text="Usted no ha otorgado turnos para este servicio" Visible="False" 
        Font-Size="Medium" Font-Names="Corbel"></asp:Label>


   <div class="DivTurnoProveedorReservar" style="border: thin solid #FF0000">
    <asp:Label ID="Label6" cssclass="TurnosLabelIzq" runat="server" Text="Reservar turno a usuario: "></asp:Label>
    <asp:TextBox ID="TextBoxUser" runat="server"></asp:TextBox>
    <asp:LinkButton ID="linkVerTurno" CssClass="TurnosVerLinks" runat="server">Ver disponibilidad</asp:LinkButton>
    <br />
    <asp:Label ID="LabelUsuarioNoExiste" runat="server" Text="Usuario no existente. Intente nuevamente" cssclass="TurnosLabelIzq" ForeColor="Red" 
        Visible="False" Font-Size="Medium"></asp:Label>
        </div>

<p class="busqueda">Turnos pendientes de aprobacion</p>

<div id="pendientes" runat="server">
<br />
<asp:GridView ID="GridPendientes" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idTurno" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
       <AlternatingRowStyle BackColor="White" />
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
             
       <div class="TurnosPendientesLinks">
       <asp:LinkButton ID="LinkButtonAcepAp" runat="server">Aceptar turnos</asp:LinkButton>
       <asp:LinkButton ID="LinkButtonCancelAp" CssClass="LinkDerecho" runat="server">Cancelar turnos</asp:LinkButton>
       </div>
     </div>

    <asp:Label ID="LabelNoPendientes" runat="server" 
        Text="Usted no tiene turnos pendientes para este servicio" Visible="False" 
        Font-Size="Medium"></asp:Label>


</asp:Content>
