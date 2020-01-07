USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllManagersByDeptorDiv]    Script Date: 12/04/2019 4:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllManagersByDeptorDiv'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllManagersByDeptorDiv]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetAllManagersByDeptorDiv]
	-- Add the parameters for the stored procedure here
	@DEPT_ID INT,
	@DIV_ID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @DIV_ID != NULL OR @DIV_ID != 0
		BEGIN
			SELECT EMP_ID, NICK_NAME, FIRST_NAME, CONCAT(FIRST_NAME, ' ',LAST_NAME) AS 'EMPLOYEE_NAME' 
			FROM EMPLOYEE 
			WHERE DEPT_ID = @DEPT_ID AND DIV_ID = @DIV_ID
			AND GRP_ID = 1 AND ACTIVE = 1
		END
	ELSE
		BEGIN
			SELECT EMP_ID, NICK_NAME, FIRST_NAME, CONCAT(FIRST_NAME, ' ',LAST_NAME) AS 'EMPLOYEE_NAME' 
			FROM EMPLOYEE 
			WHERE DEPT_ID = @DEPT_ID
			AND GRP_ID = 1 AND ACTIVE = 1
		END
END
