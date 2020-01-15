USE [AIDE]
GO

/****** Object:  View [dbo].[vw_WeekRange]    Script Date: 1/14/2020 9:22:51 PM ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_WeekRange'))
BEGIN
   PRINT 'Dropping old version of vw_WeekRange'
   Drop View dbo.vw_WeekRange
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_WeekRange] AS
	
	Select wk.WEEK_ID as WeekID,
			wk.WEEK_START as WeekStart,
			wk.WEEK_END as WeekEnd,
			Convert(varchar,wk.WEEK_END,112) as [Range],
			dbo.fn_getFiscalYear(wk.WEEK_START,wk.WEEK_START) as FiscalYear,
			Month(wk.Week_START) as [Month],
			Year(wk.Week_Start) as [Year]

	From WEEK_RANGE wk
		

GO


