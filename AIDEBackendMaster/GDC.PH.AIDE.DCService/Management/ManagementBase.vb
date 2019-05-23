Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public MustInherit Class ManagementBase
    Public MustOverride Function GetStateData(status As NotifyType, ByVal Optional data As Object = Nothing, ByVal Optional message As String = "") As StateData
    Public MustOverride Function GetMappedFields(ByVal objData As Object) As Object
    Public MustOverride Function GetExceptionMessage(ByVal ex As Exception) As String
    Public MustOverride Sub SetFields(ByRef objResult As Object, ByVal objData As Object)

End Class

Public Enum NotifyType
    IsSuccess
    IsError
End Enum


Public Class ResponseReceivedEventArgs
    Inherits EventArgs
    Private m_notifyType As NotifyType
    Public Property notifyType() As NotifyType
        Get
            Return m_notifyType
        End Get
        Set
            m_notifyType = Value
        End Set
    End Property
    Private m_DataReceived As StateData
    Public Property DataReceived() As StateData
        Get
            Return m_DataReceived
        End Get
        Set
            m_DataReceived = Value
        End Set
    End Property


    Public Sub New(status As NotifyType, data As StateData)
        Me.notifyType = status
        Me.DataReceived = data
    End Sub
End Class

Public Class StateData
    Private m_NotifyType As NotifyType
    Private m_message As String = ""
    Private m_data As Object = Nothing

    Public Sub New()

    End Sub
    Public Sub New(notifyType As NotifyType, message As String, data As Object)
        m_NotifyType = notifyType
        m_message = message
        m_data = data
    End Sub

    Public Property NotifyType() As NotifyType
        Get
            Return m_NotifyType
        End Get
        Set
            m_NotifyType = Value
        End Set
    End Property

    Public Property Message() As String
        Get
            Return m_message
        End Get
        Set
            m_message = Value
        End Set
    End Property

    Public Property Data() As Object
        Get
            Return m_data
        End Get
        Set
            m_data = Value
        End Set
    End Property
End Class
