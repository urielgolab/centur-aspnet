Imports Entities

Public Class GruposService
    Dim oGruposDA As New DataAccessLayer.GruposDA

    Public Function GetGrupos(ByVal idUsuario As Integer, ByVal accion As Char, Optional ByRef mensaje As String = "", Optional ByRef status As Boolean = False) As GrupoList

        Dim ds As DataSet = oGruposDA.GetGrupos(idUsuario, accion, mensaje, status)
        Dim oGrupoList As New GrupoList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oGrupo As New Grupo
            oGrupo.ID = CInt(dr("IdGrupo"))
            oGrupo.Tipo = CChar(dr("tipoGrupo"))
            oGrupo.Nombre = CStr(dr("nombre"))
            oGrupo.Descripcion = CStr(dr("descripcion"))
            oGrupoList.Add(oGrupo)
        Next

        Return oGrupoList

    End Function

    Public Function GetDetalleGrupo(ByVal GrupoId As Integer) As Grupo
        Dim ds As DataSet = oGruposDA.GetDetalleGrupo(GrupoId, "")
        Dim ogrupo As New Grupo

        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)

            ogrupo.ID = CInt(dr("IdGrupo"))
            ogrupo.Tipo = CChar(dr("tipoGrupo"))
            ogrupo.Nombre = CStr(dr("nombre"))
            ogrupo.Descripcion = CStr(dr("descripcion"))
        End If

        If ds.Tables(1).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(1).Rows
                Dim oUsuario As New Usuario
                oUsuario.idUsuario = CInt(dr("idUsuario"))
                oUsuario.NombreUsuario = CStr(dr("nombreUsuario"))
                ogrupo.MiembrosList.Add(oUsuario)
            Next

        End If

        If ds.Tables(2).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(2).Rows
                Dim oServicio As New Servicio
                oServicio.ID = CStr(dr("idServicio"))
                oServicio.Nombre = CStr(dr("nombre"))
                ogrupo.ServicioList.Add(oServicio)
            Next
        End If

        Return ogrupo 'ver excepcion cuando no retorna nada, caso improbable pero bue...

    End Function

    Public Sub UpdateGrupo(ByVal oGrupo As Grupo)
        oGruposDA.UpdateGrupo(oGrupo.ID, oGrupo.Nombre, oGrupo.Descripcion)
    End Sub

    Sub DeleteGrupo(ByVal idGrupo As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)
        oGruposDA.DeleteGrupo(idGrupo, Mensaje, Status)
    End Sub

    Sub RegistrarGrupo(ByVal nombreGrupo As String, ByVal DescripGrupo As String, ByVal idProveedor As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)
        oGruposDA.RegistrarGrupo(nombreGrupo, DescripGrupo, idProveedor, Mensaje, Status)
    End Sub

    Function PuedeAdherir(ByVal idUsuario As Integer, ByVal idGrupo As Integer) As Boolean
        Dim ds As DataSet = oGruposDA.PuedeAdherir(idUsuario, idGrupo)

        Return ds.Tables(0).Rows.Count = 0

    End Function

    Sub AltaAGrupoPendienteAprobacion(ByVal idUsuario As Integer, ByVal idGrupo As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)

        oGruposDA.AsociarUsuarioAGrupo(idUsuario, idGrupo, "P", Mensaje, Status)

    End Sub

    Function esDueño(ByVal idUsuario As Integer, ByVal idGrupo As Integer) As Boolean
        Dim ds As DataSet = oGruposDA.esDueño(idUsuario, idGrupo)
        Return ds.Tables(0).Rows.Count > 0

    End Function

    Function ObtenerPendientes(ByVal idProveedor As Integer) As GrupoPendientesList

        Dim ds As DataSet = oGruposDA.ObtenerPendientes(idProveedor)

        Dim oGrupoPendientesList As New GrupoPendientesList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oGrupoPendientes As New GrupoPendientes
            oGrupoPendientes.IdGrupo = CInt(dr("IdGrupo"))
            oGrupoPendientes.NombreGrupo = CStr(dr("nombreGrupo"))
            oGrupoPendientes.IdUsuario = CInt(dr("idUsuario"))
            oGrupoPendientes.NombreUsuario = CStr(dr("nombreUsuario"))
            oGrupoPendientesList.Add(oGrupoPendientes)
        Next

        Return oGrupoPendientesList
    End Function

    Sub AltaAGrupo(ByVal idGrupo As Integer, ByVal idUsuario As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)
        oGruposDA.AsociarUsuarioAGrupo(idUsuario, idGrupo, "A", Mensaje, Status)
    End Sub

    Sub BajaMiembroAGrupo(ByVal idGrupo As Integer, ByVal idUsuario As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)
        oGruposDA.AsociarUsuarioAGrupo(idUsuario, idGrupo, "B", mensaje, status)
    End Sub

    Sub BajaServicioAGrupo(ByVal idGrupo As Integer, ByVal idServicio As Integer, Optional ByRef Mensaje As String = "", Optional ByRef Status As Boolean = False)

        oGruposDA.AsociarServicioAGrupo(idServicio, idGrupo, "B", mensaje, status)

    End Sub

End Class
