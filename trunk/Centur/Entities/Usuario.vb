Imports BaseClasses

Public Class Usuario

#Region "Attributes"
    Private _idUsuario As Integer
    Private _nombreUsuario As String
    Private _rolUsuario As String
#End Region

#Region "Properties"
    Public Property idUsuario() As Integer
        Get
            Return _idUsuario
        End Get
        Set(ByVal value As Integer)
            _idUsuario = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _nombreUsuario
        End Get
        Set(ByVal value As String)
            _nombreUsuario = value
        End Set
    End Property

#End Region

End Class

Public Class UsuarioList
    Inherits BaseSolutionEntityList(Of Usuario)
End Class
