Imports GDC.PH.AIDE.BusinessLayer
Public Interface IMailConfigSet
    Property SCSenderEmail As String
    Property SCSubject As String
    Property SCBody As String
    Property SCPort As Integer
    Property SCHost As String
    Property SCEnableSSL As Integer
    Property SCTimeout As Integer
    Property SCUseDfltCredentials As Integer
    Property SCSenderPassword As String
    Property SCPasswordExpiry As Integer


    Function GetMailConfig() As MailConfigSet
End Interface
