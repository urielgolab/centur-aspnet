Imports Datos

Public Class CrearServicioP4
    Inherits System.Web.UI.Page
    Dim cntPlaceHolder As ContentPlaceHolder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cntPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

    End Sub

    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalizar.Click


        Response.Redirect("Servicios.aspx")
    End Sub

    Protected Sub chkPrivado_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPrivado.CheckedChanged
        If grdPrivacidadGrupos.Rows.Count > 0 Then
            tbServicioGrupo.Visible = False
            grdPrivacidadGrupos.Visible = chkPrivado.Checked
            lnkAgregarOtroGrupo.Visible = chkPrivado.Checked
        Else
            tbServicioGrupo.Visible = chkPrivado.Checked
        End If
    End Sub
End Class