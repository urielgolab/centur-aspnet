Imports Entities

Public Class Favoritos
    Inherits System.Web.UI.Page

    Dim oBuscarFavoritosService As New Services.FavoritosService()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oServicioList As New ServicioList

        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        oServicioList = oBuscarFavoritosService.GetFavoritos(CType(Session("Usuario"), Entities.Usuario).idUsuario)
        If oServicioList.Count > 0 Then
            GridResultadosFavoritos.DataSource = oServicioList
            GridResultadosFavoritos.DataBind()
        Else
            Label1.Visible = True
        End If

    End Sub


End Class