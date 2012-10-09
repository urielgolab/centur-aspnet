
Public Class DetalleServicio
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ServicioID As String = Request.QueryString("ServicioID")
        Me.nombre.Text = ServicioID
        Me.direccion.Text = "Rivadavia 1000"
        Me.tel.Text = "4444-5555"
        Me.imagen.ImageUrl = "http://t3.gstatic.com/images?q=tbn:ANd9GcQ4zKwAP4L3k0GOQfqa-D9P85q0lfUHAdJD2vbbti-Efo7bsTru"
    End Sub
End Class
