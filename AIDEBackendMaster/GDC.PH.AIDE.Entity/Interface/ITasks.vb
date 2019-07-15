Public Interface ITasks

#Region "Database Field Map"

    Property TASK_ID As Integer
    Property PROJ_ID As Integer
    Property PROJECT_CODE As Integer
    Property REWORK As Short
    Property REF_ID As String
    Property INC_DESCR As String
    Property SEVERITY As Short
    Property INC_TYPE As Short
    Property EMP_ID As Integer
    Property PHASE As Short
    Property STATUS As Short
    Property DATE_STARTED As DateTime
    Property TARGET_DATE As DateTime
    Property COMPLTD_DATE As DateTime
    Property DATE_CREATED As DateTime
    Property EFFORT_EST As Double
    Property ACT_EFFORT As Double
    Property ACT_EFFORT_WK As Double
    Property COMMENTS As String
    Property OTHERS_1 As String
    Property OTHERS_2 As String
    Property OTHERS_3 As String

    Function getMyTasks(ByVal empId As Integer) As List(Of TasksSet)
    Function getTaskDetailByTaskId(ByVal taskID As Integer) As TasksSet
    Function getTaskSummaryWeekly(ByVal empId As Integer, dateStart As DateTime) As List(Of TasksSet)
    Function InsertNewTask(ByVal task As TasksSet) As Boolean
    Function UpdateTask() As Boolean
    Function GetAllTasks() As List(Of TasksSet)
    Function GetTasksByEmpID(ByVal empID As Integer) As List(Of TasksSet)
#End Region

End Interface