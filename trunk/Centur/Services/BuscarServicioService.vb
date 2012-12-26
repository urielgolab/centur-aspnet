Imports Entities
Imports System.Net.Mime.MediaTypeNames

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New DataAccessLayer.BuscarServicioDA()

    Public Function BuscarServicio(ByVal nombre As String, ByVal categorias As String, ByVal zonas As String, ByVal precioDesde As Double, ByVal precioHasta As Double) As ServicioList
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(nombre, categorias, zonas, precioDesde, precioHasta)

        Dim oServicioList As New ServicioList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oServicio As New Servicio
            oServicio.ID = CInt(dr("IdServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            oServicio.Precio = CType(dr("precio"), Double)
            oServicio.MinOffset = CInt(dr("diasAntes"))
            oServicio.MaxOffset = CInt(dr("diasFuturo"))
            'oServicio.Direccion = CStr(dr("Observaciones"))
            '    oServicio.Observaciones = CStr(dr("Observaciones"))
            '    oServicio.IDProveedor = CInt(dr("IDProveedor"))
            '    oServicio.Privacidad = CBool(dr("Privacidad"))
            '    oServicio.Sobreturno = CBool(dr("Sobreturno"))
            '    oServicio.EnvioRecordatorio = CBool(dr("EnvioRecordatorio"))
            '    oServicio.TipoConfirmacion = CStr(dr("TipoConfirmacion"))

                oServicioList.Add(oServicio)
        Next

        Return oServicioList
    End Function


    Public Function VerDetalleServicio(ByVal ServicioID As Integer) As Servicio
        Dim ds As DataSet = oBuscarServicioDA.VerDetalleServicio(ServicioID)
        Dim oServicio As New Servicio

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            oServicio.ID = CInt(dr("idServicio"))
            oServicio.Nombre = CStr(dr("Nombre"))
            oServicio.Categoria = CStr(dr("Categoria"))
            oServicio.Zona = CStr(dr("Zona"))
            'If Not IsDBNull(dr("Foto")) Then
            '    oServicio.Imagen = CType((dr("Imagen")), Image)
            'End If
        End If

        Return oServicio
    End Function

    Public Function VerGruposAsociadosAServicio(ByVal ServicioID As Integer) As GrupoList
        Dim ds As DataSet = oBuscarServicioDA.VerGruposAsociadosAServicio(ServicioID)
        Dim oGrupoList As New GrupoList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oGrupo As New Grupo

            oGrupo.ID = CInt(dr("idGrupo"))
            oGrupo.Nombre = CStr(dr("Nombre"))
            oGrupo.Descripcion = CStr(dr("descripcion"))

            oGrupoList.Add(oGrupo)
        Next

        Return oGrupoList
    End Function


    Public Function ReservarTurno(ByVal idServicio As Integer, ByVal TurnoFecha As Date, ByVal TurnoHoraInicio As String, ByVal TurnoHoraFin As String, ByVal idUsuario As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False) As Turno
        Dim ds As DataSet = oBuscarServicioDA.ReservarTurno(idServicio, TurnoFecha, TurnoHoraInicio, TurnoHoraFin, idUsuario, Mensaje, Status)
        Dim oTurno As New Turno

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            oTurno.idTurno = dr("idTurno")
            oTurno.horaInicio = dr("horaInicio")
            oTurno.horaFin = dr("horaFin")
        End If

        Return oTurno
    End Function


    Public Function VerTurnosServicioxDia(ByVal idServicio As Integer, ByVal fecha As Date) As TurnoList
        Dim ds As DataSet = oBuscarServicioDA.VerTurnosServicioxDia(idServicio, fecha)

        Dim oTurnoList As New TurnoList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oTurno As New Turno
            oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.Disponible = dr("disponible")
            oTurno.Fecha = CStr(dr("fecha"))
            oTurno.ServicioID = CInt(dr("servicioID"))

            oTurnoList.Add(oTurno)
        Next

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

End Class
