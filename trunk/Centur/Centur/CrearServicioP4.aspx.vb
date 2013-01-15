Imports Datos

Public Class CrearServicioP4
    Inherits System.Web.UI.Page
    Dim cntPlaceHolder As ContentPlaceHolder
    Dim dc As New DC()
    Dim idServicio As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cntPlaceHolder = DirectCast(Master.FindControl("MainContent"), ContentPlaceHolder)

        idServicio = 3

        If Not Page.IsPostBack Then
            cargarReglasServicio()
        End If
    End Sub

    Private Sub cargarReglasServicio()
        Dim oServicio As Servicio = dc.Servicios.SingleOrDefault(Function(x) x.idServicio = idServicio)

        If Not oServicio Is Nothing Then
            If oServicio.privacidad Then
                chkPrivado.Checked = True
                cargarGrillaGrupos()
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

    Private Sub cargarGrillaGrupos()
        Dim grupos = (From sg In dc.ServicioGrupos
                      Where sg.idServicio = idServicio
                      Order By sg.Grupo.nombre
                      Select New With { _
                            Key .idServicioGrupo = sg.idServicioGrupo, _
                            Key .Grupo = sg.Grupo.nombre _
                        }).ToList()

        If grupos.Count > 0 Then
            grdPrivacidadGrupos.DataSource = grupos
            grdPrivacidadGrupos.DataBind()

            grdPrivacidadGrupos.Visible = True
            tbServicioGrupo.Visible = False

            lnkAgregarOtroGrupo.Visible = True

            'Dim gruposNoAgregados = (From grp In dc.Grupos
            '                         Join sg In dc.ServicioGrupos On grp.IdGrupo Equals sg.idGrupo
            '                         Where sg.idServicio = idServicio
            '                         Order By sg.Grupo.nombre Select New With { _
            '                            Key .idServicioGrupo = sg.idServicioGrupo, _
            '                            Key .Grupo = sg.Grupo.nombre _
            '                        }).ToList()
        Else
            'lnkNuevoHorario1.Enabled = False
            'tbAgregarHorario.Visible = True
        End If

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

    Protected Sub lnkAgregarOtroGrupo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarOtroGrupo.Click
        tbServicioGrupo.Visible = True
        lnkAgregarOtroGrupo.Visible = False
    End Sub
End Class