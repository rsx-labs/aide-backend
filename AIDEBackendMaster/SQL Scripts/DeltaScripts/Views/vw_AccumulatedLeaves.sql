USE [AIDE]
GO

/****** Object:  View [dbo].[vw_AccumulatedLeaves]    ******/
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_AccumulatedLeaves'))
BEGIN
   PRINT 'Dropping old version of vw_AccumulatedLeaves'
   Drop View dbo.vw_AccumulatedLeaves
END
GO


SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_AccumulatedLeaves] AS
	Select	EMP_ID as EmployeeID, 
			FISCAL_YEAR.ID as FiscalYear, 
			4 as LeaveType,  
			'Vacation Leave' as LeaveDesc,
			sum(counts) as TotalDays
	from RESOURCE_PLANNER
		inner join FISCAL_YEAR 
			on FISCAL_YEAR.ID = dbo.fn_getFiscalYear(date_entry,date_entry)
	where  status  in (4,8,9,6) 
		and status_cd = 1 
	group by	EMP_ID, 
				FISCAL_YEAR.ID

	union

	select	emp_id as EmployeeID, 
			FISCAL_YEAR.ID as FiscalYear, 
			3 as LeaveType,
			'Sick Leave' as LeaveDesc, 
			sum(counts) as TotalDays
	from RESOURCE_PLANNER
		inner join FISCAL_YEAR 
			on FISCAL_YEAR.ID = dbo.fn_getFiscalYear(date_entry,date_entry)
	where  status  in (3,5) and status_cd = 1 
	group by	EMP_ID,
				FISCAL_YEAR.ID
	



GO


