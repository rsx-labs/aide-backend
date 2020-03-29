Imports GDC.PH.AIDE.BusinessLayer
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports GDC.PH.AIDE.Entity
Public Class ProblemSet
    Implements IProblemSet, INotifyPropertyChanged

    Private cProblem As clsProblem
    Private cProblemFactory As clsProblemFactory
    Public Sub New()
        cProblem = New clsProblem()
        cProblemFactory = New clsProblemFactory()
    End Sub

    Public Sub New(ByVal objProblem As clsProblem)
        cProblem = objProblem
        cProblemFactory = New clsProblemFactory()
    End Sub
    Public Property EmployeeID As Integer Implements IProblemSet.EmployeeID
        Get
            Return Me.cProblem.EMP_ID
        End Get
        Set(value As Integer)
            Me.cProblem.EMP_ID = value
            NotifyPropertyChanged("EmployeeID")
        End Set
    End Property
    Public Property ProblemID As Integer Implements IProblemSet.ProblemID
        Get
            Return Me.cProblem.PROBLEM_ID
        End Get
        Set(value As Integer)
            Me.cProblem.PROBLEM_ID = value
            NotifyPropertyChanged("ProblemID")
        End Set
    End Property

    Public Property ProblemDescr As String Implements IProblemSet.ProblemDescr
        Get
            Return Me.cProblem.PROBLEM_DESCR
        End Get
        Set(value As String)
            Me.cProblem.PROBLEM_DESCR = value
            NotifyPropertyChanged("ProblemDescr")
        End Set
    End Property

    Public Property ProblemInvolve As String Implements IProblemSet.ProblemInvolve
        Get
            Return Me.cProblem.PROBLEM_INVOLVE
        End Get
        Set(value As String)
            Me.cProblem.PROBLEM_INVOLVE = value
            NotifyPropertyChanged("ProblemInvolve")
        End Set
    End Property



    Public Property CauseID As Integer Implements IProblemSet.CauseID
        Get
            Return Me.cProblem.CAUSE_ID
        End Get
        Set(value As Integer)
            Me.cProblem.CAUSE_ID = value
            NotifyPropertyChanged("CauseID")
        End Set
    End Property

    Public Property CauseWhy As String Implements IProblemSet.CauseWhy
        Get
            Return Me.cProblem.CAUSE_WHY
        End Get
        Set(value As String)
            Me.cProblem.CAUSE_WHY = value
            NotifyPropertyChanged("CauseWhy")
        End Set
    End Property

    Public Property OptionID As Integer Implements IProblemSet.OptionID
        Get
            Return Me.cProblem.OPTION_ID
        End Get
        Set(value As Integer)
            Me.cProblem.OPTION_ID = value
            NotifyPropertyChanged("OptionID")
        End Set
    End Property

    Public Property OptionDescr As String Implements IProblemSet.OptionDescr
        Get
            Return Me.cProblem.OPTION_DESCR
        End Get
        Set(value As String)
            Me.cProblem.OPTION_DESCR = value
            NotifyPropertyChanged("OptionDescr")
        End Set
    End Property

    Public Property SolutionID As Integer Implements IProblemSet.SolutionID
        Get
            Return Me.cProblem.SOLUTION_ID
        End Get
        Set(value As Integer)
            Me.cProblem.SOLUTION_ID = value
            NotifyPropertyChanged("SolutionID")
        End Set
    End Property

    Public Property SolutionDescr As String Implements IProblemSet.SolutionDescr
        Get
            Return Me.cProblem.SOLUTION_DESCR
        End Get
        Set(value As String)
            Me.cProblem.SOLUTION_DESCR = value
            NotifyPropertyChanged("SolutionDescr")
        End Set
    End Property

    Public Property ImplementID As Integer Implements IProblemSet.ImplementID
        Get
            Return Me.cProblem.IMPLEMENT_ID
        End Get
        Set(value As Integer)
            Me.cProblem.IMPLEMENT_ID = value
            NotifyPropertyChanged("ImplementID")
        End Set
    End Property

    Public Property ImplementDescr As String Implements IProblemSet.ImplementDescr
        Get
            Return Me.cProblem.IMPLEMENT_DESCR
        End Get
        Set(value As String)
            Me.cProblem.IMPLEMENT_DESCR = value
            NotifyPropertyChanged("ImplementDescr")
        End Set
    End Property

    Public Property ImplementAssignee As Integer Implements IProblemSet.ImplementAssignee
        Get
            Return Me.cProblem.IMPLEMENT_ASSIGNEE
        End Get
        Set(value As Integer)
            Me.cProblem.IMPLEMENT_ASSIGNEE = value
            NotifyPropertyChanged("ImplementAssignee")
        End Set
    End Property

    Public Property ImplementValue As String Implements IProblemSet.ImplementValue
        Get
            Return Me.cProblem.IMPLEMENT_VALUE
        End Get
        Set(value As String)
            Me.cProblem.IMPLEMENT_VALUE = value
            NotifyPropertyChanged("ImplementValue")
        End Set
    End Property

    Public Property ResultID As Integer Implements IProblemSet.ResultID
        Get
            Return Me.cProblem.RESULT_ID
        End Get
        Set(value As Integer)
            Me.cProblem.RESULT_ID = value
            NotifyPropertyChanged("ResultID")
        End Set
    End Property

    Public Property ResultDescr As String Implements IProblemSet.ResultDescr
        Get
            Return Me.cProblem.RESULT_DESCR
        End Get
        Set(value As String)
            Me.cProblem.RESULT_DESCR = value
            NotifyPropertyChanged("ResultDescr")
        End Set
    End Property

    Public Property ResultValue As String Implements IProblemSet.ResultValue
        Get
            Return Me.cProblem.RESULT_VALUE
        End Get
        Set(value As String)
            Me.cProblem.RESULT_VALUE = value
            NotifyPropertyChanged("ResultValue")
        End Set
    End Property

    Public Property EmployeeName As String Implements IProblemSet.EmployeeName
        Get
            Return Me.cProblem.EMPLOYEE_NAME
        End Get
        Set(value As String)
            Me.cProblem.EMPLOYEE_NAME = value
            NotifyPropertyChanged("EmployeeName")
        End Set
    End Property

    Public Property CauseDescr As String Implements IProblemSet.CauseDescr
        Get
            Return Me.cProblem.CAUSE_DESCR
        End Get
        Set(value As String)
            Me.cProblem.CAUSE_DESCR = value
            NotifyPropertyChanged("CauseDescr")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function GetAllProblems(empID As Integer) As List(Of ProblemSet) Implements IProblemSet.GetAllProblems
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblems(empID)

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblem() As Boolean Implements IProblemSet.InsertProblem
        Try
            Return Me.cProblemFactory.InsertProblem(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProblem() As Boolean Implements IProblemSet.UpdateProblem
        Try
            Return Me.cProblemFactory.UpdateProblem(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllProblemCause() As List(Of ProblemSet) Implements IProblemSet.GetAllProblemCause
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblemCause()

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblemCause() As Boolean Implements IProblemSet.InsertProblemCause
        Try
            Return Me.cProblemFactory.InsertProblemCause(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllProblemOption() As List(Of ProblemSet) Implements IProblemSet.GetAllProblemOption
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblemOption()

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblemOption() As Boolean Implements IProblemSet.InsertProblemOption
        Try
            Return Me.cProblemFactory.InsertProblemOption(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllProblemSolution() As List(Of ProblemSet) Implements IProblemSet.GetAllProblemSolution
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblemSolution()

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblemSolution() As Boolean Implements IProblemSet.InsertProblemSolution
        Try
            Return Me.cProblemFactory.InsertProblemSolution(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllProblemImplement() As List(Of ProblemSet) Implements IProblemSet.GetAllProblemImplement
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblemImplement()

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblemImplement() As Boolean Implements IProblemSet.InsertProblemImplement
        Try
            Return Me.cProblemFactory.InsertProblemImplement(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllProblemResult(problemID As Integer, optionID As Integer) As List(Of ProblemSet) Implements IProblemSet.GetAllProblemResult
        Try
            Dim lstProblem As List(Of clsProblem)
            Dim lstProblemSet As New List(Of ProblemSet)

            lstProblem = cProblemFactory.GetAllProblemResult(problemID, optionID)

            If Not IsNothing(lstProblem) Then
                For Each cList As clsProblem In lstProblem
                    lstProblemSet.Add(New ProblemSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstProblemSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertProblemResult() As Boolean Implements IProblemSet.InsertProblemResult
        Try
            Return Me.cProblemFactory.InsertProblemResult(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProblemCause() As Boolean Implements IProblemSet.UpdateProblemCause
        Try
            Return Me.cProblemFactory.UpdateProblemCause(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProblemOption() As Boolean Implements IProblemSet.UpdateProblemOption
        Try
            Return Me.cProblemFactory.UpdateProblemOption(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProblemSolution() As Boolean Implements IProblemSet.UpdateProblemSolution
        Try
            Return Me.cProblemFactory.UpdateProblemSolution(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateProblemImplement() As Boolean Implements IProblemSet.UpdateProblemImplement
        Try
            Return Me.cProblemFactory.UpdateProblemImplement(cProblem)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
End Class
