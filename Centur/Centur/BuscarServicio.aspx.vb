Partial Class BuscarServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()


    Protected Sub Buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gridResultados.DataSource = oBuscarServicioService.BuscarServicio(Me.nombre.Text, Me.categoria.Text, Me.zona.Text)
        gridResultados.DataBind()

    End Sub
End Class
