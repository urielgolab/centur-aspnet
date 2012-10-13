<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Web.CambiarPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Moebius</title>
    <link href="Default.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
    <br />
        <br />
        <br />
        <br />
       <table class="Panel">
       <tr>
       <td colspan="2" 
               style="background-color:DarkSlateBlue; color:White; font-weight: bold;" 
               align="center" height="50">Cambiar Password</td>
       </tr>
            <tr>
                <td align="left">
                    Usuario:</td>
                <td >
                    <asp:TextBox ID="txtUsuario" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Password Actual:
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Password Nueva:
                </td>
                <td>
                    <asp:TextBox ID="txtPasswordNueva" runat="server" TextMode="Password" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Repetir Password:
                </td>
                <td>
                    <asp:TextBox ID="txtRepetirPass" runat="server" TextMode="Password" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td >
        <asp:Button ID="btnEnviar" runat="server" Text="Cambiar" 
        Width="195px" CssClass="Button" onclick="btnEnviar_Click" />
        </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Msg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkVolver" runat="server" onclick="lnkVolver_Click">Volver al Login</asp:LinkButton>
                    </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
