Imports GDC.PH.AIDE.BusinessLayer
Public Interface ILateSet
    Property FIRST_NAME As String
    Property STATUS As Integer
    Property MONTH As String
    Property NUMBER_OF_LATE As Integer

    Function GetLate(ByVal empID As Integer, ByVal month As Integer, ByVal year As Integer, ByVal toDisplay As Integer) As List(Of LateSet)

End Interface
