USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeeklyReportsByEmpID]    Script Date: 01/06/2020 8:36:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetWeeklyReportsByEmpID'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetWeeklyReportsByEmpID]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetWeeklyReportsByEmpID]
@EMP_ID INT,
@MONTH INT,
@YEAR INT

AS
BEGIN

	DECLARE @temptable TABLE (WEEKRANGEID INT, 
							  STARTWEEK DATE, 
							  ENDWEEK DATE,
							  STATUS INT,
							  DATE_SUBMITTED DATE)

	DECLARE @fiscalYear VARCHAR(10)
	SET @fiscalYear = CAST(@year AS VARCHAR) + '-' + CAST((@year + 1) AS VARCHAR)

	
	INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, STATUS, DATE_SUBMITTED)
	SELECT WEEK_ID, WEEK_START, WEEK_END, STATUS, DATE_SUBMITTED 
	FROM WEEKLY_REPORT_XREF x 
	INNER JOIN WEEK_RANGE r
	ON x.WEEK_RANGE = r.WEEK_ID 
	WHERE EMP_ID = @EMP_ID
	AND MONTH = @MONTH
	AND FISCAL_YEAR = @fiscalYear 
	ORDER BY WEEK_ID 


	SELECT * FROM @temptable ORDER BY WEEKRANGEID ASC 
END
 


