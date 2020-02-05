USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getQuarterlyAuditor]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getQuarterlyAuditor'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getQuarterlyAuditor
    END
GO

CREATE PROCEDURE [dbo].sp_getQuarterlyAuditor
       -- Add the parameters for the stored procedure here
		@EMP_ID INT,
		@date INT
AS
BEGIN
	DECLARE @DATEVALUE int  = @date
	
	CREATE TABLE #SummaryQUARTERLYAuditor(WEEKDAYS nvarchar(30), NICKNAME nvarchar(30), EMP_ID int,WEEKDATE NVARCHAR(50) ,FY_WEEK INT, DT_CHECK_FLG INT, WEEKDATESCHED  NVARCHAR(20),DATE_CHECKED NVARCHAR(20))


DECLARE @GETPERDATESTRING NVARCHAR(20)
DECLARE @SETdatechecked NVARCHAR(20)

DECLARE @COUNT INT=1
WHILE @COUNT < 12
	BEGIN
	insert into #SummaryQUARTERLYAuditor
			SELECT distinct CONCAT(DATENAME(MONTH, w.weekdate),' - ',DATENAME(MONTH, DATEADD(MONTH,2,w.weekdate) ))as MonthName, 
						e.NICK_NAME, 
						e.emp_id,
						CONCAT(w.weekdate,' - ',DATEADD(MONTH,2,w.weekdate)),  
						w.fy_week, 
						(CASE WHEN (SELECT  COUNT(*) FROM WORKPLACE_AUDIT_QUARTERLY WW WHERE WW.DT_CHECK_FLG = 0 AND WW.WEEKDATE = W.WEEKDATE ) = 0 THEN 1 
							ELSE 0 END) AS DT_CHECK_FLG,
						w.weekdate,
						w.DT_CHECKED
			FROM WORKPLACE_AUDIT_SCHEDULE WAS 
					INNER JOIN WORKPLACE_AUDIT_QUARTERLY w 
							ON WAS.FY_WEEK = w.FY_WEEK
					INNER JOIN EMPLOYEE E 
							ON w.EMP_ID = E.EMP_ID 
			WHERE year(WAS.PERIOD_START) = @DATEVALUE 
					and MONTH(w.weekdate) + 2 =  @COUNT +2
					
	SET @COUNT = @COUNT + 3; 
	END


SELECT * FROM #SummaryQUARTERLYAuditor ORDER BY WEEKDATESCHED ASC
END

GO
