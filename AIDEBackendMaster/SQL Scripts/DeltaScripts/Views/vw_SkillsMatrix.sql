USE [AIDE]
GO

/****** Object:  View [dbo].[vw_SkillsMatrix]    Script Date: 1/29/2020 10:58:23 PM ******/
SET ANSI_NULLS ON
GO



IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_SkillsMatrix'))
BEGIN
   PRINT 'Dropping old version of dbo.vw_SkillsMatrix'
   Drop View dbo.vw_SkillsMatrix
END
GO

SET QUOTED_IDENTIFIER ON
GO






	CREATE VIEW [dbo].[vw_SkillsMatrix] AS
	
	Select emp.EMP_ID as EmployeeID,
			(emp.LAST_NAME + ', '+ emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as EmployeeName,
			skill.DESCR as Skill,
			prof.PROF_LVL as ProficiencyLevel,
			case 
				when prof.PROF_LVL = 1 then 'Has Received Training'
				when prof.PROF_LVL = 2 then 'Could Deliver Supported'
				when prof.PROF_LVL = 3 then 'Could Deliver Unsupported'
				when prof.PROF_LVL = 4 then 'Subject Matter Expert'
				else ''
			end as Proficiency,

			skill.DSPLY_ORDR as DisplayOrder,
			skilldept.DISPLAY_FG as DisplayFlag,
			skilldept.DSPLY_TO_ALL as ShowToAll,
			dept.DEPT_ID as DepartmentID,
			dept.DESCR as Department,
			div.DIV_ID as DivisionID,
			div.DESCR as Division,
			emp.ACTIVE as IsActive,
			convert(date,prof.LAST_REVIEWED,10) as LastReviewed

	From SKILLS_PROF prof
		inner join EMPLOYEE emp 
			on prof.EMP_ID = emp.EMP_ID
		inner join SKILLS_DEPT as skilldept
			on prof.SKILL_ID = skilldept.SKILL_ID 
		inner join EMPLOYEE depthead
			on depthead.EMP_ID = skilldept.EMP_ID
		inner join DEPARTMENT dept
			on dept.DEPT_ID = depthead.DEPT_ID
		inner join DIVISION div
			on div.DIV_ID = depthead.DIV_ID
		inner join SKILLS skill
			on prof.SKILL_ID = skill.SKILL_ID
		
		










GO


