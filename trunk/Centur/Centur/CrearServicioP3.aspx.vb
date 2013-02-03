Imports Datos

Public Class CrearServicioP3
    Inherits System.Web.UI.Page
    Dim dc As DC
    Dim idGrilla As Integer?
    Dim cntPlaceHolder As ContentPlaceHolder

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("oDataContext") Is Nothing Then
            dc = DirectCast(Session("oDataContext"), DC)
        Else
            dc = New DC()
        End If

        If Not Session("idGrilla") Is Nothing Then
            idGrilla = Session("idGrilla")
        Else
            Dim oServicio As Servicio
            Dim ServicioGrilla As Integer?

            If Not Session("oServicio") Is Nothing Then
                oServicio = DirectCast(Session("oServicio"), Servicio)
                ServicioGrilla = (From sg In dc.ServicioGrillas
                                  Where (sg.idServicio = oServicio.idServicio)
                                  Select sg.idGrilla).SingleOrDefault()
            End If

            If Not oServicio Is Nothing AndAlso ServicioGrilla > 0 Then
                idGrilla = ServicioGrilla
            Else
                idGrilla = dc.GrillaRegistrar(New Date(2013, 1, 1), New Date(2015, 1, 1), Nothing, Nothing)
            End If
            Session("idGrilla") = idGrilla
        End If

        cntPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

        If Not idGrilla Is Nothing And Not Page.IsPostBack Then
            CargarConfiguracionHoraria(cntPlaceHolder, idGrilla)
        End If
    End Sub

    Protected Sub btnContinuar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Dim blnEverithingOk As Boolean = True, blnGuardoDatos As Boolean = False

        For Each oControl As Control In cntPlaceHolder.Controls
            If TypeOf oControl Is CheckBox Then
                Dim chkDia As CheckBox = DirectCast(oControl, CheckBox)
                Dim strDia As String = chkDia.ID.Substring(chkDia.ID.Length - 1)
                Dim grdHorarioDia As GridView = DirectCast(cntPlaceHolder.FindControl("grdHorarios" + strDia), GridView)

                If chkDia.Checked Then
                    Dim tbHorarioDia As Table = DirectCast(cntPlaceHolder.FindControl("tb" + strDia), Table)
                    If tbHorarioDia.Visible Then
                        blnGuardoDatos = True
                        guardarHorarioDia(idGrilla, tbHorarioDia)
                        grdHorarioDia.DataSource = obtenerConfiguracionDias(idGrilla, strDia)
                        grdHorarioDia.DataBind()
                        grdHorarioDia.Visible = True
                        tbHorarioDia.Visible = False
                        Dim lnkAgregarOtroHorario As LinkButton = cntPlaceHolder.FindControl("lnkAgregarOtroHorario" + strDia)
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

        If tbExcepcion.Visible And validarExcepcion() Then 'está cargando una excepción
            Dim oGrillaExcepcion As New GrillaExepcion

            With oGrillaExcepcion
                .idGrilla = idGrilla
                .fecha = Date.Parse(txtFechaExcep.Text)
                .horaInicio = TimeSpan.Parse(txtHoraDesdeExcep.Text)
                .horaFin = TimeSpan.Parse(txtHoraHastaExcep.Text)
            End With

            dc.GrillaExepcions.InsertOnSubmit(oGrillaExcepcion)
            dc.SubmitChanges()

            actualizarGrillaExcepciones()
            tbExcepcion.Visible = False
            lnkAgregarOtraExcepcion.Visible = True
            blnGuardoDatos = True
        End If

        If blnEverithingOk And Not blnGuardoDatos Then

            Session("ServicioGrilla") = idGrilla
            Session("idGrilla") = Nothing
            Response.Redirect("CrearServicioP4.aspx")
        End If
    End Sub
    Private Function validarExcepcion() As Boolean
        If txtFechaExcep.Text = "" Then
            Return False
        End If

        Return True
    End Function

    Private Sub actualizarGrillaExcepciones()
        grdExepciones.DataSource = dc.GrillaExepcions.Where(Function(x) x.idGrilla = idGrilla And x.fecha >= Date.Today).OrderBy(Function(x) x.fecha)
        grdExepciones.DataBind()
        grdExepciones.Visible = True
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
            lblMensajeErrror.Visible = False
            dc.GrillaHorarioRegistrar(idGrilla, numeroDia, TimeSpan.Parse(txtHoraDesde.Text), TimeSpan.Parse(txtHoraHasta.Text), txtCapacidad.Text, txtDuracion.Text, Nothing, Nothing)
        Else
            lblMensajeErrror.Text = "<div class=""ui-widget""><div class=""ui-state-error ui-corner-all"" style=""padding: 0 .7em;"">" & _
                                    "<p><span class=""ui-icon ui-icon-alert"" style=""float: left; margin-right: .3em;""></span>" & _
                                    "<strong>Error:</strong> " + strMensajeError + ".</p>" & _
                                    "</div></div> "
            lblMensajeErrror.Visible = True
            'Mostrar error 
        End If
    End Sub
    Private Sub CargarConfiguracionHoraria(ByVal cntPlaceHolder As ContentPlaceHolder, ByVal idGrilla As Integer)

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

        'Carga de excepciones
        actualizarGrillaExcepciones()
    End Sub

    Protected Sub grdHorarios1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios1.RowDeleting
        screenEliminarHorario(1, e.Keys(0))
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

    Protected Sub chkDia1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia1.CheckedChanged
        screenCambiarCheckDia(1)
    End Sub

    Protected Sub lnkAgregarOtroHorario1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario1.Click
        screenAgregarOtroHorario(1)
    End Sub

    Protected Sub lnkAgregarOtroHorario2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario2.Click
        screenAgregarOtroHorario(2)
    End Sub
    Private Sub screenEliminarHorario(ByVal strNumeroDia As String, ByVal idGrillaConfHorario As Integer)
        eliminarHorario(idGrillaConfHorario)
        Dim grdHorarios As GridView = DirectCast(cntPlaceHolder.FindControl("grdHorarios" + strNumeroDia), GridView)
        grdHorarios.DataSource = obtenerConfiguracionDias(idGrilla, CInt(strNumeroDia))
        grdHorarios.DataBind()
    End Sub
    Private Sub screenCambiarCheckDia(ByVal strNumeroDia As String)
        btnSiguiente.Text = "Grabar"
        Dim grdHorarios As GridView = DirectCast(cntPlaceHolder.FindControl("grdHorarios" + strNumeroDia), GridView)
        Dim chkDia As CheckBox = DirectCast(cntPlaceHolder.FindControl("chkDia" + strNumeroDia), CheckBox)
        Dim tb As Table = DirectCast(cntPlaceHolder.FindControl("tb" + strNumeroDia), Table)
        Dim lnkOtroHorario As LinkButton = DirectCast(cntPlaceHolder.FindControl("lnkAgregarOtroHorario" + strNumeroDia), LinkButton)

        If grdHorarios.Rows.Count > 0 Then
            tb.Visible = False
            grdHorarios.Visible = chkDia.Checked
            lnkOtroHorario.Visible = chkDia.Checked
        Else
            tb.Visible = chkDia.Checked
        End If
    End Sub
    Private Sub screenAgregarOtroHorario(ByVal strNumeroDia As String)
        Dim tb As Table = DirectCast(cntPlaceHolder.FindControl("tb" + strNumeroDia), Table)
        tb.Visible = True

        btnSiguiente.Text = "Grabar"
        Dim lnkOtroHorario As LinkButton = DirectCast(cntPlaceHolder.FindControl("lnkAgregarOtroHorario" + strNumeroDia), LinkButton)
        lnkOtroHorario.Visible = False
    End Sub

    Protected Sub chkDia2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia2.CheckedChanged
        screenCambiarCheckDia(2)
    End Sub

    Protected Sub grdHorarios2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios2.RowDeleting
        screenEliminarHorario(2, e.Keys(0))
    End Sub

    Protected Sub lnkAgregarOtroHorario3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario3.Click
        screenAgregarOtroHorario(3)
    End Sub

    Protected Sub chkDia3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia3.CheckedChanged
        screenCambiarCheckDia(3)
    End Sub

    Protected Sub grdHorarios3_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios3.RowDeleting
        screenEliminarHorario(3, e.Keys(0))
    End Sub

    Protected Sub lnkAgregarOtroHorario4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario4.Click
        screenAgregarOtroHorario(4)
    End Sub

    Protected Sub grdHorarios4_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios4.RowDeleting
        screenEliminarHorario(4, e.Keys(0))
    End Sub

    Protected Sub chkDia4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia4.CheckedChanged
        screenCambiarCheckDia(4)
    End Sub

    Protected Sub chkDia5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia5.CheckedChanged
        screenCambiarCheckDia(5)
    End Sub

    Protected Sub lnkAgregarOtroHorario5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario5.Click
        screenAgregarOtroHorario(5)
    End Sub

    Protected Sub grdHorarios5_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios5.RowDeleting
        screenEliminarHorario(5, e.Keys(0))
    End Sub

    Protected Sub lnkAgregarOtroHorario6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario6.Click
        screenAgregarOtroHorario(6)
    End Sub

    Protected Sub grdHorarios6_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios6.RowDeleting
        screenEliminarHorario(6, e.Keys(0))
    End Sub

    Protected Sub chkDia6_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia6.CheckedChanged
        screenCambiarCheckDia(6)
    End Sub

    Protected Sub lnkAgregarOtroHorario7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroHorario7.Click
        screenAgregarOtroHorario(7)
    End Sub

    Protected Sub grdHorarios7_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHorarios7.RowDeleting
        screenEliminarHorario(7, e.Keys(0))
    End Sub

    Protected Sub chkDia7_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDia7.CheckedChanged
        screenCambiarCheckDia(7)
    End Sub

    Protected Sub lnkGrillaAsociada_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkGrillaAsociada.Click
        dpGrillaAsociada.Visible = True
        lnkGrillaAsociada.Visible = False

        Dim oUsuario As Entities.Usuario = DirectCast(Session("Usuario"), Entities.Usuario)
        Dim idServicio As Integer = 0
        If Not Session("oServicio") Is Nothing Then
            idServicio = DirectCast(Session("oServicio"), Servicio).idServicio
        End If

        Dim ServicioGrilla = (From srv In dc.Servicios
                              Join srvGrd In dc.ServicioGrillas On srv.idServicio Equals srvGrd.idServicio
                              Where srv.idProveedor = oUsuario.idUsuario And (idServicio = 0 OrElse srv.idServicio <> idServicio)
                              Order By srv.nombre
                              Select New With { _
                                .idGrilla = srvGrd.idGrilla, _
                                .Nombre = srv.nombre}).Distinct().ToList()

        dpGrillaAsociada.DataSource = ServicioGrilla
        dpGrillaAsociada.DataBind()

    End Sub

    Protected Sub dpGrillaAsociada_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dpGrillaAsociada.SelectedIndexChanged
        If dpGrillaAsociada.SelectedValue <> "" Then
            Dim idGrilla As Integer = dpGrillaAsociada.SelectedValue
            Session("idGrilla") = idGrilla
            CargarConfiguracionHoraria(cntPlaceHolder, idGrilla)
        Else
            lnkGrillaAsociada.Visible = True
            Session("idGrilla") = Nothing
        End If
    End Sub

    Protected Sub lnkAgregarOtraExcepcion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtraExcepcion.Click
        btnSiguiente.Text = "Grabar"
        tbExcepcion.Visible = True
        lnkAgregarOtraExcepcion.Visible = False
    End Sub

    Protected Sub grdExepciones_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdExepciones.RowDeleting
        Dim idExcepcion As Integer = e.Keys(0)

        dc.GrillaExepcions.DeleteOnSubmit(dc.GrillaExepcions.Single(Function(x) x.idExepcion = idExcepcion))
        dc.SubmitChanges()

        actualizarGrillaExcepciones()
    End Sub
End Class