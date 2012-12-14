Imports Entities

Public Class MisGrupos
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()

    Private Sub MisGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim oGrupoList As New GrupoList

        If Login1.idUsuarioGlobal.Equals(0) Then
            Response.Redirect("~/Login.aspx")
        End If

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

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        Response.Redirect("~/DetalleGrupo.aspx?id=" & DropDownListGruposPropios.text)
    End Sub
End Class
