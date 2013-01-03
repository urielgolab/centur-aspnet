Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Text


Public Class GruposDA
    Private _dbConnectionString As String = CType(Configuration.ConfigurationSettings.AppSettings("CenturConnStr"), String)

    Public Function GetGrupos(ByVal id As Integer, ByVal accion As Char, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As DataSet

        'Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        'ParamStatus.Direction = ParameterDirection.Output
        'Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        'ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        If accion = "P" Then
            params = New SqlParameter() {New SqlParameter("@idProveedor", id)}
        Else
            params = New SqlParameter() {New SqlParameter("@idUsuario", id)}
        End If

        Dim ds As DataSet = SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoBuscarPor", params)

        'Status = ParamStatus.Value
        'Mensaje = ParamMensaje.Value

        Return ds
    End Function

    Public Function GetDetalleGrupo(ByVal GrupoId As Integer, ByVal Accion As Char) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", Accion), New SqlParameter("@idGrupo", GrupoId)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoObtenerDetalle", params)

    End Function

    Public Sub UpdateGrupo(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String)

        'Dim params() As SqlParameter
        'params = New SqlParameter() {New SqlParameter("@idGrupo", id), New SqlParameter("@nombre", nombre), New SqlParameter("@descripcion", descripcion)}
        'SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "UpdateGrupo", params)

    End Sub

    Public Sub DeleteGrupo(ByVal id As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)

        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idGrupo", id), New SqlParameter("@mensaje", Mensaje), New SqlParameter("@status", Status)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoBorrar", params)

        Status = ParamStatus.Value
        Mensaje = ParamMensaje.Value
    End Sub

    Public Sub RegistrarGrupo(ByVal nombreGrupo As String, ByVal DescripGrupo As String, ByVal idProveedor As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)

        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@tipoGrupo", "U"), New SqlParameter("@nombre", nombreGrupo), New SqlParameter("@descripcion", DescripGrupo), New SqlParameter("@idProveedor", idProveedor), New SqlParameter("@mensaje", Mensaje), New SqlParameter("@status", Status)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoRegistrar", params)

        Status = ParamStatus.Value
        Mensaje = ParamMensaje.Value

    End Sub

    Public Function PuedeAdherir(ByVal idUsuario As Integer, ByVal idGrupo As Integer) As DataSet
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@idGrupo", idGrupo)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoPuedeAdherir", params)
    End Function

    Public Sub AsociarUsuarioAGrupo(ByVal idUsuario As Integer, ByVal idGrupo As Integer, ByVal accion As String, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)
        Dim ParamStatus As New SqlParameter("@status", SqlDbType.Bit)
        ParamStatus.Direction = ParameterDirection.Output
        Dim ParamMensaje As New SqlParameter("@mensaje", SqlDbType.VarChar, 500)
        ParamMensaje.Direction = ParameterDirection.Output

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@accion", accion), New SqlParameter("@idGrupo", idGrupo), New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@mensaje", Mensaje), New SqlParameter("@status", Status)}
        SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoAsociarUsuario", params)

        Status = ParamStatus.Value
        Mensaje = ParamMensaje.Value

    End Sub

    Public Function esDueño(ByVal idUsuario As Integer, ByVal idGrupo As Integer) As DataSet
        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idUsuario", idUsuario), New SqlParameter("@idGrupo", idGrupo)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoEsDueño", params)
    End Function

    Public Function ObtenerPendientes(ByVal idProveedor As Integer) As DataSet

        Dim params() As SqlParameter
        params = New SqlParameter() {New SqlParameter("@idProveedor", idProveedor)}
        Return SqlHelper.ExecuteDataset(_dbConnectionString, CommandType.StoredProcedure, "GrupoObtenerPendientes", params)

    End Function

End Class
