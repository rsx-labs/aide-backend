Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class ReportsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub



    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objReports As ReportsSet = DirectCast(objData, ReportsSet)
        Dim ReportsData As New Reports
        ReportsData.REPORT_ID = objReports.REPORT_ID
        ReportsData.OPT_ID = objReports.OPT_ID
        ReportsData.MODULE_ID = objReports.MODULE_ID
        ReportsData.DESCRIPTION = objReports.DESCRIPTION
        ReportsData.FILE_PATH = objReports.FILE_PATH

        Return ReportsData
    End Function

    Public Function GetAllReports() As StateData
        Dim Reports As New ReportsSet
        Dim lstReports As List(Of ReportsSet)
        Dim objReports As New List(Of Reports)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstReports = Reports.GetAllReports()

            If Not IsNothing(lstReports) Then
                For Each objList As ReportsSet In lstReports
                    objReports.Add(DirectCast(GetMappedFields(objList), Reports))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objReports, message)
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
        Dim objReports As Reports = DirectCast(objData, Reports)
        Dim ReportsData As New ReportsSet
        ReportsData.REPORT_ID = objReports.REPORT_ID
        ReportsData.OPT_ID = objReports.OPT_ID
        ReportsData.MODULE_ID = objReports.MODULE_ID
        ReportsData.DESCRIPTION = objReports.DESCRIPTION
        ReportsData.FILE_PATH = objReports.FILE_PATH
        objResult = ReportsData
    End Sub
End Class
