Imports Datos

Public Class CrearServicioP1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strCategoria As String

        If Not Request.QueryString("idCategoriaBack") Is Nothing Then
            strCategoria = Request.QueryString("idCategoriaBack")
        Else
            strCategoria = lstCategoria.SelectedValue
        End If

        cargarCategorias(strCategoria)
    End Sub

    Private Sub cargarCategorias(ByVal strCategoria As String)
        Dim dc As New DC()
        Dim idCategoria As Integer?

        If strCategoria <> "" Then idCategoria = strCategoria

        Dim Categorias = dc.CategoriaBuscar(CType(IIf(idCategoria Is Nothing, "R", "H"), Char), idCategoria).ToList()

        If Categorias.Count > 0 Then
            If strCategoria <> "" Then
                lblCategoriaPadre.Text = lstCategoria.Items(lstCategoria.SelectedIndex).Text
            End If

            btnSiguiente.Enabled = False

            lstCategoria.DataSource = Categorias
            lstCategoria.DataTextField = "descripcion"
            lstCategoria.DataValueField = "idCategoria"
            lstCategoria.DataBind()
        Else
            btnSiguiente.Enabled = True
        End If

    End Sub


    Protected Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        Response.Redirect("CrearServicioP2.aspx")
    End Sub
End Class