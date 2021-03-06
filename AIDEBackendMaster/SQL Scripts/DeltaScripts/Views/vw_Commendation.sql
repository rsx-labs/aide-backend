USE [AIDE]
GO

/****** Object:  View [dbo].[vw_Commendation]    ******/
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_Commendation'))
BEGIN
   PRINT 'Dropping old version of vw_Commendation'
   Drop View dbo.vw_Commendation
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_Commendation] AS
	SELECT  
		Employee as Employee,
		Project as Project,
		SENT_BY as SentBy,
		format(convert(date,date_sent,10),'MM/dd/yyyy') as DateSent,
		Month(Date_Sent) as [Month],
		Year(Date_Sent) as [Year],
		REASON as Reason,	
		dbo.fn_getFiscalYear(Date_Sent, Date_Sent) as FiscalYear
	FROM Commendations
	

GO


