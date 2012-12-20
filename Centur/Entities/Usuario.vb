Imports BaseClasses

Public Class Usuario

#Region "Attributes"
    Private _idUsuario As Integer
    Private _nombreUsuario As String
    Private _nombre As String
    Private _apellido As String
    Private _contraseña As String
    Private _tipoUsuario As String
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

    Public Property NombreUsuario() As String
        Get
            Return _nombreUsuario
        End Get
        Set(ByVal value As String)
            _nombreUsuario = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Public Property TipoUsuario() As String
        Get
            Return _tipoUsuario
        End Get
        Set(ByVal value As String)
            _tipoUsuario = value
        End Set
    End Property


#End Region

End Class

Public Class UsuarioList
    Inherits BaseSolutionEntityList(Of Usuario)
End Class
