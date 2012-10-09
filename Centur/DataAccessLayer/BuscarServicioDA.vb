Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class BuscarServicioDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)
    Dim CmdText As String


    Public Function BuscarServicio(ByVal ServicioID As Integer) As DataSet
        Dim cmdtext As New System.Text.StringBuilder
        cmdtext.AppendLine("SELECT * FROM Servicio")
        cmdtext.AppendLine("WHERE ServicioID=" & ServicioID)
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())
    End Function

End Class
