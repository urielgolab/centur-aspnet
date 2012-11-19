Public Class ReservarTurno
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TurnoHoraInicio As String = CStr(Request.QueryString("HoraInicio"))
        Dim TurnoHoraFin As String = CStr(Request.QueryString("HoraFin"))
        Dim oTurno As Entities.Turno = oBuscarServicioService.ReservarTurno(TurnoHoraInicio, TurnoHoraFin)

        TurnoStatus.InnerText = "Reservado!! De " + TurnoHoraInicio + " a " + TurnoHoraFin

    End Sub

End Class