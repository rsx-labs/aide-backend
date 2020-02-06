Imports GDC.PH.AIDE.BusinessLayer
Public Interface IWorkplaceAuditSet
    Property AUDIT_DAILY_ID As Integer
    Property AUDIT_QUESTIONS_ID As Integer
    Property EMP_ID As Integer
    Property FY_WEEK As Integer
    Property STATUS As Integer
    Property DT_CHECKED As String
    Property DT_CHECK_FLG As Integer
    Property AUDIT_QUESTIONS As String
    Property OWNER As String
    Property AUDIT_QUESTIONS_GROUP As String
    Property WEEKDAYS As String
    Property NICKNAME As String
    Property WEEKDATE As String
    Property WEEKDATESCHED As String
    Property DATE_CHECKED As String
    Property AUDITSCHED_MONTH As String
    Property AUDIT_ID As Integer


    Function GetAuditDaily(ByVal empID As Integer, ByVal parmDate As Date) As List(Of WorkplaceAuditSet)
    Function InsertAuditDaily(ByVal auditSched As WorkplaceAuditSet) As Boolean
    Function GetAuditQuestions(ByVal empID As Integer, ByVal questionGroup As String) As List(Of WorkplaceAuditSet)
    Function GetAuditSchedMonth(audit_grp As Integer, yr As Integer, month As Integer) As List(Of WorkplaceAuditSet)
    Function GetDailyAuditorByWeek(ByVal empID As Integer, ByVal paramFYWeek As String, paramDate As Date) As List(Of WorkplaceAuditSet)
    Function GetWeeklyAuditor(ByVal empID As Integer, ByVal paramDate As DateTime) As List(Of WorkplaceAuditSet)
    Function GetMonthlyAuditor(ByVal empID As Integer, ByVal paramDate As Integer) As List(Of WorkplaceAuditSet)
    Function GetQuarterlyAuditor(ByVal empID As Integer, ByVal paramDate As Integer) As List(Of WorkplaceAuditSet)
    Function UpdateCheckAuditQuestionStatus(ByVal auditSched As WorkplaceAuditSet) As Boolean
    Function UpdateAuditSched(ByVal auditSChed As AuditSchedSet) As Boolean

End Interface