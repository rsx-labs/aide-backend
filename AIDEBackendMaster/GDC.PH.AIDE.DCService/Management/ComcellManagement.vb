Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class ComcellManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objComcell As ComcellSet = DirectCast(objData, ComcellSet)
        Dim comcellData As New comcell
        comcellData.COMCELL_ID = objComcell.COMCELL_ID
        comcellData.EMP_ID = objComcell.EMP_ID
        comcellData.MONTH = objComcell.MONTH
        comcellData.FACILITATOR = objComcell.FACILITATOR
        comcellData.MINUTES_TAKER = objComcell.MINUTES_TAKER
        comcellData.SCHEDULE = objComcell.SCHEDULE
        comcellData.FY_START = objComcell.FY_START
        comcellData.FY_END = objComcell.FY_END

        Return comcellData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertComcell(ByVal comcell As Comcell) As StateData
        Dim comcellSet As New ComcellSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(comcellSet, comcell)
            If comcellSet.InsertComcellMeeting(comcellSet) Then
                status = NotifyType.IsSuccess
                message = "Create comcell Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetComcell(empID As Integer, year As Integer) As StateData
        Dim comcellSet As New ComcellSet
        Dim lstcomcell As List(Of ComcellSet)
        Dim objComcell As New List(Of Comcell)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstcomcell = comcellSet.GetComcellMeeting(empID, year)

            If Not IsNothing(lstcomcell) Then
                For Each objList As ComcellSet In lstcomcell
                    objComcell.Add(DirectCast(GetMappedFields(objList), Comcell))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objComcell, message)
        Return state
    End Function

    Public Function UpdateComcell(ByVal comcell As Comcell) As StateData
        Dim comcellSet As New ComcellSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(comcellSet, comcell)
            If comcellSet.UpdateComcellMeeting(comcellSet) Then
                status = NotifyType.IsSuccess
                message = "Update comcell Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
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
        Dim objComcell As Comcell = DirectCast(objData, Comcell)
        Dim comcellData As New ComcellSet

        comcellData.COMCELL_ID = objComcell.COMCELL_ID
        comcellData.YEAR = objComcell.YEAR
        comcellData.EMP_ID = objComcell.EMP_ID
        comcellData.MONTH = objComcell.MONTH
        comcellData.FACILITATOR = objComcell.FACILITATOR
        comcellData.MINUTES_TAKER = objComcell.MINUTES_TAKER
        comcellData.FY_START = objComcell.FY_START
        comcellData.FY_END = objComcell.FY_END

        objResult = comcellData
    End Sub
End Class
