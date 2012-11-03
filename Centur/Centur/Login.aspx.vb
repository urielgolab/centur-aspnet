Public Class Login1
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Protected Sub Entrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Entrar.Click

        'oLoginService.GetUserInfo(Me.NombreUsuario.Text)

        'Comprobar si el username y pass son correctas.
        Dim usuarioValido As Boolean
        If Me.NombreUsuario.Text.Length > 0 Then
            usuarioValido = True
        Else
            usuarioValido = False
        End If

        If usuarioValido Then
            'Cargar todas las propiedades del usuario en variable de sesion / variable global.
            Response.Redirect("~/Home.aspx")
        Else
            'Mostrar mensaje de error.
            ErrorMessage.Text = "El nombre de usuario y/o contraseña son inválidos."
        End If

    End Sub
End Class