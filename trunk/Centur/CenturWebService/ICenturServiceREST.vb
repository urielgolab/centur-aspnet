Imports System.ServiceModel
Imports System.IO

' NOTE: You can use the "Rename" command on the context menu to change the interface name "ICenturServiceREST" in both code and config file together.
<ServiceContract()>
Public Interface ICenturServiceREST

#Region "BuscarServicio"

    <OperationContract()>
   <WebGet(UriTemplate:="/BuscarServicio?nombre={nombre}&categorias={categorias}&zonas={zonas}&precioDesde={precioDesde}&precioHasta={precioHasta}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarServicio(Optional ByVal nombre As String = "", Optional ByVal categorias As String = "", Optional ByVal zonas As String = "", Optional ByVal precioDesde As Double = 0, Optional ByVal precioHasta As Double = 0, Optional ByVal usuarioID As Integer = 0) As Stream

    <OperationContract()>
   <WebGet(UriTemplate:="/BuscarCategorias?accion={accion}&idCategoria={idCategoria}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0) As Stream

    <OperationContract()>
 <WebGet(UriTemplate:="/BuscarZonas?accion={accion}&idZona={idZona}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BuscarZonas(ByVal accion As String, Optional ByVal idZona As Integer = 0) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/DetalleServicio?servicioID={servicioID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function DetalleServicio(ByVal servicioID As Integer, Optional ByVal usuarioID As Integer = 0) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/ReservarTurno?servicioID={servicioID}&TurnoFecha={TurnoFecha}&TurnoHoraInicio={TurnoHoraInicio}&TurnoHoraFin={TurnoHoraFin}&usuarioID={usuarioID}&esProveedor={esProveedor}", ResponseFormat:=WebMessageFormat.Json)> _
    Function ReservarTurno(ByVal servicioID As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal usuarioID As Integer, ByVal esProveedor As Boolean) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerTurnosServicioxDia?servicioID={servicioID}&TurnoFecha={TurnoFecha}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerTurnosServicioxDia(ByVal servicioID As Integer, ByVal TurnoFecha As Date) As Stream
#End Region

#Region "Login"

    <OperationContract()>
<WebGet(UriTemplate:="/DetalleUsuario?nombreUsuario={nombreUsuario}", ResponseFormat:=WebMessageFormat.Json)> _
    Function DetalleUsuario(ByVal nombreUsuario As String) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/RegistrarUsuario?nombreUsuario={nombreUsuario}&telefono={telefono}&rolUsuario={rolUsuario}&nombre={nombre}&apellido={apellido}&email={email}&accion={accion}&password={password}", ResponseFormat:=WebMessageFormat.Json)> _
    Function RegistrarUsuario(ByVal NombreUsuario As String, ByVal telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String, ByVal accion As Char, Optional ByVal password As String = "") As Stream

#End Region

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

#Region "Grupos"

    <OperationContract()>
<WebGet(UriTemplate:="/VerGrupos?usuarioID={usuarioID}&accion={accion}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerGrupos(ByVal usuarioID As Integer, ByVal accion As Char) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerDetalleGrupo?grupoID={grupoID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerDetalleGrupo(ByVal grupoID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/ModificarGrupo?grupoID={grupoID}&nombre={nombre}&descripcion={descripcion}", ResponseFormat:=WebMessageFormat.Json)> _
    Function ModificarGrupo(ByVal grupoID As Integer, ByVal nombre As String, ByVal descripcion As String) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/EliminarGrupo?grupoID={grupoID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function EliminarGrupo(ByVal grupoID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/CrearGrupo?nombre={nombre}&descripcion={descripcion}&proveedorID={proveedorID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function CrearGrupo(ByVal nombre As String, ByVal descripcion As String, ByVal proveedorID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerSolicitudesPendientesAGrupo?proveedorID={proveedorID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerSolicitudesPendientesAGrupo(ByVal proveedorID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/AgregarUsuarioAGrupo?grupoID={grupoID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function AgregarUsuarioAGrupo(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/EliminarUsuarioDeGrupo?grupoID={grupoID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function EliminarUsuarioDeGrupo(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/AltaAGrupoPendienteAprobacion?grupoID={grupoID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function AltaAGrupoPendienteAprobacion(ByVal grupoID As Integer, ByVal usuarioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/BajaServicioAGrupo?grupoID={grupoID}&servicioID={servicioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function BajaServicioAGrupo(ByVal grupoID As Integer, ByVal servicioID As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/VerGruposAsociadosAServicio?servicioID={servicioID}&usuarioID={usuarioID}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerGruposAsociadosAServicio(ByVal servicioID As Integer, ByVal usuarioID As Integer) As Stream



#End Region

#Region "Turnos"

    <OperationContract()>
<WebGet(UriTemplate:="/VerTurnosCliente?idUsuario={idUsuario}&confirmado={confirmado}", ResponseFormat:=WebMessageFormat.Json)> _
    Function VerTurnosCliente(ByVal idUsuario As Integer, ByVal confirmado As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/CancelarTurno?idTurno={idTurno}", ResponseFormat:=WebMessageFormat.Json)> _
    Function CancelarTurno(ByVal idTurno As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/AceptarTurno?idTurno={idTurno}", ResponseFormat:=WebMessageFormat.Json)> _
    Function AceptarTurno(ByVal idTurno As Integer) As Stream


#End Region

    <OperationContract()>
<WebGet(UriTemplate:="/Test?fecha={fecha}&hora={hora}&numero={numero}", ResponseFormat:=WebMessageFormat.Json)> _
    Function Test(ByVal fecha As Date, ByVal hora As String, ByVal numero As Integer) As Stream

    <OperationContract()>
<WebGet(UriTemplate:="/Test2?doble={doble}", ResponseFormat:=WebMessageFormat.Json)> _
    Function Test2(Optional ByVal doble As Double = 0) As Stream

End Interface
