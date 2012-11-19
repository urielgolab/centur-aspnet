<%@ Page Title="Registración de Usuarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master"
    CodeBehind="Registrer.aspx.vb" Inherits="Centur.Registrer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Registración</h1>

    <div class="accountInfo">
        <fieldset class="register">
            <legend>Registración </legend>
            <p>
                <asp:Label ID="UserNameLabel" runat="server">Nombre de Usuario:</asp:Label>
                <asp:TextBox ID="NombreUsuario" runat="server" CssClass="textEntry"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:Label ID="EmailLabel" runat="server">E-mail:</asp:Label>
                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                <%-- <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server">Contraseña:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <%--  <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:Label ID="ConfirmPasswordLabel" runat="server">Confirmar Contraseña:</asp:Label>
                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>--%>
            </p>
            <p>
                <asp:Label ID="Label1" runat="server">Telefono:</asp:Label>
                <asp:TextBox ID="Telefono" runat="server" CssClass="textEntry"></asp:TextBox>
                <%-- <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>--%>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server">Tipo de usuario:</asp:Label>
                <asp:RadioButtonList ID="TipoUsuario" runat="server" >
                    <asp:ListItem Text="Proveedor" Value="P" />
                    <asp:ListItem Text="Cliente" Value="C" />
                </asp:RadioButtonList>
            </p>
        </fieldset>
        
        <p class="submitButton">
            <asp:LinkButton ID="Registrarse" runat="server" Text="Registrarse" ValidationGroup="RegistrerUserValidationGroup"></asp:LinkButton>
        </p>
        <p class="failureNotification">
            <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            <%--<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>--%>
        </p>
    </div>
</asp:Content>
