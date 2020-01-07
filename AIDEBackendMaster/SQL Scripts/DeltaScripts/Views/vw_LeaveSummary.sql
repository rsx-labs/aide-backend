USE [AIDE]
GO

/****** Object:  View [dbo].[vw_LeaveSummary]  ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_LeaveSummary'))
BEGIN
   PRINT 'Dropping old version of vw_LeaveSummary'
   Drop View dbo.vw_LeaveSummary
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_LeaveSummary] AS
	
	Select totals.EmployeeID,
			(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as EmployeeName,
			totals.LeaveDesc,
			credits.LEAVE_CREDITS as LeaveCredits,
			totals.TotalDays as UsedLeaves,
			(credits.LEAVE_CREDITS - totals.TotalDays) as RemainingLeaves,
			case
				when ((credits.LEAVE_CREDITS/2) - totals.TotalDays) > 0  and totals.LeaveType = 4 then  ((credits.LEAVE_CREDITS/2) - totals.TotalDays)
				else 0
			end  as RemainingMandatoryLeaves,
			totals.FiscalYear,
			emp.DIV_ID as DivisionID,
			emp.DEPT_ID as DepartmentID,
			emp.ACTIVE as IsActive,
			totals.LeaveType
			
	From vw_AccumulatedLeaves as totals
		inner join LEAVE_CREDITS as credits
			on totals.EmployeeID = credits.EMP_ID
				and totals.LeaveType = credits.STATUS
				and totals.FiscalYear = dbo.fn_getFiscalYear(credits.FY_START, credits.FY_END)
		inner join EMPLOYEE as emp
			on emp.EMP_ID = totals.EmployeeID
	
GO


