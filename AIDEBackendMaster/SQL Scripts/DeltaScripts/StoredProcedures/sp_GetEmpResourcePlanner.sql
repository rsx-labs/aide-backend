USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpResourcePlanner]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetEmpResourcePlanner'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetEmpResourcePlanner]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetEmpResourcePlanner]
	@EMAIL_ADDRESS VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE e, CONTACTS c
							WHERE e.EMP_ID = c.EMP_ID 
							AND c.EMAIL_ADDRESS = @EMAIL_ADDRESS)

	DECLARE @DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE e, CONTACTS c
							WHERE e.EMP_ID = c.EMP_ID 
							AND c.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	
	DECLARE @guestAccount SMALLINT = 5

	SELECT EMP_ID, LAST_NAME + ', ' + FIRST_NAME + ' ' + SUBSTRING(MIDDLE_NAME,1,1) AS EMPLOYEE_NAME, IMAGE_PATH
	FROM EMPLOYEE  
	WHERE DEPT_ID = @DEPT_ID
	AND DIV_ID = @DIV_ID
	AND ACTIVE = 1
	AND GRP_ID != @guestAccount -- guest account cannot be retrieved
	ORDER BY LAST_NAME ASC
END

GO
