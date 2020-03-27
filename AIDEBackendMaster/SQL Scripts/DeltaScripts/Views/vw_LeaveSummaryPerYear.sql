USE [AIDE]
GO

/****** Object:  View [dbo].[vw_LeaveSummary]  ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_LeaveSummaryPerYear'))
BEGIN
   PRINT 'Dropping old version of vw_LeaveSummaryPerYear'
   Drop View dbo.vw_LeaveSummaryPerYear
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_LeaveSummaryPerYear] AS
	
	Select totals.EmployeeID,
			(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as EmployeeName,
			totals.LeaveDesc,
			totals.TotalDays,
			totals.CalendarYear as [Year],
			emp.DIV_ID as DivisionID,
			emp.DEPT_ID as DepartmentID,
			emp.ACTIVE as IsActive,
			totals.LeaveType
			
	From vw_AccumulatedLeavesPerYear as totals
		inner join EMPLOYEE as emp
			on emp.EMP_ID = totals.EmployeeID
	
GO


