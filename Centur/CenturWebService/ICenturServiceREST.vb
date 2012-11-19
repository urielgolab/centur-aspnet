Imports System.ServiceModel
Imports System.IO

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ICenturServiceREST" in both code and config file together.
<ServiceContract()>
Public Interface ICenturServiceREST


    <OperationContract()>
   <WebGet(UriTemplate:="/BuscarServicio?zona={zona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio(ByVal zona As String) As Stream

    <OperationContract()>
   <WebGet(UriTemplate:="/BuscarCategorias?accion={accion}&idCategoria={idCategoria}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0) As Stream

    <OperationContract()>
 <WebGet(UriTemplate:="/BuscarZonas?accion={accion}&idZona={idZona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarZonas(ByVal accion As String, Optional ByVal idZona As Integer = 0) As Stream

End Interface
