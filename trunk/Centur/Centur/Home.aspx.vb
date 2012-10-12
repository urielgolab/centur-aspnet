Imports Centur.CenturServiceREST

Public Class Home
    Inherits System.Web.UI.Page


    'Protected Sub EjecutarSOAP_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim Centursvc As New CenturServiceSOAPClient()
    '    Me.soap.Text = Centursvc.BuscarServicio2("Flores")
    'End Sub

    Protected Sub EjecutarREST_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim CenturRESTsvc As New CenturServiceRESTClient()
        Me.rest.Text = CenturRESTsvc.BuscarServicio("Flores")
        'just testing
    End Sub

End Class