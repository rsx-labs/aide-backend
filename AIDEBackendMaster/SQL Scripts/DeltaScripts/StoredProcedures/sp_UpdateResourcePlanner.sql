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

DECLARE @AFTERNOON_SHIFT VARCHAR(8) = (SELECT VALUE FROM dbo.[OPTION] WHERE OPTIONID = 6)

WHILE @from <= @to
       BEGIN
        DECLARE @COUNT_RP TINYINT = (SELECT COUNT(DATE_ENTRY) FROM RESOURCE_PLANNER WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = CONVERT(DATE, @from)),
                           @COUNT_A TINYINT = (SELECT COUNT(DATE_ENTRY) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND CONVERT(VARCHAR, DATE_ENTRY, 101) = CONVERT(VARCHAR, @from,101))

		DECLARE @GETCURDATESTART DATETIME
		DECLARE @GETCURDATEEND DATETIME                        
              SELECT @GETCURDATESTART = CONVERT(VARCHAR(10), @from, 111) + ' 00:00:00.000'
              SELECT @GETCURDATEEND = CONVERT(VARCHAR(10), @from, 111) + ' 23:59:59.000'

              DECLARE @GETATTRECORD DATETIME = (SELECT DATE_ENTRY FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND CONVERT(datetime, DATE_ENTRY, 101) BETWEEN  CONVERT(datetime, @GETCURDATESTART,101) AND CONVERT(datetime, @GETCURDATEEND,101))
              
              IF @COUNT_RP >= 1 OR @COUNT_A = 1
                     BEGIN
                           IF @COUNT_RP = 0
                                  BEGIN
                                  if @STATUS = 1
                                         begin
                                         UPDATE ATTENDANCE 
                                         SET STATUS = @STATUS
                                         WHERE EMP_ID = @EMP_ID AND
                                         DATE_ENTRY = @GETATTRECORD
                                         end
                                  else
										BEGIN
                                         if @STATUS = 2
												
													if @COUNT_A = 1
													begin
														UPDATE ATTENDANCE 
														SET STATUS = @STATUS
														WHERE EMP_ID = @EMP_ID AND
														DATE_ENTRY = @GETATTRECORD
													end
													else
													return
                                         else
                                                begin
												

												DECLARE @GETIFONSITEDATE DATETIME 
												DECLARE @GETONSITESTAT INT
												DECLARE @GETCURDATETIMEEND DATETIME
												DECLARE @NEWTIMEONSITEAM DATETIME
												DECLARE @NEWTIMEONSITEPM DATETIME
												DECLARE @GETPRESENTDATE DATETIME 
												DECLARE @GETPRESENTSTAT INT 

												SELECT @GETIFONSITEDATE= DATE_ENTRY, @GETONSITESTAT=STATUS FROM ATTENDANCE WHERE YEAR(DATE_ENTRY) = YEAR(@from) AND MONTH(DATE_ENTRY) = MONTH(@from) AND DAY(DATE_ENTRY) = DAY(@from) AND STATUS = 1
												SELECT @GETPRESENTDATE= DATE_ENTRY, @GETPRESENTSTAT=STATUS FROM ATTENDANCE WHERE YEAR(DATE_ENTRY) = YEAR(@from) AND MONTH(DATE_ENTRY) = MONTH(@from) AND DAY(DATE_ENTRY) = DAY(@from) AND STATUS IN (2,11)
												SELECT @GETCURDATETIMEEND = CONVERT(VARCHAR(10), @from, 111) + ' ' + (SELECT VALUE FROM dbo.[OPTION] WHERE OPTIONID = 7)
												SELECT @NEWTIMEONSITEAM = CONVERT(VARCHAR(10), @GETIFONSITEDATE, 111) + ' 00:00:00.000'
												SELECT @NEWTIMEONSITEPM = CONVERT(VARCHAR(10), @GETIFONSITEDATE, 111) + ' ' + @AFTERNOON_SHIFT


												 INSERT INTO ATTENDANCE (EMP_ID,DATE_ENTRY,STATUS) VALUES (@EMP_ID, @from, @STATUS) 
													EXEC [dbo].[sp_InsertResourcePlanner]
													@EMP_ID = @EMP_ID,
													@DATE_ENTRY = @from,
													@STATUS = @STATUS

													
													IF @STATUS IN (9,5,6,12,14)
														BEGIN
															IF @GETIFONSITEDATE <> ''
																BEGIN
																	IF @from BETWEEN @GETCURDATESTART AND @GETCURDATETIMEEND
																		BEGIN
																			UPDATE ATTENDANCE SET DATE_ENTRY=@NEWTIMEONSITEPM
																				WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = @GETIFONSITEDATE AND STATUS = @GETONSITESTAT
																		END
																END	
																ELSE IF @GETPRESENTSTAT <> ''
																	BEGIN 
																	SELECT @NEWTIMEONSITEPM = CONVERT(VARCHAR(10), @GETPRESENTDATE, 111) + ' ' + @AFTERNOON_SHIFT
																		IF @from BETWEEN @GETCURDATESTART AND @GETCURDATETIMEEND
																			BEGIN
																				UPDATE ATTENDANCE SET DATE_ENTRY=@NEWTIMEONSITEPM
																					WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = @GETPRESENTDATE AND STATUS = @GETPRESENTSTAT
																			END
																	END	
														END

                                                end   
										END
                                  END
                           ELSE
                           BEGIN
                                  BEGIN
                                         UPDATE RESOURCE_PLANNER 
                                         SET STATUS = @STATUS, STATUS_CD = 1,
										 COUNTS = (CASE WHEN @STATUS IN (3,4,8,10) THEN 1 ELSE 0.5 END)
                                         WHERE EMP_ID = @EMP_ID AND
                                         DATE_ENTRY = @from
                                  END
                                  if @STATUS <> 1
                                  begin
                                         INSERT INTO ATTENDANCE (EMP_ID,DATE_ENTRY,STATUS) VALUES (@EMP_ID, @from, @STATUS) 
                                  end
                           END
                     END 
              ELSE
                     IF @STATUS = 7 --HOLIDAY
                           BEGIN
                                  INSERT INTO [dbo].[ATTENDANCE] (EMP_ID,DATE_ENTRY,STATUS)
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


