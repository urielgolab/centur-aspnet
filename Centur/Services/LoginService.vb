Imports Entities

Public Class LoginService

    Dim oLoginDA As New DataAccessLayer.LoginDA()

    Public Function GetUserInfo(ByVal nombreUsuario As Integer) As Usuario
        Dim ds As DataSet = oLoginDA.GetUserInfo(nombreUsuario)

        Dim usuario As Usuario

        Return usuario
    End Function



    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As Integer) As Boolean

        Dim RegistroExitoso As Boolean = oLoginDA.RegistrarUsuario(NombreUsuario, Password, Telefono, rolUsuario)

        If RegistroExitoso Then
            Return True
        Else
            Return False
        End If

    End Function




End Class
