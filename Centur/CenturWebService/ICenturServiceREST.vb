Imports System.ServiceModel

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ICenturServiceREST" in both code and config file together.
<ServiceContract()>
Public Interface ICenturServiceREST

    '<WebGet()>

    <OperationContract()>
    <WebGet(UriTemplate:="/BuscarServicio?zona={zona}", BodyStyle:=WebMessageBodyStyle.Bare, ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio(ByVal zona As String) As String

End Interface
