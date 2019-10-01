Imports GDC.PH.AIDE.BusinessLayer
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Class WeeklyTeamStatusReportSet
    Implements IWeeklyTeamStatusReport, INotifyPropertyChanged

    Private cWeeklyTeamStatusReport As clsWeeklyTeamStatusReport
    Private cWeeklyReportFactory As clsWeeklyReportFactory

    Public Sub New()
        cWeeklyTeamStatusReport = New clsWeeklyTeamStatusReport()
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

    Public Sub New(ByVal objWeeklyTeamStatusReport As clsWeeklyTeamStatusReport)
        cWeeklyTeamStatusReport = objWeeklyTeamStatusReport
        cWeeklyReportFactory = New clsWeeklyReportFactory
    End Sub

#Region "Database Field"

    Public Property WeekRangeID As Integer Implements IWeeklyTeamStatusReport.WeekRangeID
        Get
            Return cWeeklyTeamStatusReport.WeekRangeID
        End Get
        Set(ByVal value As Integer)
            cWeeklyTeamStatusReport.WeekRangeID = value
        End Set
    End Property

    Public Property EmployeeID As Integer Implements IWeeklyTeamStatusReport.EmployeeID
        Get
            Return cWeeklyTeamStatusReport.EmployeeID
        End Get
        Set(ByVal value As Integer)
            cWeeklyTeamStatusReport.EmployeeID = value
        End Set
    End Property

    Public Property EmployeeName As String Implements IWeeklyTeamStatusReport.EmployeeName
        Get
            Return cWeeklyTeamStatusReport.EmployeeName
        End Get
        Set(ByVal value As String)
            cWeeklyTeamStatusReport.EmployeeName = value
        End Set
    End Property

    Public Property TotalHours As Double Implements IWeeklyTeamStatusReport.TotalHours
        Get
            Return cWeeklyTeamStatusReport.TotalHours
        End Get
        Set(ByVal value As Double)
            cWeeklyTeamStatusReport.TotalHours = value
        End Set
    End Property

    Public Property Status As Short Implements IWeeklyTeamStatusReport.Status
        Get
            Return cWeeklyTeamStatusReport.Status
        End Get
        Set(ByVal value As Short)
            cWeeklyTeamStatusReport.Status = value
        End Set
    End Property

    Public Property DateSubmitted As Date Implements IWeeklyTeamStatusReport.DateSubmitted
        Get
            Return cWeeklyTeamStatusReport.Date_Submitted
        End Get
        Set(ByVal value As Date)
            cWeeklyTeamStatusReport.Date_Submitted = value
        End Set
    End Property

    Public Property DateRange As String Implements IWeeklyTeamStatusReport.DateRange
        Get
            Return cWeeklyTeamStatusReport.DateRange
        End Get
        Set(ByVal value As String)
            cWeeklyTeamStatusReport.DateRange = value
        End Set
    End Property

#End Region

#Region "STORED PROCS"

    Public Function GetWeeklyTeamStatusReport(empID As Integer, month As Integer, year As Integer, weekID As Integer) As List(Of WeeklyTeamStatusReportSet) Implements IWeeklyTeamStatusReport.GetWeeklyTeamStatusReport
        Try
            Dim objWeeklyTeamStatusReportList As List(Of clsWeeklyTeamStatusReport)
            objWeeklyTeamStatusReportList = cWeeklyReportFactory.GetWeeklyTeamStatusReport(empID, month, year, weekID)

            If IsNothing(objWeeklyTeamStatusReportList) Then
                Throw New NoRecordFoundException("Record Not Found!")
            End If

            Dim lstWeeklyTeamStatusReport As List(Of WeeklyTeamStatusReportSet) = New List(Of WeeklyTeamStatusReportSet)
            For Each weeklyTeamStatusReport As clsWeeklyTeamStatusReport In objWeeklyTeamStatusReportList
                lstWeeklyTeamStatusReport.Add(New WeeklyTeamStatusReportSet(weeklyTeamStatusReport))
            Next

            Return lstWeeklyTeamStatusReport
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

