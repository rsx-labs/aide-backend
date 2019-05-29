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

    Function InsertAssignedProj() As Boolean
  

End Interface
