Imports System.ComponentModel
Imports System.Data.SqlClient
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
''' <summary>
''' By Jhunell G. Barcenas
''' </summary>
''' <remarks></remarks>
Public Class SkillSet
    Implements ISkill, INotifyPropertyChanged

    Private cSkill As clsSkills
    Private cSkillFactory As clsSkillsFactory

    Public Sub New()
        cSkill = New clsSkills()
        cSkillFactory = New clsSkillsFactory
    End Sub

    Public Sub New(ByVal cList As clsSkills)
        cSkill = cList
        cSkillFactory = New clsSkillsFactory
    End Sub

    Public Property EmployeeID As Integer Implements ISkill.EmployeeID
        Get
            Return Me.cSkill.EMP_ID
        End Get
        Set(value As Integer)
            Me.cSkill.EMP_ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Image_Path As String Implements ISkill.Image_Path
        Get
            Return Me.cSkill.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cSkill.IMAGE_PATH = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property SkillID As Integer Implements ISkill.SkillID
        Get
            Return Me.cSkill.SKILL_ID
        End Get
        Set(value As Integer)
            Me.cSkill.SKILL_ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Prof_LVL As Integer Implements ISkill.Prof_LVL
        Get
            Return Me.cSkill.PROF_LVL
        End Get
        Set(value As Integer)
            Me.cSkill.PROF_LVL = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property LastReviewed As DateTime Implements ISkill.LastReviewed
        Get
            Return Me.cSkill.LAST_REVIEWED
        End Get
        Set(value As DateTime)
            Me.cSkill.LAST_REVIEWED = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property SkillsDescr As String Implements ISkill.SkillDescr
        Get
            Return Me.cSkill.DESCR
        End Get
        Set(value As String)
            Me.cSkill.DESCR = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Name As String Implements ISkill.Name
        Get
            Return Me.cSkill.EMPLOYEE_NAME
        End Get
        Set(value As String)
            Me.cSkill.EMPLOYEE_NAME = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function GetAllSkillList(empId As Integer) As List(Of SkillSet) Implements ISkill.GetAllSkillList
        Try
            Dim SkillLst As List(Of clsSkills)
            Dim SkillSetLst As New List(Of SkillSet)

            SkillLst = cSkillFactory.GetSkillsList(empId)

            If Not IsNothing(SkillLst) Then
                For Each cList As clsSkills In SkillLst
                    SkillSetLst.Add(New SkillSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return SkillSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetProfLvlByEmpIDSkillID(empId As Integer, skillID As Integer) As SkillSet Implements ISkill.GetProfLvlByEmpIDSkillID
        Try
            Dim objSkill As clsSkills

            objSkill = Me.cSkillFactory.GetProfLvlByEmpIDSkillID(empId, skillID)

            If IsNothing(objSkill) Then
                Throw New EmployeeNotFoundException("Employee Not Found")
            End If
            Dim skill As SkillSet = New SkillSet(objSkill)
            Return skill

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function ViewAllEmpSkills(empID As Integer) As List(Of SkillSet) Implements ISkill.ViewAllEmpSkills
        Try
            Dim SkillLst As List(Of clsSkills)
            Dim SkillSetLst As New List(Of SkillSet)

            SkillLst = cSkillFactory.ViewEmpSkills(empID)

            If Not IsNothing(SkillLst) Then
                For Each cList As clsSkills In SkillLst
                    SkillSetLst.Add(New SkillSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return SkillSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetSkillsProfByEmpID(id As Integer) As List(Of SkillSet) Implements ISkill.GetSkillsProfByEmpID
        Try
            Dim SkillLst As List(Of clsSkills)
            Dim SkillSetLst As New List(Of SkillSet)

            SkillLst = cSkillFactory.GetSkillsProfByEmpID(id)

            If Not IsNothing(SkillLst) Then
                For Each cList As clsSkills In SkillLst
                    SkillSetLst.Add(New SkillSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return SkillSetLst

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertSkills(skills As SkillSet) As Boolean Implements ISkill.InsertNewSkills
        Try
            Return Me.cSkillFactory.InsertSkills(cSkill)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Lesson Learnt Failed!")
            End If
        End Try
    End Function

    Public Function UpdateSkills(skills As SkillSet) As Boolean Implements ISkill.UpdateSkills
        Try
            Return Me.cSkillFactory.UpdateSkills(cSkill)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAllSkills(skills As SkillSet) As Boolean Implements ISkill.UpdateAllSkills
        Try
            Return Me.cSkillFactory.UpdateAllSkills(cSkill)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    Public Function GetSkillsLastReviewByEmpIDSkillID(empId As Integer, skillID As Integer) As SkillSet Implements ISkill.GetSkillsLastReviewByEmpIDSkillID
        Try
            Dim objSkill As clsSkills

            objSkill = Me.cSkillFactory.GetSkillsLastReviewByEmpIDSkillID(empId, skillID)

            If IsNothing(objSkill) Then
                Throw New EmployeeNotFoundException("Employee Not Found")
            End If
            Dim skill As SkillSet = New SkillSet(objSkill)
            Return skill

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
End Class
