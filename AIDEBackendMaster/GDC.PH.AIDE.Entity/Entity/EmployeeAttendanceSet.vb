
Imports GDC.PH.AIDE.Entity
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer

Public Class EmployeeAttendanceSet
    Implements IEmployeeAttendanceSet, INotifyPropertyChanged


    Private listEmployeeAttendance As New List(Of clsEmployeeAttendance)

    Private cEmployeeAttendance As clsEmployeeAttendance
    Private cEmployeeAttendanceFactory As clsEmployeeAttendanceFACTORY

    Public Sub New()
        cEmployeeAttendance = New clsEmployeeAttendance
        cEmployeeAttendanceFactory = New clsEmployeeAttendanceFACTORY
    End Sub


    Public Property DateNow As Integer Implements IEmployeeAttendanceSet.DateNow
        Get
            Return Me.cEmployeeAttendance.DateNow

        End Get
        Set(value As Integer)
            Me.cEmployeeAttendance.DateNow = value
        End Set
    End Property

    Public Property EmployeeID As Integer Implements IEmployeeAttendanceSet.EmployeeID
        Get
            Return Me.cEmployeeAttendance.EMP_ID

        End Get
        Set(value As Integer)
            Me.cEmployeeAttendance.EMP_ID = value
        End Set
    End Property

    Public Property FirstName As String Implements IEmployeeAttendanceSet.FirstName
        Get
            Return Me.cEmployeeAttendance.FIRST_NAME

        End Get
        Set(value As String)
            Me.cEmployeeAttendance.FIRST_NAME = value
        End Set
    End Property
    Public Property LastName As String Implements IEmployeeAttendanceSet.LastName
        Get
            Return Me.cEmployeeAttendance.LAST_NAME

        End Get
        Set(value As String)
            Me.cEmployeeAttendance.LAST_NAME = value
        End Set
    End Property
    Public Property Month As Integer Implements IEmployeeAttendanceSet.Month
        Get
            Return Me.cEmployeeAttendance.MONTH
        End Get
        Set(value As Integer)
            Me.cEmployeeAttendance.MONTH = value
        End Set
    End Property
    Public Property Position As String Implements IEmployeeAttendanceSet.Position
        Get
            Return Me.cEmployeeAttendance.POSITION

        End Get
        Set(value As String)
            Me.cEmployeeAttendance.POSITION = value
        End Set
    End Property
    Public Property Year As Integer Implements IEmployeeAttendanceSet.Year
        Get
            Return Me.cEmployeeAttendance.YEAR

        End Get
        Set(value As Integer)
            Me.cEmployeeAttendance.YEAR = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Sub GetAttendance() Implements IEmployeeAttendanceSet.GetAttendance
        Try
            listEmployeeAttendance = Me.cEmployeeAttendanceFactory.GetAll
            For Each employee As clsEmployeeAttendance In listEmployeeAttendance
                If employee.EMP_ID = Me.EmployeeID Then
                    cEmployeeAttendance = employee
                End If
            Next
        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New NoRecordFoundException("No Record Found")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
        End Try
    End Sub
End Class
