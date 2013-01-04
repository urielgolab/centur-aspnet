Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Xml.Linq
Imports System.Web.Services
Imports System.Web.Script.Services

Imports Datos

Public Class CrearServicio
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lstCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim idCategoriaSeleccionada As Integer = lstCategoria.SelectedValue.ToString()
        Dim dc As New DC()

        hidCategoriaPadre.Value = lstCategoria.SelectedValue.ToString()

    End Sub

    <System.Web.Services.WebMethod(BufferResponse:=False)> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Shared Function getCategorias(ByVal idCategoria As Integer?) As List(Of CategoriaBuscarResult)
        Dim dc As New DC()

        Return dc.CategoriaBuscar(CType(IIf(idCategoria Is Nothing, "R", "H"), Char), idCategoria).ToList()
    End Function

   
    Protected Sub btnFinalizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFinalizar.Click
        Return
    End Sub
End Class