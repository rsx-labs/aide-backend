''' <summary>
''' ''' GIANN CALRO CAMILO
''' </summary>
''' <remarks></remarks>
Public Interface IEmployeeSet
    Property EmployeeID As Integer
    Property EmployeeName As String
    Property LastName As String
    Property FirstName As String
    Property MiddleInitial As String
    Property NickName As String
    Property BirthDate As DateTime
    Property Position As String
    Property DateHired As DateTime
    Property Status As Short
    Property ImagePath As String
    Property GroupID As Short
    Property EmailAddress As String
    Property EmailAddress2 As String
    Property Location As String
    Property CelNo As String
    Property Local As Integer
    Property HomePhone As String
    Property Other_Phone As String
    Property DtReviewed As DateTime
    Property ManagerEmail As String

    Function GetEmployeeList() As List(Of EmployeeSet)

    Function GetNicknameByDeptID(ByVal email As String) As List(Of EmployeeSet)


    Function GetEmployee(ByVal empId As Integer) As EmployeeSet

    Function UpdateEmployee() As Boolean

    Function GetMissingAttendanceForToday(ByVal empID As Integer) As List(Of EmployeeSet)

End Interface
