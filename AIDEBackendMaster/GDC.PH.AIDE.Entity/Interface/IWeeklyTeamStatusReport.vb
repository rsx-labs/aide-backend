Public Interface IWeeklyTeamStatusReport

#Region "Database Field Map"

    Property WeekRangeID As Integer
    Property EmployeeID As Integer
    Property EmployeeName As String
    Property TotalHours As Double
    Property Status As Short
    Property DateSubmitted As Date
    Property DateRange As String

    Function GetWeeklyTeamStatusReport(empID As Integer, month As Integer, year As Integer, weekID As Integer) As List(Of WeeklyTeamStatusReportSet)
#End Region

End Interface