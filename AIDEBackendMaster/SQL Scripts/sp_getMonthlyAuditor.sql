USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getMonthlyAuditor]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getMonthlyAuditor'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getMonthlyAuditor
    END
GO

CREATE PROCEDURE [dbo].sp_getMonthlyAuditor
       -- Add the parameters for the stored procedure here
		@EMP_ID INT,
		@date INT
AS
BEGIN
	DECLARE @DATEVALUE int  = @date
	
	CREATE TABLE #SummaryMonthlyAuditor(WEEKDAYS nvarchar(25), NICKNAME nvarchar(30), EMP_ID int,WEEKDATE NVARCHAR(20) ,FY_WEEK INT, DT_CHECK_FLG INT, WEEKDATESCHED  NVARCHAR(20),DATE_CHECKED NVARCHAR(20))


DECLARE @GETPERDATESTRING NVARCHAR(20)
DECLARE @SETdatechecked NVARCHAR(20)

DECLARE @COUNT INT=1
	WHILE @COUNT <= 12
	BEGIN
	if @COUNT = 1
	begin
	set @DATEVALUE = @date
	end
	else if @COUNT = 2
	begin
	set @DATEVALUE = @date
	end
	else if @COUNT = 3
	begin
	set @DATEVALUE = @date
	end
	else
	begin
	set @DATEVALUE = @date -1
	end
	insert into #SummaryMonthlyAuditor
			SELECT distinct DATENAME(MONTH, w.weekdate )as MonthName, 
						e.FIRST_NAME, 
						e.emp_id,
						w.weekdate,  
						w.fy_week, 
						(CASE WHEN (SELECT  COUNT(*) FROM WORKPLACE_AUDIT_monthly WW WHERE WW.DT_CHECK_FLG = 0 AND WW.WEEKDATE = W.WEEKDATE ) = 0 THEN 1 
							ELSE 0 END) AS DT_CHECK_FLG,
						w.weekdate,
						w.DT_CHECKED
			FROM WORKPLACE_AUDIT_SCHEDULE WAS 
					INNER JOIN WORKPLACE_AUDIT_monthly w 
							ON WAS.FY_WEEK = w.FY_WEEK
					INNER JOIN EMPLOYEE E 
							ON w.EMP_ID = E.EMP_ID 
			WHERE 
					 MONTH(w.weekdate)  =  @COUNT  
			
	SET @COUNT = @COUNT + 1; 
	END


SELECT * FROM #SummaryMonthlyAuditor  w where CONVERT(date, w.WEEKDATE) between convert(date,concat(@DATEVALUE,'-','04','-','01')) and convert(date,concat(@date,'-','03','-','31')) ORDER BY WEEKDATESCHED ASC
END

GO
