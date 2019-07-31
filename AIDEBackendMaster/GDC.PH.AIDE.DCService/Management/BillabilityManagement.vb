Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class BillabilityManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function GetBillableHoursByMonth(empID As Integer, month As Integer, year As Integer, weekID As Integer) As StateData
        Dim BillablesSet As New BillableSet
        Dim BillablesSetLst As List(Of BillableSet)
        Dim objResource As New List(Of BillableHours)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            BillablesSetLst = BillablesSet.GetBillableHoursByMonth(empID, month, year, weekID)

            If Not IsNothing(BillablesSetLst) Then
                For Each objList As BillableSet In BillablesSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), BillableHours))
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

    Public Function GetBillableHoursByWeek(empID As Integer, weekID As Integer) As StateData
        Dim BillablesSet As New BillableSet
        Dim BillablesSetLst As List(Of BillableSet)
        Dim objResource As New List(Of BillableHours)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            BillablesSetLst = BillablesSet.GetBillableHoursByWeek(empID, weekID)

            If Not IsNothing(BillablesSetLst) Then
                For Each objList As BillableSet In BillablesSetLst
                    objResource.Add(DirectCast(GetMappedFields(objList), BillableHours))
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

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objResource As BillableSet = DirectCast(objData, BillableSet)
        Dim resourceData As New BillableHours

        resourceData.Name = objResource.Name
        resourceData.Hours = objResource.Hours
        resourceData.Status = objResource.Status

        Return resourceData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
End Class
