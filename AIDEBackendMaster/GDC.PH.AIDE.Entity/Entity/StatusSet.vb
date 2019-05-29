Imports System.ComponentModel

Imports GDC.PH.AIDE.BusinessLayer
Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient

Public Enum Grouping As Short
    Attendance
    CivilStatus
    TaskCategory
    TaskStatus
    PhaseStatus
    ReworkStatus
End Enum
Public Class StatusSet
    Implements IStatusSet, INotifyPropertyChanged

    Dim cStatus As clsStatus
    Dim cStatusFactory As clsStatusFactory


    Dim curStatus As StatusSet
    Public Sub New()
        cStatus = New clsStatus()
        cStatusFactory = New clsStatusFactory()
    End Sub

    Public Sub New(ByVal objStatus As clsStatus)
        cStatus = objStatus
        cStatusFactory = New clsStatusFactory()
        curStatus = Me

    End Sub

    Public Property CurrentStatusSet As StatusSet Implements IStatusSet.CurrentStatusSet
        Get
            Return curStatus
        End Get
        Set(value As StatusSet)
            Me.curStatus = value
            NotifyPropertyChanged("CurrentStatusSet")
        End Set
    End Property

    Public Property Description As String Implements IStatusSet.Description
        Get
            Return Me.cStatus.DESCR
        End Get
        Set(value As String)
            Me.cStatus.DESCR = value
            NotifyPropertyChanged("Description")
        End Set
    End Property

    Public Property STATUS_ID As Short Implements IStatusSet.STATUS_ID
        Get
            Return Me.cStatus.STATUS_ID
        End Get
        Set(value As Short)
            Me.cStatus.STATUS_ID = value
            NotifyPropertyChanged("STATUS_ID")
        End Set
    End Property
    Public Property STATUS_NAME As String Implements IStatusSet.STATUS_NAME
        Get
            Return Me.cStatus.STATUS_NAME
        End Get
        Set(value As String)
            Me.cStatus.STATUS_NAME = value
            NotifyPropertyChanged("STATUS_NAME")
        End Set
    End Property

    Public Property Status As Short Implements IStatusSet.Status
        Get
            Return Me.cStatus.STATUS
        End Get
        Set(value As Short)
            Me.cStatus.STATUS = value
            NotifyPropertyChanged("Status")
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function getAttendanceStatus() As List(Of StatusSet) Implements IStatusSet.getAttendanceStatus
        Try
            Return GetListOfStatus(Grouping.Attendance)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If

        End Try
    End Function

    Public Function getCivil() As List(Of StatusSet) Implements IStatusSet.getCivil
        Try
            Return GetListOfStatus(Grouping.CivilStatus)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If

        End Try
    End Function

    Public Function GetTaskStatus() As List(Of StatusSet) Implements IStatusSet.GetTaskStatus
        Try
            Return GetListOfStatus(Grouping.TaskStatus)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetTaskCategories() As List(Of StatusSet) Implements IStatusSet.GetTaskCategories
        Try
            Return GetListOfStatus(Grouping.TaskCategory)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetPhaseStatus() As List(Of StatusSet) Implements IStatusSet.GetPhaseStatus
        Try
            Return GetListOfStatus(Grouping.PhaseStatus)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetReworkStatus() As List(Of StatusSet) Implements IStatusSet.GetReworkStatus
        Try
            Return GetListOfStatus(Grouping.ReworkStatus)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetListOfStatus(ByVal Group_ID As Short) As List(Of StatusSet)
        Dim key As clsStatusKeys = New clsStatusKeys(Group_ID)
        Dim lstStatus As List(Of clsStatus)
        Dim lstStatusSet As New List(Of StatusSet)

        lstStatus = Me.cStatusFactory.GetByPrimaryKey(key)

        For Each objStatus As clsStatus In lstStatus
            lstStatusSet.Add(New StatusSet(objStatus))
        Next

        Return lstStatusSet
    End Function

End Class
