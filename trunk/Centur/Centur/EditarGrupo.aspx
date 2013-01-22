<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditarGrupo.aspx.vb" Inherits="Centur.EditarGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" language="javascript">
    $(function () {
        $ID("ButtonEditGrupo").button();
    });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<p align="left" class="tituloPrincipal" > Editar Grupo</p>
   
        <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="NombreGrupo" runat="server"></asp:TextBox> 
        <br />
         <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="DescripGrupo" runat="server"></asp:TextBox>
        <br />
        
        <div class="GrupoDetalleListas"> 
        <div class="GrupoDetalleServicios">
        <p class="busqueda">Servicios</p>
        <br />
        <div id="servicios" Runat="Server">
       <asp:GridView ID="GridServicios" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>

       <asp:BoundField DataField="Nombre" HeaderText="Nombre Servicio" SortExpression="Nombre"/>
       </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>
       <br />     
       
            <asp:Label ID="Label5" runat="server" Text="Seleccione servicios a eliminar"></asp:Label>
       
     
       </div>
   
   <asp:Label ID="labelNoServicios" runat="server" 
        Text="Usted no tiene servicios asociados a este grupo" Visible="False" 
                  ForeColor="#FF3300"></asp:Label>
        </div>
        <div class="GrupoDetalleMiembros"> 
        <p class="busqueda">Miembros</p>
        <br />
        <div id="miembros" Runat="Server">
       <asp:GridView ID="GridMiembros" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="idUsuario" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
           <AlternatingRowStyle BackColor="White" />
       <Columns>
       
       <asp:TemplateField HeaderText="Selecccione">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="CheckBox1"/>
            </ItemTemplate>
       </asp:TemplateField>

       <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre Usuario" SortExpression="NombreUsuario"/>
       </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>
       <br />     
       
            <asp:Label ID="Label3" runat="server" Text="Seleccione miembros a eliminar"></asp:Label>
       
       
       </div>
   
   <asp:Label ID="LabelNoMiembros" runat="server" 
        Text="Usted no tiene miembros asociados a este grupo" Visible="False" 
            ForeColor="#FF3300"></asp:Label>
            </div>
   </div>
       
    <div class="GrupoEditarLinks">
    <asp:Button ID="ButtonEditGrupo" runat="server" Text="Modificar"></asp:Button>
    </div>
    
 </asp:Content>
