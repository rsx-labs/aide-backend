USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAttendance]    Script Date: 11/18/2019 12:56:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertAttendance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].sp_InsertAttendance
GO

CREATE PROCEDURE [dbo].[sp_InsertAttendance]
	@EMP_ID INT,
	@DATE_ENTRY DATETIME
AS

DECLARE @SHIFT VARCHAR(10) = (SELECT SHIFT_STATUS FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
DECLARE @ONSITE_STATUS SMALLINT = (SELECT ONSITE_FLG FROM LOCATION L, CONTACTS C WHERE C.LOCATION = L.LOCATION_ID AND EMP_ID = @EMP_ID)
DECLARE @STATUS INT = 2 -- Present Status
DECLARE @currStatus INT 
DECLARE @currLeaveTime DATETIME
DECLARE @COUNT SMALLINT = (SELECT COUNT(DATE_ENTRY) FROM ATTENDANCE
						   WHERE EMP_ID = @EMP_ID 
						   AND STATUS_CD = 1
						   AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY))

IF @ONSITE_STATUS != 0
	SET @STATUS = 1 -- Onsite Status

IF CONVERT(VARCHAR(10), @DATE_ENTRY, 108) >= '10:01:00' AND @SHIFT != 'Flexi'
	SET @STATUS = 11 -- Late Status

IF @COUNT = 0
	BEGIN
		INSERT [dbo].[ATTENDANCE] ([EMP_ID],[DATE_ENTRY],[STATUS],[COUNTS])
		VALUES (@EMP_ID, @DATE_ENTRY, @STATUS, 1.0)
	END
ELSE
	BEGIN
		IF @COUNT = 1
			BEGIN
				SET @currStatus = (SELECT [STATUS] FROM ATTENDANCE
								   WHERE EMP_ID = @EMP_ID 
								   AND STATUS_CD = 1
								   AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY))
				
				IF @currStatus NOT IN (1,2,11)
					BEGIN
						-- Whole day leaves
						IF @currStatus IN (3,4,7,8,10,13)
							BEGIN
								-- Cancel the file leave
								EXEC dbo.[sp_CancelLeave] @EMP_ID, @currStatus, @DATE_ENTRY, @DATE_ENTRY

								-- Insert Attendance
								INSERT [dbo].[ATTENDANCE] ([EMP_ID],[DATE_ENTRY],[STATUS],[COUNTS])
								VALUES (@EMP_ID, @DATE_ENTRY, @STATUS, 1.0)
							END
						ELSE 
							-- Half day leaves
							BEGIN
								SET @currLeaveTime = (SELECT DATE_ENTRY FROM ATTENDANCE WHERE EMP_ID = @EMP_ID 
													  AND STATUS_CD = 1
													  AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY))

								-- Cancel morning halfday leaves automatically if user open the AIDE between 00:00:00 and 08:59:59
								IF CONVERT(VARCHAR(10), @currLeaveTime, 108) BETWEEN '00:00:00' AND '08:59:59' AND CONVERT(VARCHAR(10), @DATE_ENTRY, 108) BETWEEN '00:00:00' AND '08:59:59'
									EXEC dbo.[sp_CancelLeave] @EMP_ID, @currStatus, @currLeaveTime, @currLeaveTime
								ELSE
									BEGIN
										DECLARE @afternoonTime DATETIME = (SELECT DATEADD(DAY, DATEDIFF(DAY, 0, CONVERT(DATE, @DATE_ENTRY)), '14:00:00'))

										IF EXISTS (SELECT (1) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND DATE_ENTRY = @afternoonTime AND STATUS = @currStatus AND STATUS_CD = 1)
											BEGIN
												-- Employee time-in morning -> update leave time for afternoon
												EXEC dbo.[sp_UpdateLeaves] @EMP_ID, @currStatus, @currLeaveTime, @DATE_ENTRY
											END
									END

								IF @ONSITE_STATUS != 0
									SET @STATUS = 1 -- Onsite Status
								ELSE
									SET @STATUS = 2

								---- Insert Attendance
								INSERT [dbo].[ATTENDANCE] ([EMP_ID],[DATE_ENTRY],[STATUS],[COUNTS])
								VALUES (@EMP_ID, @DATE_ENTRY, @STATUS, 1.0)
							END
					END
			END
		ELSE
			BEGIN
				SET @currStatus = (SELECT TOP 1 [STATUS] FROM ATTENDANCE 
								   WHERE EMP_ID = @EMP_ID 
								   AND STATUS_CD = 1
								   AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY)
								   AND DATE_ENTRY BETWEEN CONVERT(DATE, @DATE_ENTRY) AND @DATE_ENTRY
								   ORDER BY DATE_ENTRY DESC)

				SET @currLeaveTime = (SELECT DATE_ENTRY FROM ATTENDANCE WHERE EMP_ID = @EMP_ID
									  AND STATUS_CD = 1
									  AND STATUS = @currStatus
									  AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY))

				IF @currStatus NOT IN (1,2,11)
					BEGIN
						-- Cancel the file leave
						EXEC dbo.[sp_CancelLeave] @EMP_ID, @currStatus, @currLeaveTime, @DATE_ENTRY

						IF NOT EXISTS (SELECT (1) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID 
									   AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, @DATE_ENTRY)
									   AND STATUS IN (1,2,11))
							-- Insert Attendance
							BEGIN
								INSERT [dbo].[ATTENDANCE] ([EMP_ID],[DATE_ENTRY],[STATUS],[COUNTS])
								VALUES (@EMP_ID, @DATE_ENTRY, @STATUS, 1.0)
							END
					END
				
			END
	END





