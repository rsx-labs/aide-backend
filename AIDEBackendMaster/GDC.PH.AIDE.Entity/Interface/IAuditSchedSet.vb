Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAuditSchedSet
    Property AUDIT_SCHED_ID As Integer
    Property YEAR As Integer
    Property EMP_ID As Integer
    Property FY_WEEK As Integer
    Property PERIOD_START As DateTime
    Property PERIOD_END As DateTime
    Property DAILY As String
    Property WEEKLY As String
    Property MONTHLY As String
    Property FY_START As DateTime
    Property FY_END As DateTime

    Function GetAuditSched(ByVal empID As Integer, ByVal year As Integer) As List(Of AuditSchedSet)
    Function InsertAuditSched(ByVal auditSched As AuditSchedSet) As Boolean
    Function UpdateAuditSched(ByVal auditSched As AuditSchedSet) As Boolean

End Interface
