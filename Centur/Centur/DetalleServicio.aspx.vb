﻿Imports Datos
Public Class DetalleServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim oFavoritosService As New Services.FavoritosService()

    'Public idServicio As Integer
    Public servicio As Entities.Servicio
    Dim dc As New DC()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        servicio = oBuscarServicioService.VerDetalleServicio(CInt(Request.QueryString("ServicioID")), CType(Session("Usuario"), Entities.Usuario).idUsuario)
        Dim oServicio As Servicio = dc.Servicios.Single(Function(x) x.idServicio = servicio.ID)

        Me.NombreServicio.Text = servicio.Nombre
        Me.CategoriaServicio.Text = dc.CategoriaObtenerPadre(oServicio.idCategoria)
        Me.DescripcionServicio.Text = servicio.Descripcion
        Me.ZonaServicio.Text = dc.ZonaObtenerPadre(oServicio.idZona)
        Me.DescripcionServicio.Text = servicio.Descripcion

        PrecioServicio.Visible = servicio.Precio > 0
        Me.PrecioServicio.Text = "$ " + servicio.Precio.ToString()

        Me.DireccionServicio.Text = servicio.Direccion
        Me.ProveedorServicio.Text = servicio.NombreUsuarioProveedor
        Me.EmailServicio.Text = servicio.Email
        Me.ObservacionesServicio.Text = servicio.Observaciones
        lblObservacionesServicio.Visible = servicio.Observaciones <> ""
        Me.TelefonoServicio.Text = servicio.Telefono
        Me.ImagenServicio.ImageUrl = "Images/publicaciones/" + servicio.Imagen

        If servicio.Imagen Is Nothing Then
            Me.ImagenServicio.Visible = False
        End If

        Dim gruposAsoc As Entities.GrupoList = oBuscarServicioService.VerGruposAsociadosAServicio(CInt(Request.QueryString("ServicioID")))

        If gruposAsoc.Count > 0 Then
            GruposAsociados.DataSource = gruposAsoc
            GruposAsociados.DataBind()
        End If

        If oFavoritosService.esFavorito(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
            Me.Favoritos.Attributes.Add("title", "Quitar de Favoritos")
            Favoritos.CssClass = "iconoFavorito favOn"
        Else
            Me.Favoritos.Attributes.Add("title", "Agregar a Favoritos")
            Favoritos.CssClass = "iconoFavorito favOff"
        End If

        If oBuscarServicioService.ClientePuedePedirTurno(servicio.ID, CType(Session("Usuario"), Entities.Usuario).idUsuario) Then
            DIVPedirTurno.Visible = True
            ErrorMessage.Visible = False
        Else
            ErrorMessage.Text = "<div class='ui-widget' style='margin: 10px;'>" &
                 "<div class='ui-state-highlight ui-corner-all' style='margin-top: 20px; padding: 0 .7em;'>" &
                     "<p><span class='ui-icon ui-icon-info' style='float: left; margin-right: .3em;'></span>" &
                         "<strong>Servicio privado: </strong>Debe pertenecer a un grupo de autorizados para pedir un turno</p>" &
                 "</div>" &
                "</div>"
            ErrorMessage.Visible = True
            DIVPedirTurno.Visible = False
            reservarTurno.Visible = False
        End If

        DIVPedirTurno.Visible = False

    End Sub

  
    Private Sub VerHorarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerHorarios.Click
        If Not txtDatePicker.Text = "" Then
            Dim selectedDate As Date = CDate(txtDatePicker.Text)
            Dim turnos As Entities.TurnoList = oBuscarServicioService.VerTurnosServicioxDia(servicio.ID, selectedDate, False)
            If turnos.Count > 0 Then
                HorariosxDia.DataSource = turnos
                HorariosxDia.DataBind()
                ErrorMessage.Visible = False
                'ltlAbrirGrillaHorarios.Text = "<script  type='text/javascript'>$(function () { $ID('DIVPedirTurno').dialog('open');});</script>"
                'ltlAbrirGrillaHorarios.Visible = True
            Else
                ErrorMessage.Text = "No hay turnos disponibles dicho día"
                ErrorMessage.Visible = True
            End If
        Else
            ErrorMessage.Text = "Seleccione una fecha válida"
            ErrorMessage.Visible = True
        End If
        DIVPedirTurno.Visible = True
    End Sub

    Private Sub Favoritos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Favoritos.Click
        'llamar al service de Guido y mostrar un popup
        If Me.Favoritos.Attributes("title") = "Agregar a Favoritos" Then
            If oFavoritosService.AltaFavoritos(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
                Me.Favoritos.Attributes.Add("title", "Quitar de Favoritos")
                Favoritos.CssClass = "iconoFavorito favOn"
            End If
        Else
            If oFavoritosService.BajaFavoritos(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
                Me.Favoritos.Attributes.Add("title", "Agregar a Favoritos")
                Favoritos.CssClass = "iconoFavorito favOff"
            End If
        End If
    End Sub

    'Private Sub PedirTurno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PedirTurno.Click
    '    If oBuscarServicioService.ClientePuedePedirTurno(servicio.ID, CType(Session("Usuario"), Entities.Usuario).idUsuario) Then
    '        DIVPedirTurno.Visible = True
    '        ErrorMessageExterno.Visible = False
    '    Else
    '        ErrorMessageExterno.Text = "Debe estar inscripto en al menos un grupo para pedir un turno a este servicio"
    '        ErrorMessageExterno.Visible = True
    '        DIVPedirTurno.Visible = False
    '    End If
    'End Sub
End Class
