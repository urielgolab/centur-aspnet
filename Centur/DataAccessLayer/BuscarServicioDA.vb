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

    Public Function VerDetalleServicio(ByVal ServicioID As Integer) As DataSet
        Dim cmdtext As New System.Text.StringBuilder
        cmdtext.AppendLine("SELECT * FROM Servicio")
        cmdtext.AppendLine("WHERE IdServicio=" & ServicioID)
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())
    End Function

    Public Function VerTurnosServicioxDia(ByVal idServicio As Integer, ByVal fecha As Date) As DataSet
        'DEVOLVER TODOS LOS TURNOS (DISPONIBLES Y OCUPADOS) DE ESE DIA PARA ESE SERVICIO. UN FLAG DEBE INDICAR SI QUEDA AL MENOS UN LUGAR 
        'EN EL CASO QUE UN USUARIO PUEDA RESERVAR 1+ TURNO, EN ESTE SP SE DEBERIA DEVOLVER LA CANTIDAD DE LUGARES DISPONIBLES
    End Function

    Public Function ReservarServicio(ByVal idUsuario As Integer, ByVal idServicio As Integer) As DataSet
        'RESERVAR 1 (O MAS??) TURNO PARA DICHO USUARIO
    End Function

End Class
