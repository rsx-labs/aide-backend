Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class DashboardManagement
    Private _AttendanceMgmt As AttendanceManagement
    Private _EmployeeMgmt As EmployeeManagement
    Private _NonBillableMgmt As NonBillabilityManagement
    Private _TaskMgmt As TasksManagement
    Private _ProjectMgmt As ProjectManagement
    Private _NonBillableHoursMgmt As NonBillabilityManagement
    Public Sub New()
        _AttendanceMgmt = New AttendanceManagement()
        _EmployeeMgmt = New EmployeeManagement()
        _NonBillableMgmt = New NonBillabilityManagement()
        _TaskMgmt = New TasksManagement()
        _ProjectMgmt = New ProjectManagement()
        _NonBillableHoursMgmt = New NonBillabilityManagement()
    End Sub

    Public Function DashbrdGetEmployeeList() As List(Of DashboardEmployee)
        Dim state As StateData = _EmployeeMgmt.GetEmployeeList()
        Dim lstDbEmployeeList As List(Of DashboardEmployee) = Nothing

        If Not IsNothing(state.Data) Then
            Dim lstEmployee As List(Of Employee) = DirectCast(state.Data, List(Of Employee))
            lstDbEmployeeList = New List(Of DashboardEmployee)
            For Each _employee As Employee In lstEmployee
                Dim item As New DashboardEmployee
                item.EmployeeName = _employee.FirstName & " " & _employee.LastName
                item.EmployeePosition = _employee.Position
                item.EmployeeType = IIf((_employee.GroupID = 1), "Employee", "Manager")
                item.ImageSource = "ms-appx:///Assets/EmployeePhotos/" & _employee.FirstName.Trim() & _employee.LastName.Trim() & ".jpg"
                lstDbEmployeeList.Add(item)
            Next
        End If
        Return lstDbEmployeeList
    End Function

    Public Function DashbrdGetContactList() As List(Of DashboardContact)
        Dim state As StateData = _EmployeeMgmt.GetEmployeeList()
        Dim lstDbContactList As List(Of DashboardContact) = Nothing

        If Not IsNothing(state.Data) Then
            Dim lstEmployee As List(Of Employee) = DirectCast(state.Data, List(Of Employee))
            lstDbContactList = New List(Of DashboardContact)
            For Each _employee As Employee In lstEmployee
                Dim item As New DashboardContact
                item.EmployeeID = _employee.EmployeeID
                item.FullName = _employee.FirstName & " " & _employee.LastName
                item.NickName = _employee.Nickname
                item.CellNo = _employee.CellNumber
                item.DateReviewed = _employee.DateReviewed
                item.EmailAdd = _employee.EmailAddress
                item.EmployeeLocation = _employee.Location
                item.EmployeeType = IIf((_employee.GroupID = 1), "Employee", "Manager")
                item.ImageSource = "ms-appx:///Assets/CoverPhotos/" & _employee.FirstName.Trim() & _employee.LastName.Trim() & ".jpg"
                item.ImageSource2 = "ms-appx:///Assets/EmployeePhotos/" & _employee.FirstName.Trim() & _employee.LastName.Trim() & ".jpg"
                item.Local = _employee.Local
                item.DateReviewed = _employee.DateReviewed.ToShortDateString()
                lstDbContactList.Add(item)
            Next
        End If
        Return lstDbContactList
    End Function
    Public Function DashbrdGetTaskSummaryTotals(ByVal dateStart As Date, ByVal email As String) As List(Of DashboardTaskSummaryTotals)
        Dim currDate As Date = Date.Now
        Dim state As StateData = _TaskMgmt.ViewTaskAll(currDate, email)
        Dim lstDbTaskstList As List(Of DashboardTaskSummaryTotals) = Nothing

        If Not IsNothing(state.Data) Then
            Dim lstTaskSummary As List(Of TaskSummary) = DirectCast(state.Data, List(Of TaskSummary))
            lstDbTaskstList = New List(Of DashboardTaskSummaryTotals)
            For Each _task As TaskSummary In lstTaskSummary
                Dim item As New DashboardTaskSummaryTotals
                item.Name = _task.Name

                Select Case currDate.DayOfWeek
                    Case DayOfWeek.Monday
                        item.AssignedTaskCount = _task.MondayAT
                        item.CompletedTaskCount = _task.MondayCT
                        item.OutstandingTaskCount = _task.MondayOT
                    Case DayOfWeek.Tuesday
                        item.AssignedTaskCount = _task.TuesdayCT
                        item.CompletedTaskCount = _task.TuesdayCT
                        item.OutstandingTaskCount = _task.TuesdayOT
                    Case DayOfWeek.Wednesday
                        item.AssignedTaskCount = _task.WednesdayAT
                        item.CompletedTaskCount = _task.WednesdayCT
                        item.OutstandingTaskCount = _task.WednesdayOT
                    Case DayOfWeek.Thursday
                        item.AssignedTaskCount = _task.ThursdayAT
                        item.CompletedTaskCount = _task.ThursdayCT
                        item.OutstandingTaskCount = _task.ThursdayOT
                    Case DayOfWeek.Friday
                        item.AssignedTaskCount = _task.FridayAT
                        item.CompletedTaskCount = _task.FridayCT
                        item.OutstandingTaskCount = _task.FridayOT
                End Select
                lstDbTaskstList.Add(item)
            Next
        End If
        Return lstDbTaskstList
    End Function

    Public Function DashbrdGetTaskSummary(ByVal dateStart As Date, ByVal email As String) As List(Of TaskSummary)
        Dim currDate As Date = Date.Now
        Dim state As StateData = _TaskMgmt.ViewTaskAll(currDate, email)
        Dim lstTaskSummary As List(Of TaskSummary) = Nothing

        If Not IsNothing(state.Data) Then
            lstTaskSummary = DirectCast(state.Data, List(Of TaskSummary))
        End If
        Return lstTaskSummary
    End Function
    Public Function DashbrdGetTeamAttendance() As List(Of DashboardTeamAttendance)
        Dim state As StateData = _ProjectMgmt.ViewProject()
        Dim lstDbAttendanceList As List(Of DashboardTeamAttendance) = Nothing

        If Not IsNothing(state.Data) Then
            Dim lstAssignedProj As List(Of ViewProject) = DirectCast(state.Data, List(Of ViewProject))
            lstDbAttendanceList = New List(Of DashboardTeamAttendance)
            For Each _project As ViewProject In lstAssignedProj
                Dim item As New DashboardTeamAttendance
                item.Name = _project.Name
                item.Status = _project.Status
                item.ImageSource = "ms-appx:///Assets/EmployeePhotos/" & _project.Name.Trim() & ".jpg"
                item.FirstMonth = _project.Month1
                item.SecondMonth = _project.Month2
                item.ThirdMonth = _project.Month3
                lstDbAttendanceList.Add(item)
            Next
        End If
        Return lstDbAttendanceList
    End Function

    Public Function DashbrdGetNonBillableHours() As List(Of DashboardNonBillableHours)
        Dim currDate As Date = Date.Now
        Dim state As StateData = _NonBillableHoursMgmt.getNonBillableData(currDate)
        Dim lstDbNonBillableHoursList As List(Of DashboardNonBillableHours) = Nothing

        If Not IsNothing(state.Data) Then
            Dim lstNonBillableSummary As List(Of NonBillableSummary) = DirectCast(state.Data, List(Of NonBillableSummary))
            lstDbNonBillableHoursList = New List(Of DashboardNonBillableHours)
            For Each _nonbillable As NonBillableSummary In lstNonBillableSummary
                Dim item As New DashboardNonBillableHours
                item.Name = _nonbillable.Name
                'item.IBP = _nonbillable.InBetween
                item.Holiday = _nonbillable.Holiday
                item.VL = _nonbillable.VacationLeave
                item.SL = _nonbillable.SickLeave
                lstDbNonBillableHoursList.Add(item)
            Next
        End If
        Return lstDbNonBillableHoursList
    End Function

    Public Function DashbrdGetNonBillableSummary() As List(Of DashboardNonBillableHoursSummary)
        Dim lstDbNonBillableSummaryList As List(Of DashboardNonBillableHoursSummary) = Nothing
        Return lstDbNonBillableSummaryList
    End Function
End Class
