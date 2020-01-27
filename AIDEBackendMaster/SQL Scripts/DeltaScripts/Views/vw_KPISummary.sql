USE [AIDE]
GO

/****** Object:  View [dbo].[vw_KPISummary]    Script Date: 1/27/2020 4:52:56 AM ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_KPISummary'))
BEGIN
   PRINT 'Dropping old version of vw_KPISummary'
   Drop View dbo.vw_KPISummary
END
GO

SET QUOTED_IDENTIFIER ON
GO



	CREATE VIEW [dbo].[vw_KPISummary] AS
	
	Select summary.KPI_REF as KPIRefID,
			targets.SUBJECT as [Subject],
			targets.DESCRIPTION as [Description],
			summary.KPI_TARGET as [Target],
			summary.KPI_ACTUAL as Actual,
			summary.KPI_OVERALL as Overall,
			case
				when summary.KPI_MONTH < 4 then summary.KPI_MONTH + 12
				else summary.KPI_MONTH
			end as [MonthID],
			DateName( month , DateAdd( month , summary.KPI_MONTH , -1 ) ) as [Month],
			dbo.fn_getFiscalYear(summary.FY_START, summary.FY_END) as FiscalYear,
			dept.DEPT_ID as DepartmentID,
			div.DIV_ID as DivisionID,
			summary.DATE_POSTED as DatePosted
	From KPI_SUMMARY summary
		inner join KPI_TARGETS targets
			on summary.KPI_REF = targets.KPI_REF
		inner join EMPLOYEE emp 
			on summary.EMP_ID = emp.EMP_ID
		inner join DEPARTMENT dept
			on dept.DEPT_ID = emp.DEPT_ID
		inner join DIVISION div
			on emp.DIV_ID = div.DIV_ID









GO


