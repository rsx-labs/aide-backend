Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class TasksManagement
    Inherits ManagementBase

    Public Function CreateNewTask(ByVal task As Tasks) As StateData
        Dim tasksSet As New TasksSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(tasksSet, task)
            If tasksSet.InsertNewTask(tasksSet) Then
                status = NotifyType.IsSuccess
                message = "Create task successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateTask(ByVal task As Tasks) As StateData
        Dim tasksSet As New TasksSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(tasksSet, task)
            If tasksSet.UpdateTask() Then
                status = NotifyType.IsSuccess
                message = "Update task successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetTasksAll() As StateData
        Dim tasksSet As New TasksSet
        Dim lstTasks As List(Of TasksSet)
        Dim objTasks As New List(Of Tasks)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstTasks = tasksSet.GetAllTasks()

            If Not IsNothing(lstTasks) Then
                For Each objList As TasksSet In lstTasks
                    objTasks.Add(DirectCast(GetMappedFields(objList), Tasks))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objTasks, message)
        Return state
    End Function

    Public Function ViewMyTasks(ByVal empId As Integer) As StateData
        Dim tasksSet As New TasksSet
        Dim lstTaskSet As New List(Of TasksSet)
        Dim lstTasks As New List(Of Tasks)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstTaskSet = tasksSet.getMyTasks(empId)
            If lstTaskSet.Count > 0 Then
                For Each _taskItem As TasksSet In lstTaskSet
                    lstTasks.Add(DirectCast(GetMappedFields(_taskItem), Tasks))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, lstTasks, message)
        Return state
    End Function

    Public Function ViewTaskByEmployee(ByVal empId As Integer, ByVal dateStart As DateTime) As StateData
        Dim tasksSummarySet As New TasksSummarySet
        Dim lstTaskSummarySet As New List(Of TasksSummarySet)
        Dim lstTaskSummary As New List(Of TaskSummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstTaskSummarySet = tasksSummarySet.getTaskSummaryByEmpId(empId, dateStart)
            If lstTaskSummarySet.Count > 0 Then
                For Each _taskItem As TasksSummarySet In lstTaskSummarySet
                    lstTaskSummary.Add(DirectCast(GetMappedFields2(_taskItem), TaskSummary))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, lstTaskSummary, message)
        Return state
    End Function

    Public Function ViewTaskAll(ByVal dateStart As DateTime, ByVal email As String) As StateData
        Dim tasksSummarySet As New TasksSummarySet
        Dim lstTaskSummarySet As New List(Of TasksSummarySet)
        Dim lstTaskSummary As New List(Of TaskSummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstTaskSummarySet = tasksSummarySet.getTaskSummaryAll(dateStart, email)
            If lstTaskSummarySet.Count > 0 Then
                For Each _taskItem As TasksSummarySet In lstTaskSummarySet
                    lstTaskSummary.Add(DirectCast(GetMappedFields2(_taskItem), TaskSummary))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, lstTaskSummary, message)
        Return state
    End Function

    Public Function GetTasksByEmpID(empID As Integer) As StateData
        Dim taskSet As New TasksSet
        Dim TaskSetList As List(Of TasksSet)
        Dim objTaskAs As New List(Of Tasks)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            TaskSetList = taskSet.GetTasksByEmpID(empID)

            If Not IsNothing(TaskSetList) Then
                For Each objList As TasksSet In TaskSetList
                    objTaskAs.Add(DirectCast(GetMappedFields(objList), Tasks))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objTaskAs, message)
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objTasks As Tasks = DirectCast(objData, Tasks)
        Dim tasksData As New TasksSet
        tasksData.TASK_ID = objTasks.TaskID
        tasksData.PROJ_ID = objTasks.ProjectID
        tasksData.PROJECT_CODE = objTasks.ProjectCode
        tasksData.REWORK = objTasks.Rework
        tasksData.REF_ID = objTasks.ReferenceID
        tasksData.INC_DESCR = objTasks.IncidentDescr
        tasksData.SEVERITY = objTasks.Severity
        tasksData.INC_TYPE = objTasks.IncidentType
        tasksData.EMP_ID = objTasks.EmpID
        tasksData.PHASE = objTasks.Phase
        tasksData.STATUS = objTasks.Status
        tasksData.DATE_STARTED = objTasks.DateStarted
        tasksData.TARGET_DATE = objTasks.TargetDate
        tasksData.COMPLTD_DATE = objTasks.CompletedDate
        tasksData.DATE_CREATED = objTasks.DateCreated
        tasksData.EFFORT_EST = objTasks.EffortEst
        tasksData.ACT_EFFORT = objTasks.ActualEffort
        tasksData.ACT_EFFORT_WK = objTasks.ActualEffortWk
        tasksData.COMMENTS = objTasks.Comments
        tasksData.OTHERS_1 = objTasks.Others1
        tasksData.OTHERS_2 = objTasks.Others2
        tasksData.OTHERS_3 = objTasks.Others3

        objResult = tasksData
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objTasks As TasksSet = DirectCast(objData, TasksSet)
        Dim tasksData As New Tasks
        tasksData.TaskID = objTasks.TASK_ID
        tasksData.ProjectID = objTasks.PROJ_ID
        tasksData.ProjectCode = objTasks.PROJECT_CODE
        tasksData.Rework = objTasks.REWORK
        tasksData.ReferenceID = objTasks.REF_ID
        tasksData.IncidentDescr = objTasks.INC_DESCR
        tasksData.Severity = objTasks.SEVERITY
        tasksData.IncidentType = objTasks.INC_TYPE
        tasksData.EmpID = objTasks.EMP_ID
        tasksData.Phase = objTasks.PHASE
        tasksData.Status = objTasks.STATUS
        tasksData.DateStarted = objTasks.DATE_STARTED
        tasksData.TargetDate = objTasks.TARGET_DATE
        tasksData.CompletedDate = objTasks.COMPLTD_DATE
        tasksData.DateCreated = objTasks.DATE_CREATED
        tasksData.EffortEst = objTasks.EFFORT_EST
        tasksData.ActualEffort = objTasks.ACT_EFFORT
        tasksData.ActualEffortWk = objTasks.ACT_EFFORT_WK
        tasksData.Comments = objTasks.COMMENTS
        tasksData.Others1 = objTasks.OTHERS_1
        tasksData.Others2 = objTasks.OTHERS_2
        tasksData.Others3 = objTasks.OTHERS_3
        Return tasksData
    End Function

    Public Function GetMappedFields2(objData As Object) As Object
        Dim objTasks As TasksSummarySet = DirectCast(objData, TasksSummarySet)
        Dim tasksData As New TaskSummary
        tasksData.Name = objTasks.EmployeeName
        tasksData.OutstandingTaskLastWeek = objTasks.LastWeekOutstanding
        tasksData.MondayAT = objTasks.Mon_AT
        tasksData.MondayCT = objTasks.Mon_CT
        tasksData.MondayOT = objTasks.Mon_OT
        tasksData.TuesdayAT = objTasks.Tue_AT
        tasksData.TuesdayCT = objTasks.Tue_CT
        tasksData.TuesdayOT = objTasks.Tue_OT
        tasksData.WednesdayAT = objTasks.Wed_AT
        tasksData.WednesdayCT = objTasks.Wed_CT
        tasksData.WednesdayOT = objTasks.Wed_OT
        tasksData.ThursdayAT = objTasks.Thu_AT
        tasksData.ThursdayCT = objTasks.Thu_CT
        tasksData.ThursdayOT = objTasks.Thu_OT
        tasksData.FridayAT = objTasks.Fri_AT
        tasksData.FridayCT = objTasks.Fri_CT
        tasksData.FridayOT = objTasks.Fri_OT
        Return tasksData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
End Class
