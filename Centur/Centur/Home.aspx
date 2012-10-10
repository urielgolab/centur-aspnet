<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Home.aspx.vb" Inherits="Centur.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <asp:TextBox runat="server" Width="200px" ID="soap" />
        <asp:Button Text="Ejecutar Servicio SOAP" runat="server" onclick="EjecutarSOAP_Click"/>
        <br />
        <asp:TextBox runat="server" Width="200px" ID="rest" />
        <asp:Button ID="Button1" Text="Ejecutar Servicio REST" runat="server" onclick="EjecutarREST_Click"/>
</asp:Content>
