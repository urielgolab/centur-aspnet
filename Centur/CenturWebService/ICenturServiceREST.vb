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

    <OperationContract()>
<WebGet(UriTemplate:="/DetalleServicio?servicioID={servicioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function DetalleServicio(ByVal servicioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/ReservarTurno?servicioID={servicioID}&TurnoFecha={TurnoFecha}&TurnoHoraInicio={TurnoHoraInicio}&TurnoHoraFin={TurnoHoraFin}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function ReservarTurno(ByVal servicioID As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerTurnosServicioxDia?servicioID={servicioID}&TurnoFecha={TurnoFecha}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerTurnosServicioxDia(ByVal servicioID As Integer, ByVal TurnoFecha As Date) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/DetalleUsuario?nombreUsuario={nombreUsuario}", ResponseFormat:=WebMessageFormat.Json)> _
    Function DetalleUsuario(ByVal nombreUsuario As String) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/RegistrarUsuario?nombreUsuario={nombreUsuario}&password={password}&telefono={telefono}&rolUsuario={rolUsuario}&nombre={nombre}&apellido={apellido}&email={email}", ResponseFormat:=WebMessageFormat.Json)> _
    Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal password As String, ByVal telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String) As Stream

#Region "Favoritos"

    <OperationContract()>
<WebGet(UriTemplate:="/AltaFavoritos?servicioID={servicioID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function AltaFavoritos(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/BajaFavoritos?servicioID={servicioID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BajaFavoritos(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerFavoritos?usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerFavoritos(ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/EsFavorito?servicioID={servicioID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function EsFavorito(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream

#End Region



    <OperationContract()>
<WebGet(UriTemplate:="/Test?fecha={fecha}&hora={hora}&numero={numero}", ResponseFormat:=WebMessageFormat.Json)> _
    Function Test(ByVal fecha As Date, ByVal hora As String, ByVal numero As Integer) As Stream

End Interface
