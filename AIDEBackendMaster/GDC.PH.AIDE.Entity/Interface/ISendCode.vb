Imports GDC.PH.AIDE.BusinessLayer
Public Interface ISendCode
    Property SendCodeWorkEmail As String
    Property SendCodeFName As String
    Property SendCodeLName As String

    Function GetWorkEmailbyEmail(ByVal email As String) As SendCodeSet
End Interface
