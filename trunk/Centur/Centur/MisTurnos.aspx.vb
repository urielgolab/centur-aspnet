Imports Entities

Public Class MisTurnos
    Inherits System.Web.UI.Page
    Dim oBuscarServicioService As New Services.BuscarServicioService
    Dim oTurnosService As New Services.TurnosService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If CType(Session("Usuario"), Entities.Usuario).TipoUsuario.Equals("P") Then
            Me.GetServiciosPropios()
        Else
            propios.Visible = False
        End If

        Me.GetTurnosTomados()
    End Sub

    Private Sub GetServiciosPropios()

        Dim oServicioList As New ServicioList

        oServicioList = oBuscarServicioService.VerServiciosDeProveedor(CType(Session("Usuario"), Entities.Usuario).idUsuario)
        If oServicioList.Count > 0 Then
            If Not (Page.IsPostBack) Then
                DropDownListServiciosPropios.DataSource = oServicioList
                DropDownListServiciosPropios.DataTextField = "Nombre"
                DropDownListServiciosPropios.DataValueField = "ID"
                DropDownListServiciosPropios.DataBind()
            End If
        Else
            LinkButton4.Visible = False
        End If

    End Sub

    Private Sub GetTurnosTomados()
        Dim oTurnoList As New List(Of Turno)
        Dim confirmados As New List(Of Turno)
        Dim pendientes As New List(Of Turno)

        If Not IsPostBack Then
            oTurnoList = oTurnosService.VerTurnosCliente(CType(Session("Usuario"), Entities.Usuario).idUsuario)

            If oTurnoList.Count = 0 Then
                tomados.Visible = False
                labelNoReservados.Visible = True
                Return
            End If

            confirmados = oTurnoList.FindAll(AddressOf FindConfirmados)
            If confirmados.Count > 0 Then
                GridConfirmados.DataSource = confirmados
                GridConfirmados.DataBind()
            Else
                divConfirmados.Visible = False
            End If

            pendientes = oTurnoList.FindAll(AddressOf FindPendientes)
            If pendientes.Count > 0 Then
                GridPendientes.DataSource = pendientes
                GridPendientes.DataBind()
            Else
                divPendientes.Visible = False
            End If

        End If

    End Sub

    Protected Sub Cancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cancelar.Click

        For Each row As GridViewRow In GridConfirmados.Rows

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then
                Dim idTurno As Integer = Convert.ToInt32(GridConfirmados.DataKeys(row.RowIndex).Values("idTurno"))
                oTurnosService.CancelarTurno(idTurno)
            End If

        Next row

        For Each row As GridViewRow In GridPendientes.Rows

            If CType(row.FindControl("CheckBox1"), CheckBox).Checked = True Then
                Dim idTurno As Integer = Convert.ToInt32(GridPendientes.DataKeys(row.RowIndex).Values("idTurno"))
                oTurnosService.CancelarTurno(idTurno)
            End If

        Next row

        Response.Redirect("~/MisTurnos.aspx")
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        Response.Redirect("~/AdministrarTurnos.aspx?servicioId=" & DropDownListServiciosPropios.Text)
    End Sub

    Private Function FindConfirmados(ByVal turno As Turno) As Boolean
        Return turno.Confirmado
    End Function

    Private Function FindPendientes(ByVal turno As Turno) As Boolean
        Return Not turno.Confirmado
    End Function

End Class