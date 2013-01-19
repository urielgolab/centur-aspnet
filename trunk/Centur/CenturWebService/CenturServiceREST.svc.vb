Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.IO
Imports Entities

' NOTE: You can use the "Rename" command on the context menu to change the class name "CenturServiceREST" in code, svc and config file together.
Public Class CenturServiceREST
    Implements ICenturServiceREST

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim oLoginService As New Services.LoginService
    Dim oFavoritosService As New Services.FavoritosService
    Dim oGruposService As New Services.GruposService
    Dim oTurnosService As New Services.TurnosService

#Region "BuscarServcio"
    Public Function BuscarServicio(Optional ByVal nombre As String = "", Optional ByVal categorias As String = "", Optional ByVal zonas As String = "", Optional ByVal precioDesde As Double = 0, Optional ByVal precioHasta As Double = 0, Optional ByVal usuarioID As Integer = 0) As Stream Implements ICenturServiceREST.BuscarServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        If precioHasta = 0 Then
            precioHasta = Double.MaxValue
        End If

        Dim servicios As ServicioList = oBuscarServicioService.BuscarServicio(nombre, categorias, zonas, precioDesde, precioHasta, usuarioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicios

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function DetalleServicio(ByVal servicioID As Integer, Optional ByVal usuarioID As Integer = 0) As Stream Implements ICenturServiceREST.DetalleServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim servicio As Servicio = oBuscarServicioService.VerDetalleServicio(servicioID, usuarioID)

        If servicio.Descripcion <> "" Then
            servicio.Descripcion = Regex.Replace(servicio.Descripcion, "<.*?>", "")
        End If

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicio

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function VerTurnosServicioxDia(ByVal servicioID As Integer, ByVal TurnoFecha As Date) As Stream Implements ICenturServiceREST.VerTurnosServicioxDia
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turnos As TurnoList = oBuscarServicioService.VerTurnosServicioxDia(servicioID, TurnoFecha, False)

        For Each oTurno As Turno In turnos
            oTurno.horaFin = oTurno.horaFin.Replace(".", ":")
            oTurno.horaInicio = oTurno.horaInicio.Replace(".", ":")
            'oTurno.Fecha = Format(oTurno.Fecha, "MM/dd/yyyy")
        Next

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turnos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


    Public Function ReservarTurno(ByVal servicioID As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal usuarioID As Integer, ByVal esProveedor As Boolean) As Stream Implements ICenturServiceREST.ReservarTurno
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turno As Turno = oBuscarServicioService.ReservarTurno(servicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, usuarioID, esProveedor, Mensaje, Status)

        turno.horaFin = turno.horaFin.Replace(".", ":")
        turno.horaInicio = turno.horaInicio.Replace(".", ":")

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turno

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0) As Stream Implements ICenturServiceREST.BuscarCategorias
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim categorias As CategoriaList = oBuscarServicioService.BuscarCategorias(accion, idCategoria, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = categorias

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function BuscarZonas(ByVal accion As String, Optional ByVal idZona As Integer = 0) As Stream Implements ICenturServiceREST.BuscarZonas
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim zonas As ZonaList = oBuscarServicioService.BuscarZonas(accion, idZona, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = zonas

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

#End Region

#Region "Login"
    Public Function DetalleUsuario(ByVal nombreUsuario As String) As Stream Implements ICenturServiceREST.DetalleUsuario
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim usuario As Usuario = oLoginService.GetUserInfo(nombreUsuario, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = usuario

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal telefono As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal accion As Char, Optional ByVal password As String = "", Optional ByVal rolUsuario As String = "") As Stream Implements ICenturServiceREST.RegistrarUsuario
        Dim Mensaje As String = ""
        Dim Status As Boolean

        If password = "" Then
            password = ""
        End If
        If rolUsuario = "" Then
            rolUsuario = ""
        End If

        Dim usuario As Usuario = oLoginService.RegistrarUsuario(NombreUsuario, password, telefono, rolUsuario, nombre, apellido, email, accion, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = usuario

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

#End Region

#Region "Favoritos"

    Public Function VerFavoritos(ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.VerFavoritos
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim servicios As ServicioList = oFavoritosService.GetFavoritos(usuarioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicios

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


    Public Function AltaFavoritos(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.AltaFavoritos
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim exito As Boolean = oFavoritosService.AltaFavoritos(usuarioID, servicioID, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


    Public Function BajaFavoritos(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.BajaFavoritos
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim exito As Boolean = oFavoritosService.BajaFavoritos(usuarioID, servicioID, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function EsFavorito(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.EsFavorito
        Dim Mensaje As String = ""
        Dim Status As Boolean

        'Dim YaEsFavorito As Boolean = oFavoritosService.esFavorito(usuarioID, servicioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = oFavoritosService.esFavorito(usuarioID, servicioID)

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

#End Region

#Region "Grupos"

    Function VerGrupos(ByVal usuarioID As Integer, ByVal accion As Char) As Stream Implements ICenturServiceREST.VerGrupos
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim grupos As GrupoList = oGruposService.GetGrupos(usuarioID, accion)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = grupos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


    Function VerDetalleGrupo(ByVal grupoID As Integer) As Stream Implements ICenturServiceREST.VerDetalleGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim grupo As Grupo = oGruposService.GetDetalleGrupo(grupoID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = grupo

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function ModificarGrupo(ByVal grupoID As Integer, ByVal nombre As String, ByVal descripcion As String) As Stream Implements ICenturServiceREST.ModificarGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim nuevoGrupo As New Grupo
        nuevoGrupo.ID = grupoID
        nuevoGrupo.Nombre = nombre
        nuevoGrupo.Descripcion = descripcion

        oGruposService.UpdateGrupo(nuevoGrupo)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function EliminarGrupo(ByVal grupoID As Integer) As Stream Implements ICenturServiceREST.EliminarGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.DeleteGrupo(grupoID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function CrearGrupo(ByVal nombre As String, ByVal descripcion As String, ByVal proveedorID As Integer) As Stream Implements ICenturServiceREST.CrearGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.RegistrarGrupo(nombre, descripcion, proveedorID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function VerSolicitudesPendientesAGrupo(ByVal proveedorID As Integer) As Stream Implements ICenturServiceREST.VerSolicitudesPendientesAGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim solicitudesPendientes As GrupoPendientesList = oGruposService.ObtenerPendientes(proveedorID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = solicitudesPendientes

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function AgregarUsuarioAGrupo(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.AgregarUsuarioAGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.AltaAGrupo(grupoID, usuarioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function EliminarUsuarioDeGrupo(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.EliminarUsuarioDeGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.BajaMiembroAGrupo(grupoID, usuarioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


    Function AltaAGrupoPendienteAprobacion(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.AltaAGrupoPendienteAprobacion
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.AltaAGrupoPendienteAprobacion(usuarioID, grupoID, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function BajaServicioAGrupo(ByVal grupoID As Integer, ByVal servicioID As Integer) As Stream Implements ICenturServiceREST.BajaServicioAGrupo
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.BajaServicioAGrupo(grupoID, servicioID, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = Nothing

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))

    End Function


    Function VerGruposAsociadosAServicio(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.VerGruposAsociadosAServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim grupos As GrupoList = oBuscarServicioService.VerGruposAsociadosAServicio(servicioID, usuarioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = grupos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


#End Region

#Region "Turnos"

    Function VerTurnosCliente(ByVal idUsuario As Integer, ByVal confirmado As Integer) As Stream Implements ICenturServiceREST.VerTurnosCliente
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim oTurnoList As TurnoList = oTurnosService.VerTurnosCliente(idUsuario, confirmado)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = oTurnoList

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function CancelarTurno(ByVal idTurno As Integer) As Stream Implements ICenturServiceREST.CancelarTurno
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oTurnosService.CancelarTurno(idTurno)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = oTurnoList

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Function AceptarTurno(ByVal idTurno As Integer) As Stream Implements ICenturServiceREST.AceptarTurno
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oTurnosService.AceptarTurno(idTurno)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        'result.Body = oTurnoList

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

#End Region



    Public Function Test(ByVal fecha As Date, ByVal hora As String, ByVal numero As Integer) As Stream Implements ICenturServiceREST.Test
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turnos As TurnoList = oBuscarServicioService.VerTurnosServicioxDia(numero, fecha, False)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turnos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(turnos)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function

    Public Function Test2(Optional ByVal doble As Double = 0) As Stream Implements ICenturServiceREST.Test2
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = doble

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.UTF8.GetBytes(strJSON))
    End Function


End Class
