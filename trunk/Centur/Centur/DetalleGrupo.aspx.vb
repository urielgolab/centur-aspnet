Imports Entities

Public Class DetalleGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        oGrupo = oGruposService.GetDetalleGrupo(CInt(Request.QueryString("id")))
        NombreGrupo.Text = oGrupo.Nombre
        DescripGrupo.Text = oGrupo.Descripcion
        'falta miembros implementar pablo

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click

        oGrupo.ID = CInt(Request.QueryString("id"))
        oGrupo.Nombre = NombreGrupo.Text
        oGrupo.Descripcion = DescripGrupo.Text

        oGruposService.UpdateGrupo(oGrupo)

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        oGruposService.DeleteGrupo(CInt(Request.QueryString("id")))
    End Sub
End Class