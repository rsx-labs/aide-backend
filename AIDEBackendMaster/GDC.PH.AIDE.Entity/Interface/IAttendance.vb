
Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAttendanceSet
    Property EmployeeID As Integer
    Property EmployeeName As String
    Property Descr As String
    Property ImagePath As String
    Property Status As Integer
    Property DateEntry As DateTime
    Property Year As Integer
    Property Month As Integer
    Property Day1 As Integer
    Property Day2 As Integer
    Property Day3 As Integer
    Property Day4 As Integer
    Property Day5 As Integer
    Property Day6 As Integer
    Property Day7 As Integer
    Property Day8 As Integer
    Property Day9 As Integer
    Property Day10 As Integer
    Property Day11 As Integer
    Property Day12 As Integer
    Property Day13 As Integer
    Property Day14 As Integer
    Property Day15 As Integer
    Property Day16 As Integer
    Property Day17 As Integer
    Property Day18 As Integer
    Property Day19 As Integer
    Property Day20 As Integer
    Property Day21 As Integer
    Property Day22 As Integer
    Property Day23 As Integer
    Property Day24 As Integer
    Property Day25 As Integer
    Property Day26 As Integer
    Property Day27 As Integer
    Property Day28 As Integer
    Property Day29 As Integer
    Property Day30 As Integer
    Property Day31 As Integer

    Property Monday As Integer

    Property Tuesday As Integer

    Property Wednesday As Integer
    Property Thursday As Integer

    Property Friday As Integer

    Function Insert() As Boolean
    Function Update() As Boolean

    Function Update(ByVal empid As Integer, ByVal day As Integer, ByVal status As Integer) As Boolean
    Function GetAttendanceMonthly(ByVal month As Integer, ByVal year As Integer) As List(Of AttendanceSet)
    Function GetAttendanceToday(ByVal email As String) As List(Of AttendanceSet)
    Function GetAttendanceTodayBySearch(ByVal email As String, ByVal input As String) As List(Of AttendanceSet)
    Function GetAttendanceWeekly(ByVal empId As Integer, ByVal weekOf As Date) As List(Of AttendanceSet)
    'Sub Update(ByVal day As Integer, ByVal status As Integer)

    'Function GetAttendanceByID(ByVal EmpId As Integer) As cls




End Interface


