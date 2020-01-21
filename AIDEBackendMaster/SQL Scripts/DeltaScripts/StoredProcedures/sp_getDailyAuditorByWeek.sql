USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDailyAuditorByWeek]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getDailyAuditorByWeek'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getDailyAuditorByWeek
    END
GO

CREATE PROCEDURE [dbo].[sp_getDailyAuditorByWeek]
       -- Add the parameters for the stored procedure here
		@EMP_ID INT,
		@DATE nvarchar(20)
AS
BEGIN
	DECLARE @MONTHTODAY DATETIME = MONTH(GETDATE())
	DECLARE @DATESELECTED DATETIME
	DECLARE @cnt INT = 2;
	CREATE TABLE #SummaryDailyAuditor(WEEKDAYS nvarchar(20), NICKNAME nvarchar(30), EMP_ID int, WEEKDATE nvarchar(10))

	---		2---MONDAY		3---TUESTDAY	4---WEDNESDAY	5---THURSDAY	6---FRIDAY
	WHILE @cnt < 7
		BEGIN
			INSERT INTO #SummaryDailyAuditor
			SELECT DISTINCT SUBSTRING(DATENAME(weekday,DATEADD(wk,	0, DATEADD(DAY, @cnt-DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE())))), 1, 3)	,
					E.NICK_NAME , 
					E.EMP_ID , 
					CONCAT(MONTH(GETDATE()), '/', DATENAME(DAY,DATEADD(wk,	0, DATEADD(DAY, @cnt-DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE())))))
				 FROM WORKPLACE_AUDIT_SCHEDULE WAS 
					INNER JOIN WORKPLACE_AUDIT_DAILY WAD 
							ON WAS.FY_WEEK = WAD.FY_WEEK
					INNER JOIN EMPLOYEE E 
							ON WAD.EMP_ID = E.EMP_ID 
					WHERE MONTH(WAS.PERIOD_START) = @MONTHTODAY
			SET @cnt = @cnt + 1;
		END;
	SET NOCOUNT ON;
SELECT * FROM #SummaryDailyAuditor
    
END

GO
