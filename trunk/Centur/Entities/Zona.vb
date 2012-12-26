Imports BaseClasses

Public Class Zona

#Region "Attributes"
    Private _idZona As Integer
    Private _nombre As String
    Private _tieneHijos As Boolean
#End Region


#Region "Properties"

    Public Property IDZona() As Integer
        Get
            Return _idZona
        End Get
        Set(ByVal value As Integer)
            _idZona = value
        End Set
    End Property

    Public Property NombreZona() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property TieneHijos() As Boolean
        Get
            Return _tieneHijos
        End Get
        Set(ByVal value As Boolean)
            _tieneHijos = value
        End Set
    End Property

#End Region

End Class

Public Class ZonaList
    Inherits BaseSolutionEntityList(Of Zona)
End Class