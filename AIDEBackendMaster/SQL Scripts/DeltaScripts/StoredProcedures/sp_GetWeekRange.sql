USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeekRange]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetWeekRange'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetWeekRange]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetWeekRange]
	@CURRENT_DATE DATE,
	@WEEK_ID INT,
	@EMP_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @weekBefore DATE,
			@weekAfter DATE,
			@startWeek DATE,
			@tempDate DATE

	DECLARE @temptable TABLE (WEEKRANGEID INT, 
							  STARTWEEK DATE, 
							  ENDWEEK DATE,
							  DATERANGE VARCHAR(75))
	DECLARE @WeekNum INT, 
			@YearNum char(4)

	SELECT @WeekNum = DATEPART(WK, @CURRENT_DATE), 
		   @YearNum = CAST(DATEPART(YY, @CURRENT_DATE) AS CHAR(4));
						   
	-- Once you have the @WeekNum and @YearNum set, the following calculates the date range.
	SET @startWeek = (SELECT DATEADD(wk, DATEDIFF(wk, 6, '1/1/' + @YearNum) + (@WeekNum-1), 7))

	-- Get the Week Range
	SET @weekBefore = (SELECT DATEADD(week, -2, @startWeek))
	SET @weekAfter = (SELECT DATEADD(week, 2, @startWeek))

	IF @WEEK_ID = 0
		BEGIN
			INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, DATERANGE)
			SELECT WEEK_ID, WEEK_START, WEEK_END, 
				   CONVERT(varchar, WEEK_START, 101) + ' - ' + 
				   CONVERT(varchar, WEEK_END, 101)
			FROM WEEK_RANGE 
			WHERE WEEK_ID NOT IN (SELECT DISTINCT WR_WEEK_RANGE_ID FROM WEEKLY_REPORT WHERE WR_EMP_ID = @EMP_ID) AND
			WEEK_START BETWEEN @weekBefore AND @weekAfter 
		END
	ELSE
		BEGIN
			INSERT INTO @temptable (WEEKRANGEID, STARTWEEK, ENDWEEK, DATERANGE)
			SELECT WEEK_ID, WEEK_START, WEEK_END, 
				   CONVERT(varchar, WEEK_START, 101) + ' - ' + 
				   CONVERT(varchar, WEEK_END, 101)
			FROM WEEK_RANGE 
			WHERE WEEK_ID = @WEEK_ID
		END
	
	SELECT * FROM @temptable
END



GO
