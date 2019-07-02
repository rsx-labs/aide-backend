Imports gdc.ph.AIDE.BusinessLayer

''' <summary>
''' By Aevan Camille Batongbacal
''' </summary>
Public Interface ISuccessRegisterSet

    Property EmpID As Integer
    Property WhosInvolve As String
    Property DetailsOfSuccess As String
    Property AdditionalInformation As String
    Property Nick_Name As String
    Property First_Name As String
    Property DateInput As Date
    Property SuccessID As Integer
    Property DeptID As Integer

    Function GetSuccessRegisterAll(ByVal email As String) As List(Of SuccessRegisterSet)
    Function GetSuccessRegisterByEmpID(ByVal email As String) As List(Of SuccessRegisterSet)
    Function GetSuccessRegisterBySearch(ByVal input As String, ByVal email As String) As List(Of SuccessRegisterSet)
    Function UpdateSuccessRegister(ByVal successRegister As SuccessRegisterSet) As Boolean
    Function InsertSuccessRegister(ByVal successRegister As SuccessRegisterSet) As Boolean
    Function DeleteSuccessRegister(ByVal successID As Integer) As Boolean

End Interface

Public Interface INicknameSet

    Property EmpID As Integer
    Property Nick_Name As String
    Property ToDisplay As Integer
    Property First_Name As String

    Function GetNicknameByDeptID(ByVal email As String, ByVal ToDisplay As Integer) As List(Of NicknameSet)
    Function GetEmployeePerProject(ByVal empID As Integer, ByVal projID As Integer) As List(Of NicknameSet)
    Function GetAllManagers(ByVal empID As Integer) As List(Of NicknameSet)
End Interface