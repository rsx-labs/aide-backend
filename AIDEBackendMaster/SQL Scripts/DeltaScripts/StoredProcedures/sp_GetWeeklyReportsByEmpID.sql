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

	DECLARE @WeekNum INT, 
			@YearNum char(4)

	DECLARE @fiscalYear INT
	IF @MONTH < 4
		SET @fiscalYear	= @YEAR + 1
	ELSE
		SET @fiscalYear = @YEAR

	DECLARE @firstDayMonth DATE = (SELECT DATEADD(month, @MONTH-1, DATEADD(year, @fiscalYear-1900, 0)))
	DECLARE @endDayMonth DATE = (SELECT DATEADD(day, -1, DATEADD(month, @MONTH, DATEADD(year, @fiscalYear-1900, 0))))

	DECLARE @firstDateName VARCHAR(10) = (SELECT DATENAME(weekday, @firstDayMonth))
	DECLARE @endDateName VARCHAR(10) = (SELECT DATENAME(weekday, @endDayMonth))

	DECLARE @startDate DATE,
			@endDate DATE,
			@startOfWeek DATE,
			@endOfWeek DATE

	-- Set Begin Range
	IF @firstDateName != 'MONDAY'
		IF @firstDateName = 'SATURDAY' OR @firstDateName = 'SUNDAY'
			-- Set @startDate to first Monday of the Month
			SET @startDate = (SELECT DATEADD(wk, DATEDIFF(wk,0,DATEADD(dd,6-DATEPART(DAY, @firstDayMonth), @firstDayMonth)), 0))
		ELSE
			BEGIN
				SELECT @WeekNum = DATEPART(WK, @firstDayMonth), 
					   @YearNum = CAST(DATEPART(YY, @firstDayMonth) AS CHAR(4));
						   
				-- Set @startDate to the Monday of the next week
				SET @startDate = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 14))
			END
	ELSE
		SET @startDate = @firstDayMonth

	SET @startOfWeek = (SELECT WEEK_START FROM WEEK_RANGE WHERE @startDate BETWEEN WEEK_START AND WEEK_END)

	-- Set End Range
	IF @endDateName != 'FRIDAY'
		SET @endDate = (SELECT DATEADD(DY,DATEDIFF(DY,'1900-01-05',DATEADD(MM,DATEDIFF(MM,'1900-01-01',@firstDayMonth),30))/7*7,'1900-01-05'))
	ELSE
		SET @endDate = @endDayMonth

	WHILE(MONTH(@endDate) = MONTH(@startDate))
		BEGIN
			SELECT @WeekNum = DATEPART(WK, @startDate), 
				   @YearNum = CAST(DATEPART(YY, @startDate) AS CHAR(4));
						   
			-- Set @startDate to the Saturday of the Current week
			SET @startOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 5)) -- Get Saturday Date
			SET @endOfWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 5, '1/1/' + @YearNum) + (@WeekNum-1), 4)) -- Get Friday Date
			
			INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, STATUS, DATE_SUBMITTED)
			SELECT WEEK_ID, WEEK_START, WEEK_END, STATUS, DATE_SUBMITTED 
			FROM WEEKLY_REPORT_XREF x INNER JOIN WEEK_RANGE r
			ON x.WEEK_RANGE = r.WEEK_ID 
			WHERE EMP_ID = @EMP_ID
			AND WEEK_START = @startOfWeek

			-- Set Date to next week
			SET @startDate = (SELECT DATEADD(week, 1, @startDate))
		END

	SELECT * FROM @temptable ORDER BY WEEKRANGEID ASC 
END
 


