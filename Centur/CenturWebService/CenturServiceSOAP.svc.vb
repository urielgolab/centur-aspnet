Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.IO


' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
Public Class CenturServiceSOAP
    Implements ICenturServiceSOAP

    Dim oBuscarServicioService As New Services.BuscarServicioService()


    <WebGet(UriTemplate:="/BuscarServicio?zona={zona}", ResponseFormat:=WebMessageFormat.Json)> _
    Public Function BuscarServicio(ByVal zona As String) As String Implements ICenturServiceSOAP.BuscarServicio
        Dim servicios As Entities.ServicioList = oBuscarServicioService.BuscarServicio("cancha", "deportes", "paternal", True)

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(servicios)
        Return strJSON
        'Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function


    Public Function BuscarServicio2(ByVal zona As String) As String Implements ICenturServiceSOAP.BuscarServicio2
        Dim servicios As Entities.ServicioList = oBuscarServicioService.BuscarServicio("cancha", "deportes", "paternal", True)

        Dim js As New JavaScriptSerializer()
        Dim strJSON As String = js.Serialize(servicios)
        Return strJSON
        'Return New MemoryStream(UTF8Encoding.Default.GetBytes(strJSON))
    End Function


End Class
