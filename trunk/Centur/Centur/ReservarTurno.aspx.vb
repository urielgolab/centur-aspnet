Public Class ReservarTurno
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim TurnoHoraInicio As String = CStr(Request.QueryString("horaInicio"))
        Dim TurnoHoraFin As String = CStr(Request.QueryString("horaFin"))
        Dim TurnoFecha As Date = CDate(CStr(Request.QueryString("fecha")))
        Dim ServicioID As Integer = CInt(Request.QueryString("servicioID"))
        Dim oTurno As Entities.Turno = oBuscarServicioService.ReservarTurno(ServicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, CType(Session("Usuario"), Entities.Usuario).idUsuario, Mensaje, Status)


        TurnoStatus.InnerText = "Reservado!! De " + oTurno.horaInicio + " a " + oTurno.horaFin


    End Sub

End Class