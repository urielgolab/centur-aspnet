Imports base
Imports System.Net.Mime.MediaTypeNames

Public Class Servicio

#Region "Attributes"
    Private _id As Integer
    Private _nombre As String
    Private _descripcion As String
    Private _categoria As String
    Private _zona As Integer
    Private _imagen As Image
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
#End Region

End Class

Public Class TqlList
    Inherits BaseSolutionEntityList(Of TQL)

    Public Function BindToControl() As List(Of Entities.TQL)
        Return MyBase.BindToControl
    End Function
End Class
