Imports Entities

Public Class MisGrupos
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Label3.Text = DropDownListGruposPropios.Text

    End Sub

    Private Sub MisGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oGrupoList As New GrupoList

        oGrupoList = oGruposService.GetGruposPropios(Login1.idUsuarioGlobal)
        If oGrupoList.Count > 0 Then
            If Not (Page.IsPostBack) Then
                DropDownListGruposPropios.DataSource = oGrupoList
                DropDownListGruposPropios.DataTextField = "Nombre"
                DropDownListGruposPropios.DataValueField = "ID"
                DropDownListGruposPropios.DataBind()
            End If
        End If
    End Sub
End Class
