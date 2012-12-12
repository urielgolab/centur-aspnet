Imports Entities

Public Class GruposService
    Dim oGruposDA As New DataAccessLayer.GruposDA

    Public Function GetGruposPropios(ByVal idUsuario As Integer) As GrupoList

        'Falta if para saber si es proveedor
        Dim ds As DataSet = oGruposDA.GetGruposPropios(idUsuario)
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

End Class
