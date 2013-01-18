Imports Datos
Public Class MisServicios
    Inherits System.Web.UI.Page

    Dim dc As New DC()

    Private Sub MisGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("Usuario") Is Nothing Then
        '    Response.Redirect("~/Login.aspx")
        'End If

        If Not Request.QueryString("idServicio") Is Nothing Then
            Dim oServicio As Servicio = dc.Servicios.SingleOrDefault(Function(x) x.idServicio = CInt(Request.QueryString("idServicio")))
            dc.Servicios.DeleteOnSubmit(oServicio)
            dc.SubmitChanges()

            grdServicios.DataBind()
        End If

    End Sub

    Protected Sub btAgregarServicio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btAgregarServicio.Click
        Response.Redirect("CrearServicioP1.aspx")
    End Sub
End Class