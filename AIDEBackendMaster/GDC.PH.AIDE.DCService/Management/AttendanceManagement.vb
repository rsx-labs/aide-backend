Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class AttendanceManagement
    Inherits ManagementBase

    Public Function Insert(ByVal attendance As AttendanceSummary) As StateData
        Dim _attendanceSet As New AttendanceSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(_attendanceSet, attendance)
            If _attendanceSet.Insert() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function InsertLogoffTime(ByVal empid As Integer, ByVal logoffTime As Date) As StateData
        Dim _attendanceSet As New AttendanceSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            If _attendanceSet.InsertLogoffTime(empid, logoffTime) Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAttendanceByEmployee(ByVal empId As Integer, ByVal weekOf As DateTime) As StateData
        Dim _attendanceSet As New AttendanceSet
        Dim lstAttendanceSet As New List(Of AttendanceSet)
        Dim lstAttendance As New List(Of MyAttendance)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstAttendanceSet = _attendanceSet.GetAttendanceWeekly(empId, weekOf)
            If lstAttendanceSet.Count > 0 Then
                For Each _attendance As AttendanceSet In lstAttendanceSet
                    lstAttendance.Add(DirectCast(GetMappedFields2(_attendance), MyAttendance))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAttendanceAll(ByVal month As Integer, ByVal year As Integer) As StateData
        Dim _attendanceSet As New AttendanceSet
        Dim lstAttendanceSet As New List(Of AttendanceSet)
        Dim lstAttendance As New List(Of AttendanceSummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstAttendanceSet = _attendanceSet.GetAttendanceMonthly(month, year)
            If lstAttendanceSet.Count > 0 Then
                For Each _attendance As AttendanceSet In lstAttendanceSet
                    lstAttendance.Add(DirectCast(GetMappedFields(_attendance), AttendanceSummary))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, lstAttendance)
        Return state
    End Function

    Public Function GetAttendanceToday(empID As Integer) As StateData
        Dim AttendanceSet As New AttendanceSet
        Dim AttendanceSetLst As List(Of AttendanceSet)
        Dim objAttendance As New List(Of MyAttendance)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            AttendanceSetLst = AttendanceSet.GetAttendanceToday(empID)

            If Not IsNothing(AttendanceSetLst) Then
                For Each objList As AttendanceSet In AttendanceSetLst
                    objAttendance.Add(DirectCast(GetMappedFields3(objList), MyAttendance))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAttendance, message)
        Return state
    End Function

    Public Function GetAttendanceTodayBySearch(email As String, input As String) As StateData
        Dim AttendanceSet As New AttendanceSet
        Dim AttendanceSetLst As List(Of AttendanceSet)
        Dim objAttendance As New List(Of MyAttendance)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            AttendanceSetLst = AttendanceSet.GetAttendanceTodayBySearch(email, input)

            If Not IsNothing(AttendanceSetLst) Then
                For Each objList As AttendanceSet In AttendanceSetLst
                    objAttendance.Add(DirectCast(GetMappedFields3(objList), MyAttendance))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAttendance, message)
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objAttendance As AttendanceSummary = DirectCast(objData, AttendanceSummary)
        Dim attendanceData As New AttendanceSet
        attendanceData.EmployeeID = objAttendance.EmployeeID
        attendanceData.DATE_ENTRY = objAttendance.TimeIn
        'attendanceData.EmployeeName = objAttendance.Name
        attendanceData.Month = objAttendance.Month
        attendanceData.Year = objAttendance.Year
        attendanceData.Day1 = objAttendance.Day1
        attendanceData.Day2 = objAttendance.Day2
        attendanceData.Day3 = objAttendance.Day3
        attendanceData.Day4 = objAttendance.Day4
        attendanceData.Day5 = objAttendance.Day5
        attendanceData.Day6 = objAttendance.Day6
        attendanceData.Day7 = objAttendance.Day7
        attendanceData.Day8 = objAttendance.Day8
        attendanceData.Day9 = objAttendance.Day9
        attendanceData.Day10 = objAttendance.Day10
        attendanceData.Day11 = objAttendance.Day11
        attendanceData.Day12 = objAttendance.Day12
        attendanceData.Day13 = objAttendance.Day13
        attendanceData.Day14 = objAttendance.Day14
        attendanceData.Day15 = objAttendance.Day15
        attendanceData.Day16 = objAttendance.Day16
        attendanceData.Day17 = objAttendance.Day17
        attendanceData.Day18 = objAttendance.Day18
        attendanceData.Day19 = objAttendance.Day19
        attendanceData.Day20 = objAttendance.Day20
        attendanceData.Day21 = objAttendance.Day21
        attendanceData.Day22 = objAttendance.Day22
        attendanceData.Day23 = objAttendance.Day23
        attendanceData.Day24 = objAttendance.Day24
        attendanceData.Day25 = objAttendance.Day25
        attendanceData.Day26 = objAttendance.Day26
        attendanceData.Day27 = objAttendance.Day27
        attendanceData.Day28 = objAttendance.Day28
        attendanceData.Day29 = objAttendance.Day29
        attendanceData.Day30 = objAttendance.Day30
        attendanceData.Day31 = objAttendance.Day31
        objResult = attendanceData
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objAttendance As AttendanceSet = DirectCast(objData, AttendanceSet)
        Dim attendanceData As New AttendanceSummary
        attendanceData.EmployeeID = objAttendance.EmployeeID
        attendanceData.Name = objAttendance.EmployeeName
        attendanceData.Month = objAttendance.Month
        attendanceData.Year = objAttendance.Year
        attendanceData.Day1 = objAttendance.Day1
        attendanceData.Day2 = objAttendance.Day2
        attendanceData.Day3 = objAttendance.Day3
        attendanceData.Day4 = objAttendance.Day4
        attendanceData.Day5 = objAttendance.Day5
        attendanceData.Day6 = objAttendance.Day6
        attendanceData.Day7 = objAttendance.Day7
        attendanceData.Day8 = objAttendance.Day8
        attendanceData.Day9 = objAttendance.Day9
        attendanceData.Day10 = objAttendance.Day10
        attendanceData.Day11 = objAttendance.Day11
        attendanceData.Day12 = objAttendance.Day12
        attendanceData.Day13 = objAttendance.Day13
        attendanceData.Day14 = objAttendance.Day14
        attendanceData.Day15 = objAttendance.Day15
        attendanceData.Day16 = objAttendance.Day16
        attendanceData.Day17 = objAttendance.Day17
        attendanceData.Day18 = objAttendance.Day18
        attendanceData.Day19 = objAttendance.Day19
        attendanceData.Day20 = objAttendance.Day20
        attendanceData.Day21 = objAttendance.Day21
        attendanceData.Day22 = objAttendance.Day22
        attendanceData.Day23 = objAttendance.Day23
        attendanceData.Day24 = objAttendance.Day24
        attendanceData.Day25 = objAttendance.Day25
        attendanceData.Day26 = objAttendance.Day26
        attendanceData.Day27 = objAttendance.Day27
        attendanceData.Day28 = objAttendance.Day28
        attendanceData.Day29 = objAttendance.Day29
        attendanceData.Day30 = objAttendance.Day30
        attendanceData.Day31 = objAttendance.Day31
        Return attendanceData
    End Function

    Public Function GetMappedFields2(objData As Object) As Object
        Dim objAttendance As AttendanceSet = DirectCast(objData, AttendanceSet)
        Dim attendanceData As New MyAttendance
        attendanceData.EmployeeID = objAttendance.EmployeeID
        attendanceData.Name = objAttendance.EmployeeName
        attendanceData.MondayVal = objAttendance.Monday
        attendanceData.TuesdayVal = objAttendance.Tuesday
        attendanceData.WednesdayVal = objAttendance.Wednesday
        attendanceData.ThursdayVal = objAttendance.Thursday
        attendanceData.FridayVal = objAttendance.Friday
        Return attendanceData
    End Function

    Public Function GetMappedFields3(objData As Object) As Object
        Dim objAttendance As AttendanceSet = DirectCast(objData, AttendanceSet)
        Dim attendanceData As New MyAttendance

        attendanceData.EmployeeID = objAttendance.EmployeeID
        attendanceData.Name = objAttendance.EmployeeName
        attendanceData.Descr = objAttendance.DESCR
        attendanceData.Status = objAttendance.STATUS
        attendanceData.Image_Path = objAttendance.IMAGE_PATH
        attendanceData.DateEntry = objAttendance.DATE_ENTRY
        attendanceData.LogoffTime = objAttendance.LOGOFF_TIME
        Return attendanceData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function


End Class
