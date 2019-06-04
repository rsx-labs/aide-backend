Public Interface IWeekRange

#Region "Database Field Map"

    Property WeekRangeID As Integer
    Property StartDate As Date
    Property EndDate As Date
    Property DateCreated As Date
    Property DateRange As String

    Function InsertWeekRange() As Boolean
    Function GetWeekRange(currentDate As Date, empID As Integer) As List(Of WeekRangeSet)
    Function GetWeeklyReportsByEmpID(empID As Integer) As List(Of WeekRangeSet)
#End Region

End Interface