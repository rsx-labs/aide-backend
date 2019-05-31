Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class ComcellClockSet
    Implements IComcellClockSet, INotifyPropertyChanged

    Private cComcellClock As clsComcellClock
    Private cComcellClockFactory As clsComcellClockFactory
    Public Sub New()
        cComcellClock = New clsComcellClock()
        cComcellClockFactory = New clsComcellClockFactory()
    End Sub

    Public Sub New(ByVal objComcellClock As clsComcellClock)
        cComcellClock = objComcellClock
        cComcellClockFactory = New clsComcellClockFactory()
    End Sub


    Public Property ClockDay As Integer Implements IComcellClockSet.ClockDay
        Get
            Return cComcellClock.CLOCK_DAY
        End Get
        Set(value As Integer)
            cComcellClock.CLOCK_DAY = value
        End Set
    End Property

    Public Property ClockHour As Integer Implements IComcellClockSet.ClockHour
        Get
            Return cComcellClock.CLOCK_HOUR
        End Get
        Set(value As Integer)
            cComcellClock.CLOCK_HOUR = value
        End Set
    End Property
    Public Property ClockMinute As Integer Implements IComcellClockSet.ClockMinute
        Get
            Return cComcellClock.CLOCK_MINUTE
        End Get
        Set(value As Integer)
            cComcellClock.CLOCK_MINUTE = value
        End Set
    End Property

    Public Property EmpID As Integer Implements IComcellClockSet.EmpID
        Get
            Return cComcellClock.EMP_ID
        End Get
        Set(value As Integer)
            cComcellClock.EMP_ID = value
        End Set
    End Property

    Public Function GetSelectClockByEmpID(empid As Integer) As ComcellClockSet Implements IComcellClockSet.GetSelectClockByEmpID
         Try
            Dim cComClock As clsComcellClock
            Dim keys As clsComcellClockKeys = New clsComcellClockKeys(empid)
            cComClock = cComcellClockFactory.GetByPrimaryKey(keys)
            If Not IsNothing(cComClock) Then
                Dim cComClockSet As New ComcellClockSet(cComClock)
                Return cComClockSet
            Else
                Throw New ComCellClockNotFoundException("Clock not set!")
            End If

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateClockTime() As Boolean Implements IComcellClockSet.UpdateActionList
        Try
            Return Me.cComcellClockFactory.Update(cComcellClock)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
