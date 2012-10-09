Partial Class BuscarServicio
    Inherits System.Web.UI.Page

    Protected Sub Buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim table As New Data.DataTable
        table.Columns.Add("ID")
        table.Columns.Add("Nombre")
        table.Columns.Add("Direccion")
        table.Rows.Add(1, "Futbol", "Gavilan")
        table.Rows.Add(2, "Tenis", "Camacua  .")

        gridResultados.DataSource = table
        gridResultados.DataBind()




    End Sub
End Class
