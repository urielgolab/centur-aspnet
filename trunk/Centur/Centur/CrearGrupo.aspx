﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="CrearGrupo.aspx.vb" Inherits="Centur.CrearGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
    <asp:LinkButton ID="LinkButton1" cssclass="GrupoCrearLinks" runat="server">Crear</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="Success" runat="server" Text="Grupo creado exitosamente" 
        Visible="False"></asp:Label>
</asp:Content>

