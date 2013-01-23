<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="DetalleGrupo.aspx.vb" Inherits="Centur.DetalleGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $ID("ButtonAdherir").button();
            $ID("ButtonDesuscribirse").button();
            $ID("ButtonEditGrupo").button();
            $ID("ButtonSuprGrupo").button();
        });
        </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal" > Detalle Grupo</p>
         
        <div class="GrupoDetalleLabel"> 
        <asp:Label ID="Label1" runat="server" Text="Nombre: " Font-Size="Large"></asp:Label>
        <asp:Label ID="LabelNombreGrupo" runat="server" Font-Size="Large"></asp:Label>
                 
        <br />
        <asp:Label ID="Label2" runat="server" Text="Descripcion: " Font-Size="Large"></asp:Label>
        <asp:Label ID="LabelDescripGrupo" runat="server" Font-Size="Large"></asp:Label>
        </div>
        
        <div class="GrupoDetalleLinksSuscripcion"> 
        <asp:Button ID="ButtonAdherir" runat="server" Visible="False" Text="Unite!"></asp:Button>
        <asp:Button ID="ButtonDesuscribirse" runat="server" Visible="False" Text="Cancelar suscripción"></asp:Button>
        </div>
       
       
       <div class="GrupoDetalleListas">
        <div class="GrupoDetalleServicios">
        
        <p class="busqueda">Servicios</p>
        <div id="servicios" Runat="Server" Visible="False">
        <asp:ListBox ID="ListBoxServicios" runat="server" Width="150px">
            
        </asp:ListBox>
        <br />
        </div>

    <asp:Label ID="LabelNoServicios" runat="server" 
        Text="Usted no tiene servicios asociados a este grupo" Visible="False" 
                ForeColor="#FF3300"></asp:Label>
       </div>
        <div id="DivMiembros" runat="server" class="GrupoDetalleMiembros">
        <p class="busqueda">Miembros</p>
        <div id="miembros" Runat="Server" Visible="False">
        <asp:ListBox ID="ListBoxMiembros" CssClass="GrupoDetalleListBox" runat="server" 
                Width="150px">
            
        </asp:ListBox>
        <br />
        </div>

    <asp:Label ID="LabelNoMiembros" runat="server" 
        Text="Usted no tiene miembros asociados a este grupo" Visible="False" 
                ForeColor="#FF3300"></asp:Label>
        </div>
       </div>    
    <div id="comandosGrupo" class="GrupoDetalleLinks" Runat="Server" Visible="False">
    <asp:Button ID="ButtonEditGrupo" runat="server" Text="Modificar Grupo"></asp:Button>
    <asp:Button ID="ButtonSuprGrupo" CssClass="ButtonDerecho" runat="server" Text="Eliminar Grupo"></asp:Button>
    </div>

    
    
</asp:Content>

