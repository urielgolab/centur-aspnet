Imports BaseClasses
Imports System.Net.Mime.MediaTypeNames

Public Class Servicio

#Region "Attributes"
    Private _id As Integer
    Private _nombre As String
    Private _descripcion As String
    Private _categoria As String
    Private _zona As String
    Private _imagen As Image
    Private _minOffset As Integer
    Private _maxOffset As Integer
#End Region

#Region "Properties"
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
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
    Public Property Categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property
    Public Property Zona() As String
        Get
            Return _zona
        End Get
        Set(ByVal value As String)
            _zona = value
        End Set
    End Property
    Public Property Imagen() As Image
        Get
            Return _imagen
        End Get
        Set(ByVal value As Image)
            _imagen = value
        End Set
    End Property

    Public Property MinOffset() As Integer
        Get
            Return 3
        End Get
        Set(ByVal value As Integer)
            _minOffset = value
        End Set
    End Property

    Public Property MaxOffset() As Integer
        Get
            Return 5 + MinOffset - 1
        End Get
        Set(ByVal value As Integer)
            _maxOffset = value
        End Set
    End Property
#End Region

End Class

Public Class ServicioList
    Inherits BaseSolutionEntityList(Of Servicio)

    'Public Function BindToControl() As List(Of Entities.Servicio)
    '    Return MyBase.BindToControl
    'End Function
End Class
