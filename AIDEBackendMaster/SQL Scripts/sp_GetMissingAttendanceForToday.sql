USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetMissingAttendanceForToday]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetMissingAttendanceForToday]
GO

CREATE PROCEDURE [dbo].[sp_GetMissingAttendanceForToday]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@CHOICE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		    @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@MGREMAILSTRING VARCHAR(MAX), 
			@EMAILSTRING VARCHAR(MAX),
			@EMPNAMESTRING VARCHAR(MAX),
			@END_DATE DATE = GETDATE(),
			@START_DATE DATE = DATEADD(month, -2, GETDATE()),
			@dayNumber INT,
			@attendance VARCHAR(MAX)
	
	CREATE TABLE #TABLEONE(WEEK_DATE VARCHAR(20), EMAIL_ADDRESS VARCHAR(MAX), EMPLOYEE_NAME VARCHAR(MAX))

	SELECT @MGREMAILSTRING = COALESCE(@MGREMAILSTRING + ',', '') + c.EMAIL_ADDRESS
			FROM EMPLOYEE E INNER JOIN CONTACTS C 
			ON E.EMP_ID = C.EMP_ID
			WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 AND E.GRP_ID = 1

	--Test employee that are semi-flex
	IF @CHOICE = 1
		BEGIN
			WHILE (@START_DATE <= GETDATE())
				BEGIN
					SET @dayNumber = DATEPART(DW, @START_DATE);
					IF NOT (@dayNumber = 1 OR @dayNumber = 7)		
					SELECT @EMAILSTRING = COALESCE(@EMAILSTRING + ',', '') + c.EMAIL_ADDRESS, 
						@EMPNAMESTRING = COALESCE(@EMPNAMESTRING + ',', '') + e.FIRST_NAME + ' ' + e.LAST_NAME
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Semi-flex' AND E.GRP_ID != 5 AND c.LOCATION != 3
					ORDER BY e.LAST_NAME	

					INSERT INTO #TABLEONE(WEEK_DATE, EMAIL_ADDRESS, EMPLOYEE_NAME)
					SELECT @START_DATE, @EMAILSTRING, @EMPNAMESTRING
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Semi-flex' AND E.GRP_ID != 5 AND c.LOCATION != 3
					ORDER BY e.LAST_NAME

					SET @EMAILSTRING = null
					SET @EMPNAMESTRING = null 
					SET @START_DATE = DATEADD(DAY, 1, @START_DATE);
				END
		END
	--Test employee that are flexi
	ELSE IF @CHOICE = 2
		BEGIN
			WHILE (@START_DATE <= GETDATE())
				BEGIN
					SET @dayNumber = DATEPART(DW, @START_DATE);
					IF NOT (@dayNumber = 1 OR @dayNumber = 7)		
					SELECT @EMAILSTRING = COALESCE(@EMAILSTRING + ',', '') + c.EMAIL_ADDRESS, 
						@EMPNAMESTRING = COALESCE(@EMPNAMESTRING + ',', '') + e.FIRST_NAME + ' ' + e.LAST_NAME
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Flexi' AND E.GRP_ID != 5 AND c.LOCATION != 3
					ORDER BY e.LAST_NAME	

					INSERT INTO #TABLEONE(WEEK_DATE, EMAIL_ADDRESS, EMPLOYEE_NAME)
					SELECT @START_DATE, @EMAILSTRING, @EMPNAMESTRING
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Flexi' AND E.GRP_ID != 5 AND c.LOCATION != 3
					ORDER BY e.LAST_NAME

					SET @EMAILSTRING = null
					SET @EMPNAMESTRING = null 
					SET @START_DATE = DATEADD(DAY, 1, @START_DATE);
				END
		END
	ELSE
		BEGIN
			WHILE (CONVERT(DATE,@START_DATE) < CONVERT(DATE,GETDATE()))
				BEGIN
					SET @dayNumber = DATEPART(DW, @START_DATE);
					IF NOT (@dayNumber = 1 OR @dayNumber = 7)		
					SELECT @EMAILSTRING = COALESCE(@EMAILSTRING + ',', '') + c.EMAIL_ADDRESS, 
						@EMPNAMESTRING = COALESCE(@EMPNAMESTRING + ',', '') + e.FIRST_NAME + ' ' + e.LAST_NAME
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Flexi' AND E.GRP_ID != 5 AND c.LOCATION = 3
					ORDER BY e.LAST_NAME	

					INSERT INTO #TABLEONE(WEEK_DATE, EMAIL_ADDRESS, EMPLOYEE_NAME)
					SELECT @START_DATE, @EMAILSTRING, @EMPNAMESTRING
					FROM EMPLOYEE E INNER JOIN CONTACTS C 
						ON E.EMP_ID = C.EMP_ID
					WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
						AND E.EMP_ID NOT IN (SELECT EMP_ID 
										FROM ATTENDANCE 
										WHERE CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @START_DATE))
						AND E.SHIFT_STATUS = 'Flexi' AND E.GRP_ID != 5 AND c.LOCATION = 3
					ORDER BY e.LAST_NAME

					SET @EMAILSTRING = null
					SET @EMPNAMESTRING = null 
					SET @START_DATE = DATEADD(DAY, 1, @START_DATE);
				END
		END

		SELECT DISTINCT(WEEK_DATE), EMPLOYEE_NAME, EMAIL_ADDRESS, @MGREMAILSTRING AS 'MANAGER_EMAIL' FROM #TABLEONE
		WHERE EMAIL_ADDRESS != '' AND EMPLOYEE_NAME != ''
		GROUP BY WEEK_DATE, EMAIL_ADDRESS, EMPLOYEE_NAME
		ORDER BY WEEK_DATE DESC

	DROP TABLE #TABLEONE
END
