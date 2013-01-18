<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisServicios.aspx.vb" Inherits="Centur.MisServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        *
        {
            border:0;
            margin:0;
            padding:0;    
        }    
    </style>
    <script language="javascript">
        $(function () {
            $ID("btAgregarServicio  ").button();

            $(function () {
                $(document).tooltip({
                    position: {
                        my: "center bottom-20",
                        at: "center top",
                        using: function (position, feedback) {
                            $(this).css(position);
                            $("<div>")
            .addClass("arrow")
            .addClass(feedback.vertical)
            .addClass(feedback.horizontal)
            .appendTo(this);
                        }
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal">Mis Servicios</p>

    <div>
        <asp:GridView ID="grdServicios" runat="server" AutoGenerateColumns="False" 
            DataSourceID="linqServicios" CssClass="tbHorariosDia">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Servicio" ReadOnly="True" 
                    SortExpression="nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripcion" 
                    ReadOnly="True" SortExpression="descripcion" />
                <asp:TemplateField HeaderText="Categoria" 
                    SortExpression="Categoria.descripcion">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Categoria.descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idZona" HeaderText="idZona" ReadOnly="True" 
                    SortExpression="idZona" />
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <asp:Image runat="server" ImageUrl =<%# String.Format("~/Images/publicaciones/thumb_{0}",Eval("foto"))%>  Visible='<%# (Not Eval("foto")="") %>' style="max-width:100px" />
                        <%--<img src="Images/publicaciones/<%# Eval("foto") %>" alt="imagenServicio" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="true" HeaderText="Acciones">
                    <ItemTemplate>
                        <a href="CrearServicioP1.aspx?idServicio=<%# Eval("idServicio") %>"><img src="Images/Edit-icon.png" height="20" width="20" title="Editar servicio" alt="editar" /></a>
                        &nbsp;
                        <a href="MisServicios.aspx?idServicio=<%# Eval("idServicio") %>"><img src="Images/DeleteIcon.png" height="20" width="20" title="Eliminar servicio" alt="eliminar" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="linqServicios" runat="server" 
            ContextTypeName="Datos.DC" EntityTypeName="" 
            TableName="Servicios" Where="idProveedor == @idProveedor">
            <WhereParameters>
                <asp:SessionParameter Name="idProveedor" SessionField="Usuario" Type="Int32" DefaultValue="1" />
            </WhereParameters>
        </asp:LinqDataSource>
    </div>
    <br />
    <p>
        <asp:Button ID="btAgregarServicio" runat="server" Text="Agregar Servicio" />
    </p>
<br />


</asp:Content>

