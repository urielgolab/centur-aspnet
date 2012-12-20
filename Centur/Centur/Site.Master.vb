Public Class Site1
    Inherits System.Web.UI.MasterPage

    Dim oLoginService As New Services.LoginService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Usuario") Is Nothing Then
            Me.ArmarMenu(CType(Session("Usuario"), Entities.Usuario).TipoUsuario)
        Else
            Me.ArmarMenu("")
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
            NavigationMenu.Items.Add(New MenuItem("Inicio", "Inicio", "", "Home.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Buscar Servicio", "Buscar Servicio", "", "BuscarServicio.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Mis Grupos", "Mis Grupos", "", "MisGrupos.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Mis Turnos", "Mis Turnos", "", "MisTurnos.aspx"))
            NavigationMenu.Items.Add(New MenuItem("Favoritos", "Favoritos", "", "Favoritos.aspx"))

            If TipoUsuario = "P" Then
                'Solo Proveedor
                NavigationMenu.Items.Add(New MenuItem("Estadisticas", "Estadisticas", "", "VerEstadisticas.aspx"))
            End If
        End If
    End Sub


End Class