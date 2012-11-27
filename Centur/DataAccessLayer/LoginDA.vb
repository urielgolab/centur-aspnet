Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class LoginDA

    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function GetUserInfo(ByVal nombreUsuario As String, ByRef Mensaje As String, ByRef Status As Boolean) As DataSet
        'Devolver TODA la info del usuario en cuestion, incluida la contraseña.

        Dim cmdtext As New StringBuilder
        cmdtext.AppendLine("SELECT * FROM Usuario")
        cmdtext.AppendLine(" WHERE nombreUsuario= '" & nombreUsuario & "'")
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.Text, cmdtext.ToString())
    End Function


    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet
        'Registrar el usuario, primero chequear si el nombre de usuario ya existe, en dicho caso no registrarlo y devovler un mensaje (o flag) de error.
        'Caso contrario, registrarlo y devolver un mensaje (o flag) afirmativo

        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@nombreUsuario", NombreUsuario), New SqlParameter("@tipoUsuario", rolUsuario), New SqlParameter("@password", Password), New SqlParameter("@nombre", nombre), New SqlParameter("@apellido", apellido), New SqlParameter("@email", email), New SqlParameter("@telefono", Telefono), ParamMensaje, ParamStatus}
        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "RegistrarUsuario", params)

        Status = ParamStatus.Value
        If Status = True Then
            Mensaje = ParamMensaje.Value
        End If

        Return ds
    End Function


End Class
