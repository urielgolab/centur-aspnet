﻿Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.IO
Imports Entities

' NOTE: You can use the "Rename" command on the context menu to change the class name "CenturServiceREST" in code, svc and config file together.
Public Class CenturServiceREST
    Implements ICenturServiceREST

    Dim oBuscarServicioService As New Services.BuscarServicioService()

   
    Public Function BuscarServicio(ByVal zona As String) As Stream Implements ICenturServiceREST.BuscarServicio
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim servicios As ServicioList = oBuscarServicioService.BuscarServicio("", "", "2", True)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = servicios

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

    Public Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0) As Stream Implements ICenturServiceREST.BuscarCategorias
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim categorias As CategoriaList = oBuscarServicioService.BuscarCategorias(accion, Mensaje, Status, idCategoria)

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

        Dim zonas As ZonaList = oBuscarServicioService.BuscarZonas(accion, Mensaje, Status, idZona)

        Dim result As New JSONResult
        result.Estado = Status
        result.Mensaje = Mensaje
        result.Body = zonas

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(result)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

End Class
