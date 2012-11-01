Partial Class BuscarServicio
    Inherits System.Web.UI.Page

    Dim oBuscarServicioService As New Services.BuscarServicioService()

    Protected Sub buscar_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles buscar.Click
        Dim categoriasSeleccionadas As String = VerNodosSeleccionados(ArbolCategorias)
        Dim zonasSeleccionadas As String = VerNodosSeleccionados(ArbolZonas)

        gridResultados.DataSource = oBuscarServicioService.BuscarServicio(Me.nombre.Text, categoriasSeleccionadas, zonasSeleccionadas)
        gridResultados.DataBind()
        resultados.Visible = True
    End Sub

    Private Sub reset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reset.Click
        resultados.Visible = False
    End Sub

    Private Sub BuscarServicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            resultados.Visible = False
            ArmarArbolCategorias()
            ArmarArbolZonas()
        End If
    End Sub


    Private Function VerNodosSeleccionados(ByVal arbol As TreeView) As String
        Dim nodosSeleccionados As String = ""
        For Each node As TreeNode In arbol.Nodes
            VerSubNodosSeleccionados(nodosSeleccionados, node)
            If node.Checked Then
                nodosSeleccionados = nodosSeleccionados + CStr(node.Value) + "|"
            End If
        Next

        If nodosSeleccionados.Length > 0 Then
            nodosSeleccionados = nodosSeleccionados.Remove(nodosSeleccionados.Length - 1)
        End If

        Return nodosSeleccionados
    End Function

    Private Function VerSubNodosSeleccionados(ByRef nodosSeleccionados As String, ByVal ParentNode As TreeNode)
        For Each node As TreeNode In ParentNode.ChildNodes
            VerSubNodosSeleccionados(nodosSeleccionados, node)
            If node.Checked Then
                nodosSeleccionados = nodosSeleccionados + CStr(node.Value) + "|"
            End If
        Next

    End Function

    Private Sub ArmarArbolCategorias()
        Dim dt As DataTable = oBuscarServicioService.BuscarCategorias()

        ArbolCategorias.Nodes.Clear()
        Dim RootNodes As DataRow() = dt.Select("ParentID=0")

        For Each row As DataRow In RootNodes
            Dim node As New TreeNode
            node.Value = row("ID")
            node.Text = row("Nombre")
            AddChildNodes(node, dt)
            ArbolCategorias.Nodes.Add(node)
        Next
    End Sub

    Private Sub ArmarArbolZonas()
        Dim dt As DataTable = oBuscarServicioService.BuscarZonas()

        ArbolZonas.Nodes.Clear()
        Dim RootNodes As DataRow() = dt.Select("ParentID=0")

        For Each row As DataRow In RootNodes
            Dim node As New TreeNode
            node.Value = row("ID")
            node.Text = row("Nombre")
            AddChildNodes(node, dt)
            ArbolZonas.Nodes.Add(node)
        Next
    End Sub

    Private Sub AddChildNodes(ByRef ParentNode As TreeNode, ByVal dt As DataTable)
        Dim ChildNodes As DataRow() = dt.Select("ParentID=" + CStr(ParentNode.Value))

        For Each row As DataRow In dt.Rows
            If row("ParentID") = ParentNode.Value Then
                Dim ChildNode As New TreeNode
                ChildNode.Value = row("ID")
                ChildNode.Text = row("Nombre")
                AddChildNodes(ChildNode, dt)
                ParentNode.ChildNodes.Add(ChildNode)
            End If
        Next
    End Sub



End Class
