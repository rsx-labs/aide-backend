
Imports GDC.PH.AIDE.Entity
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
''' <summary>
''' By Jhunell G. Barcenas / John Harvey Sanchez
''' </summary>
''' <remarks></remarks>
Public Class ResourcePlannerSet
    Implements IResourcePlanner, INotifyPropertyChanged

    Private cResourcePlanner As clsResourcePlanner
    Private cResourcePlannerFactory As clsResourcePlannerFactory

    Public Sub New()
        cResourcePlanner = New clsResourcePlanner()
        cResourcePlannerFactory = New clsResourcePlannerFactory()
    End Sub

    Public Sub New(ByVal _resourcePlanner As clsResourcePlanner)
        cResourcePlanner = _resourcePlanner
        cResourcePlannerFactory = New clsResourcePlannerFactory()
    End Sub

    Public Property EmployeeID As Integer Implements IResourcePlanner.EmployeeID
        Get
            Return Me.cResourcePlanner.EMP_ID
        End Get
        Set(value As Integer)
            Me.cResourcePlanner.EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Name As String Implements IResourcePlanner.Name
        Get
            Return Me.cResourcePlanner.EMPLOYEE_NAME
        End Get
        Set(value As String)
            Me.cResourcePlanner.EMPLOYEE_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property dateFrom As Date Implements IResourcePlanner.dateFrom
        Get
            Return Me.cResourcePlanner.from
        End Get
        Set(value As Date)
            Me.cResourcePlanner.from = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property dateTo As Date Implements IResourcePlanner.dateTo
        Get
            Return Me.cResourcePlanner.to
        End Get
        Set(value As Date)
            Me.cResourcePlanner.to = value
            NotifyPropertyChanged()
        End Set
    End Property

	Public Property Status As String Implements IResourcePlanner.Status
		Get
			Return Me.cResourcePlanner.STATUS
		End Get
		Set(value As String)
			Me.cResourcePlanner.STATUS = value
			NotifyPropertyChanged()
		End Set
	End Property

	Public Property UsedLeaves As Double Implements IResourcePlanner.UsedLeaves
        Get
            Return Me.cResourcePlanner.USEDLEAVES
        End Get
        Set(value As Double)
            Me.cResourcePlanner.USEDLEAVES = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property TotalBalance As Double Implements IResourcePlanner.TotalBalance
        Get
            Return Me.cResourcePlanner.TOTALBALANCE
        End Get
        Set(value As Double)
            Me.cResourcePlanner.TOTALBALANCE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property HalfBalance As Double Implements IResourcePlanner.HalfBalance
        Get
            Return Me.cResourcePlanner.HALFBALANCE
        End Get
        Set(value As Double)
            Me.cResourcePlanner.HALFBALANCE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Description As String Implements IResourcePlanner.Description
        Get
            Return Me.cResourcePlanner.DESCR
        End Get
        Set(value As String)
            Me.cResourcePlanner.DESCR = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Image_Path As String Implements IResourcePlanner.Image_Path
        Get
            Return Me.cResourcePlanner.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cResourcePlanner.IMAGE_PATH = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Date_Entry As Date Implements IResourcePlanner.dateEntry
        Get
            Return Me.cResourcePlanner.DATE_ENTRY
        End Get
        Set(value As Date)
            Me.cResourcePlanner.DATE_ENTRY = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property holidayHours As Double Implements IResourcePlanner.holidayHours
        Get
            Return Me.cResourcePlanner.HOLIDAYHOURS
        End Get
        Set(value As Double)
            Me.cResourcePlanner.HOLIDAYHOURS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property vlHours As Double Implements IResourcePlanner.vlHours
        Get
            Return Me.cResourcePlanner.VLHOURS
        End Get
        Set(value As Double)
            Me.cResourcePlanner.VLHOURS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property slHours As Double Implements IResourcePlanner.slHours
        Get
            Return Me.cResourcePlanner.SLHOURS
        End Get
        Set(value As Double)
            Me.cResourcePlanner.SLHOURS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Duration As Double Implements IResourcePlanner.Duration
        Get
            Return Me.cResourcePlanner.DURATION
        End Get
        Set(value As Double)
            Me.cResourcePlanner.DURATION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property EndDate As Date Implements IResourcePlanner.EndDate
        Get
            Return Me.cResourcePlanner.END_DATE
        End Get
        Set(value As Date)
            Me.cResourcePlanner.END_DATE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property StartDate As Date Implements IResourcePlanner.StartDate
        Get
            Return Me.cResourcePlanner.START_DATE
        End Get
        Set(value As Date)
            Me.cResourcePlanner.START_DATE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property StatusCD As Integer Implements IResourcePlanner.StatusCD
        Get
            Return Me.cResourcePlanner.STATUS_CD
        End Get
        Set(value As Integer)
            Me.cResourcePlanner.STATUS_CD = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Comment As String Implements IResourcePlanner.Comment
        Get
            Return Me.cResourcePlanner.COMMENT
        End Get
        Set(value As String)
            Me.cResourcePlanner.COMMENT = value
        End Set
    End Property

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

#Region "Resource Planner"
    Public Function InsertAttendanceForLeaves(resource As ResourcePlannerSet) As Boolean Implements IResourcePlanner.InsertAttendanceForLeaves
        Try
            Return Me.cResourcePlannerFactory.InsertAttendanceForLeaves(cResourcePlanner)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateResourcePlanner(resource As ResourcePlannerSet) As Boolean Implements IResourcePlanner.UpdateResourcePlanner
        Try
            Return Me.cResourcePlannerFactory.UpdateResourcePlanner(cResourcePlanner)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function ViewEmpResourcePlanner(email As String) As List(Of ResourcePlannerSet) Implements IResourcePlanner.ViewEmpResourcePlanner
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.ViewEmpResourcePlanner(email)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetStatusResourcePlanner(empID As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetStatusResourcePlanner
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetStatusResourcePlanner(empID)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetResourcePlannerByEmpID(empId As Integer, deptID As Integer, month As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetResourcePlannerByEmpID
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetResourcePlannerByEmpID(empId, deptID, month, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllEmpResourcePlanner(email As String, month As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllEmpResourcePlanner
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllEmpResourcePlanner(email, month, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllPerfectAttendance(email As String, month As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllPerfectAttendance
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllPerfectAttendance(email, month, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllEmpResourcePlannerByStatus(email As String, month As Integer, year As Integer, status As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllEmpResourcePlannerByStatus
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllEmpResourcePlannerByStatus(email, month, year, status)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllStatusResourcePlanner() As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllStatusResourcePlanner
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllStatusResourcePlanner()

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


    Public Function GetResourcePlanner(email As String, status As Integer, toBeDisplayed As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetResourcePlanner
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetResourcePlanner(email, status, toBeDisplayed, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


    Public Function GetBillableHoursByMonth(empID As Integer, month As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetBillableHoursByMonth
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetBillableHoursByMonth(empID, month, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetBillableHoursByWeek(empID As Integer, weekID As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetBillableHoursByWeek
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetBillableHoursByWeek(empID, weekID)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetNonBillableHours(email As String, display As Integer, month As Integer, year As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetNonBillableHours
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetNonBillableHours(email, display, month, year)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllLeavesByEmployee(empID As Integer, leaveType As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllLeavesByEmployee
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllLeavesByEmployee(empID, leaveType)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllLeavesHistoryByEmployee(empID As Integer, leaveType As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllLeavesHistoryByEmployee
        Try
            Dim ResourceLst As List(Of clsResourcePlanner)
            Dim ResourceSetLst As New List(Of ResourcePlannerSet)

            ResourceLst = cResourcePlannerFactory.GetAllLeavesHistoryByEmployee(empID, leaveType)

            If Not IsNothing(ResourceLst) Then
                For Each cList As clsResourcePlanner In ResourceLst
                    ResourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return ResourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function CancelLeave(resource As ResourcePlannerSet) As Boolean Implements IResourcePlanner.CancelLeave
        Try
            Return Me.cResourcePlannerFactory.CancelLeave(cResourcePlanner)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetLeavesByDateAndEmpID(empID As Integer, status As Integer, dateFrom As Date, dateTo As Date) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetLeavesByDateAndEmpID
        Try
            Dim resourceLst As List(Of clsResourcePlanner)
            Dim resourceSetLst As New List(Of ResourcePlannerSet)

            resourceLst = cResourcePlannerFactory.GetLeavesByDateAndEmpID(empID, status, dateFrom, dateTo)

            If Not IsNothing(resourceLst) Then
                For Each cList As clsResourcePlanner In resourceLst
                    resourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return resourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllNotFiledLeaves(empID As Integer) As List(Of ResourcePlannerSet) Implements IResourcePlanner.GetAllNotFiledLeaves
        Try
            Dim resourceLst As List(Of clsResourcePlanner)
            Dim resourceSetLst As New List(Of ResourcePlannerSet)

            resourceLst = cResourcePlannerFactory.GetAllNotFiledLeave(empID)

            If Not IsNothing(resourceLst) Then
                For Each cList As clsResourcePlanner In resourceLst
                    resourceSetLst.Add(New ResourcePlannerSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return resourceSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
#End Region

End Class




