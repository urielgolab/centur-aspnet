﻿Imports BaseClasses
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
    Private _precio As Double
    Private _direccion As String
    Private _observaciones As String
    Private _idProveedor As Integer
    Private _privacidad As Boolean
    Private _envioRecordatorio As Boolean
    Private _sobreturno As Boolean
    Private _tipoConfirmacion As String

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
            Return _minOffset
        End Get
        Set(ByVal value As Integer)
            _minOffset = value
        End Set
    End Property

    Public Property MaxOffset() As Integer
        Get
            Return _maxOffset + _minOffset - 1
        End Get
        Set(ByVal value As Integer)
            _maxOffset = value
        End Set
    End Property

    Public Property Precio() As Integer
        Get
            Return _precio
        End Get
        Set(ByVal value As Integer)
            _precio = value
        End Set
    End Property

    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    Public Property IDProveedor() As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
        End Set
    End Property

    Public Property Privacidad() As Boolean
        Get
            Return _privacidad
        End Get
        Set(ByVal value As Boolean)
            _privacidad = value
        End Set
    End Property

    Public Property EnvioRecordatorio() As Boolean
        Get
            Return _envioRecordatorio
        End Get
        Set(ByVal value As Boolean)
            _envioRecordatorio = value
        End Set
    End Property

    Public Property Sobreturno() As Boolean
        Get
            Return _sobreturno
        End Get
        Set(ByVal value As Boolean)
            _sobreturno = value
        End Set
    End Property

    Public Property TipoConfirmacion() As String
        Get
            Return _tipoConfirmacion
        End Get
        Set(ByVal value As String)
            _tipoConfirmacion = value
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
