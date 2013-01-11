Imports Entities

Public Class AdministrarTurnos
    Inherits System.Web.UI.Page
    Dim oBuscarServicioService As New Services.BuscarServicioService
    Dim oTurnosService As New Services.TurnosService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))
        Dim oServicio As New Servicio


        If Not oBuscarServicioService.esDueño(idServicio, CType(Session("Usuario"), Entities.Usuario).idUsuario) Then
            Response.Redirect("~/MisTurnos.aspx")
            Return
        End If

        If Not IsPostBack Then

            oServicio = oBuscarServicioService.VerDetalleServicio(idServicio, 0)
            LabelServicio.Text = oServicio.Nombre

            Me.VerTurnosOtorgados()
            Me.VerTurnosPendientes()

        End If


    End Sub

    Protected Sub Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancelar.Click

        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))

        For Each row As GridViewRow In GridTomados.Rows

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idTurno As Integer = Convert.ToInt32(GridTomados.DataKeys(row.RowIndex).Values("idTurno"))

                oTurnosService.CancelarTurno(idTurno)

            End If

        Next row

        Response.Redirect("~/AdministrarTurnos.aspx?servicioId=" & idServicio)

    End Sub

    Private Sub VerTurnosOtorgados()
        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))
        Dim oTurnoList As New TurnoList


        oTurnoList = oTurnosService.VerTurnosProveedor(idServicio, 1)
        If oTurnoList.Count > 0 Then
            GridTomados.DataSource = oTurnoList
            GridTomados.DataBind()
        Else
            tomados.Visible = False
            LabelNoTurnosOtorgados.Visible = True
        End If

    End Sub


    Private Sub VerTurnosPendientes()
        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))
        Dim oTurnoList As New TurnoList


        oTurnoList = oTurnosService.VerTurnosProveedor(idServicio, 0)
        If oTurnoList.Count > 0 Then
            GridPendientes.DataSource = oTurnoList
            GridPendientes.DataBind()
        Else
            pendientes.Visible = False
            LabelNoPendientes.Visible = True
        End If

    End Sub



    Protected Sub LinkButtonCancelAp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButtonCancelAp.Click

        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))
        For Each row As GridViewRow In GridPendientes.Rows

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idTurno As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("idTurno"))

                oTurnosService.CancelarTurno(idTurno)

            End If

        Next row

        Response.Redirect("~/AdministrarTurnos.aspx?servicioId=" & idServicio)
    End Sub

    Protected Sub LinkButtonAcepAp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButtonAcepAp.Click

        Dim idServicio As Integer = CInt(Request.QueryString("servicioId"))
        For Each row As GridViewRow In GridPendientes.Rows

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then

                Dim idTurno As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("idTurno"))

                oTurnosService.AceptarTurno(idTurno)

            End If

        Next row

        Response.Redirect("~/AdministrarTurnos.aspx?servicioId=" & idServicio)

    End Sub
End Class