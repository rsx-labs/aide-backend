Imports GDC.PH.AIDE.BusinessLayer
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class ProjectSet
    Implements IProject, INotifyPropertyChanged

    Private cProject As clsProject
    Private cProjectFactory As clsProjectFactory
    Public Sub New()
        cProject = New clsProject()
        cProjectFactory = New clsProjectFactory()
    End Sub

    Public Sub New(ByVal objProject As clsProject)
        cProject = objProject
        cProjectFactory = New clsProjectFactory()
    End Sub

    Public Property Billability As Short Implements IProject.Billability
        Get
            Return Me.cProject.BILLABILITY
        End Get
        Set(value As Short)
            Me.cProject.BILLABILITY = value
            NotifyPropertyChanged("Billability")
        End Set
    End Property
    Public Property Category As Short Implements IProject.Category
        Get
            Return Me.cProject.CATEGORY
        End Get
        Set(value As Short)
            Me.cProject.CATEGORY = value
            NotifyPropertyChanged("Category")
        End Set
    End Property
    Public Function InsertNewProject() As Boolean Implements IProject.InsertNewProject
        Try
            Return Me.cProjectFactory.Insert(cProject)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProject() As Boolean Implements IProject.UpdateProject
        Try
            Return Me.cProjectFactory.Update(cProject)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Property EmpID As Integer Implements IProject.EmpID
        Get
            Return Me.cProject.EMP_ID
        End Get
        Set(value As Integer)
            Me.cProject.EMP_ID = value
            NotifyPropertyChanged("EmpID")
        End Set
    End Property

    Public Property ProjectId As Integer Implements IProject.ProjectId
        Get
            Return Me.cProject.PROJ_ID
        End Get
        Set(value As Integer)
            Me.cProject.PROJ_ID = value
            NotifyPropertyChanged("ProjectId")
        End Set
    End Property
    Public Property ProjectName As String Implements IProject.ProjectName
        Get
            Return Me.cProject.PROJ_NAME
        End Get
        Set(value As String)
            Me.cProject.PROJ_NAME = value
            NotifyPropertyChanged("ProjectName")
        End Set
    End Property

    Public Function GetProjectByID(ProjId As Integer) As ProjectSet Implements IProject.GetProjectByID
        Try
            Dim key As clsProjectKeys = New clsProjectKeys(ProjId)
            Dim objProject As clsProject
            objProject = Me.cProjectFactory.GetByPrimaryKey(key)
            If Not IsNothing(objProject) Then
                Dim projSet As ProjectSet = New ProjectSet(objProject)
                Return projSet
            Else
                Throw New NoRecordFoundException("Project code not found!")
            End If
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try

    End Function

    Public Function ViewProject() As List(Of ProjectSet) Implements IProject.ViewProject
        Try
            Dim lstProject As List(Of clsProject)
            Dim lstProjectSet As New List(Of ProjectSet)

            lstProject = cProjectFactory.GetAll()

            If Not IsNothing(lstProject) Then
                For Each cList As clsProject In lstProject
                    lstProjectSet.Add(New ProjectSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstProjectSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


    ''' <summary>
    ''' VIEW PROJECT
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ViewProjectListofEmployee(ByVal empID As Integer) As List(Of ProjectSet) Implements IProject.ViewProjectListofEmployee
        Try
            Dim lstProject As List(Of clsProject)
            Dim lstProjectSet As New List(Of ProjectSet)
            lstProject = cProjectFactory.GetAllProjectListofEmployee(empID)
            If Not IsNothing(lstProject) Then
                For Each cEmp As clsProject In lstProject
                    lstProjectSet.Add(New ProjectSet(cEmp))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstProjectSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetProjectLists(ByVal EmpID As Integer, ByVal displayStatus As Integer) As List(Of ProjectSet) Implements IProject.GetProjectLists
        Try
            Dim lstProject As List(Of clsProject)
            Dim lstProjectSet As New List(Of ProjectSet)

            lstProject = cProjectFactory.GetAllProjects(EmpID, displayStatus)

            If Not IsNothing(lstProject) Then
                For Each cList As clsProject In lstProject
                    lstProjectSet.Add(New ProjectSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProjectSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Property FirstMonth As String Implements IProject.FirstMonth
        Get
            Return Me.cProject.FIRSTMONTH
        End Get
        Set(value As String)
            Me.cProject.FIRSTMONTH = value
            NotifyPropertyChanged("FirstMonth")
        End Set
    End Property
    Public Property Name As String Implements IProject.Name
        Get
            Return Me.cProject.NAME
        End Get
        Set(value As String)
            Me.cProject.NAME = value
            NotifyPropertyChanged("Name")
        End Set
    End Property
    Public Property SecondMonth As String Implements IProject.SecondMonth
        Get
            Return Me.cProject.SECONDMONTH
        End Get
        Set(value As String)
            Me.cProject.SECONDMONTH = value
            NotifyPropertyChanged("SecondMonth")
        End Set
    End Property
    Public Property Status As String Implements IProject.Status
        Get
            Return Me.cProject.STATUS
        End Get
        Set(value As String)
            Me.cProject.STATUS = value
            NotifyPropertyChanged("Status")
        End Set
    End Property
    Public Property ThirdMonth As String Implements IProject.ThirdMonth
        Get
            Return Me.cProject.THIRDMONTH
        End Get
        Set(value As String)
            Me.cProject.THIRDMONTH = value
            NotifyPropertyChanged("ThirdMonth")
        End Set
    End Property

End Class
