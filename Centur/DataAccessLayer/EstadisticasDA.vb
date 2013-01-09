Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class EstadisticasDA

    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)


    Public Function CalcularEstadisticas(ByVal accion As Char, ByVal ServicioID As Integer, ByVal FechaDesde As   Date, ByVal FechaHasta As Date, ByVal HoraDesde As String, ByVal HoraHasta As String) As Integer
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@idServicio", ServicioID), New SqlParameter("@fechaDesde", FechaDesde), New SqlParameter("@fechaHasta", FechaHasta), New SqlParameter("@horaDesde", HoraDesde), New SqlParameter("@horaHasta", HoraHasta)}
        Return SqlHelper.ExecuteScalar(_dbConnectionString, CommandType.StoredProcedure, "EstadisticasBuscar", params)
    End Function


End Class