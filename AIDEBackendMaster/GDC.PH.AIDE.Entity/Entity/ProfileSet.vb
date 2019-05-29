Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer

Imports System.Runtime.CompilerServices
Imports System.Data.SqlClient
''' <summary>
''' ''' GIANN CALRO CAMILO
''' </summary>
''' <remarks></remarks>
Public Class ProfileSet
    Implements IProfileSet, INotifyPropertyChanged


    Private cProfile As clsProfile
    Private cProfileFactory As clsProfileFactory


     Public Sub New()
        cProfile = New clsProfile()
        cProfileFactory = New clsProfileFactory()
    End Sub

    Public Sub New(ByVal objProfile As clsProfile)
        cProfile = objProfile
        cProfileFactory = New clsProfileFactory()
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property EmployeeID As Integer Implements IProfileSet.EmployeeID
        Get
            Return Me.cProfile.EMP_ID
        End Get
        Set(value As Integer)
            Me.cProfile.EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property


    Public Property WsEpID As String Implements IProfileSet.WsEmpID
        Get
            Return Me.cProfile.WS_EMP_ID
        End Get
        Set(value As String)
            Me.cProfile.WS_EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property DeptID As Short Implements IProfileSet.DeptID
        Get
            Return Me.cProfile.DEPT_ID
        End Get
        Set(value As Short)
            Me.cProfile.DEPT_ID = value
            NotifyPropertyChanged()
        End Set
    End Property



    Public Property FirstName As String Implements IProfileSet.FirstName
        Get
            Return Me.cProfile.FIRST_NAME
        End Get
        Set(value As String)
            Me.cProfile.FIRST_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property LastName As String Implements IProfileSet.LastName
        Get
            Return Me.cProfile.LAST_NAME
        End Get
        Set(value As String)
            Me.cProfile.LAST_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property MiddleName As String Implements IProfileSet.MiddleName
        Get
            Return Me.cProfile.MIDDLE_NAME
        End Get
        Set(value As String)
            Me.cProfile.MIDDLE_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property NickName As String Implements IProfileSet.NickName
        Get
            Return IIf(IsDBNull(Me.cProfile.NICK_NAME), "", Me.cProfile.NICK_NAME)
        End Get
        Set(value As String)
            Me.cProfile.NICK_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property BirthDate As Date Implements IProfileSet.BirthDate
        Get
            Return Me.cProfile.BIRTHDATE
        End Get
        Set(value As Date)
            Me.cProfile.BIRTHDATE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property DateHired As Date Implements IProfileSet.DateHired
        Get
            Return IIf(IsDBNull(Me.cProfile.DATE_HIRED), New Date(), Me.cProfile.DATE_HIRED)
        End Get
        Set(value As Date)
            Me.cProfile.DATE_HIRED = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property ImagePath As String Implements IProfileSet.ImagePath
        Get
            Return IIf(IsDBNull(Me.cProfile.IMAGE_PATH), "", Me.cProfile.IMAGE_PATH)
        End Get
        Set(value As String)
            Me.cProfile.IMAGE_PATH = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Department As String Implements IProfileSet.Department
        Get
            Return IIf(IsDBNull(Me.cProfile.DEPARTMENT), "", Me.cProfile.DEPARTMENT)
        End Get
        Set(value As String)
            Me.cProfile.DEPARTMENT = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Division As String Implements IProfileSet.Division
        Get
            Return IIf(IsDBNull(Me.cProfile.DIVISION), "", Me.cProfile.DIVISION)
        End Get
        Set(value As String)
            Me.cProfile.DIVISION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Position As String Implements IProfileSet.Position
        Get
            Return IIf(IsDBNull(Me.cProfile.POSITION), "", Me.cProfile.POSITION)
        End Get
        Set(value As String)
            Me.cProfile.POSITION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property EmailAddress As String Implements IProfileSet.EmailAddress
        Get
            Return IIf(IsDBNull(Me.cProfile.EMAIL_ADDRESS), "", Me.cProfile.EMAIL_ADDRESS)
        End Get
        Set(value As String)
            Me.cProfile.EMAIL_ADDRESS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property EmailAddress2 As String Implements IProfileSet.EmailAddress2
        Get
            Return IIf(IsDBNull(Me.cProfile.EMAIL_ADDRESS2), "", Me.cProfile.EMAIL_ADDRESS2)
        End Get
        Set(value As String)
            Me.cProfile.EMAIL_ADDRESS2 = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Location As String Implements IProfileSet.Location
        Get
            Return IIf(IsDBNull(Me.cProfile.LOCATION), "", Me.cProfile.LOCATION)
        End Get
        Set(value As String)
            Me.cProfile.LOCATION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property CelNo As String Implements IProfileSet.CelNo
        Get
            Return IIf(IsDBNull(Me.cProfile.CEL_NO), "", Me.cProfile.CEL_NO)
        End Get
        Set(value As String)
            Me.cProfile.CEL_NO = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Local As Integer Implements IProfileSet.Local
        Get
            Return IIf(IsDBNull(Me.cProfile.LOCAL), "", Me.cProfile.LOCAL)
        End Get
        Set(value As Integer)
            Me.cProfile.LOCAL = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property HomePhone As String Implements IProfileSet.HomePhone
        Get
            Return IIf(IsDBNull(Me.cProfile.HOMEPHONE), "", Me.cProfile.HOMEPHONE)
        End Get
        Set(value As String)
            Me.cProfile.HOMEPHONE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property OtherPhone As String Implements IProfileSet.OtherPhone
        Get
            Return IIf(IsDBNull(Me.cProfile.OTHER_PHONE), "", Me.cProfile.OTHER_PHONE)
        End Get
        Set(value As String)
            Me.cProfile.OTHER_PHONE = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property DtReviewed As DateTime Implements IProfileSet.DtReviewed
        Get
            Return IIf(IsDBNull(Me.cProfile.DT_REVIEWED), "", Me.cProfile.DT_REVIEWED)
        End Get
        Set(value As DateTime)
            Me.cProfile.DT_REVIEWED = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Permission As String Implements IProfileSet.Permission
        Get
            Return IIf(IsDBNull(Me.cProfile.PERMISSION), "", Me.cProfile.PERMISSION)
        End Get
        Set(value As String)
            Me.cProfile.PERMISSION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property CivilStatus As String Implements IProfileSet.CivilStatus
        Get
            Return Me.cProfile.CIVILSTATUS
        End Get
        Set(value As String)
            Me.cProfile.CIVILSTATUS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property ShiftStatus As String Implements IProfileSet.ShiftStatus
        Get
            Return Me.cProfile.SHIFT_STATUS
        End Get
        Set(value As String)
            Me.cProfile.SHIFT_STATUS = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Function GetProfile(EmpId As String) As ProfileSet Implements IProfileSet.GetProfile
        Try
            Dim key As clsProfileKeys = New clsProfileKeys(EmpId)

            Dim objProfile As clsProfile
            objProfile = Me.cProfileFactory.getProfile(key)
            If IsNothing(objProfile) Then
                Throw New EmployeeNotFoundException("Employee Not Found")
            End If
            Dim profile As ProfileSet = New ProfileSet(objProfile)
            Return profile

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Public Function GetProfileByEmailAddress(EmailAddress As String) As ProfileSet Implements IProfileSet.GetProfileByEmailAddress
        Try
            Dim objProfile As clsProfile
            objProfile = Me.cProfileFactory.getProfileByEmailAddress(EmailAddress)
            If IsNothing(objProfile) Then
                Throw New EmployeeNotFoundException("Employee Not Found")
            End If
            Dim profile As ProfileSet = New ProfileSet(objProfile)
            Return profile

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try

    End Function
    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    'Public Function UpdateProfile() As Boolean Implements IProfileSet.UpdateProfile
    '    Try

    '        Return Me.cProfileFactory.UpdateProfile(cProfile)
    '    Catch ex As Exception
    '        If (ex.InnerException.GetType() = GetType(SqlException)) Then
    '            Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
    '        Else
    '            Throw New UpdateFailedException("Update Profile Failed!")
    '        End If
    '    End Try
    'End Function
End Class
