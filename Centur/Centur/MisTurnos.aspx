<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MisTurnos.aspx.vb" Inherits="Centur.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p align="left" class="tituloPrincipal" > Mis Turnos</p>
<div id="propios" Runat="Server">
<p class="busqueda">Servicios prestados</p>
<br />
        <asp:Label ID="Label1" runat="server" Text="Seleccionar servicio: "></asp:Label>
        
<asp:DropDownList ID="DropDownListServiciosPropios" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee servicios</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton4" CssClass="TurnosVerLinks" runat="server">Ver Turnos...</asp:LinkButton>
        
</div>
<p class="busqueda">Turnos inscriptos</p>
<div id="tomados" runat="server">
<br />
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
       
       <asp:HyperLinkField DataTextField="ServicioNombre" HeaderText="Nombre servicio" DataNavigateUrlFormatString="~/DetalleServicio.aspx?servicioID={0}"
                    DataNavigateUrlFields="ServicioID" />
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
     <asp:Label ID="labelNoReservados" runat="server" 
        Text="Usted no posee turnos reservados" Visible="False" Font-Size="Medium"></asp:Label>
     <br />
</asp:Content>
