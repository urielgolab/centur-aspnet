Imports System.ServiceModel
Imports System.IO

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ICenturServiceREST" in both code and config file together.
<ServiceContract()>
Public Interface ICenturServiceREST


    <OperationContract()>
    <WebGet(UriTemplate:="/BuscarServicio?zona={zona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio(ByVal zona As String) As String

    <OperationContract()>
   <WebGet(UriTemplate:="/BuscarServicio2?zona={zona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio2(ByVal zona As String) As Stream

End Interface
