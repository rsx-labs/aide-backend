Public Interface IProblemSet
    Property EmployeeID As Integer
    Property EmployeeName As String
    Property ProblemID As Integer
    Property ProblemDescr As String
    Property ProblemInvolve As String
    Property CauseID As Integer
    Property CauseDescr As String
    Property CauseWhy As String
    Property OptionID As Integer
    Property OptionDescr As String
    Property SolutionID As Integer
    Property SolutionDescr As String
    Property ImplementID As Integer
    Property ImplementDescr As String
    Property ImplementAssignee As Integer
    Property ImplementValue As String
    Property ResultID As Integer
    Property ResultDescr As String
    Property ResultValue As String

    Function GetAllProblems(ByVal empID As Integer) As List(Of ProblemSet)
    Function InsertProblem() As Boolean
    Function UpdateProblem() As Boolean
    Function GetAllProblemCause() As List(Of ProblemSet)
    Function InsertProblemCause() As Boolean
    Function UpdateProblemCause() As Boolean
    Function GetAllProblemOption() As List(Of ProblemSet)
    Function InsertProblemOption() As Boolean
    Function UpdateProblemOption() As Boolean
    Function GetAllProblemSolution() As List(Of ProblemSet)
    Function InsertProblemSolution() As Boolean
    Function UpdateProblemSolution() As Boolean
    Function GetAllProblemImplement() As List(Of ProblemSet)
    Function InsertProblemImplement() As Boolean
    Function UpdateProblemImplement() As Boolean
    Function GetAllProblemResult(ByVal problemID As Integer, ByVal optionID As Integer) As List(Of ProblemSet)
    Function InsertProblemResult() As Boolean
End Interface
