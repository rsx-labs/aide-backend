Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class AuditSchedSet

    Implements IAuditSchedSet, INotifyPropertyChanged

    Private cAuditSched As clsAuditSched
    Private cAuditSchedFactory As clsAuditSchedFactory

    Public Sub New()
        cAuditSched = New clsAuditSched()
        cAuditSchedFactory = New clsAuditSchedFactory()
    End Sub

    Public Sub New(ByVal objAuditSched As clsAuditSched)
        cAuditSched = objAuditSched
        cAuditSchedFactory = New clsAuditSchedFactory()
    End Sub

    Public Property AUDIT_SCHED_ID As Integer Implements IAuditSchedSet.AUDIT_SCHED_ID
        Get
            Return Me.cAuditSched.AUDIT_SCHED_ID
        End Get
        Set(value As Integer)
            Me.cAuditSched.AUDIT_SCHED_ID = value
        End Set
    End Property

    Public Property YEAR As Integer Implements IAuditSchedSet.YEAR
        Get
            Return Me.cAuditSched.YEAR
        End Get
        Set(value As Integer)
            Me.cAuditSched.YEAR = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IAuditSchedSet.EMP_ID
        Get
            Return Me.cAuditSched.EMP_ID
        End Get
        Set(value As Integer)
            Me.cAuditSched.EMP_ID = value
        End Set
    End Property

    Public Property FY_WEEK As Integer Implements IAuditSchedSet.FY_WEEK
        Get
            Return Me.cAuditSched.FY_WEEK
        End Get
        Set(value As Integer)
            Me.cAuditSched.FY_WEEK = value
        End Set
    End Property

    Public Property PERIOD_START As DateTime Implements IAuditSchedSet.PERIOD_START
        Get
            Return Me.cAuditSched.PERIOD_START
        End Get
        Set(value As DateTime)
            Me.cAuditSched.PERIOD_START = value
        End Set
    End Property

    Public Property PERIOD_END As DateTime Implements IAuditSchedSet.PERIOD_END
        Get
            Return Me.cAuditSched.PERIOD_END
        End Get
        Set(value As DateTime)
            Me.cAuditSched.PERIOD_END = value
        End Set
    End Property

    Public Property DAILY As String Implements IAuditSchedSet.DAILY
        Get
            Return Me.cAuditSched.DAILY
        End Get
        Set(value As String)
            Me.cAuditSched.DAILY = value
        End Set
    End Property

    Public Property WEEKLY As String Implements IAuditSchedSet.WEEKLY
        Get
            Return Me.cAuditSched.WEEKLY
        End Get
        Set(value As String)
            Me.cAuditSched.WEEKLY = value
        End Set
    End Property

    Public Property MONTHLY As String Implements IAuditSchedSet.MONTHLY
        Get
            Return Me.cAuditSched.MONTHLY
        End Get
        Set(value As String)
            Me.cAuditSched.MONTHLY = value
        End Set
    End Property

    Public Property FY_START As DateTime Implements IAuditSchedSet.FY_START
        Get
            Return Me.cAuditSched.FY_START
        End Get
        Set(value As DateTime)
            Me.cAuditSched.FY_START = value
        End Set
    End Property

    Public Property FY_END As DateTime Implements IAuditSchedSet.FY_END
        Get
            Return Me.cAuditSched.FY_END
        End Get
        Set(value As DateTime)
            Me.cAuditSched.FY_END = value
        End Set
    End Property

    Public Function GetAuditSched(empID As Integer, year As Integer) As List(Of AuditSchedSet) Implements IAuditSchedSet.GetAuditSched
        Dim cList As List(Of clsAuditSched)
        Dim cListSet As New List(Of AuditSchedSet)
        Try

            cList = cAuditSchedFactory.GetAuditSched(empID, year)

            If Not IsNothing(cList) Then
                For Each cAuditSched As clsAuditSched In cList
                    cListSet.Add(New AuditSchedSet(cAuditSched))
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

    Public Function InsertAuditSched(auditSched As AuditSchedSet) As Boolean Implements IAuditSchedSet.InsertAuditSched
        Try
            Return Me.cAuditSchedFactory.InsertAuditSched(cAuditSched)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAuditSched(auditSched As AuditSchedSet) As Boolean Implements IAuditSchedSet.UpdateAuditSched
        Try
            Return Me.cAuditSchedFactory.UpdateAuditSched(cAuditSched)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
