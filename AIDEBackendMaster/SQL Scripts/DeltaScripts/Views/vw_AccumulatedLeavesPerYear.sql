USE [AIDE]
GO

/****** Object:  View [dbo].[vw_AccumulatedLeavesPerYear]    ******/
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_AccumulatedLeavesPerYear'))
BEGIN
   PRINT 'Dropping old version of vw_AccumulatedLeavesPerYear'
   Drop View dbo.vw_AccumulatedLeavesPerYear
END
GO


SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_AccumulatedLeavesPerYear] AS
	Select	EMP_ID as EmployeeID, 
			Year(date_entry) as [CalendarYear],
			4 as LeaveType,  
			'Vacation Leave' as LeaveDesc,
			sum(counts) as TotalDays
	from ATTENDANCE
	where  status  in (4,8,9,6) 
		and status_cd = 1 
	group by	EMP_ID, 
				Year(date_entry)

	union

	select	emp_id as EmployeeID, 
			Year(date_entry) as [CalendarYear], 
			3 as LeaveType,
			'Sick Leave' as LeaveDesc, 
			sum(counts) as TotalDays
	from ATTENDANCE
	where  status  in (3,5) and status_cd = 1 
	group by	EMP_ID,
				Year(date_entry)
	
	



GO


