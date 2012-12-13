﻿
Public Class DetalleServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim oFavoritosService As New Services.FavoritosService()
    ' Dim usuarioID As Integer = CInt(Session("idUsuario"))
    Public Shared idServicio As Integer

    Dim MinDate As Date = Date.Now.AddDays(-7)
    Dim MaxDate As Date = Date.Now.AddDays(7)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'DivPedirTurno.Visible = False
        idServicio = CInt(Request.QueryString("ServicioID"))

        Dim servicio As Entities.Servicio = oBuscarServicioService.VerDetalleServicio(idServicio)

        Me.NombreServicio.Text = servicio.Nombre
        Me.CategoriaServicio.Text = servicio.Categoria
        Me.ZonaServicio.Text = servicio.Zona

        Me.ImagenServicio.ImageUrl = "http://t3.gstatic.com/images?q=tbn:ANd9GcQ4zKwAP4L3k0GOQfqa-D9P85q0lfUHAdJD2vbbti-Efo7bsTru"

        If oFavoritosService.esFavorito(Login1.idUsuarioGlobal, idServicio) Then
            Me.Favoritos.Text = "Quitar de Favoritos"
        Else

        End If

    End Sub

  
    Private Sub VerHorarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerHorarios.Click
        'Dim selectedDate As Date = CType(txtDatePicker.Text, Date)
        Dim selectedDate As Date = Date.Now
        HorariosxDia.DataSource = oBuscarServicioService.VerTurnosServicioxDia(idServicio, selectedDate)
        HorariosxDia.DataBind()
    End Sub

    Private Sub Favoritos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Favoritos.Click
        'llamar al service de Guido y mostrar un popup
        If Me.Favoritos.Text = "Agregar a Favoritos" Then
            If oFavoritosService.AltaFavoritos(Login1.idUsuarioGlobal, idServicio) Then
                Me.Mensaje.Text = "Agregado!!"
                Me.Favoritos.Text = "Quitar de Favoritos"
            End If
        Else
            If oFavoritosService.BajaFavoritos(Login1.idUsuarioGlobal, idServicio) Then
                Me.Mensaje.Text = "Eliminado!!"
                Me.Favoritos.Text = "Agregar a Favoritos"
            End If
        End If

    End Sub
End Class