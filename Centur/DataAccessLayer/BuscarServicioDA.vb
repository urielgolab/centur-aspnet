Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class BuscarServicioDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)
    Dim CmdText As String


    Public Function BuscarServicio(ByVal nombre As String, ByVal categorias As String, ByVal zonas As String) As DataSet
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@nombre", nombre), New SqlParameter("@categorias", categorias), New SqlParameter("@zonas", zonas)}

        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "BuscarServicio", params)
    End Function

    Public Function VerDetalleServicio(ByVal ServicioID As String) As DataSet
        Dim cmdtext As New System.Text.StringBuilder
        cmdtext.AppendLine("SELECT * FROM Servicio")
        cmdtext.AppendLine("WHERE IdServicio=" & ServicioID)
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())
    End Function

    Function ArmarArbolCategorias() As DataSet
        Throw New NotImplementedException
    End Function

End Class
