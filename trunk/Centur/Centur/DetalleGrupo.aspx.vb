Imports Entities

Public Class DetalleGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oGrupo As New Grupo
        oGrupo = oGruposService.GetDetalleGrupo(CInt(Request.QueryString("id")))
        NombreGrupo.Text = oGrupo.Nombre
        DescripGrupo.Text = oGrupo.Descripcion
        'falta miembros implementar pablo

    End Sub

End Class