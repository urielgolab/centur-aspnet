Imports Entities

Public Class EditarGrupo
    Inherits System.Web.UI.Page
    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim idGrupo As Integer = CInt(Request.QueryString("id"))

        oGrupo = oGruposService.GetDetalleGrupo(idGrupo)
        NombreGrupo.Text = oGrupo.Nombre
        DescripGrupo.Text = oGrupo.Descripcion

        If Not Page.IsPostBack Then
            If oGrupo.MiembrosList.Count > 0 Then
                GridMiembros.DataSource = oGrupo.MiembrosList
                GridMiembros.DataBind()
            Else
                miembros.Visible = False
                LabelNoMiembros.Visible = True
            End If
        End If

    End Sub

End Class