<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="GrupoPendientes.aspx.vb" Inherits="Centur.GrupoPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Usuarios Pendientes de Aprobación</h1>
    <p>
        <asp:GridView ID="GridPendientes" runat="server" AutoGenerateColumns="False" DataKeyNames="IdGrupo,IdUsuario">
        <Columns>
            
         <asp:TemplateField HeaderText="Selecccione">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="CheckBox1"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="NombreGrupo" HeaderText="Nombre Grupo" SortExpression="NombreGrupo" />
            <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" SortExpression="NombreUsuario" />
        </Columns>
        </asp:GridView>
        <asp:LinkButton ID="AceptarSel" runat="server">Aceptar seleccionados</asp:LinkButton>
    </p>

</asp:Content>
