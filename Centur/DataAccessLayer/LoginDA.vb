Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class LoginDA

    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function GetUserInfo(ByVal nombreUsuario As String, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet
        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@nombreUsuario", nombreUsuario), ParamMensaje, ParamStatus}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "UsuarioObtener", params)

        Status = ParamStatus.Value
        If Status = True Then
            Mensaje = ParamMensaje.Value
        End If

        Return ds
    End Function


    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal accion As Char, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet
        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@nombreUsuario", NombreUsuario), New SqlParameter("@tipoUsuario", rolUsuario), New SqlParameter("@password", Password), New SqlParameter("@nombre", nombre), New SqlParameter("@apellido", apellido), New SqlParameter("@email", email), New SqlParameter("@telefono", Telefono), ParamMensaje, ParamStatus}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "UsuarioRegistrar", params)

        Status = ParamStatus.Value
        If Status = True Then
            Mensaje = ParamMensaje.Value
        End If

        Return ds
    End Function


End Class
