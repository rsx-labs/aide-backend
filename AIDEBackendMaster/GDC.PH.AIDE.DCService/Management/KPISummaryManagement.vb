Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class KPISummaryManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim kpiSummarySet As IKPISummarySet = DirectCast(objData, IKPISummarySet)
        Dim kpiSummaryData As New KPISummary
        kpiSummaryData.KPI_Id = kpiSummarySet.Id
        kpiSummaryData.EmployeeId = kpiSummarySet.Emp_Id
        kpiSummaryData.FYStart = kpiSummarySet.FYStart
        kpiSummaryData.FYEnd = kpiSummarySet.FYEnd
        kpiSummaryData.KPI_Reference = kpiSummarySet.KPIReferenceNo
        kpiSummaryData.Subject = kpiSummarySet.Subject
        kpiSummaryData.Description = kpiSummarySet.Description
        kpiSummaryData.KPI_Month = kpiSummarySet.KPIMonth
        kpiSummaryData.KPITarget = kpiSummarySet.KPITarget
        kpiSummaryData.KPIActual = kpiSummarySet.KPIActual
        kpiSummaryData.KPIOverall = kpiSummarySet.KPIOverall
        kpiSummaryData.DatePosted = kpiSummarySet.DatePosted

        Return kpiSummaryData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertKPISummary(ByVal kpiSummaryData As KPISummary) As StateData
        Dim kpiSet As New KPISummarySet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(kpiSet, kpiSummaryData)
            If kpiSet.InsertKPISummary() Then
                status = NotifyType.IsSuccess
                message = "Create KPI Summary Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateKPISummary(ByVal kpiSummaryData As KPISummary) As StateData
        Dim kpiSet As New KPISummarySet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(kpiSet, kpiSummaryData)
            If kpiSet.UpdateKPISummary() Then
                status = NotifyType.IsSuccess
                message = "Update KPI Summary Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetKPISummaryByMonth(ByVal EmpId As Integer, ByVal FY_Start As Date, ByVal FY_End As Date, ByVal Month As Short, KPIRef As String) As StateData
        Dim kpiSet As New KPISummarySet
        Dim lstKpiSet As List(Of IKPISummarySet)
        Dim kpiSummaryData As New List(Of KPISummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstKpiSet = kpiSet.GetKPISummaryByMonth(EmpId, FY_Start, FY_End, Month, KPIRef)

            If Not IsNothing(lstKpiSet) Then
                For Each item As IKPISummarySet In lstKpiSet
                    kpiSummaryData.Add(DirectCast(GetMappedFields(item), KPISummary))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, kpiSummaryData, message)
        Return state
    End Function

    Public Function GetAllKPISummary(ByVal EmpId As Integer, ByVal FY_Start As Date, ByVal FY_End As Date) As StateData
        Dim kpiSet As New KPISummarySet
        Dim lstKpiSet As List(Of IKPISummarySet)
        Dim kpiSummaryData As New List(Of KPISummary)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstKpiSet = kpiSet.GetAllKPISummary(EmpId, FY_Start, FY_End)

            If Not IsNothing(lstKpiSet) Then
                For Each item As IKPISummarySet In lstKpiSet
                    kpiSummaryData.Add(DirectCast(GetMappedFields(item), KPISummary))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, kpiSummaryData, message)
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
        Dim kpi As KPISummary = DirectCast(objData, KPISummary)
        Dim kpiset As New KPISummarySet
        kpiset.Id = kpi.KPI_Id
        kpiset.Emp_Id = kpi.EmployeeId
        kpiset.FYStart = kpi.FYStart
        kpiset.FYEnd = kpi.FYEnd
        kpiset.KPIMonth = kpi.KPI_Month
        kpiset.KPIReferenceNo = kpi.KPI_Reference
        kpiset.Description = kpi.Description
        kpiset.Subject = kpi.Subject
        kpiset.KPITarget = kpi.KPITarget
        kpiset.KPIActual = kpi.KPIActual
        kpiset.KPIOverall = kpi.KPIOverall
        kpiset.DatePosted = kpi.DatePosted

        objResult = kpiset
    End Sub
End Class
