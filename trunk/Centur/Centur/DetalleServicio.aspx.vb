
Public Class DetalleServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    ' Dim usuarioID As Integer = CInt(Session("idUsuario"))
    Dim ServicioID As Integer
    Dim MinDate As Date = Date.Now.AddDays(-7)
    Dim MaxDate As Date = Date.Now.AddDays(7)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'DivPedirTurno.Visible = False
        ServicioID = CInt(Request.QueryString("ServicioID"))

        Dim servicio As Entities.Servicio = oBuscarServicioService.VerDetalleServicio(ServicioID)

        Me.NombreServicio.Text = servicio.Nombre
        Me.CategoriaServicio.Text = servicio.Categoria
        Me.ZonaServicio.Text = servicio.Zona

        Me.ImagenServicio.ImageUrl = "http://t3.gstatic.com/images?q=tbn:ANd9GcQ4zKwAP4L3k0GOQfqa-D9P85q0lfUHAdJD2vbbti-Efo7bsTru"
    End Sub

  
    Private Sub VerHorarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerHorarios.Click
        Dim selectedDate As Date = CType(txtDatePicker.Text.ToString, Date)
        oBuscarServicioService.VerTurnosServicioxDia(ServicioID, selectedDate)
    End Sub
End Class
