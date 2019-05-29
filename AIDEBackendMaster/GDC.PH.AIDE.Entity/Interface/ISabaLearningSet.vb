Imports GDC.PH.AIDE.BusinessLayer
Public Interface ISabaLearningSet
    Property SABA_ID As Integer
    Property EMP_ID As Integer
    Property TITLE As String
    Property END_DATE As Date
    Property DATE_COMPLETED As String
    Property IMAGE_PATH As String

    Function GetAllSabaCourses(ByVal empID As Integer) As List(Of SabaLearningSet)
    Function GetAllSabaXref(ByVal empID As Integer, ByVal sabaID As Integer) As List(Of SabaLearningSet)
    Function InsertSabaCourses() As Boolean
    Function UpdateSabaCourses() As Boolean
    Function UpdateSabaXref() As Boolean
    Function GetAllSabaCourseByTitle(ByVal saba_message As String, ByVal empID As Integer) As List(Of SabaLearningSet)
End Interface
