Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class WeeklyReportManagement
    Inherits ManagementBase

    Public Function CreateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport), ByVal weeklyReportXref As WeekRange) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetWeekRangeFields(weekRangeSet, weeklyReportXref)
            If weekRangeSet.InsertWeeklyReportXref(weekRangeSet) Then
                For Each objReports As WeeklyReport In weeklyReport
                    InsertWeeklyReport(objReports)
                Next
            End If
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

    Public Function UpdateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport), ByVal weeklyReportXref As WeekRange) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetWeekRangeFields(weekRangeSet, weeklyReportXref)
            If weekRangeSet.UpdateWeeklyReportXref(weekRangeSet) Then
                For Each objReports As WeeklyReport In weeklyReport
                    UpdateWeeklyReports(objReports)
                Next
            End If
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

    Public Function GetWeekRangeByMonthYear(empID As Integer, month As Integer, year As Integer) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim weekRangeSetList As List(Of WeekRangeSet)
        Dim objWeekRange As New List(Of WeekRange)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weekRangeSetList = weekRangeSet.GetWeekRangeByMonthYear(empID, month, year)

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

    Public Function GetWeeklyReportsByEmpID(empID As Integer, month As Integer, year As Integer) As StateData
        Dim weekRangeSet As New WeekRangeSet
        Dim weekRangeSetList As List(Of WeekRangeSet)
        Dim objWeekRange As New List(Of WeekRange)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weekRangeSetList = weekRangeSet.GetWeeklyReportsByEmpID(empID, month, year)

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

    Public Function GetTasksDataByEmpID(weekRangeID As Integer, empID As Integer) As StateData
        Dim weeklyReportSet As New WeeklyReportSet
        Dim weeklyReportSetList As List(Of WeeklyReportSet)
        Dim objWeeklyReport As New List(Of WeeklyReport)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weeklyReportSetList = weeklyReportSet.GetTasksDataByEmpID(weekRangeID, empID)

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

    Public Function GetMissingReportsByEmpID(empID As Integer, currentDate As Date) As StateData
        Dim contactListSet As New ContactSet
        Dim lstContacts As List(Of ContactSet)
        Dim objContacts As New List(Of ContactList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstContacts = contactListSet.GetMissingReportsByEmpID(empID, currentDate)

            If Not IsNothing(lstContacts) Then
                For Each objList As ContactSet In lstContacts
                    objContacts.Add(DirectCast(GetMappedFieldsWithEmpName(objList), ContactList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objContacts, message)
        Return state
    End Function

    Public Function GetWeeklyTeamStatusReport(empID As Integer, month As Integer, year As Integer, weekID As Integer) As StateData
        Dim weeklyTeamStatusReportSet As New WeeklyTeamStatusReportSet
        Dim weeklyTeamStatusReportSetList As List(Of WeeklyTeamStatusReportSet)
        Dim objweeklyTeamStatusReport As New List(Of WeeklyTeamStatusReport)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            weeklyTeamStatusReportSetList = weeklyTeamStatusReportSet.GetWeeklyTeamStatusReport(empID, month, year, weekID)

            If Not IsNothing(weeklyTeamStatusReportSetList) Then
                For Each objList As WeeklyTeamStatusReportSet In weeklyTeamStatusReportSetList
                    objweeklyTeamStatusReport.Add(DirectCast(GetWeeklyTeamStatusReportMappedFields(objList), WeeklyTeamStatusReport))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objweeklyTeamStatusReport, message)
        Return state
    End Function
    
    Public Sub SetWeekRangeFields(ByRef objResult As Object, objData As Object)
        Dim objWeekRange As WeekRange = DirectCast(objData, WeekRange)
        Dim weekRangeData As New WeekRangeSet
        weekRangeData.WeekRangeID = objWeekRange.WeekRangeID
        weekRangeData.StartWeek = objWeekRange.StartWeek
        weekRangeData.EndWeek = objWeekRange.EndWeek
        weekRangeData.EmpID = objWeekRange.EmployeeID
        weekRangeData.Status = objWeekRange.Status
        weekRangeData.DateSubmitted = objWeekRange.DateSubmitted
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
        weekRangeData.Status = objWeekRange.Status
        weekRangeData.DateRange = objWeekRange.DateRange
        weekRangeData.DateSubmitted = objWeekRange.DateSubmitted
        Return weekRangeData
    End Function

    Public Function GetMappedFieldsWithEmpName(ByVal objData As Object) As Object
        Dim objContacts As ContactSet = DirectCast(objData, ContactSet)
        Dim contactData As New ContactList
        contactData.EmpID = objContacts.EmpID
        contactData.EMADDRESS = objContacts.EMADDRESS
        contactData.EMADDRESS2 = objContacts.EMADDRESS2
        contactData.HOUSEPHONE = objContacts.HOUSEPHONE
        contactData.OTHERPHONE = objContacts.OTHERPHONE
        contactData.LOC = objContacts.LOC
        contactData.lOCAL = objContacts.lOCAL
        contactData.CELL_NO = objContacts.CELL_NO
        contactData.DateReviewed = objContacts.DateReviewed
        contactData.FIRST_NAME = objContacts.FIRST_NAME
        contactData.LAST_NAME = objContacts.LAST_NAME
        contactData.MIDDLE_NAME = objContacts.MIDDLE_NAME
        contactData.IMAGE_PATH = objContacts.IMAGE_PATH

        Return contactData
    End Function

    Public Function GetWeeklyTeamStatusReportMappedFields(objData As Object) As Object
        Dim objWeeklyTeamStatusReport As WeeklyTeamStatusReportSet = DirectCast(objData, WeeklyTeamStatusReportSet)
        Dim weeklyTeamStatusReportData As New WeeklyTeamStatusReport

        weeklyTeamStatusReportData.WeekRangeID = objWeeklyTeamStatusReport.WeekRangeID
        weeklyTeamStatusReportData.EmployeeID = objWeeklyTeamStatusReport.EmployeeID
        weeklyTeamStatusReportData.EmployeeName = objWeeklyTeamStatusReport.EmployeeName
        weeklyTeamStatusReportData.TotalHours = objWeeklyTeamStatusReport.TotalHours
        weeklyTeamStatusReportData.Status = objWeeklyTeamStatusReport.Status
        weeklyTeamStatusReportData.DateSubmitted = objWeeklyTeamStatusReport.DateSubmitted

        Return weeklyTeamStatusReportData
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
