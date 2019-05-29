Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class LateManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objLate As LateSet = DirectCast(objData, LateSet)
        Dim LateData As New Late
        LateData.FIRST_NAME = objLate.FIRST_NAME
        LateData.STATUS = objLate.STATUS
        LateData.MONTH = objLate.MONTH
        LateData.NUMBER_OF_LATE = objLate.NUMBER_OF_LATE

        Return LateData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function GetLate(empID As Integer, month As Integer, year As Integer, toDisplay As Integer) As StateData
        Dim LateSet As New LateSet
        Dim lstLate As List(Of LateSet)
        Dim objLate As New List(Of Late)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstLate = LateSet.GetLate(empID, month, year, toDisplay)

            If Not IsNothing(lstLate) Then
                For Each objList As LateSet In lstLate
                    objLate.Add(DirectCast(GetMappedFields(objList), Late))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objLate, message)
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
        Dim objLate As Late = DirectCast(objData, Late)
        Dim LateData As New LateSet
        LateData.FIRST_NAME = objLate.FIRST_NAME
        LateData.STATUS = objLate.STATUS
        LateData.MONTH = objLate.MONTH
        LateData.NUMBER_OF_LATE = objLate.NUMBER_OF_LATE

        objResult = LateData
    End Sub
End Class
