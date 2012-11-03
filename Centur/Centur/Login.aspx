<%@ Page Title="Login" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="Login.aspx.vb" Inherits="Centur.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Login</h1>



    <div class="accountInfo">
        <fieldset  class="login">
            <legend>Información del Usuario</legend>
            <p>
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="NombreUsuario">Nombre de Usuario:</asp:Label>
                <asp:TextBox ID="NombreUsuario" runat="server" CssClass="textEntry"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator> --%>    
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
              <%--  <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:CheckBox ID="RememberMe" runat="server" />
                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Recordarme</asp:Label>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:LinkButton ID="Entrar" runat="server" Text="Entrar"  ValidationGroup="LoginUserValidationGroup" ></asp:LinkButton>
        </p>
        <p class="failureNotification">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            <%--<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>--%>
        </p>
    </div>



</asp:Content>
