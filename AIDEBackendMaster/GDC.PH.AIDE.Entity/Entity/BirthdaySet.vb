Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class BirthdaySet

    Implements IBirthday, INotifyPropertyChanged

    Private cContact As clsContacts
    Private cBirthday As clsBirthday
    Private cContactFactory As clsContactsFactory
    Private cBirthdayFactory As clsBirthdayFactory

    Public Sub New()
        cContact = New clsContacts()
        cBirthday = New clsBirthday()
        cContactFactory = New clsContactsFactory()
        cBirthdayFactory = New clsBirthdayFactory()
    End Sub

    Public Sub New(ByVal objContactList As clsContacts)
        cContact = objContactList
        cContactFactory = New clsContactsFactory()
    End Sub

    Public Sub New(ByVal objBirthdayList As clsBirthday)
        cBirthday = objBirthdayList
        cBirthdayFactory = New clsBirthdayFactory()
    End Sub

    Public Property EmpID As Integer Implements IBirthday.EMP_ID
        Get
            Return Me.cBirthday.EMP_ID
        End Get
        Set(value As Integer)
            Me.cBirthday.EMP_ID = value
        End Set
    End Property

    Public Property FIRST_NAME As String Implements IBirthday.FIRST_NAME
        Get
            Return Me.cBirthday.FIRST_NAME
        End Get
        Set(value As String)
            Me.cBirthday.FIRST_NAME = value
        End Set
    End Property

    Public Property LAST_NAME As String Implements IBirthday.LAST_NAME
        Get
            Return Me.cBirthday.LAST_NAME
        End Get
        Set(value As String)
            Me.cBirthday.LAST_NAME = value
        End Set
    End Property

    Public Property BIRTHDAY As Date Implements IBirthday.BIRTHDAY
        Get
            Return Me.cBirthday.BIRTHDAY
        End Get
        Set(value As Date)
            Me.cBirthday.BIRTHDAY = value
        End Set
    End Property

    Public Property IMAGE_PATH As String Implements IBirthday.IMAGE_PATH
        Get
            Return Me.cBirthday.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cBirthday.IMAGE_PATH = value
        End Set
    End Property

    Public Function GetAllBirthday(email As String) As List(Of BirthdaySet) Implements IBirthday.GetAllBirthday
        Dim cList As List(Of clsBirthday)
        Dim cListSet As New List(Of BirthdaySet)
        Dim key As New clsBirthdayKeys(email)
        Try

            cList = cBirthdayFactory.GetAll(key.EMAIL)

            If Not IsNothing(cList) Then
                For Each cBirthday As clsBirthday In cList
                    cListSet.Add(New BirthdaySet(cBirthday))
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

    Public Function GetBirthdayByMonth(email As String) As List(Of BirthdaySet) Implements IBirthday.GetBirthdayByMonth
        Dim cList As List(Of clsBirthday)
        Dim cListSet As New List(Of BirthdaySet)
        Dim key As New clsBirthdayKeys(email)
        Try

            cList = cBirthdayFactory.GetAllByMonth(key.EMAIL)

            If Not IsNothing(cList) Then
                For Each cBirthday As clsBirthday In cList
                    cListSet.Add(New BirthdaySet(cBirthday))
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

    Public Function GetBirthdayByDay(email As String) As List(Of BirthdaySet) Implements IBirthday.GetBirthdayByDay
        Dim cList As List(Of clsBirthday)
        Dim cListSet As New List(Of BirthdaySet)
        Dim key As New clsBirthdayKeys(email)
        Try

            cList = cBirthdayFactory.GetAllByDay(key.EMAIL)

            If Not IsNothing(cList) Then
                For Each cBirthday As clsBirthday In cList
                    cListSet.Add(New BirthdaySet(cBirthday))
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
