Public Class AdministrarTurnos
    Inherits System.Web.UI.Page
    Dim oBuscarServicioService As New Services.BuscarServicioService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))

        If Not oBuscarServicioService.esDueño(idServicio, CType(Session("Usuario"), Entities.Usuario).idUsuario) Then
            Response.Redirect("~/MisTurnos.aspx")
            Return
        End If
    End Sub

End Class