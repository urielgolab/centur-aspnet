﻿Imports Entities

Public Class MisGrupos
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()

    Private Sub MisGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If CType(Session("Usuario"), Entities.Usuario).TipoUsuario.Equals("P") Then
            Me.GetGruposPropios()
        Else
            propios.Visible = False
        End If

        Me.GetGruposAdheridos()
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        Response.Redirect("~/DetalleGrupo.aspx?id=" & DropDownListGruposPropios.Text)
    End Sub

    Private Sub GetGruposPropios()

        Dim mensaje As String = ""
        Dim status As Boolean
        Dim oGrupoList As New GrupoList

        oGrupoList = oGruposService.GetGrupos(CType(Session("Usuario"), Entities.Usuario).idUsuario, "P", mensaje, status)
        If oGrupoList.Count > 0 Then
            If Not (Page.IsPostBack) Then
                DropDownListGruposPropios.DataSource = oGrupoList
                DropDownListGruposPropios.DataTextField = "Nombre"
                DropDownListGruposPropios.DataValueField = "ID"
                DropDownListGruposPropios.DataBind()
            End If
        End If

    End Sub

    Private Sub GetGruposAdheridos()

        Dim mensaje As String = ""
        Dim status As Boolean
        Dim oGrupoList As New GrupoList

        oGrupoList = oGruposService.GetGrupos(CType(Session("Usuario"), Entities.Usuario).idUsuario, "A", mensaje, status)
        If oGrupoList.Count > 0 Then
            If Not (Page.IsPostBack) Then
                DropDownListGruposAdheridos.DataSource = oGrupoList
                DropDownListGruposAdheridos.DataTextField = "Nombre"
                DropDownListGruposAdheridos.DataValueField = "ID"
                DropDownListGruposAdheridos.DataBind()
            End If
        End If

    End Sub

    Protected Sub CrearGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CrearGrupo.Click
        Response.Redirect("~/CrearGrupo.aspx")
    End Sub

    Protected Sub EliminarGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EliminarGrupo.Click
        oGruposService.DeleteGrupo(DropDownListGruposPropios.Text)
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton5.Click
        Response.Redirect("~/DetalleGrupo.aspx?id=" & DropDownListGruposAdheridos.Text)
    End Sub

End Class