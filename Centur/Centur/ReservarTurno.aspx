<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ReservarTurno.aspx.vb" Inherits="Centur.ReservarTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Literal ID="ltlMercadoPago" runat="server"></asp:Literal>
    
    <label style="float:left; width:600px;" id="TurnoStatus" runat="server"></label> 
    <br />
    <img id="tildeCofirmacion" style="float:left;" src="Images/TildeVerde.jpg" />

</asp:Content>
