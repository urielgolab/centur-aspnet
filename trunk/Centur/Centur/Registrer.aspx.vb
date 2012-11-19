
Public Class Registrer
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Private Sub Registrarse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Registrarse.Click

        Dim rolUsuario As String = CStr(TipoUsuario.SelectedValue)

        Dim RegistroExitoso As Boolean = oLoginService.RegistrarUsuario(Me.NombreUsuario.Text, Me.Password.Text, Me.Telefono.Text, rolUsuario)

        If RegistroExitoso Then
            'Cargar todas las propiedades del usuario en variable de sesion / variable global.
            'Mostrar mensaje de exito
            Response.Redirect("~/Home.aspx")
        Else
            'Mostrar mensaje de error.
            ErrorMessage.Text = "El Nombre de Usuario elegido está actualmente en uso."
        End If


    End Sub
End Class