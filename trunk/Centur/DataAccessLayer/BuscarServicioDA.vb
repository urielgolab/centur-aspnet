Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class BuscarServicioDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)
    Dim CmdText As String


    Public Function BuscarServicio(ByVal nombre As String, ByVal categoria As String, ByVal zona As String)
        Dim cmdtext As New System.Text.StringBuilder
        cmdtext.AppendLine("SELECT * FROM Servicio")
        cmdtext.AppendLine("WHERE nombre='" & nombre & "'")
        cmdtext.AppendLine(" OR categoria='" & categoria & "'")
        cmdtext.AppendLine(" OR zona='" & zona & "'")
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())
    End Function

End Class
