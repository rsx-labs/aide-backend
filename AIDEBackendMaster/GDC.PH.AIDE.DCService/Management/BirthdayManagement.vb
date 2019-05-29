Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class BirthdayManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objBirthday As BirthdaySet = DirectCast(objData, BirthdaySet)
        Dim birthdayData As New BirthdayList
        birthdayData.EmpID = objBirthday.EmpID
        birthdayData.BIRTHDAY = objBirthday.BIRTHDAY
        birthdayData.FIRST_NAME = objBirthday.FIRST_NAME
        birthdayData.LAST_NAME = objBirthday.LAST_NAME
        birthdayData.IMAGE_PATH = objBirthday.IMAGE_PATH

        Return birthdayData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function GetBirthdayListAll(email As String) As StateData
        Dim birthdayListSet As New BirthdaySet
        Dim lstBirthday As List(Of BirthdaySet)
        Dim objBirthday As New List(Of BirthdayList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstBirthday = birthdayListSet.GetAllBirthday(email)

            If Not IsNothing(lstBirthday) Then
                For Each objList As BirthdaySet In lstBirthday
                    objBirthday.Add(DirectCast(GetMappedFields(objList), BirthdayList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objBirthday, message)
        Return state
    End Function

    Public Function GetBirthdayListAllByMonth(email As String) As StateData
        Dim birthdayListSet As New BirthdaySet
        Dim lstBirthday As List(Of BirthdaySet)
        Dim objBirthday As New List(Of BirthdayList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstBirthday = birthdayListSet.GetBirthdayByMonth(email)

            If Not IsNothing(lstBirthday) Then
                For Each objList As BirthdaySet In lstBirthday
                    objBirthday.Add(DirectCast(GetMappedFields(objList), BirthdayList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objBirthday, message)
        Return state
    End Function
    Public Function GetBirthdayListAllByDay(email As String) As StateData
        Dim birthdayListSet As New BirthdaySet
        Dim lstBirthday As List(Of BirthdaySet)
        Dim objBirthday As New List(Of BirthdayList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstBirthday = birthdayListSet.GetBirthdayByDay(email)

            If Not IsNothing(lstBirthday) Then
                For Each objList As BirthdaySet In lstBirthday
                    objBirthday.Add(DirectCast(GetMappedFields(objList), BirthdayList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objBirthday, message)
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
        
    End Sub
End Class
