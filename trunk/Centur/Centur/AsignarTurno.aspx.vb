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
        If Not txtDatePicker.Text = "" Then
            Dim selectedDate As Date = CDate(txtDatePicker.Text)
            Dim turnos As Entities.TurnoList = oBuscarServicioService.VerTurnosServicioxDia(ServicioID, selectedDate, True, UsuarioID)
            If turnos.Count > 0 Then
                HorariosxDia.DataSource = turnos
                HorariosxDia.DataBind()
                ErrorMessage.Visible = False
            Else
                ErrorMessage.Text = "No hay turnos disponibles dicho día"
                ErrorMessage.Visible = True
            End If
        Else
            ErrorMessage.Text = "Seleccione una fecha válida"
            ErrorMessage.Visible = True
        End If
    End Sub
End Class