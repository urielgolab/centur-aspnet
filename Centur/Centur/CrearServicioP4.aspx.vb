Imports Datos

Public Class CrearServicioP4
    Inherits System.Web.UI.Page
    Dim cntPlaceHolder As ContentPlaceHolder
    Dim dc As DC
    Dim oServicio As Servicio
    Dim lstServicioGrupos As New List(Of Integer)
    Dim oUsuario As Entities.Usuario

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("oDataContext") Is Nothing Then
            dc = DirectCast(Session("oDataContext"), DC)
        Else
            dc = New DC()
        End If

        If Not Session("Usuario") Is Nothing Then
            oUsuario = DirectCast(Session("Usuario"), Entities.Usuario)
        End If

        cntPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

        If Not Session("oServicio") Is Nothing Then
            oServicio = DirectCast(Session("oServicio"), Servicio)
        Else
            oServicio = New Servicio() 'dc.Servicios.SingleOrDefault(Function(x) x.idServicio = CInt(3))
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
            txtDiasAntes.Text = oServicio.diasAntes
            txtDiasDespues.Text = oServicio.diasFuturo
            txtPrecio.Text = oServicio.precio

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
                txtPrecioReserva.Text = oServicio.precioReserva
                txtPrecioReserva.Visible = True
            End If

            If oServicio.necesitaConfirmacion Then
                chkConfirmarTurno.Checked = True
            End If
        End If
    End Sub

    Private Sub cargarOpcionesGrupos()
        Dim idServicio As Integer? = oServicio.idServicio

        Dim grupos = New List(Of Integer)
        If idServicio > 0 Then
            grupos = (From sg In dc.ServicioGrupos
                        Where sg.idServicio = idServicio
                        Order By sg.Grupo.nombre
                        Select sg.Grupo.IdGrupo).Distinct().ToList()
            lstServicioGrupos = grupos
            'lstServicioGrupos.AddRange(grupos)
            'lstServicioGrupos = lstServicioGrupos.Distinct().ToList()
        End If

        cargarComboGruposDisponibles()

        If grupos.Count > 0 Then
            Session("ServicioGrupos") = grupos
            'cargar grilla grupos
            cargarGrillaGrupos()


            tbServicioGrupo.Visible = False
            lnkAgregarOtroGrupo.Visible = True
        Else
            'lnkNuevoHorario1.Enabled = False
            'tbAgregarHorario.Visible = True
        End If

    End Sub
    Private Sub cargarComboGruposDisponibles()
        dpServicioGrupo.Items.Clear()
        dpServicioGrupo.DataSource = From grp In dc.GruposListarDisponibles(oUsuario.idUsuario, If(Not IsNothing(oServicio) AndAlso oServicio.idServicio > 0, oServicio.idServicio, Nothing))
                                     Where Not lstServicioGrupos.Contains(grp.IdGrupo)
                                     Order By grp.nombre
                                     Select grp
        dpServicioGrupo.DataBind()
    End Sub
    Private Sub cargarGrillaGrupos()
        grdPrivacidadGrupos.DataSource = (From grp In dc.Grupos
                                          Where lstServicioGrupos.Contains(grp.IdGrupo)
                                         Order By grp.nombre
                                         Select grp).ToList()
        grdPrivacidadGrupos.DataBind()

        If grdPrivacidadGrupos.Rows.Count > 0 Then
            grdPrivacidadGrupos.Visible = True
        End If
    End Sub
    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalizar.Click
        Dim blnEverithingOk As Boolean = True, blnGuardoReglas As Boolean = False

        blnGuardoReglas = guardarReglas()

        If blnEverithingOk Then
            Session("idGrilla") = Nothing
            Session("ServicioGrupos") = Nothing
            Session("ServicioGrilla") = Nothing

            Response.Redirect("MisServicios.aspx")
        End If
    End Sub
    Private Function guardarReglas() As Boolean
        Dim blnCambioReglas As Boolean = False

        'Genero el idServicio
        oServicio.idProveedor = oUsuario.idUsuario
        oServicio.diasAntes = txtDiasAntes.Text
        oServicio.diasFuturo = txtDiasDespues.Text
        oServicio.precio = txtPrecio.Text

        If oServicio.idServicio = 0 Then
            dc.Servicios.InsertOnSubmit(oServicio)
        End If
        dc.SubmitChanges()

        'Asocio la grilla al servicio
        dc.GrillaAsociarServicio("A", Session("ServicioGrilla"), oServicio.idServicio, Nothing, Nothing)

        If chkConfirmarTurno.Checked <> oServicio.necesitaConfirmacion Then
            oServicio.necesitaConfirmacion = chkConfirmarTurno.Checked
            blnCambioReglas = True
        End If

        If chkEnviarRecordatorio.Checked <> oServicio.envioRecordatorio Then
            oServicio.envioRecordatorio = chkEnviarRecordatorio.Checked
            blnCambioReglas = True
        End If

        If chkPrivado.Checked <> oServicio.privacidad OrElse (chkPrivado.Checked AndAlso lstServicioGrupos.Count > 0) Then
            oServicio.privacidad = chkPrivado.Checked
            If chkPrivado.Checked And lstServicioGrupos.Count > 0 Then
                guardarServiciosGrupos()
            End If
            blnCambioReglas = True
        End If

        If chkMercadoPago.Checked <> oServicio.mercadoPago OrElse (chkMercadoPago.Checked AndAlso oServicio.precioReserva.ToString() <> txtPrecioReserva.Text) Then
            oServicio.mercadoPago = chkMercadoPago.Checked
            If oServicio.mercadoPago AndAlso (oServicio.precioReserva.ToString() <> txtPrecioReserva.Text) Then
                oServicio.precioReserva = CDbl(txtPrecioReserva.Text)
            End If
            blnCambioReglas = True
        End If

        If chkSobreturno.Checked <> oServicio.sobreturno Then
            oServicio.sobreturno = chkSobreturno.Checked
            blnCambioReglas = True
        End If


        If blnCambioReglas Then
            dc.SubmitChanges()
        End If

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
        tbServicioGrupo.Visible = True
        lnkAgregarOtroGrupo.Visible = False        
    End Sub

    Protected Sub grdPrivacidadGrupos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdPrivacidadGrupos.RowDeleting
        lstServicioGrupos.Remove(e.Keys(0))
        Session("ServicioGrupos") = lstServicioGrupos
        cargarGrillaGrupos()
        cargarComboGruposDisponibles()
        'dc.GrupoAsociarServicio("E", e.Keys(0), oServicio.idServicio, Nothing, Nothing)
    End Sub
    Private Sub guardarServiciosGrupos()
        dc.GrupoAsociarServicio("E", Nothing, oServicio.idServicio, Nothing, Nothing)
        For Each idGrupo In lstServicioGrupos
            dc.GrupoAsociarServicio("A", idGrupo, oServicio.idServicio, Nothing, Nothing)
        Next
    End Sub
    Protected Sub btAgregarGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAgregarGrupo.Click
        lstServicioGrupos.Add(dpServicioGrupo.SelectedValue)
        Session("ServicioGrupos") = lstServicioGrupos
        cargarGrillaGrupos()
        cargarComboGruposDisponibles()
    End Sub

    Protected Sub chkMercadoPago_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkMercadoPago.CheckedChanged
        txtPrecioReserva.Visible = chkMercadoPago.Checked
    End Sub
End Class