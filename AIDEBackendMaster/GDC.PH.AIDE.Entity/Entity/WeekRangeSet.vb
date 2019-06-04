Imports GDC.PH.AIDE.BusinessLayer
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class WeekRangeSet
    Implements IWeekRange, INotifyPropertyChanged

    Private cWeekRange As clsWeekRange
    Private cWeeklyReportFactory As clsWeeklyReportFactory

    Public Sub New()
        cWeekRange = New clsWeekRange()
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

    Public Sub New(ByVal objWeekRange As clsWeekRange)
        cWeekRange = objWeekRange
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

#Region "Database Field"

    Public Property WeekRangeID As Integer Implements IWeekRange.WeekRangeID
        Get
            Return cWeekRange.WeekRangeID
        End Get
        Set(ByVal value As Integer)
            cWeekRange.WeekRangeID = value
        End Set
    End Property

    Public Property StartWeek As Date Implements IWeekRange.StartDate
        Get
            Return cWeekRange.StartWeek
        End Get
        Set(ByVal value As Date)
            cWeekRange.StartWeek = value
        End Set
    End Property

    Public Property EndWeek As Date Implements IWeekRange.EndDate
        Get
            Return cWeekRange.EndWeek
        End Get
        Set(ByVal value As Date)
            cWeekRange.EndWeek = value
        End Set
    End Property

    Public Property DateCreated As Date Implements IWeekRange.DateCreated
        Get
            Return cWeekRange.DateCreated
        End Get
        Set(ByVal value As Date)
            cWeekRange.DateCreated = value
        End Set
    End Property

    Public Property DateRange As String Implements IWeekRange.DateRange
        Get
            Return cWeekRange.DateRange
        End Get
        Set(ByVal value As String)
            cWeekRange.DateRange = value
        End Set
    End Property

#End Region

#Region "STORED PROCS"

    Public Function InsertWeekRange() As Boolean Implements IWeekRange.InsertWeekRange
        Try
            Return Me.cWeeklyReportFactory.InsertWeekRange(cWeekRange)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Weekly Report Failed!")
            End If
        End Try
    End Function

    Public Function GetWeekRange(currentDate As Date, empID As Integer) As List(Of WeekRangeSet) Implements IWeekRange.GetWeekRange
        Try
            Dim objWeekRangeList As List(Of clsWeekRange)
            objWeekRangeList = cWeeklyReportFactory.GetWeekRange(currentDate, empID)

            If IsNothing(objWeekRangeList) Then
                Throw New NoRecordFoundException("Record Not Found!")
            End If

            Dim lstWeekRange As List(Of WeekRangeSet) = New List(Of WeekRangeSet)
            For Each weekRange As clsWeekRange In objWeekRangeList
                lstWeekRange.Add(New WeekRangeSet(weekRange))
            Next

            Return lstWeekRange
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetWeeklyReportsByEmpID(empID As Integer) As List(Of WeekRangeSet) Implements IWeekRange.GetWeeklyReportsByEmpID
        Try
            Dim objWeekRangeList As List(Of clsWeekRange)
            objWeekRangeList = cWeeklyReportFactory.GetWeeklyReportsByEmpID(empID)

            If IsNothing(objWeekRangeList) Then
                Throw New NoRecordFoundException("Record Not Found!")
            End If

            Dim lstWeekRange As List(Of WeekRangeSet) = New List(Of WeekRangeSet)
            For Each weekRange As clsWeekRange In objWeekRangeList
                lstWeekRange.Add(New WeekRangeSet(weekRange))
            Next

            Return lstWeekRange
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    'Public Function getTaskSummaryAll(dateStart As DateTime, email As String) As List(Of TasksSummarySet) Implements ITasksSummary.getTaskSummaryAll
    '    Try
    '        Dim objTasksList As List(Of clsTasks_sp)
    '        objTasksList = cTasksFactory.getTaskSummaryAll(dateStart, email)

    '        If IsNothing(objTasksList) Then
    '            Throw New NoRecordFoundException("Record Not Found!")
    '        End If

    '        Dim _tasksList As List(Of TasksSummarySet) = New List(Of TasksSummarySet)
    '        For Each _task As clsTasks_sp In objTasksList
    '            _tasksList.Add(New TasksSummarySet(_task))
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

    'Public Function getTaskSummaryByEmpId(empID As Integer, dateStart As DateTime) As List(Of TasksSummarySet) Implements ITasksSummary.getTaskSummaryByEmpId
    '    Try
    '        Dim objTasksList As List(Of clsTasks_sp)
    '        objTasksList = Me.cTasksFactory.getTaskSummaryByEmpId(empID, dateStart)

    '        If IsNothing(objTasksList) Then
    '            Throw New NoRecordFoundException("Record Not Found!")
    '        End If

    '        Dim _tasksList As List(Of TasksSummarySet) = New List(Of TasksSummarySet)
    '        For Each _task As clsTasks_sp In objTasksList
    '            _tasksList.Add(New TasksSummarySet(_task))
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

#End Region

#Region "PropertyChange"
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
#End Region

End Class

