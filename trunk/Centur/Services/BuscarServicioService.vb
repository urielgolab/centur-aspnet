Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Function BuscarServicio(ByVal nombre As String, ByVal categoria As String, ByVal zona As String) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categoria, zona)

        Dim oServicioList As New ServicioList
        Dim oServicio As New Servicio

        For Each dr As DataRow In ds.Tables(0).Rows
            oServicio.ID = CInt(dr("ID"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            If Not IsDBNull(dr("Imagen")) Then
                oServicio.Imagen = CType((dr("Imagen")), Image)
            End If
            oServicioList.Add(oServicio)
        Next

        Return oServicioList
    End Function

End Class
