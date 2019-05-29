Imports GDC.PH.AIDE.BusinessLayer
''' <summary>
''' By Jhunell G. Barcenas
''' </summary>
''' <remarks></remarks>
Public Interface ISkill
    Property EmployeeID As Integer
    Property SkillID As Integer
    Property Prof_LVL As Integer
    Property LastReviewed As DateTime
    Property SkillDescr As String
    Property Name As String
    Property Image_Path As String

    Function InsertNewSkills(ByVal skills As SkillSet) As Boolean
    Function UpdateSkills(ByVal skills As SkillSet) As Boolean
    Function UpdateAllSkills(ByVal skills As SkillSet) As Boolean
    Function GetAllSkillList() As List(Of SkillSet)
    Function GetSkillsProfByEmpID(ByVal id As Integer) As List(Of SkillSet)
    Function ViewAllEmpSkills(ByVal empID As Integer) As List(Of SkillSet)
    Function GetProfLvlByEmpIDSkillID(ByVal empID As Integer, ByVal skillID As Integer) As SkillSet
    Function GetSkillsLastReviewByEmpIDSkillID(ByVal empID As Integer, ByVal skillID As Integer) As SkillSet

End Interface
