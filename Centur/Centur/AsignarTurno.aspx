<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AsignarTurno.aspx.vb" Inherits="Centur.AsignarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript"> 
        $(function () {
            $("#MainContent_txtDatePicker").datepicker({ dateFormat: 'dd/mm/yy' });
        });
    </script>

    <div id="DIVPedirTurno">
        <asp:TextBox CssClass="txtDatePicker" runat="server" ID="txtDatePicker"></asp:TextBox>
        <asp:LinkButton CssClass="MarginLeft30" ID="VerHorarios" runat="server"> Ver Horarios </asp:LinkButton>
        <asp:GridView CssClass="GrillaTurnosDisponibles" ID="HorariosxDia" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%--<asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />--%>
                <asp:BoundField DataField="horaInicio" HeaderText="Hora Inicio" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" HeaderStyle-HorizontalAlign="Left" />
                <asp:HyperLinkField Text="Reservar Turno" HeaderText="Accion" HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFormatString="ReservarTurnoProveedor.aspx?horaInicio={0}&horaFin={1}&fecha={2}&servicioID={3}&usuarioID={4}"  DataNavigateUrlFields="horaInicio, horaFin, fecha, servicioID, usuarioID" />
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
