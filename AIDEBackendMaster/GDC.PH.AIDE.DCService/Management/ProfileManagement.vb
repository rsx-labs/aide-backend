Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
''' <summary>
''' BY GIANN CARLO CAMILO
''' </summary>
''' <remarks></remarks>
Public Class ProfileManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objProfile As ProfileSet = DirectCast(objData, ProfileSet)
        Dim profileData As New Profile
        profileData.Emp_ID = objProfile.EmployeeID
        profileData.Ws_EMP_ID = objProfile.WsEpID
        profileData.Dept_ID = objProfile.DeptID
        profileData.LastName = objProfile.LastName
        profileData.MiddleName = objProfile.MiddleName
        profileData.Nickname = objProfile.NickName
        profileData.FirstName = objProfile.FirstName
        profileData.Birthdate = objProfile.BirthDate
        profileData.DateHired = objProfile.DateHired
        profileData.ImagePath = objProfile.ImagePath
        profileData.Department = objProfile.Department
        profileData.Division = objProfile.Division
        profileData.Position = objProfile.Position
        profileData.Email_Address = objProfile.EmailAddress
        profileData.Email_Address2 = objProfile.EmailAddress2
        profileData.Location = objProfile.Location
        profileData.Cel_No = objProfile.CelNo
        profileData.Local = objProfile.Local
        profileData.Home_Phone = objProfile.HomePhone
        profileData.Other_Phone = objProfile.OtherPhone
        profileData.Dt_Reviewed = objProfile.DtReviewed
        profileData.Permission = objProfile.Permission
        profileData.Permission_ID = objProfile.Permission_ID
        profileData.CivilStatus = objProfile.CivilStatus
        profileData.ShiftStatus = objProfile.ShiftStatus

        Return profileData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function GetProfile(emp_id As Integer) As StateData
        Dim profileSet As New ProfileSet
        Dim objprofile As Profile = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            profileSet = profileSet.GetProfile(emp_id)

            If Not IsNothing(profileSet) Then
                objprofile = DirectCast(GetMappedFields(profileSet), Profile)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objprofile, message)
        Return state
    End Function

    Public Function GetProfileByEmailAddress(emailAddress As String) As StateData
        Dim profileSet As New ProfileSet
        Dim objprofile As Profile = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try

            profileSet = profileSet.GetProfileByEmailAddress(emailAddress)

            If Not IsNothing(profileSet) Then
                objprofile = DirectCast(GetMappedFields(profileSet), Profile)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try

        state = GetStateData(status, objprofile, message)
        Return state
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional ByVal data As Object = Nothing, Optional ByVal message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    'Public Function UpdateProfile(ByVal profile As Profile) As StateData
    '    Dim profileSet As New ProfileSet
    '    Dim message As String = ""
    '    Dim state As StateData
    '    Dim status As NotifyType
    '    Try
    '        SetFields(profileSet, profile)
    '        If profileSet.UpdateProfile() Then
    '            status = NotifyType.IsSuccess
    '            message = "Update profile successful!"
    '        End If

    '    Catch ex As Exception
    '        status = NotifyType.IsError
    '    End Try
    '    state = GetStateData(status, Nothing, message)
    '    Return state
    'End Function

     Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objProfile As Profile = DirectCast(objData, Profile)
        Dim profileData As New ProfileSet
        profileData.EmployeeID = objProfile.Emp_ID
        profileData.WsEpID = objProfile.Ws_EMP_ID
        profileData.DeptID = objProfile.Dept_ID
        profileData.LastName = objProfile.LastName
        profileData.MiddleName = objProfile.MiddleName
        profileData.NickName = objProfile.Nickname
        profileData.FirstName = objProfile.FirstName
        profileData.BirthDate = objProfile.Birthdate
        profileData.DateHired = objProfile.DateHired
        profileData.ImagePath = objProfile.ImagePath
        profileData.Department = objProfile.Department
        profileData.Division = objProfile.Division
        profileData.Position = objProfile.Position
        profileData.EmailAddress = objProfile.Email_Address
        profileData.EmailAddress2 = objProfile.Email_Address2
        profileData.Location = objProfile.Location
        profileData.CelNo = objProfile.Cel_No
        profileData.Local = objProfile.Local
        profileData.HomePhone = objProfile.Home_Phone
        profileData.OtherPhone = objProfile.Other_Phone
        profileData.DtReviewed = objProfile.Dt_Reviewed
        profileData.Permission = objProfile.Permission
        profileData.Permission_ID = objProfile.Permission_ID
        profileData.CivilStatus = objProfile.CivilStatus
        profileData.ShiftStatus = objProfile.ShiftStatus

        objResult = profileData
    End Sub
End Class
