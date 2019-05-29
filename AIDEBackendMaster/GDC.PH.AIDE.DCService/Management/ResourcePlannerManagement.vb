Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class ResourcePlannerManagement
    Inherits ManagementBase

#Region "Resource Planner"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks>

    Public Function UpdateResourcePlanner(ByVal rp As ResourcePlanner) As StateData
        Dim rpSet As New ResourcePlannerSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(rpSet, rp)
            If rpSet.UpdateResourcePlanner(rpSet) Then
                status = NotifyType.IsSuccess
                message = "Update Resource Planner Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function InsertResourcePlanner(ByVal rp As ResourcePlanner) As StateData
        Dim rpSet As New ResourcePlannerSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(rpSet, rp)
            If rpSet.InsertResourcePlanner(rpSet) Then
                status = NotifyType.IsSuccess
                message = "Insert Resource Planner Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function ViewEmpResourcePlanner(email As String) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.ViewEmpResourcePlanner(email)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetStatusResourcePlanner() As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetStatusResourcePlanner()

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetResourcePlannerByEmpID(empID As Integer, deptID As Integer, month As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetResourcePlannerByEmpID(empID, deptID, month, year)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetAllEmpResourcePlanner(email As String, month As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllEmpResourcePlanner(email, month, year)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetAllEmpResourcePlannerByStatus(email As String, month As Integer, year As Integer, statuss As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllEmpResourcePlannerByStatus(email, month, year, statuss)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetAllStatusResourcePlanner() As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllStatusResourcePlanner()

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetResourcePlanner(email As String, status As Integer, toBeDisplayed As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim statusS As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetResourcePlanner(email, status, toBeDisplayed, year)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            statusS = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetBillableHoursByWeek(empID As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetBillableHoursByWeek(empID)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetBillableHoursByMonth(empID As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetBillableHoursByMonth(empID)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Function GetNonBillableHours(email As String, display As Integer, month As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetNonBillableHours(email, display, month, year)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), ResourcePlanner))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objResource, message)
        Return state
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objResource As ResourcePlannerSet = DirectCast(objData, ResourcePlannerSet)
        Dim resourceData As New ResourcePlanner

        resourceData.EmpID = objResource.EmployeeID
        resourceData.NAME = objResource.Name
        resourceData.dateFrom = objResource.dateFrom
        resourceData.dateTo = objResource.dateTo
        resourceData.Status = objResource.Status
        resourceData.DESCR = objResource.Description
        resourceData.Image_Path = objResource.Image_Path
        resourceData.DateEntry = objResource.Date_Entry
        resourceData.UsedLeaves = objResource.UsedLeaves
        resourceData.TotalBalance = objResource.TotalBalance
        resourceData.HalfBalance = objResource.HalfBalance
        resourceData.holidayHours = objResource.holidayHours
        resourceData.vlHours = objResource.vlHours
        resourceData.slHours = objResource.slHours

        Return resourceData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objResource As ResourcePlanner = DirectCast(objData, ResourcePlanner)
        Dim resourceData As New ResourcePlannerSet

        resourceData.EmployeeID = objResource.EmpID
        resourceData.NAME = objResource.NAME
        resourceData.dateFrom = objResource.dateFrom
        resourceData.dateTo = objResource.dateTo
        resourceData.Status = objResource.Status
        resourceData.Description = objResource.DESCR
        resourceData.Image_Path = objResource.Image_Path
        resourceData.Date_Entry = objResource.DateEntry

        objResult = resourceData
    End Sub

#End Region

    

End Class
