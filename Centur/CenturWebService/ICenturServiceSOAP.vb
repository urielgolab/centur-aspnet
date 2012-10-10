Imports System.IO

' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
<ServiceContract()>
Public Interface ICenturServiceSOAP

    '<OperationContract()>
    'Function GetData(ByVal value As Integer) As String

    '<OperationContract()>
    'Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

    <OperationContract()>
    <WebGet(UriTemplate:="/BuscarServicio?zona={zona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio(ByVal zona As String) As String

    <OperationContract()>
    Function BuscarServicio2(ByVal zona As String) As String


End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.

<DataContract()>
Public Class CompositeType

    <DataMember()>
    Public Property BoolValue() As Boolean

    <DataMember()>
    Public Property StringValue() As String

End Class
