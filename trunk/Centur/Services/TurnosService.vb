Imports Entities

Public Class TurnosService

    Dim oTurnosDA As New DataAccessLayer.TurnosDA

    Function VerTurnosCliente(ByVal idUsuario As Integer) As TurnoList
        Dim ds As DataSet = oTurnosDA.verTurnosCliente(idUsuario, 1)
        Dim oTurnoList As New TurnoList

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oTurno As New Turno
            oTurno.idTurno = CInt(dr("idturno"))
            oTurno.Fecha = CStr(dr("fecha"))
            oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.ServicioID = CInt(dr("idServicio"))
            oTurno.ServicioNombre = CStr(dr("nombre"))


            oTurnoList.Add(oTurno)
        Next

        Return oTurnoList
    End Function

    Sub CancelarTurno(ByVal idTurno As Integer)
        oTurnosDA.TurnoAdministrar(idTurno, "B")
    End Sub

End Class
