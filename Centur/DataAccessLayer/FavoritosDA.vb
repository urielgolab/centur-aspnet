Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text

Public Class FavoritosDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function AltaFavorito(ByVal idUsuario As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Boolean

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@idServicio", idServicio)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "AltaFavorito", params)

        Return True 'cambiar mas adelante

    End Function

    Public Function bajaFavorito(ByVal idUsuario As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Boolean
        Dim params() As SqlParameter

        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@idServicio", idServicio)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BajaFavorito", params)
        Return True 'cambiar mas adelante tambien

    End Function

    Public Function GetFavoritos(ByVal idUsuario As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GetFavoritos", params)

    End Function

    Public Function esFavorito(ByVal idUsuario As Integer, ByVal idServicio As Integer) As DataSet

        Dim cmdtext As New StringBuilder
        cmdtext.AppendLine("SELECT 1 FROM ServicioFavoritos")
        cmdtext.AppendLine(" WHERE idUsuario=" & idUsuario & " and idServicio=" & idServicio)
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())

    End Function

End Class
