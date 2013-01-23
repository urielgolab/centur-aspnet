Imports Entities

Public Class DetalleGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo
    Dim oMaqueteado As New Maqueteado

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim idGrupo As Integer = CInt(Request.QueryString("id"))

        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        oGrupo = oGruposService.GetDetalleGrupo(idGrupo)
        LabelNombreGrupo.Text = oGrupo.Nombre
        LabelDescripGrupo.Text = oGrupo.Descripcion

        If oGrupo.ServicioList.Count = 0 Then
            LabelNoServicios.Visible = True
        Else
            servicios.Visible = True
            ListBoxServicios.DataSource = oGrupo.ServicioList
            ListBoxServicios.DataTextField = "Nombre"
            ListBoxServicios.DataValueField = "ID"
            ListBoxServicios.DataBind()
            oMaqueteado.AttachColor(ListBoxServicios, "lightblue", "white")
        End If

        If (oGruposService.PuedeAdherir(CType(Session("Usuario"), Entities.Usuario).idUsuario, idGrupo)) Then
            ButtonAdherir.Visible = True

        Else

            If oGruposService.esDueño(CType(Session("Usuario"), Entities.Usuario).idUsuario, idGrupo) Then
                comandosGrupo.Visible = True
                If oGrupo.MiembrosList.Count = 0 Then
                    LabelNoMiembros.Visible = True
                Else
                    miembros.Visible = True
                    ListBoxMiembros.DataSource = oGrupo.MiembrosList
                    ListBoxMiembros.DataTextField = "NombreUsuario"
                    ListBoxMiembros.DataValueField = "idUsuario"
                    ListBoxMiembros.DataBind()
                    oMaqueteado.AttachColor(ListBoxMiembros, "lightblue", "white")

                End If
            Else
                ButtonDesuscribirse.Visible = True
                DivMiembros.visible = False
            End If
        End If
    End Sub


    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonAdherir.Click
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.AltaAGrupoPendienteAprobacion(CType(Session("Usuario"), Entities.Usuario).idUsuario, CInt(Request.QueryString("id")), Mensaje, Status)
        Response.Redirect("~/DetalleGrupo.aspx?id=" & CInt(Request.QueryString("id")))

    End Sub

    Protected Sub suprGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonSuprGrupo.Click
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.DeleteGrupo(CInt(Request.QueryString("id")), Mensaje, Status)
        Response.Redirect("~/MisGrupos.aspx")
    End Sub

    Protected Sub editGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonEditGrupo.Click
        Response.Redirect("~/EditarGrupo.aspx?id=" & CInt(Request.QueryString("id")))
    End Sub

    Protected Sub Desuscribirse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonDesuscribirse.Click
        Dim mensaje As String = ""
        Dim status As Boolean

        oGruposService.BajaMiembroAGrupo(CInt(Request.QueryString("id")), CType(Session("Usuario"), Entities.Usuario).idUsuario, mensaje, status)
        Response.Redirect("~/MisGrupos.aspx")
    End Sub

    

End Class