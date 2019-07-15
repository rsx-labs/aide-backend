Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class BillableSet
    Implements IBillables, INotifyPropertyChanged

    Private cBillables As clsBillables
    Private cBillableFactory As clsBillablesFactory

    Public Sub New()
        cBillables = New clsBillables()
        cBillableFactory = New clsBillablesFactory()
    End Sub

    Public Sub New(clsBillables As clsBillables)
        cBillables = clsBillables
        cBillableFactory = New clsBillablesFactory()
    End Sub

    Public Property EmployeeID As Integer Implements IBillables.EmployeeID
        Get
            Return Me.cBillables.EMPID
        End Get
        Set(value As Integer)
            Me.cBillables.EMPID = value
            NotifyPropertyChanged("EmployeeID")
        End Set
    End Property

    Public Property Name As String Implements IBillables.Name
        Get
            Return Me.cBillables.NAME
        End Get
        Set(value As String)
            Me.cBillables.NAME = value
            NotifyPropertyChanged("Name")
        End Set
    End Property

    Public Property Hours As Double Implements IBillables.Hours
        Get
            Return Me.cBillables.TOTAL_HOURS
        End Get
        Set(value As Double)
            Me.cBillables.TOTAL_HOURS = value
            NotifyPropertyChanged("Hours")
        End Set
    End Property

    Public Property Status As Short Implements IBillables.Status
        Get
            Return Me.cBillables.BILL_STATUS
        End Get
        Set(value As Short)
            Me.cBillables.BILL_STATUS = value
            NotifyPropertyChanged("Status")
        End Set
    End Property

    Public Property Months As Integer Implements IBillables.Months
        Get
            Return Me.cBillables.MONTH
        End Get
        Set(value As Integer)
            Me.cBillables.MONTH = value
            NotifyPropertyChanged("Months")
        End Set
    End Property

    Public Property Years As Integer Implements IBillables.Years
        Get
            Return Me.cBillables.YEAR
        End Get
        Set(value As Integer)
            Me.cBillables.YEAR = value
            NotifyPropertyChanged("Years")
        End Set
    End Property

    'Public Property VL As Double Implements IBillables.VL
    '    Get
    '        Return Me.cBillables.VL
    '    End Get
    '    Set(value As Double)
    '        Me.cBillables.VL = value
    '        NotifyPropertyChanged("VL")
    '    End Set
    'End Property

    'Public Property SL As Double Implements IBillables.SL
    '    Get
    '        Return Me.cBillables.SL
    '    End Get
    '    Set(value As Double)
    '        Me.cBillables.SL = value
    '        NotifyPropertyChanged("SL")
    '    End Set
    'End Property

    'Public Property Holiday As Double Implements IBillables.Holiday
    '    Get
    '        Return Me.cBillables.HOLIDAY
    '    End Get
    '    Set(value As Double)
    '        Me.cBillables.HOLIDAY = value
    '        NotifyPropertyChanged("HOLIDAY")
    '    End Set
    'End Property

    Public Function GetBillableHoursByMonth(employeeID As Integer, months As Integer, years As Integer) As List(Of BillableSet) Implements IBillables.GetBillableHoursByMonth
        Try
            Dim keys As clsBillablesKeys = New clsBillablesKeys(employeeID, months, years)

            Dim BillablesLst As List(Of clsBillables)
            Dim BillablesSetLst As New List(Of BillableSet)

            BillablesLst = cBillableFactory.GetBillableHoursByMonth(keys)

            If Not IsNothing(BillablesLst) Then
                For Each cList As clsBillables In BillablesLst
                    BillablesSetLst.Add(New BillableSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return BillablesSetLst
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetBillableHoursByWeek(employeeID As Integer, weekID As Integer) As List(Of BillableSet) Implements IBillables.GetBillableHoursByWeek
        Try
            Dim BillablesLst As List(Of clsBillables)
            Dim BillablesSetLst As New List(Of BillableSet)

            BillablesLst = cBillableFactory.GetBillableHoursByWeek(employeeID, weekID)

            If Not IsNothing(BillablesLst) Then
                For Each cList As clsBillables In BillablesLst
                    BillablesSetLst.Add(New BillableSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return BillablesSetLst

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
