Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Function BuscarServicio(ByVal nombre As String, ByVal categorias As String, ByVal zonas As String, Optional ByVal CalledFromWS As Boolean = False) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categorias, zonas)

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

    Public Function BuscarCategorias() As DataTable

        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("ParentID")
        dt.Columns.Add("Nombre")

        dt.Rows.Add(1, 0, "futbol")
        dt.Rows.Add(4, 0, "tenis")
        dt.Rows.Add(2, 1, "cesped")
        dt.Rows.Add(3, 1, "cemento")
        dt.Rows.Add(5, 4, "polvo")
        dt.Rows.Add(6, 4, "cesped")
        dt.Rows.Add(7, 4, "cemento")

        Return dt

    End Function

    Public Function BuscarZonas() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("ParentID")
        dt.Columns.Add("Nombre")

        dt.Rows.Add(1, 0, "Buenos Aires")
        dt.Rows.Add(2, 0, "Cordoba")
        dt.Rows.Add(3, 1, "Flores")
        dt.Rows.Add(4, 1, "Paternal")
        dt.Rows.Add(5, 2, "Carlos Paz")

        Return dt
    End Function

End Class
