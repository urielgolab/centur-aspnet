<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="MiCuenta.aspx.vb" Inherits="Centur.MiCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1>Mi Cuenta</h1>
    <%--<asp:LinkButton runat="server" PostBackUrl="~/VerDatosPersonales.aspx">Ver Datos Personales</asp:LinkButton>--%>
    <a href="/VerDatosPersonales.aspx">Ver Datos Personales</a>
</asp:Content>
