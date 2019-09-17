Imports GDC.PH.AIDE.BusinessLayer
Public Interface IKPISummarySet
    Property Id As Integer
    Property FYStart As Date
    Property FYEnd As Date
    Property KPIMonth As Short
    Property Subject As String
    Property Description As String
    Property KPIReferenceNo As String
    Property KPITarget As Double
    Property KPIActual As Double
    Property KPIOverall As Double
    Property DatePosted As DateTime

    Function GetKPISummaryByMonth(ByVal FY_Start As Date, ByVal FY_End As Date, ByVal Month As Short) As List(Of IKPISummarySet)
    Function GetAllKPISummary(ByVal FY_Start As Date, ByVal FY_End As Date) As List(Of IKPISummarySet)
    Function InsertKPISummary() As Boolean
    Function UpdateKPISummary() As Boolean

End Interface
