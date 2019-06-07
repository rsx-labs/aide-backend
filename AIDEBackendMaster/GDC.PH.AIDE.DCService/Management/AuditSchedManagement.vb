Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class AuditSchedManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objAuditSched As AuditSchedSet = DirectCast(objData, AuditSchedSet)
        Dim auditSchedData As New AuditSched
        auditSchedData.AUDIT_SCHED_ID = objAuditSched.AUDIT_SCHED_ID
        auditSchedData.EMP_ID = objAuditSched.EMP_ID
        auditSchedData.FY_WEEK = objAuditSched.FY_WEEK
        auditSchedData.PERIOD_START = objAuditSched.PERIOD_START
        auditSchedData.PERIOD_END = objAuditSched.PERIOD_END
        auditSchedData.DAILY = objAuditSched.DAILY
        auditSchedData.WEEKLY = objAuditSched.WEEKLY
        auditSchedData.MONTHLY = objAuditSched.MONTHLY
        auditSchedData.FY_START = objAuditSched.FY_START
        auditSchedData.FY_END = objAuditSched.FY_END

        Return auditSchedData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertAuditSched(ByVal AuditSched As AuditSched) As StateData
        Dim AuditSchedSet As New AuditSchedSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(AuditSchedSet, AuditSched)
            If AuditSchedSet.InsertAuditSched(AuditSchedSet) Then
                status = NotifyType.IsSuccess
                message = "Create AuditSched Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAuditSched(empID As Integer, year As Integer) As StateData
        Dim AuditSchedSet As New AuditSchedSet
        Dim lstAuditSched As List(Of AuditSchedSet)
        Dim objAuditSched As New List(Of AuditSched)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAuditSched = AuditSchedSet.GetAuditSched(empID, year)

            If Not IsNothing(lstAuditSched) Then
                For Each objList As AuditSchedSet In lstAuditSched
                    objAuditSched.Add(DirectCast(GetMappedFields(objList), AuditSched))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAuditSched, message)
        Return state
    End Function

    Public Function UpdateAuditSched(ByVal AuditSched As AuditSched) As StateData
        Dim AuditSchedSet As New AuditSchedSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(AuditSchedSet, AuditSched)
            If AuditSchedSet.UpdateAuditSched(AuditSchedSet) Then
                status = NotifyType.IsSuccess
                message = "Update AuditSched Information successful!"
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
        Dim objAuditSched As AuditSched = DirectCast(objData, AuditSched)
        Dim auditSchedData As New AuditSchedSet

        auditSchedData.YEAR = objAuditSched.YEAR
        auditSchedData.AUDIT_SCHED_ID = objAuditSched.AUDIT_SCHED_ID
        auditSchedData.EMP_ID = objAuditSched.EMP_ID
        auditSchedData.PERIOD_START = objAuditSched.PERIOD_START
        auditSchedData.PERIOD_END = objAuditSched.PERIOD_END
        auditSchedData.DAILY = objAuditSched.DAILY
        auditSchedData.WEEKLY = objAuditSched.WEEKLY
        auditSchedData.MONTHLY = objAuditSched.MONTHLY
        auditSchedData.FY_START = objAuditSched.FY_START
        auditSchedData.FY_END = objAuditSched.FY_END

        objResult = auditSchedData
    End Sub
End Class
