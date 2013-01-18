Imports Datos

Public Class CrearServicioP4
    Inherits System.Web.UI.Page
    Dim cntPlaceHolder As ContentPlaceHolder
    Dim dc As New DC()
    Dim oServicio As Servicio
    Dim lstServicioGrupos As New List(Of Integer)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cntPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

        If Not Session("oServicio") Is Nothing Then
            oServicio = DirectCast(Session("oServicio"), Servicio)
        Else
            oServicio = New Servicio()
            Session("oServicio") = oServicio
        End If

        If Not Session("ServicioGrupos") Is Nothing Then
            lstServicioGrupos = DirectCast(Session("ServicioGrupos"), List(Of Integer))
        End If

        If Not Page.IsPostBack Then
            cargarReglasServicio()
        End If
    End Sub

    Private Sub cargarReglasServicio()


        If Not oServicio Is Nothing Then

            cargarOpcionesGrupos()
            If oServicio.privacidad Then
                chkPrivado.Checked = True
            End If

            If oServicio.envioRecordatorio Then
                chkEnviarRecordatorio.Checked = True
            End If

            If oServicio.sobreturno Then
                chkSobreturno.Checked = True
            End If

            If oServicio.mercadoPago Then
                chkMercadoPago.Checked = True
            End If

            If oServicio.necesitaConfirmacion Then
                chkConfirmarTurno.Checked = True
            End If
        End If
    End Sub

    Private Sub cargarOpcionesGrupos()
        Dim idServicio As Integer

        Dim grupos As New List(Of Integer)
        If oServicio.idServicio > 0 Then
            grupos = (From sg In dc.ServicioGrupos
                        Where sg.idServicio = idServicio
                        Order By sg.Grupo.nombre
                        Select sg.idGrupo).ToList()
        End If

        Dim idProveedor As Integer = 1
        dpServicioGrupo.DataSource = dc.GruposListarDisponibles(idProveedor, If(Not IsNothing(oServicio) AndAlso oServicio.idServicio > 0, oServicio.idServicio, Nothing))
        dpServicioGrupo.DataBind()

        'Key .idServicioGrupo = sg.idServicioGrupo, _
        'Key .Grupo = sg.Grupo.nombre _
        If grupos.Count > 0 Then
            Session("ServicioGrupos") = grupos
            lstServicioGrupos = grupos
            'cargar grilla grupos


            grdPrivacidadGrupos.Visible = True
            tbServicioGrupo.Visible = False

            lnkAgregarOtroGrupo.Visible = True




        Else
            'lnkNuevoHorario1.Enabled = False
            'tbAgregarHorario.Visible = True
        End If

    End Sub
    Private Sub cargarGrillaGrupos()
        For Each Grupo In lstServicioGrupos

        Next
    End Sub
    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalizar.Click
        Dim blnEverithingOk As Boolean = True, blnGuardoReglas As Boolean = False

        blnGuardoReglas = guardarServicio()
        btnFinalizar.Text = "Finalizar"

        If blnEverithingOk And Not blnGuardoReglas Then
            Session("idGrilla") = Nothing
            Session("ServicioGrupos") = Nothing

            Response.Redirect("MisServicios.aspx")
        End If
    End Sub
    Private Function guardarServicio() As Boolean

        Dim blnGuardoReglas As Boolean = False
        blnGuardoReglas = guardarReglas(oServicio)

        If blnGuardoReglas Then 'para que muestre en la pantalla "Grabar" y sino toque "Finalizar" para guardar los otros datos
            Return True
        Else
            With oServicio
                .nombre = Session("ServicioNombre")
                .direccion = Session("ServicioDireccion")
            End With

            dc.SubmitChanges()
            Return False
        End If
    End Function
    Private Function guardarReglas(ByVal oServicio As Servicio) As Boolean
        Dim blnCambioReglas As Boolean = False


        If chkConfirmarTurno.Checked <> oServicio.necesitaConfirmacion Then
            oServicio.necesitaConfirmacion = chkConfirmarTurno.Checked
            blnCambioReglas = True
        End If

        If chkEnviarRecordatorio.Checked <> oServicio.envioRecordatorio Then
            oServicio.envioRecordatorio = chkEnviarRecordatorio.Checked
            blnCambioReglas = True
        End If

        If chkPrivado.Checked <> oServicio.privacidad OrElse (chkPrivado.Checked AndAlso dpServicioGrupo.SelectedValue <> "0") Then
            oServicio.privacidad = chkPrivado.Checked
            If chkPrivado.Checked And dpServicioGrupo.SelectedValue <> "0" Then
                dc.GrupoAsociarServicio("A", dpServicioGrupo.SelectedValue, oServicio.idServicio, Nothing, Nothing)
                cargarOpcionesGrupos()
            End If
            blnCambioReglas = True
        End If


        If chkMercadoPago.Checked <> oServicio.mercadoPago Then
            oServicio.mercadoPago = chkMercadoPago.Checked
            blnCambioReglas = True
        End If

        If chkSobreturno.Checked <> oServicio.sobreturno Then
            oServicio.sobreturno = chkSobreturno.Checked
            blnCambioReglas = True
        End If

        Dim oUsuario As Entities.Usuario = Session("Usuario")
        oServicio.idProveedor = 1 'oUsuario.idUsuario
        oServicio.diasAntes = txtDiasAntes.Text
        oServicio.diasAntes = txtDiasDespues.Text

        If oServicio.idServicio = 0 Then
            dc.Servicios.InsertOnSubmit(oServicio)
        End If
        dc.SubmitChanges()

        Session("oServicio") = oServicio



        Return blnCambioReglas
    End Function

    Protected Sub chkPrivado_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPrivado.CheckedChanged
        btnFinalizar.Text = "Grabar"
        If grdPrivacidadGrupos.Rows.Count > 0 Then
            tbServicioGrupo.Visible = False
            grdPrivacidadGrupos.Visible = chkPrivado.Checked
            lnkAgregarOtroGrupo.Visible = chkPrivado.Checked
        Else
            tbServicioGrupo.Visible = chkPrivado.Checked
        End If
    End Sub

    Protected Sub lnkAgregarOtroGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroGrupo.Click
        btnFinalizar.Text = "Grabar"

        tbServicioGrupo.Visible = True
        lnkAgregarOtroGrupo.Visible = False
    End Sub

    Protected Sub chkConfirmarTurno_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkConfirmarTurno.CheckedChanged
        btnFinalizar.Text = "Grabar"
    End Sub

    Protected Sub grdPrivacidadGrupos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdPrivacidadGrupos.RowDeleting

        dc.GrupoAsociarServicio("E", e.Keys(0), oServicio.idServicio, Nothing, Nothing)
    End Sub

    Protected Sub chkEnviarRecordatorio_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkEnviarRecordatorio.CheckedChanged
        btnFinalizar.Text = "Grabar"
    End Sub

    Protected Sub chkSobreturno_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkSobreturno.CheckedChanged
        btnFinalizar.Text = "Grabar"
    End Sub

    Protected Sub chkMercadoPago_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMercadoPago.CheckedChanged
        btnFinalizar.Text = "Grabar"
    End Sub
End Class