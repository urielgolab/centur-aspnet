Public Class MiCuenta
    Inherits System.Web.UI.Page

    Dim oLoginService As New Services.LoginService()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim oUsuario As Entities.Usuario = oLoginService.GetUserInfo(CType(Session("Usuario"), Entities.Usuario).NombreUsuario)

            Me.NombreUsuario.Text = oUsuario.NombreUsuario
            'Me.Password.Text = oUsuario.Password
            Me.Telefono.Text = oUsuario.Telefono
            If oUsuario.TipoUsuario = "P" Then
                TipoUsuario.SelectedIndex = 0
            Else
                TipoUsuario.SelectedIndex = 1
            End If
            Me.Nombre.Text = oUsuario.Nombre
            Me.Apellido.Text = oUsuario.Apellido
            Me.Email.Text = oUsuario.Email

            Me.NombreUsuario.Enabled = False
            TipoUsuario.Enabled = False

        End If
    End Sub

    Private Sub Registrarse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Registrarse.Click
        Dim Mensaje As String = ""
        Dim Status As Boolean

        Dim rolUsuario As String = CStr(TipoUsuario.SelectedValue)

        Dim oUsuario As Entities.Usuario = oLoginService.RegistrarUsuario(Me.NombreUsuario.Text, "", Me.Telefono.Text, rolUsuario, Me.Nombre.Text, Me.Apellido.Text, Me.Email.Text, "M", Mensaje, Status)

        If Status = False Then
            Session("Usuario") = oUsuario
            'Mostrar mensaje de exito

            Response.Redirect("~/Home.aspx")
        Else
            'Mostrar mensaje de error.
            ErrorMessage.Text = Mensaje
        End If


    End Sub

End Class