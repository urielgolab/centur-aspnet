Imports Entities

Public Class GrupoPendientes
    Inherits System.Web.UI.Page
    Dim oGruposService As New Services.GruposService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oGrupoPendientesList As New GrupoPendientesList

        If Not Page.IsPostBack Then
            oGrupoPendientesList = oGruposService.ObtenerPendientes(CType(Session("Usuario"), Entities.Usuario).idUsuario)
            If oGrupoPendientesList.Count > 0 Then
                GridPendientes.DataSource = oGrupoPendientesList
                GridPendientes.DataBind()
            Else
                pendientes.Visible = False
                noPendientes.Visible = True
            End If
        End If
    End Sub

    Protected Sub AceptarSel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AceptarSel.Click

        For Each row As GridViewRow In GridPendientes.Rows

            Dim mensaje As String = ""
            Dim status As Boolean

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idGrupo As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("IdGrupo"))
                Dim idUsuario As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("IdUsuario"))

                oGruposService.AltaAGrupo(idGrupo, idUsuario, mensaje, status)

            End If

        Next row

        Response.Redirect("~/GrupoPendientes.aspx")

    End Sub

    Protected Sub RechazarSel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RechazarSel.Click

        For Each row As GridViewRow In GridPendientes.Rows

            Dim mensaje As String = ""
            Dim status As Boolean

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idGrupo As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("IdGrupo"))
                Dim idUsuario As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("IdUsuario"))

                oGruposService.BajaMiembroAGrupo(idGrupo, idUsuario, mensaje, status)

            End If

        Next row

        Response.Redirect("~/GrupoPendientes.aspx")
    End Sub

End Class