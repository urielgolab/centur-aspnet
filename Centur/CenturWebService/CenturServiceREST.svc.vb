﻿Imports System.Web.Script.Serialization
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

   
    Public Function BuscarServicio(Optional ByVal nombre As String = "", Optional ByVal categorias As String = "", Optional ByVal zonas As String = "", Optional ByVal precioDesde As Double = 0, Optional ByVal precioHasta As Double = 0) As Stream Implements ICenturServiceREST.BuscarServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim servicios As ServicioList = oBuscarServicioService.BuscarServicio(nombre, categorias, zonas, precioDesde, precioHasta)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicios

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

    Public Function DetalleServicio(ByVal servicioID As Integer) As Stream Implements ICenturServiceREST.DetalleServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim servicio As Servicio = oBuscarServicioService.VerDetalleServicio(servicioID)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicio

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

    Public Function VerTurnosServicioxDia(ByVal servicioID As Integer, ByVal TurnoFecha As Date) As Stream Implements ICenturServiceREST.VerTurnosServicioxDia
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turnos As TurnoList = oBuscarServicioService.VerTurnosServicioxDia(servicioID, TurnoFecha)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turnos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(turnos)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function


    Public Function ReservarTurno(ByVal servicioID As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal usuarioID As Integer) As Stream Implements ICenturServiceREST.ReservarTurno
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turno As Turno = oBuscarServicioService.ReservarTurno(servicioID, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, usuarioID, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turno

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

    Public Function DetalleUsuario(ByVal nombreUsuario As String) As Stream Implements ICenturServiceREST.DetalleUsuario
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim usuario As Usuario = oLoginService.GetUserInfo(nombreUsuario)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = usuario

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal password As String, ByVal telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String) As Stream Implements ICenturServiceREST.RegistrarUsuario
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim usuario As Usuario = oLoginService.RegistrarUsuario(NombreUsuario, Password, Telefono, rolUsuario, nombre, apellido, email, Mensaje, Status)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = usuario

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function



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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
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
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

#End Region


    Public Function Test(ByVal fecha As Date, ByVal hora As String, ByVal numero As Integer) As Stream Implements ICenturServiceREST.Test
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim turnos As TurnoList = oBuscarServicioService.VerTurnosServicioxDia(numero, fecha)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = turnos

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(turnos)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function



End Class
