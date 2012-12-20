Public Class ErrorPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing Then
            Me.ErrorDescr.InnerText = "La sesión ha expirado. Vuelva a iniciar sesión o regístrese"
        End If
    End Sub

End Class