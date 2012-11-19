Imports Entities

Public Class LoginService

    Dim oLoginDA As New DataAccessLayer.LoginDA()

    Public Function GetUserInfo(ByVal nombreUsuario As String) As Usuario
        Dim oUsuario As New Usuario
        Dim ds As DataSet = oLoginDA.GetUserInfo(nombreUsuario)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            oUsuario.idUsuario = dr("idUsuario")
            oUsuario.TipoUsuario = dr("tipoUsuario")
            oUsuario.Nombre = dr("nombre")
            oUsuario.Apellido = dr("apellido")
            oUsuario.NombreUsuario = dr("nombreUsuario")
            oUsuario.Contraseña = dr("password")
        End If

        Return oUsuario
    End Function



    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String) As Boolean

        Dim RegistroExitoso As Boolean = oLoginDA.RegistrarUsuario(NombreUsuario, Password, Telefono, rolUsuario, nombre, apellido, email)

        If RegistroExitoso Then
            Return True
        Else
            Return False
        End If

    End Function




End Class
