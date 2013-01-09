Public Class VerEstadisticas
    Inherits System.Web.UI.Page

    Dim oEstadisticasDA As New DataAccessLayer.EstadisticasDA
    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DDLServicios.DataSource = oBuscarServicioService.VerServiciosDeProveedor(1)
        'DDLServicios.DataSource = oBuscarServicioService.VerServiciosDeProveedor(CType(Session("Usuario"), Entities.Usuario).idUsuario)
        'DDLServicios.Items.Insert(0, "Seleccione un servicio")
        DDLServicios.DataBind()
    End Sub

    Private Sub CalcularEstadisticas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CalcularEstadisticas.Click
        Dim accion As Char = CChar(Estadistica.SelectedValue)
        Dim servicioID As Integer = DDLServicios.SelectedValue

        Dim fechaDesdeSeleccionada As Date
        Dim fechaHastaSeleccionada As Date
        Dim horaDesdeSeleccionada As String
        Dim horaHastaSeleccionada As String

        If FechaDesde.Text = "" Then
            fechaDesdeSeleccionada = New Date(1900, 1, 1)
        Else
            fechaDesdeSeleccionada = CDate(FechaDesde.Text)
        End If

        If FechaHasta.Text = "" Then
            fechaHastaSeleccionada = Date.MaxValue
        Else
            fechaHastaSeleccionada = CDate(FechaHasta.Text)
        End If

        If HoraDesde.Text = "" Then
            horaDesdeSeleccionada = ""
        Else
            horaDesdeSeleccionada = CStr(HoraDesde.Text) + ":00"
        End If

        If HoraHasta.Text = "" Then
            horaHastaSeleccionada = ""
        Else
            horaHastaSeleccionada = CStr(HoraHasta.Text) + ":00"
        End If


        Dim resultado As Integer = oEstadisticasDA.CalcularEstadisticas(accion, servicioID, fechaDesdeSeleccionada, fechaHastaSeleccionada, horaDesdeSeleccionada, horaHastaSeleccionada)

        Select Case accion
            Case "A"
                lblResultado.Text = "El servicio ha sido visto " & CStr(resultado) & " veces"
            Case "C"
                lblResultado.Text = CStr(resultado) & " personas han cancelado un turno para dicho servicio"
            Case "P"
                lblResultado.Text = "El porcentaje de ocupación de dicho servicio en la franja seleccionada es de " & CStr(resultado) & "%"
            Case "D"
                lblResultado.Text = "El total de dinero recaudado por dicho servicio es de $ " & CStr(resultado)
        End Select



    End Sub

    Private Sub BorrarEstadisticas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BorrarEstadisticas.Click
        HoraDesde.Text = ""
        HoraHasta.Text = ""
        FechaDesde.Text = ""
        FechaHasta.Text = ""
        Estadistica.ClearSelection()
        lblResultado.Text = ""
    End Sub
End Class