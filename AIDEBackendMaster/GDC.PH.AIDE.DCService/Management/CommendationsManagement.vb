Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class CommendationsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objCommendations As CommendationsSet = DirectCast(objData, CommendationsSet)
        Dim commendationsData As New Commendations
        commendationsData.COMMEND_ID = objCommendations.COMMEND_ID
        commendationsData.DEPT_ID = objCommendations.DEPT_ID
        commendationsData.EMPLOYEE = objCommendations.EMPLOYEE
        commendationsData.PROJECT = objCommendations.PROJECT
        commendationsData.DATE_SENT = objCommendations.DATE_SENT
        commendationsData.SENT_BY = objCommendations.SENT_BY
        commendationsData.REASON = objCommendations.REASON

        Return commendationsData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertCommendations(ByVal commendations As Commendations) As StateData
        Dim commendationsSet As New CommendationsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(commendationsSet, commendations)
            If commendationsSet.InsertCommendations(commendationsSet) Then
                status = NotifyType.IsSuccess
                message = "Create Commendations Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetCommendations(deptID As Integer) As StateData
        Dim commendationsSet As New CommendationsSet
        Dim lstCommendations As List(Of CommendationsSet)
        Dim objCommendations As New List(Of Commendations)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstCommendations = commendationsSet.GetCommendations(deptID)

            If Not IsNothing(lstCommendations) Then
                For Each objList As CommendationsSet In lstCommendations
                    objCommendations.Add(DirectCast(GetMappedFields(objList), Commendations))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objCommendations, message)
        Return state
    End Function

    Public Function UpdateCommendations(ByVal commendations As Commendations) As StateData
        Dim commendationsSet As New CommendationsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(commendationsSet, commendations)
            If commendationsSet.UpdateCommendations(commendationsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Commendations Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional ByVal data As Object = Nothing, Optional ByVal message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objCommendations As Commendations = DirectCast(objData, Commendations)
        Dim commendationsData As New CommendationsSet
        commendationsData.COMMEND_ID = objCommendations.COMMEND_ID
        commendationsData.DEPT_ID = objCommendations.DEPT_ID
        commendationsData.EMPLOYEE = objCommendations.EMPLOYEE
        commendationsData.PROJECT = objCommendations.PROJECT
        commendationsData.DATE_SENT = objCommendations.DATE_SENT
        commendationsData.SENT_BY = objCommendations.SENT_BY
        commendationsData.REASON = objCommendations.REASON
        objResult = commendationsData
    End Sub
End Class
