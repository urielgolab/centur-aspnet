Imports Entities

Public Class EditarGrupo
    Inherits System.Web.UI.Page
    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim idGrupo As Integer = CInt(Request.QueryString("id"))

        If Not IsPostBack Then
            oGrupo = oGruposService.GetDetalleGrupo(idGrupo)
            NombreGrupo.Text = oGrupo.Nombre
            DescripGrupo.Text = oGrupo.Descripcion

            If oGrupo.ServicioList.Count > 0 Then
                GridServicios.DataSource = oGrupo.ServicioList
                GridServicios.DataBind()
            Else
                servicios.Visible = False
                labelNoServicios.Visible = True
            End If


            If oGrupo.MiembrosList.Count > 0 Then
                GridMiembros.DataSource = oGrupo.MiembrosList
                GridMiembros.DataBind()
            Else
                miembros.Visible = False
                LabelNoMiembros.Visible = True
            End If
        End If

    End Sub

    Protected Sub editGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles editGrupo.Click

        Dim idGrupo As Integer = CInt(Request.QueryString("id"))

        oGrupo.ID = idGrupo
        oGrupo.Nombre = NombreGrupo.Text
        oGrupo.Descripcion = DescripGrupo.Text
        oGruposService.UpdateGrupo(oGrupo)

        For Each row As GridViewRow In GridServicios.Rows

            Dim mensaje As String = ""
            Dim status As Boolean

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idServicio As Integer = Convert.ToInt32(GridMiembros.DataKeys(row.RowIndex).Values("idUsuario"))

                oGruposService.BajaServicioAGrupo(idGrupo, idServicio, mensaje, status)

            End If

        Next row

        For Each row As GridViewRow In GridMiembros.Rows

            Dim mensaje As String = ""
            Dim status As Boolean

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idUsuario As Integer = Convert.ToInt32(GridMiembros.DataKeys(row.RowIndex).Values("idUsuario"))

                oGruposService.BajaMiembroAGrupo(idGrupo, idUsuario, mensaje, status)

            End If

        Next row

        Response.Redirect("~/DetalleGrupo.aspx?id=" & idGrupo)

    End Sub

End Class