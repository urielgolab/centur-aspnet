﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.269
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace CenturServiceREST
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="CenturServiceREST.ICenturServiceREST")>  _
    Public Interface ICenturServiceREST
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/ICenturServiceREST/BuscarServicio", ReplyAction:="http://tempuri.org/ICenturServiceREST/BuscarServicioResponse")>  _
        Function BuscarServicio(ByVal zona As String) As String
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface ICenturServiceRESTChannel
        Inherits CenturServiceREST.ICenturServiceREST, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class CenturServiceRESTClient
        Inherits System.ServiceModel.ClientBase(Of CenturServiceREST.ICenturServiceREST)
        Implements CenturServiceREST.ICenturServiceREST
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function BuscarServicio(ByVal zona As String) As String Implements CenturServiceREST.ICenturServiceREST.BuscarServicio
            Return MyBase.Channel.BuscarServicio(zona)
        End Function
    End Class
End Namespace
