
#Region "Operation Contracts"
<ServiceContract(SessionMode:=SessionMode.Required, CallbackContract:=GetType(IAIDEServiceCallback))>
Public Interface IAideService

    ''' <summary>
    ''' By Lemuela Abulencia
    ''' </summary>
    ''' <remarks></remarks>
#Region "Action Operation Contracts"

    <OperationContract(IsOneWay:=True)>
    Sub InsertActionList(ByVal _Action As Action)

    <OperationContract()>
    Function GetActionListByMessage(ByVal _Message As String, ByVal email As String) As List(Of Action)

    <OperationContract()>
    Function GetActionSummary(ByVal email As String) As List(Of Action)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateActionList(ByVal _Action As Action)

#End Region

#Region "Attendance Operation Contracts"
    <OperationContract()>
    Function GetMyAttendance(ByVal EmpId As Integer, ByVal WeekOf As Date) As MyAttendance

    <OperationContract()>
    Function GetAttendanceSummary(ByVal Month As Integer, ByVal Year As Integer) As List(Of AttendanceSummary)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAttendance(ByVal _Attendance As AttendanceSummary)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAttendance2(ByVal empid As Integer, ByVal day As Integer, attstatus As Integer)

    <OperationContract(IsOneWay:=True)>
    Sub InsertAttendance(ByVal _Attendance As AttendanceSummary)

    <OperationContract()>
    Function GetAttendanceToday(ByVal email As String) As List(Of MyAttendance)

    <OperationContract()>
    Function GetAttendanceTodayBySearch(ByVal email As String, ByVal input As String) As List(Of MyAttendance)

#End Region

#Region "NonBillability Hours Operation Contracts"
    <OperationContract()>
    Function GetNonBillabilityHoursByEmpID(ByVal EmpID As Integer, ByVal userChoice As Short) As NonBillableHours
    <OperationContract()>
    Function GetNonBillabilityHoursAll(ByVal userChoice As Short) As List(Of NonBillableHours)
    <OperationContract()>
    Function GetNonBillabilityHoursSummary(ByVal dateInput As Date) As List(Of NonBillableSummary)
#End Region

#Region "Contacts Operation Contracts"
    <OperationContract()>
    Function GetContactInformation(ByVal Emp_ID As Integer) As Contact

    <OperationContract()>
    Function GetContactList() As List(Of Contact)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateContactInformation(ByVal contact As Contact)
#End Region

#Region "Employee Operation Contracts"
    ''' <summary>
    ''' GIANN CARLO CAMILO 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    <OperationContract()>
    Function GetEmployeeList() As List(Of Employee)

    <OperationContract()>
    Function GetNicknameByDeptID(ByVal email As String) As List(Of Employee)

#End Region

#Region "Profile Operation Contracts"
    <OperationContract()>
    Function GetProfileInformation(ByVal empId As Integer) As Profile

    '<OperationContract(IsOneWay:=True)>
    'Sub UpdateProfileInformation(ByVal profile As Profile)
#End Region

#Region "Project Operation Contracts"
    ''' <summary>
    ''' GIANN CARLO CAMILO/
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetAllListOfProject(ByVal empID As Integer) As List(Of Project)

    <OperationContract()>
    Function GetProjectList(ByVal empID As Integer) As List(Of Project)

    <OperationContract(IsOneWay:=True)>
    Sub CreateProject(ByVal project As Project)

    <OperationContract(IsOneWay:=True)>
    Sub AssignProject(ByVal Project As AssignedProject)

    <OperationContract>
    Function GetProjectByID(ByVal projID As Integer) As Project
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function ViewProject() As List(Of ViewProject)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateProject(ByVal project As Project)
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="assignProj"></param>
    ''' <remarks></remarks>
    <OperationContract(IsOneWay:=True)>
    Sub CreateAssignedProject(ByVal assignProj As List(Of AssignedProject))
    ''' <summary>
    ''' GIANN CARLO CAMILO / LEMUELA ABULENCIA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function ViewProjectListofEmployee(ByVal empID As Integer) As List(Of ViewProject)

    'For the list of employee per project displayed in Combobox
    <OperationContract()>
    Function GetEmployeePerProject(ByVal empID As Integer, ByVal projID As Integer) As List(Of Nickname)
#End Region

#Region "Status Operation Contracts"
    <OperationContract()>
    Function GetStatusList(ByVal groupId As Integer) As List(Of StatusGroup)
#End Region

#Region "Tasks Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub CreateTask(ByVal task As Tasks)

    <OperationContract()>
    Function ViewTasksByEmployee(ByVal empId As Integer) As List(Of Tasks)

    <OperationContract()>
    Function ViewTaskSummary(ByVal Current_Date As Date, ByVal empId As Integer) As List(Of TaskSummary)

    <OperationContract()>
    Function ViewTaskSummaryAll(ByVal Current_Date As Date, ByVal email As String) As List(Of TaskSummary)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateTask(ByVal Task As Tasks)

    <OperationContract()>
    Function GetAllTasks() As List(Of Tasks)

    <OperationContract()>
    Function GetTaskDetailByIncidentId(ByVal id As Integer) As List(Of Tasks)

#End Region

#Region "Commendations Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertCommendations(ByVal task As Commendations)

    <OperationContract()>
    Function GetCommendations(ByVal deptID As Integer) As List(Of Commendations)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateCommendations(ByVal task As Commendations)

    <OperationContract()>
    Function GetCommendationsBySearch(ByVal empID As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of Commendations)
#End Region

#Region "Assets Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertAssets(ByVal assets As Assets)

    <OperationContract()>
    Function GetAllAssetsByEmpID(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetMyAssets(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetAllAssetsBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAssets(ByVal assets As Assets)

    <OperationContract(IsOneWay:=True)>
    Sub InsertAssetsInventory(ByVal assets As Assets)

    <OperationContract()>
    Function GetAllAssetsInventoryByEmpID(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetAllAssetsInventoryUnApproved(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetAllAssetsUnAssigned(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetAllManagers(ByVal empID As Integer) As List(Of Nickname)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAssetsInventory(ByVal assets As Assets)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAssetsInventoryApproval(ByVal assets As Assets)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAssetsInventoryCancel(ByVal assets As Assets)

    <OperationContract()>
    Function GetAllAssetsHistory(ByVal empID As Integer) As List(Of Assets)

    <OperationContract()>
    Function GetAllAssetsHistoryBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)

    <OperationContract()>
    Function GetAllAssetsInventoryBySearch(ByVal empID As Integer, ByVal input As String, ByVal page As String) As List(Of Assets)

    <OperationContract()>
    Function GetAssetDescription() As List(Of Assets)

    <OperationContract()>
    Function GetAssetManufacturer() As List(Of Assets)

#End Region

    ''' <summary>
    ''' By Marivic Espino
    ''' </summary>
    ''' <remarks></remarks>
#Region "Lesson Learnt Operation Contracts"

    <OperationContract()>
    Function GetLessonLearntList(ByVal email As String) As List(Of LessonLearnt)

    <OperationContract()>
    Function GetLessonLearntByProblem(ByVal search As String, ByVal email As String) As List(Of LessonLearnt)

    <OperationContract(IsOneWay:=True)>
    Sub CreateLessonLearnt(ByVal lessonLearnt As LessonLearnt)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateLessonLearntInfo(ByVal lesson As LessonLearnt)

#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Success Register Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub CreateNewSuccessRegister(ByVal success As SuccessRegister)

    <OperationContract()>
    Function ViewSuccessRegisterByEmpID(ByVal email As String) As List(Of SuccessRegister)

    <OperationContract()>
    Function ViewSuccessRegisterBySearch(ByVal input As String, ByVal email As String) As List(Of SuccessRegister)

    <OperationContract()>
    Function ViewSuccessRegisterAll(ByVal email As String) As List(Of SuccessRegister)

    'For the list of Nickname displayed in Combobox
    <OperationContract()>
    Function ViewNicknameByDeptID(ByVal email As String, ByVal toDisplay As Integer) As List(Of Nickname)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateSuccessRegisterByEmpID(ByVal success As SuccessRegister)

    <OperationContract(IsOneWay:=True)>
    Sub DeleteSuccessRegisterBySuccessID(ByVal successID As Integer)
#End Region

#Region "Signon/SignOff Operation Contract"
    <OperationContract()>
    Function SignOn(ByVal emailAddress As String) As Profile
    <OperationContract()>
    Function SignOff(ByVal EmployeeName As String) As Integer
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Contact List Operation Contracts"

    <OperationContract()>
    Function ViewContactListAll(ByVal email As String) As List(Of ContactList)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateContactListByEmpID(ByVal contact As ContactList)

    <OperationContract(IsOneWay:=True)>
    Sub CreateNewContactByEmpID(ByVal contact As ContactList)
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Birthday List Operation Contracts"

    <OperationContract()>
    Function ViewBirthdayListAll(ByVal email As String) As List(Of BirthdayList)

    <OperationContract()>
    Function ViewBirthdayListByCurrentMonth(ByVal email As String) As List(Of BirthdayList)

    <OperationContract()>
    Function ViewBirthdayListByCurrentDay(ByVal email As String) As List(Of BirthdayList)

#End Region

#Region "Concern Data Contracts"

    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function selectAllConcern(ByVal email As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)

    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <param name="email"></param>
    ''' <remarks></remarks>
    <OperationContract(IsOneWay:=True)>
    Sub InsertIntoConcern(ByVal concern As Concern, email As String)

    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetGeneratedRefNo() As Concern

    ''SEARCH
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="searchKeyWord"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetResultSearch(ByVal email As String, ByVal searchKeyWord As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)

    ''LISTVIEW LIST OF ACTION LIST
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetListOfACtion(Ref_id As String, email As String) As List(Of Concern)

    ''LISTVIEW DISPLAY EACH ACTIONS TO CONCERN
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetListOfACtionsReferences(Ref_id As String) As List(Of Concern)

    ''insert selected action
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <remarks></remarks>
    <OperationContract(IsOneWay:=True)>
    Sub insertAndDeleteSelectedAction(ByVal concern As Concern)

    ''UPDATE selected CONCERN
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <remarks></remarks>
    <OperationContract(IsOneWay:=True)>
    Sub UpdateSelectedConcern(ByVal concern As Concern)

    ''GET RESULT OF BETWEEN DATE
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <param name="date1"></param>
    ''' <param name="date2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetBetweenSearchConcern(ByVal email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of Concern)

    ''LISTVIEW LIST OF ACTION LIST  VIA SEARCH
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="_keywordAction"></param>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetSearchAction(_keywordAction As String, Ref_id As String, email As String) As List(Of Concern)

#End Region

#Region "Skill Matrix Operation Contracts"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks>
    <OperationContract()>
    Function GetSkillsList() As List(Of Skills)

    <OperationContract(IsOneWay:=True)>
    Sub InsertNewSkills(ByVal skills As Skills)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateSkills(ByVal skills As Skills)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAllSkills(ByVal skills As Skills)

    <OperationContract()>
    Function ViewEmpSKills(ByVal empID As Integer) As List(Of Skills)

    <OperationContract()>
    Function GetProfLvlByEmpIDSkillIDs(ByVal empID As Integer, ByVal skillID As Integer) As Skills

    <OperationContract()>
    Function GetSkillsProfByEmpID(ByVal id As Integer) As List(Of Skills)

    <OperationContract()>
    Function GetSkillsLastReviewByEmpIDSkillID(ByVal empID As Integer, ByVal skillID As Integer) As Skills
#End Region

#Region "Resource Planner Operation Contract"
    ''' <summary>
    ''' By Jhunell G. Barcenas / John Harvey Sanchez
    ''' </summary>
    ''' <remarks></remarks>

    <OperationContract(IsOneWay:=True)>
    Sub UpdateResourcePlanner(ByVal resource As ResourcePlanner)

    <OperationContract(IsOneWay:=True)>
    Sub InsertResourcePlanner(ByVal resource As ResourcePlanner)

    <OperationContract()>
    Function ViewEmpResourcePlanner(ByVal email As String) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetStatusResourcePlanner() As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetResourcePlannerByEmpID(ByVal empID As Integer, ByVal deptID As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetAllEmpResourcePlanner(ByVal email As String, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetAllEmpResourcePlannerByStatus(ByVal email As String, ByVal month As Integer, ByVal year As Integer, ByVal status As Integer) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetAllStatusResourcePlanner() As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetResourcePlanner(ByVal email As String, ByVal status As Integer, ByVal toBeDisplayed As Integer, ByVal year As Integer) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetBillableHoursByMonth(ByVal empID As Integer, ByVal month As Integer, year As Integer) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetBillableHoursByWeek(ByVal empID As Integer, ByVal currentDate As Date) As List(Of ResourcePlanner)

    <OperationContract()>
    Function GetNonBillableHours(ByVal email As String, ByVal display As Integer, ByVal month As Integer, ByVal year As Integer) As List(Of ResourcePlanner)
#End Region

#Region "Announcements Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertAnnouncements(ByVal announcements As Announcements)

    <OperationContract()>
    Function GetAnnouncements(ByVal empID As Integer) As List(Of Announcements)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAnnouncements(ByVal announcements As Announcements)
#End Region

#Region "Late Operation Contracts"
    <OperationContract()>
    Function GetLate(ByVal empID As Integer, ByVal month As Integer, ByVal year As Integer, ByVal toDisplay As Integer) As List(Of Late)
#End Region

#Region "Saba Learning Operation Contracts"

    <OperationContract()>
    Function GetAllSabaCourses(ByVal empID As Integer) As List(Of SabaLearning)
    <OperationContract()>
    Function GetAllSabaXref(ByVal empID As Integer, ByVal sabaID As Integer) As List(Of SabaLearning)
    <OperationContract()>
    Sub InsertSabaCourses(ByVal obj As SabaLearning)
    <OperationContract()>
    Sub UpdateSabaCourses(ByVal obj As SabaLearning)
    <OperationContract()>
    Sub UpdateSabaXref(ByVal obj As SabaLearning)
    <OperationContract()>
    Function GetAllSabaCourseByTitle(ByVal message As String, ByVal empID As Integer) As List(Of SabaLearning)
#End Region

#Region "Comcell Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertComcellMeeting(ByVal comcell As Comcell)

    <OperationContract()>
    Function GetComcellMeeting(ByVal empID As Integer, ByVal year As Integer) As List(Of Comcell)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateComcellMeeting(ByVal comcell As Comcell)

#End Region

#Region "ComcellClock Operation Contracts"

    <OperationContract()>
    Function GetClockTimeByEmployee(ByVal empid As Integer) As ComcellClock

    <OperationContract()>
    Sub UpdateComcellClock(ByVal obj As ComcellClock)

#End Region

#Region "Weekly Report Operation Contracts"
    ''' <summary>
    ''' By John Harvey Sanchez
    ''' </summary>
    <OperationContract(IsOneWay:=True)>
    Sub CreateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport))

    <OperationContract(IsOneWay:=True)>
    Sub UpdateWeeklyReport(ByVal weeklyReport As List(Of WeeklyReport))

    <OperationContract(IsOneWay:=True)>
    Sub CreateWeekRange(ByVal weekRange As WeekRange)

    <OperationContract()>
    Function GetWeekRange(ByVal currentDate As Date, ByVal empID As Integer) As List(Of WeekRange)

    <OperationContract()>
    Function GetWeeklyReportsByEmpID(ByVal empID As Integer) As List(Of WeekRange)

    <OperationContract()>
    Function GetWeeklyReportsByWeekRangeID(ByVal weekRangeID As Integer, ByVal empID As Integer) As List(Of WeeklyReport)
#End Region

#Region "AuditSched Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertAuditSched(ByVal auditSched As AuditSched)

    <OperationContract()>
    Function GetAuditSched(ByVal empID As Integer, ByVal year As Integer) As List(Of AuditSched)

    <OperationContract(IsOneWay:=True)>
    Sub UpdateAuditSched(ByVal auditSched As AuditSched)

#End Region
#Region "SendCode Operation Contracts"

    <OperationContract()>
    Function GetWorkEmailbyEmail(ByVal email As String) As SendCode

#End Region

#Region "MailConfig Operation Contracts"

    <OperationContract()>
    Function GetMailConfig() As MailConfig

#End Region

#Region "Workplace Audit Operation Contracts"
    <OperationContract(IsOneWay:=True)>
    Sub InsertAuditDaily(ByVal auditSched As WorkplaceAudit)

    <OperationContract()>
    Function GetAuditDaily(ByVal empID As Integer, ByVal parmDate As Date) As List(Of WorkplaceAudit)

    <OperationContract()>
    Function GetAuditQuestions(ByVal empID As Integer, ByVal questionGroup As String) As List(Of WorkplaceAudit)

    '<OperationContract(IsOneWay:=True)>
    'Sub UpdateAuditSched(ByVal auditSched As AuditSched)

#End Region

End Interface
#End Region

#Region "Data Contracts"

#Region "Action Data Contracts"
''' <summary>
''' By Jester Sanchez/ Lemuela Abulencia
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class Action

    <DataMember()>
    Public Property Act_ID As String

    <DataMember()>
    Public Property Act_Message As String

    <DataMember()>
    Public Property Act_Assignee As Integer

    <DataMember()>
    Public Property Act_NickName As String

    <DataMember()>
    Public Property Act_DueDate As Date

    <DataMember()>
    Public Property Act_DateClosed As String

End Class
#End Region

#Region "Contacts Data Contracts"

<DataContract()>
Public Class Contact

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property EmailAddress As String

    <DataMember()>
    Public Property EmailAddress2 As String

    <DataMember()>
    Public Property Location As String

    <DataMember()>
    Public Property CellNumber As String

    <DataMember()>
    Public Property Local As Integer

    <DataMember()>
    Public Property HomePhone As String

    <DataMember()>
    Public Property DateReviewed As DateTime
End Class

#End Region

#Region "Employee Data Contract"
''' <summary>
''' GIANN CALRO CAMILO
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class Employee

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property EmployeeName As String

    <DataMember()>
    Public Property FirstName As String

    <DataMember()>
    Public Property LastName As String

    <DataMember()>
    Public Property MiddleInitial As Char

    <DataMember()>
    Public Property Nickname As String

    <DataMember()>
    Public Property Birthdate As Date

    <DataMember()>
    Public Property Position As String

    <DataMember()>
    Public Property DateHired As Date

    <DataMember()>
    Public Property Status As String

    <DataMember()>
    Public Property ImagePath As String

    <DataMember()>
    Public Property GroupID As Short

    <DataMember()>
    Public Property EmailAddress As String

    <DataMember()>
    Public Property EmailAddress2 As String

    <DataMember()>
    Public Property Location As String

    <DataMember()>
    Public Property CellNumber As String

    <DataMember()>
    Public Property Local As Integer

    <DataMember()>
    Public Property HomePhone As String

    <DataMember()>
    Public Property OtherPhone As String

    <DataMember()>
    Public Property DateReviewed As DateTime
End Class
#End Region

#Region "Profile Data Contract"
<DataContract()>
Public Class Profile

    <DataMember()>
    Public Property Emp_ID As Integer

    <DataMember()>
    Public Property Ws_EMP_ID As String

    <DataMember()>
    Public Property Dept_ID As Short

    <DataMember()>
    Public Property FirstName As String

    <DataMember()>
    Public Property LastName As String

    <DataMember()>
    Public Property MiddleName As Char

    <DataMember()>
    Public Property Nickname As String

    <DataMember()>
    Public Property Birthdate As Date

    <DataMember()>
    Public Property DateHired As Date

    <DataMember()>
    Public Property ImagePath As String

    <DataMember()>
    Public Property Department As String

    <DataMember()>
    Public Property Division As String

    <DataMember()>
    Public Property Position As String

    <DataMember()>
    Public Property Email_Address As String

    <DataMember()>
    Public Property Email_Address2 As String

    <DataMember()>
    Public Property Location As String

    <DataMember()>
    Public Property Cel_No As String

    <DataMember()>
    Public Property Local As Integer

    <DataMember()>
    Public Property Home_Phone As String

    <DataMember()>
    Public Property Other_Phone As String

    <DataMember()>
    Public Property Dt_Reviewed As DateTime

    <DataMember()>
    Public Property Permission As String

    <DataMember()>
    Public Property CivilStatus As String

    <DataMember()>
    Public Property ShiftStatus As String

End Class
#End Region

#Region "Project Data Contracts"
''' <summary>
''' HYACINTH, GIANN AND HARVEY
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class Project

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property ProjectID As Integer

    <DataMember()>
    Public Property ProjectName As String

    <DataMember()>
    Public Property Category As Integer

    <DataMember()>
    Public Property Billability As Short

End Class

<DataContract()>
Public Class ViewProject

    <DataMember()>
    Public Property Status As String

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property Month1 As String

    <DataMember()>
    Public Property Month2 As String

    <DataMember()>
    Public Property Month3 As String

End Class

<DataContract()>
Public Class AssignedProject
    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property ProjectID As Integer

    <DataMember()>
    Public Property DateCreated As Date

    <DataMember()>
    Public Property StartPeriod As Date

    <DataMember()>
    Public Property EndPeriod As Date

End Class
#End Region

#Region "Tasks Data Contracts"

<DataContract()>
Public Class Tasks

    <DataMember()>
    Public Property TaskID As Integer

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property IncidentID As String

    <DataMember()>
    Public Property TaskType As Short

    <DataMember()>
    Public Property ProjectID As Integer

    <DataMember()>
    Public Property IncidentDescr As String

    <DataMember()>
    Public Property TaskDescr As String

    <DataMember()>
    Public Property DateStarted As Date

    <DataMember()>
    Public Property TargetDate As Date

    <DataMember()>
    Public Property CompletedDate As Date

    <DataMember()>
    Public Property DateCreated As Date

    <DataMember()>
    Public Property Status As String

    <DataMember()>
    Public Property Remarks As String

    <DataMember()>
    Public Property EffortEst As Decimal

    <DataMember()>
    Public Property ActualEffortEst As Decimal

    <DataMember()>
    Public Property EffortEstWk As Decimal

    <DataMember()>
    Public Property ProjectCode As Integer

    <DataMember()>
    Public Property Rework As Short

    <DataMember()>
    Public Property Phase As String

    <DataMember()>
    Public Property HoursWorked_Date As String

    <DataMember()>
    Public Property Others1 As String

    <DataMember()>
    Public Property Others2 As String

    <DataMember()>
    Public Property Others3 As String


End Class

<DataContract()>
Public Class TaskSummary
    <DataMember()>
    Public Property InitialDate As Date

    <DataMember()>
    Public Property OutstandingTaskLastWeek As Integer

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property MondayAT As Integer

    <DataMember()>
    Public Property MondayCT As Integer

    <DataMember()>
    Public Property MondayOT As Integer

    <DataMember()>
    Public Property TuesdayAT As Integer

    <DataMember()>
    Public Property TuesdayCT As Integer

    <DataMember()>
    Public Property TuesdayOT As Integer

    <DataMember()>
    Public Property WednesdayAT As Integer

    <DataMember()>
    Public Property WednesdayCT As Integer

    <DataMember()>
    Public Property WednesdayOT As Integer

    <DataMember()>
    Public Property ThursdayAT As Integer

    <DataMember()>
    Public Property ThursdayCT As Integer

    <DataMember()>
    Public Property ThursdayOT As Integer

    <DataMember()>
    Public Property FridayAT As Integer

    <DataMember()>
    Public Property FridayCT As Integer

    <DataMember()>
    Public Property FridayOT As Integer
End Class
#End Region

#Region "Lesson Learnt Data Contracts"

<DataContract()>
Public Class LessonLearnt

    <DataMember()>
    Public Property ReferenceNo As String

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property Nickname As String

    <DataMember()>
    Public Property Problem As String

    <DataMember()>
    Public Property Resolution As String

    <DataMember()>
    Public Property ActionNo As String
End Class

#End Region

#Region "Status Data Contracts"
<DataContract()>
Public Class StatusGroup
    <DataMember()>
    Public Property StatusID As Short

    <DataMember()>
    Public Property StatusName As String

    <DataMember()>
    Public Property Description As String

    <DataMember()>
    Public Property Status As Short

End Class
#End Region

#Region "Success Register Data Contract"
<DataContract()>
Public Class SuccessRegister

    <DataMember()>
    Public Property Emp_ID As Integer

    <DataMember()>
    Public Property SuccessID As Integer

    <DataMember()>
    Public Property DetailsOfSuccess As String

    <DataMember()>
    Public Property WhosInvolve As String

    <DataMember()>
    Public Property AdditionalInformation As String

    <DataMember()>
    Public Property Nick_Name As String

    <DataMember()>
    Public Property DateInput As Date
End Class

#Region "For the List of Nickname"
<DataContract()>
Public Class Nickname

    <DataMember()>
    Public Property Emp_ID As Integer
    <DataMember()>
    Public Property Nick_Name As String
    <DataMember()>
    Public Property First_Name As String
    <DataMember()>
    Public Property Employee_Name As String

End Class
#End Region
#End Region

#Region "Contact List Data Contract"
<DataContract()>
Public Class ContactList

    <DataMember()>
    Public Property CELL_NO As String

    <DataMember()>
    Public Property DateReviewed As Date

    <DataMember()>
    Public Property EMADDRESS As String

    <DataMember()>
    Public Property EMADDRESS2 As String

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property HOUSEPHONE As String

    <DataMember()>
    Public Property lOCAL As Integer

    <DataMember()>
    Public Property LOC As String

    <DataMember()>
    Public Property MARITAL_STATUS As String

    <DataMember()>
    Public Property POSITION As String

    <DataMember()>
    Public Property OTHERPHONE As String

    <DataMember()>
    Public Property FULL_NAME As String

    <DataMember()>
    Public Property FIRST_NAME As String

    <DataMember()>
    Public Property LAST_NAME As String

    <DataMember()>
    Public Property IsREVIEWED As Boolean

    <DataMember()>
    Public Property IMAGE_PATH As String

    <DataMember()>
    Public Property MIDDLE_NAME As String

    <DataMember()>
    Public Property Nick_Name As String

    <DataMember()>
    Public Property ACTIVE As Integer
    '<DataMember()>
    'Public Property STATUS As String

    <DataMember()>
    Public Property PERMISSION_GROUP As String

    <DataMember()>
    Public Property DEPARTMENT As String

    <DataMember()>
    Public Property DIVISION As String

    <DataMember()>
    Public Property SHIFT As String

    <DataMember()>
    Public Property BIRTHDATE As Date

    <DataMember()>
    Public Property DT_HIRED As Date

    <DataMember()>
    Public Property MARITAL_STATUS_ID As Integer

    <DataMember()>
    Public Property POSITION_ID As Integer

    <DataMember()>
    Public Property PERMISSION_GROUP_ID As Integer

    <DataMember()>
    Public Property DEPARTMENT_ID As Integer

    <DataMember()>
    Public Property DIVISION_ID As Integer
End Class
#End Region

#Region "Commendations Data Contract"
<DataContract()>
Public Class Commendations

    <DataMember()>
    Public Property COMMEND_ID As Integer

    <DataMember()>
    Public Property DEPT_ID As Integer

    <DataMember()>
    Public Property EMPLOYEE As String

    <DataMember()>
    Public Property PROJECT As String

    <DataMember()>
    Public Property DATE_SENT As Date

    <DataMember()>
    Public Property SENT_BY As String

    <DataMember()>
    Public Property REASON As String

End Class
#End Region

#Region "Birthday List Data Contract"
<DataContract()>
Public Class BirthdayList

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property FULL_NAME As String

    <DataMember()>
    Public Property FIRST_NAME As String

    <DataMember()>
    Public Property LAST_NAME As String

    <DataMember()>
    Public Property BIRTHDAY As Date

    <DataMember()>
    Public Property IMAGE_PATH As String
End Class
#End Region

#Region "Concern Data Contracts"
''' <summary>
''' GIANN CARLO CAMILO / CHRISTIAN VALONDO
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class Concern

    <DataMember()>
    Public Property RefID As String

    <DataMember()>
    Public Property Concerns As String

    <DataMember()>
    Public Property Cause As String

    <DataMember()>
    Public Property CounterMeasure As String

    <DataMember()>
    Public Property EmpID As String

    <DataMember()>
    Public Property Act_Reference As String

    <DataMember()>
    Public Property Due_Date As Date

    <DataMember()>
    Public Property Status As String



    <DataMember()>
    Public Property GENERATEDREF_ID As String


    <DataMember()>
    Public Property ACTREF As String

    <DataMember()>
    Public Property ACT_MESSAGE As String


    <DataMember()>
    Public Property ACTION_REFERENCES As String


    <DataMember()>
    Public Property DATE1 As Date


    <DataMember()>
    Public Property DATE2 As Date

End Class

#End Region

#Region "Skills Matrix Data Contracts"
''' <summary>
''' By Jhunell G. Barcenas
''' </summary>
''' <remarks></remarks>
Public Class Skills

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property SkillID As Integer

    <DataMember()>
    Public Property Prof_LVL As Integer

    <DataMember()>
    Public Property Last_Reviewed As DateTime

    <DataMember()>
    Public Property DESCR As String

    <DataMember()>
    Public Property NAME As String

    <DataMember()>
    Public Property Image_Path As String

End Class

#End Region

#Region "Resource Planner Data Contracts"
''' <summary>
''' By Jhunell G. Barcenas / John Harvey A. Sanchez
''' </summary>
''' <remarks></remarks>
Public Class ResourcePlanner

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property NAME As String

    <DataMember()>
    Public Property dateFrom As Date

    <DataMember()>
    Public Property dateTo As Date

    <DataMember()>
    Public Property Status As Double

    <DataMember()>
    Public Property UsedLeaves As Double

    <DataMember()>
    Public Property TotalBalance As Double

    <DataMember()>
    Public Property HalfBalance As Double

    <DataMember()>
    Public Property DESCR As String

    <DataMember()>
    Public Property Image_Path As String

    <DataMember()>
    Public Property DateEntry As Date

    <DataMember()>
    Public Property holidayHours As Double

    <DataMember()>
    Public Property vlHours As Double

    <DataMember()>
    Public Property slHours As Double

End Class
#End Region

#Region "Attendance Data Contracts"
<DataContract()>
Public Class MyAttendance

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property Descr As String

    <DataMember()>
    Public Property Status As Integer

    <DataMember()>
    Public Property Image_Path As String

    <DataMember()>
    Public Property DateEntry As Date

    <DataMember()>
    Public Property MondayVal As Short

    <DataMember()>
    Public Property TuesdayVal As Short

    <DataMember()>
    Public Property WednesdayVal As Short

    <DataMember()>
    Public Property ThursdayVal As Short

    <DataMember()>
    Public Property FridayVal As Short

End Class

<DataContract()>
Public Class AttendanceSummary

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property TimeIn As DateTime

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property Month As Short

    <DataMember()>
    Public Property Year As Short

    <DataMember()>
    Public Property Day1 As Short

    <DataMember()>
    Public Property Day2 As Short

    <DataMember()>
    Public Property Day3 As Short

    <DataMember()>
    Public Property Day4 As Short

    <DataMember()>
    Public Property Day5 As Short

    <DataMember()>
    Public Property Day6 As Short

    <DataMember()>
    Public Property Day7 As Short

    <DataMember()>
    Public Property Day8 As Short

    <DataMember()>
    Public Property Day9 As Short

    <DataMember()>
    Public Property Day10 As Short

    <DataMember()>
    Public Property Day11 As Short

    <DataMember()>
    Public Property Day12 As Short

    <DataMember()>
    Public Property Day13 As Short

    <DataMember()>
    Public Property Day14 As Short

    <DataMember()>
    Public Property Day15 As Short

    <DataMember()>
    Public Property Day16 As Short

    <DataMember()>
    Public Property Day17 As Short

    <DataMember()>
    Public Property Day18 As Short

    <DataMember()>
    Public Property Day19 As Short

    <DataMember()>
    Public Property Day20 As Short

    <DataMember()>
    Public Property Day21 As Short

    <DataMember()>
    Public Property Day22 As Short

    <DataMember()>
    Public Property Day23 As Short

    <DataMember()>
    Public Property Day24 As Short

    <DataMember()>
    Public Property Day25 As Short

    <DataMember()>
    Public Property Day26 As Short

    <DataMember()>
    Public Property Day27 As Short

    <DataMember()>
    Public Property Day28 As Short

    <DataMember()>
    Public Property Day29 As Short

    <DataMember()>
    Public Property Day30 As Short

    <DataMember()>
    Public Property Day31 As Short

End Class
#End Region

#Region "Assets Data Contract"
<DataContract()>
Public Class Assets

    <DataMember()>
    Public Property ASSET_ID As Integer

    <DataMember()>
    Public Property EMP_ID As Integer

    <DataMember()>
    Public Property ASSET_DESC As String

    <DataMember()>
    Public Property MANUFACTURER As String

    <DataMember()>
    Public Property MODEL_NO As String

    <DataMember()>
    Public Property SERIAL_NO As String

    <DataMember()>
    Public Property ASSET_TAG As String

    <DataMember()>
    Public Property DATE_PURCHASED As DateTime

    <DataMember()>
    Public Property STATUS As Integer

    <DataMember()>
    Public Property OTHER_INFO As String

    <DataMember()>
    Public Property DATE_ASSIGNED As DateTime

    <DataMember()>
    Public Property COMMENTS As String

    <DataMember()>
    Public Property FULL_NAME As String

    <DataMember()>
    Public Property DEPARTMENT As String

    <DataMember()>
    Public Property ASSIGNED_TO As String

    <DataMember()>
    Public Property APPROVAL As Integer

    <DataMember()>
    Public Property TABLE_NAME As String

    <DataMember()>
    Public Property STATUS_DESCR As String
End Class
#End Region

#Region "Announcements Data Contract"
<DataContract()>
Public Class Announcements

    <DataMember()>
    Public Property ANNOUNCEMENT_ID As Integer
    <DataMember()>
    Public Property EMP_ID As Integer
    <DataMember()>
    Public Property MESSAGE As String
    <DataMember()>
    Public Property TITLE As String
    <DataMember()>
    Public Property END_DATE As Date

End Class
#End Region

#Region "Late Data Contract"
<DataContract()>
Public Class Late

    <DataMember()>
    Public Property FIRST_NAME As String

    <DataMember()>
    Public Property STATUS As Integer

    <DataMember()>
    Public Property MONTH As String

    <DataMember()>
    Public Property NUMBER_OF_LATE As Integer

End Class
#End Region

#Region "Saba Learning Data Contract"
<DataContract()>
Public Class SabaLearning

    <DataMember()>
    Public Property SABA_ID As Integer
    <DataMember()>
    Public Property EMP_ID As Integer
    <DataMember()>
    Public Property TITLE As String
    <DataMember()>
    Public Property END_DATE As Date
    <DataMember()>
    Public Property DATE_COMPLETED As String
    <DataMember()>
    Public Property IMAGE_PATH As String

End Class
#End Region

#Region "Comcell Data Contract"
<DataContract()>
Public Class Comcell

    <DataMember()>
    Public Property COMCELL_ID As Integer

    <DataMember()>
    Public Property EMP_ID As Integer

    <DataMember()>
    Public Property MONTH As String

    <DataMember()>
    Public Property FACILITATOR As String

    <DataMember()>
    Public Property MINUTES_TAKER As String

    <DataMember()>
    Public Property SCHEDULE As String

    <DataMember()>
    Public Property FY_START As DateTime

    <DataMember()>
    Public Property FY_END As DateTime

    <DataMember()>
    Public Property YEAR As Integer
End Class
#End Region

#Region "ComcellClock Data Contracts"
''' <summary>
''' By Jester Sanchez/ Lemuela Abulencia
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class ComcellClock

    <DataMember()>
    Public Property Clock_Day As Integer

    <DataMember()>
    Public Property Clock_Hour As Integer

    <DataMember()>
    Public Property Clock_Minute As Integer

    <DataMember()>
    Public Property Emp_ID As Integer

End Class
#End Region

#Region "AuditSched Data Contract"
<DataContract()>
Public Class AuditSched

    <DataMember()>
    Public Property AUDIT_SCHED_ID As Integer

    <DataMember()>
    Public Property EMP_ID As Integer

    <DataMember()>
    Public Property FY_WEEK As Integer

    <DataMember()>
    Public Property PERIOD_START As DateTime

    <DataMember()>
    Public Property PERIOD_END As DateTime

    <DataMember()>
    Public Property DAILY As String

    <DataMember()>
    Public Property WEEKLY As String

    <DataMember()>
    Public Property MONTHLY As String

    <DataMember()>
    Public Property FY_START As DateTime

    <DataMember()>
    Public Property FY_END As DateTime

    <DataMember()>
    Public Property YEAR As Integer
End Class
#End Region

#Region "Weekly Report Data Contracts"

<DataContract()>
Public Class WeeklyReport

    <DataMember()>
    Public Property WeekID As Integer

    <DataMember()>
    Public Property WeekRangeID As Integer

    <DataMember()>
    Public Property ProjectID As Integer

    <DataMember()>
    Public Property Rework As Short

    <DataMember()>
    Public Property ReferenceID As String

    <DataMember()>
    Public Property Subject As String

    <DataMember()>
    Public Property Severity As Short

    <DataMember()>
    Public Property IncidentType As Short

    <DataMember()>
    Public Property EmpID As Integer

    <DataMember()>
    Public Property Phase As Short

    <DataMember()>
    Public Property Status As Short

    <DataMember()>
    Public Property DateStarted As Date

    <DataMember()>
    Public Property DateTarget As Date

    <DataMember()>
    Public Property DateFinished As Date

    <DataMember()>
    Public Property DateCreated As Date

    <DataMember()>
    Public Property EffortEst As Decimal

    <DataMember()>
    Public Property ActualEffortWk As Decimal

    <DataMember()>
    Public Property ActualEffort As Decimal

    <DataMember()>
    Public Property Comments As String

    <DataMember()>
    Public Property InboundContacts As Short
End Class

<DataContract()>
Public Class WeekRange
    <DataMember()>
    Public Property WeekRangeID As Integer

    <DataMember()>
    Public Property StartWeek As Date

    <DataMember()>
    Public Property EndWeek As Date

    <DataMember()>
    Public Property DateCreated As Date

    <DataMember()>
    Public Property DateRange As String
End Class

#End Region

#Region "Non-Billability Hours Data Contracts"
<DataContract()>
Public Class NonBillableSummary

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property SickLeave As Double

    <DataMember()>
    Public Property VacationLeave As Double

    <DataMember()>
    Public Property Holiday As Short

    '<DataMember()>
    'Public Property InBetween As Short

    <DataMember()>
    Public Property HalfdayVL As Double

    <DataMember()>
    Public Property HalfdaySL As Double

    <DataMember()>
    Public Property HalfDay As Double

    <DataMember()>
    Public Property Total As Double
End Class

<DataContract()>
Public Class NonBillableHours

    <DataMember()>
    Public Property EmployeeID As Integer

    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property TotalHours As Short

    <DataMember()>
    Public Property Month As String

    <DataMember()>
    Public Property Year As Short

End Class
#End Region

#Region "SendCode Data Contracts"
''' <summary>
''' By Jester Sanchez/ Lemuela Abulencia
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class SendCode

    <DataMember()>
    Public Property Work_Email As String

    <DataMember()>
    Public Property FName As String

    <DataMember()>
    Public Property LName As String

End Class
#End Region
#Region "Mail Config Data Contracts"
''' <summary>
''' By Jester Sanchez/ Lemuela Abulencia
''' </summary>
''' <remarks></remarks>
<DataContract()>
Public Class MailConfig

    <DataMember()>
    Public Property SenderEmail As String

    <DataMember()>
    Public Property Subject As String

    <DataMember()>
    Public Property Body As String

    <DataMember()>
    Public Property Port As Integer

    <DataMember()>
    Public Property Host As String

    <DataMember()>
    Public Property EnableSSL As Integer

    <DataMember()>
    Public Property Timeout As Integer

    <DataMember()>
    Public Property UseDfltCredentials As Integer

    <DataMember()>
    Public Property SenderPassword As String

    <DataMember()>
    Public Property PasswordExpiry As Integer


End Class
#End Region

#Region "Wokrplace Audit Data Contract"
<DataContract()>
Public Class WorkplaceAudit

    <DataMember()>
    Public Property AUDIT_QUESTIONS_ID As Integer

    <DataMember()>
    Public Property EMP_ID As Integer

    <DataMember()>
    Public Property FY_WEEK As Integer

    <DataMember()>
    Public Property AUDIT_DAILY_ID As Integer

    <DataMember()>
    Public Property STATUS As Integer

    <DataMember()>
    Public Property DT_CHECKED As Date

    <DataMember()>
    Public Property AUDIT_QUESTIONS As String

    <DataMember()>
    Public Property OWNER As String

    <DataMember()>
    Public Property AUDIT_QUESTIONS_GROUP As String
End Class
#End Region

#End Region

<ServiceContract()>
Public Interface IAideService2
    <OperationContract()>
    Function DashboardGetEmployeeList() As List(Of DashboardEmployee)

    <OperationContract()>
    Function DashboardGetContactList() As List(Of DashboardContact)

    <OperationContract()>
    Function DashboardGetNonBillableHours() As List(Of DashboardNonBillableHours)

    <OperationContract()>
    Function DashboardGetNonBillableHoursSummary() As List(Of DashboardNonBillableHoursSummary)

    <OperationContract()>
    Function DashboardGetTeamAttendance() As List(Of DashboardTeamAttendance)

    <OperationContract()>
    Function DashboardGetResourcePlanner() As List(Of AttendanceSummary)

    <OperationContract()>
    Function DashboardGetTaskSummary(ByVal dateStart As Date, ByVal email As String) As List(Of TaskSummary)


    <OperationContract()>
    Function DashboardGetTaskSummaryTotals(ByVal dateStart As Date, ByVal email As String) As List(Of DashboardTaskSummaryTotals)
End Interface

#Region "Dashboard Contracts"
<DataContract()>
Public Class DashboardAttendance
    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property Status As Short
End Class

<DataContract()>
Public Class DashboardTeamAttendance
    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property ImageSource As String

    <DataMember()>
    Public Property Status As Short

    <DataMember()>
    Public Property FirstMonth As String

    <DataMember()>
    Public Property SecondMonth As String

    <DataMember()>
    Public Property ThirdMonth As String
End Class

<DataContract()>
Public Class DashboardContact
    <DataMember()>
    Public Property EmployeeID As String

    <DataMember()>
    Public Property FullName As String

    <DataMember()>
    Public Property NickName As String

    <DataMember()>
    Public Property Position As String

    <DataMember()>
    Public Property EmailAdd As String

    <DataMember()>
    Public Property EmployeeLocation As String

    <DataMember()>
    Public Property CellNo As String

    <DataMember()>
    Public Property Local As String

    <DataMember()>
    Public Property DateReviewed As String

    <DataMember()>
    Public Property EmployeeType As String

    <DataMember()>
    Public Property ImageSource As String

    <DataMember()>
    Public Property ImageSource2 As String
End Class

<DataContract()>
Public Class DashboardPlanner
    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property Color As String

    <DataMember()>
    Public Property Status As Short

    <DataMember()>
    Public Property Dates As List(Of String)
End Class

<DataContract()>
Public Class DashboardTaskSummaryTotals
    <DataMember()>
    Public Property Name As String

    <DataMember()>
    Public Property AssignedTaskCount As Integer

    <DataMember()>
    Public Property CompletedTaskCount As Integer

    <DataMember()>
    Public Property OutstandingTaskCount As Integer
End Class


<DataContract()>
Public Class DashboardNonBillableHours
    <DataMember()>
    Public Property SL As Integer

    <DataMember()>
    Public Property VL As Integer

    <DataMember()>
    Public Property Holiday As Integer

    <DataMember()>
    Public Property IBP As Integer

    <DataMember()>
    Public Property Name As String
End Class


<DataContract()>
Public Class DashboardNonBillableHoursSummary
    <DataMember()>
    Public Property SL As Integer

    <DataMember()>
    Public Property VL As Integer

    <DataMember()>
    Public Property Holiday As Integer

    <DataMember()>
    Public Property IBP As Integer

    <DataMember()>
    Public Property DateSelected As String
End Class

<DataContract()>
Public Class DashboardEmployee
    <DataMember()>
    Public Property EmployeeName As String

    <DataMember()>
    Public Property ImageSource As String

    <DataMember()>
    Public Property EmployeePosition As String

    <DataMember()>
    Public Property EmployeeType As String

End Class

#End Region


