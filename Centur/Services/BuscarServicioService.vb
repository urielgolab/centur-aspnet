Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Sub BuscarServicio(ByVal nombre As String, ByVal categoria As String, ByVal zona As String)
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categoria, zona)

        Dim oServicioList As New ServicioList
        Dim oServicio As New Servicio

        For Each dr As DataRow In ds.Tables(0).Rows
            oServicio.ID = CInt(dr("ID"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicio.Imagen = CType((dr("Imagen")), Image)
            oServicioList.Add(oServicio)
        Next

    End Sub

End Class
