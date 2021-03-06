USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_CancelLeave]    Script Date: 02/17/2020 02:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_CancelLeave'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_CancelLeave]
    END
GO

CREATE PROCEDURE [dbo].[sp_CancelLeave] 
	@EMP_ID INT,
	@LEAVE_TYPE INT,
	@START_DATE DATETIME,
	@END_DATE DATETIME
AS

-- For Halfday leaves
IF @LEAVE_TYPE IN (5, 6, 9, 12, 14)
	BEGIN
		UPDATE ATTENDANCE SET STATUS_CD = 0 
		WHERE EMP_ID = @EMP_ID AND STATUS = @LEAVE_TYPE 
		AND DATE_ENTRY = @START_DATE
	END
ELSE
	BEGIN
		UPDATE ATTENDANCE SET STATUS_CD = 0 
		WHERE EMP_ID = @EMP_ID AND STATUS = @LEAVE_TYPE 
		AND CONVERT(DATE, DATE_ENTRY) BETWEEN CONVERT(DATE, @START_DATE) AND CONVERT(DATE, @END_DATE)
	END




