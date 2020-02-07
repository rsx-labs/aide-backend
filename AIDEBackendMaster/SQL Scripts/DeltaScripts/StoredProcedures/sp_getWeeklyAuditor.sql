USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getWeeklyAuditor]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getWeeklyAuditor'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getWeeklyAuditor
    END
GO

CREATE PROCEDURE [dbo].sp_getWeeklyAuditor
       -- Add the parameters for the stored procedure here
		@EMP_ID INT,
		@date datetime
AS
BEGIN
	

	
	DECLARE @DATEVALUE DATETIME  = @date
	

	CREATE TABLE #SummaryWEEKLYAuditor(WEEKDAYS nvarchar(25), NICKNAME nvarchar(30), EMP_ID int, WEEKDATE nvarchar(25), FY_WEEK INT, DT_CHECK_FLG INT, WEEKDATESCHED  NVARCHAR(20),DATE_CHECKED NVARCHAR(20))


DECLARE @GETPERDATESTRING NVARCHAR(20)
DECLARE @SETdatechecked NVARCHAR(20)

if MONTH(@date) = 1
	BEGIN
	SET @date = @date
	END
ELSE IF MONTH(@date) = 2
	BEGIN
	SET @date = @date
	END
ELSE IF MONTH(@date) = 3
	BEGIN
		SET @date = @date
	END
ELSE
	BEGIN
		SET @date = DATEADD(YEAR,1,@date)
	END
	insert into #SummaryWEEKLYAuditor
		 SELECT distinct 'TUE', 
						e.FIRST_NAME, 
						e.emp_id,  
						CONCAT(MONTH(WAS.PERIOD_START), '/',DAY(WAS.PERIOD_START), ' - ' ,MONTH(WAS.PERIOD_END), '/',DAY(WAS.PERIOD_END) ), 
						w.fy_week, 
							(CASE WHEN (SELECT  COUNT(*) FROM WORKPLACE_AUDIT_WEEKLY WW WHERE WW.DT_CHECK_FLG = 0 AND WW.WEEKDATE = W.WEEKDATE ) = 0 THEN 1 
							ELSE 0 END) AS DT_CHECK_FLG,
						w.weekdate,
						w.DT_CHECKED
						
						FROM
							 WORKPLACE_AUDIT_SCHEDULE WAS 
					INNER JOIN WORKPLACE_AUDIT_WEEKLY w 
							ON WAS.FY_WEEK = w.FY_WEEK
					INNER JOIN EMPLOYEE E 
							ON w.EMP_ID = E.EMP_ID 
					WHERE MONTH(WAS.PERIOD_START) = MONTH(@DATEVALUE)   and YEAR(WAS.PERIOD_START) = YEAR(@DATEVALUE)
					and w.WEEKDATE between convert(date,concat(YEAR(@DATEVALUE ) - 1 ,'-','04','-','01')) and convert(date,concat(YEAR(@date),'-','03','-','31'))

		 
		

SELECT * FROM #SummaryWEEKLYAuditor ORDER BY WEEKDATESCHED ASC
END

GO
