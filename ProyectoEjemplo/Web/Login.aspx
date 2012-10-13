<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
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
               align="center" height="50">Sistema Moebius</td>
       </tr>
            <tr>
                <td align="right">
                    &nbsp;Usuario:</td>
                <td >
                    <asp:TextBox ID="txtUsuario" runat="server" Width="190px"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td align="right">
                    Password:
                </td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="190px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td >
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
        Width="195px" onclick= "btnIngresar_Click"  CssClass="Button" />
        </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="changePassword" runat="server" onclick="changePassword_Click">Cambiar Password</asp:LinkButton>
                    &nbsp;|&nbsp;
                    <asp:LinkButton ID="Olvido" runat="server" CausesValidation="false" OnClick="Olvido_Click"
                        Font-Size="Small">Olvide mi Password...</asp:LinkButton></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Msg" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                    </td>
            </tr>
        </table>
    </center>
    </div>
    </form>
</body>
</html>
