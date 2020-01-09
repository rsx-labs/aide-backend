USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateResourcePlanner]    Script Date: 01/09/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateResourcePlanner'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateResourcePlanner]
    END
GO

CREATE PROCEDURE [dbo].[sp_UpdateResourcePlanner]
	@from DATETIME,
	@to DATETIME,
	@EMP_ID INT ,
	@STATUS INT
AS

WHILE @from <= @to
	BEGIN
        DECLARE @COUNT_RP TINYINT = (SELECT COUNT(DATE_ENTRY) FROM RESOURCE_PLANNER WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = CONVERT(DATE, @from)),
				@COUNT_A TINYINT = (SELECT COUNT(DATE_ENTRY) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND CONVERT(VARCHAR, DATE_ENTRY, 101) = CONVERT(VARCHAR, @from,101))

		IF @COUNT_RP >= 1 OR @COUNT_A = 1
			BEGIN
				UPDATE ATTENDANCE SET STATUS = @STATUS WHERE EMP_ID = @EMP_ID AND CONVERT(DATE,DATE_ENTRY) = CONVERT(DATE, @from)
				IF @COUNT_RP = 0
					BEGIN
						EXEC [dbo].[sp_InsertResourcePlanner]
						@EMP_ID = @EMP_ID,
						@DATE_ENTRY = @from,
						@STATUS = @STATUS
						--@EMPLOYEE_NAME = @FULL_NAME,
					END
				ELSE
					BEGIN
						UPDATE RESOURCE_PLANNER 
						SET STATUS = @STATUS, STATUS_CD = 1
						WHERE EMP_ID = @EMP_ID AND
						DATE_ENTRY = @from

						IF NOT EXISTS (SELECT (1) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = @from)
							BEGIN
								INSERT INTO ATTENDANCE VALUES (@EMP_ID, @from, @STATUS) 
							END
					END
			END 
		ELSE
			IF @STATUS = 7 --HOLIDAY
				BEGIN
					INSERT INTO [dbo].[ATTENDANCE]
					SELECT E.EMP_ID, @from,
							@STATUS FROM dbo.EMPLOYEE E INNER JOIN CONTACTS C
							ON E.EMP_ID = C.EMP_ID
					WHERE C.LOCATION = 1 OR C.LOCATION = 2 OR C.LOCATION = 4
						  AND E.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
							ON A.EMP_ID = B.EMP_ID WHERE A.EMP_ID = @EMP_ID) AND
						  E.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
							ON A.EMP_ID = B.EMP_ID WHERE A.EMP_ID = @EMP_ID)
				END
			ELSE
				BEGIN
					INSERT [dbo].[ATTENDANCE]
					(
						[EMP_ID],
						[DATE_ENTRY],
						[STATUS]
					)
					VALUES
					(
						@EMP_ID,
						@from,
						@STATUS
					)
					BEGIN
						EXEC [dbo].[sp_InsertResourcePlanner]
						@EMP_ID = @EMP_ID,
						@DATE_ENTRY = @from,
						@STATUS = @STATUS
						--@EMPLOYEE_NAME = @FULL_NAME,
					END
				END

		 SET @from = (SELECT dbo.DAYSADDNOWK(@from, 1))
	END
