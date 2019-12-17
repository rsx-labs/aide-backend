USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsCustodian]    Script Date: 12/04/2019 4:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllAssetsCustodian'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllAssetsCustodian]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetAllAssetsCustodian]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EMP_ID, NICK_NAME, FIRST_NAME, CONCAT(FIRST_NAME, ' ',LAST_NAME) AS 'EMPLOYEE_NAME' 
	FROM EMPLOYEE 
	WHERE DEPT_ID = @DEPT_ID AND DIV_ID = @DIV_ID
	AND GRP_ID = 3 AND ACTIVE = 1

END
