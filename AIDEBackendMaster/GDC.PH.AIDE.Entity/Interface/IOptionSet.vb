Imports GDC.PH.AIDE.BusinessLayer
Public Interface IOptionSet
    Property OptionID As Integer
    Property ModuleID As Integer
    Property FunctionID As Integer
    Property Description As String
    Property Value As String
    Property ModuleDescr As String
    Property FunctionDescr As String

    Function GetOptions(ByVal optionID As Integer, ByVal moduleID As Integer, ByVal functionID As Integer) As List(Of OptionSet)
End Interface
