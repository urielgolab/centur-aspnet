Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Function BuscarServicio(ByVal nombre As String, ByVal categoria As String, ByVal zona As String, Optional ByVal CalledFromWS As Boolean = False) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categoria, zona)

        Dim oServicioList As New ServicioList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oServicio As New Servicio
            oServicio.ID = CInt(dr("ID"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicioList.Add(oServicio)
        Next

        Return oServicioList
    End Function

    Public Function VerDetalleServicio(ByVal ServicioID As String) As Servicio
        Dim ds As DataSet = oBuscarServicioDA.VerDetalleServicio(ServicioID)
        Dim dr As DataRow = ds.Tables(0).Rows(0)

        Dim oServicio As New Servicio

        If ds.Tables(0).Rows.Count > 0 Then
            oServicio.ID = CInt(dr("ID"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            If Not IsDBNull(dr("Imagen")) Then
                oServicio.Imagen = CType((dr("Imagen")), Image)
            End If
        End If

        Return oServicio
    End Function

End Class
