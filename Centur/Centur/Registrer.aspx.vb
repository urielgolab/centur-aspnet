﻿
Public Class Registrer
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Private Sub Registrarse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Registrarse.Click
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim rolUsuario As String = CStr(TipoUsuario.SelectedValue)

        Dim oUsuario As Entities.Usuario = oLoginService.RegistrarUsuario(Me.NombreUsuario.Text, Me.Password.Text, Me.Telefono.Text, rolUsuario, Me.Nombre.Text, Me.Apellido.Text, Me.Email.Text, Mensaje, Status)

        If Status = False Then
            'Cargar todas las propiedades del usuario en variable de sesion / variable global.
            'Mostrar mensaje de exito
            Login1.idUsuarioGlobal = oUsuario.idUsuario

            Response.Redirect("~/Home.aspx")
        Else
            'Mostrar mensaje de error.
            ErrorMessage.Text = Mensaje
        End If


    End Sub
End Class