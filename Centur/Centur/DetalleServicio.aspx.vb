
Public Class DetalleServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ServicioID As String = Request.QueryString("ServicioID")

        Dim servicio As Entities.Servicio = oBuscarServicioService.VerDetalleServicio(ServicioID)

        Me.nombre.Text = servicio.Nombre
        Me.categoria.Text = servicio.Categoria
        Me.zona.Text = servicio.Zona
        Me.imagen.ImageUrl = "http://t3.gstatic.com/images?q=tbn:ANd9GcQ4zKwAP4L3k0GOQfqa-D9P85q0lfUHAdJD2vbbti-Efo7bsTru"
    End Sub
End Class
