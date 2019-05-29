Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAnnouncementsSet
    Property EMP_ID As Integer
    Property MESSAGE As String
    Property TITLE As String
    Property END_DATE As Date

    Function GetAnnouncements(ByVal empID As Integer) As List(Of AnnouncementsSet)
    Function InsertAnnouncements(ByVal message As AnnouncementsSet) As Boolean

End Interface
