Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer
Imports GDC.PH.AIDE.Entity
Imports System.Data.SqlClient
''' <summary>
''' ''' GIANN CALRO CAMILO
''' </summary>
''' <remarks></remarks>
Public Class EmployeeSet
    Implements IEmployeeSet
    Implements INotifyPropertyChanged

    Private cEmployee As clsEmployee
    Private cEmployeeFactory As clsEmployeeFactory

    Public Sub New()
        cEmployee = New clsEmployee()
        cEmployeeFactory = New clsEmployeeFactory
    End Sub

    Public Sub New(ByVal cEmp As clsEmployee)
        cEmployee = cEmp
        cEmployeeFactory = New clsEmployeeFactory
    End Sub

    Public Property EmployeeID As Integer Implements IEmployeeSet.EmployeeID
        Get
            Return cEmployee.EMP_ID
        End Get
        Set(value As Integer)
            cEmployee.EMP_ID = value
        End Set
    End Property

    Public Property EmployeeName As String Implements IEmployeeSet.EmployeeName
        Get
            Return cEmployee.EMPLOYEE_NAME
        End Get
        Set(value As String)
            cEmployee.EMPLOYEE_NAME = value
        End Set
    End Property

    Public Property LastName As String Implements IEmployeeSet.LastName
        Get
            Return cEmployee.LAST_NAME
        End Get
        Set(value As String)
            cEmployee.LAST_NAME = value
        End Set
    End Property

    Public Property FirstName As String Implements IEmployeeSet.FirstName
        Get
            Return cEmployee.FIRST_NAME
        End Get
        Set(value As String)
            cEmployee.FIRST_NAME = value
        End Set
    End Property

    Public Property MiddleInitial As String Implements IEmployeeSet.MiddleInitial
        Get
            Return IIf(IsDBNull(cEmployee.MIDDLE_INITIAL), " ", cEmployee.MIDDLE_INITIAL)
        End Get
        Set(value As String)
            cEmployee.MIDDLE_INITIAL = value
        End Set
    End Property

    Public Property NickName As String Implements IEmployeeSet.NickName
        Get
            Return IIf(IsDBNull(cEmployee.NICK_NAME), " ", cEmployee.NICK_NAME)
        End Get
        Set(value As String)
            cEmployee.NICK_NAME = value
        End Set
    End Property

    Public Property BirthDate As Date Implements IEmployeeSet.BirthDate
        Get
            Return cEmployee.BIRTHDATE
        End Get
        Set(value As Date)
            cEmployee.BIRTHDATE = value
        End Set
    End Property

    Public Property Position As String Implements IEmployeeSet.Position
        Get
            Return IIf(IsDBNull(cEmployee.POSITION), " ", cEmployee.POSITION)
        End Get
        Set(value As String)
            cEmployee.POSITION = value
        End Set
    End Property

    Public Property DateHired As Date Implements IEmployeeSet.DateHired
        Get
            Return cEmployee.DATE_HIRED
        End Get
        Set(value As Date)
            cEmployee.DATE_HIRED = value
        End Set
    End Property

    Public Property Status As Short Implements IEmployeeSet.Status
        Get
            Return cEmployee.STATUS
        End Get
        Set(value As Short)
            cEmployee.STATUS = value
        End Set
    End Property

    Public Property ImagePath As String Implements IEmployeeSet.ImagePath
        Get
            Return IIf(IsDBNull(cEmployee.IMAGE_PATH), " ", cEmployee.IMAGE_PATH)
        End Get
        Set(value As String)
            cEmployee.IMAGE_PATH = value
        End Set
    End Property

    Public Property GroupID As Short Implements IEmployeeSet.GroupID
        Get
            Return cEmployee.GRP_ID
        End Get
        Set(value As Short)
            cEmployee.GRP_ID = value
        End Set
    End Property

    Public Property EmailAddress As String Implements IEmployeeSet.EmailAddress
        Get
            Return IIf(IsDBNull(cEmployee.EMAIL_ADDRESS), " ", cEmployee.EMAIL_ADDRESS)
        End Get
        Set(value As String)
            cEmployee.EMAIL_ADDRESS = value
        End Set
    End Property

    Public Property EmailAddress2 As String Implements IEmployeeSet.EmailAddress2
        Get
            Return IIf(IsDBNull(cEmployee.EMAIL_ADDRESS2), " ", cEmployee.EMAIL_ADDRESS2)
        End Get
        Set(value As String)
            cEmployee.EMAIL_ADDRESS2 = value
        End Set
    End Property

    Public Property Location As String Implements IEmployeeSet.Location
        Get
            Return IIf(IsDBNull(cEmployee.LOCATION), " ", cEmployee.LOCATION)
        End Get
        Set(value As String)
            cEmployee.LOCATION = value
        End Set
    End Property

    Public Property CelNo As String Implements IEmployeeSet.CelNo
        Get
            Return IIf(IsDBNull(cEmployee.CEL_NO), " ", cEmployee.CEL_NO)
        End Get
        Set(value As String)
            cEmployee.CEL_NO = value
        End Set
    End Property

    Public Property Local As Integer Implements IEmployeeSet.Local
        Get
            Return cEmployee.LOCAL
        End Get
        Set(value As Integer)
            cEmployee.LOCAL = value
        End Set
    End Property

    Public Property HomePhone As String Implements IEmployeeSet.HomePhone
        Get
            Return IIf(IsDBNull(cEmployee.HOMEPHONE), " ", cEmployee.HOMEPHONE)
        End Get
        Set(value As String)
            cEmployee.HOMEPHONE = value
        End Set
    End Property

    Public Property Other_Phone As String Implements IEmployeeSet.Other_Phone
        Get
            Return IIf(IsDBNull(cEmployee.OTHER_PHONE), " ", cEmployee.OTHER_PHONE)
        End Get
        Set(value As String)
            cEmployee.OTHER_PHONE = value
        End Set
    End Property

    Public Property DtReviewed As Date Implements IEmployeeSet.DtReviewed
        Get
            Return cEmployee.DT_REVIEWED
        End Get
        Set(value As Date)
            cEmployee.DT_REVIEWED = value
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
    Public Function GetEmployeeList() As List(Of EmployeeSet) Implements IEmployeeSet.GetEmployeeList
        Try
            Dim lstEmployee As List(Of clsEmployee)
            Dim lstEmployeeSet As New List(Of EmployeeSet)
            lstEmployee = cEmployeeFactory.GetAll()
            If Not IsNothing(lstEmployee) Then
                For Each cEmp As clsEmployee In lstEmployee
                    lstEmployeeSet.Add(New EmployeeSet(cEmp))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstEmployeeSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetNicknameByDeptID(ByVal email As String) As List(Of EmployeeSet) Implements IEmployeeSet.GetNicknameByDeptID
        Try
            Dim lstEmployee As List(Of clsEmployee)
            Dim lstEmployeeSet As New List(Of EmployeeSet)
            lstEmployee = cEmployeeFactory.GetNicknameByDeptID(email)
            If Not IsNothing(lstEmployee) Then
                For Each cEmp As clsEmployee In lstEmployee
                    lstEmployeeSet.Add(New EmployeeSet(cEmp))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstEmployeeSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetEmployee(empId As Integer) As EmployeeSet Implements IEmployeeSet.GetEmployee
        Try
            Dim cEmp As clsEmployee
            Dim keys As clsEmployeeKeys = New clsEmployeeKeys(empId)
            cEmp = cEmployeeFactory.GetByPrimaryKey(keys)
            If Not IsNothing(cEmp) Then
                Dim empSet As New EmployeeSet(cEmp)
                Return empSet
            Else
                Throw New EmployeeNotFoundException("Employee not found!")
            End If

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateEmployee() As Boolean Implements IEmployeeSet.UpdateEmployee
        Try
            If cEmployeeFactory.Update(cEmployee) Then
                Return True
            Else
                Throw New UpdateFailedException("Update Employee Failed!")
            End If
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
End Class
