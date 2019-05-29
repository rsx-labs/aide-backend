Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class AnnouncementsSet

    Implements IAnnouncementsSet, INotifyPropertyChanged


    Private cAnnouncements As clsAnnouncements
    Private cAnnouncementsFactory As clsAnnouncementsFactory

    Public Sub New()
        cAnnouncements = New clsAnnouncements()
        cAnnouncementsFactory = New clsAnnouncementsFactory()
    End Sub

    Public Sub New(ByVal objAnnouncements As clsAnnouncements)
        cAnnouncements = objAnnouncements
        cAnnouncementsFactory = New clsAnnouncementsFactory()
    End Sub

    Public Property MESSAGE As String Implements IAnnouncementsSet.MESSAGE
        Get
            Return Me.cAnnouncements.MESSAGE
        End Get
        Set(value As String)
            Me.cAnnouncements.MESSAGE = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IAnnouncementsSet.EMP_ID
        Get
            Return Me.cAnnouncements.EMP_ID
        End Get
        Set(value As Integer)
            Me.cAnnouncements.EMP_ID = value
        End Set
    End Property


    Public Property END_DATE As Date Implements IAnnouncementsSet.END_DATE
        Get
            Return Me.cAnnouncements.END_DATE
        End Get
        Set(value As Date)
            Me.cAnnouncements.END_DATE = value
        End Set
    End Property
    Public Property TITLE As String Implements IAnnouncementsSet.TITLE
        Get
            Return Me.cAnnouncements.TITLE
        End Get
        Set(value As String)
            Me.cAnnouncements.TITLE = value
        End Set
    End Property


    Public Function GetAnnouncements(deptID As Integer) As List(Of AnnouncementsSet) Implements IAnnouncementsSet.GetAnnouncements
        Dim cList As List(Of clsAnnouncements)
        Dim cListSet As New List(Of AnnouncementsSet)
        Try

            cList = cAnnouncementsFactory.GetAnnouncements(deptID)

            If Not IsNothing(cList) Then
                For Each cAnnouncements As clsAnnouncements In cList
                    cListSet.Add(New AnnouncementsSet(cAnnouncements))
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

    Public Function InsertAnnouncements(announcements As AnnouncementsSet) As Boolean Implements IAnnouncementsSet.InsertAnnouncements
        Try
            Return Me.cAnnouncementsFactory.InsertAnnouncements(cAnnouncements)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    End Class
