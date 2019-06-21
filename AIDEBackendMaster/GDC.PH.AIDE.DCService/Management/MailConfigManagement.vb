Imports GDC.PH.AIDE.Entity
Public Class MailConfigManagement
    Inherits ManagementBase


    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objMailConfig As MailConfigSet = DirectCast(objData, MailConfigSet)
        Dim MailConfigData As New MailConfig

        MailConfigData.Body = objMailConfig.SCBody
        MailConfigData.EnableSSL = objMailConfig.SCEnableSSL
        MailConfigData.Host = objMailConfig.SCHost
        MailConfigData.Port = objMailConfig.SCPort
        MailConfigData.SenderEmail = objMailConfig.SCSenderEmail
        MailConfigData.SenderPassword = objMailConfig.SCSenderPassword
        MailConfigData.Subject = objMailConfig.SCSubject
        MailConfigData.Timeout = objMailConfig.SCTimeout
        MailConfigData.UseDfltCredentials = objMailConfig.SCUseDfltCredentials
        MailConfigData.PasswordExpiry = objMailConfig.SCPasswordExpiry

        Return MailConfigData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objMailConfig As MailConfig = DirectCast(objData, MailConfig)
        Dim MailConfigData As New MailConfigSet

        MailConfigData.SCBody = objMailConfig.Body
        MailConfigData.SCEnableSSL = objMailConfig.EnableSSL
        MailConfigData.SCHost = objMailConfig.Host
        MailConfigData.SCPort = objMailConfig.Port
        MailConfigData.SCSenderEmail = objMailConfig.SenderEmail
        MailConfigData.SCSenderPassword = objMailConfig.SenderPassword
        MailConfigData.SCSubject = objMailConfig.Subject
        MailConfigData.SCTimeout = objMailConfig.Timeout
        MailConfigData.SCUseDfltCredentials = objMailConfig.UseDfltCredentials
        MailConfigData.SCPasswordExpiry = objMailConfig.PasswordExpiry

        objResult = MailConfigData
    End Sub

    Public Function GetMailConfig() As StateData
        Dim _mailConfigSet As New MailConfigSet
        Dim objMailConfig As New MailConfig
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try

            Dim objMailConfigSet As MailConfigSet = _mailConfigSet.GetMailConfig()

            If Not IsNothing(objMailConfigSet) Then
                objMailConfig = DirectCast(GetMappedFields(objMailConfigSet), MailConfig)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objMailConfig, message)
        Return state
    End Function
End Class
