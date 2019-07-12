Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class ContributorsSet
    Implements IContributorsSet, INotifyPropertyChanged

    Private cContributors As clsContributors
    Private cContributorsFactory As clsContributorsFactory

    Public Sub New()
        cContributors = New clsContributors()
        cContributorsFactory = New clsContributorsFactory()
    End Sub

    Public Sub New(ByVal objContributors As clsContributors)
        cContributors = objContributors
        cContributorsFactory = New clsContributorsFactory()
    End Sub

    Public Property DEPARTMENT As String Implements IContributorsSet.DEPARTMENT
        Get
            Return Me.cContributors.DEPARTMENT
        End Get
        Set(value As String)
            Me.cContributors.DEPARTMENT = value
        End Set
    End Property

    Public Property DIVISIOn As String Implements IContributorsSet.DIVISIOn
        Get
            Return Me.cContributors.DIVISION
        End Get
        Set(value As String)
            Me.cContributors.DIVISION = value
        End Set
    End Property

    Public Property FULL_NAME As String Implements IContributorsSet.FULL_NAME
        Get
            Return Me.cContributors.FULL_NAME
        End Get
        Set(value As String)
            Me.cContributors.FULL_NAME = value
        End Set
    End Property

    Public Property IMAGE_PATH As String Implements IContributorsSet.IMAGE_PATH
        Get
            Return Me.cContributors.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cContributors.IMAGE_PATH = value
        End Set
    End Property

    Public Function GetAllContributors(level As Integer) As List(Of ContributorsSet) Implements IContributorsSet.GetAllContributors
        Dim cList As List(Of clsContributors)
        Dim cListSet As New List(Of ContributorsSet)
        Try

            cList = cContributorsFactory.GetAnnouncements(level)

            If Not IsNothing(cList) Then
                For Each cContributors As clsContributors In cList
                    cListSet.Add(New ContributorsSet(cContributors))
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

    Public Property POSITION As String Implements IContributorsSet.POSITION
        Get
            Return Me.cContributors.POSITION
        End Get
        Set(value As String)
            Me.cContributors.POSITION = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class
