﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="DetalleGrupo.aspx.vb" Inherits="Centur.DetalleGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1> Detalle grupo </h1>
    <p> 
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server"></asp:TextBox> 
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server"></asp:TextBox>
       <br />
        <asp:Label ID="Label3" runat="server" Text="Miembros"></asp:Label>
        <br />
        <asp:ListBox ID="ListBox1" runat="server">
            <asp:ListItem>Maxi</asp:ListItem>
            <asp:ListItem>Guido</asp:ListItem>
            <asp:ListItem>Manu</asp:ListItem>
        </asp:ListBox>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />

    </p>
    <asp:LinkButton ID="LinkButton1" runat="server">Modificar</asp:LinkButton>
    <asp:LinkButton ID="LinkButton2" runat="server">Eliminar</asp:LinkButton>

</asp:Content>

