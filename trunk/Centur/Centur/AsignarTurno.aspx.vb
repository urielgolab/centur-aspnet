Public Class AsignarTurno
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim UsuarioID As Integer
    Dim ServicioID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UsuarioID = CStr(Request.QueryString("UsuarioID"))
        ServicioID = CStr(Request.QueryString("ServicioID"))
    End Sub

    Private Sub VerHorarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerHorarios.Click
        Dim selectedDate As Date = CDate(txtDatePicker.Text)
        HorariosxDia.DataSource = oBuscarServicioService.VerTurnosServicioxDia(ServicioID, selectedDate, True, UsuarioID)
        HorariosxDia.DataBind()
    End Sub
End Class