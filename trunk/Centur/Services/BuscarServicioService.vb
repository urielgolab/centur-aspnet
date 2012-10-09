Imports DataAccessLayer

Public Class BuscarServicioService

    Dim oBuscarServicioDA As New BuscarServicioDA()

    Public Sub BuscarServicio(ByVal ServicioID As Integer)
        Dim ds As DataSet = oBuscarServicioDA.BuscarServicio(ServicioID)


    End Sub

End Class
