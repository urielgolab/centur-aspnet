Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.IO

' NOTE: You can use the "Rename" command on the context menu to change the class name "CenturServiceREST" in code, svc and config file together.
Public Class CenturServiceREST
    Implements ICenturServiceREST

    Dim oBuscarServicioService As New Services.BuscarServicioService()

   
    Public Function BuscarServicio(ByVal zona As String) As String Implements ICenturServiceREST.BuscarServicio
        Dim servicios As Entities.ServicioList = oBuscarServicioService.BuscarServicio("cancha", "deportes", "paternal", True)

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(servicios)
        Return strJSON
    End Function

    Public Function BuscarServicio2(ByVal zona As String) As Stream Implements ICenturServiceREST.BuscarServicio2
        Dim servicios As Entities.ServicioList = oBuscarServicioService.BuscarServicio("cancha", "deportes", "paternal", True)

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(servicios)
        Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function

End Class
