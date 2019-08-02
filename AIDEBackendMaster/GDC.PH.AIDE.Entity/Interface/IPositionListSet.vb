Imports GDC.PH.AIDE.BusinessLayer

Public Interface ILocationListSet
    Property LOCATION_ID As Integer
    Property LOCATION As String
    Property ONSITE_FLG As Short
    Function GetAllLocation() As List(Of LocationListSet)
End Interface

Public Interface IPositionListSet
    Property POS_ID As Integer
    Property POS_DESCR As String
    Function GetAllPosition() As List(Of PositionListSet)
End Interface

Public Interface IPermissionListSet
    Property GRP_ID As Integer
    Property GRP_DESCR As String
    Function GetAllPermission() As List(Of PermissionListSet)
End Interface

Public Interface IDepartmentListSet
    Property DEPT_ID As Integer
    Property DEPT_DESCR As String
    Function GetAllDepartment() As List(Of DepartmentListSet)
End Interface

Public Interface IDivisionListSet
    Property DIV_ID As Integer
    Property DIV_DESCR As String
    Function GetAllDivision() As List(Of DivisionListSet)
End Interface

Public Interface IStatusListSet
    Property STATUS_ID As Integer
    Property STATUS_DESCR As String
    Function GetAllStatus(statusname As String) As List(Of StatusListSet)
End Interface
