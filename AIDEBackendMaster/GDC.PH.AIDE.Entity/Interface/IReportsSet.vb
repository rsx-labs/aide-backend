Imports GDC.PH.AIDE.BusinessLayer
Public Interface IReportsSet
    Property REPORT_ID As Integer
    Property OPT_ID As Integer
    Property MODULE_ID As Integer
    Property DESCRIPTION As String
    Property FILE_PATH As String

    Function GetAllReports() As List(Of ReportsSet)
End Interface
