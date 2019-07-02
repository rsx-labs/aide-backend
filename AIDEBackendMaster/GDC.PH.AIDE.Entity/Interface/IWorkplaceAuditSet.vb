Imports GDC.PH.AIDE.BusinessLayer
Public Interface IWorkplaceAuditSet
    Property AUDIT_DAILY_ID As Integer
    Property AUDIT_QUESTIONS_ID As Integer
    Property EMP_ID As Integer
    Property FY_WEEK As Integer
    Property STATUS As Integer
    Property DT_CHECKED As Date
    Property AUDIT_QUESTIONS As String
    Property OWNER As String
    Property AUDIT_QUESTIONS_GROUP As String

    Function GetAuditDaily(ByVal empID As Integer, ByVal parmDate As Date) As List(Of WorkplaceAuditSet)
    Function InsertAuditDaily(ByVal auditSched As WorkplaceAuditSet) As Boolean
    Function GetAuditQuestions(ByVal empID As Integer, ByVal questionGroup As String) As List(Of WorkplaceAuditSet)
    'Function UpdateAuditSched(ByVal auditSched As WorkplaceAuditSet) As Boolean

End Interface
