Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class CommendationsSet

    Implements ICommendationsSet, INotifyPropertyChanged

    Private cCommendations As clsCommendations
    Private cCommendationsFactory As clsCommendationsFactory

    Public Sub New()
        cCommendations = New clsCommendations()
        cCommendationsFactory = New clsCommendationsFactory()
    End Sub

    Public Sub New(ByVal objCommendations As clsCommendations)
        cCommendations = objCommendations
        cCommendationsFactory = New clsCommendationsFactory()
    End Sub

    Public Property COMMEND_ID As Integer Implements ICommendationsSet.COMMEND_ID
        Get
            Return Me.cCommendations.COMMEND_ID
        End Get
        Set(value As Integer)
            Me.cCommendations.COMMEND_ID = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements ICommendationsSet.EMP_ID
        Get
            Return Me.cCommendations.EMP_ID
        End Get
        Set(value As Integer)
            Me.cCommendations.EMP_ID = value
        End Set
    End Property

    Public Property EMPLOYEE As String Implements ICommendationsSet.EMPLOYEE
        Get
            Return Me.cCommendations.EMPLOYEE
        End Get
        Set(value As String)
            Me.cCommendations.EMPLOYEE = value
        End Set
    End Property

    Public Property PROJECT As String Implements ICommendationsSet.PROJECT
        Get
            Return Me.cCommendations.PROJECT
        End Get
        Set(value As String)
            Me.cCommendations.PROJECT = value
        End Set
    End Property

    Public Property DATE_SENT As Date Implements ICommendationsSet.DATE_SENT
        Get
            Return Me.cCommendations.DATE_SENT
        End Get
        Set(value As Date)
            Me.cCommendations.DATE_SENT = value
        End Set
    End Property

    Public Property SENT_BY As String Implements ICommendationsSet.SENT_BY
        Get
            Return Me.cCommendations.SENT_BY
        End Get
        Set(value As String)
            Me.cCommendations.SENT_BY = value
        End Set
    End Property

    Public Property REASON As String Implements ICommendationsSet.REASON
        Get
            Return Me.cCommendations.REASON
        End Get
        Set(value As String)
            Me.cCommendations.REASON = value
        End Set
    End Property

    Public Function GetCommendations(deptID As Integer) As List(Of CommendationsSet) Implements ICommendationsSet.GetAllCoCommendations
        Dim cList As List(Of clsCommendations)
        Dim cListSet As New List(Of CommendationsSet)
        Try

            cList = cCommendationsFactory.GetCommendations(deptID)

            If Not IsNothing(cList) Then
                For Each cCommendations As clsCommendations In cList
                    cListSet.Add(New CommendationsSet(cCommendations))
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

    Public Function InsertCommendations(contacts As CommendationsSet) As Boolean Implements ICommendationsSet.InsertCommendations
        Try
            Return Me.cCommendationsFactory.InsertCommendations(cCommendations)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateCommendations(contacts As CommendationsSet) As Boolean Implements ICommendationsSet.UpdateCommendations
        Try
            Return Me.cCommendationsFactory.UpdateCommendations(cCommendations)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetCommendationsBySearch(empID As Integer, month As Integer, year As Integer) As List(Of CommendationsSet) Implements ICommendationsSet.GetCommendationsBySearch
        Try
            Dim cList As List(Of clsCommendations)
            Dim cListSet As New List(Of CommendationsSet)

            cList = cCommendationsFactory.GetCommendationsBySearch(empID, month, year)

            If Not IsNothing(cList) Then
                For Each cCommendations As clsCommendations In cList
                    cListSet.Add(New CommendationsSet(cCommendations))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
