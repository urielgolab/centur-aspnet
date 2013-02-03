﻿Public Class Site1
    Inherits System.Web.UI.MasterPage

    Dim oLoginService As New Services.LoginService()

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not Session("Usuario") Is Nothing Then
            Dim user As Entities.Usuario = Session("Usuario")

            Me.ArmarMenu(user.TipoUsuario)
            logout.Visible = True
            miCuenta.Visible = True

            logout.Text = "Desloguearse [" + user.NombreUsuario.ToLower() + "]"
        Else
            Dim starray As String() = Request.Url.AbsolutePath.Split("/")
            Dim strActualPage As String = starray(starray.Length - 1)
            If strActualPage <> "Login.aspx" AndAlso strActualPage <> "Registrer.aspx" Then
                Response.Redirect("Login.aspx")
            Else
                Me.ArmarMenu("")
            End If
        End If
    End Sub

    Public Sub ArmarMenu(ByVal TipoUsuario As String)
        If TipoUsuario = "" Then
            'Antes de loguearse
            NavigationMenu.Items.Add(New MenuItem("Iniciar Sesión", "Iniciar Sesión", "", "Login.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Registrarse", "Registrarse", "", "Registrer.aspx"))
            'NavigationMenu.Items.Add(New MenuItem("Buscar Servicio", "Buscar Servicio", "", "BuscarServicio.aspx"))
        Else
            'Proveedor y Cliente
            NavigationMenu.Items.Add(New MenuItem("Inicio", "Inicio", "", "Default.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Mis Grupos", "Mis Grupos", "", "MisGrupos.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Mis Turnos", "Mis Turnos", "", "MisTurnos.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Buscar Servicio", "Buscar Servicio", "", "BuscarServicio.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Favoritos", "Favoritos", "", "Favoritos.aspx"))


            If TipoUsuario = "P" Then
                'Solo Proveedor
                NavigationMenu.Items.Add(New MenuItem("Estadisticas", "Estadisticas", "", "VerEstadisticas.aspx"))
                NavigationMenu.Items.AddAt(1, New MenuItem("Mis Servicios", "Mis Servicios", "", "MisServicios.aspx"))
            End If
        End If
    End Sub



    Private Sub logout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles logout.Click
        Session("Usuario") = Nothing
        Response.Redirect("default.aspx")
    End Sub
End Class