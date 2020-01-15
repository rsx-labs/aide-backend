USE [AIDE]
GO

/****** Object:  View [dbo].[vw_BillabilityByProjectPerWeek]    Script Date: 1/14/2020 9:25:51 PM ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_BillabilityByProjectPerWeek'))
BEGIN
   PRINT 'Dropping old version of vw_BillabilityByProjectPerWeek'
   Drop View dbo.vw_BillabilityByProjectPerWeek
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_BillabilityByProjectPerWeek] AS
	
	Select report.WR_PROJ_ID as ProjectID,
			proj.PROJ_NAME as Project, 
			report.WR_WEEK_RANGE_ID as WeekID, 
			sum(report.WR_act_effort_wk) as [TotalHours],
			proj.BILLABILITY as IsBillable,
			[week].FiscalYear,
			emp.DIV_ID as DivisionID,
			emp.DEPT_ID as DepartmentID,
			[week].Range as [WeekRange],
			[week].Month as [Month]

	From WEEKLY_REPORT report
			inner join PROJECT proj
				on proj.PROJ_ID = report.WR_PROJ_ID
			inner join vw_WeekRange [week]
				on report.WR_WEEK_RANGE_ID = [week].WeekID
			inner join EMPLOYEE emp
				on proj.EMP_ID = emp.EMP_ID

	Group by report.WR_PROJ_ID, 
				report.WR_WEEK_RANGE_ID, 
				proj.BILLABILITY,
				proj.PROJ_NAME,
				[week].FiscalYear,
				emp.DIV_ID,
				emp.DEPT_ID,
				[week].Range,
				[week].Month
	

GO


