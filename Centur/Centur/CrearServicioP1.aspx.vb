Imports Datos

Public Class CrearServicioP1
    Inherits System.Web.UI.Page
    Dim oServicio As Servicio
    Dim dc As New DC()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("idServicio") Is Nothing Then
            oServicio = dc.Servicios.SingleOrDefault(Function(x) x.idServicio = CInt(Request.QueryString("idServicio")))
        End If

        If Not oServicio Is Nothing AndAlso lstCategoria.SelectedValue = "" Then
            cargarCategoria(oServicio.idCategoria)
        Else
            cargarCategoriasHijo(lstCategoria.SelectedValue)
        End If
    End Sub

    Private Sub cargarCategoriasHijo(ByVal strCategoria As String)
        Dim idCategoria As Integer?

        If strCategoria <> "" Then idCategoria = strCategoria

        Dim Categorias = dc.CategoriaBuscar(CType(IIf(idCategoria Is Nothing, "R", "H"), Char), idCategoria).ToList()

        If Categorias.Count > 0 Then
            'If strCategoria <> "" Then
            '    lnkCategoriaPadre.Text = lstCategoria.Items(lstCategoria.SelectedIndex).Text
            '    lnkCategoriaPadre.ToolTip = lstCategoria.Items(lstCategoria.SelectedIndex).Value
            'End If
            lnkCategoriaPadre.Text = dc.CategoriaObtenerPadre(idCategoria)

            btnSiguiente.Enabled = False

            lstCategoria.DataSource = Categorias
            lstCategoria.DataTextField = "descripcion"
            lstCategoria.DataValueField = "idCategoria"
            lstCategoria.DataBind()
        Else
            btnSiguiente.Enabled = True
        End If

    End Sub
    Private Sub cargarCategoria(ByVal idCategoria As Integer)
        Dim Categorias = (From c In dc.Categorias
                         Join sch In dc.SubCategorias On c.idCategoria Equals sch.idCategoriaHijo
                         Where sch.idCategoriaPadre = dc.SubCategorias.Single(Function(x) x.idCategoriaHijo = idCategoria).idCategoriaPadre
                         Select c).ToList()

        If Categorias.Count > 0 Then
            'If strCategoria <> "" Then
            '    lnkCategoriaPadre.Text = lstCategoria.Items(lstCategoria.SelectedIndex).Text
            '    lnkCategoriaPadre.ToolTip = lstCategoria.Items(lstCategoria.SelectedIndex).Value
            'End If
            lnkCategoriaPadre.Text = dc.CategoriaObtenerPadre(idCategoria)

            btnSiguiente.Enabled = True

            lstCategoria.DataSource = Categorias
            lstCategoria.DataTextField = "descripcion"
            lstCategoria.DataValueField = "idCategoria"
            lstCategoria.DataBind()

            lstCategoria.SelectedValue = idCategoria
        End If

    End Sub

    Protected Sub btnSiguiente_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSiguiente.Click
        If oServicio Is Nothing Then
            oServicio = New Servicio()
        End If

        oServicio.idCategoria = lstCategoria.SelectedValue
        Session("oServicio") = oServicio
        Session("oDataContext") = dc
        Session("idGrilla") = Nothing
        Response.Redirect("CrearServicioP2.aspx")
    End Sub

    Protected Sub lnkCategoriaPadre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkCategoriaPadre.Click
        cargarCategoriasHijo("")
    End Sub
End Class