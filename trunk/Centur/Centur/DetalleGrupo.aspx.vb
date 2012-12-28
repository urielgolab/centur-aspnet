Imports Entities

Public Class DetalleGrupo
    Inherits System.Web.UI.Page

    Dim oGruposService As New Services.GruposService()
    Dim oGrupo As New Grupo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        End If

        If (oGruposService.PuedeAdherir(CType(Session("Usuario"), Entities.Usuario).idUsuario, CInt(Request.QueryString("id")))) Then
            Adherir.Visible = True
        End If

        oGrupo = oGruposService.GetDetalleGrupo(CInt(Request.QueryString("id")))
        NombreGrupo.Text = oGrupo.Nombre
        DescripGrupo.Text = oGrupo.Descripcion

        ListBox1.DataSource = oGrupo.MiembrosList
        ListBox1.DataTextField = "NombreUsuario"
        ListBox1.DataValueField = "idUsuario"
        ListBox1.DataBind()

        'falta miembros implementar pablo

    End Sub

   
    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Adherir.Click
        Dim Mensaje As String = ""
        Dim Status As Boolean

        oGruposService.AltaAGrupoPendienteAprobacion(CType(Session("Usuario"), Entities.Usuario).idUsuario, CInt(Request.QueryString("id")), Mensaje, Status)
        Response.Redirect("~/DetalleGrupo.aspx?id=" & CInt(Request.QueryString("id")))

    End Sub
End Class