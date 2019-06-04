Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class WeeklyReportManagement
    Inherits ManagementBase

    Public Function CreateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport)) As StateData
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            For Each objReports As WeeklyReport In weeklyReport
                InsertWeeklyReport(objReports)
            Next
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function InsertWeeklyReport(ByVal objReports As WeeklyReport) As StateData
        Dim weeklyReportSet As New WeeklyReportSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(weeklyReportSet, objReports) 'ERROR: Unable to cast object of type 'GDC.WeServ.EPAD.DCService.AssignedProject' to type 'GDC.WeServ.EPAD.DCService.Project'.
            If weeklyReportSet.InsertWeeklyReport(weeklyReportSet) Then
                status = NotifyType.IsSuccess
                message = "Create weekly report successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport)) As StateData
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            For Each objReports As WeeklyReport In weeklyReport
                UpdateWeeklyReports(objReports)
            Next
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateWeeklyReports(ByVal objReports As WeeklyReport) As StateData
        Dim weeklyReportSet As New WeeklyReportSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(weeklyReportSet, objReports) 'ERROR: Unable to cast object of type 'GDC.WeServ.EPAD.DCService.AssignedProject' to type 'GDC.WeServ.EPAD.DCService.Project'.
            If weeklyReportSet.UpdateWeeklyReport(weeklyReportSet) Then
                status = NotifyType.IsSuccess
                message = "Create weekly report successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function CreateWeekRange(ByVal weekRange As WeekRange) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetWeekRangeFields(weekRangeSet, weekRange)
            If weekRangeSet.InsertWeekRange() Then
                status = NotifyType.IsSuccess
                message = "Create weekly report successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetWeekRange(currentDate As Date, empID As Integer) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim weekRangeSetList As List(Of WeekRangeSet)
        Dim objWeekRange As New List(Of WeekRange)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weekRangeSetList = weekRangeSet.GetWeekRange(currentDate, empID)

            If Not IsNothing(weekRangeSetList) Then
                For Each objList As WeekRangeSet In weekRangeSetList
                    objWeekRange.Add(DirectCast(GetWeekRangeMappedFields(objList), WeekRange))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objWeekRange, message)
        Return state
    End Function

    Public Function GetWeeklyReportsByEmpID(empID As Integer) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim weekRangeSetList As List(Of WeekRangeSet)
        Dim objWeekRange As New List(Of WeekRange)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weekRangeSetList = weekRangeSet.GetWeeklyReportsByEmpID(empID)

            If Not IsNothing(weekRangeSetList) Then
                For Each objList As WeekRangeSet In weekRangeSetList
                    objWeekRange.Add(DirectCast(GetWeekRangeMappedFields(objList), WeekRange))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objWeekRange, message)
        Return state
    End Function

    Public Function GetWeeklyReportsByWeekRangeID(weekRangeID As Integer, empID As Integer) As StateData
        Dim weeklyReportSet As New WeeklyReportSet
        Dim weeklyReportSetList As List(Of WeeklyReportSet)
        Dim objWeeklyReport As New List(Of WeeklyReport)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weeklyReportSetList = weeklyReportSet.GetWeeklyReportsByWeekRangeID(weekRangeID, empID)

            If Not IsNothing(weeklyReportSetList) Then
                For Each objList As WeeklyReportSet In weeklyReportSetList
                    objWeeklyReport.Add(DirectCast(GetMappedFields(objList), WeeklyReport))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objWeeklyReport, message)
        Return state
    End Function

    'Public Function GetTasksAll() As StateData
    '    Dim tasksSet As New TasksSet
    '    Dim lstTasks As List(Of TasksSet)
    '    Dim objTasks As New List(Of Tasks)
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType

    '    Try
    '        lstTasks = tasksSet.GetAllTasks()

    '        If Not IsNothing(lstTasks) Then
    '            For Each objList As TasksSet In lstTasks
    '                objTasks.Add(DirectCast(GetMappedFields(objList), Tasks))
    '            Next
    '            status = NotifyType.IsSuccess
    '        End If

    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '        message = GetExceptionMessage(ex)
    '    End Try
    '    state = GetStateData(status, objTasks, message)
    '    Return state
    'End Function

    'Public Function ViewMyTasks(ByVal empId As Integer) As StateData
    '    Dim tasksSet As New TasksSet
    '    Dim lstTaskSet As New List(Of TasksSet)
    '    Dim lstTasks As New List(Of Tasks)
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType
    '    Try
    '        lstTaskSet = tasksSet.getMyTasks(empId)
    '        If lstTaskSet.Count > 0 Then
    '            For Each _taskItem As TasksSet In lstTaskSet
    '                lstTasks.Add(DirectCast(GetMappedFields(_taskItem), Tasks))
    '            Next
    '            status = NotifyType.IsSuccess
    '        End If
    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '        message = GetExceptionMessage(ex)
    '    End Try
    '    state = GetStateData(status, lstTasks, message)
    '    Return state
    'End Function

    'Public Function ViewTaskByEmployee(ByVal empId As Integer, ByVal dateStart As DateTime) As StateData
    '    Dim tasksSummarySet As New TasksSummarySet
    '    Dim lstTaskSummarySet As New List(Of TasksSummarySet)
    '    Dim lstTaskSummary As New List(Of TaskSummary)
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType
    '    Try
    '        lstTaskSummarySet = tasksSummarySet.getTaskSummaryByEmpId(empId, dateStart)
    '        If lstTaskSummarySet.Count > 0 Then
    '            For Each _taskItem As TasksSummarySet In lstTaskSummarySet
    '                lstTaskSummary.Add(DirectCast(GetMappedFields2(_taskItem), TaskSummary))
    '            Next
    '            status = NotifyType.IsSuccess
    '        End If
    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '        message = GetExceptionMessage(ex)
    '    End Try
    '    state = GetStateData(status, lstTaskSummary, message)
    '    Return state
    'End Function

    'Public Function ViewTaskAll(ByVal dateStart As DateTime, ByVal email As String) As StateData
    '    Dim tasksSummarySet As New TasksSummarySet
    '    Dim lstTaskSummarySet As New List(Of TasksSummarySet)
    '    Dim lstTaskSummary As New List(Of TaskSummary)
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType
    '    Try
    '        lstTaskSummarySet = tasksSummarySet.getTaskSummaryAll(dateStart, email)
    '        If lstTaskSummarySet.Count > 0 Then
    '            For Each _taskItem As TasksSummarySet In lstTaskSummarySet
    '                lstTaskSummary.Add(DirectCast(GetMappedFields2(_taskItem), TaskSummary))
    '            Next
    '            status = NotifyType.IsSuccess
    '        End If
    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '        message = GetExceptionMessage(ex)
    '    End Try
    '    state = GetStateData(status, lstTaskSummary, message)
    '    Return state
    'End Function

    'Public Function GetTaskDetailByIncidentId(id As Integer) As StateData
    '    Dim taskSet As New TasksSet
    '    Dim TaskSetList As List(Of TasksSet)
    '    Dim objTaskAs As New List(Of Tasks)
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType

    '    Try
    '        TaskSetList = taskSet.GetTaskDetailByIncidentId(id)

    '        If Not IsNothing(TaskSetList) Then
    '            For Each objList As TasksSet In TaskSetList
    '                objTaskAs.Add(DirectCast(GetMappedFields(objList), Tasks))
    '            Next

    '            status = NotifyType.IsSuccess
    '        End If

    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '        message = GetExceptionMessage(ex)
    '    End Try
    '    state = GetStateData(status, objTaskAs, message)
    '    Return state
    'End Function

    Public Sub SetWeekRangeFields(ByRef objResult As Object, objData As Object)
        Dim objWeekRange As WeekRange = DirectCast(objData, WeekRange)
        Dim weekRangeData As New WeekRangeSet
        weekRangeData.WeekRangeID = objWeekRange.WeekRangeID
        weekRangeData.StartWeek = objWeekRange.StartWeek
        weekRangeData.EndWeek = objWeekRange.EndWeek
        objResult = weekRangeData
    End Sub

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objWeeklyReport As WeeklyReport = DirectCast(objData, WeeklyReport)
        Dim weeklyReportData As New WeeklyReportSet
        weeklyReportData.WK_ID = objWeeklyReport.WeekID
        weeklyReportData.WK_RANGE_ID = objWeeklyReport.WeekRangeID
        weeklyReportData.PROJ_ID = objWeeklyReport.ProjectID
        weeklyReportData.REWORK = objWeeklyReport.Rework
        weeklyReportData.REF_ID = objWeeklyReport.ReferenceID
        weeklyReportData.SUBJECT = objWeeklyReport.Subject
        weeklyReportData.SEVERITY = objWeeklyReport.Severity
        weeklyReportData.INC_TYPE = objWeeklyReport.IncidentType
        weeklyReportData.EMP_ID = objWeeklyReport.EmpID
        weeklyReportData.PHASE = objWeeklyReport.Phase
        weeklyReportData.STATUS = objWeeklyReport.Status
        weeklyReportData.DATE_STARTED = objWeeklyReport.DateStarted
        weeklyReportData.DATE_TARGET = objWeeklyReport.DateTarget
        weeklyReportData.DATE_FINISHED = objWeeklyReport.DateFinished
        weeklyReportData.DATE_CREATED = objWeeklyReport.DateCreated
        weeklyReportData.EFFORT_EST = objWeeklyReport.EffortEst
        weeklyReportData.ACT_EFFORT_WK = objWeeklyReport.ActualEffortWk
        weeklyReportData.ACT_EFFORT = objWeeklyReport.ActualEffort
        weeklyReportData.COMMENTS = objWeeklyReport.Comments
        weeklyReportData.INBOUND_CONTACTS = objWeeklyReport.InboundContacts
        objResult = weeklyReportData
    End Sub

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objWeeklyReport As WeeklyReportSet = DirectCast(objData, WeeklyReportSet)
        Dim weeklyReportData As New WeeklyReport
        weeklyReportData.WeekID = objWeeklyReport.WK_ID
        weeklyReportData.WeekRangeID = objWeeklyReport.WK_RANGE_ID
        weeklyReportData.ProjectID = objWeeklyReport.PROJ_ID
        weeklyReportData.Rework = objWeeklyReport.REWORK
        weeklyReportData.ReferenceID = objWeeklyReport.REF_ID
        weeklyReportData.Subject = objWeeklyReport.SUBJECT
        weeklyReportData.Severity = objWeeklyReport.SEVERITY
        weeklyReportData.IncidentType = objWeeklyReport.INC_TYPE
        weeklyReportData.EmpID = objWeeklyReport.EMP_ID
        weeklyReportData.Phase = objWeeklyReport.PHASE
        weeklyReportData.Status = objWeeklyReport.STATUS
        weeklyReportData.DateStarted = objWeeklyReport.DATE_STARTED
        weeklyReportData.DateTarget = objWeeklyReport.DATE_TARGET
        weeklyReportData.DateFinished = objWeeklyReport.DATE_FINISHED
        weeklyReportData.DateCreated = objWeeklyReport.DATE_CREATED
        weeklyReportData.EffortEst = objWeeklyReport.EFFORT_EST
        weeklyReportData.ActualEffortWk = objWeeklyReport.ACT_EFFORT_WK
        weeklyReportData.ActualEffort = objWeeklyReport.ACT_EFFORT
        weeklyReportData.Comments = objWeeklyReport.COMMENTS
        weeklyReportData.InboundContacts = objWeeklyReport.INBOUND_CONTACTS
        Return weeklyReportData
    End Function

    Public Function GetWeekRangeMappedFields(objData As Object) As Object
        Dim objWeekRange As WeekRangeSet = DirectCast(objData, WeekRangeSet)
        Dim weekRangeData As New WeekRange
        weekRangeData.WeekRangeID = objWeekRange.WeekRangeID
        weekRangeData.StartWeek = objWeekRange.StartWeek
        weekRangeData.EndWeek = objWeekRange.EndWeek
        weekRangeData.DateRange = objWeekRange.DateRange
        weekRangeData.DateCreated = objWeekRange.DateCreated
        Return weekRangeData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
End Class
