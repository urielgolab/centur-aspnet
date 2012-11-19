Public Class Login1
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Protected Sub Entrar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Entrar.Click
        Dim usuarioValido As Boolean

        If Me.NombreUsuario.Text = "" Or Me.Password.Text = "" Then
            usuarioValido = False
        Else
            Dim oUsuario As New Entities.Usuario
            oUsuario = oLoginService.GetUserInfo(Me.NombreUsuario.Text)

            If oUsuario.Contraseña Is Nothing Then
                usuarioValido = False
            Else
                If Me.Password.Text = oUsuario.Contraseña Then
                    usuarioValido = True
                Else
                    usuarioValido = False
                End If
            End If
        End If

        If usuarioValido Then
            ' Cargar todas las propiedades del usuario en variable de sesion / variable global.
            ' Armar el menu de acuerdo a su perfil (cliente/proveedor)
            Response.Redirect("~/Home.aspx")
        Else
            'Mostrar mensaje de error.
            ErrorMessage.Text = "El nombre de usuario y/o contraseña son inválidos."
        End If

    End Sub
End Class