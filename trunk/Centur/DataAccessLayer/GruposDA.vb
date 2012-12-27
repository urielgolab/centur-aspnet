﻿Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text


Public Class GruposDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function GetGruposPropios(ByVal idUsuario As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idProveedor", idUsuario), New SqlParameter("@mensaje", "NULL"), New SqlParameter("@status", "")}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoBuscarPor", params)

    End Function

    Function GetDetalleGrupo(ByVal GrupoId As Integer, ByVal Accion As Char) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", Accion), New SqlParameter("@idGrupo", GrupoId)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoObtenerDetalle", params)

    End Function

    Public Sub UpdateGrupo(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String)

        'Dim params() As SqlParameter
        'params = New SqlParameter() {New SqlParameter("@idGrupo", id), New SqlParameter("@nombre", nombre), New SqlParameter("@descripcion", descripcion)}
        'SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "UpdateGrupo", params)

    End Sub

    Sub DeleteGrupo(ByVal id As Integer)
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idGrupo", id)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "DeleteGrupo", params)
    End Sub

    Sub AltaGrupo(ByVal nombreGrupo As String, ByVal DescripGrupo As String, ByVal idProveedor As Integer)
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@tipoGrupo", "U"), New SqlParameter("@nombre", nombreGrupo), New SqlParameter("@descripcion", DescripGrupo), New SqlParameter("@idProveedor", idProveedor), New SqlParameter("@mensaje", "NULL"), New SqlParameter("@status", "")}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoRegistrar", params)
    End Sub

End Class
