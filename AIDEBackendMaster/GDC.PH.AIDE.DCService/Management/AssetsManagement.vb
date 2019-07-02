Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class AssetsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objAssets As AssetsSet = DirectCast(objData, AssetsSet)
        Dim assetsData As New Assets
        assetsData.ASSET_ID = objAssets.ASSET_ID
        assetsData.EMP_ID = objAssets.EMP_ID
        assetsData.ASSET_DESC = objAssets.ASSET_DESC
        assetsData.MANUFACTURER = objAssets.MANUFACTURER
        assetsData.SERIAL_NO = objAssets.SERIAL_NO
        assetsData.ASSET_TAG = objAssets.ASSET_TAG
        assetsData.DATE_PURCHASED = objAssets.DATE_PURCHASED
        assetsData.STATUS = objAssets.STATUS
        assetsData.OTHER_INFO = objAssets.OTHER_INFO
        assetsData.COMMENTS = objAssets.COMMENTS
        assetsData.MODEL_NO = objAssets.MODEL_NO
        assetsData.DEPARTMENT = objAssets.DEPARTMENT
        assetsData.FULL_NAME = objAssets.FULL_NAME
        assetsData.DATE_ASSIGNED = objAssets.DATE_ASSIGNED
        assetsData.APPROVAL = objAssets.APPROVAL
        assetsData.STATUS_DESCR = objAssets.STATUS_DESCR

        Return assetsData
    End Function

    Public Function GetMappedFieldsForNickname(ByVal objData As Object) As Object
        Dim objNickname As NicknameSet = DirectCast(objData, NicknameSet)
        Dim nicknamedata As New Nickname
        nicknamedata.Emp_ID = objNickname.EmpID
        nicknamedata.Nick_Name = objNickname.Nick_Name
        nicknamedata.First_Name = objNickname.First_Name

        Return nicknamedata
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertAssets(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(assetsSet, assets)
            If assetsSet.InsertAssets(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Create Assets Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAllAssetsByEmpID(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsByEmpID(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetMyAssets(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetMyAssets(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAllAssetsBySearch(empID As Integer, input As String) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsBySearch(empID, input)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function UpdateAssets(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(assetsSet, assets)
            If assetsSet.UpdateAssets(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Assets Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function GetAllAssetsInventoryByEmpID(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsInventoryByEmpID(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAllAssetsInventoryBySearch(empID As Integer, input As String, page As String) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsInventoryBySearch(empID, input, page)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAllAssetsInventoryUnApproved(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsInventoryUnApproved(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function InsertAssetsInventory(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(assetsSet, assets)
            If assetsSet.InsertAssetsInventory(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Create Assets Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateAssetsInventory(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(assetsSet, assets)
            If assetsSet.UpdateAssetsInventory(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Assets Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function UpdateAssetsInventoryApproval(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(assetsSet, assets)
            If assetsSet.UpdateAssetsInventoryApproval(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Assets Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function UpdateAssetsInventoryCancel(ByVal assets As Assets) As StateData
        Dim assetsSet As New AssetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(assetsSet, assets)
            If assetsSet.UpdateAssetsInventoryCancel(assetsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Assets Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function GetAllAssetsUnAssigned(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsUnAssigned(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    'For the list of Employee by Group e.g. Manager only or User only
    Public Function GetAllManagers(empID As Integer) As StateData
        Dim nicknameSet As New NicknameSet
        Dim lstNickname As List(Of NicknameSet)
        Dim objNickname As New List(Of Nickname)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstNickname = nicknameSet.GetAllManagers(empID)

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

    Public Function GetAllAssetsHistory(empID As Integer) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsHistory(empID)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAllAssetsHistoryBySearch(empID As Integer, input As String) As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAllAssetsHistoryBySearch(empID, input)

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAssetDescription() As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAssetDescription()

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
        Return state
    End Function

    Public Function GetAssetManufacturer() As StateData
        Dim assetsSet As New AssetsSet
        Dim lstAssets As List(Of AssetsSet)
        Dim objAssets As New List(Of Assets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAssets = assetsSet.GetAssetManufacturer()

            If Not IsNothing(lstAssets) Then
                For Each objList As AssetsSet In lstAssets
                    objAssets.Add(DirectCast(GetMappedFields(objList), Assets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssets, message)
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
        Dim objAssets As Assets = DirectCast(objData, Assets)
        Dim assetsData As New AssetsSet
        assetsData.ASSET_ID = objAssets.ASSET_ID
        assetsData.EMP_ID = objAssets.EMP_ID
        assetsData.ASSET_DESC = objAssets.ASSET_DESC
        assetsData.MANUFACTURER = objAssets.MANUFACTURER
        assetsData.MODEL_NO = objAssets.MODEL_NO
        assetsData.SERIAL_NO = objAssets.SERIAL_NO
        assetsData.ASSET_TAG = objAssets.ASSET_TAG
        assetsData.DATE_PURCHASED = objAssets.DATE_PURCHASED
        assetsData.STATUS = objAssets.STATUS
        assetsData.OTHER_INFO = objAssets.OTHER_INFO
        assetsData.FULL_NAME = objAssets.FULL_NAME
        assetsData.COMMENTS = objAssets.COMMENTS
        assetsData.DEPARTMENT = objAssets.DEPARTMENT
        assetsData.DATE_ASSIGNED = objAssets.DATE_ASSIGNED
        assetsData.ASSIGNED_TO = objAssets.ASSIGNED_TO
        assetsData.APPROVAL = objAssets.APPROVAL
        objResult = assetsData
    End Sub
End Class
