USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttendanceToday]    Script Date: 09/27/2019 3:27:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAttendanceToday'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAttendanceToday]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetAttendanceToday]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @ATTENDANCE_TODAY TABLE (EMP_ID INT,
								     EMPLOYEE_NAME VARCHAR(50),
								     DESCR VARCHAR(50),
								     DATE_ENTRY DATETIME,
								     STATUS INT,
								     IMAGE_PATH VARCHAR(MAX),
									 DSPLY_ORDR INT)
	DECLARE @DEPT_ID INT = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
							ON A.EMP_ID = B.EMP_ID
							WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	DECLARE @DIV_ID INT = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
						   ON A.EMP_ID = B.EMP_ID
						   WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	DECLARE @DSPLY_ORDR INT
	DECLARE @counter INT = 1
	DECLARE @totalEmployees INT = (SELECT COUNT(A.EMP_ID) FROM ATTENDANCE A INNER JOIN EMPLOYEE B
								   ON A.EMP_ID = B.EMP_ID
								   WHERE CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
								   AND B.DEPT_ID = @DEPT_ID
								   AND B.DIV_ID = @DIV_ID)


	WHILE (@counter <= @totalEmployees)
		BEGIN
			-- Get the employee by row number
			DECLARE @STATUS INT = (SELECT STATUS FROM (
											SELECT ROW_NUMBER() OVER (ORDER BY LAST_NAME) As RowNum, A.STATUS 
											FROM ATTENDANCE A INNER JOIN EMPLOYEE B
											ON A.EMP_ID = B.EMP_ID
											WHERE CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
											AND B.DEPT_ID = @DEPT_ID
											AND B.DIV_ID = @DIV_ID) Data
									   WHERE RowNum = @counter)
			DECLARE @EMP_ID INT = (SELECT EMP_ID FROM (
											SELECT ROW_NUMBER() OVER (ORDER BY LAST_NAME) As RowNum, A.EMP_ID 
											FROM ATTENDANCE A INNER JOIN EMPLOYEE B
											ON A.EMP_ID = B.EMP_ID
											WHERE CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
											AND B.DEPT_ID = @DEPT_ID
											AND B.DIV_ID = @DIV_ID) Data
									   WHERE RowNum = @counter)

			IF @STATUS = 2 OR @STATUS = 11 OR @STATUS = 7--PRESENT
				BEGIN
					SET @DSPLY_ORDR = 1
				END
			ELSE IF @STATUS = 1 OR @STATUS = 13 OR @STATUS = 14--ONSITE
				BEGIN
					SET @DSPLY_ORDR = 2
				END
			ELSE IF @STATUS = 4 OR @STATUS = 6 OR @STATUS = 8 OR @STATUS = 9 OR @STATUS = 10 OR @STATUS = 12 --VL
				BEGIN
					SET @DSPLY_ORDR = 3
				END
			ELSE IF @STATUS = 3 OR @STATUS = 5 OR @STATUS = 13 OR @STATUS = 14 --SL
				BEGIN
					SET @DSPLY_ORDR = 4
				END
			ELSE
				BEGIN
					SET @DSPLY_ORDR = 5
				END

			INSERT INTO @ATTENDANCE_TODAY (EMP_ID, EMPLOYEE_NAME, DESCR, DATE_ENTRY, STATUS, IMAGE_PATH, DSPLY_ORDR)
				select B.EMP_ID, B.LAST_NAME + ', ' + B.FIRST_NAME + ' ' + SUBSTRING(B.MIDDLE_NAME,1,1) + '' AS EMPLOYEE_NAME, 
				D.DESCR, a.DATE_ENTRY,a.STATUS, B.IMAGE_PATH, @DSPLY_ORDR
				from ATTENDANCE a inner join EMPLOYEE b on a.EMP_ID = b.EMP_ID
				INNER JOIN DIVISION D ON B.DIV_ID = D.DIV_ID
				where CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
				AND B.DEPT_ID = @DEPT_ID
				AND B.DIV_ID = @DIV_ID
				AND A.EMP_ID = @EMP_ID
				ORDER BY B.LAST_NAME
		SET @counter += 1
		END

	SELECT * FROM @ATTENDANCE_TODAY ORDER BY DSPLY_ORDR, EMPLOYEE_NAME
END


