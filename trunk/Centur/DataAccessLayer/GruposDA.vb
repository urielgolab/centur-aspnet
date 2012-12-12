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

End Class
