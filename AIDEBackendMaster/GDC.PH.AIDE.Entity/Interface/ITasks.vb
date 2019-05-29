Public Interface ITasks

#Region "Database Field Map"

    Property TASK_ID As Integer
    Property EMP_ID As Integer
    Property INC_ID As String
    Property TASK_TYPE As Integer
    Property PROJ_ID As Integer
    Property INC_DESCR As String
    Property TASK_DESCR As String
    Property DATE_STARTED As DateTime
    Property TARGET_DATE As DateTime
    Property COMPLTD_DATE As DateTime
    Property DATE_CREATED As DateTime
    Property HOURSWORKED_DATE As DateTime
    Property STATUS As Integer
    Property REMARKS As String
    Property EFFORT_EST As Double
    Property ACT_EFFORT_EST As Double
    Property ACT_EFFORT_EST_WK As Double
    Property PROJECT_CODE As Integer
    Property REWORK As Byte
    Property PHASE As String
    Property OTHERS_1 As String
    Property OTHERS_2 As String
    Property OTHERS_3 As String

    Function getMyTasks(ByVal empId As Integer) As List(Of TasksSet)
    Function getTaskDetailByTaskId(ByVal taskID As Integer) As TasksSet
    Function getTaskSummaryWeekly(ByVal empId As Integer, dateStart As DateTime) As List(Of TasksSet)
    Function InsertNewTask(ByVal task As TasksSet) As Boolean
    Function UpdateTask() As Boolean
    Function GetAllTasks() As List(Of TasksSet)
    Function GetTaskDetailByIncidentId(ByVal id As Integer) As List(Of TasksSet)
#End Region

End Interface