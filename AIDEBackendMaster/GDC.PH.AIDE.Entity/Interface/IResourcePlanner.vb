Imports GDC.PH.AIDE.BusinessLayer
''' <summary>
''' By Jhunell G. Barcenas / John Harvey Sanchez
''' </summary>
''' <remarks></remarks>
Public Interface IResourcePlanner

    Property EmployeeID As Integer
    Property Name As String
    Property dateFrom As Date
    Property dateTo As Date
	Property Status As String
	Property UsedLeaves As Double
    Property vlHours As Double
    Property slHours As Double
    Property Description As String
    Property Image_Path As String
    Property dateEntry As Date
    Property HalfBalance As Double
    Property TotalBalance As Double
    Property holidayHours As Double
    Property StartDate As Date
    Property EndDate As Date
    Property Duration As Double
    Property StatusCD As Integer
    Property Comment As String

    Function InsertAttendanceForLeaves(ByVal resourcePlanner As ResourcePlannerSet) As Boolean
    Function UpdateResourcePlanner(ByVal resource As ResourcePlannerSet) As Boolean
    Function ViewEmpResourcePlanner(ByVal email As String) As List(Of ResourcePlannerSet)
    Function GetStatusResourcePlanner(ByVal empID As Integer) As List(Of ResourcePlannerSet)
    Function GetResourcePlannerByEmpID(ByVal empID As Integer, ByVal deptID As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetAllEmpResourcePlanner(ByVal email As String, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetAllEmpResourcePlannerByStatus(ByVal email As String, ByVal month As Integer, ByVal year As Integer, ByVal status As Integer) As List(Of ResourcePlannerSet)
    Function GetAllStatusResourcePlanner() As List(Of ResourcePlannerSet)
    Function GetResourcePlanner(ByVal email As String, ByVal status As Integer, ByVal toBeDisplayed As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetBillableHoursByMonth(ByVal status As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetBillableHoursByWeek(ByVal status As Integer, ByVal weekID As Integer) As List(Of ResourcePlannerSet)
    Function GetNonBillableHours(ByVal email As String, ByVal display As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetAllLeavesByEmployee(ByVal empID As Integer, ByVal leaveType As Integer) As List(Of ResourcePlannerSet)
    Function GetAllLeavesHistoryByEmployee(ByVal empID As Integer, ByVal leaveType As Integer) As List(Of ResourcePlannerSet)
    Function GetAllPerfectAttendance(ByVal email As String, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlannerSet)
    Function GetLeavesByDateAndEmpID(ByVal empID As Integer, ByVal status As Integer, ByVal dateFrom As Date, ByVal dateTo As Date) As List(Of ResourcePlannerSet)
    Function CancelLeave(ByVal resource As ResourcePlannerSet) As Boolean
    Function GetAllNotFiledLeaves(ByVal empID As Integer) As List(Of ResourcePlannerSet)
End Interface
