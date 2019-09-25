Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class KPITargetsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim kpiTargetsSet As IKPITargetsSet = DirectCast(objData, IKPITargetsSet)
        Dim kpiTargetsData As New KPITargets
        kpiTargetsData.KPI_Id = kpiTargetsSet.Id
        kpiTargetsData.EmployeeId = kpiTargetsSet.Emp_Id
        kpiTargetsData.FYStart = kpiTargetsSet.FYStart
        kpiTargetsData.FYEnd = kpiTargetsSet.FYEnd
        kpiTargetsData.KPI_ReferenceNo = kpiTargetsSet.KPIReferenceNo
        kpiTargetsData.Description = kpiTargetsSet.Description
        kpiTargetsData.Subject = kpiTargetsSet.Subject
        kpiTargetsData.DateCreated = kpiTargetsSet.CreateDate

        Return kpiTargetsData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertKPITargets(ByVal kpiTargetsData As KPITargets) As StateData
        Dim kpiSet As New KPITargetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(kpiSet, kpiTargetsData)
            If kpiSet.InsertKPITargets() Then
                status = NotifyType.IsSuccess
                message = "Create KPI Targets Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateKPITargets(ByVal kpiTargetsData As KPITargets) As StateData
        Dim kpiSet As New KPITargetsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(kpiSet, kpiTargetsData)
            If kpiSet.UpdateKPITargets() Then
                status = NotifyType.IsSuccess
                message = "Update KPI Targets Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetKPITarget(Id As Integer) As StateData
        Dim kpiSet As New KPITargetsSet
        Dim lstKpiSet As List(Of IKPITargetsSet)
        Dim kpiTargetData As New List(Of KPITargets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstKpiSet = kpiSet.GetKPITargetById(Id)

            If Not IsNothing(lstKpiSet) Then
                For Each item As IKPITargetsSet In lstKpiSet
                    kpiTargetData.Add(DirectCast(GetMappedFields(item), KPITargets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, kpiTargetData, message)
        Return state
    End Function

    Public Function GetAllKPITargets(EmpID As Integer, fiscalYear As Date) As StateData
        Dim kpiSet As New KPITargetsSet
        Dim lstKpiSet As List(Of IKPITargetsSet)
        Dim kpiTargetData As New List(Of KPITargets)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstKpiSet = kpiSet.GetKPITargetByFiscalYear(EmpID, fiscalYear)

            If Not IsNothing(lstKpiSet) Then
                For Each item As IKPITargetsSet In lstKpiSet
                    kpiTargetData.Add(DirectCast(GetMappedFields(item), KPITargets))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, kpiTargetData, message)
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
        Dim kpi As KPITargets = DirectCast(objData, KPITargets)
        Dim kpiset As New KPITargetsSet
        kpiset.Id = kpi.KPI_Id
        kpiset.EmpId = kpi.EmployeeId
        kpiset.FYStart = kpi.FYStart
        kpiset.FYEnd = kpi.FYEnd
        kpiset.KPIReferenceNo = kpi.KPI_ReferenceNo
        kpiset.Description = kpi.Description
        kpiset.Subject = kpi.Subject
        kpiset.CreateDate = kpi.DateCreated

        objResult = kpiset
    End Sub
End Class
