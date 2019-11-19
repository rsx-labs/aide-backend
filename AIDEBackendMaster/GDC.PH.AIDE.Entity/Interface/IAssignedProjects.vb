Imports GDC.PH.AIDE.BusinessLayer
''' <summary>
''' ''' GIANN CALRO CAMILO / LEMUELA ABULENCIA
''' </summary>
''' <remarks></remarks>
Public Interface IAssignedProjects

    Property EmpId As Integer
    Property ProjectId As Integer
    Property DateCreated As Date
    Property StartPeriod As Date
    Property EndPeriod As Date
    Function GetAssignedProjects(ByVal projectID As Integer) As List(Of AssignedProjectSet)
    Function InsertAssignedProj() As Boolean
    Function DeleteAssignedProj(ByVal EmpID As Integer, ByVal projectID As Integer) As Boolean
    Function DeleteAllAssignedProj(ByVal projectID As Integer) As Boolean
End Interface
