<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="CrearGrupo.aspx.vb" Inherits="CrearGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>Crear grupo</h1>
 <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server"></asp:TextBox> 
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server"></asp:TextBox>
       <br />
               
    <asp:LinkButton ID="LinkButton1" runat="server">Crear</asp:LinkButton>
</asp:Content>

