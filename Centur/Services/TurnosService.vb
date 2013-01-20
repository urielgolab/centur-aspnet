Imports Entities

Public Class TurnosService

    Dim oTurnosDA As New DataAccessLayer.TurnosDA

    Function VerTurnosCliente(ByVal idUsuario As Integer) As TurnoList
        Dim ds As DataSet = oTurnosDA.verTurnosCliente(idUsuario)
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

    Function VerTurnosProveedor(ByVal idServicio As Integer, ByVal confirmado As Integer) As TurnoList
        Dim oTurnoList As New TurnoList
        Dim ds As DataSet
        ds = oTurnosDA.verTurnosServicio(idServicio, confirmado)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim oTurno As New Turno
            oTurno.idTurno = CInt(dr("idturno"))
            oTurno.Fecha = CStr(dr("fecha"))
            oTurno.horaInicio = dr("horaInicio").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.horaFin = dr("horaFin").ToString().Substring(0, 5).Replace(":", ".")
            oTurno.ClienteNombre = CStr(dr("nombreUsuario"))


            oTurnoList.Add(oTurno)
        Next

        Return oTurnoList


    End Function

    Sub AceptarTurno(ByVal idTurno As Integer)
        oTurnosDA.TurnoAdministrar(idTurno, "A")
    End Sub

End Class
