Public Interface IWeekRange

#Region "Database Field Map"

    Property WeekRangeID As Integer
    Property StartDate As Date
    Property EndDate As Date
    Property EmpID As Integer
    Property Status As Short
    Property DateSubmitted As Date
    Property DateRange As String

    Function InsertWeekRange() As Boolean
    Function InsertWeeklyReportXref(weekRange As WeekRangeSet) As Boolean
    Function UpdateWeeklyReportXref(weekRange As WeekRangeSet) As Boolean
    Function GetWeekRange(currentDate As Date, empID As Integer) As List(Of WeekRangeSet)
    Function GetWeekRangeByMonthYear(empID As Integer, month As Integer, year As Integer) As List(Of WeekRangeSet)
    Function GetWeeklyReportsByEmpID(empID As Integer, month As Integer, year As Integer) As List(Of WeekRangeSet)
#End Region

End Interface