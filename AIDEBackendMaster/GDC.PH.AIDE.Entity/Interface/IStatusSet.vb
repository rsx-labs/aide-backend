Imports GDC.PH.AIDE.BusinessLayer
Public Interface IStatusSet
    Property STATUS_ID As Short
    Property STATUS_NAME As String
    Property Description As String
    Property Status As Short
    Property CurrentStatusSet As StatusSet

    Function getAttendanceStatus() As List(Of StatusSet)
    Function getCivil() As List(Of StatusSet)
    Function GetTaskStatus() As List(Of StatusSet)
    Function GetTaskCategories() As List(Of StatusSet)
    Function GetPhaseStatus() As List(Of StatusSet)
    Function GetReworkStatus() As List(Of StatusSet)
End Interface
