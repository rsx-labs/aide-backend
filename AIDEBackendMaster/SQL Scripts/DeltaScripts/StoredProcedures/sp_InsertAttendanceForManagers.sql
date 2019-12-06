USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendanceForManagers]    Script Date: 11/09/2019 8:47:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_InsertAttendanceForManagers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].sp_InsertAttendanceForManagers
GO

CREATE PROCEDURE [dbo].[sp_InsertAttendanceForManagers]
	@from datetime,
	@to datetime,
	@EMP_ID int ,
	@STATUS INT
AS

DECLARE @TODAYSTAT INT
DECLARE @GETCURDATESTART DATETIME
DECLARE @GETCURDATEEND DATETIME 

declare @COUNT tinyint


SELECT @GETCURDATESTART = CONVERT(VARCHAR(10), getdate(), 111) + ' 00:00:00.000'
SELECT @GETCURDATEEND = CONVERT(VARCHAR(10), getdate(), 111) + ' 14:00:00.000'


SELECT @TODAYSTAT = A.STATUS FROM ATTENDANCE A WHERE A.EMP_ID = @EMP_ID AND A.DATE_ENTRY BETWEEN  @GETCURDATESTART AND @GETCURDATEEND
SET @COUNT = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = Convert(date, @from))

IF @TODAYSTAT <> 11
BEGIN
WHILE @from<=@to
BEGIN
SET @COUNT = (select count(a.DATE_ENTRY) from ATTENDANCE a where a.EMP_ID = @EMP_ID and CONVERT(varchar,a.DATE_ENTRY,101) = Convert(date, @from))
	declare @FULL_NAME NVARCHAR(MAX) = (SELECT FIRST_NAME + ' ' + LAST_NAME FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	
	IF @COUNT = 0
		BEGIN
			INSERT [dbo].[ATTENDANCE]
			([EMP_ID],[DATE_ENTRY],[STATUS])VALUES(@EMP_ID,@from,@STATUS)

			exec [dbo].[sp_InsertResourcePlanner]
				 @EMP_ID = @EMP_ID ,			
				 @DATE_ENTRY = @from ,
				 @STATUS = @STATUS
		END 
	ELSE IF @COUNT > 0 AND @STATUS != 2
		BEGIN
		DECLARE @SETAFTERNOONTIME DATETIME
			SELECT @SETAFTERNOONTIME = CONVERT(VARCHAR(10), @from, 111) + ' 14:00:00.000'

				INSERT [dbo].[ATTENDANCE]
			([EMP_ID],[DATE_ENTRY],[STATUS])VALUES(@EMP_ID,@SETAFTERNOONTIME,@STATUS)

			exec [dbo].[sp_InsertResourcePlanner]
				 @EMP_ID = @EMP_ID ,
				 @DATE_ENTRY = @SETAFTERNOONTIME ,
				 @STATUS = @STATUS
		END
	ELSE
		BEGIN
			update ATTENDANCE set STATUS = 2 where EMP_ID = @EMP_ID and DATE_ENTRY = Convert(datetime, getdate())
		END
		SET @from=DATEADD(DAY,1,@from)
	END
END
ELSE
		if @COUNT = 1
		BEGIN
			
			SELECT @SETAFTERNOONTIME = CONVERT(VARCHAR(10), @from, 111) + ' 14:00:00.000'
		
			INSERT [dbo].[ATTENDANCE]
				([EMP_ID],[DATE_ENTRY],[STATUS])VALUES(@EMP_ID,@SETAFTERNOONTIME,@STATUS)

				exec [dbo].[sp_InsertResourcePlanner]
					 @EMP_ID = @EMP_ID ,			
					@DATE_ENTRY = @SETAFTERNOONTIME ,
					 @STATUS = @STATUS
		END
		ELSE
		BEGIN
			DECLARE @SETMORNINGTIME DATETIME = CONVERT(VARCHAR(10), @from, 111) + ' 00:00:00.000'
			
			INSERT [dbo].[ATTENDANCE]
			([EMP_ID],[DATE_ENTRY],[STATUS])VALUES(@EMP_ID,@from,@STATUS)

			exec [dbo].[sp_InsertResourcePlanner]
				 @EMP_ID = @EMP_ID ,			
				 @DATE_ENTRY = @from ,
				 @STATUS = @STATUS
		END




