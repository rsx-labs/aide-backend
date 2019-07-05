Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class ContactSet

    Implements IContact, INotifyPropertyChanged

    Private cContact As clsContacts
    Private cContactFactory As clsContactsFactory

    Public Sub New()
        cContact = New clsContacts()
        cContactFactory = New clsContactsFactory()
    End Sub

    Public Sub New(ByVal objContactList As clsContacts)
        cContact = objContactList
        cContactFactory = New clsContactsFactory()
    End Sub

    Public Property CELL_NO As String Implements IContact.CEL_NO
        Get
            Return Me.cContact.CEL_NO
        End Get
        Set(value As String)
            Me.cContact.CEL_NO = value
        End Set
    End Property

    Public Property DateReviewed As Date Implements IContact.DT_REVIEWED
        Get
            If IsNothing(Me.cContact.DT_REVIEWED) Then
                Return Now.ToString()
            Else
                Return Me.cContact.DT_REVIEWED
            End If
        End Get
        Set(value As Date)
            value = Me.cContact.DT_REVIEWED
        End Set
    End Property

    Public Property EMADDRESS As String Implements IContact.EMAIL_ADDRESS
        Get
            Return Me.cContact.EMAIL_ADDRESS
        End Get
        Set(value As String)
            Me.cContact.EMAIL_ADDRESS = value
        End Set
    End Property

    Public Property EMADDRESS2 As String Implements IContact.EMAIL_ADDRESS2
        Get
            Return Me.cContact.EMAIL_ADDRESS2
        End Get
        Set(value As String)
            Me.cContact.EMAIL_ADDRESS2 = value
        End Set
    End Property

    Public Property EmpID As Integer Implements IContact.EMP_ID
        Get
            Return Me.cContact.EMP_ID
        End Get
        Set(value As Integer)
            Me.cContact.EMP_ID = value
        End Set
    End Property

    Public Property HOUSEPHONE As String Implements IContact.HOMEPHONE
        Get
            Return Me.cContact.HOMEPHONE
        End Get
        Set(value As String)
            Me.cContact.HOMEPHONE = value
        End Set
    End Property

    Public Property lOCAL As Integer Implements IContact.LOCAL
        Get
            Return Me.cContact.LOCAL
        End Get
        Set(value As Integer)
            Me.cContact.LOCAL = value
        End Set
    End Property

    Public Property LOC As String Implements IContact.LOCATION
        Get
            Return Me.cContact.LOCATION
        End Get
        Set(value As String)
            Me.cContact.LOCATION = value
        End Set
    End Property

    Public Property MARITAL_STATUS As String Implements IContact.MARITAL_STATUS
        Get
            Return Me.cContact.MARITAL_STATUS
        End Get
        Set(value As String)
            Me.cContact.MARITAL_STATUS = value
        End Set
    End Property

    Public Property POSITION As String Implements IContact.POSITION
        Get
            Return Me.cContact.POSITION
        End Get
        Set(value As String)
            Me.cContact.POSITION = value
        End Set
    End Property

    Public Property OTHERPHONE As String Implements IContact.OTHER_PHONE
        Get
            Return Me.cContact.OTHER_PHONE
        End Get
        Set(value As String)
            Me.cContact.OTHER_PHONE = value
        End Set
    End Property

    Public Property FIRST_NAME As String Implements IContact.FIRST_NAME
        Get
            Return Me.cContact.FIRST_NAME
        End Get
        Set(value As String)
            Me.cContact.FIRST_NAME = value
        End Set
    End Property

    Public Property LAST_NAME As String Implements IContact.LAST_NAME
        Get
            Return Me.cContact.LAST_NAME
        End Get
        Set(value As String)
            Me.cContact.LAST_NAME = value
        End Set
    End Property

    Public Property IMAGE_PATH As String Implements IContact.IMAGE_PATH
        Get
            Return Me.cContact.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cContact.IMAGE_PATH = value
        End Set
    End Property

    Public Property NICK_NAME As String Implements IContact.NICK_NAME
        Get
            Return Me.cContact.NICK_NAME
        End Get
        Set(value As String)
            Me.cContact.NICK_NAME = value
        End Set
    End Property

    Public Property MIDDLE_NAME As String Implements IContact.MIDDLE_NAME
        Get
            Return Me.cContact.MIDDLE_NAME
        End Get
        Set(value As String)
            Me.cContact.MIDDLE_NAME = value
        End Set
    End Property

    'Public Property STATUS As String Implements IContact.STATUS
    '    Get
    '        Return Me.cContact.STATUS
    '    End Get
    '    Set(value As String)
    '        Me.cContact.STATUS = value
    '    End Set
    'End Property

    Public Property PERMISSION_GROUP As String Implements IContact.PERMISSION_GROUP
        Get
            Return Me.cContact.PERMISSION_GROUP
        End Get
        Set(value As String)
            Me.cContact.PERMISSION_GROUP = value
        End Set
    End Property

    Public Property DEPARTMENT As String Implements IContact.DEPARTMENT
        Get
            Return Me.cContact.DEPARTMENT
        End Get
        Set(value As String)
            Me.cContact.DEPARTMENT = value
        End Set
    End Property

    Public Property DIVISION As String Implements IContact.DIVISION
        Get
            Return Me.cContact.DIVISION
        End Get
        Set(value As String)
            Me.cContact.DIVISION = value
        End Set
    End Property

    Public Property SHIFT As String Implements IContact.SHIFT
        Get
            Return Me.cContact.SHIFT
        End Get
        Set(value As String)
            Me.cContact.SHIFT = value
        End Set
    End Property

    Public Property BIRTHDATE As Date Implements IContact.BIRTHDATE
        Get
            If IsNothing(Me.cContact.BIRTHDATE) Then
                Return Now.ToString()
            Else
                Return Me.cContact.BIRTHDATE
            End If
        End Get
        Set(value As Date)
            Me.cContact.BIRTHDATE = value
        End Set
    End Property

    Public Property DT_HIRED As Date Implements IContact.DT_HIRED
        Get
            If IsNothing(Me.cContact.DT_HIRED) Then
                Return Now.ToString()
            Else
                Return Me.cContact.DT_HIRED
            End If
        End Get
        Set(value As Date)
            Me.cContact.DT_HIRED = value
        End Set
    End Property

    Public Property ACTIVE As Integer Implements IContact.ACTIVE
        Get
            Return Me.cContact.ACTIVE
        End Get
        Set(value As Integer)
            Me.cContact.ACTIVE = value
        End Set
    End Property

    Public Property DEPARTMENT_ID As Integer Implements IContact.DEPARTMENT_ID
        Get
            Return Me.cContact.DEPARTMENT_ID
        End Get
        Set(value As Integer)
            Me.cContact.DEPARTMENT_ID = value
        End Set
    End Property

    Public Property DIVISION_ID As Integer Implements IContact.DIVISION_ID
        Get
            Return Me.cContact.DIVISION_ID
        End Get
        Set(value As Integer)
            Me.cContact.DIVISION_ID = value
        End Set
    End Property

    Public Property MARITAL_STATUS_ID As String Implements IContact.MARITAL_STATUS_ID
        Get
            Return Me.cContact.MARITAL_STATUS_ID
        End Get
        Set(value As String)
            Me.cContact.MARITAL_STATUS_ID = value
        End Set
    End Property

    Public Property PERMISSION_GROUP_ID As Integer Implements IContact.PERMISSION_GROUP_ID
        Get
            Return Me.cContact.PERMISSION_GROUP_ID
        End Get
        Set(value As Integer)
            Me.cContact.PERMISSION_GROUP_ID = value
        End Set
    End Property

    Public Property POSITION_ID As Integer Implements IContact.POSITION_ID
        Get
            Return Me.cContact.POSITION_ID
        End Get
        Set(value As Integer)
            Me.cContact.POSITION_ID = value
        End Set
    End Property

    Public Property OLD_EMP_ID As Integer Implements IContact.OLD_EMP_ID
        Get
            Return Me.cContact.OLD_EMP_ID
        End Get
        Set(value As Integer)
            Me.cContact.OLD_EMP_ID = value
        End Set
    End Property

    Public Function GetContactsByID(EMP_ID As Integer) As Object Implements IContact.GetContactsByID
        Try
            Dim key As clsContactsKeys = New clsContactsKeys(EmpID)
            Dim objContact As clsContacts
            objContact = Me.cContactFactory.GetByPrimaryKey(key)
            Return objContact
        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New EmployeeNotFoundException("Employee Not Found")

            End If
            Return Nothing
        End Try
    End Function

    'Public Sub InsertContact() Implements IContact.InsertContact
    '    Try
    '        Me.cContactFactory.Insert(cContact)
    '    Catch ex As Exception
    '        If ex.HResult = -2146233088 Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed")
    '        Else
    '            Throw New InsertFailedException("Insert Failed")

    '        End If
    '        Console.WriteLine("Error encountered.." & ex.Message.ToString())
    '    End Try
    'End Sub

    Public Function GetAllContacts(email As String) As List(Of ContactSet) Implements IContact.GetAllContacts
        Dim cList As List(Of clsContacts)
        Dim cListSet As New List(Of ContactSet)
        Dim key As New clsContactsKeys(email)
        Try

            cList = cContactFactory.GetAll(key.EMAIL)

            If Not IsNothing(cList) Then
                For Each cContact As clsContacts In cList
                    cListSet.Add(New ContactSet(cContact))
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

    Public Function CreateContacts(contacts As ContactSet) As Boolean Implements IContact.CreateContacts
        Try
            Return Me.cContactFactory.Insert(cContact)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateContact(contacts As ContactSet) As Boolean Implements IContact.UpdateContacts
        Try
            Return Me.cContactFactory.Update(cContact)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    'Public Sub DeleteContact() Implements IContact.DeleteContact
    '    Throw New NotImplementedException()
    'End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class
