
Imports GDC.PH.AIDE.Entity
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class AttendanceSet
    Implements IAttendanceSet, INotifyPropertyChanged


    Private cAttendance As clsAttendance
    Private cAttendanceFactory As clsAttendanceFactory
    Public Sub New()
        cAttendance = New clsAttendance()
        cAttendanceFactory = New clsAttendanceFactory()
    End Sub

    Public Sub New(ByVal _attendance As clsAttendance)
        cAttendance = _attendance
        cAttendanceFactory = New clsAttendanceFactory()
    End Sub
    Public Property EmployeeName As String Implements IAttendanceSet.EmployeeName
        Get
            Return Me.cAttendance.EMPLOYEE_NAME
        End Get
        Set(value As String)
            Me.cAttendance.EMPLOYEE_NAME = value
        End Set
    End Property

    Public Property Day1 As Integer Implements IAttendanceSet.Day1
        Get
            Return Me.cAttendance.DAY1
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY1 = value
        End Set
    End Property
    Public Property Day10 As Integer Implements IAttendanceSet.Day10
        Get
            Return Me.cAttendance.DAY10
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY10 = value
        End Set
    End Property
    Public Property Day11 As Integer Implements IAttendanceSet.Day11
        Get
            Return Me.cAttendance.DAY11
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY11 = value
        End Set
    End Property
    Public Property Day12 As Integer Implements IAttendanceSet.Day12
        Get
            Return Me.cAttendance.DAY12
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY12 = value
        End Set
    End Property
    Public Property Day13 As Integer Implements IAttendanceSet.Day13
        Get
            Return Me.cAttendance.DAY13
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY13 = value
        End Set
    End Property
    Public Property Day14 As Integer Implements IAttendanceSet.Day14
        Get
            Return Me.cAttendance.DAY14
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY14 = value
        End Set
    End Property
    Public Property Day15 As Integer Implements IAttendanceSet.Day15
        Get
            Return Me.cAttendance.DAY15
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY15 = value
        End Set
    End Property
    Public Property Day16 As Integer Implements IAttendanceSet.Day16
        Get
            Return Me.cAttendance.DAY16
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY16 = value
        End Set
    End Property
    Public Property Day17 As Integer Implements IAttendanceSet.Day17
        Get
            Return Me.cAttendance.DAY17
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY17 = value
        End Set
    End Property
    Public Property Day18 As Integer Implements IAttendanceSet.Day18
        Get
            Return Me.cAttendance.DAY18
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY18 = value
        End Set
    End Property
    Public Property Day19 As Integer Implements IAttendanceSet.Day19
        Get
            Return Me.cAttendance.DAY19
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY19 = value
        End Set
    End Property
    Public Property Day2 As Integer Implements IAttendanceSet.Day2
        Get
            Return Me.cAttendance.DAY2
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY2 = value
        End Set
    End Property
    Public Property Day20 As Integer Implements IAttendanceSet.Day20
        Get
            Return Me.cAttendance.DAY20
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY20 = value
        End Set
    End Property
    Public Property Day21 As Integer Implements IAttendanceSet.Day21
        Get
            Return Me.cAttendance.DAY21
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY21 = value
        End Set
    End Property
    Public Property Day22 As Integer Implements IAttendanceSet.Day22
        Get
            Return Me.cAttendance.DAY22
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY22 = value
        End Set
    End Property
    Public Property Day23 As Integer Implements IAttendanceSet.Day23
        Get
            Return Me.cAttendance.DAY23
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY23 = value
        End Set
    End Property
    Public Property Day24 As Integer Implements IAttendanceSet.Day24
        Get
            Return Me.cAttendance.DAY24
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY24 = value
        End Set
    End Property
    Public Property Day25 As Integer Implements IAttendanceSet.Day25
        Get
            Return Me.cAttendance.DAY25
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY25 = value
        End Set
    End Property
    Public Property Day26 As Integer Implements IAttendanceSet.Day26
        Get
            Return Me.cAttendance.DAY26
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY26 = value
        End Set
    End Property
    Public Property Day27 As Integer Implements IAttendanceSet.Day27
        Get
            Return Me.cAttendance.DAY27
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY27 = value
        End Set
    End Property
    Public Property Day28 As Integer Implements IAttendanceSet.Day28
        Get
            Return Me.cAttendance.DAY28
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY28 = value
        End Set
    End Property
    Public Property Day29 As Integer Implements IAttendanceSet.Day29
        Get
            Return Me.cAttendance.DAY29
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY29 = value
        End Set
    End Property
    Public Property Day3 As Integer Implements IAttendanceSet.Day3
        Get
            Return Me.cAttendance.DAY3
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY3 = value
        End Set
    End Property
    Public Property Day30 As Integer Implements IAttendanceSet.Day30
        Get
            Return Me.cAttendance.DAY30
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY30 = value
        End Set
    End Property
    Public Property Day31 As Integer Implements IAttendanceSet.Day31
        Get
            Return Me.cAttendance.DAY31
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY31 = value
        End Set
    End Property
    Public Property Day4 As Integer Implements IAttendanceSet.Day4
        Get
            Return Me.cAttendance.DAY4
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY4 = value
        End Set
    End Property
    Public Property Day5 As Integer Implements IAttendanceSet.Day5
        Get
            Return Me.cAttendance.DAY5
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY5 = value
        End Set
    End Property
    Public Property Day6 As Integer Implements IAttendanceSet.Day6
        Get
            Return Me.cAttendance.DAY6
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY6 = value
        End Set
    End Property
    Public Property Day7 As Integer Implements IAttendanceSet.Day7
        Get
            Return Me.cAttendance.DAY7
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY7 = value
        End Set
    End Property
    Public Property Day8 As Integer Implements IAttendanceSet.Day8
        Get
            Return Me.cAttendance.DAY8
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY8 = value
        End Set
    End Property
    Public Property Day9 As Integer Implements IAttendanceSet.Day9
        Get
            Return Me.cAttendance.DAY9
        End Get
        Set(value As Integer)
            Me.cAttendance.DAY9 = value
        End Set
    End Property
    Public Property EmployeeID As Integer Implements IAttendanceSet.EmployeeID
        Get
            Return Me.cAttendance.EMP_ID
        End Get
        Set(value As Integer)
            Me.cAttendance.EMP_ID = value
        End Set
    End Property

    Public Property Month As Integer Implements IAttendanceSet.Month
        Get
            Return IIf(IsDBNull(Me.cAttendance.MONTH), "", Me.cAttendance.MONTH)
        End Get
        Set(value As Integer)
            Me.cAttendance.MONTH = value
        End Set
    End Property
    Public Property Year As Integer Implements IAttendanceSet.Year
        Get
            Return IIf(IsDBNull(Me.cAttendance.YEAR), "", Me.cAttendance.YEAR)
        End Get
        Set(value As Integer)
            Me.cAttendance.YEAR = CInt(value)
        End Set
    End Property

    Public Property Monday As Integer Implements IAttendanceSet.Monday
        Get
            Return Me.cAttendance.MONDAY
        End Get
        Set(value As Integer)
            Me.cAttendance.MONDAY = value
        End Set
    End Property

    Public Property Tuesday As Integer Implements IAttendanceSet.Tuesday
        Get
            Return Me.cAttendance.TUESDAY
        End Get
        Set(value As Integer)
            Me.cAttendance.TUESDAY = value
        End Set
    End Property

    Public Property Wednesday As Integer Implements IAttendanceSet.Wednesday
        Get
            Return Me.cAttendance.WEDNESDAY
        End Get
        Set(value As Integer)
            Me.cAttendance.WEDNESDAY = value
        End Set
    End Property

    Public Property Thursday As Integer Implements IAttendanceSet.Thursday
        Get
            Return Me.cAttendance.THURSDAY
        End Get
        Set(value As Integer)
            Me.cAttendance.THURSDAY = value
        End Set
    End Property

    Public Property Friday As Integer Implements IAttendanceSet.Friday
        Get
            Return Me.cAttendance.FRIDAY
        End Get
        Set(value As Integer)
            Me.cAttendance.FRIDAY = value
        End Set
    End Property

    Public Property STATUS As Integer Implements IAttendanceSet.Status
        Get
            Return Me.cAttendance.STATUS
        End Get
        Set(value As Integer)
            Me.cAttendance.STATUS = value
        End Set
    End Property

    Public Property IMAGE_PATH As String Implements IAttendanceSet.ImagePath
        Get
            Return Me.cAttendance.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cAttendance.IMAGE_PATH = value
        End Set
    End Property

    Public Property DESCR As String Implements IAttendanceSet.Descr
        Get
            Return Me.cAttendance.DESCR
        End Get
        Set(value As String)
            Me.cAttendance.DESCR = value
        End Set
    End Property

    Public Property DATE_ENTRY As DateTime Implements IAttendanceSet.DateEntry
        Get
            Return Me.cAttendance.DATE_ENTRY
        End Get
        Set(value As DateTime)
            Me.cAttendance.DATE_ENTRY = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function Insert() As Boolean Implements IAttendanceSet.Insert
        Try
            Return Me.cAttendanceFactory.Insert(cAttendance)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function Update() As Boolean Implements IAttendanceSet.Update
        Try
            Return Me.cAttendanceFactory.Update(cAttendance)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


    Public Function UpdateAttendance(ByVal empid As Integer, ByVal day As Integer, status As Integer) As Boolean Implements IAttendanceSet.Update
        Try
            Dim curdate As Date = Date.Now
            cAttendance.MONTH = curdate.Month
            cAttendance.YEAR = curdate.Year
            cAttendance.EMP_ID = empid
            Return Me.cAttendanceFactory.Update(cAttendance, day, status)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAttendanceMonthly(month As Integer, year As Integer) As List(Of AttendanceSet) Implements IAttendanceSet.GetAttendanceMonthly
        Try
            Dim keys As clsAttendanceKeys = New clsAttendanceKeys(0, month, year)
            Dim objAttendanceList As List(Of clsAttendance)
            objAttendanceList = Me.cAttendanceFactory.GetByMothly(keys)
            If IsNothing(objAttendanceList) Then
                Throw New NoRecordFoundException("No records Found!")
            End If
            Dim _attendanceList As List(Of AttendanceSet) = New List(Of AttendanceSet)
            For Each _attendance As clsAttendance In objAttendanceList
                _attendanceList.Add(New AttendanceSet(_attendance))
            Next
            Return _attendanceList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAttendanceWeekly(empId As Integer, ByVal weekOf As Date) As List(Of AttendanceSet) Implements IAttendanceSet.GetAttendanceWeekly
        Try

            Dim objAttendanceList As List(Of clsAttendance)
            objAttendanceList = Me.cAttendanceFactory.GetByWeekly(empId, weekOf)
            If IsNothing(objAttendanceList) Then
                Throw New NoRecordFoundException("No records Found!")
            End If
            Dim _attendanceList As List(Of AttendanceSet) = New List(Of AttendanceSet)
            For Each _attendance As clsAttendance In objAttendanceList
                _attendanceList.Add(New AttendanceSet(_attendance))
            Next
            Return _attendanceList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAttendanceToday(email As String) As List(Of AttendanceSet) Implements IAttendanceSet.GetAttendanceToday
        Try
            Dim AttendanceLst As List(Of clsAttendance)
            Dim AttendanceSetLst As New List(Of AttendanceSet)

            AttendanceLst = cAttendanceFactory.GetAttendanceToday(email)

            If Not IsNothing(AttendanceLst) Then
                For Each cList As clsAttendance In AttendanceLst
                    AttendanceSetLst.Add(New AttendanceSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return AttendanceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAttendanceTodayBySearch(email As String, input As String) As List(Of AttendanceSet) Implements IAttendanceSet.GetAttendanceTodayBySearch
        Try
            Dim AttendanceLst As List(Of clsAttendance)
            Dim AttendanceSetLst As New List(Of AttendanceSet)

            AttendanceLst = cAttendanceFactory.GetAttendanceTodayBySearch(email, input)

            If Not IsNothing(AttendanceLst) Then
                For Each cList As clsAttendance In AttendanceLst
                    AttendanceSetLst.Add(New AttendanceSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return AttendanceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

End Class




