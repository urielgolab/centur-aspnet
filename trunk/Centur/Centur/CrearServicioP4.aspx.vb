Imports Datos

Public Class CrearServicioP4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalizar.Click
        Response.Redirect("CrearServicioP2.aspx")
    End Sub
End Class