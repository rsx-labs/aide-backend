Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

Public Class ResourcePlannerManagement
    Inherits ManagementBase

#Region "Resource Planner"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks>

    Public Function InsertAttendanceForLeaves(ByVal resourcePlanner As ResourcePlanner) As StateData
        Dim resourcePlannerSet As New ResourcePlannerSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(resourcePlannerSet, resourcePlanner)
            If resourcePlannerSet.InsertAttendanceForLeaves(resourcePlannerSet) Then
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

    Public Function GetStatusResourcePlanner(empID As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetStatusResourcePlanner(empID)

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

    Public Function GetAllPerfectAttendance(email As String, month As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllPerfectAttendance(email, month, year)

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

    Public Function GetBillableHoursByWeek(empID As Integer, weekID As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetBillableHoursByWeek(empID, weekID)

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

    Public Function GetBillableHoursByMonth(empID As Integer, month As Integer, year As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetBillableHoursByMonth(empID, month, year)

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


    Public Function GetAllLeavesByEmployee(empID As Integer, leaveType As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllLeavesByEmployee(empID, leaveType)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFieldsLeaves(objList), ResourcePlanner))
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

    Public Function GetAllLeavesHistoryByEmployee(empID As Integer, leaveType As Integer) As StateData
        Dim ResourceSet As New ResourcePlannerSet
        Dim ResourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            ResourceSetLst = ResourceSet.GetAllLeavesHistoryByEmployee(empID, leaveType)

            If Not IsNothing(ResourceSetLst) Then
                For Each objList As ResourcePlannerSet In ResourceSetLst
                    objResource.Add(DirectCast(GetMappedFieldsLeaves(objList), ResourcePlanner))
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

    Public Function CancelLeave(ByVal rp As ResourcePlanner) As StateData
        Dim rpSet As New ResourcePlannerSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFieldsLeaves(rpSet, rp)
            If rpSet.CancelLeave(rpSet) Then
                status = NotifyType.IsSuccess
                message = "Update Leaves Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function GetLeavesByDateAndEmpID(empID As Integer, status As Integer, dateFrom As Date, dateTo As Date) As StateData
        Dim resourceSet As New ResourcePlannerSet
        Dim resourceSetLst As List(Of ResourcePlannerSet)
        Dim objResource As New List(Of ResourcePlanner)
        Dim message As String = ""
        Dim state As StateData
        Dim statNotify As NotifyType

        Try
            resourceSetLst = resourceSet.GetLeavesByDateAndEmpID(empID, status, dateFrom, dateTo)

            If Not IsNothing(resourceSetLst) Then
                For Each objList As ResourcePlannerSet In resourceSetLst
                    objResource.Add(DirectCast(GetMappedFieldsLeaves(objList), ResourcePlanner))
                Next

                statNotify = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            statNotify = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(statNotify, objResource, message)
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

    Public Function GetMappedFieldsLeaves(objData As Object) As Object
        Dim objResource As ResourcePlannerSet = DirectCast(objData, ResourcePlannerSet)
        Dim resourceData As New ResourcePlanner

        resourceData.StartDate = objResource.StartDate
        resourceData.EndDate = objResource.EndDate
        resourceData.Duration = objResource.Duration
        resourceData.StatusCD = objResource.StatusCD
        resourceData.Status = objResource.Status
        resourceData.DESCR = objResource.Description
        Return resourceData
    End Function

    Public Sub SetFieldsLeaves(ByRef objResult As Object, objData As Object)
        Dim objResource As ResourcePlanner = DirectCast(objData, ResourcePlanner)
        Dim resourceData As New ResourcePlannerSet

        resourceData.StartDate = objResource.StartDate
        resourceData.EndDate = objResource.EndDate
        resourceData.EmployeeID = objResource.EmpID
        resourceData.Status = objResource.Status
        objResult = resourceData
    End Sub

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
