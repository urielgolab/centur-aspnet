Imports Entities

Public Class FavoritosService

    Dim oFavoritosDA As New DataAccessLayer.FavoritosDA


    Public Function AltaFavoritos(ByVal idUsuario As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Boolean
        Return oFavoritosDA.AltaFavorito(idUsuario, idServicio, Mensaje, Status)
    End Function

    Public Function BajaFavoritos(ByVal idUsuario As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Boolean

        Return oFavoritosDA.bajaFavorito(idUsuario, idServicio, Mensaje, Status)

    End Function

    Public Function GetFavoritos(ByVal idUsuario As Integer) As ServicioList
        Dim ds As DataSet = oFavoritosDA.GetFavoritos(idUsuario)
        Dim oServicioList As New ServicioList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oServicio As New Servicio
            oServicio.ID = CInt(dr("IdServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicioList.Add(oServicio)
        Next

        Return oServicioList

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