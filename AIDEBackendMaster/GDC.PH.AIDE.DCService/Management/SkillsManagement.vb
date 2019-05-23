Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity

''' <summary>
''' By Jhunell G. Barcenas
''' </summary>
''' <remarks></remarks>
Public Class SkillsManagement
    Inherits ManagementBase

    Public Function InsertNewSkills(ByVal skills As Skills) As StateData
        Dim skillSet As New SkillSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(skillSet, skills)
            If skillSet.InsertSkills(skillSet) Then
                status = NotifyType.IsSuccess
                message = "Insert New Skills Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function UpdateSkills(ByVal skills As Skills) As StateData
        Dim skillSet As New SkillSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(skillSet, skills)
            If skillSet.UpdateSkills(skillSet) Then
                status = NotifyType.IsSuccess
                message = "Update Skills Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetSkillsList() As StateData
        Dim skillSet As New SkillSet
        Dim skillSetList As List(Of SkillSet)
        Dim objSkills As New List(Of Skills)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            skillSetList = skillSet.GetAllSkillList()

            If Not IsNothing(skillSetList) Then
                For Each objList As SkillSet In skillSetList
                    objSkills.Add(DirectCast(GetMappedFields(objList), Skills))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSkills, message)
        Return state
    End Function

    Public Function GetProfLvlByEmpIDSkillID(empID As Integer, skillID As Integer) As StateData
        Dim skillSet As New SkillSet
        Dim objSkill As Skills = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            skillSet = skillSet.GetProfLvlByEmpIDSkillID(empID, skillID)

            If Not IsNothing(skillSet) Then
                objSkill = DirectCast(GetMappedFields(skillSet), Skills)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSkill, message)
        Return state
    End Function

    Public Function GetSkillsByEmpID(id As Integer) As StateData
        Dim skillSet As New SkillSet
        Dim skillSetList As List(Of SkillSet)
        Dim objSkills As New List(Of Skills)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            skillSetList = skillSet.GetSkillsProfByEmpID(id)

            If Not IsNothing(skillSetList) Then
                For Each objList As SkillSet In skillSetList
                    objSkills.Add(DirectCast(GetMappedFields(objList), Skills))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSkills, message)
        Return state
    End Function

    Public Function ViewAllEmpSKills(empID As Integer) As StateData
        Dim skillSet As New SkillSet
        Dim skillSetList As List(Of SkillSet)
        Dim objSkills As New List(Of Skills)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            skillSetList = skillSet.ViewAllEmpSkills(empID)

            If Not IsNothing(skillSetList) Then
                For Each objList As SkillSet In skillSetList
                    objSkills.Add(DirectCast(GetMappedFields(objList), Skills))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSkills, message)
        Return state
    End Function

    Public Function GetSkillsLastReviewByEmpIDSkillID(empID As Integer, skillID As Integer) As StateData
        Dim skillSet As New SkillSet
        Dim objSkill As Skills = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            skillSet = skillSet.GetSkillsLastReviewByEmpIDSkillID(empID, skillID)

            If Not IsNothing(skillSet) Then
                objSkill = DirectCast(GetMappedFields(skillSet), Skills)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSkill, message)
        Return state
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objSkills As SkillSet = DirectCast(objData, SkillSet)
        Dim SkillsData As New Skills

        SkillsData.Image_Path = objSkills.Image_Path
        SkillsData.EmpID = objSkills.EmployeeID
        SkillsData.SkillID = objSkills.SkillID
        SkillsData.Prof_LVL = objSkills.Prof_LVL
        SkillsData.Last_Reviewed = objSkills.LastReviewed
        SkillsData.DESCR = objSkills.SkillsDescr
        SkillsData.NAME = objSkills.Name
        Return SkillsData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objSkill As Skills = DirectCast(objData, Skills)
        Dim skillData As New SkillSet
        skillData.EmployeeID = objSkill.EmpID
        skillData.SkillID = objSkill.SkillID
        skillData.Prof_LVL = objSkill.Prof_LVL
        skillData.LastReviewed = objSkill.Last_Reviewed
        skillData.SkillsDescr = objSkill.DESCR
        skillData.Name = objSkill.NAME
        objResult = skillData
    End Sub

End Class
