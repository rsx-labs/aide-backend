Imports GDC.PH.AIDE.BusinessLayer
Public Interface IBillables
    Property EmployeeID As Integer
    Property Name As String
    Property Hours As Double
    Property Status As Short
    Property Years As Integer
    Property Months As Integer

    'Property VL As Double
    'Property SL As Double
    'Property Holiday As Double

    Function GetBillableHoursByMonth(ByVal employeeId As Integer, ByVal month As Integer, ByVal year As Integer, ByVal weekID As Integer) As List(Of BillableSet)
    Function GetBillableHoursByWeek(ByVal employeeId As Integer, ByVal weekID As Integer) As List(Of BillableSet)
    Function InsertLeaveCredits(ByVal empID As Integer, ByVal year As Integer) As Boolean
    'Function sp_getBillableSummary(ByVal month As Integer, year As Integer) As List(Of BillableSet)

End Interface
