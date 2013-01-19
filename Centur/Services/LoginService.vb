Imports Entities

Public Class LoginService

    Dim oLoginDA As New DataAccessLayer.LoginDA()

    Public Function GetUserInfo(ByVal nombreUsuario As String, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Usuario

        Dim oUsuario As New Usuario
        Dim ds As DataSet = oLoginDA.GetUserInfo(nombreUsuario, Mensaje, Status)

        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            oUsuario.idUsuario = dr("idUsuario")
            oUsuario.TipoUsuario = dr("tipoUsuario")
            oUsuario.Nombre = dr("nombre")
            oUsuario.Apellido = dr("apellido")
            oUsuario.NombreUsuario = dr("nombreUsuario")
            oUsuario.Password = dr("password")
            oUsuario.Email = dr("email")
            oUsuario.Telefono = dr("telefono")
        End If

        Return oUsuario
    End Function



    Public Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal Password As String, ByVal Telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal accion As Char, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Usuario
        Dim oUsuario As New Usuario
        Dim ds As DataSet = oLoginDA.RegistrarUsuario(NombreUsuario, Password, Telefono, rolUsuario, nombre, apellido, email, accion, Mensaje, Status)

        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            oUsuario.idUsuario = dr("idUsuario")
            oUsuario.TipoUsuario = dr("tipoUsuario")
            oUsuario.Nombre = dr("nombre")
            oUsuario.Apellido = dr("apellido")
            oUsuario.NombreUsuario = dr("nombreUsuario")
            oUsuario.Password = dr("password")
            oUsuario.Email = dr("email")
            oUsuario.Telefono = dr("telefono")
        End If


        Return oUsuario
    End Function



End Class
