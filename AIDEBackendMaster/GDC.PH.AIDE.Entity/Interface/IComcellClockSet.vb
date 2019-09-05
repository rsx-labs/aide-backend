Imports GDC.PH.AIDE.BusinessLayer
Public Interface IComcellClockSet
    Property ClockDay As Integer
    Property ClockHour As Integer
    Property ClockMinute As Integer
    Property EmpID As Integer
    Property Midday As String

    Function GetSelectClockByEmpID(ByVal empid As Integer) As ComcellClockSet
    Function UpdateActionList() As Boolean
End Interface
