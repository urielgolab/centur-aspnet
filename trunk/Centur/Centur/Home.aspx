<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Home.aspx.vb" Inherits="Centur.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <h1>Welcome to Centur</h1>
      <h2 id="mensaje" runat="server"></h2>
      <img src="Images/logo.png" alt="centur" />
</asp:Content> 