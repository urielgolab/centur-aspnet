Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Function BuscarServicio(ByVal nombre As String, ByVal categorias As String, ByVal zonas As String, ByVal precioDesde As Double, ByVal precioHasta As Double, ByVal usuarioID As Integer) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categorias, zonas, precioDesde, precioHasta, usuarioID)

        Dim oServicioList As New ServicioList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oServicio As New Servicio
            oServicio.ID = CInt(dr("IdServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            If Not IsDBNull(dr("foto")) Then
                oServicio.Imagen = CStr(dr("foto"))
            End If
            oServicio.Precio = CType(dr("precio"), Double)
            oServicio.EsFavorito = CBool(dr("esFavorito"))

            oServicioList.Add(oServicio)
        Next

        Return oServicioList
    End Function


    Public Function VerDetalleServicio(ByVal ServicioID As Integer, ByVal usuarioID As Integer) As Servicio
        Dim ds As DataSet = oBuscarServicioDA.VerDetalleServicio(ServicioID, usuarioID)
        Dim oServicio As New Servicio

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            oServicio.ID = CInt(dr("idServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicio.Descripcion = CStr(dr("Descripcion"))
            oServicio.EsFavorito = CBool(dr("esFavorito"))
            If Not IsDBNull(dr("direccion")) Then
                oServicio.Direccion = CStr(dr("direccion"))
            End If
            'If Not IsDBNull(dr("Observaciones")) Then
            '    oServicio.Observaciones = CStr(dr("Observaciones"))
            'End If
            If Not IsDBNull(dr("IDProveedor")) Then
                oServicio.IDProveedor = CInt(dr("IDProveedor"))
            End If
            If Not IsDBNull(dr("Privacidad")) Then
                oServicio.Privacidad = CBool(dr("Privacidad"))
            End If
            If Not IsDBNull(dr("Sobreturno")) Then
                oServicio.Sobreturno = CBool(dr("Sobreturno"))
            End If
            If Not IsDBNull(dr("EnvioRecordatorio")) Then
                oServicio.EnvioRecordatorio = CBool(dr("EnvioRecordatorio"))
            End If
            If Not IsDBNull(dr("necesitaConfirmacion")) Then
                oServicio.NecesitaConfirmacion = CBool(dr("necesitaConfirmacion"))
            End If
            If Not IsDBNull(dr("MercadoPago")) Then
                oServicio.MercadoPago = CBool(dr("MercadoPago"))
            End If
            oServicio.Telefono = CStr(dr("Telefono"))
            oServicio.Email = CStr(dr("Email"))
            oServicio.NombreUsuarioProveedor = CStr(dr("NombreUsuario"))
            If Not IsDBNull(dr("precio")) Then
                oServicio.Precio = CType(dr("precio"), Double)
            Else
                oServicio.Precio = 0
            End If
            oServicio.MinOffset = CInt(dr("diasAntes"))
            oServicio.MaxOffset = CInt(dr("diasFuturo"))
            If Not IsDBNull(dr("foto")) Then
                oServicio.Imagen = CStr(dr("foto"))
            End If
        End If

        Return oServicio
    End Function

    Public Function VerGruposAsociadosAServicio(ByVal ServicioID As Integer, Optional ByVal UsuarioID As Integer = 0) As GrupoList
        Dim oGrupoList As New GrupoList

        If UsuarioID = 0 Then
            Dim ds As DataSet = oBuscarServicioDA.VerGruposAsociadosAServicio(ServicioID)

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim oGrupo As New Grupo

                oGrupo.ID = CInt(dr("idGrupo"))
                oGrupo.Nombre = CStr(dr("Nombre"))
                oGrupo.Descripcion = CStr(dr("descripcion"))

                oGrupoList.Add(oGrupo)
            Next
        Else
            Dim ds As DataSet = oBuscarServicioDA.VerGruposAsociadosAServicioConUsuarios(ServicioID, UsuarioID)

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim oGrupo As New Grupo

                oGrupo.ID = CInt(dr("idGrupo"))
                oGrupo.Nombre = CStr(dr("Nombre"))
                oGrupo.Descripcion = CStr(dr("descripcion"))
                oGrupo.usuarioEstaEnGrupo = CBool(dr("EstaEnGrupo"))

                oGrupoList.Add(oGrupo)
            Next

        End If

        Return oGrupoList
    End Function


    Public Function ReservarTurno(ByVal idServicio As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal idUsuario As Integer, ByVal esProveedor As Boolean, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Turno

        Dim TurnoHoraInicioFix As String = TurnoHoraInicio.Replace(".", ":") + ":00"
        Dim TurnoHoraFinFix As String = TurnoHoraFin.Replace(".", ":") + ":00"

        Dim ds As DataSet = oBuscarServicioDA.ReservarTurno(idServicio, TurnoFecha, TurnoHoraInicioFix, TurnoHoraFinFix, idUsuario, esProveedor, Mensaje, Status)
        Dim oTurno As New Turno

        If Status = False Then
            If ds.Tables.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                oTurno.idTurno = dr("idTurno")
                oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
                oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
                oTurno.Fecha = dr("fecha")
            End If

            Return oTurno
        End If

    End Function


    Public Function VerTurnosServicioxDia(ByVal idServicio As Integer, ByVal fecha As Date, ByVal esProveedor As Boolean, Optional ByVal UsuarioID As Integer = 0) As TurnoList
        Dim ds As DataSet = oBuscarServicioDA.VerTurnosServicioxDia(idServicio, fecha)
        Dim oTurnoList As New TurnoList

        If esProveedor Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim oTurno As New Turno
                oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
                oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
                oTurno.Disponible = dr("disponible")
                oTurno.FechaMMDD = Format(dr("fecha"), "MM/dd/yyyy")
                oTurno.Fecha = CStr(dr("fecha"))
                oTurno.ServicioID = CInt(dr("servicioID"))
                oTurno.UsuarioID = UsuarioID

                oTurnoList.Add(oTurno)
            Next
        Else
            For Each dr As DataRow In ds.Tables(0).Rows
                If dr("disponible") Then
                    Dim oTurno As New Turno
                    oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
                    oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
                    oTurno.Disponible = dr("disponible")
                    oTurno.FechaMMDD = Format(dr("fecha"), "MM/dd/yyyy")
                    oTurno.Fecha = CStr(dr("fecha"))
                    oTurno.ServicioID = CInt(dr("servicioID"))

                    oTurnoList.Add(oTurno)
                End If
            Next
        End If



        Return oTurnoList


    End Function

    Public Function BuscarCategorias(ByVal accion As String, Optional ByVal idCategoria As Integer = 0, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As CategoriaList
        Dim ds As DataSet = oBuscarServicioDA.BuscarCategorias(accion, idCategoria, Mensaje, Status)
        Dim oCategoriaList As New CategoriaList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oCategoria As New Categoria
            oCategoria.IDCategoria = CInt(dr("idCategoria"))
            oCategoria.NombreCategoria = CStr(dr("descripcion"))
            oCategoria.TieneHijos = CBool(dr("TieneHijos"))

            oCategoriaList.Add(oCategoria)
        Next

        Return oCategoriaList
    End Function

    Public Function BuscarZonas(ByVal accion As String, Optional ByVal idZona As Integer = 0, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As ZonaList
        Dim ds As DataSet = oBuscarServicioDA.BuscarZonas(accion, idZona, Mensaje, Status)
        Dim oZonaList As New ZonaList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oZona As New Zona
            oZona.IDZona = CInt(dr("idZona"))
            oZona.NombreZona = CStr(dr("descripcion"))
            oZona.TieneHijos = CBool(dr("TieneHijos"))

            oZonaList.Add(oZona)
        Next

        Return oZonaList
    End Function
    Public Function VerServiciosDeProveedor(ByVal idProveedor As Integer) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.VerServiciosDeProveedor(idProveedor)

        Dim oServicioList As New ServicioList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oServicio As New Servicio
            oServicio.ID = CInt(dr("IdServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicio.Precio = CType(dr("precio"), Double)

            oServicioList.Add(oServicio)
        Next

        Return oServicioList
    End Function

    Function esDueño(ByVal idServicio As Integer, ByVal idProveedor As Integer) As Boolean
        Dim ds As DataSet = oBuscarServicioDA.EsDueño(idServicio, idProveedor)

        Return ds.Tables(0).Rows.Count > 0

    End Function


    Public Function ClientePuedePedirTurno(ByVal idServicio As Integer, ByVal idUsuario As Integer) As Boolean

        Dim ds As DataSet = oBuscarServicioDA.ClientePuedePedirTurno(idServicio, idUsuario)
        Dim oServicio As New Servicio

        If ds.Tables.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Return CBool(dr("estaEnServicio"))
        End If

    End Function


End Class
