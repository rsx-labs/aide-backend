Imports GDC.PH.AIDE.BusinessLayer
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class TasksSummarySet
    Implements ITasksSummary, INotifyPropertyChanged

    Private cTasks_sp As clsTasks_sp
    Private cTasksFactory As clsTasksFactory

    Public Sub New()
        cTasks_sp = New clsTasks_sp()
        cTasksFactory = New clsTasksFactory
    End Sub

    Public Sub New(ByVal objTask_sp As clsTasks_sp)
        cTasks_sp = objTask_sp
        cTasksFactory = New clsTasksFactory
    End Sub

#Region "Database Field"

    Public Property EmployeeName As String Implements ITasksSummary.EmployeeName
        Get
            Return cTasks_sp.EmployeeName
        End Get
        Set(ByVal value As String)
            cTasks_sp.EmployeeName = value
        End Set
    End Property

    Public Property LastWeekOutstanding As Integer Implements ITasksSummary.LastWeekOutstanding
        Get
            Return cTasks_sp.LastWeekOutstanding
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.LastWeekOutstanding = value
        End Set
    End Property

    Public Property Mon_AT As Integer Implements ITasksSummary.Mon_AT
        Get
            Return cTasks_sp.Mon_AT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Mon_AT = value
        End Set
    End Property

    Public Property Mon_CT As Integer Implements ITasksSummary.Mon_CT
        Get
            Return cTasks_sp.Mon_CT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Mon_CT = value
        End Set
    End Property

    Public Property Mon_OT As Integer Implements ITasksSummary.Mon_OT
        Get
            Return cTasks_sp.Mon_OT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Mon_OT = value
        End Set
    End Property

    Public Property Tue_AT As Integer Implements ITasksSummary.Tue_AT
        Get
            Return cTasks_sp.Tue_AT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Tue_AT = value
        End Set
    End Property

    Public Property Tue_CT As Integer Implements ITasksSummary.Tue_CT
        Get
            Return cTasks_sp.Tue_CT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Tue_CT = value
        End Set
    End Property

    Public Property Tue_OT As Integer Implements ITasksSummary.Tue_OT
        Get
            Return cTasks_sp.Tue_OT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Tue_OT = value
        End Set
    End Property

    Public Property Wed_AT As Integer Implements ITasksSummary.Wed_AT
        Get
            Return cTasks_sp.Wed_AT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Wed_AT = value
        End Set
    End Property

    Public Property Wed_CT As Integer Implements ITasksSummary.Wed_CT
        Get
            Return cTasks_sp.Wed_CT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Wed_CT = value
        End Set
    End Property

    Public Property Wed_OT As Integer Implements ITasksSummary.Wed_OT
        Get
            Return cTasks_sp.Wed_OT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Wed_OT = value
        End Set
    End Property

    Public Property Thu_AT As Integer Implements ITasksSummary.Thu_AT
        Get
            Return cTasks_sp.Thu_AT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Thu_AT = value
        End Set
    End Property

    Public Property Thu_CT As Integer Implements ITasksSummary.Thu_CT
        Get
            Return cTasks_sp.Thu_CT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Thu_CT = value
        End Set
    End Property

    Public Property Thu_OT As Integer Implements ITasksSummary.Thu_OT
        Get
            Return cTasks_sp.Thu_OT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Thu_OT = value
        End Set
    End Property

    Public Property Fri_AT As Integer Implements ITasksSummary.Fri_AT
        Get
            Return cTasks_sp.Fri_AT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Fri_AT = value
        End Set
    End Property

    Public Property Fri_CT As Integer Implements ITasksSummary.Fri_CT
        Get
            Return cTasks_sp.Fri_CT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Fri_CT = value
        End Set
    End Property

    Public Property Fri_OT As Integer Implements ITasksSummary.Fri_OT
        Get
            Return cTasks_sp.Fri_OT
        End Get
        Set(ByVal value As Integer)
            cTasks_sp.Fri_OT = value
        End Set
    End Property

#End Region

#Region "STORED PROCS"

    Public Function getTaskSummaryAll(dateStart As DateTime, email As String) As List(Of TasksSummarySet) Implements ITasksSummary.getTaskSummaryAll
        Try
            Dim objTasksList As List(Of clsTasks_sp)
            objTasksList = cTasksFactory.getTaskSummaryAll(dateStart, email)

            If IsNothing(objTasksList) Then
                Throw New NoRecordFoundException("Record Not Found!")
            End If

            Dim _tasksList As List(Of TasksSummarySet) = New List(Of TasksSummarySet)
            For Each _task As clsTasks_sp In objTasksList
                _tasksList.Add(New TasksSummarySet(_task))
            Next

            Return _tasksList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function getTaskSummaryByEmpId(empID As Integer, dateStart As DateTime) As List(Of TasksSummarySet) Implements ITasksSummary.getTaskSummaryByEmpId
        Try
            Dim objTasksList As List(Of clsTasks_sp)
            objTasksList = Me.cTasksFactory.getTaskSummaryByEmpId(empID, dateStart)

            If IsNothing(objTasksList) Then
                Throw New NoRecordFoundException("Record Not Found!")
            End If

            Dim _tasksList As List(Of TasksSummarySet) = New List(Of TasksSummarySet)
            For Each _task As clsTasks_sp In objTasksList
                _tasksList.Add(New TasksSummarySet(_task))
            Next

            Return _tasksList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

#End Region

#Region "PropertyChange"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
#End Region

End Class

