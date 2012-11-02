Imports Entities

Public Class LoginService

    Dim oLoginDA As New DataAccessLayer.LoginDA()

    Public Function GetUserInfo(ByVal userID As Integer) As Usuario
        Dim ds As DataSet = oLoginDA.GetUserInfo(userID)

        Dim usuario As Usuario

        Return usuario
    End Function

End Class
