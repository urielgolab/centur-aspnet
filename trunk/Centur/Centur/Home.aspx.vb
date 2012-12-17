
Public Class Home
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Usuario") Is Nothing Then
            Dim user As Entities.Usuario = Session("Usuario")
            Me.mensaje.InnerText = user.NombreUsuario + " | Tipo de usuario: " + user.TipoUsuario
        End If

    End Sub
End Class