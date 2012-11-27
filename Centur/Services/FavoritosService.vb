Imports Entities

Public Class FavoritosService

    Dim oFavoritosDA As New DataAccessLayer.FavoritosDA


    Public Function AltaFavoritos(ByVal idUsuario As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Boolean
        Return oFavoritosDA.AltaFavorito(idUsuario, idServicio, Mensaje, Status)
    End Function

    Public Function esFavorito(ByVal idUsuario As Integer, ByVal idServicio As Integer) As Boolean

        Dim ds As DataSet = oFavoritosDA.esFavorito(idUsuario, idServicio)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
