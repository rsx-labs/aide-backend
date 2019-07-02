Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

''' <summary>
''' By Aevan Camille Batongbacal
''' </summary>
Public Class SuccessRegisterSet
    Implements INotifyPropertyChanged, ISuccessRegisterSet

    Private cSuccessRegister As clsSuccessRegister
    Private cSuccessRegisterFactory As clsSuccessRegisterFactory
    Private cNickname As clsNickname
    Private cNicknameFactory As clsNicknameFactory


    Public Sub New()
        cSuccessRegister = New clsSuccessRegister()
        cSuccessRegisterFactory = New clsSuccessRegisterFactory()
    End Sub

    Public Sub New(ByVal objSuccessRegister As clsSuccessRegister)
        cSuccessRegister = objSuccessRegister
        cSuccessRegisterFactory = New clsSuccessRegisterFactory()
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property DateInput As Date Implements ISuccessRegisterSet.DateInput
        Get
            Return Me.cSuccessRegister.DATE_INPUT
        End Get
        Set(value As Date)
            Me.cSuccessRegister.DATE_INPUT = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property EmpID As Integer Implements ISuccessRegisterSet.EmpID
        Get
            Return Me.cSuccessRegister.EMP_ID
        End Get
        Set(value As Integer)
            Me.cSuccessRegister.EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property DeptID As Integer Implements ISuccessRegisterSet.DeptID
        Get
            Return Me.cSuccessRegister.DEPT_ID
        End Get
        Set(value As Integer)
            Me.cSuccessRegister.DEPT_ID = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property DetailsOfSuccess As String Implements ISuccessRegisterSet.DetailsOfSuccess
        Get
            Return Me.cSuccessRegister.DetailsOfSuccess
        End Get
        Set(value As String)
            Me.cSuccessRegister.DetailsOfSuccess = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property Nick_Name As String Implements ISuccessRegisterSet.Nick_Name
        Get
            Return IIf(IsDBNull(Me.cSuccessRegister.Nick_Name), "", Me.cSuccessRegister.Nick_Name)
        End Get
        Set(value As String)
            Me.cSuccessRegister.Nick_Name = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property First_Name As String Implements ISuccessRegisterSet.First_Name
        Get
            Return IIf(IsDBNull(Me.cSuccessRegister.FIRST_NAME), "", Me.cSuccessRegister.FIRST_NAME)
        End Get
        Set(value As String)
            Me.cSuccessRegister.FIRST_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property WhosInvolve As String Implements ISuccessRegisterSet.WhosInvolve
        Get
            Return IIf(IsDBNull(Me.cSuccessRegister.WhosInvolve), "", Me.cSuccessRegister.WhosInvolve)
        End Get
        Set(value As String)
            Me.cSuccessRegister.WhosInvolve = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property AdditionalInformation As String Implements ISuccessRegisterSet.AdditionalInformation
        Get
            Return IIf(IsDBNull(Me.cSuccessRegister.AdditionalInformation), "", Me.cSuccessRegister.AdditionalInformation)
        End Get
        Set(value As String)
            Me.cSuccessRegister.AdditionalInformation = value
            NotifyPropertyChanged()
        End Set
    End Property
    Public Property SuccessID As Integer Implements ISuccessRegisterSet.SuccessID
        Get
            Return Me.cSuccessRegister.SUCCESS_ID
        End Get
        Set(value As Integer)
            Me.cSuccessRegister.SUCCESS_ID = value
            NotifyPropertyChanged()
        End Set
    End Property


    Public Function InsertSuccessRegister(successRegister As SuccessRegisterSet) As Boolean Implements ISuccessRegisterSet.InsertSuccessRegister
        Try
            Return Me.cSuccessRegisterFactory.InsertSuccessRegister(cSuccessRegister)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetSuccessRegisterAll(email As String) As List(Of SuccessRegisterSet) Implements ISuccessRegisterSet.GetSuccessRegisterAll
        Try

            Dim lstSuccessRegister As List(Of clsSuccessRegister)
            Dim lstSuccessRegisterSet As New List(Of SuccessRegisterSet)

            lstSuccessRegister = Me.cSuccessRegisterFactory.getSuccessRegisterAll(email)

            If Not IsNothing(lstSuccessRegister) Then
                For Each cList As clsSuccessRegister In lstSuccessRegister
                    lstSuccessRegisterSet.Add(New SuccessRegisterSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstSuccessRegisterSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Public Function GetSuccessRegisterByEmpID(ByVal email As String) As List(Of SuccessRegisterSet) Implements ISuccessRegisterSet.GetSuccessRegisterByEmpID
        Try
            Dim key As clsSuccessRegisterKeys = New clsSuccessRegisterKeys(email)

            Dim lstSuccessRegister As List(Of clsSuccessRegister)
            Dim lstSuccessRegisterSet As New List(Of SuccessRegisterSet)

            lstSuccessRegister = Me.cSuccessRegisterFactory.getSuccessRegisterByEmpID(email)

            If Not IsNothing(lstSuccessRegister) Then
                For Each cList As clsSuccessRegister In lstSuccessRegister
                    lstSuccessRegisterSet.Add(New SuccessRegisterSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstSuccessRegisterSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Public Function GetSuccessRegisterBySearch(ByVal input As String, ByVal email As String) As List(Of SuccessRegisterSet) Implements ISuccessRegisterSet.GetSuccessRegisterBySearch
        Try
            Dim key As clsSuccessRegisterKeys = New clsSuccessRegisterKeys(input, email)
            Dim lstSuccessRegister As List(Of clsSuccessRegister)
            Dim lstSuccessRegisterSet As New List(Of SuccessRegisterSet)

            lstSuccessRegister = Me.cSuccessRegisterFactory.getSuccessRegisterBySearch(key)

            If Not IsNothing(lstSuccessRegister) Then
                For Each cList As clsSuccessRegister In lstSuccessRegister
                    lstSuccessRegisterSet.Add(New SuccessRegisterSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstSuccessRegisterSet

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

    Public Function UpdateSuccessRegister(successRegister As SuccessRegisterSet) As Boolean Implements ISuccessRegisterSet.UpdateSuccessRegister
        Try

            Return Me.cSuccessRegisterFactory.UpdateSuccessRegister(cSuccessRegister)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function DeleteSuccessRegister(successID As Integer) As Boolean Implements ISuccessRegisterSet.DeleteSuccessRegister
        Try

            Return Me.cSuccessRegisterFactory.DeleteSuccessRegister(successID)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Delete Success Register Failed!")
            End If
        End Try
    End Function

End Class

Public Class NicknameSet
    Implements INotifyPropertyChanged, INicknameSet

    Private cNickname As clsNickname
    Private cNicknamefactory As clsNicknameFactory

    Public Sub New()
        cNickname = New clsNickname()
        cNicknamefactory = New clsNicknameFactory()
    End Sub

    Public Sub New(ByVal objNickname As clsNickname)
        cNickname = objNickname
        cNicknamefactory = New clsNicknameFactory()
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property EmpID As Integer Implements INicknameSet.EmpID
        Get
            Return Me.cNickname.EMP_ID
        End Get
        Set(value As Integer)
            Me.cNickname.EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Nick_Name As String Implements INicknameSet.Nick_Name
        Get
            Return IIf(IsDBNull(Me.cNickname.NICK_NAME), "", Me.cNickname.NICK_NAME)
        End Get
        Set(value As String)
            Me.cNickname.NICK_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property First_Name As String Implements INicknameSet.First_Name
        Get
            Return IIf(IsDBNull(Me.cNickname.FIRST_NAME), "", Me.cNickname.FIRST_NAME)
        End Get
        Set(value As String)
            Me.cNickname.FIRST_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property ToDisplay As Integer Implements INicknameSet.ToDisplay
        Get
            Return Me.cNickname.TO_DISPLAY
        End Get
        Set(value As Integer)
            Me.cNickname.TO_DISPLAY = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Function GetNicknameByDeptID(email As String, toDisplay As Integer) As List(Of NicknameSet) Implements INicknameSet.GetNicknameByDeptID
        Try

            Dim lstNickname As List(Of clsNickname)
            Dim lstNicknameSet As New List(Of NicknameSet)

            lstNickname = Me.cNicknamefactory.getNicknameByDeptID(email, toDisplay)

            If Not IsNothing(lstNickname) Then
                For Each cList As clsNickname In lstNickname
                    lstNicknameSet.Add(New NicknameSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstNicknameSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Public Function GetEmployeePerProject(empID As Integer, projID As Integer) As List(Of NicknameSet) Implements INicknameSet.GetEmployeePerProject
        Try

            Dim lstNickname As List(Of clsNickname)
            Dim lstNicknameSet As New List(Of NicknameSet)

            lstNickname = Me.cNicknamefactory.GetEmployeePerProject(empID, projID)

            If Not IsNothing(lstNickname) Then
                For Each cList As clsNickname In lstNickname
                    lstNicknameSet.Add(New NicknameSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstNicknameSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Public Function GetAllManagers(empID As Integer) As List(Of NicknameSet) Implements INicknameSet.GetAllManagers
        Try

            Dim lstNickname As List(Of clsNickname)
            Dim lstNicknameSet As New List(Of NicknameSet)

            lstNickname = Me.cNicknamefactory.GetAllManagers(empID)

            If Not IsNothing(lstNickname) Then
                For Each cList As clsNickname In lstNickname
                    lstNicknameSet.Add(New NicknameSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstNicknameSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
            Return Nothing
        End Try

    End Function

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class