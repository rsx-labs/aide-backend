Public Interface IWeeklyReport

#Region "Database Field Map"

    Property WK_ID As Integer
    Property WK_RANGE_ID As Integer
    Property PROJ_ID As Integer
    Property REWORK As Integer
    Property REF_ID As String
    Property SUBJECT As String
    Property SEVERITY As Integer
    Property INC_TYPE As Integer
    Property EMP_ID As Integer
    Property PHASE As Integer
    Property STATUS As Integer
    Property DATE_STARTED As DateTime
    Property DATE_TARGET As DateTime
    Property DATE_FINISHED As DateTime
    Property DATE_CREATED As DateTime
    Property EFFORT_EST As Double
    Property ACT_EFFORT_WK As Double
    Property ACT_EFFORT As Double
    Property COMMENTS As String
    Property INBOUND_CONTACTS As Integer

    'Function getMyTasks(ByVal empId As Integer) As List(Of WeeklyReportSet)
    'Function getTaskDetailByTaskId(ByVal taskID As Integer) As WeeklyReportSet
    'Function getTaskSummaryWeekly(ByVal empId As Integer, dateStart As DateTime) As List(Of WeeklyReportSet)

    'Function GetAllTasks() As List(Of WeeklyReportSet)
    'Function GetTaskDetailByIncidentId(ByVal id As Integer) As List(Of WeeklyReportSet)
#End Region

End Interface