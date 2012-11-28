Public Class ReservarTurno
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim TurnoHoraInicio As String = CStr(Request.QueryString("horaInicio"))
        Dim TurnoHoraFin As String = CStr(Request.QueryString("horaFin"))
        Dim oTurno As Entities.Turno = oBuscarServicioService.ReservarTurno(DetalleServicio.idServicio, TurnoHoraInicio, TurnoHoraFin, Login1.idUsuarioGlobal, Mensaje, Status)


        TurnoStatus.InnerText = "Reservado!! De " + oTurno.horaInicio + " a " + oTurno.horaFin

    End Sub

End Class