Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAnnouncementsSet
    Property ANNOUNCEMENT_ID As Integer
    Property EMP_ID As Integer
    Property MESSAGE As String
    Property TITLE As String
    Property END_DATE As Date
    Property DELETED_FG As Integer

    Function GetAnnouncements(ByVal empID As Integer) As List(Of AnnouncementsSet)
    Function InsertAnnouncements(ByVal message As AnnouncementsSet) As Boolean
    Function UpdateAnnouncements(ByVal message As AnnouncementsSet) As Boolean

End Interface
