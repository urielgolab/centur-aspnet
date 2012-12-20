Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text


Public Class GruposDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function GetGruposPropios(ByVal idUsuario As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GetGruposPropios", params)

    End Function

    Function GetDetalleGrupo(ByVal GrupoId As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idGrupo", GrupoId)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GetDetalleGrupo", params)

    End Function

    Public Sub UpdateGrupo(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String)

        'Dim params() As SqlParameter
        'params = New SqlParameter() {New SqlParameter("@idGrupo", id), New SqlParameter("@nombre", nombre), New SqlParameter("@descripcion", descripcion)}
        'SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "UpdateGrupo", params)

    End Sub

    Sub DeleteGrupo(ByVal id As Integer)
        'Dim params() As SqlParameter
        'params = New SqlParameter() {New SqlParameter("@idGrupo", GrupoId)}
        'SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "DeleteGrupo", params)
    End Sub

End Class
