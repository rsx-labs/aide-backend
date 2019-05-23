Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class SuccessRegisterManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objSuccess As SuccessRegisterSet = DirectCast(objData, SuccessRegisterSet)
        Dim successData As New SuccessRegister
        successData.Emp_ID = objSuccess.EmpID
        successData.SuccessID = objSuccess.SuccessID
        successData.DetailsOfSuccess = objSuccess.DetailsOfSuccess
        successData.WhosInvolve = objSuccess.WhosInvolve
        successData.Nick_Name = objSuccess.Nick_Name
        successData.AdditionalInformation = objSuccess.AdditionalInformation
        successData.DateInput = objSuccess.DateInput

        Return successData
    End Function

    Public Function GetMappedFieldsForNickname(ByVal objData As Object) As Object
        Dim objNickname As NicknameSet = DirectCast(objData, NicknameSet)
        Dim nicknamedata As New Nickname
        nicknamedata.Emp_ID = objNickname.EmpID
        nicknamedata.Nick_Name = objNickname.Nick_Name

        Return nicknamedata
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function CreateSuccessRegister(ByVal success As SuccessRegister) As StateData
        Dim successSet As New SuccessRegisterSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(successSet, success)
            If successSet.InsertSuccessRegister(successSet) Then
                status = NotifyType.IsSuccess
                message = "Create Success Register successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetNicknameByDeptID(email As String) As StateData
        Dim nicknameSet As New NicknameSet
        Dim lstNickname As List(Of NicknameSet)
        Dim objNickname As New List(Of Nickname)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstNickname = nicknameSet.GetNicknameByDeptID(email)

            If Not IsNothing(lstNickname) Then
                For Each objNicknameList As NicknameSet In lstNickname
                    objNickname.Add(DirectCast(GetMappedFieldsForNickname(objNicknameList), Nickname))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objNickname, message)
        Return state
    End Function

    Public Function GetSuccessRegisterAll(email As String) As StateData
        Dim successRegisterSet As New SuccessRegisterSet
        Dim lstSuccessRegister As List(Of SuccessRegisterSet)
        Dim objSuccessRegister As New List(Of SuccessRegister)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSuccessRegister = successRegisterSet.GetSuccessRegisterAll(email)

            If Not IsNothing(lstSuccessRegister) Then
                For Each objList As SuccessRegisterSet In lstSuccessRegister
                    objSuccessRegister.Add(DirectCast(GetMappedFields(objList), SuccessRegister))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSuccessRegister, message)
        Return state
    End Function

    Public Function GetSuccessRegisterByEmpID(email As String) As StateData
        Dim successRegisterSet As New SuccessRegisterSet
        Dim lstSuccessRegister As List(Of SuccessRegisterSet)
        Dim objSuccessRegister As New List(Of SuccessRegister)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSuccessRegister = successRegisterSet.GetSuccessRegisterByEmpID(email)

            If Not IsNothing(lstSuccessRegister) Then
                For Each objList As SuccessRegisterSet In lstSuccessRegister
                    objSuccessRegister.Add(DirectCast(GetMappedFields(objList), SuccessRegister))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSuccessRegister, message)
        Return state
    End Function

    Public Function GetSuccessRegisterBySearch(input As String, email As String) As StateData
        Dim successRegisterSet As New SuccessRegisterSet
        Dim lstSuccessRegister As List(Of SuccessRegisterSet)
        Dim objSuccessRegister As New List(Of SuccessRegister)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSuccessRegister = successRegisterSet.GetSuccessRegisterBySearch(input, email)

            If Not IsNothing(lstSuccessRegister) Then
                For Each objList As SuccessRegisterSet In lstSuccessRegister
                    objSuccessRegister.Add(DirectCast(GetMappedFields(objList), SuccessRegister))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSuccessRegister, message)
        Return state
    End Function

    Public Function DeleteSuccessRegister(ByVal successID As Integer) As StateData
        Dim successSet As New SuccessRegisterSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            'SetFields(successSet, successID)
            If successSet.DeleteSuccessRegister(successID) Then
                status = NotifyType.IsSuccess
                message = "Update Success Register Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function UpdateSuccessRegister(ByVal success As SuccessRegister) As StateData
        Dim successSet As New SuccessRegisterSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(successSet, success)
            If successSet.UpdateSuccessRegister(successSet) Then
                status = NotifyType.IsSuccess
                message = "Update Success Register Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional ByVal data As Object = Nothing, Optional ByVal message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objSuccess As SuccessRegister = DirectCast(objData, SuccessRegister)
        Dim successData As New SuccessRegisterSet
        successData.EmpID = objSuccess.Emp_ID
        successData.SuccessID = objSuccess.SuccessID
        successData.DetailsOfSuccess = objSuccess.DetailsOfSuccess
        successData.WhosInvolve = objSuccess.WhosInvolve
        successData.Nick_Name = objSuccess.Nick_Name
        successData.AdditionalInformation = objSuccess.AdditionalInformation
        successData.DateInput = objSuccess.DateInput
        objResult = successData
    End Sub
End Class
