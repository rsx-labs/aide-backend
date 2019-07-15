Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer

Public Class WeeklyReportSet
    Implements IWeeklyReport, INotifyPropertyChanged

    Private cWeeklyReport As clsWeeklyReport
    Private cWeeklyReportFactory As clsWeeklyReportFactory


    Public Sub New()
        cWeeklyReport = New clsWeeklyReport()
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

    Public Sub New(ByVal objTask As clsWeeklyReport)
        cWeeklyReport = objTask
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

#Region "Database Field"

    Public Property WK_ID As Integer Implements IWeeklyReport.WK_ID
        Get
            Return cWeeklyReport.WR_ID
        End Get
        Set(ByVal value As Integer)
            cWeeklyReport.WR_ID = value
        End Set
    End Property

    Public Property WK_RANGE_ID As Integer Implements IWeeklyReport.WK_RANGE_ID
        Get
            Return cWeeklyReport.WR_WEEK_RANGE_ID
        End Get
        Set(ByVal value As Integer)
            cWeeklyReport.WR_WEEK_RANGE_ID = value
        End Set
    End Property

    Public Property PROJ_ID As Integer Implements IWeeklyReport.PROJ_ID
        Get
            Return cWeeklyReport.WR_PROJ_ID
        End Get
        Set(ByVal value As Integer)
            cWeeklyReport.WR_PROJ_ID = value
        End Set
    End Property

    Public Property REWORK As Short Implements IWeeklyReport.REWORK
        Get
            Return cWeeklyReport.WR_REWORK
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_REWORK = value
        End Set
    End Property

    Public Property REF_ID As String Implements IWeeklyReport.REF_ID
        Get
            Return cWeeklyReport.WR_REF_ID
        End Get
        Set(ByVal value As String)
            cWeeklyReport.WR_REF_ID = value
        End Set
    End Property

    Public Property SUBJECT As String Implements IWeeklyReport.SUBJECT
        Get
            Return cWeeklyReport.WR_SUBJECT
        End Get
        Set(ByVal value As String)
            cWeeklyReport.WR_SUBJECT = value
        End Set
    End Property

    Public Property SEVERITY As Short Implements IWeeklyReport.SEVERITY
        Get
            Return cWeeklyReport.WR_SEVERITY
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_SEVERITY = value
        End Set
    End Property

    Public Property INC_TYPE As Short Implements IWeeklyReport.INC_TYPE
        Get
            Return cWeeklyReport.WR_INC_TYPE
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_INC_TYPE = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IWeeklyReport.EMP_ID
        Get
            Return cWeeklyReport.WR_EMP_ID
        End Get
        Set(ByVal value As Integer)
            cWeeklyReport.WR_EMP_ID = value
        End Set
    End Property

    Public Property PHASE() As Short Implements IWeeklyReport.PHASE
        Get
            Return cWeeklyReport.WR_PHASE
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_PHASE = value
        End Set
    End Property

    Public Property STATUS() As Short Implements IWeeklyReport.STATUS
        Get
            Return cWeeklyReport.WR_STATUS
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_STATUS = value
        End Set
    End Property

    Public Property DATE_STARTED As DateTime Implements IWeeklyReport.DATE_STARTED
        Get
            Return cWeeklyReport.WR_DATE_STARTED
        End Get
        Set(ByVal value As DateTime)
            cWeeklyReport.WR_DATE_STARTED = value
        End Set
    End Property

    Public Property DATE_TARGET As DateTime Implements IWeeklyReport.DATE_TARGET
        Get
            Return cWeeklyReport.WR_DATE_TARGET
        End Get
        Set(ByVal value As DateTime)
            cWeeklyReport.WR_DATE_TARGET = value
        End Set
    End Property

    Public Property DATE_FINISHED As DateTime Implements IWeeklyReport.DATE_FINISHED
        Get
            Return cWeeklyReport.WR_DATE_FINISHED
        End Get
        Set(ByVal value As DateTime)
            cWeeklyReport.WR_DATE_FINISHED = value
        End Set
    End Property

    Public Property EFFORT_EST As Double Implements IWeeklyReport.EFFORT_EST
        Get
            Return cWeeklyReport.WR_EFFORT_EST
        End Get
        Set(ByVal value As Double)
            cWeeklyReport.WR_EFFORT_EST = value
        End Set
    End Property

    Public Property ACT_EFFORT_WK As Double Implements IWeeklyReport.ACT_EFFORT_WK
        Get
            Return cWeeklyReport.WR_ACT_EFFORT_WK
        End Get
        Set(ByVal value As Double)
            cWeeklyReport.WR_ACT_EFFORT_WK = value
        End Set
    End Property

    Public Property ACT_EFFORT As Double Implements IWeeklyReport.ACT_EFFORT
        Get
            Return cWeeklyReport.WR_ACT_EFFORT
        End Get
        Set(ByVal value As Double)
            cWeeklyReport.WR_ACT_EFFORT = value
        End Set
    End Property

    Public Property COMMENTS As String Implements IWeeklyReport.COMMENTS
        Get
            Return cWeeklyReport.WR_COMMENTS
        End Get
        Set(ByVal value As String)
            cWeeklyReport.WR_COMMENTS = value
        End Set
    End Property

    Public Property INBOUND_CONTACTS As Short Implements IWeeklyReport.INBOUND_CONTACTS
        Get
            Return cWeeklyReport.WR_INBOUND_CONTACTS
        End Get
        Set(ByVal value As Short)
            cWeeklyReport.WR_INBOUND_CONTACTS = value
        End Set
    End Property
   
#End Region

#Region "STORED PROCS"
    'Public Function getTaskDetailByTaskId(taskID As Integer) As TasksSet Implements ITasks.getTaskDetailByTaskId
    '    Try
    '        Dim key As clsTasksKeys = New clsTasksKeys(taskID)
    '        Dim objTasks As clsTasks
    '        objTasks = Me.cTasksFactory.getTaskDetailByTaskId(key)
    '        If IsNothing(objTasks) Then
    '            Throw New NoRecordFoundException("Record Not Found!")
    '        End If
    '        Dim _tasks As TasksSet = New TasksSet(objTasks)
    '        Return _tasks
    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
    '        Else
    '            Throw ex.InnerException
    '        End If
    '    End Try
    'End Function

    'Public Function getTaskSummaryWeekly(ByVal empId As Integer, dateStart As DateTime) As List(Of TasksSet) Implements ITasks.getTaskSummaryWeekly
    '    Try
    '        Dim objTasksList As List(Of clsTasks)
    '        objTasksList = Me.cTasksFactory.getTaskSummaryWeekly(empId, dateStart)
    '        If IsNothing(objTasksList) Then
    '            Throw New NoRecordFoundException("Record Not Found!")
    '        End If
    '        Dim _tasksList As List(Of TasksSet) = New List(Of TasksSet)
    '        For Each _task As clsTasks In objTasksList
    '            _tasksList.Add(New TasksSet(_task))
    '        Next
    '        Return _tasksList
    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
    '        Else
    '            Throw ex.InnerException
    '        End If
    '    End Try
    'End Function

    'Public Function getMyTasks(ByVal empId As Integer) As List(Of TasksSet) Implements ITasks.getMyTasks
    '    Try
    '        Dim objTasksList As List(Of clsTasks)
    '        objTasksList = Me.cTasksFactory.getMyTasks(empId)
    '        If IsNothing(objTasksList) Then
    '            Throw New NoRecordFoundException("Record Not Found!")
    '        End If
    '        Dim _tasksList As List(Of TasksSet) = New List(Of TasksSet)
    '        For Each _task As clsTasks In objTasksList
    '            _tasksList.Add(New TasksSet(_task))
    '        Next
    '        Return _tasksList
    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
    '        Else
    '            Throw ex.InnerException
    '        End If
    '    End Try
    'End Function

    Public Function InsertWeeklyReport(weeklyReport As WeeklyReportSet) As Boolean Implements IWeeklyReport.InsertWeeklyReport
        Try
            Return Me.cWeeklyReportFactory.Insert(cWeeklyReport)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Weekly Report Failed!")
            End If
        End Try
    End Function

    Public Function UpdateWeeklyReport(weeklyReport As WeeklyReportSet) As Boolean Implements IWeeklyReport.UpdateWeeklyReport
        Try
            Return Me.cWeeklyReportFactory.Update(cWeeklyReport)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Weekly Report Failed!")
            End If
        End Try
    End Function

    Public Function GetWeeklyReportsByWeekRangeID(weekRangeID As Integer, empID As Integer) As List(Of WeeklyReportSet) Implements IWeeklyReport.GetWeeklyReportsByWeekRangeID
        Try
            Dim lstWeeklyReport As List(Of clsWeeklyReport)
            Dim lstWeeklyReportSet As New List(Of WeeklyReportSet)

            lstWeeklyReport = cWeeklyReportFactory.GetWeeklyReportsByWeekRangeID(weekRangeID, empID)

            If Not IsNothing(lstWeeklyReport) Then
                For Each cList As clsWeeklyReport In lstWeeklyReport
                    lstWeeklyReportSet.Add(New WeeklyReportSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstWeeklyReportSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetTasksDataByEmpID(weekRangeID As Integer, empID As Integer) As List(Of WeeklyReportSet) Implements IWeeklyReport.GetTasksDataByEmpID
        Try
            Dim lstWeeklyReport As List(Of clsWeeklyReport)
            Dim lstWeeklyReportSet As New List(Of WeeklyReportSet)

            lstWeeklyReport = cWeeklyReportFactory.GetTasksDataByEmpID(weekRangeID, empID)

            If Not IsNothing(lstWeeklyReport) Then
                For Each cList As clsWeeklyReport In lstWeeklyReport
                    lstWeeklyReportSet.Add(New WeeklyReportSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstWeeklyReportSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
#End Region

    

    'Public Function GetAllTasks() As List(Of TasksSet) Implements ITasks.GetAllTasks
    '    Try
    '        Dim lstTasks As List(Of clsTasks)
    '        Dim lstTasksSet As New List(Of TasksSet)

    '        lstTasks = cTasksFactory.GetAll()

    '        If Not IsNothing(lstTasks) Then
    '            For Each cList As clsTasks In lstTasks
    '                lstTasksSet.Add(New TasksSet(cList))
    '            Next
    '        Else
    '            Throw New NoRecordFoundException("No records found!")
    '        End If

    '        Return lstTasksSet
    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed")
    '        Else
    '            Throw ex.InnerException
    '        End If
    '    End Try
    'End Function

    'Public Function GetTaskDetailByIncidentId(id As Integer) As List(Of TasksSet) Implements ITasks.GetTaskDetailByIncidentId
    '    Try
    '        Dim TaskLst As List(Of clsTasks)
    '        Dim TaskSetLst As New List(Of TasksSet)

    '        TaskLst = cTasksFactory.GetTaskDetailByIncidentId(id)

    '        If Not IsNothing(TaskLst) Then
    '            For Each cList As clsTasks In TaskLst
    '                TaskSetLst.Add(New TasksSet(cList))
    '            Next
    '        Else
    '            Throw New NoRecordFoundException("No records found!")
    '        End If

    '        Return TaskSetLst

    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed")
    '        Else
    '            Throw ex.InnerException
    '        End If
    '    End Try
    'End Function

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class

