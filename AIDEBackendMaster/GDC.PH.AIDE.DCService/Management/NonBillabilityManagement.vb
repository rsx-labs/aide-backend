Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class NonBillabilityManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function getNonBillableData(inputDate As Date) As StateData
        Dim nonBillableSet As New BillableSet
        Dim lstNonBillables As New List(Of NonBillableSummary)
        Dim lstClsNonBillables As New List(Of BillableSet)
        Dim lstNonBillablesGroup As New List(Of NonBillableSummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Dim month = inputDate.Month
        Dim year = inputDate.Year


        Try
            lstClsNonBillables = nonBillableSet.sp_getBillableSummary(month, year)
            If lstClsNonBillables.Count > 0 Then
                For Each _nonBillables As BillableSet In lstClsNonBillables
                    lstNonBillables.Add(DirectCast(GetMappedFields(_nonBillables), NonBillableSummary))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, lstNonBillables, "")
        Return state
    End Function


    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objNonbillables As BillableSet = DirectCast(objData, BillableSet)
        Dim nonBillableData As New NonBillableSummary
        nonBillableData.Employeeid = objNonbillables.EmployeeID
        nonBillableData.Name = objNonbillables.Nickame
        nonBillableData.SickLeave = objNonbillables.SL
        nonBillableData.VacationLeave = objNonbillables.VL
        'nonBillableData.InBetween = objNonbillables.IBP
        nonBillableData.Holiday = objNonbillables.Holiday
        nonBillableData.Halfday = objNonbillables.HalfDay
        nonBillableData.HalfdayVL = objNonbillables.HalfVl
        nonBillableData.HalfdaySL = objNonbillables.HalfSl
        nonBillableData.Total = objNonbillables.Total
        Return nonBillableData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
End Class
