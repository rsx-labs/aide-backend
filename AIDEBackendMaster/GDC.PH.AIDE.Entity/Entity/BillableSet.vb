Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer

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
        cBillableFactory = New clsBILLABLESFactory()
    End Sub

    Public Property Employeeid As Integer Implements IBillables.Employeeid
        Get
            Return Me.cBillables.EMPID
        End Get
        Set(value As Integer)
            Me.cBillables.EMPID = value
            NotifyPropertyChanged("Employeeid")
        End Set
    End Property

    Public Property Hours As Double Implements IBillables.Hours
        Get
            Return Me.cBillables.HOURS
        End Get
        Set(value As Double)
            Me.cBillables.HOURS = value
            NotifyPropertyChanged("Hours")
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

    Public Property Nickame As String Implements IBillables.Nickname
        Get
            Return Me.cBillables.NICK_NAME
        End Get
        Set(value As String)
            Me.cBillables.NICK_NAME = value
            NotifyPropertyChanged("Nickname")
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

    Public Property VL As Double Implements IBillables.VL
        Get
            Return Me.cBillables.VL
        End Get
        Set(value As Double)
            Me.cBillables.VL = value
            NotifyPropertyChanged("VL")
        End Set
    End Property

    Public Property SL As Double Implements IBillables.SL
        Get
            Return Me.cBillables.SL
        End Get
        Set(value As Double)
            Me.cBillables.SL = value
            NotifyPropertyChanged("SL")
        End Set
    End Property

    'Public Property IBP As Double Implements IBillables.IBP
    '    Get
    '        Return Me.cBillables.IBP
    '    End Get
    '    Set(value As Double)
    '        Me.cBillables.IBP = value
    '        NotifyPropertyChanged("IBP")
    '    End Set
    'End Property

    Public Property Holiday As Double Implements IBillables.Holiday
        Get
            Return Me.cBillables.HOLIDAY
        End Get
        Set(value As Double)
            Me.cBillables.HOLIDAY = value
            NotifyPropertyChanged("HOLIDAY")
        End Set
    End Property

    Public Property Total As Double Implements IBillables.Total
        Get
            Return Me.cBillables.TOTAL
        End Get
        Set(value As Double)
            Me.cBillables.TOTAL = value
            NotifyPropertyChanged("TOTAL")
        End Set
    End Property

    Public Property Halfday As Double Implements IBillables.Halfday
        Get
            Return Me.cBillables.HALFDAY
        End Get
        Set(value As Double)
            Me.cBillables.TOTAL = value
            NotifyPropertyChanged("HALFDAY")
        End Set
    End Property

    Public Property HalfSl As Double Implements IBillables.HalfSl
        Get
            Return Me.cBillables.HALFSL
        End Get
        Set(value As Double)
            Me.cBillables.HALFSL = value
            NotifyPropertyChanged("HALFSL")
        End Set
    End Property

    Public Property HalfVl As Double Implements IBillables.HalfVl
        Get
            Return Me.cBillables.HALFVL
        End Get
        Set(value As Double)
            Me.cBillables.HALFVL = value
            NotifyPropertyChanged("HALFVL")
        End Set
    End Property

    Public Function sp_getBillabilityHoursAll(dateStart As Date, dateFinish As Date, userChoice As Integer) As List(Of clsBillables) Implements IBillables.sp_getBillabilityHoursAll
        Try
            Dim keys As clsBillablesKeys = New clsBillablesKeys(0, dateStart, dateFinish, userChoice, Months, Years)

            Dim lstOfBillables As List(Of clsBillables) = cBillableFactory.sp_getBillabilityHoursAll(keys)

            Return lstOfBillables
        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Return Nothing
        End Try
    End Function

    Public Function sp_getBillabilityHoursByEmpID(employeeId As Integer, dateStart As Date, dateFinish As Date, userChoice As Integer) As List(Of clsBillables) Implements IBillables.sp_getBillabilityHoursByEmpID
        Try
            Dim keys As clsBillablesKeys = New clsBillablesKeys(employeeId, dateStart, dateFinish, userChoice, dateFinish.Month, dateFinish.Year)
            Dim lstOfBillables As List(Of clsBillables) = cBillableFactory.sp_getBillabilityHoursByEmpID(keys)
            Return lstOfBillables
        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New EmployeeNotFoundException("Employee Not Found")

            End If
            Return Nothing
        End Try
    End Function

    Public Function sp_getBillableSummary(month As Integer, year As Integer) As List(Of BillableSet) Implements IBillables.sp_getBillableSummary
        Try
            Dim keys As clsBillablesKeys = New clsBillablesKeys(0, #1/1/1900#, #1/1/1900#, 0, month, year)
            Dim lstOfBillables As List(Of clsBILLABLES) = cBillableFactory.sp_getBillableSummary(keys)
            Dim lstOfBillableSet As New List(Of BillableSet)
            For Each objOfBillables As clsBILLABLES In lstOfBillables
                lstOfBillableSet.Add(New BillableSet(objOfBillables))
            Next
            Return lstOfBillableSet
        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New EmployeeNotFoundException("Employee Not Found")

            End If
            Return Nothing
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
