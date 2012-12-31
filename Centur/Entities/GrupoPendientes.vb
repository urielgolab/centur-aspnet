Imports BaseClasses
Imports System.Net.Mime.MediaTypeNames

Public Class GrupoPendientes

#Region "Attributes"
    Private _idGrupo As Integer
    Private _nombreGrupo As String
    Private _idUsuario As Integer
    Private _nombreUsuario As String
#End Region

#Region "Properties"
    Public Property IdGrupo() As Integer
        Get
            Return _idGrupo
        End Get
        Set(ByVal value As Integer)
            _idGrupo = value
        End Set
    End Property

    Public Property NombreGrupo() As String
        Get
            Return _nombreGrupo
        End Get
        Set(ByVal value As String)
            _nombreGrupo = value
        End Set
    End Property

    Public Property IdUsuario() As Integer
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

#End Region

End Class

Public Class GrupoPendientesList
    Inherits BaseSolutionEntityList(Of GrupoPendientes)

    'Public Function BindToControl() As List(Of Entities.Servicio)
    '    Return MyBase.BindToControl
    'End Function
End Class
