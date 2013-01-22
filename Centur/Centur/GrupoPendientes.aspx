<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GrupoPendientes.aspx.vb" Inherits="Centur.GrupoPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $ID("ButtonAceptarSel").button();
            $ID("ButtonRechazarSel").button();
        });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p align="left" class="tituloPrincipal" > Usuarios pendientes de aprobación</p>

    <div id="pendientes" Runat="Server">
        <asp:GridView ID="GridPendientes" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="IdGrupo,IdUsuario" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
        <Columns>
            
         <asp:TemplateField HeaderText="Selecccione">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="CheckBox1"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="NombreGrupo" HeaderText="Nombre Grupo" SortExpression="NombreGrupo" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" SortExpression="NombreUsuario" />
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
   
        <div class="GruposPendientesLinks">
            <asp:Button ID="ButtonAceptarSel" runat="server" Text="Aceptar seleccionados"></asp:Button>
            <asp:Button ID="ButtonRechazarSel" cssclass="ButtonDerecho" runat="server" Text="Rechazar Seleccionados"></asp:Button>
        </div>
     </div>
    <asp:Label ID="noPendientes" runat="server" Font-Size="Large" 
        Text="Usted no tiene usuarios pendientes de aprobación" Visible="False"></asp:Label>
    <br />
    

</asp:Content>
