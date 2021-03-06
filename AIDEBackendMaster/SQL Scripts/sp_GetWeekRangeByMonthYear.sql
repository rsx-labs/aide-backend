USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeekRangeByMonthYear]    Script Date: 01/06/2020 7:22:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetWeekRangeByMonthYear'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetWeekRangeByMonthYear]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetWeekRangeByMonthYear]
	@EMP_ID INT,
	@MONTH INT,
	@YEAR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @temptable TABLE (WEEKRANGEID INT, 
							  STARTWEEK DATE, 
							  ENDWEEK DATE,
							  DATERANGE VARCHAR(50))

	DECLARE @fiscalYear VARCHAR(10)
	--SET @fiscalYear = CAST(@year AS VARCHAR) + '-' + CAST((@year + 1) AS VARCHAR)
	SET @fiscalYear = CAST((SELECT YEAR(FY_START) FROM FISCAL_YEAR WHERE YEAR(FY_START) = @year) AS VARCHAR) + '-' + CAST((SELECT YEAR(FY_END) FROM FISCAL_YEAR WHERE YEAR(FY_START) = @year) AS VARCHAR)

	INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, DATERANGE)
	SELECT WEEK_ID, WEEK_START, WEEK_END, 
		   CONVERT(varchar, WEEK_START, 101) + ' - ' + 
		   CONVERT(varchar, WEEK_END, 101)
	FROM WEEK_RANGE 
	WHERE MONTH = @MONTH
	AND FISCAL_YEAR = @fiscalYear 

	SELECT * FROM @temptable
END


