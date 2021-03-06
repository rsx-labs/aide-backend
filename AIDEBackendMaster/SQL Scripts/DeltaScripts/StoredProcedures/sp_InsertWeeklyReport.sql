USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertWeeklyReport]    Script Date: 12/17/2019 8:42:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertWeeklyReport'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_InsertWeeklyReport]
    END
GO

CREATE PROCEDURE [dbo].[sp_InsertWeeklyReport] 
			@WR_RANGE_ID INT, 
			@PROJ_ID INT, 
			@REWORK SMALLINT, 
			@REF_ID VARCHAR(10),
			@SUBJECT VARCHAR(MAX),
			@SEVERITY SMALLINT,
			@INC_TYPE SMALLINT,
			@EMP_ID INT, 
			@PHASE SMALLINT,
			@STATUS SMALLINT, 
			@DATE_STARTED DATE,  
			@DATE_TARGET DATE,  
			@DATE_FINISHED DATE,
			@EFFORT_EST FLOAT, 
			@ACT_EFFORT FLOAT, 
			@ACT_EFFORT_WK FLOAT, 
			@COMMENTS VARCHAR(MAX),
			@INBOUND_CONTACTS SMALLINT,
			@PROJ_CODE INT,
			@TASK_ID INT

AS

SET NOCOUNT ON

BEGIN
	INSERT INTO WEEKLY_REPORT 
	(
		[WR_WEEK_RANGE_ID],
		[WR_PROJ_ID],
		[WR_REWORK],
		[WR_REF_ID],
		[WR_SUBJECT],
		[WR_SEVERITY],
		[WR_INC_TYPE],
		[WR_EMP_ID],
		[WR_PHASE],
		[WR_STATUS],
		[WR_DATE_STARTED],
		[WR_DATE_TARGET],
		[WR_DATE_FINISHED],
		[WR_EFFORT_EST],
		[WR_ACT_EFFORT],
		[WR_ACT_EFFORT_WK],
		[WR_COMMENTS],
		[WR_INBOUND_CONTACTS],
		[WR_PROJ_CODE],
		[WR_TASK_ID]
	)
	VALUES
	(
		@WR_RANGE_ID,
		@PROJ_ID,
		@REWORK,
		@REF_ID,
		@SUBJECT,
		@SEVERITY,
		@INC_TYPE,
		@EMP_ID,
		@PHASE,
		@STATUS,
		@DATE_STARTED,
		@DATE_TARGET,
		@DATE_FINISHED,
		@EFFORT_EST,
		@ACT_EFFORT,
		@ACT_EFFORT_WK,
		@COMMENTS,
		@INBOUND_CONTACTS,
		@PROJ_CODE,
		@TASK_ID
	);

	IF @TASK_ID != 0
		BEGIN
			EXEC [dbo].[sp_UpdateTasks] @TASKS_ID = @TASK_ID, 
										@PROJ_ID = @PROJ_ID,
										@PROJECT_CODE = @PROJ_CODE,
										@REWORK = @REWORK,
										@REF_ID = @REF_ID,
										@INC_DESCR = @SUBJECT,
										@SEVERITY = @SEVERITY,
										@INC_TYPE = @INC_TYPE,
										@EMP_ID = @EMP_ID,
										@PHASE = @PHASE,
										@STATUS = @STATUS,
										@DATE_STARTED = @DATE_STARTED,
										@TARGET_DATE = @DATE_TARGET,
										@COMPLTD_DATE = @DATE_FINISHED,
										@EFFORT_EST = @EFFORT_EST,
										@ACT_EFFORT = @ACT_EFFORT,
										@ACT_EFFORT_WK = @ACT_EFFORT_WK,
										@COMMENTS = @COMMENTS 
		END
	--ELSE
	--	BEGIN
	--		DECLARE @BILLABILITY SMALLINT = (SELECT BILLABILITY FROM PROJECT WHERE PROJ_ID = @PROJ_ID)
	--		-- Check if project is billable, if yes - it will insert the new weekly report to task
	--		IF @BILLABILITY != 0
	--			BEGIN
	--				DECLARE @newTaskID INT = (SELECT MAX(TASK_ID) FROM TASKS)
	--				DECLARE @dateToday DATE = CONVERT(VARCHAR(10),GETDATE(),120)

	--				EXEC [dbo].[sp_InsertTasks] @TASK_ID = @newTaskID, 
	--											@PROJ_ID = @PROJ_ID,
	--											@PROJECT_CODE = @PROJ_CODE,
	--											@REWORK = @REWORK,
	--											@REF_ID = @REF_ID,
	--											@INC_DESCR = @SUBJECT,
	--											@SEVERITY = @SEVERITY,
	--											@INC_TYPE = @INC_TYPE,
	--											@EMP_ID = @EMP_ID,
	--											@PHASE = @PHASE,
	--											@STATUS = @STATUS,
	--											@DATE_CREATED = @dateToday,
	--											@DATE_STARTED = @DATE_STARTED,
	--											@TARGET_DATE = @DATE_TARGET,
	--											@COMPLTD_DATE = @DATE_FINISHED,
	--											@EFFORT_EST = @EFFORT_EST,
	--											@ACT_EFFORT = @ACT_EFFORT,
	--											@ACT_EFFORT_WK = @ACT_EFFORT_WK,
	--											@COMMENTS = @COMMENTS 
	--			END
	--	END
END


