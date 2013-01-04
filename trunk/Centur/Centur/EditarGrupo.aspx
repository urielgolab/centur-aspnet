<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditarGrupo.aspx.vb" Inherits="Centur.EditarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1> Editar Grupo </h1>
     
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server"></asp:TextBox> 
        &nbsp;
        &nbsp;
        &nbsp;
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server"></asp:TextBox>
       <br />
       <br />
        <div id="miembros" Runat="Server" Visible="False">
        <asp:Label ID="LabelMiembros" runat="server" Text="Miembros"></asp:Label>
        <br />
       <asp:GridView ID="GridMiembros" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idUsuario">
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>

       <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" SortExpression="NombreUsuario"/>
       </Columns>
       </asp:GridView>
            
       
       <br />
       <br />
       </div>
   
   <asp:Label ID="LabelNoMiembros" runat="server" 
        Text="Usted no tiene miembros asociados a este grupo" Visible="False"></asp:Label>
        <br />
        <br />
    <asp:LinkButton ID="editGrupo" runat="server">Modificar</asp:LinkButton>
    
 </asp:Content>
