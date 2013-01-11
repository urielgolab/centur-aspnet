Imports BaseClasses

Public Class Turno

#Region "Attributes"
    Private _idTurno As Integer
    Private _horaInicio As String
    Private _horaFin As String
    Private _disponible As Boolean
    Private _fecha As String
    Private _servicioID As Integer
    Private _servicioNombre As String
    Private _clienteNombre As String
#End Region


#Region "Properties"
    Public Property idTurno() As Integer
        Get
            Return _idTurno
        End Get
        Set(ByVal value As Integer)
            _idTurno = value
        End Set
    End Property

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

    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property


    Public Property ServicioID() As Integer
        Get
            Return _servicioID
        End Get
        Set(ByVal value As Integer)
            _servicioID = value
        End Set
    End Property

    Public Property ServicioNombre() As String
        Get
            Return _servicioNombre
        End Get
        Set(ByVal value As String)
            _servicioNombre = value
        End Set
    End Property

    Public Property ClienteNombre() As String
        Get
            Return _clienteNombre
        End Get
        Set(ByVal value As String)
            _clienteNombre = value
        End Set
    End Property

#End Region

End Class


Public Class TurnoList
    Inherits BaseSolutionEntityList(Of Turno)
End Class
