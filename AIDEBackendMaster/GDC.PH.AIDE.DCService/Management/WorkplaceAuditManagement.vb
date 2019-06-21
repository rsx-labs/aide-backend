Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class WorkplaceAuditManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objWorkplaceAudit As WorkplaceAuditSet = DirectCast(objData, WorkplaceAuditSet)
        Dim workplaceData As New WorkplaceAudit

        workplaceData.AUDIT_DAILY_ID = objWorkplaceAudit.AUDIT_DAILY_ID
        workplaceData.AUDIT_QUESTIONS_ID = objWorkplaceAudit.AUDIT_QUESTIONS_ID
        workplaceData.EMP_ID = objWorkplaceAudit.EMP_ID
        workplaceData.FY_WEEK = objWorkplaceAudit.FY_WEEK
        workplaceData.STATUS = objWorkplaceAudit.STATUS
        workplaceData.DT_CHECKED = objWorkplaceAudit.DT_CHECKED
        workplaceData.AUDIT_QUESTIONS = objWorkplaceAudit.AUDIT_QUESTIONS
        workplaceData.OWNER = objWorkplaceAudit.OWNER
        workplaceData.AUDIT_QUESTIONS_GROUP = objWorkplaceAudit.AUDIT_QUESTIONS_GROUP
        Return workplaceData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertAuditDaily(ByVal workplaceAudit As WorkplaceAudit) As StateData
        Dim WorkplaceAuditSet As New WorkplaceAuditSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(WorkplaceAuditSet, workplaceAudit)
            If WorkplaceAuditSet.InsertAuditDaily(WorkplaceAuditSet) Then
                status = NotifyType.IsSuccess
                message = "Create workplaceAudit Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAuditDaily(empID As Integer, parmDate As Date) As StateData
        Dim WorkplaceAuditSet As New WorkplaceAuditSet
        Dim lstWorkplaceAudit As List(Of WorkplaceAuditSet)
        Dim objWorkplaceAudit As New List(Of WorkplaceAudit)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstWorkplaceAudit = WorkplaceAuditSet.GetAuditDaily(empID, parmDate)

            If Not IsNothing(lstWorkplaceAudit) Then
                For Each objList As WorkplaceAuditSet In lstWorkplaceAudit
                    objWorkplaceAudit.Add(DirectCast(GetMappedFields(objList), WorkplaceAudit))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objWorkplaceAudit, message)
        Return state
    End Function

    Public Function GetAuditQuestions(empID As Integer, questionGroup As String) As StateData
        Dim WorkplaceAuditSet As New WorkplaceAuditSet
        Dim lstWorkplaceAudit As List(Of WorkplaceAuditSet)
        Dim objWorkplaceAudit As New List(Of WorkplaceAudit)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstWorkplaceAudit = WorkplaceAuditSet.GetAuditQuestions(empID, questionGroup)

            If Not IsNothing(lstWorkplaceAudit) Then
                For Each objList As WorkplaceAuditSet In lstWorkplaceAudit
                    objWorkplaceAudit.Add(DirectCast(GetMappedFields(objList), WorkplaceAudit))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objWorkplaceAudit, message)
        Return state
    End Function

    'Public Function UpdateAuditSched(ByVal AuditSched As AuditSched) As StateData
    '    Dim WorkplaceAuditSet As New WorkplaceAuditSet
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType

    '    Try
    '        SetFields(WorkplaceAuditSet, AuditSched)
    '        If WorkplaceAuditSet.UpdateAuditSched(WorkplaceAuditSet) Then
    '            status = NotifyType.IsSuccess
    '            message = "Update AuditSched Information successful!"
    '        End If

    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '    End Try
    '    state = GetStateData(status, Nothing, message)
    '    Return state
    'End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional ByVal data As Object = Nothing, Optional ByVal message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objWorkplaceAudit As WorkplaceAudit = DirectCast(objData, WorkplaceAudit)
        Dim workplaceData As New WorkplaceAuditSet

        workplaceData.AUDIT_QUESTIONS_ID = objWorkplaceAudit.AUDIT_QUESTIONS_ID
        workplaceData.EMP_ID = objWorkplaceAudit.EMP_ID
        workplaceData.FY_WEEK = objWorkplaceAudit.FY_WEEK
        workplaceData.STATUS = objWorkplaceAudit.STATUS
        workplaceData.DT_CHECKED = objWorkplaceAudit.DT_CHECKED
        workplaceData.AUDIT_QUESTIONS = objWorkplaceAudit.AUDIT_QUESTIONS
        workplaceData.OWNER = objWorkplaceAudit.OWNER
        workplaceData.AUDIT_QUESTIONS_GROUP = objWorkplaceAudit.AUDIT_QUESTIONS_GROUP

        objResult = workplaceData
    End Sub
End Class
