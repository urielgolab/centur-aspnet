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

        ArbolCategorias.Nodes.Clear()
        Dim categorias As Entities.CategoriaList = oBuscarServicioService.BuscarCategorias("R")

        For Each cat As Entities.Categoria In categorias
            Dim node As New TreeNode
            node.Value = cat.IDCategoria
            node.Text = cat.NombreCategoria
            AddChildNodesCategorias(node)
            ArbolCategorias.Nodes.Add(node)
        Next
    End Sub

    Private Sub AddChildNodesCategorias(ByRef ParentNode As TreeNode)
        Dim categorias As Entities.CategoriaList = oBuscarServicioService.BuscarCategorias("H", ParentNode.Value)

        For Each cat As Entities.Categoria In categorias
            Dim node As New TreeNode
            Dim ChildNode As New TreeNode
            ChildNode.Value = cat.IDCategoria
            ChildNode.Text = cat.NombreCategoria
            AddChildNodesCategorias(ChildNode)
            ParentNode.ChildNodes.Add(ChildNode)
        Next
    End Sub

    Private Sub ArmarArbolZonas()
        ArbolZonas.Nodes.Clear()
        Dim zonas As Entities.ZonaList = oBuscarServicioService.BuscarZonas("R")

        For Each zon As Entities.Zona In zonas
            Dim node As New TreeNode
            node.Value = zon.IDZona
            node.Text = zon.NombreZona
            AddChildNodesZonas(node)
            ArbolZonas.Nodes.Add(node)
        Next
    End Sub

    Private Sub AddChildNodesZonas(ByRef ParentNode As TreeNode)
        Dim zonas As Entities.ZonaList = oBuscarServicioService.BuscarZonas("H", ParentNode.Value)

        For Each zon As Entities.Zona In zonas
            Dim node As New TreeNode
            Dim ChildNode As New TreeNode
            ChildNode.Value = zon.IDZona
            ChildNode.Text = zon.NombreZona
            AddChildNodesZonas(ChildNode)
            ParentNode.ChildNodes.Add(ChildNode)
        Next
    End Sub





End Class
