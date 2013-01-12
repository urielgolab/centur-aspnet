Public Class ReservarTurnoProveedor
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim TurnoHoraInicio As String = CStr(Request.QueryString("horaInicio"))
        Dim TurnoHoraFin As String = CStr(Request.QueryString("horaFin"))
        Dim TurnoFecha As Date = CDate(CStr(Request.QueryString("fecha")))
        Dim ServicioID As Integer = CInt(Request.QueryString("servicioID"))
        Dim UsuarioID As Integer = CInt(Request.QueryString("usuarioID"))

        Dim esProveedor As Boolean
        If CType(Session("Usuario"), Entities.Usuario).TipoUsuario = "P" Then
            esProveedor = True
        Else
            esProveedor = False
        End If

        Dim oTurno As Entities.Turno = oBuscarServicioService.ReservarTurno(ServicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, UsuarioID, esProveedor, Mensaje, Status)


        TurnoStatus.InnerText = "Reservado manualmente por el proveedor!! De " + oTurno.horaInicio + " a " + oTurno.horaFin

    End Sub

End Class