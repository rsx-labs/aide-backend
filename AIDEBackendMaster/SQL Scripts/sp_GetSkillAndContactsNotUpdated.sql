USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMissingReportsByEmpID]    Script Date: 11/28/2019 9:48:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_GetSkillAndContactsNotUpdated]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetSkillAndContactsNotUpdated]
GO

CREATE PROCEDURE [dbo].[sp_GetSkillAndContactsNotUpdated]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@CHOICE INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		    @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
			@EMAILSTRING VARCHAR(MAX),
			@EMPNAMESTRING VARCHAR(MAX)

	IF @CHOICE = 1
	BEGIN
		SELECT @EMPNAMESTRING = COALESCE(@EMPNAMESTRING + ',', '') + (E.FIRST_NAME + ' ' + E.LAST_NAME), @EMAILSTRING = COALESCE(@EMAILSTRING + ',', '') + c.EMAIL_ADDRESS 
		FROM CONTACTS C INNER JOIN EMPLOYEE E ON C.EMP_ID = E.EMP_ID 
		WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 
		AND MONTH(C.DT_REVIEWED) != MONTH(GETDATE())
	END
	ELSE
	BEGIN
		SELECT @EMPNAMESTRING = COALESCE(@EMPNAMESTRING + ',', '') + (E.FIRST_NAME + ' ' + E.LAST_NAME), @EMAILSTRING = COALESCE(@EMAILSTRING + ',', '') + c.EMAIL_ADDRESS 
		FROM SKILLS_PROF S INNER JOIN EMPLOYEE E ON S.EMP_ID = E.EMP_ID
		INNER JOIN CONTACTS C ON E.EMP_ID = C.EMP_ID
		WHERE E.DIV_ID = @DIVID AND E.DEPT_ID = @DEPTID AND E.ACTIVE = 1 AND MONTH(S.LAST_REVIEWED) != MONTH(GETDATE())
		GROUP BY s.EMP_ID,LAST_REVIEWED,EMAIL_ADDRESS,FIRST_NAME,LAST_NAME
	END
	
		SELECT @EMPNAMESTRING AS 'EMPLOYEE_NAME', @EMAILSTRING AS 'EMAIL_ADDRESS'
END
