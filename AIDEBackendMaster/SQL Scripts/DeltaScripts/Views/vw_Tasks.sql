USE [AIDE]
GO

/****** Object:  View [dbo].[vw_Tasks]  ******/
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_Tasks'))
BEGIN
   PRINT 'Dropping old version of vw_Tasks'
   Drop View dbo.vw_Tasks
END

SET QUOTED_IDENTIFIER ON
GO






	CREATE VIEW [dbo].[vw_Tasks] AS
	
	Select emp.EMP_ID as EmployeeID,
			(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as [EmployeeName],
			task.PROJ_ID as ProjectID,
			proj.PROJ_NAME as ProjectName,
			task.REF_ID as RefID,
			task.INC_DESCR as [Description],
			task.INC_TYPE as [IncidentTypeID],
			incidentType.DESCR as [IncidentType],
			task.DATE_CREATED as DateCreated,
			task.DATE_STARTED as DateStarted,
			task.TARGET_DATE as TargetDate,
			task.COMPLTD_DATE as DateCompleted,
			task.PHASE as PhaseID,
			phase.DESCR as Phase,
			task.STATUS as [TaskStatusID],
			incidentStatus.DESCR as [TaskStatus],
			task.COMMENTS as [Comments],
			task.EFFORT_EST as [EstimatedEffort],
			task.ACT_EFFORT as [ActualEffort],
			emp.DEPT_ID as [DepartmentID],
			dept.DESCR as [Department],
			emp.DIV_ID as [DivisionID],
			div.DESCR as [Division],
			emp.ACTIVE as [IsActive]
	
			 
	From TASKS task
		inner join EMPLOYEE emp
			on emp.EMP_ID = task.EMP_ID
		inner join PROJECT proj
			on task.PROJ_ID = proj.PROJ_ID
		left outer join [Status] incidentType
			on incidentType.STATUS = task.Status and incidentType.STATUS_NAME = 'TASK_TYPE'
		left outer join [Status] incidentStatus
			on incidentStatus.STATUS = task.STATUS and incidentStatus.STATUS_NAME = 'TASK_STATUS'
		left outer join [Status] phase
			on phase.STATUS = task.PHASE and phase.STATUS_NAME = 'PHASE'
		inner join Department dept
			on emp.DEPT_ID = dept.DEPT_ID
		inner join Division div
			on emp.DIV_ID = div.DIV_ID





GO


