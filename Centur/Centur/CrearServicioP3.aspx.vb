Imports Datos

Public Class CrearServicioP3
    Inherits System.Web.UI.Page
    Dim dc As New DC()
    Dim idGrilla As Integer?
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("idGrilla") Is Nothing Then
            idGrilla = Session("idGrilla")
        Else
            idGrilla = 5 'dc.GrillaRegistrar(Nothing, Nothing, Nothing, Nothing)
        End If

        Dim cntPlaceHolder As ContentPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

        If Not idGrilla Is Nothing And Not Page.IsPostBack Then
            CargarConfiguracionHoraria(cntPlaceHolder, idGrilla)
        End If
    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Dim contentPlaceHolder As ContentPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)
        Dim blnEverithingOk As Boolean = True, blnGuardoDatos As Boolean = False

        For Each oControl As Control In contentPlaceHolder.Controls
            If TypeOf oControl Is CheckBox Then
                Dim chkDia As CheckBox = DirectCast(oControl, CheckBox)
                Dim strDia As String = chkDia.ID.Substring(chkDia.ID.Length - 1)
                Dim grdHorarioDia As GridView = DirectCast(contentPlaceHolder.FindControl("grdHorarios" + strDia), GridView)

                If chkDia.Checked Then
                    Dim tbHorarioDia As Table = DirectCast(contentPlaceHolder.FindControl("tb" + strDia), Table)
                    If tbHorarioDia.Visible Then
                        blnGuardoDatos = True
                        guardarHorarioDia(idGrilla, tbHorarioDia)
                        grdHorarioDia.DataSource = obtenerConfiguracionDias(idGrilla, strDia)
                        grdHorarioDia.DataBind()
                        grdHorarioDia.Visible = True
                        tbHorarioDia.Visible = False
                        Dim lnkAgregarOtroHorario As LinkButton = contentPlaceHolder.FindControl("lnkAgregarOtroHorario" + strDia)
                        lnkAgregarOtroHorario.Visible = True
                        btnSiguiente.Text = "Siguiente"
                    End If
                Else
                    dc.GrillaDiaEliminar(idGrilla, strDia)
                    btnSiguiente.Text = "Siguiente"
                    grdHorarioDia.DataSource = Nothing
                    grdHorarioDia.DataBind()
                End If
            End If
        Next
        'Dim mControl As ControlType = DirectCast(contentPlaceHolder.FindControl("ControlName"), ControlType)

        If blnEverithingOk And Not blnGuardoDatos Then
            'Response.Redirect("CrearServicioP4.aspx")
        End If
    End Sub
    Protected Sub btAgregarNuevo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Return
    End Sub

    Private Sub guardarHorarioDia(ByVal idGrilla As Integer, ByVal tbHorarioDia As Table)
        Dim numeroDia As String = tbHorarioDia.ID.Substring(tbHorarioDia.ID.Length - 1)
        'Dim strCapacidad As String, strDuracion As String, strHoraDesde As String, strHoraHasta As String

        Dim txtHoraDesde As TextBox = DirectCast(tbHorarioDia.FindControl("txtHoraDesde" + numeroDia), TextBox)
        Dim txtHoraHasta As TextBox = DirectCast(tbHorarioDia.FindControl("txtHoraHasta" + numeroDia), TextBox)
        Dim txtCapacidad As TextBox = DirectCast(tbHorarioDia.FindControl("txtCapacidad" + numeroDia), TextBox)
        Dim txtDuracion As TextBox = DirectCast(tbHorarioDia.FindControl("txtDuracion" + numeroDia), TextBox)

        Dim strMensajeError As String = ""
        If dc.GrillaHorarioValidar(idGrilla, numeroDia, TimeSpan.Parse(txtHoraDesde.Text), TimeSpan.Parse(txtHoraHasta.Text), txtCapacidad.Text, txtDuracion.Text, strMensajeError) Then
            dc.GrillaHorarioRegistrar(idGrilla, numeroDia, TimeSpan.Parse(txtHoraDesde.Text), TimeSpan.Parse(txtHoraHasta.Text), txtCapacidad.Text, txtDuracion.Text, Nothing, Nothing)
        Else
            'Mostrar error 
        End If
    End Sub
    Private Sub CargarConfiguracionHoraria(ByVal cntPlaceHolder As ContentPlaceHolder, ByVal idGrilla As Integer)
        Dim dc As New DC()

        btnSiguiente.Text = "Continuar"
        For intDia As Integer = 1 To 7 'oConfigDia As GrillaConfiguracionDia In configuracionDias
            Try
                Dim strDia As String = intDia.ToString()

                Dim chkDia As CheckBox = cntPlaceHolder.FindControl("chkDia" + strDia)
                Dim grdGrillaHorarios As GridView = cntPlaceHolder.FindControl("grdHorarios" + strDia)
                Dim tbAgregarHorario As Table = cntPlaceHolder.FindControl("tb" + strDia)

                Dim horarios As List(Of GrillaConfiguracionHoraria) = obtenerConfiguracionDias(idGrilla, intDia)

                If horarios.Count > 0 Then
                    chkDia.Checked = True
                    grdGrillaHorarios.DataSource = horarios
                    grdGrillaHorarios.DataBind()
                    grdGrillaHorarios.Visible = True
                    'lnkNuevoHorario1.Visible = True
                    tbAgregarHorario.Visible = False

                    Dim lnkAgregarOtroHorario As LinkButton = cntPlaceHolder.FindControl("lnkAgregarOtroHorario" + strDia)
                    lnkAgregarOtroHorario.Visible = True
                Else
                    'lnkNuevoHorario1.Enabled = False
                    'tbAgregarHorario.Visible = True
                End If
            Catch
            End Try
        Next
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
        txtDuracion.MaxLength = 3
        tdDuracion.Controls.Add(txtDuracion)
        trFilaHorario.Cells.Add(tdDuracion)


        tbTabla.Rows.Add(trFilaHorario)
    End Sub
    Private Sub agregarFilaNuevoDia(ByVal tbTabla As Table)
        Dim trFilaAgregarNuevo As New TableRow

        Dim tdNuevoDia As New TableCell
        Dim btAgregarNuevo As New Button
        btAgregarNuevo.ID = "btAgregarNuevo"
        btAgregarNuevo.Text = "(+) Nuevo rango"
        tdNuevoDia.Controls.Add(btAgregarNuevo)
        trFilaAgregarNuevo.Cells.Add(tdNuevoDia)
        AddHandler btAgregarNuevo.Click, AddressOf btAgregarNuevo_Click
        tbTabla.Rows.Add(trFilaAgregarNuevo)
    End Sub

    Protected Sub grdHorarios1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios1.RowDeleting
        eliminarHorario(e.Keys(0))
        grdHorarios1.DataSource = obtenerConfiguracionDias(idGrilla, 1)
        grdHorarios1.DataBind()
    End Sub
    Private Function obtenerConfiguracionDias(ByVal idGrilla As Integer, ByVal intDia As Integer) As List(Of GrillaConfiguracionHoraria)
        Return (From gch In dc.GrillaConfiguracionHorarias
                Join gcd In dc.GrillaConfiguracionDias On gcd.idConfiguracionDia Equals gch.idConfiguracionDia
                Where gcd.idGrilla = idGrilla And gcd.dia = intDia
                Order By gch.idConfiguracionHoraria
                Select gch).ToList()
    End Function

    Private Sub eliminarHorario(ByVal idConfiguracionHoraria As Integer)
        dc.GrillaHorarioEliminar(idConfiguracionHoraria)
    End Sub

    'Protected Sub lnkNuevoHorario1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkNuevoHorario1.Click
    '    tb1.Visible = True
    'End Sub

    Protected Sub chkDia1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia1.CheckedChanged
        btnSiguiente.Text = "Grabar"
        If grdHorarios1.Rows.Count > 0 Then
            tb1.Visible = False
            grdHorarios1.Visible = chkDia1.Checked
            lnkAgregarOtroHorario1.Visible = chkDia1.Checked
        Else
            tb1.Visible = chkDia1.Checked
        End If

    End Sub

    Protected Sub lnkAgregarOtroHorario1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario1.Click
        tb1.Visible = True
        btnSiguiente.Text = "Grabar"
        lnkAgregarOtroHorario1.Visible = False
    End Sub
End Class