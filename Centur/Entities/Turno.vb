Imports BaseClasses

Public Class Turno

#Region "Attributes"
    Private _horaInicio As String
    Private _horaFin As String
    Private _disponible As Boolean
#End Region


#Region "Properties"
    Public Property horaInicio() As String
        Get
            Return _horaInicio
        End Get
        Set(ByVal value As String)
            _horaInicio = value
        End Set
    End Property

    Public Property horaFin() As String
        Get
            Return _horaFin
        End Get
        Set(ByVal value As String)
            _horaFin = value
        End Set
    End Property

    Public Property Disponible() As Boolean
        Get
            Return _disponible
        End Get
        Set(ByVal value As Boolean)
            _disponible = value
        End Set
    End Property

#End Region

End Class


Public Class TurnoList
    Inherits BaseSolutionEntityList(Of Turno)
End Class
