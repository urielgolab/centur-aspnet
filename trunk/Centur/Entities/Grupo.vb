Imports BaseClasses
Imports System.Net.Mime.MediaTypeNames

Public Class Grupo

#Region "Attributes"
    Private _id As Integer
    Private _tipo As Char
    Private _nombre As String
    Private _descripcion As String
    Private _miembrosList As List(Of Usuario)
    Private _serviciosList As List(Of Servicio)
    Private _usuarioEstaEnGrupo As Boolean
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

    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
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
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property MiembrosList() As List(Of Usuario)
        Get
            Return _miembrosList
        End Get

        Set(ByVal value As List(Of Usuario))
            _miembrosList = value
        End Set
    End Property

    Public Property ServicioList() As List(Of Servicio)
        Get
            Return _serviciosList
        End Get

        Set(ByVal value As List(Of Servicio))
            _serviciosList = value
        End Set
    End Property

    Public Property usuarioEstaEnGrupo() As Boolean
        Get
            Return _usuarioEstaEnGrupo
        End Get
        Set(ByVal value As Boolean)
            _usuarioEstaEnGrupo = value
        End Set
    End Property


#End Region


    Public Sub New()
        _miembrosList = New List(Of Usuario)
        _serviciosList = New List(Of Servicio)
    End Sub

End Class

Public Class GrupoList
    Inherits BaseSolutionEntityList(Of Grupo)

    'Public Function BindToControl() As List(Of Entities.Servicio)
    '    Return MyBase.BindToControl
    'End Function
End Class
