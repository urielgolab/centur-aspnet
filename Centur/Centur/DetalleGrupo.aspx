<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="DetalleGrupo.aspx.vb" Inherits="Centur.DetalleGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal" > Detalle Grupo</p>
         
        <div class="GrupoDetalleTextbox"> 
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server" ReadOnly="True"></asp:TextBox> 
          
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        
        <div class="GrupoDetalleLinksSuscripcion"> 
        <asp:LinkButton ID="Adherir" runat="server" Visible="False">Unite!</asp:LinkButton>
        <asp:LinkButton ID="Desuscribirse" runat="server" Visible="False">Cancelar suscripción</asp:LinkButton>
        </div>
       
       
       <div class="GrupoDetalleListas">
        <div class="GrupoDetalleServicios">
        <div id="servicios" Runat="Server" Visible="False">
        <p class="busqueda">Servicios</p>
        <asp:ListBox ID="ListBoxServicios" runat="server" Width="150px">
            
        </asp:ListBox>
        <br />
        </div>

    <asp:Label ID="LabelNoServicios" runat="server" 
        Text="Usted no tiene servicios asociados a este grupo" Visible="False" 
                ForeColor="#FF3300"></asp:Label>
       </div>
        <div class="GrupoDetalleMiembros">
        <div id="miembros" Runat="Server" Visible="False">
        <p class="busqueda">Miembros</p>
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
    <asp:LinkButton ID="editGrupo" runat="server">Modificar Grupo</asp:LinkButton>
    <asp:LinkButton ID="suprGrupo" CssClass="LinkDerecho" runat="server">Eliminar Grupo</asp:LinkButton>
    </div>

    
    
</asp:Content>

