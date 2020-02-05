Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class WorkplaceAuditSet

    Implements IWorkplaceAuditSet, INotifyPropertyChanged

    Private cWorkplaceAudit As clsWorkplaceAudit
    Private cWorkplaceAuditFactory As clsWorkplaceAuditFactory
    Private cAuditSched As clsAuditSched

    Dim cList As List(Of clsWorkplaceAudit)
    Dim cListSet As New List(Of WorkplaceAuditSet)
    Public Sub New()
        cWorkplaceAudit = New clsWorkplaceAudit()
        cWorkplaceAuditFactory = New clsWorkplaceAuditFactory()
        cAuditSched = New clsAuditSched()
    End Sub

    Public Sub New(ByVal objWorkplaceAudit As clsWorkplaceAudit)
        cWorkplaceAudit = objWorkplaceAudit
        cWorkplaceAuditFactory = New clsWorkplaceAuditFactory()
        cAuditSched = New clsAuditSched()
    End Sub

    Public Property AUDIT_DAILY_ID As Integer Implements IWorkplaceAuditSet.AUDIT_DAILY_ID
        Get
            Return Me.cWorkplaceAudit.AUDIT_DAILY_ID
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.AUDIT_DAILY_ID = value
        End Set
    End Property

    Public Property AUDIT_QUESTIONS_ID As Integer Implements IWorkplaceAuditSet.AUDIT_QUESTIONS_ID
        Get
            Return Me.cWorkplaceAudit.AUDIT_QUESTIONS_ID
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.AUDIT_QUESTIONS_ID = value
        End Set
    End Property
    Public Property AUDIT_ID As Integer Implements IWorkplaceAuditSet.AUDIT_ID
        Get
            Return Me.cWorkplaceAudit.AUDIT_ID
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.AUDIT_ID = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IWorkplaceAuditSet.EMP_ID
        Get
            Return Me.cWorkplaceAudit.EMP_ID
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.EMP_ID = value
        End Set
    End Property

    Public Property FY_WEEK As Integer Implements IWorkplaceAuditSet.FY_WEEK
        Get
            Return Me.cWorkplaceAudit.FY_WEEK
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.FY_WEEK = value
        End Set
    End Property

    Public Property STATUS As Integer Implements IWorkplaceAuditSet.STATUS
        Get
            Return Me.cWorkplaceAudit.STATUS
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.STATUS = value
        End Set
    End Property

    Public Property DT_CHECKED As String Implements IWorkplaceAuditSet.DT_CHECKED
        Get
            Return Me.cWorkplaceAudit.DT_CHECKED
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.DT_CHECKED = value
        End Set
    End Property
    Public Property DT_CHECK_FLG As Integer Implements IWorkplaceAuditSet.DT_CHECK_FLG
        Get
            Return Me.cWorkplaceAudit.DT_CHECK_FLG
        End Get
        Set(value As Integer)
            Me.cWorkplaceAudit.DT_CHECK_FLG = value
        End Set
    End Property

    Public Property AUDIT_QUESTIONS As String Implements IWorkplaceAuditSet.AUDIT_QUESTIONS
        Get
            Return Me.cWorkplaceAudit.AUDIT_QUESTIONS
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.AUDIT_QUESTIONS = value
        End Set
    End Property

    Public Property AUDIT_QUESTIONS_GROUP As String Implements IWorkplaceAuditSet.AUDIT_QUESTIONS_GROUP
        Get
            Return Me.cWorkplaceAudit.AUDIT_QUESTIONS_GROUP
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.AUDIT_QUESTIONS_GROUP = value
        End Set
    End Property

    Public Property OWNER As String Implements IWorkplaceAuditSet.OWNER
        Get
            Return Me.cWorkplaceAudit.OWNER
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.OWNER = value
        End Set
    End Property
    Public Property AUDITSCHED_MONTH As String Implements IWorkplaceAuditSet.AUDITSCHED_MONTH
        Get
            Return Me.cWorkplaceAudit.AUDITSCHED_MONTH
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.AUDITSCHED_MONTH = value
        End Set
    End Property
    Public Property WEEKDAYS As String Implements IWorkplaceAuditSet.WEEKDAYS
        Get
            Return Me.cWorkplaceAudit.WEEKDAYS
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.WEEKDAYS = value
        End Set
    End Property
    Public Property NICKNAME As String Implements IWorkplaceAuditSet.NICKNAME
        Get
            Return Me.cWorkplaceAudit.NICKNAME
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.NICKNAME = value
        End Set
    End Property
    Public Property WEEKDATE As String Implements IWorkplaceAuditSet.WEEKDATE
        Get
            Return Me.cWorkplaceAudit.WEEKDATE
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.WEEKDATE = value
        End Set
    End Property
    Public Property WEEKDATESCHED As String Implements IWorkplaceAuditSet.WEEKDATESCHED
        Get
            Return Me.cWorkplaceAudit.WEEKDATESCHED
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.WEEKDATESCHED = value
        End Set
    End Property
    Public Property DATE_CHECKED As String Implements IWorkplaceAuditSet.DATE_CHECKED
        Get
            Return Me.cWorkplaceAudit.DATE_CHECKED
        End Get
        Set(value As String)
            Me.cWorkplaceAudit.DATE_CHECKED = value
        End Set
    End Property


    Public Function GetAuditDaily(empID As Integer, parmDate As DateTime) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetAuditDaily
        Dim cList As List(Of clsWorkplaceAudit)
        Dim cListSet As New List(Of WorkplaceAuditSet)
        Try

            cList = cWorkplaceAuditFactory.GetAuditDaily(empID, parmDate)

            If Not IsNothing(cList) Then
                For Each cWorkplaceAudit As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cWorkplaceAudit))
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

    Public Function InsertAuditDaily(auditSched As WorkplaceAuditSet) As Boolean Implements IWorkplaceAuditSet.InsertAuditDaily
        Try
            Return Me.cWorkplaceAuditFactory.InsertAuditDaily(cWorkplaceAudit)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetAuditQuestions(empID As Integer, questionGroup As String) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetAuditQuestions
        Dim cList As List(Of clsWorkplaceAudit)
        Dim cListSet As New List(Of WorkplaceAuditSet)
        Try

            cList = cWorkplaceAuditFactory.GetAuditQuestions(empID, questionGroup)

            If Not IsNothing(cList) Then
                For Each cWorkplaceAudit As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cWorkplaceAudit))
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

    Public Function GetAuditSchedMonth(audit_grp As Integer, yr As Integer, month As Integer) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetAuditSchedMonth

        Try

            cList = cWorkplaceAuditFactory.GetAuditSChed_Month(audit_grp, yr, month)

            If Not IsNothing(cList) Then
                For Each cObject As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cObject))
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
    Public Function GetDailyAuditorByWeek(empID As Integer, paramFYWeek As String) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetDailyAuditorByWeek

        Try

            cList = cWorkplaceAuditFactory.GetDailyAuditorByWeek(empID, paramFYWeek)

            If Not IsNothing(cList) Then
                For Each cObject As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cObject))
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
    Public Function UpdateCheckAuditQuestionStatus(auditSched As WorkplaceAuditSet) As Boolean Implements IWorkplaceAuditSet.UpdateCheckAuditQuestionStatus
        Try
            Return Me.cWorkplaceAuditFactory.UpdateCheckAuditQuestionStatus(cWorkplaceAudit)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Audit Question Status Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAuditSched(auditScheds As AuditSchedSet) As Boolean Implements IWorkplaceAuditSet.UpdateAuditSched
        Try
            Return Me.cWorkplaceAuditFactory.UpdateAuditSched(cAuditSched)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function
    Public Function GetWeeklyAuditor(empID As Integer, paraDate As Date) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetWeeklyAuditor

        Try

            cList = cWorkplaceAuditFactory.GetWeeklyAuditor(empID, paraDate)

            If Not IsNothing(cList) Then
                For Each cObject As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cObject))
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
    Public Function GetMonthlyAuditor(empID As Integer, paraDate As Integer) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetMonthlyAuditor

        Try

            cList = cWorkplaceAuditFactory.GetMonthlyAuditor(empID, paraDate)

            If Not IsNothing(cList) Then
                For Each cObject As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cObject))
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
    Public Function GetQuarterlyAuditor(empID As Integer, paraDate As Integer) As List(Of WorkplaceAuditSet) Implements IWorkplaceAuditSet.GetQuarterlyAuditor

        Try

            cList = cWorkplaceAuditFactory.GetQuarterlyAuditor(empID, paraDate)

            If Not IsNothing(cList) Then
                For Each cObject As clsWorkplaceAudit In cList
                    cListSet.Add(New WorkplaceAuditSet(cObject))
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
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged


End Class

