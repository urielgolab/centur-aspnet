
Public Class Home
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.mensaje.InnerText = Login1.idUsuarioGlobal.ToString()
    End Sub
End Class