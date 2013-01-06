Imports Datos

Public Class CrearServicioP3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Response.Redirect("CrearServicioP4.aspx")
    End Sub

    Protected Sub chkLunes_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkLunes.CheckedChanged
        tbLunes.Visible = chkLunes.Checked

        If chkLunes.Checked Then
            agregarFilaConfDia(tbLunes)
            agregarFilaNuevoDia(tbLunes)
        End If
    End Sub

    Private Sub agregarFilaConfDia(ByVal tbTabla As Table)
        Dim strFila As String = tbTabla.Rows.Count.ToString()

        Dim trFilaHorario As New TableRow

        Dim tdHoraDesde As New TableCell

        Dim lblHoraDesde As New Label
        lblHoraDesde.ID = "lblHoraDesde" + strFila
        lblHoraDesde.Width = 50
        lblHoraDesde.Text = "Desde:"
        tdHoraDesde.Controls.Add(lblHoraDesde)
        Dim txtHoraDesde As New TextBox
        txtHoraDesde.ID = "txtHoraDesde" + strFila
        txtHoraDesde.Attributes.Add("placeholder", "Desde")
        txtHoraDesde.Width = 50
        txtHoraDesde.Text = "09:00"
        txtHoraDesde.MaxLength = 5
        tdHoraDesde.Controls.Add(txtHoraDesde)
        trFilaHorario.Cells.Add(tdHoraDesde)

        Dim tdHoraHasta As New TableCell
        Dim lblHoraHasta As New Label
        lblHoraHasta.ID = "lblHoraHasta" + strFila
        lblHoraHasta.Width = 50
        lblHoraHasta.Text = "Hasta:"
        tdHoraHasta.Controls.Add(lblHoraHasta)
        Dim txtHoraHasta As New TextBox
        txtHoraHasta.ID = "txtHoraHasta" + strFila
        txtHoraHasta.Attributes.Add("placeholder", "Hasta")
        txtHoraHasta.Width = 50
        txtHoraHasta.Text = "20:00"
        txtHoraHasta.MaxLength = 5
        tdHoraHasta.Controls.Add(txtHoraHasta)
        trFilaHorario.Cells.Add(tdHoraHasta)

        Dim tdCapacidad As New TableCell
        Dim lblCapacidad As New Label
        lblCapacidad.ID = "lblCapacidad" + strFila
        lblCapacidad.Width = 75
        lblCapacidad.Text = "Capacidad:"
        tdCapacidad.Controls.Add(lblCapacidad)
        Dim txtCapacidad As New TextBox
        txtCapacidad.ID = "txtCapacidad" + strFila
        txtCapacidad.Width = 15
        txtCapacidad.Text = "1"
        txtCapacidad.MaxLength = 2
        tdCapacidad.Controls.Add(txtCapacidad)
        trFilaHorario.Cells.Add(tdCapacidad)

        Dim tdDuracion As New TableCell
        Dim lblDuracion As New Label
        lblDuracion.ID = "lblDuracion" + strFila
        lblDuracion.Width = 100
        lblDuracion.Text = "Duraci&oacute;n (min):"
        tdDuracion.Controls.Add(lblDuracion)
        Dim txtDuracion As New TextBox
        txtDuracion.ID = "txtDuracion" + strFila
        txtDuracion.Width = 35
        txtDuracion.Text = "30"
        txtDuracion .MaxLength = 3
        tdDuracion.Controls.Add(txtDuracion)
        trFilaHorario.Cells.Add(tdDuracion)


        tbTabla.Rows.Add(trFilaHorario)
    End Sub
    Private Sub agregarFilaNuevoDia(ByVal tbTabla As Table)
        Dim trFilaAgregarNuevo As New TableRow

        Dim tdNuevoDia As New TableCell
        Dim lnkAgregarNuevo As New LinkButton
        lnkAgregarNuevo.ID = "btAgregarNuevo"
        lnkAgregarNuevo.Text = "(+) Nuevo rango"
        tdNuevoDia.Controls.Add(lnkAgregarNuevo)
        trFilaAgregarNuevo.Cells.Add(tdNuevoDia)

        tbTabla.Rows.Add(trFilaAgregarNuevo)
    End Sub
End Class