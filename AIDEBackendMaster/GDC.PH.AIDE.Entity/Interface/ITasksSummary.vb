Public Interface ITasksSummary

#Region "Database Field Map"

    Property EmployeeName As String
    Property LastWeekOutstanding As Integer

    Property Mon_AT As Integer
    Property Mon_CT As Integer
    Property Mon_OT As Integer

    Property Tue_AT As Integer
    Property Tue_CT As Integer
    Property Tue_OT As Integer

    Property Wed_AT As Integer
    Property Wed_CT As Integer
    Property Wed_OT As Integer

    Property Thu_AT As Integer
    Property Thu_CT As Integer
    Property Thu_OT As Integer

    Property Fri_AT As Integer
    Property Fri_CT As Integer
    Property Fri_OT As Integer

    Function getTaskSummaryAll(dateStart As DateTime, email As String) As List(Of TasksSummarySet)
    Function getTaskSummaryByEmpId(ByVal empID As Integer, dateStart As DateTime) As List(Of TasksSummarySet)

#End Region

End Interface