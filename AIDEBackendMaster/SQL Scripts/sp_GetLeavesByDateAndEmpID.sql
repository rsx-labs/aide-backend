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
	@DATE_FROM DATE,
	@DATE_TO DATE
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Condition for the halfday status
	IF @STATUS = 5 OR @STATUS = 6 OR @STATUS = 9 OR @STATUS = 12 OR @STATUS = 14
		BEGIN
			SELECT EMP_ID, '' AS EMPLOYEE_NAME, DATE_ENTRY, CAST(STATUS AS VARCHAR) AS STATUS
			FROM RESOURCE_PLANNER 
			WHERE EMP_ID = @EMP_ID
			AND DATE_ENTRY BETWEEN @DATE_FROM AND @DATE_TO
			AND STATUS IN (3, 4, 7, 8, 10, 13)
		END
	ELSE 
		BEGIN
			SELECT EMP_ID, '' AS EMPLOYEE_NAME, DATE_ENTRY, CAST(STATUS AS VARCHAR) AS STATUS
			FROM RESOURCE_PLANNER 
			WHERE EMP_ID = @EMP_ID
			AND DATE_ENTRY BETWEEN @DATE_FROM AND @DATE_TO
		END
