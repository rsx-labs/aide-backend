Imports GDC.PH.AIDE.Entity
Public Class SendCodeManagement
    Inherits ManagementBase

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objSendCode As SendCodeSet = DirectCast(objData, SendCodeSet)
        Dim SendCodeData As New SendCode
        SendCodeData.Work_Email = objSendCode.SendCodeWorkEmail
        SendCodeData.FName = objSendCode.SendCodeFName
        SendCodeData.LName = objSendCode.SendCodeLName
        
        Return SendCodeData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objSendCode As SendCode = DirectCast(objData, SendCode)
        Dim SendCodeData As New SendCodeSet
        SendCodeData.SendCodeWorkEmail = objSendCode.Work_Email
        SendCodeData.SendCodeFName = objSendCode.FName
        SendCodeData.SendCodeLName = objSendCode.LName
        objResult = SendCodeData
    End Sub

    Public Function GetWorkEmailbyEmail(ByVal email As String) As StateData
        Dim _sendCodeset As New SendCodeSet
        Dim objSendCode As New SendCode
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try

            Dim objsendcodeSet As SendCodeSet = _sendCodeset.GetWorkEmailbyEmail(email)

            If Not IsNothing(objsendcodeSet) Then
                objSendCode = DirectCast(GetMappedFields(objsendcodeSet), SendCode)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSendCode, message)
        Return state
        'Try
        '    lstsendcodelist = _sendCodeset.GetWorkEmailbyEmail(email)
        '    If Not IsNothing(lstsendcodelist) Then
        '        For Each objsend As SendCodeSet In lstsendcodelist
        '            objSendCode.Add(DirectCast(GetMappedFields(objsend), SendCode))
        '        Next
        '    End If
        'Catch ex As Exception
        '    status = NotifyType.IsError
        '    message = GetExceptionMessage(ex)
        'End Try
        'state = GetStateData(status, objSendCode, message)
        'Return state
    End Function
End Class
