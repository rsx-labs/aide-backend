Imports GDC.PH.AIDE.BusinessLayer
Public Interface IContributorsSet
    Property FULL_NAME As String
    Property DEPARTMENT As String
    Property DIVISIOn As String
    Property POSITION As String
    Property IMAGE_PATH As String

    Function GetAllContributors(ByVal level As Integer) As List(Of ContributorsSet)
End Interface
