Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Public Class MessageManagement
    Inherits ManagementBase


    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objMessage As MessageSet = DirectCast(objData, MessageSet)
        Dim messageData As New MessageDetail
        messageData.MESSAGE_DESCR = objMessage.MESSAGE_DESCR
        messageData.TITLE = objMessage.TITLE

        Return messageData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
    Public Function GetAllMessage(msgID As Integer, secID As Integer) As StateData
        Dim MessageSet As New MessageSet
        Dim lstMessage As List(Of MessageSet)
        Dim objMessage As New List(Of MessageDetail)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstMessage = MessageSet.GetAllMessage(msgID, secID)

            If Not IsNothing(lstMessage) Then
                For Each objList As MessageSet In lstMessage
                    objMessage.Add(DirectCast(GetMappedFields(objList), MessageDetail))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objMessage, message)
        Return state
    End Function


    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)

    End Sub
End Class
