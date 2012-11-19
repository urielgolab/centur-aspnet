Imports BaseClasses

Public Class JSONResult

#Region "Attributes"
    Private _estado As Boolean
    Private _mensaje As String
    Private _body As Object
#End Region


#Region "Properties"

    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property

    Public Property Body() As Object
        Get
            Return _body
        End Get
        Set(ByVal value As Object)
            _body = value
        End Set
    End Property

#End Region

End Class
