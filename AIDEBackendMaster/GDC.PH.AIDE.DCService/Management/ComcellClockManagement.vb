Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Public Class ComcellClockManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objComcellClock As ComcellClock = DirectCast(objData, ComcellClock)
        Dim ClockData As New ComcellClockSet
        ClockData.ClockDay = objComcellClock.Clock_Day
        ClockData.ClockHour = objComcellClock.Clock_Hour
        ClockData.ClockMinute = objComcellClock.Clock_Minute
        ClockData.EmpID = objComcellClock.Emp_ID
        objResult = ClockData
    End Sub

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objComcellClock As ComcellClockSet = DirectCast(objData, ComcellClockSet)
        Dim ClockData As New ComcellClock
        ClockData.Clock_Day = objComcellClock.ClockDay
        ClockData.Clock_Hour = objComcellClock.ClockHour
        ClockData.Clock_Minute = objComcellClock.ClockMinute
        ClockData.Emp_ID = objComcellClock.EmpID

        Return ClockData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Function GetClockTime(ByVal empId As Integer) As StateData
        Dim ClockSet As New ComcellClockSet
        Dim ClockData As ComcellClock = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try

            Dim objClockSet As ComcellClockSet = ClockSet.GetSelectClockByEmpID(empId)

            If Not IsNothing(objClockSet) Then
                ClockData = DirectCast(GetMappedFields(objClockSet), ComcellClock)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, ClockData, message)
        Return state
    End Function

    Public Function UpdateClockTime(ByVal ClockData As ComcellClock) As StateData
        Dim clockSet As New ComcellClockSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(clockSet, ClockData)
            If clockSet.UpdateClockTime() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

End Class
