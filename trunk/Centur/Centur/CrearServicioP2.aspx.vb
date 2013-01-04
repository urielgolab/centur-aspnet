Imports Datos

Public Class CrearServicioP2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Response.Redirect("CrearServicioP3.aspx")
    End Sub
End Class