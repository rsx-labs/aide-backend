Imports GDC.PH.AIDE.BusinessLayer
Public Interface IActionLists
    ''' <summary>
    ''' By Lemuela Abulencia
    ''' </summary>
    ''' <remarks></remarks>
    Property ActionID As String
    Property ActionMessage As String
    Property ActionAssignee As Integer
    Property ActionNickName As String
    Property ActionDueDate As Date
    Property ActionDateClosed As String

    Function InsertActionList() As Boolean
    Function GetActionListByMessage(ByVal ActionMessage As String, ByVal email As String) As List(Of ActionListSet)
    Function GetActionListByActionNo(ByVal actionNo As String, ByVal empID As Integer) As List(Of ActionListSet)
    Function GetAllActionList(ByVal email As String) As List(Of ActionListSet)
    Function GetLessonLearntListOfActionSummary(ByVal empID As Integer) As List(Of ActionListSet)
    Function UpdateActionList() As Boolean
End Interface
