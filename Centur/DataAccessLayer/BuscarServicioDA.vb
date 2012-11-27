﻿Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class BuscarServicioDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)
    Dim CmdText As String


    Public Function BuscarServicio(ByVal nombre As String, ByVal categorias As String, ByVal zonas As String) As DataSet
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@nombre", nombre), New SqlParameter("@categorias", categorias), New SqlParameter("@zonas", zonas)}

        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BuscarServicio", params)
    End Function

    Public Function VerDetalleServicio(ByVal idServicio As Integer) As DataSet
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idServicio", idServicio)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BuscarServicio", params)

    End Function

    Public Function VerTurnosServicioxDia(ByVal idServicio As Integer, ByVal fecha As Date) As DataSet
        'DEVOLVER TODOS LOS TURNOS (DISPONIBLES Y OCUPADOS) DE ESE DIA PARA ESE SERVICIO. UN FLAG DEBE INDICAR SI QUEDA AL MENOS UN LUGAR 
        'EN EL CASO QUE UN USUARIO PUEDA RESERVAR 1+ TURNO, EN ESTE SP SE DEBERIA DEVOLVER LA CANTIDAD DE LUGARES DISPONIBLES --> UN USUARIO SOLO PUEDE RESERVAR DE UN TURNO A LA VEZ!!

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idServicio", idServicio), New SqlParameter("@fecha", fecha)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "ObtenerGrillaTurnos", params)
    End Function

    Public Function ReservarTurno(ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String) As DataSet
        'RESERVAR 1 TURNO PARA DICHO USUARIO

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@TurnoHoraInicio", TurnoHoraInicio), New SqlParameter("@TurnoHoraFin", TurnoHoraFin)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "ReservarTurno", params)
    End Function

    Public Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet
        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@idCategoria", idCategoria)}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BuscarCategoria", params)

        Status = ParamStatus.Value
        Mensaje = ParamMensaje.Value

        Return ds
    End Function


    Public Function BuscarZonas(ByVal accion As String, Optional ByVal idZona As Integer = 0, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet
        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@idZona", idZona)}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BuscarZona", params)

        Status = ParamStatus.Value
        Mensaje = ParamMensaje.Value

        Return ds
    End Function

End Class