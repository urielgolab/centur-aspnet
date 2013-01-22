﻿Imports Entities

Partial Class CrearGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCrear.Click

        Dim mensaje As String = ""
        Dim status As Boolean

        If NombreGrupo.Text = String.Empty Or DescripGrupo.Text = String.Empty Then
            MsgBox("Los campos solicitados no han sido completados en su totalidad", MsgBoxStyle.Critical, "Error")
            Return
        End If

        oGruposService.RegistrarGrupo(NombreGrupo.Text, DescripGrupo.Text, CType(Session("Usuario"), Entities.Usuario).idUsuario, mensaje, status)

        Success.Visible = True
        Response.AddHeader("REFRESH", "5;URL=MisGrupos.aspx")
        'Response.Redirect("~/MisGrupos.aspx")

    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If
    End Sub
End Class
