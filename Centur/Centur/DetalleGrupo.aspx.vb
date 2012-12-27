Imports Entities

Public Class DetalleGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        oGrupo = oGruposService.GetDetalleGrupo(CInt(Request.QueryString("id")))
        NombreGrupo.Text = oGrupo.Nombre
        DescripGrupo.Text = oGrupo.Descripcion

        ListBox1.DataSource = oGrupo.MiembrosList
        ListBox1.DataTextField = "NombreUsuario"
        ListBox1.DataValueField = "idUsuario"
        ListBox1.DataBind()

        'falta miembros implementar pablo

    End Sub

   
End Class