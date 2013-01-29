
Public Class [Default]
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Usuario") Is Nothing Then
            Dim user As Entities.Usuario = Session("Usuario")
            Me.mensaje.InnerText = "¡Hola " + user.NombreUsuario + "!"
        End If

    End Sub
End Class