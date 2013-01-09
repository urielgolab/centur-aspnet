Imports Entities

Public Class MisTurnos
    Inherits System.Web.UI.Page
    Dim oBuscarServicioService As New Services.BuscarServicioService

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
        End If

    End Sub

    Private Sub GetTurnosTomados()
        Dim oTurnoList As New TurnoList

        If Not IsPostBack Then
            oTurnoList = oBuscarServicioService.VerTurnosCliente(CType(Session("Usuario"), Entities.Usuario).idUsuario)

            If oTurnoList.Count > 0 Then
                GridTomados.DataSource = oTurnoList
                GridTomados.DataBind()
            Else
                tomados.Visible = False
                labelNoReservados.Visible = True
            End If
        End If

    End Sub

End Class