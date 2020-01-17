USE [AIDE]
GO

/****** Object:  View [dbo].[vw_BillabilityByEmployeePerWeek]    Script Date: 1/17/2020 1:27:56 AM ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_BillabilityByEmployeePerWeek'))
BEGIN
   PRINT 'Dropping old version of vw_vw_BillabilityByEmployeePerWeek'
   Drop View dbo.vw_vw_BillabilityByEmployeePerWeek
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_BillabilityByEmployeePerWeek] AS
	
	Select  emp.EMP_ID as EmployeeID,
			(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as EmployeeName,
			report.WR_PROJ_ID as ProjectID,
			proj.PROJ_NAME as [Project],
			
			report.WR_WEEK_RANGE_ID as WeekID, 
			sum(report.WR_act_effort_wk) as [TotalHours],
			proj.BILLABILITY as IsBillable,
			[week].FiscalYear,
			emp.DIV_ID as [DivisionID],
			emp.DEPT_ID as [DepartmentID],
			[week].Month,
			[week].Range
	From WEEKLY_REPORT report
			inner join PROJECT proj
				on proj.PROJ_ID = report.WR_PROJ_ID
			inner join vw_WeekRange [week]
				on report.WR_WEEK_RANGE_ID = [week].WeekID
			inner join EMPLOYEE emp
				on report.WR_EMP_ID = emp.EMP_ID


	Group by report.WR_PROJ_ID, 
				report.WR_WEEK_RANGE_ID, 
				proj.BILLABILITY,
				proj.PROJ_NAME,
				[week].FiscalYear,
				emp.EMP_ID,
				(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME),
				 emp.DIV_ID,
			 	emp.DEPT_ID,
				[week].Month,
				[week].Range

	






GO


