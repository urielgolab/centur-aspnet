Imports System.Diagnostics
Imports System.IO
Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mProcess As New Process
        Try
            Dim strAplicacion As String = "Calc.exe"

            mProcess.Start(strAplicacion)
            lblRespuesta.Text = "Actualizado correctamente"
            lblRespuesta.ForeColor = Drawing.Color.Green
        Catch ex As Exception
            lblRespuesta.Text = ex.Message
            lblRespuesta.ForeColor = Drawing.Color.Red
        End Try



    End Sub

End Class