<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Home.aspx.vb" Inherits="Centur.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:TextBox runat="server" ID="nombre" />
        <asp:Button Text="Saludar" runat="server" onclick="Saludar_Click"/>
    </h2>
</asp:Content>
