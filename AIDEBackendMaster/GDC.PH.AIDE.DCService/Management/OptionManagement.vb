Imports GDC.PH.AIDE.Entity
Public Class OptionManagement
    Inherits ManagementBase

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objOptionSet As OptionSet = DirectCast(objData, OptionSet)
        Dim optionData As New Options
        optionData.OptionID = objOptionSet.OptionID
        optionData.Value = objOptionSet.Value
        optionData.ModuleDescr = objOptionSet.ModuleDescr
        optionData.FunctionDescr = objOptionSet.FunctionDescr
        Return optionData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function GetOptions(ByVal optionID As Integer, ByVal moduleID As Integer, ByVal functionID As Integer) As StateData
        Dim _optionSet As New OptionSet
        Dim lstOptionSet As List(Of OptionSet)
        Dim objOption As New List(Of Options)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstOptionSet = _optionSet.GetOptions(optionID, moduleID, functionID)
            If Not IsNothing(lstOptionSet) Then
                For Each objopt As OptionSet In lstOptionSet
                    objOption.Add(DirectCast(GetMappedFields(objopt), Options))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objOption, message)
        Return state
    End Function
End Class
