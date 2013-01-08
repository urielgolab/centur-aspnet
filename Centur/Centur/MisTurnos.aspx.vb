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

        'Me.GetGruposAdheridos()
    End Sub

    Private Sub GetServiciosPropios()

        Dim mensaje As String = ""
        Dim status As Boolean
        Dim oServicioList As New ServicioList

        oServicioList = oBuscarServicioService.ObtenerServicios(CType(Session("Usuario"), Entities.Usuario).idUsuario, "P", mensaje, status)
        If oServicioList.Count > 0 Then
            If Not (Page.IsPostBack) Then
                DropDownListServiciosPropios.DataSource = oServicioList
                DropDownListServiciosPropios.DataTextField = "Nombre"
                DropDownListServiciosPropios.DataValueField = "ID"
                DropDownListServiciosPropios.DataBind()
            End If
        End If

    End Sub

End Class