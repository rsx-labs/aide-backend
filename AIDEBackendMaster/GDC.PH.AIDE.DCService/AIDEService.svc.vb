' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Imports System.ServiceModel.PeerResolvers

Public Enum Grouping As Short
    Attendance
    CivilStatus
    TaskCategory
    TaskStatus
    Phase
    Rework
End Enum

<ServiceBehavior(ConcurrencyMode:=ConcurrencyMode.Single, InstanceContextMode:=InstanceContextMode.PerCall)>
Public Class AIDEService

    Inherits MainService
    Implements IAideService

    Implements IAideService2


    Private Shared _callbackList As New List(Of IAIDEServiceCallback)()
    '  number of current users - 0 to begin with
    Private Shared _registeredUsers As Integer = 0
    Private Shared _DashboardManagement As DashboardManagement

    Public Sub New()
        _DashboardManagement = New DashboardManagement()
    End Sub

    Protected Overrides Sub OnReceivedResponse(e As ResponseReceivedEventArgs)
        MyBase.OnReceivedResponse(e)
        Dim state As StateData = DirectCast(e.DataReceived, StateData)
        If (state.NotifyType = NotifyType.IsSuccess) Then
            NotifySuccess(state.Message)
        Else
            NotifyError(state.Message)
        End If
    End Sub

    Public Sub NotifyError(ByVal errorMessage As String)
        'Dim registeredUser As IAIDEServiceCallback = OperationContext.Current.GetCallbackChannel(Of IAIDEServiceCallback)()
        'If Not _callbackList.Contains(registeredUser) Then
        '    _callbackList.Add(registeredUser)
        '    _callbackList(_registeredUsers).NotifyError(errorMessage)
        'Else
        '    registeredUser.NotifyError(errorMessage)
        'End If
    End Sub

    Public Sub NotifySuccess(ByVal message As String)
        'Dim registeredUser As IAIDEServiceCallback = OperationContext.Current.GetCallbackChannel(Of IAIDEServiceCallback)()
        'If Not _callbackList.Contains(registeredUser) Then
        '    _callbackList.Add(registeredUser)
        '    _callbackList(_registeredUsers).NotifySuccess(message)
        'Else
        '    registeredUser.NotifySuccess(message)
        'End If
    End Sub

#Region "Attendance Funcions"

    Public Sub UpdateAttendance2(empid As Integer, day As Integer, attstatus As Integer) Implements IAideService.UpdateAttendance2
        MyBase.UpdateAttendanceByEmp(empid, day, attstatus)
    End Sub

    Public Sub InsertLogoffTimes(empid As Integer) Implements IAideService.InsertLogoffTime
        MyBase.InsertLogoffTime(empid)
    End Sub

    Public Sub InsertAttendance(ByVal _Attendance As AttendanceSummary) Implements IAideService.InsertAttendance
        MyBase.InsertAttendanceByEmp(_Attendance)
    End Sub

    Public Function GetMyAttendance(EmpId As Integer, WeekOf As Date) As MyAttendance Implements IAideService.GetMyAttendance
        Dim objAttendance As MyAttendance = Nothing
        MyBase.GetAttendanceEmployee(EmpId, WeekOf, objAttendance)
        Return objAttendance
    End Function

    Public Function GetAttendanceSummary(ByVal Month As Integer, ByVal Year As Integer) As List(Of AttendanceSummary) Implements IAideService.GetAttendanceSummary
        Dim lstAttendance As List(Of AttendanceSummary) = Nothing
        MyBase.GetAttendanceAll(Month, Year, lstAttendance)
        Return lstAttendance
    End Function

    Public Sub UpdateAttendance(ByVal _Attendance As AttendanceSummary) Implements IAideService.UpdateAttendance
        MyBase.UpdateAttendanceByEmp(_Attendance)
    End Sub

    Public Function GetAttendanceTodays(email As String) As List(Of MyAttendance) Implements IAideService.GetAttendanceToday
        Return MyBase.GetAttendanceToday(email)
    End Function

    Public Function GetAttendanceTodayBySearchs(email As String, input As String) As List(Of MyAttendance) Implements IAideService.GetAttendanceTodayBySearch
        Return MyBase.GetAttendanceTodayBySearch(email, input)
    End Function

#End Region

#Region "Billability Functions"
    Public Function GetBillableHoursByWeeks(empID As Integer, weekID As Integer) As List(Of BillableHours) Implements IAideService.GetBillableHoursByWeek
        Return MyBase.GetBillableHoursByWeek(empID, weekID)
    End Function

    Public Function GetBillableHoursByMonths(empID As Integer, month As Integer, year As Integer, weekID As Integer) As List(Of BillableHours) Implements IAideService.GetBillableHoursByMonth
        Return MyBase.GetBillableHoursByMonth(empID, month, year, weekID)
    End Function
#End Region

#Region "Contacts Functions"
    Public Function GetContactInformation(Emp_ID As Integer) As Contact Implements IAideService.GetContactInformation
        Throw New NotImplementedException()
    End Function

    Public Function GetContactList() As List(Of Contact) Implements IAideService.GetContactList
        Throw New NotImplementedException()
    End Function

    Public Sub UpdateContactInformation(contact As Contact) Implements IAideService.UpdateContactInformation
        Throw New NotImplementedException()
    End Sub
#End Region

#Region "Profile Functions"
    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="empId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProfileInformation(empId As Integer) As Profile Implements IAideService.GetProfileInformation
        Dim objProfile As Profile = Nothing
        MyBase.GetProfile(empId, objProfile)
        Return objProfile
    End Function


    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <param name="emailAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SignOn(emailAddress As String) As Profile Implements IAideService.SignOn
        Dim objProfile As Profile = Nothing
        Dim objResult As Object = Nothing
        Dim userName As String = ""
        Try
            Dim registeredUser As IAIDEServiceCallback = OperationContext.Current.GetCallbackChannel(Of IAIDEServiceCallback)()

            If Not _callbackList.Contains(registeredUser) Then
                _callbackList.Add(registeredUser)
            End If



            If MyBase.GetMyProfile(emailAddress, objResult) Then
                objProfile = DirectCast(objResult, Profile)

                'MyBase.UpdateAttendanceByEmp(objProfile.Emp_ID, Date.Now.Day, 0)
                '_callbackList.ForEach(Sub(callback As IAIDEServiceCallback)
                '                          callback.NotifyPresent(objProfile.FirstName & " " & objProfile.LastName)
                '                          _registeredUsers += 1

                '                      End Sub)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return objProfile
    End Function

    ''' <summary>
    ''' GIANN CARLO CAMILO - NOT YET IMPLEMENTED
    ''' </summary>
    ''' <param name="EmployeeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SignOff(EmployeeName As String) As Integer Implements IAideService.SignOff
        Try
            Dim registeredUser As IAIDEServiceCallback = OperationContext.Current.GetCallbackChannel(Of IAIDEServiceCallback)()
            Dim userName As String = ""
            If _callbackList.Contains(registeredUser) Then
                _callbackList.Remove(registeredUser)
                _registeredUsers -= 1
            End If
            _callbackList.ForEach(Sub(callback As IAIDEServiceCallback)
                                      callback.NotifyOffline(EmployeeName)
                                  End Sub)
        Catch ex As Exception
        End Try
        Return _registeredUsers
    End Function
#End Region

#Region "Dashboard Functions"
    Public Function DashboardGetEmployeeList() As List(Of DashboardEmployee) Implements IAideService2.DashboardGetEmployeeList
        Return _DashboardManagement.DashbrdGetEmployeeList()
    End Function

    Public Function DashboardGetContactList() As List(Of DashboardContact) Implements IAideService2.DashboardGetContactList
        Return _DashboardManagement.DashbrdGetContactList()
    End Function

    'Public Function DashboardGetNonBillableHours() As List(Of DashboardNonBillableHours) Implements IAideService2.DashboardGetNonBillableHours
    '    Return _DashboardManagement.DashbrdGetNonBillableHours()
    'End Function

    Public Function DashboardGetNonBillableHoursSummary() As List(Of DashboardNonBillableHoursSummary) Implements IAideService2.DashboardGetNonBillableHoursSummary
        Return _DashboardManagement.DashbrdGetNonBillableSummary()
    End Function

    Public Function DashboardGetTeamAttendance() As List(Of DashboardTeamAttendance) Implements IAideService2.DashboardGetTeamAttendance
        Return _DashboardManagement.DashbrdGetTeamAttendance()
    End Function

    Public Function DashboardGetResourcePlanner() As List(Of AttendanceSummary) Implements IAideService2.DashboardGetResourcePlanner
        Return Nothing
    End Function

    Public Function DashboardGetTaskSummary(dateStart As Date, email As String) As List(Of TaskSummary) Implements IAideService2.DashboardGetTaskSummary
        Return _DashboardManagement.DashbrdGetTaskSummary(dateStart, email)
    End Function

    Public Function DashboardGetTaskSummaryTotals(dateStart As Date, email As String) As List(Of DashboardTaskSummaryTotals) Implements IAideService2.DashboardGetTaskSummaryTotals
        Return _DashboardManagement.DashbrdGetTaskSummaryTotals(dateStart, email)
    End Function
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    ''' <summary>
    ''' By Jester Sanchez
    ''' </summary>
#Region "Action List Functions"

    Public Sub InsertActionList(_Action As Action) Implements IAideService.InsertActionList
        MyBase.InsertActionLst(_Action)
    End Sub

    Public Sub UpdateActionList(_Action As Action) Implements IAideService.UpdateActionList
        MyBase.UpdateActionLst(_Action)
    End Sub

    Public Function GetActionListByMessage(_Message As String, email As String) As List(Of Action) Implements IAideService.GetActionListByMessage
        Dim Actionlist As List(Of Action) = Nothing
        MyBase.GetActionLstByMessage(_Message, email, Actionlist)
        Return Actionlist
    End Function

    Public Function GetActionListByActionNo(actionNo As String, empID As Integer) As List(Of Action) Implements IAideService.GetActionListByActionNo
        Dim actionList As List(Of Action) = Nothing
        Return MyBase.GetActionLstByActionNo(actionNo, empID, actionList)
    End Function

    Public Function GetActionSummary(email As String) As List(Of Action) Implements IAideService.GetActionSummary
        Dim Actionlist As List(Of Action) = Nothing
        MyBase.GetActionSummry(email, Actionlist)
        Return Actionlist
    End Function

    Public Function GetLessonLearntListOfActionSummary(empID As Integer) As List(Of Action) Implements IAideService.GetLessonLearntListOfActionSummary
        Dim lstActionSummary As List(Of Action) = Nothing
        Return MyBase.GetLessonLearntLstOfActionSummary(empID, lstActionSummary)
    End Function

#End Region

    ''' <summary>
    ''' By John Harvey Sanchez
    ''' </summary>
#Region "Lesson Learnt Functions"

    Public Function GetLessonLearntByProblem(search As String, email As String) As List(Of LessonLearnt) Implements IAideService.GetLessonLearntByProblem
        Dim lstLessonLearnt As List(Of LessonLearnt) = Nothing
        MyBase.GetLessonLearntByProblems(search, email, lstLessonLearnt)
        Return lstLessonLearnt
    End Function

    Public Function GetLessonLearntList(email As String) As List(Of LessonLearnt) Implements IAideService.GetLessonLearntList
        Dim lstLessonLearnt As List(Of LessonLearnt) = Nothing
        MyBase.GetAllLessonLearntList(email, lstLessonLearnt)
        Return lstLessonLearnt
    End Function

    Public Sub CreateLessonLearnt(lessonLearnt As LessonLearnt) Implements IAideService.CreateLessonLearnt
        MyBase.CreateNewLessonLearnt(lessonLearnt)
    End Sub

    Public Sub UpdateLessonLearntInfo(lesson As LessonLearnt) Implements IAideService.UpdateLessonLearntInfo
        MyBase.UpdateLessonLearnt(lesson)
    End Sub

#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Success Register Functions"

    Public Function ViewSuccessRegisterAll(email As String) As List(Of SuccessRegister) Implements IAideService.ViewSuccessRegisterAll
        Return MyBase.GetSuccessRegisterAll(email)
    End Function

    Public Function ViewSuccessRegisterByEmpID(email As String) As List(Of SuccessRegister) Implements IAideService.ViewSuccessRegisterByEmpID
        Return MyBase.GetSuccessRegisterByEmpID(email)
    End Function

    Public Function ViewSuccessRegisterBySearch(input As String, email As String) As List(Of SuccessRegister) Implements IAideService.ViewSuccessRegisterBySearch
        Return MyBase.GetSuccessRegisterBySearch(input, email)
    End Function

    Public Sub UpdateSuccessRegisterByEmpID(success As SuccessRegister) Implements IAideService.UpdateSuccessRegisterByEmpID
        MyBase.UpdateSuccessRegister(success)
    End Sub

    Public Sub CreateNewSuccessRegister(success As SuccessRegister) Implements IAideService.CreateNewSuccessRegister
        MyBase.CreateSuccessRegister(success)
    End Sub

    Public Function ViewNicknameByDeptID(email As String, toDisplay As Integer) As List(Of Nickname) Implements IAideService.ViewNicknameByDeptID
        Return MyBase.GetNicknameByDeptID(email, toDisplay)
    End Function

    Public Sub DeleteSuccessRegisterBySuccessID(successId As Integer) Implements IAideService.DeleteSuccessRegisterBySuccessID
        MyBase.DeleteSuccessRegister(successId)
    End Sub

#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Contact List Functions"
    Public Function ViewContactListAll(ByVal empID As Integer, ByVal selection As Integer) As List(Of ContactList) Implements IAideService.ViewContactListAll
        Return MyBase.GetContactListAll(empID, selection)
    End Function

    Public Sub UpdateContactListByEmpID(ByVal contact As ContactList, ByVal selection As Integer) Implements IAideService.UpdateContactListByEmpID
        MyBase.UpdateContactList(contact, selection)
    End Sub

    Public Sub CreateNewContactByEmpID(ByVal contact As ContactList) Implements IAideService.CreateNewContactByEmpID
        MyBase.CreateContact(contact)
    End Sub
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Birthday List Functions"
    Public Function ViewBirthdayListAll(ByVal email As String) As List(Of BirthdayList) Implements IAideService.ViewBirthdayListAll
        Return MyBase.GetBirthdayListAll(email)
    End Function

    Public Function ViewBirthdayListByCurrentMonth(ByVal email As String) As List(Of BirthdayList) Implements IAideService.ViewBirthdayListByCurrentMonth
        Return MyBase.GetBirthdayListByMonth(email)
    End Function

    Public Function ViewBirthdayListByCurrentDay(ByVal email As String) As List(Of BirthdayList) Implements IAideService.ViewBirthdayListByCurrentDay
        Return MyBase.GetBirthdayListByDay(email)
    End Function
#End Region

#Region "Concern"

    ''DISPLAY ALL CONCERN

    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectAllConcernLst(email As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern) Implements IAideService.selectAllConcern
        Return MyBase.selectAllConcern(email, offsetVal, nextVal)
    End Function

    ''INSERT CONCERN

    ''DISPLAY ALL CONCERN
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <param name="email"></param>
    ''' <remarks></remarks>
    Public Sub InsertIntoConcern(concern As Concern, email As String) Implements IAideService.InsertIntoConcern

        MyBase.InsertIntoConcerns(concern, email)
    End Sub

    ''GET GEMERATED REF NO 
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetGeneratedRefNos() As Concern Implements IAideService.GetGeneratedRefNo
        Dim objProfile As Concern = Nothing
        MyBase.GetGeneratedRefNo(objProfile)
        Return objProfile
    End Function

    ''SEARCH
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="SearchKeyWord"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetResultSearchs(email As String, SearchKeyWord As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern) Implements IAideService.GetResultSearch
        Return MyBase.GetResultSearch(email, SearchKeyWord, offsetVal, nextVal)
    End Function


    ''DISPLAY TO COMBO BOX
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetListOfACtions(Ref_id As String, email As String) As List(Of Concern) Implements IAideService.GetListOfACtion
        Return MyBase.GetListOfACtion(Ref_id, email)
    End Function


    ''DISPLAY TO LIST BOX ACTION REFERENCES
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetListOfACtionsReferencesList(Ref_id As String) As List(Of Concern) Implements IAideService.GetListOfACtionsReferences
        Return MyBase.GetListOfACtionsReferences(Ref_id)
    End Function


    ''INSERT SELECTED ACTION
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <remarks></remarks>
    Public Sub InsertAndDeleteSelectedActions(concern As Concern) Implements IAideService.insertAndDeleteSelectedAction

        MyBase.insertAndDeleteSelectedAction(concern)
    End Sub


    ''UPDATE SELECTED CONCERN
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSelectedConcerns(concern As Concern) Implements IAideService.UpdateSelectedConcern

        MyBase.UpdateSelectedConcern(concern)
    End Sub


    ''DISPLAY ALL CONCERN BY BETWEEN DATE
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <param name="date1"></param>
    ''' <param name="date2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetBetweenSearchConcerns(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of Concern) Implements IAideService.GetBetweenSearchConcern
        Return MyBase.GetBetweenSearchConcern(email, offsetVal, nextVal, date1, date2)
    End Function


    ''DISPLAY TO LISTVIEW LIST OF ACION VIA SEARCH
    ''' <summary>
    ''' ''' GIANN CARLO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="_keywordAction"></param>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSearchActions(_keywordAction As String, Ref_id As String, email As String) As List(Of Concern) Implements IAideService.GetSearchAction
        Return MyBase.GetSearchAction(_keywordAction, Ref_id, email)
    End Function

#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Skills"
    Public Overrides Function GetSkillsList(ByVal empID As Integer) As List(Of Skills) Implements IAideService.GetSkillsList
        Return MyBase.GetAllSkillsList(empID)
    End Function

    Public Overrides Function ViewEmpSKills(ByVal empID As Integer) As List(Of Skills) Implements IAideService.ViewEmpSKills
        Return MyBase.ViewAllEmpSkills(empID)
    End Function

    Public Overrides Function GetSkillsProfByEmpID(ByVal id As Integer) As List(Of Skills) Implements IAideService.GetSkillsProfByEmpID
        Return MyBase.GetSkillsProfByEmpID(id)
    End Function

    Public Function GetProfLvlByEmpIDSkillIDs(empID As Integer, skillID As Integer) As Skills Implements IAideService.GetProfLvlByEmpIDSkillIDs
        Dim objSkills As Skills = Nothing
        MyBase.GetProfLvlByEmpIDSkillID(empID, skillID, objSkills)
        Return objSkills
    End Function

    Public Sub InsertNewSkill(skills As Skills) Implements IAideService.InsertNewSkills
        MyBase.InsertNewSkills(skills)
    End Sub

    Public Sub UpdateSkill(skills As Skills) Implements IAideService.UpdateSkills
        MyBase.UpdateSkills(skills)
    End Sub

    Public Sub UpdateAllSkill(skills As Skills) Implements IAideService.UpdateAllSkills
        MyBase.UpdateAllSkills(skills)
    End Sub

    Public Function GetSkillsLastReviewByEmpIDSkillIDs(empID As Integer, skillID As Integer) As Skills Implements IAideService.GetSkillsLastReviewByEmpIDSkillID
        Dim objSkills As Skills = Nothing
        MyBase.GetSkillsLastReviewByEmpIDSkillID(empID, skillID, objSkills)
        Return objSkills
    End Function
#End Region

#Region "Project"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="project"></param>
    ''' <remarks></remarks>
    Public Sub CreateProject(project As Project) Implements IAideService.CreateProject
        MyBase.CreateNewProject(project)
    End Sub
    ''' <summary>
    ''' GIANN CARLO CAMILO/LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="assignProj"></param>
    ''' <remarks></remarks>
    Public Sub CreateAssignedProject(assignProj As List(Of AssignedProject)) Implements IAideService.CreateAssignedProject
        MyBase.CreateNewAssignedProject(assignProj)
    End Sub

    Public Sub AssignProject(Project As AssignedProject) Implements IAideService.AssignProject
        Throw New NotImplementedException()
    End Sub
    Public Sub UpdateProject(project As Project) Implements IAideService.UpdateProject
        MyBase.UpdateAssignedProject(project)
    End Sub

    Public Function GetProjectByID(ByVal projID As Integer) As Project Implements IAideService.GetProjectByID
        Dim objProject As Project = Nothing
        MyBase.GetProjectByProjID(projID, objProject)
        Return objProject
    End Function

    Public Function GetAllListOfProjects(ByVal empID As Integer, ByVal displayStatus As Integer) As List(Of Project) Implements IAideService.GetAllListOfProject
        Return MyBase.GetAllListOfProject(empID, displayStatus)
    End Function


    Public Function ViewProject() As List(Of ViewProject) Implements IAideService.ViewProject
        Dim lstViewProject As List(Of ViewProject) = Nothing
        MyBase.ViewProjectList(lstViewProject)
        Return lstViewProject
    End Function

    ''' <summary>
    ''' DISPLAY LIST PROJECT IN EVERYMONTH - GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetProjectList(ByVal EmpID As Integer, ByVal displayStatus As Integer) As List(Of Project) Implements IAideService.GetProjectList
        Dim lstProject As List(Of Project) = Nothing
        MyBase.GetProjectsList(lstProject, EmpID, displayStatus)
        Return lstProject
    End Function

    ''' <summary>
    ''' VIEW PROJECT  - GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ViewProjectListofEmployees(ByVal EmpID As Integer) As List(Of ViewProject) Implements IAideService.ViewProjectListofEmployee
        Dim lstViewProject As List(Of ViewProject) = Nothing
        MyBase.ViewProjectListofEmployee(EmpID, lstViewProject)
        Return lstViewProject
    End Function


    Public Function GetEmployeePerProjects(empID As Integer, projID As Integer) As List(Of Nickname) Implements IAideService.GetEmployeePerProject
        Return MyBase.GetEmployeePerProject(empID, projID)
    End Function

    Public Sub DeleteAssignedProject(ByVal EmployeeID As Integer, ByVal ProjectID As Integer) Implements IAideService.DeleteAssignedProject
        MyBase.DeleteAssignedProjects(EmployeeID, ProjectID)
    End Sub

    Public Sub DeleteAllAssignedProject(ByVal ProjectID As Integer) Implements IAideService.DeleteAllAssignedProject
        MyBase.DeleteAllAssignedProjects(ProjectID)
    End Sub

    Public Function GetAssignedProjects(projectId As Integer) As List(Of AssignedProject) Implements IAideService.GetAssignedProjects
        Dim lstAssignedProject As List(Of AssignedProject) = Nothing
        MyBase.GetAssignedProjectsByProjID(projectId, lstAssignedProject)
        Return lstAssignedProject
    End Function
#End Region

#Region "EmployeeList"
    ''' <summary>
    ''' GIANN CARLO CAMILO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Function GetEmployeeList() As List(Of Employee) Implements IAideService.GetEmployeeList
        Dim objEmployees As List(Of Employee) = Nothing
        MyBase.GetAllEmployees(objEmployees)
        Return objEmployees
    End Function

    Public Function GetNicknameByDeptIDs(email As String) As List(Of Employee) Implements IAideService.GetNicknameByDeptID
        Dim objEmployees As List(Of Employee) = Nothing
        MyBase.GetNicknameByDeptID(email, objEmployees)
        Return objEmployees
    End Function

#End Region

    ''' <summary>
    ''' By John Harvey Sanchez
    ''' </summary>
#Region "Task"
    Public Sub CreateTask(task As Tasks) Implements IAideService.CreateTask
        MyBase.CreateNewTask(task)
    End Sub

    ' Get this Function
    Public Function ViewTaskSummary(Current_Date As Date, empId As Integer) As List(Of TaskSummary) Implements IAideService.ViewTaskSummary
        Dim lstTaskSummary As List(Of TaskSummary) = Nothing
        MyBase.ViewEmployeeTaskSummry(empId, Current_Date, lstTaskSummary)
        Return lstTaskSummary
    End Function

    ' Get this Function
    Public Function ViewTaskSummaryAll(Current_Date As Date, email As String) As List(Of TaskSummary) Implements IAideService.ViewTaskSummaryAll
        Dim lstTaskSummary As List(Of TaskSummary) = Nothing
        MyBase.ViewTasksSummaryAll(Current_Date, email, lstTaskSummary)
        Return lstTaskSummary
    End Function

    ' Get this Function
    Public Function GetAllTasks() As List(Of Tasks) Implements IAideService.GetAllTasks
        Dim objTasks As List(Of Tasks) = Nothing
        MyBase.GetTasksAll(objTasks)
        Return objTasks
    End Function

    Public Function ViewTasksByEmployee(empId As Integer) As List(Of Tasks) Implements IAideService.ViewTasksByEmployee
        Dim lstTasks As List(Of Tasks) = Nothing
        MyBase.ViewMyTasks(empId, lstTasks)
        Return lstTasks
    End Function

    Public Sub UpdateTask(Task As Tasks) Implements IAideService.UpdateTask
        MyBase.UpdateEmployeeTask(Task)
    End Sub

    Public Overrides Function GetTasksByEmpID(ByVal empID As Integer) As List(Of Tasks) Implements IAideService.GetTasksByEmpID
        Return MyBase.GetTasksByEmpID(empID)
    End Function

#End Region

#Region "Status"
    Public Function GetStatusList(groupId As Integer) As List(Of StatusGroup) Implements IAideService.GetStatusList
        Dim lstStatusGroup As List(Of StatusGroup) = Nothing
        Select Case groupId
            Case Grouping.Attendance
                MyBase.GetAttendanceStatusList(lstStatusGroup)
            Case Grouping.CivilStatus
                MyBase.GetCivilStatusList(lstStatusGroup)
            Case Grouping.TaskCategory
                MyBase.GetTaskCategoriesList(lstStatusGroup)
            Case Grouping.TaskStatus
                MyBase.GetTaskStatusList(lstStatusGroup)
            Case Grouping.Phase
                MyBase.GetPhaseStatusList(lstStatusGroup)
            Case Grouping.Rework
                MyBase.GetReworkStatusList(lstStatusGroup)
            Case Else
                MyBase.GetGenericStatusList(groupId, lstStatusGroup)
        End Select
        Return lstStatusGroup
    End Function
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas / John Harvey Sanchez
    ''' </summary>
#Region "Resource Planner"
    Public Sub InsertResourcePlanners(resource As ResourcePlanner) Implements IAideService.InsertResourcePlanner
        MyBase.InsertResourcePlanner(resource)
    End Sub

    Public Sub UpdateResourcePlanners(resource As ResourcePlanner) Implements IAideService.UpdateResourcePlanner
        MyBase.UpdateResourcePlanner(resource)
    End Sub

    Public Overrides Function ViewEmpResourcePlanner(ByVal email As String) As List(Of ResourcePlanner) Implements IAideService.ViewEmpResourcePlanner
        Return MyBase.ViewEmpResourcePlanners(email)
    End Function

    Public Overrides Function GetStatusResourcePlanner(empID As Integer) As List(Of ResourcePlanner) Implements IAideService.GetStatusResourcePlanner
        Return MyBase.GetStatusResourcePlanners(empID)
    End Function

    Public Function GetResourcePlannerByEmpIDs(empID As Integer, deptID As Integer, month As Integer, year As Integer) As List(Of ResourcePlanner) Implements IAideService.GetResourcePlannerByEmpID
        Return MyBase.GetResourcePlannerByEmpID(empID, deptID, month, year)
    End Function

    Public Function GetAllEmpResourcePlanners(email As String, month As Integer, year As Integer) As List(Of ResourcePlanner) Implements IAideService.GetAllEmpResourcePlanner
        Return MyBase.GetAllEmpResourcePlanner(email, month, year)
    End Function

    Public Function GetAllPerfectAttendances(email As String, month As Integer, year As Integer) As List(Of ResourcePlanner) Implements IAideService.GetAllPerfectAttendance
        Return MyBase.GetAllPerfectAttendance(email, month, year)
    End Function

    Public Function GetAllEmpResourcePlannerByStatuss(email As String, month As Integer, year As Integer, status As Integer) As List(Of ResourcePlanner) Implements IAideService.GetAllEmpResourcePlannerByStatus
        Return MyBase.GetAllEmpResourcePlannerByStatus(email, month, year, status)
    End Function

    Public Overrides Function GetAllStatusResourcePlanner() As List(Of ResourcePlanner) Implements IAideService.GetAllStatusResourcePlanner
        Return MyBase.GetAllStatusResourcePlanners
    End Function

    Public Function GetResourcePlanners(email As String, status As Integer, toBeDisplayed As Integer, year As Integer) As List(Of ResourcePlanner) Implements IAideService.GetResourcePlanner
        Return MyBase.GetResourcePlanner(email, status, toBeDisplayed, year)
    End Function

    Public Overrides Function GetNonBillableHours(email As String, display As Integer, month As Integer, year As Integer) As List(Of ResourcePlanner) Implements IAideService.GetNonBillableHours
        Return MyBase.GetNonBillableHours(email, display, month, year)
    End Function

    Public Overrides Function GetAllLeavesByEmployee(empID As Integer, leaveType As Integer, statusCode As Integer) As List(Of ResourcePlanner) Implements IAideService.GetAllLeavesByEmployee
        Return MyBase.GetAllLeavesByEmployees(empID, leaveType, statusCode)
    End Function

    Public Overrides Function GetAllLeavesHistoryByEmployee(empID As Integer, leaveType As Integer) As List(Of ResourcePlanner) Implements IAideService.GetAllLeavesHistoryByEmployee
        Return MyBase.GetAllLeavesHistoryByEmployees(empID, leaveType)
    End Function
    Public Sub UpdateLeaves1(resource As ResourcePlanner, statusCD As Integer, leaveType As Integer) Implements IAideService.UpdateLeaves
        MyBase.UpdateLeavess(resource, statusCD, leaveType)
    End Sub
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Commendations Functions"
    Public Sub InsertCommendationss(commendations As Commendations) Implements IAideService.InsertCommendations
        MyBase.InsertCommendations(commendations)
    End Sub

    Public Function GetCommendationss(empID As Integer) As List(Of Commendations) Implements IAideService.GetCommendations
        Return MyBase.GetCommendations(empID)
    End Function

    Public Sub UpdateCommendationss(commendations As Commendations) Implements IAideService.UpdateCommendations
        MyBase.UpdateCommendations(commendations)
    End Sub

    Public Function GetCommendationsBySearchs(empID As Integer, month As Integer, year As Integer) As List(Of Commendations) Implements IAideService.GetCommendationsBySearch
        Return MyBase.GetCommendationsBySearch(empID, month, year)
    End Function
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>

#Region "Assets Functions"
    Public Sub InsertAssetss(assets As Assets) Implements IAideService.InsertAssets
        MyBase.InsertAssets(assets)
    End Sub

    Public Function GetAllAssetsByEmpIDs(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsByEmpID
        Return MyBase.GetAllAssetsByEmpID(empID)
    End Function

    Public Function GetAllDeletedAssetsByEmpIDs(empID As Integer) As List(Of Assets) Implements IAideService.GetAllDeletedAssetsByEmpID
        Return MyBase.GetAllDeletedAssetsByEmpID(empID)
    End Function

    Public Function GetMyAssetss(empID As Integer) As List(Of Assets) Implements IAideService.GetMyAssets
        Return MyBase.GetMyAssets(empID)
    End Function

    Public Sub UpdateAssetss(assets As Assets) Implements IAideService.UpdateAssets
        MyBase.UpdateAssets(assets)
    End Sub

    Public Sub DeleteAssets(assets As Assets) Implements IAideService.DeleteAsset
        MyBase.DeleteAsset(assets)
    End Sub

    Public Function GetAllAssetsBySearchs(empID As Integer, input As String) As List(Of Assets) Implements IAideService.GetAllAssetsBySearch
        Return MyBase.GetAllAssetsBySearch(empID, input)
    End Function

    Public Sub InsertAssetsInventorys(assets As Assets) Implements IAideService.InsertAssetsInventory
        MyBase.InsertAssetsInventory(assets)
    End Sub

    Public Sub UpdateAssetsInventorys(assets As Assets) Implements IAideService.UpdateAssetsInventory
        MyBase.UpdateAssetsInventory(assets)
    End Sub

    Public Sub UpdateAssetsInventoryApprovals(assets As Assets) Implements IAideService.UpdateAssetsInventoryApproval
        MyBase.UpdateAssetsInventoryApproval(assets)
    End Sub

    Public Sub UpdateAssetsInventoryCancels(assets As Assets) Implements IAideService.UpdateAssetsInventoryCancel
        MyBase.UpdateAssetsInventoryCancel(assets)
    End Sub

    Public Function GetAllAssetsInventoryByEmpIDs(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsInventoryByEmpID
        Return MyBase.GetAllAssetsInventoryByEmpID(empID)
    End Function

    Public Function GetAllAssetsInventoryUnApproveds(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsInventoryUnApproved
        Return MyBase.GetAllAssetsInventoryUnApproved(empID)
    End Function

    Public Function GetAllAssetsUnAssigneds(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsUnAssigned
        Return MyBase.GetAllAssetsUnAssigned(empID)
    End Function

    Public Function GetAllManagerss(empID As Integer) As List(Of Nickname) Implements IAideService.GetAllManagers
        Return MyBase.GetAllManagers(empID)
    End Function

    Public Function GetAllManagersByDeptorDivs(deptID As Integer, divID As Integer) As List(Of Assets) Implements IAideService.GetAllManagersByDeptorDiv
        Return MyBase.GetAllManagersByDeptorDiv(deptID, divID)
    End Function

    Public Function GetAllAssetsCustodians(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsCustodian
        Return MyBase.GetAllAssetsCustodian(empID)
    End Function

    Public Function GetAllAssetsHistorys(empID As Integer) As List(Of Assets) Implements IAideService.GetAllAssetsHistory
        Return MyBase.GetAllAssetsHistory(empID)
    End Function

    Public Function GetAllAssetsHistoryBySearchs(empID As Integer, input As String) As List(Of Assets) Implements IAideService.GetAllAssetsHistoryBySearch
        Return MyBase.GetAllAssetsHistoryBySearch(empID, input)
    End Function

    Public Function GetAllAssetsInventoryBySearchs(empID As Integer, input As String, page As String) As List(Of Assets) Implements IAideService.GetAllAssetsInventoryBySearch
        Return MyBase.GetAllAssetsInventoryBySearch(empID, input, page)
    End Function

    Public Function GetAssetDescriptions() As List(Of Assets) Implements IAideService.GetAssetDescription
        Return MyBase.GetAssetDescription()
    End Function

    Public Function GetAssetManufacturers() As List(Of Assets) Implements IAideService.GetAssetManufacturer
        Return MyBase.GetAssetManufacturer()
    End Function

#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Announcements Functions"
    Public Sub InsertAnnouncementss(announcements As Announcements) Implements IAideService.InsertAnnouncements
        MyBase.InsertAnnouncements(announcements)
    End Sub

    Public Function GetAnnouncementss(empID As Integer) As List(Of Announcements) Implements IAideService.GetAnnouncements
        Return MyBase.GetAnnouncements(empID)
    End Function
    Public Sub UpdateAnnouncementss(announcements As Announcements) Implements IAideService.UpdateAnnouncements
        MyBase.UpdateAnnouncements(announcements)
    End Sub
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Late Functions"
    Public Function GetLates(empID As Integer, month As Integer, year As Integer, toDisplay As Integer) As List(Of Late) Implements IAideService.GetLate
        Return MyBase.GetLate(empID, month, year, toDisplay)
    End Function
#End Region

#Region "SABA Learning"

    Public Function GetAllSabaCoursess(empID As Integer) As List(Of SabaLearning) Implements IAideService.GetAllSabaCourses
        Return MyBase.GetAllSabaCourses(empID)
    End Function

    Public Function GetAllSabaXrefs(empID As Integer, sabaID As Integer) As List(Of SabaLearning) Implements IAideService.GetAllSabaXref
        Return MyBase.GetAllSabaXref(empID, sabaID)
    End Function

    Public Sub UpdateSabaCoursess(obj As SabaLearning) Implements IAideService.UpdateSabaCourses
        MyBase.UpdateSabaCourses(obj)
    End Sub

    Public Sub InsertSabaCoursess(obj As SabaLearning) Implements IAideService.InsertSabaCourses
        MyBase.InsertSabaCourses(obj)
    End Sub

    Public Sub UpdateSabaXrefs(obj As SabaLearning) Implements IAideService.UpdateSabaXref
        MyBase.UpdateSabaXref(obj)
    End Sub

    Public Function GetAllSabaCourseByTitles(saba_message As String, empID As Integer) As List(Of SabaLearning) Implements IAideService.GetAllSabaCourseByTitle
        Return MyBase.GetAllSabaCourseByTitle(saba_message, empID)
    End Function
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Comcell Functions"
    Public Sub InsertComcellMeetings(comcell As Comcell) Implements IAideService.InsertComcellMeeting
        MyBase.InsertComcellMeeting(comcell)
    End Sub

    Public Function GetComcellMeetings(empID As Integer, year As Integer) As List(Of Comcell) Implements IAideService.GetComcellMeeting
        Return MyBase.GetComcellMeeting(empID, year)
    End Function

    Public Sub UpdateComcellMeetings(comcell As Comcell) Implements IAideService.UpdateComcellMeeting
        MyBase.UpdateComcellMeeting(comcell)
    End Sub

#End Region

#Region "Comcell Clock"
    Public Function GetClockTimeByEmployees(empid As Integer) As ComcellClock Implements IAideService.GetClockTimeByEmployee
        Dim objComcellClock As ComcellClock = Nothing
        MyBase.GetClockTimeByEmployee(empid, objComcellClock)
        Return objComcellClock
    End Function

    Public Sub UpdateComcellClocks(obj As ComcellClock) Implements IAideService.UpdateComcellClock
        MyBase.UpdateComcellClock(obj)
    End Sub
#End Region

    ''' <summary>
    ''' By John Harvey Sanchez
    ''' </summary>
#Region "Weekly Report Functions"
    Public Sub CreateWeeklyReports(weeklyReport As List(Of WeeklyReport), deletedWeeklyReport As List(Of WeeklyReport), weeklyReportXref As WeekRange) Implements IAideService.CreateWeeklyReport
        MyBase.CreateWeeklyReport(weeklyReport, deletedWeeklyReport, weeklyReportXref)
    End Sub

    Public Sub CreateNewWeekRange(weekRange As WeekRange) Implements IAideService.CreateWeekRange
        MyBase.CreateWeekRange(weekRange)
    End Sub

    Public Sub UpdateWeeklyReports(weeklyReport As List(Of WeeklyReport), deletedWeeklyReport As List(Of WeeklyReport), weeklyReportXref As WeekRange) Implements IAideService.UpdateWeeklyReport
        MyBase.UpdateWeeklyReport(weeklyReport, deletedWeeklyReport, weeklyReportXref)
    End Sub

    Public Function GetTheWeekRange(currentDate As Date, weekID As Integer, empID As Integer) As List(Of WeekRange) Implements IAideService.GetWeekRange
        Dim lstWeekRange As List(Of WeekRange) = Nothing
        MyBase.GetWeekRange(currentDate, weekID, empID, lstWeekRange)
        Return lstWeekRange
    End Function

    Public Function GetTheWeekRangeByMonthYear(empID As Integer, month As Integer, year As Integer) As List(Of WeekRange) Implements IAideService.GetWeekRangeByMonthYear
        Dim lstWeekRange As List(Of WeekRange) = Nothing
        MyBase.GetWeekRangeByMonthYear(empID, month, year, lstWeekRange)
        Return lstWeekRange
    End Function

    Public Function GetTheWeeklyReportsByEmpID(empID As Integer, month As Integer, year As Integer) As List(Of WeekRange) Implements IAideService.GetWeeklyReportsByEmpID
        Dim lstWeekRange As List(Of WeekRange) = Nothing
        MyBase.GetWeeklyReportsByEmpID(empID, month, year, lstWeekRange)
        Return lstWeekRange
    End Function

    Public Function GetTheWeeklyTeamStatusReport(empID As Integer, month As Integer, year As Integer, weekID As Integer, entryType As Integer) As List(Of WeeklyTeamStatusReport) Implements IAideService.GetWeeklyTeamStatusReport
        Dim lstWeeklyTeamStatusReport As List(Of WeeklyTeamStatusReport) = Nothing
        MyBase.GetWeeklyTeamStatusReport(empID, month, year, weekID, entryType, lstWeeklyTeamStatusReport)
        Return lstWeeklyTeamStatusReport
    End Function

    Public Function GetTheWeeklyReportsByWeekRangeID(weekRangeID As Integer, currentDate As Date, empID As Integer) As List(Of WeeklyReport) Implements IAideService.GetWeeklyReportsByWeekRangeID
        Dim lstWeeklyReport As List(Of WeeklyReport) = Nothing
        MyBase.GetWeeklyReportsByWeekRangeID(weekRangeID, currentDate, empID, lstWeeklyReport)
        Return lstWeeklyReport
    End Function

    Public Function GetTaskDataByEmpID(weekRangeID As Integer, empID As Integer) As List(Of WeeklyReport) Implements IAideService.GetTasksDataByEmpID
        Dim lstWeeklyReport As List(Of WeeklyReport) = Nothing
        MyBase.GetTasksDataByEmpID(weekRangeID, empID, lstWeeklyReport)
        Return lstWeeklyReport
    End Function

    Public Function GetTheMissingReportsByEmpID(empID As Integer, currentDate As Date) As List(Of ContactList) Implements IAideService.GetMissingReportsByEmpID
        Dim lstMissingReports As List(Of ContactList) = Nothing
        MyBase.GetMissingReportsByEmpID(empID, currentDate, lstMissingReports)
        Return lstMissingReports
    End Function
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "AuditSched Functions"
    Public Function InsertAuditScheds(auditSched As AuditSched) Implements IAideService.InsertAuditSched
        Return MyBase.InsertAuditSched(auditSched)
    End Function

    Public Function GetAuditScheds(empID As Integer, year As Integer) As List(Of AuditSched) Implements IAideService.GetAuditSched
        Return MyBase.GetAuditSched(empID, year)
    End Function

    Public Function UpdateAuditScheds(auditSched As AuditSched) Implements IAideService.UpdateAuditSched
        Return MyBase.UpdateAuditSched(auditSched)
    End Function

#End Region

#Region "Send Email Code"
    Public Function GetWorkEmailByEmails(email As String) As SendCode Implements IAideService.GetWorkEmailbyEmail
        Dim SendCodeItem As SendCode = Nothing
        MyBase.GetWorkEmailbyEmail(email, SendCodeItem)
        Return SendCodeItem
    End Function
#End Region

#Region "Mail Config"
    Public Function GetMailConfigs() As MailConfig Implements IAideService.GetMailConfig
        Dim MailConfigItem As MailConfig = Nothing
        MyBase.GetMailConfig(MailConfigItem)
        Return MailConfigItem
    End Function
#End Region

    ''' <summary>
    ''' By Jhunell Barcenas
    ''' </summary>
#Region "Workplace Audit Functions"
    Public Sub InsertAuditDailys(auditSched As WorkplaceAudit) Implements IAideService.InsertAuditDaily
        MyBase.InsertAuditDaily(auditSched)
    End Sub

    Public Function GetAuditDailys(empID As Integer, parmDate As Date) As List(Of WorkplaceAudit) Implements IAideService.GetAuditDaily
        Return MyBase.GetAuditDaily(empID, parmDate)
    End Function

    Public Function GetAuditQuestionss(empID As Integer, questionGroup As String) As List(Of WorkplaceAudit) Implements IAideService.GetAuditQuestions
        Return MyBase.GetAuditQuestions(empID, questionGroup)
    End Function

    Public Function GetAuditSChed_Month(audit_grp As Integer, yr As Integer, month As Integer) As List(Of WorkplaceAudit) Implements IAideService.GetAuditSChed_Month
        Return MyBase.GetAuditSched_Month(audit_grp, yr, month)
    End Function

    Public Function GetDailyAuditorByWeek(empID As Integer, paramFYWeek As String, paramDate As Date) As List(Of WorkplaceAudit) Implements IAideService.GetDailyAuditorByWeek
        Return MyBase.GetDailyAuditorByWeek(empID, paramFYWeek, paramDate)
    End Function

    Public Function GetWeeklyAuditor(empID As Integer, paramDate As DateTime) As List(Of WorkplaceAudit) Implements IAideService.GetWeeklyAuditor
        Return MyBase.GetWeeklyAuditor(empID, paramDate)
    End Function
    Public Function GetMonthlyAuditor(empID As Integer, paramDate As Integer) As List(Of WorkplaceAudit) Implements IAideService.GetMonthlyAuditor
        Return MyBase.GetMonthlyAuditor(empID, paramDate)
    End Function

    Public Function GetQuarterlyAuditor(empID As Integer, paramDate As Integer) As List(Of WorkplaceAudit) Implements IAideService.GetQuarterlyAuditor
        Return MyBase.GetQuarterlyAuditor(empID, paramDate)
    End Function

    Public Function UpdateCheckAuditQuestionStatus(auditSched As WorkplaceAudit) As Boolean Implements IAideService.UpdateCheckAuditQuestionStatus
        Return MyBase.UpdateCheckAuditQuestionStatus(auditSched)
    End Function
#End Region

#Region "Contributors Functions"
    Public Function GetAllContributorss(level As Integer) As List(Of Contributors) Implements IAideService.GetAllContributors
        Return MyBase.GetAllContributors(level)
    End Function
#End Region

#Region "Message Functions"
    Public Function GetMessage(msgID As Integer, secID As Integer) As List(Of MessageDetail) Implements IAideService.GetMessage
        Return MyBase.GetAllMessage(msgID, secID)
    End Function
#End Region

#Region "Selection Function"
    Public Function GetAllDepartments() As List(Of DepartmentList) Implements IAideService.GetAllDepartment
        Return MyBase.GetAllDepartment()
    End Function

    Public Function GetAllDivisions(ByVal DeptID As Integer) As List(Of DivisionList) Implements IAideService.GetAllDivision
        Return MyBase.GetAllDivision(DeptID)
    End Function

    Public Function GetAllPermissions() As List(Of PermissionList) Implements IAideService.GetAllPermission
        Return MyBase.GetAllPermission()
    End Function

    Public Function GetAllPositions() As List(Of PositionList) Implements IAideService.GetAllPosition
        Return MyBase.GetAllPosition()
    End Function

    Public Function GetAllStatuss(statusName As String) As List(Of StatusList) Implements IAideService.GetAllStatus
        Return MyBase.GetAllStatus(statusName)
    End Function

    Public Function GetAllLocations() As List(Of LocationList) Implements IAideService.GetAllLocation
        Return MyBase.GetAllLocation()
    End Function

    Public Function GetAllFiscalYears() As List(Of FiscalYear) Implements IAideService.GetAllFiscalYear
        Return MyBase.GetAllFiscalYear()
    End Function

#End Region

#Region "KPI Targets"

    Public Function InsertKPITarget(kpiTarget As KPITargets) As Boolean Implements IAideService.InsertKPITarget
        Return MyBase.InsetKPITarget(kpiTarget)
    End Function

    Public Function UpdatePITarget(kpiTarget As KPITargets) As Boolean Implements IAideService.UpdatePITarget
        Return MyBase.UpdateKPITarget(kpiTarget)
    End Function

    Public Function GetKPITargets(Id As Integer) As List(Of KPITargets) Implements IAideService.GetKPITargets
        Return MyBase.GetKPITarget(Id)
    End Function

    Public Function GetAllKPITarget(ByVal EmpId As Integer, FiscalYear As Date) As List(Of KPITargets) Implements IAideService.GetAllKPITargets
        Return MyBase.GetAllKPITargets(EmpId, FiscalYear)
    End Function

    Public Function InsertKPISummary(kpi As KPISummary) As Boolean Implements IAideService.InsertKPISummary
        Return MyBase.InsertNewKPISummary(kpi)
    End Function

    Public Function UpdateKPISummary(kpi As KPISummary) As Boolean Implements IAideService.UpdateKPISummary
        Return MyBase.UpdateSelectedKPISummary(kpi)
    End Function

    Public Function GetKPISummaryList(ByVal EmpId As Integer, FY_Start As Date, FY_End As Date) As List(Of KPISummary) Implements IAideService.GetKPISummaryList
        Return MyBase.GetAllKPISummary(EmpId, FY_Start, FY_End)
    End Function

    Public Function GetKPISummaryListMonthly(ByVal EmpId As Integer, FY_Start As Date, FY_End As Date, Month As Short, KPIRef As String) As List(Of KPISummary) Implements IAideService.GetKPISummaryListMonthly
        Return MyBase.GetKPISummaryMonthly(EmpId, FY_Start, FY_End, Month, KPIRef)
    End Function

#End Region

#Region "Leave Credits"
    Public Sub InsertLeaveCredit(empID As Integer, year As Integer) Implements IAideService.InsertLeaveCredits
        MyBase.InsertLeaveCredits(empID, year)
    End Sub
#End Region


End Class
