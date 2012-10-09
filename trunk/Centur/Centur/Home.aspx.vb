Imports Centur.CenturWebReference

Public Class Home
    Inherits System.Web.UI.Page


    Protected Sub Saludar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim name As String = Me.nombre.Text
        Dim Centursvc As New Service1Client()
        Me.nombre.Text = Centursvc.Saludar(name)

    End Sub
End Class