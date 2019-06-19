Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class AnnouncementsManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objAnnouncements As AnnouncementsSet = DirectCast(objData, AnnouncementsSet)
        Dim announcementsData As New Announcements
        announcementsData.ANNOUNCEMENT_ID = objAnnouncements.ANNOUNCEMENT_ID
        announcementsData.EMP_ID = objAnnouncements.EMP_ID
        announcementsData.MESSAGE = objAnnouncements.MESSAGE
        announcementsData.TITLE = objAnnouncements.TITLE
        announcementsData.END_DATE = objAnnouncements.END_DATE


        Return announcementsData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function InsertAnnouncements(ByVal Announcements As Announcements) As StateData
        Dim AnnouncementsSet As New AnnouncementsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(AnnouncementsSet, Announcements)
            If AnnouncementsSet.InsertAnnouncements(AnnouncementsSet) Then
                status = NotifyType.IsSuccess
                message = "Create Announcements Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateAnnouncements(ByVal Announcements As Announcements) As StateData
        Dim AnnouncementsSet As New AnnouncementsSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(AnnouncementsSet, Announcements)
            If AnnouncementsSet.UpdateAnnouncements(AnnouncementsSet) Then
                status = NotifyType.IsSuccess
                message = "Update Announcements Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAnnouncements(empID As Integer) As StateData
        Dim AnnouncementsSet As New AnnouncementsSet
        Dim lstAnnouncements As List(Of AnnouncementsSet)
        Dim objAnnouncements As New List(Of Announcements)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstAnnouncements = AnnouncementsSet.GetAnnouncements(empID)

            If Not IsNothing(lstAnnouncements) Then
                For Each objList As AnnouncementsSet In lstAnnouncements
                    objAnnouncements.Add(DirectCast(GetMappedFields(objList), Announcements))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAnnouncements, message)
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
        Dim objAnnouncements As Announcements = DirectCast(objData, Announcements)
        Dim announcementsData As New AnnouncementsSet
        announcementsData.ANNOUNCEMENT_ID = objAnnouncements.ANNOUNCEMENT_ID
        announcementsData.EMP_ID = objAnnouncements.EMP_ID
        announcementsData.MESSAGE = objAnnouncements.MESSAGE
        announcementsData.TITLE = objAnnouncements.TITLE
        announcementsData.END_DATE = objAnnouncements.END_DATE

        objResult = announcementsData
    End Sub
End Class
