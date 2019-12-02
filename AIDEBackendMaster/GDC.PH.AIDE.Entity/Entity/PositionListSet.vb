Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class PositionListSet
    Implements IPositionListSet, INotifyPropertyChanged

    Private cPosition As clsPositionList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cPosition = New clsPositionList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsPositionList)
        cPosition = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property POS_DESCR As String Implements IPositionListSet.POS_DESCR
        Get
            Return cPosition.POS_DESCR
        End Get
        Set(value As String)
            cPosition.POS_DESCR = value
        End Set
    End Property
    Public Property POS_ID As Integer Implements IPositionListSet.POS_ID
        Get
            Return cPosition.POS_ID
        End Get
        Set(value As Integer)
            cPosition.POS_ID = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllPosition() As List(Of PositionListSet) Implements IPositionListSet.GetAllPosition
        Dim cList As List(Of clsPositionList)
        Dim cListSet As New List(Of PositionListSet)
        Try

            cList = cSelectionFactory.GetAllPosition()

            If Not IsNothing(cList) Then
                For Each cObject As clsPositionList In cList
                    cListSet.Add(New PositionListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class

Public Class LocationListSet
    Implements ILocationListSet, INotifyPropertyChanged

    Private cLocation As clsLocationList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cLocation = New clsLocationList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsLocationList)
        cLocation = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property LOCATION_ID As Integer Implements ILocationListSet.LOCATION_ID
        Get
            Return cLocation.LOCATION_ID
        End Get
        Set(value As Integer)
            cLocation.LOCATION_ID = value
        End Set
    End Property

    Public Property LOCATION As String Implements ILocationListSet.LOCATION
        Get
            Return cLocation.LOCATION
        End Get
        Set(value As String)
            cLocation.LOCATION = value
        End Set
    End Property

    Public Property ONSITE_FLG As Short Implements ILocationListSet.ONSITE_FLG
        Get
            Return cLocation.ONSITE_FLG
        End Get
        Set(value As Short)
            cLocation.ONSITE_FLG = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllLocation() As List(Of LocationListSet) Implements ILocationListSet.GetAllLocation
        Dim cList As List(Of clsLocationList)
        Dim cListSet As New List(Of LocationListSet)
        Try

            cList = cSelectionFactory.GetAllLocation()

            If Not IsNothing(cList) Then
                For Each cObject As clsLocationList In cList
                    cListSet.Add(New LocationListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class

Public Class PermissionListSet
    Implements IPermissionListSet, INotifyPropertyChanged

    Private cPermission As clsPermissionList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cPermission = New clsPermissionList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsPermissionList)
        cPermission = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property GRP_DESCR As String Implements IPermissionListSet.GRP_DESCR
        Get
            Return cPermission.GRP_DESCR
        End Get
        Set(value As String)
            cPermission.GRP_DESCR = value
        End Set
    End Property
    Public Property GRP_ID As Integer Implements IPermissionListSet.GRP_ID
        Get
            Return cPermission.GRP_ID
        End Get
        Set(value As Integer)
            cPermission.GRP_ID = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllPermission() As List(Of PermissionListSet) Implements IPermissionListSet.GetAllPermission
        Dim cList As List(Of clsPermissionList)
        Dim cListSet As New List(Of PermissionListSet)
        Try

            cList = cSelectionFactory.GetAllPermission()

            If Not IsNothing(cList) Then
                For Each cObject As clsPermissionList In cList
                    cListSet.Add(New PermissionListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class
Public Class DepartmentListSet
    Implements IDepartmentListSet, INotifyPropertyChanged

    Private cDepartment As clsDepartmentList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cDepartment = New clsDepartmentList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsDepartmentList)
        cDepartment = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property DEPT_DESCR As String Implements IDepartmentListSet.DEPT_DESCR
        Get
            Return cDepartment.DEPT_DESCR
        End Get
        Set(value As String)
            cDepartment.DEPT_DESCR = value
        End Set
    End Property
    Public Property DEPT_ID As Integer Implements IDepartmentListSet.DEPT_ID
        Get
            Return cDepartment.DEPT_ID
        End Get
        Set(value As Integer)
            cDepartment.DEPT_ID = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllDepartment() As List(Of DepartmentListSet) Implements IDepartmentListSet.GetAllDepartment
        Dim cList As List(Of clsDepartmentList)
        Dim cListSet As New List(Of DepartmentListSet)
        Try

            cList = cSelectionFactory.GetAllDepartment()

            If Not IsNothing(cList) Then
                For Each cObject As clsDepartmentList In cList
                    cListSet.Add(New DepartmentListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class
Public Class DivisionListSet
    Implements IDivisionListSet, INotifyPropertyChanged

    Private cDivision As clsDivisionList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cDivision = New clsDivisionList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsDivisionList)
        cDivision = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property DIV_DESCR As String Implements IDivisionListSet.DIV_DESCR
        Get
            Return cDivision.DIV_DESCR
        End Get
        Set(value As String)
            cDivision.DIV_DESCR = value
        End Set
    End Property
    Public Property DIV_ID As Integer Implements IDivisionListSet.DIV_ID
        Get
            Return cDivision.DIV_ID
        End Get
        Set(value As Integer)
            cDivision.DIV_ID = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllDivision() As List(Of DivisionListSet) Implements IDivisionListSet.GetAllDivision
        Dim cList As List(Of clsDivisionList)
        Dim cListSet As New List(Of DivisionListSet)
        Try

            cList = cSelectionFactory.GetAllDivision()

            If Not IsNothing(cList) Then
                For Each cObject As clsDivisionList In cList
                    cListSet.Add(New DivisionListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class

Public Class StatusListSet
    Implements IStatusListSet, INotifyPropertyChanged

    Private cStatus As clsStatusList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cStatus = New clsStatusList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsStatusList)
        cStatus = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Property STATUS_DESCR As String Implements IStatusListSet.STATUS_DESCR
        Get
            Return cStatus.STATUS_DESCR
        End Get
        Set(value As String)
            cStatus.STATUS_DESCR = value
        End Set
    End Property
    Public Property STATUS_ID As Integer Implements IStatusListSet.STATUS_ID
        Get
            Return cStatus.STATUS_ID
        End Get
        Set(value As Integer)
            cStatus.STATUS_ID = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllStatus(statusname As String) As List(Of StatusListSet) Implements IStatusListSet.GetAllStatus
        Dim cList As List(Of clsStatusList)
        Dim cListSet As New List(Of StatusListSet)
        Try

            cList = cSelectionFactory.GetAllStatus(statusname)

            If Not IsNothing(cList) Then
                For Each cObject As clsStatusList In cList
                    cListSet.Add(New StatusListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class

Public Class FiscalYearListSet
    Implements IFiscalYearListSet, INotifyPropertyChanged

    Private cFiscalYear As clsFiscalYearList
    Private cSelectionFactory As clsPositionListFactory

    Public Sub New()
        cFiscalYear = New clsFiscalYearList()
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public Sub New(ByVal obj As clsFiscalYearList)
        cFiscalYear = obj
        cSelectionFactory = New clsPositionListFactory()
    End Sub

    Public ReadOnly Property FISCAL_YEAR As String Implements IFiscalYearListSet.FISCAL_YEAR
        Get
            Return cFiscalYear.FISCAL_YEAR
        End Get
    End Property
   
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllFiscalYear() As List(Of FiscalYearListSet) Implements IFiscalYearListSet.GetAllFiscalYear
        Dim cList As List(Of clsFiscalYearList)
        Dim cListSet As New List(Of FiscalYearListSet)
        Try

            cList = cSelectionFactory.GetAllFiscalYear()

            If Not IsNothing(cList) Then
                For Each cObject As clsFiscalYearList In cList
                    cListSet.Add(New FiscalYearListSet(cObject))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
End Class