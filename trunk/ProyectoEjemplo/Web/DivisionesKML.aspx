<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DivisionesKML.aspx.cs" Inherits="Web.DivisionesKML" MasterPageFile="~/moebiusWeb.Master" %>
<asp:Content ContentPlaceHolderID="cphPrincipal" ID="ABMGruposPH" runat="server">
<h1>Seleccione las divisiones a exportar</h1>
    <table>
    <tr>
        <td><asp:ListBox ID="lstDivisiones" runat="server" Height="650px" Width="300px" 
                DataTextField="Nombre" DataValueField="idDivision" 
                SelectionMode="Multiple" Font-Bold="False" Font-Names="Tahoma" 
                Font-Overline="False" Font-Size="Large"></asp:ListBox>
        </td>
        <td valign="middle">
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Obtener Divisiones</asp:LinkButton>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Debe seleccionar al menos una división" 
                ControlToValidate="lstDivisiones"></asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="chkGenerarTramos" runat="server" Text="Generar Tramos" />
        </td>
    </tr>            
    </table>
</asp:Content>