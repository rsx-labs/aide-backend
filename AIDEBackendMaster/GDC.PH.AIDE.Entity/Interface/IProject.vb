Imports GDC.PH.AIDE.BusinessLayer

Public Interface IProject
    Property ProjectId As Integer
    Property ProjectCode As String
    Property EmpID As Integer
    Property ProjectName As String
    Property Category As Short
    Property Billability As Short
    Property Status As String
    Property Name As String
    Property FirstMonth As String
    Property SecondMonth As String
    Property ThirdMonth As String

    Function InsertNewProject() As Boolean
    Function UpdateProject() As Boolean
    Function ViewProject() As List(Of ProjectSet)
    Function GetProjectByID(ByVal ProjId As Integer) As ProjectSet
    Function GetProjectLists(ByVal empID As Integer, ByVal displayStatus As Integer) As List(Of ProjectSet)
    Function ViewProjectListofEmployee(ByVal empID As Integer) As List(Of ProjectSet)
End Interface
