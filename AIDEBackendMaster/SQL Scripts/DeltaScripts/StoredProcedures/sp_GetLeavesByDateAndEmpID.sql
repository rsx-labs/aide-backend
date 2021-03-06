USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLeavesByDateAndEmpID]    Script Date: 02/11/2020 8:57:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetLeavesByDateAndEmpID'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetLeavesByDateAndEmpID]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetLeavesByDateAndEmpID]
	@EMP_ID INT,
	@STATUS INT,
	@DATE_FROM DATETIME,
	@DATE_TO DATETIME
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @COUNT INT
	DECLARE @COUNT_STATUS INT

	CREATE TABLE #existingLeavesTable(EMP_ID INT, EMPLOYEE_NAME VARCHAR(MAX), DATE_ENTRY DATETIME, STATUS NVARCHAR(10))

	-- Condition for the halfday status
	IF @STATUS IN (5, 6, 9, 12, 14)
		BEGIN
			-- Check if there is existing whole day filed leaves.
			INSERT INTO #existingLeavesTable 
			SELECT EMP_ID, '', DATE_ENTRY, CAST(STATUS AS VARCHAR)
			FROM ATTENDANCE
			WHERE EMP_ID = @EMP_ID
			AND DATE_ENTRY BETWEEN CONVERT(VARCHAR, @DATE_FROM, 101) AND CONVERT(VARCHAR, @DATE_TO, 101)
			AND STATUS IN (3, 4, 7, 8, 10, 13)
			AND STATUS_CD = 1
			
			SET @COUNT = (SELECT COUNT(*) FROM #existingLeavesTable)

			IF @COUNT = 0
				BEGIN
					INSERT INTO #existingLeavesTable 
					SELECT EMP_ID, '', DATE_ENTRY, CAST(STATUS AS VARCHAR)
					FROM ATTENDANCE
					WHERE EMP_ID = @EMP_ID
					AND DATE_ENTRY BETWEEN @DATE_FROM AND @DATE_TO
					AND STATUS IN (5, 6, 9, 12, 14)
					AND STATUS_CD = 1
				END
		END
	ELSE 
		-- Check all leaves from date range 
		BEGIN
			INSERT INTO #existingLeavesTable 
			SELECT EMP_ID, '', DATE_ENTRY, CAST(STATUS AS VARCHAR)
			FROM ATTENDANCE
			WHERE EMP_ID = @EMP_ID
			AND DATE_ENTRY BETWEEN @DATE_FROM AND @DATE_TO
			AND STATUS NOT IN (1, 2, 11)
			AND STATUS_CD = 1
		END

	SELECT * FROM #existingLeavesTable

	DROP TABLE #existingLeavesTable