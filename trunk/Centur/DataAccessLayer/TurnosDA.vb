Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text


Public Class TurnosDA

    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)
    Function verTurnosCliente(ByVal idUsuario As Integer, ByVal confirmado As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@confirmado", confirmado)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "TurnoObtener", params)


    End Function

    Sub TurnoAdministrar(ByVal idTurno As Integer, ByVal accion As String)

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@idTurno", idTurno)}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "TurnoAdministrar", params)
    End Sub

End Class
