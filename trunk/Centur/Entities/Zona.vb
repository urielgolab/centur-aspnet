Imports BaseClasses

Public Class Zona

#Region "Attributes"
    Private _idZona As Integer
    Private _nombre As String
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
#End Region

End Class

Public Class ZonaList
    Inherits BaseSolutionEntityList(Of Zona)
End Class