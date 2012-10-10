<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeBehind="DetalleServicio.aspx.vb" Inherits="Centur.DetalleServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h1>
        Detalle Servicio
    </h1>
    <div>
        <label id="Label3"> 
            Nombre
        </label>
        <asp:TextBox runat="server" ID="nombre" Enabled="false" />
        <br />
        <label id="Label1">
            Categoria
        </label>
        <asp:TextBox runat="server" ID="categoria" Enabled="false" />
        <br />
        <label id="Label2">
            Zona
        </label>
        <asp:TextBox runat="server" ID="zona" Enabled="false" />
        <br />
        <br />
        <asp:Image runat="server" ID="imagen" />
    </div>
    <div>
           <asp:LinkButton ID="LinkButton1" PostBackUrl="~/BuscarServicio.aspx" runat="server"> Volver </asp:LinkButton>
    </div>
</asp:Content>
