
Imports GDC.PH.AIDE.BusinessLayer
Public Interface IEmployeeAttendanceSet
    Property EmployeeID As Integer
    Property FirstName As String
    Property LastName As String
    Property Position As String
    Property Month As Integer
    Property DateNow As Integer
    Property Year As Integer

    Sub GetAttendance()
    'Function GetAttendanceByID(ByVal EmpId As Integer) As clsEmployeeAttendance

End Interface
