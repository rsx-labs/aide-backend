Imports GDC.PH.AIDE.BusinessLayer
Public Interface IBillables
    Property Employeeid As Integer
    Property Nickname As String
    Property Hours As Double
    Property Years As Integer
    Property Months As Integer
    Property VL As Double
    Property SL As Double
    'Property IBP As Double
    Property Holiday As Double
    Property Halfday As Double
    Property HalfVl As Double
    Property HalfSl As Double
    Property Total As Double

    Function sp_getBillabilityHoursAll(ByVal dateStart As Date, dateFinish As Date, userChoice As Integer) As List(Of clsBillables)
    Function sp_getBillabilityHoursByEmpID(ByVal employeeId As Integer, dateStart As Date, dateFinish As Date, userChoice As Integer) As List(Of clsBILLABLES)
    Function sp_getBillableSummary(ByVal month As Integer, year As Integer) As List(Of BillableSet)

End Interface
