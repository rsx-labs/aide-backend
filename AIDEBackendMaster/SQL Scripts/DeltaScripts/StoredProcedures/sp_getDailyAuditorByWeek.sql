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
		@FY_WEEK nvarchar(20),
		@DATE date
AS
BEGIN
	

	DECLARE @cnt INT = 2;
	DECLARE @DATEVALUE DATETIME  = @date
	
	if @FY_WEEK = ''
		BEGIN
			SELECT DISTINCT @FY_WEEK = FY_WEEK FROM WORKPLACE_AUDIT_DAILY WHERE WEEKDATE = CONVERT(DATE, GETDATE())
		END

	SELECT TOP 1 @DATEVALUE = WEEKDATE FROM WORKPLACE_AUDIT_DAILY WHERE FY_WEEK = @FY_WEEK and YEAR(WEEKDATE) = YEAR(@DATE)
	
	CREATE TABLE #SummaryDailyAuditor(WEEKDAYS nvarchar(20), NICKNAME nvarchar(30), EMP_ID int, WEEKDATE nvarchar(10), FY_WEEK INT, DT_CHECK_FLG INT, WEEKDATESCHED  NVARCHAR(20))
	CREATE TABLE #SummaryDailyAuditor2 (WEEKDAYS nvarchar(20), NICKNAME nvarchar(30), EMP_ID int, WEEKDATE nvarchar(10), FY_WEEK INT, DT_CHECK_FLG INT, WEEKDATESCHED  NVARCHAR(20), DATE_CHECKED NVARCHAR(20))
	
		--	2---MONDAY		3---TUESTDAY	4---WEDNESDAY	5---THURSDAY	6---FRIDAY

	

DECLARE @GETPERDATESTRING NVARCHAR(20)
DECLARE @SETdatechecked date


	


WHILE @cnt < 7
		BEGIN
			SET @GETPERDATESTRING = CONCAT(MONTH(@DATEVALUE), '/', DATENAME(DAY,DATEADD(wk,	0, DATEADD(DAY, @cnt-DATEPART(WEEKDAY, @DATEVALUE), DATEDIFF(dd, 0, @DATEVALUE)))))
			SET @SETdatechecked = CONCAT(YEAR(@DATEVALUE), '-',month(@DATEVALUE),'-' ,DATENAME(DAY,DATEADD(wk,	0, DATEADD(DAY, @cnt-DATEPART(WEEKDAY, @DATEVALUE), DATEDIFF(dd, 0, @DATEVALUE)))))
	
		INSERT INTO #SummaryDailyAuditor
				SELECT DISTINCT SUBSTRING(DATENAME(weekday,DATEADD(wk,	0, DATEADD(DAY, @cnt-DATEPART(WEEKDAY, @DATEVALUE), DATEDIFF(dd, 0, @DATEVALUE)))), 1, 3)	,
					E.NICK_NAME , 
					E.EMP_ID , 
					@GETPERDATESTRING,
					WAD.FY_WEEK,
					(CASE WHEN (SELECT  COUNT(*) FROM WORKPLACE_AUDIT_DAILY W WHERE W.DT_CHECK_FLG = 0 AND w.FY_WEEK= wad.FY_WEEK and CONCAT(MONTH(W.WEEKDATE), '/',DATENAME(DAY, W.WEEKDATE)) = @GETPERDATESTRING) = 0 THEN 1 
							ELSE 0 END) AS DT_CHECK_FLG,	
					@SETdatechecked
				 FROM WORKPLACE_AUDIT_SCHEDULE WAS 
					INNER JOIN WORKPLACE_AUDIT_DAILY WAD 
							ON WAS.FY_WEEK = WAD.FY_WEEK
					INNER JOIN EMPLOYEE E 
							ON WAD.EMP_ID = E.EMP_ID 
					WHERE MONTH(WAS.PERIOD_START) = MONTH(@DATEVALUE) and was.FY_WEEK = @FY_WEEK
						
			SET @cnt = @cnt + 1;
		
		END;
	SET NOCOUNT ON;

INSERT INTO #SummaryDailyAuditor2
	SELECT DISTINCT SDA.*, WAD.DT_CHECKED 
	FROM #SummaryDailyAuditor SDA    
	INNER JOIN WORKPLACE_AUDIT_DAILY WAD  ON SDA.WEEKDATESCHED = convert(nvarchar,WAD.WEEKDATE)
	ORDER BY SDA.WEEKDATESCHED ASC

SELECT * FROM #SummaryDailyAuditor2 where MONTH(WEEKDATESCHED) = MONTH(@DATEVALUE) ORDER BY WEEKDATESCHED ASC
END

GO
