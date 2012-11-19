Imports BaseClasses

Public Class Categoria

#Region "Attributes"
    Private _idCategoria As Integer
    Private _nombre As String
#End Region


#Region "Properties"

    Public Property IDCategoria() As Integer
        Get
            Return _idCategoria
        End Get
        Set(ByVal value As Integer)
            _idCategoria = value
        End Set
    End Property

    Public Property NombreCategoria() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
#End Region

End Class

Public Class CategoriaList
    Inherits BaseSolutionEntityList(Of Categoria)
End Class