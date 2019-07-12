Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Public Class ContributorsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objContributors As ContributorsSet = DirectCast(objData, ContributorsSet)
        Dim contributorsData As New Contributors
        contributorsData.FULL_NAME = objContributors.FULL_NAME
        contributorsData.DEPARTMENT = objContributors.DEPARTMENT
        contributorsData.DIVISION = objContributors.DIVISIOn
        contributorsData.POSITION = objContributors.POSITION
        contributorsData.IMAGE_PATH = objContributors.IMAGE_PATH

        Return contributorsData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function


    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objContributors As Contributors = DirectCast(objData, Contributors)
        Dim contributorsData As New ContributorsSet
        contributorsData.FULL_NAME = objContributors.FULL_NAME
        contributorsData.DEPARTMENT = objContributors.DEPARTMENT
        contributorsData.DIVISIOn = objContributors.DIVISION
        contributorsData.POSITION = objContributors.POSITION
        contributorsData.IMAGE_PATH = objContributors.IMAGE_PATH

        objResult = contributorsData
    End Sub



    Public Function GetAllContributors(level As Integer) As StateData
        Dim ContributorsSets As New ContributorsSet
        Dim lstContributorsSet As List(Of ContributorsSet)
        Dim objContributors As New List(Of Contributors)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstContributorsSet = ContributorsSets.GetAllContributors(level)

            If Not IsNothing(lstContributorsSet) Then
                For Each objList As ContributorsSet In lstContributorsSet
                    objContributors.Add(DirectCast(GetMappedFields(objList), Contributors))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objContributors, message)
        Return state
    End Function
End Class
