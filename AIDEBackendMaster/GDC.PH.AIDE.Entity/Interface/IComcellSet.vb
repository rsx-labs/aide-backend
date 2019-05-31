Imports GDC.PH.AIDE.BusinessLayer
Public Interface IComcellSet
    Property COMCELL_ID As Integer
    Property YEAR As Integer
    Property EMP_ID As Integer
    Property MONTH As String
    Property FACILITATOR As String
    Property MINUTES_TAKER As String
    Property SCHEDULE As String
    Property FY_START As DateTime
    Property FY_END As DateTime

    Function GetComcellMeeting(ByVal empID As Integer, ByVal year As Integer) As List(Of ComcellSet)
    Function InsertComcellMeeting(ByVal comcell As ComcellSet) As Boolean
    Function UpdateComcellMeeting(ByVal comcell As ComcellSet) As Boolean

End Interface
