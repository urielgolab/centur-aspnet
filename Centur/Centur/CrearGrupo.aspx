<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="CrearGrupo.aspx.vb" Inherits="Centur.CrearGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $ID("ButtonCrear").button();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<p align="left" class="tituloPrincipal" > Crear Grupo</p>
 <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server"></asp:TextBox> 
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server"></asp:TextBox>
       <br />
               
    <br />
    <asp:Button ID="ButtonCrear" cssclass="GrupoCrearLinks" runat="server" Text="Crear"></asp:Button>
    <br />
    <br />
    <asp:Label ID="Success" runat="server" Text="Grupo creado exitosamente" 
        Visible="False"></asp:Label>
</asp:Content>

