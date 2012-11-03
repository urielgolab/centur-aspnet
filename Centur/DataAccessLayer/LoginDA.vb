Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Public Class LoginDA

    Public Function GetUserInfo(ByVal nombreUsuario As String) As DataSet
        'Devolver TODA la info del usuario en cuestion.

    End Function


    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As Integer) As Boolean
        'Registrar el usuario, primero chequear si el nombre de usuario ya existe, en dicho caso no registrarlo y devovler un mensaje (o flag) de error.
        'Caso contrario, registrarlo y devolver un mensaje (o flag) afirmativo

        Return False
    End Function


End Class
