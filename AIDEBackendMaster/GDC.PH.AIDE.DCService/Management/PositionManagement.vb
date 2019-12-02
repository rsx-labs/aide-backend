Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class PositionManagement
    Inherits ManagementBase
    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objSet As PositionListSet = DirectCast(objData, PositionListSet)
        Dim classData As New PositionList

        classData.POS_ID = objSet.POS_ID
        classData.POS_DESCR = objSet.POS_DESCR

        Return classData
    End Function

    Public Function GetMappedFieldsPermission(objData As Object) As Object
        Dim objSet As PermissionListSet = DirectCast(objData, PermissionListSet)
        Dim classData As New PermissionList

        classData.GRP_ID = objSet.GRP_ID
        classData.GRP_DESCR = objSet.GRP_DESCR

        Return classData
    End Function

    Public Function GetMappedFieldsDepartment(objData As Object) As Object
        Dim objSet As DepartmentListSet = DirectCast(objData, DepartmentListSet)
        Dim classData As New DepartmentList

        classData.DEPT_ID = objSet.DEPT_ID
        classData.DEPT_DESCR = objSet.DEPT_DESCR

        Return classData
    End Function

    Public Function GetMappedFieldsDivision(objData As Object) As Object
        Dim objSet As DivisionListSet = DirectCast(objData, DivisionListSet)
        Dim classData As New DivisionList

        classData.DIV_ID = objSet.DIV_ID
        classData.DIV_DESCR = objSet.DIV_DESCR

        Return classData
    End Function

    Public Function GetMappedFieldsStatus(objData As Object) As Object
        Dim objSet As StatusListSet = DirectCast(objData, StatusListSet)
        Dim classData As New StatusList

        classData.STATUS_ID = objSet.STATUS_ID
        classData.STATUS_DESCR = objSet.STATUS_DESCR

        Return classData
    End Function

    Public Function GetMappedFieldsLocation(objData As Object) As Object
        Dim objSet As LocationListSet = DirectCast(objData, LocationListSet)
        Dim classData As New LocationList

        classData.LOCATION_ID = objSet.LOCATION_ID
        classData.LOCATION = objSet.LOCATION
        classData.ONSITE_FLG = objSet.ONSITE_FLG

        Return classData
    End Function

    Public Function GetMappedFieldsFiscalYear(objData As Object) As Object
        Dim objSet As FiscalYearListSet = DirectCast(objData, FiscalYearListSet)
        Dim classData As New FiscalYear

        classData.FISCAL_YEAR = objSet.FISCAL_YEAR

        Return classData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)

    End Sub

    Public Function GetAllLocations() As StateData
        Dim objSet As New LocationListSet
        Dim objSetList As List(Of LocationListSet)
        Dim classDataList As New List(Of LocationList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllLocation()

            If Not IsNothing(objSetList) Then
                For Each objList As LocationListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsLocation(objList), LocationList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllPositions() As StateData
        Dim objSet As New PositionListSet
        Dim objSetList As List(Of PositionListSet)
        Dim classDataList As New List(Of PositionList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllPosition()

            If Not IsNothing(objSetList) Then
                For Each objList As PositionListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFields(objList), PositionList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllPermissions() As StateData
        Dim objSet As New PermissionListSet
        Dim objSetList As List(Of PermissionListSet)
        Dim classDataList As New List(Of PermissionList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllPermission()

            If Not IsNothing(objSetList) Then
                For Each objList As PermissionListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsPermission(objList), PermissionList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllDepartments() As StateData
        Dim objSet As New DepartmentListSet
        Dim objSetList As List(Of DepartmentListSet)
        Dim classDataList As New List(Of DepartmentList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllDepartment()

            If Not IsNothing(objSetList) Then
                For Each objList As DepartmentListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsDepartment(objList), DepartmentList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllDivisions() As StateData
        Dim objSet As New DivisionListSet
        Dim objSetList As List(Of DivisionListSet)
        Dim classDataList As New List(Of DivisionList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllDivision()

            If Not IsNothing(objSetList) Then
                For Each objList As DivisionListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsDivision(objList), DivisionList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllStatus(statusName As String) As StateData
        Dim objSet As New StatusListSet
        Dim objSetList As List(Of StatusListSet)
        Dim classDataList As New List(Of StatusList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllStatus(statusName)

            If Not IsNothing(objSetList) Then
                For Each objList As StatusListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsStatus(objList), StatusList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function

    Public Function GetAllFiscalYear() As StateData
        Dim objSet As New FiscalYearListSet
        Dim objSetList As List(Of FiscalYearListSet)
        Dim classDataList As New List(Of FiscalYear)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            objSetList = objSet.GetAllFiscalYear()

            If Not IsNothing(objSetList) Then
                For Each objList As FiscalYearListSet In objSetList
                    classDataList.Add(DirectCast(GetMappedFieldsFiscalYear(objList), FiscalYear))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, classDataList, message)
        Return state
    End Function
End Class
