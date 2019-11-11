USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttendanceToday]    Script Date: 11/24/2019 2:48:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAttendanceToday]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetAttendanceToday]
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
									 DSPLY_ORDR INT,
									 DT_FLG int)
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

	DECLARE @DT_TIME_TODAY TIME = CONVERT(VARCHAR(10), GETDATE(), 108)



	WHILE (@counter <= @totalEmployees)
		BEGIN
		---date flag 1-morning 2-afternoon
			INSERT INTO @ATTENDANCE_TODAY (EMP_ID, EMPLOYEE_NAME, DESCR, DATE_ENTRY, STATUS, IMAGE_PATH, DSPLY_ORDR, DT_FLG)
				select  B.EMP_ID, B.LAST_NAME + ', ' + B.FIRST_NAME + ' ' + SUBSTRING(B.MIDDLE_NAME,1,1) + '' AS EMPLOYEE_NAME, 
						D.DESCR, 
						a.DATE_ENTRY,
						a.STATUS, 
						B.IMAGE_PATH, 
						case when  A.STATUS = 2 OR A.STATUS = 11 OR A.STATUS = 7 THEN  1  
							 WHEN  A.STATUS = 1 OR A.STATUS = 13 OR A.STATUS = 14 THEN 2
							 WHEN  A.STATUS = 4 OR A.STATUS = 6 OR A.STATUS = 8 OR A.STATUS = 9 OR A.STATUS = 10 OR A.STATUS = 12 THEN 3
							 WHEN  A.STATUS = 3 OR A.STATUS = 5 OR A.STATUS = 13 OR A.STATUS = 14 THEN 4	 
						else
						 5
						end  as DSPLAY_ORDER	,
						case when  CONVERT(VARCHAR(10), a.DATE_ENTRY, 108)  between '00:00:00' and '13:59:59' then 1 
						else
						2
						end  as DATE_FLAG	

				from ATTENDANCE a 
				inner join EMPLOYEE b on a.EMP_ID = b.EMP_ID
				INNER JOIN DIVISION D ON B.DIV_ID = D.DIV_ID
				where CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
				AND B.DEPT_ID = b.DEPT_ID
				AND B.DIV_ID = d.DIV_ID
				AND A.EMP_ID = b.EMP_ID
				ORDER BY B.LAST_NAME
						
		SET @counter += 1
		END

IF @DT_TIME_TODAY BETWEEN '00:00:00' AND '13:59:59'
	SELECT DISTINCT DATE_ENTRY, * FROM @ATTENDANCE_TODAY WHERE DT_FLG = 1 ORDER BY DSPLY_ORDR, EMPLOYEE_NAME
ELSE
	SELECT DISTINCT DATE_ENTRY, * FROM @ATTENDANCE_TODAY WHERE DT_FLG = 2 ORDER BY DSPLY_ORDR, EMPLOYEE_NAME
END

