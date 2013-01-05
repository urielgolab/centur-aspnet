<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="DetalleGrupo.aspx.vb" Inherits="Centur.DetalleGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1> Detalle grupo </h1>
     
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server" ReadOnly="True"></asp:TextBox> 
        &nbsp;
        &nbsp;
        &nbsp;
        <asp:LinkButton ID="Adherir" runat="server" Visible="False">Unite!</asp:LinkButton>
        <asp:LinkButton ID="Desuscribirse" runat="server" Visible="False">Cancelar suscripción</asp:LinkButton>
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server" ReadOnly="True"></asp:TextBox>
               <br />
       <br />
       <table>
       <tr> 
          <td>
     
        <div id="servicios" Runat="Server" Visible="False">
        <asp:Label ID="Label3" runat="server" Text="Servicios"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxServicios" runat="server">
            
        </asp:ListBox>
        <br />
        </div>

    <asp:Label ID="LabelNoServicios" runat="server" 
        Text="Usted no tiene servicios asociados a este grupo" Visible="False"></asp:Label>
        </td> <td>
        <div id="miembros" Runat="Server" Visible="False">
        <asp:Label ID="LabelMiembros" runat="server" Text="Miembros"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxMiembros" runat="server">
            
        </asp:ListBox>
        <br />
        </div>

    <asp:Label ID="LabelNoMiembros" runat="server" 
        Text="Usted no tiene miembros asociados a este grupo" Visible="False"></asp:Label>
        </td>
        </tr> 
        </table> 
    <div id="comandosGrupo" Runat="Server" Visible="False">
    <br />
    <asp:LinkButton ID="editGrupo" runat="server">Modificar Grupo</asp:LinkButton>
    <br />
    <asp:LinkButton ID="suprGrupo" runat="server">Eliminar Grupo</asp:LinkButton>
    </div>

    <br />
    
</asp:Content>

