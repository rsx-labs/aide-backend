
Imports GDC.PH.AIDE.BusinessLayer
Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
''' <summary>
''' BY HYACINTH ARMARLES AND GIANN CARLO CAMILO
''' </summary>
''' <remarks></remarks>
Public Class ProjectManagement
    Inherits ManagementBase


    ''' <summary>
    ''' HYACINCTH AMARLES
    ''' </summary>
    ''' <param name="objProject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateNewProject(ByVal objProject As Project) As StateData
        Dim projSet As New ProjectSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            Me.InsertNewProject(objProject)
            'For Each _assigned As AssignedProject In lstAssigned
            '    Me.InsertAssignedProject(_assigned)
            'Next
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function
    ''' <summary>
    ''' HYACINCTH AMARLES
    ''' </summary>
    ''' <param name="objProject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertNewProject(ByVal objProject As Project) As StateData
        Dim projSet As New ProjectSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(projSet, objProject)
            If projSet.InsertNewProject() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function
    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="objProject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertAssignedProject(ByVal objProject As AssignedProject) As StateData
        Dim projSet As New AssignedProjectSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetAssignedFields(projSet, objProject) 'ERROR: Unable to cast object of type 'GDC.WeServ.EPAD.DCService.AssignedProject' to type 'GDC.WeServ.EPAD.DCService.Project'.
            If projSet.InsertAssignedProj() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

   Public Function UpdateProject(ByVal objProject As Project) As StateData
        Dim projSet As New ProjectSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(projSet, objProject)
            If projSet.UpdateProject() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    ''' <summary>
    ''' VIEW PROJECT WITH EMPLOYEES ---- GIANN CARLO CAMILO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ViewProject() As StateData
        Dim projSet As New ProjectSet
        Dim lstProject As List(Of ProjectSet)
        Dim objProjects As New List(Of ViewProject)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try

            lstProject = projSet.ViewProject()

            If Not IsNothing(lstProject) Then
                For Each objProject As ProjectSet In lstProject
                    objProjects.Add(DirectCast(GetMappedFields(objProject), ViewProject))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProjects, message)
        Return state
    End Function

    ' Get this Function
    Public Function GetProjectLists(ByVal EmpID As Integer, ByVal displayStatus As Integer)
        Dim projectSet As New ProjectSet
        Dim lstProject As List(Of ProjectSet)
        Dim objProject As New List(Of Project)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProject = projectSet.GetProjectLists(EmpID, displayStatus)

            If Not IsNothing(lstProject) Then
                For Each objList As ProjectSet In lstProject
                    objProject.Add(DirectCast(GetMappedFields(objList), Project))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProject, message)
        Return state
    End Function

    Public Function GetProjectByID(ByVal ProjId As Integer) As StateData
        Dim projectset As New ProjectSet
        Dim objprofile As Project = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            projectset = projectset.GetProjectByID(ProjId)
            If Not IsNothing(projectset) Then
                objprofile = DirectCast(GetMappedFields(projectset), Project)
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objprofile, message)
        Return state
    End Function
    Public Function GetAssignedProjects(ByVal ProjId As Integer) As StateData
        Dim projectSet As New AssignedProjectSet
        Dim lstProjectset As New List(Of AssignedProjectSet)
        Dim objAssignedProject As New List(Of AssignedProject)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            lstProjectset = projectSet.GetAssignedProjects(ProjId)
            If Not IsNothing(lstProjectset) Then
                For Each objList As AssignedProjectSet In lstProjectset
                    objAssignedProject.Add(DirectCast(GetMappedFields3(objList), AssignedProject))
                Next
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objAssignedProject, message)
        Return state
    End Function

    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="lstAssigned"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateNewAssignedProject(ByVal lstAssigned As List(Of AssignedProject)) As StateData
        Dim projSet As New ProjectSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try

            For Each _assigned As AssignedProject In lstAssigned
                Me.InsertAssignedProject(_assigned)
            Next
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function DeleteAssignedProject(ByVal empID As Integer, ByVal projID As Integer) As StateData

        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            Dim projSet As New AssignedProjectSet
            If projSet.DeleteAssignedProj(empID, projID) Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function DeleteAllAssignedProject(ByVal projID As Integer) As StateData

        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try

            Dim projSet As New AssignedProjectSet
            If projSet.DeleteAllAssignedProj(projID) Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    ''' <summary>
    ''' VIEW PROJECT WITH EMPLOYEES - GIANN CARLO CAMILO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ViewProjectListofEmployee(ByVal empID As Integer) As StateData
        Dim projSet As New ProjectSet
        Dim lstProject As List(Of ProjectSet)
        Dim objProjects As New List(Of ViewProject)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try

            lstProject = projSet.ViewProjectListofEmployee(empID)

            If Not IsNothing(lstProject) Then
                For Each objProject As ProjectSet In lstProject
                    objProjects.Add(DirectCast(GetMappedFieldsProject(objProject), ViewProject))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProjects, message)
        Return state
    End Function


    'For the list of Employee Per Porject for the combobox
    Public Function GetEmployeePerProject(empID As Integer, projID As Integer) As StateData
        Dim nicknameSet As New NicknameSet
        Dim lstNickname As List(Of NicknameSet)
        Dim objNickname As New List(Of Nickname)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstNickname = nicknameSet.GetEmployeePerProject(empID, projID)

            If Not IsNothing(lstNickname) Then
                For Each objNicknameList As NicknameSet In lstNickname
                    objNickname.Add(DirectCast(GetMappedFieldsForNickname(objNicknameList), Nickname))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objNickname, message)
        Return state
    End Function

    Public Function GetMappedFieldsForNickname(ByVal objData As Object) As Object
        Dim objNickname As NicknameSet = DirectCast(objData, NicknameSet)
        Dim nicknamedata As New Nickname
        nicknamedata.Emp_ID = objNickname.EmpID
        nicknamedata.Nick_Name = objNickname.Nick_Name

        Return nicknamedata
    End Function


    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objProject As ProjectSet = DirectCast(objData, ProjectSet)
        Dim viewProjectData As New ViewProject
        Dim projectData As New Project

        projectData.ProjectID = objProject.ProjectId
        projectData.ProjectCode = objProject.ProjectCode
        projectData.ProjectName = objProject.ProjectName
        projectData.Category = objProject.Category
        projectData.Billability = objProject.Billability

        viewProjectData.Status = objProject.Status
        viewProjectData.Name = objProject.Name
        viewProjectData.Month1 = objProject.FirstMonth
        viewProjectData.Month2 = objProject.SecondMonth
        viewProjectData.Month3 = objProject.ThirdMonth

        If Not IsNothing(viewProjectData) Then
            Return projectData
        Else
            Return viewProjectData
        End If

    End Function

    Public Function GetMappedFields3(objData As Object) As Object
        Dim objAssignedProj As AssignedProjectSet = DirectCast(objData, AssignedProjectSet)
        Dim assignedProjectData As New AssignedProject

        assignedProjectData.ProjectID = objAssignedProj.ProjectId
        assignedProjectData.EmployeeID = objAssignedProj.EmpId
        assignedProjectData.StartPeriod = objAssignedProj.StartPeriod
        assignedProjectData.EndPeriod = objAssignedProj.EndPeriod

        Return assignedProjectData
    End Function
    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="objData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMappedFieldsProject(objData As Object) As Object
        Dim objProject As ProjectSet = DirectCast(objData, ProjectSet)
        Dim viewProjectData As New ViewProject

        viewProjectData.Status = objProject.Status
        viewProjectData.Name = objProject.Name
        viewProjectData.Month1 = objProject.FirstMonth
        viewProjectData.Month2 = objProject.SecondMonth
        viewProjectData.Month3 = objProject.ThirdMonth
        Return viewProjectData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objProject As Project = DirectCast(objData, Project)
        Dim projectData As New ProjectSet
        projectData.EmpID = objProject.EmpID
        projectData.ProjectId = objProject.ProjectID
        projectData.ProjectCode = objProject.ProjectCode
        projectData.ProjectName = objProject.ProjectName
        projectData.Billability = objProject.Billability
        projectData.Category = objProject.Category
        objResult = projectData
    End Sub
    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <param name="objData"></param>
    ''' <remarks></remarks>
    Public Sub SetAssignedFields(ByRef objResult As Object, objData As Object)
        Dim objProject As AssignedProject = DirectCast(objData, AssignedProject)
        Dim projectData As New AssignedProjectSet
        projectData.ProjectId = objProject.ProjectID
        projectData.EmpId = objProject.EmployeeID
        projectData.DateCreated = objProject.DateCreated
        projectData.StartPeriod = objProject.StartPeriod
        projectData.EndPeriod = objProject.EndPeriod
        objResult = projectData
    End Sub
End Class
