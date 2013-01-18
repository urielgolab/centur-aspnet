
Public Class DetalleServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()
    Dim oFavoritosService As New Services.FavoritosService()

    'Public idServicio As Integer
    Public servicio As Entities.Servicio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("Usuario") Is Nothing Then
        'Response.Redirect("ErrorPage.aspx")
        'Else

        'DivPedirTurno.Visible = False

        servicio = oBuscarServicioService.VerDetalleServicio(CInt(Request.QueryString("ServicioID")), CType(Session("Usuario"), Entities.Usuario).idUsuario)

        Me.NombreServicio.Text = servicio.Nombre
        Me.CategoriaServicio.Text = servicio.Categoria
        Me.DescripcionServicio.Text = servicio.Descripcion
        Me.ZonaServicio.Text = servicio.Zona
        Me.DescripcionServicio.Text = servicio.Descripcion
        Me.PrecioServicio.Text = servicio.Precio
        Me.DireccionServicio.Text = servicio.Direccion
        Me.ProveedorServicio.Text = servicio.NombreUsuarioProveedor
        Me.EmailServicio.Text = servicio.Email
        Me.ObservacionesServicio.Text = servicio.Observaciones
        Me.TelefonoServicio.Text = servicio.Telefono
        Me.ImagenServicio.ImageUrl = "Images/publicaciones/" + servicio.Imagen

        If servicio.Imagen Is Nothing Then
            Me.ImagenServicio.Visible = False
        End If

        GruposAsociados.DataSource = oBuscarServicioService.VerGruposAsociadosAServicio(CInt(Request.QueryString("ServicioID")))
        GruposAsociados.DataBind()


        If oFavoritosService.esFavorito(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
            Me.Favoritos.Text = "Quitar de Favoritos"
        Else
            Me.Favoritos.Text = "Agregar a Favoritos"
        End If

        'End If

    End Sub

  
    Private Sub VerHorarios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VerHorarios.Click
        Dim selectedDate As Date = CDate(txtDatePicker.Text)
        HorariosxDia.DataSource = oBuscarServicioService.VerTurnosServicioxDia(servicio.ID, selectedDate, False)
        HorariosxDia.DataBind()
    End Sub

    Private Sub Favoritos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Favoritos.Click
        'llamar al service de Guido y mostrar un popup
        If Me.Favoritos.Text = "Agregar a Favoritos" Then
            If oFavoritosService.AltaFavoritos(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
                Me.Mensaje.Text = "Agregado!!"
                Me.Favoritos.Text = "Quitar de Favoritos"
            End If
        Else
            If oFavoritosService.BajaFavoritos(CType(Session("Usuario"), Entities.Usuario).idUsuario, servicio.ID) Then
                Me.Mensaje.Text = "Eliminado!!"
                Me.Favoritos.Text = "Agregar a Favoritos"
            End If
        End If

    End Sub
End Class
