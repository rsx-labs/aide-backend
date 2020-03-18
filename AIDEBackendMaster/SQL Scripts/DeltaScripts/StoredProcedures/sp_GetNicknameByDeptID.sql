USE [AIDE]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetNicknameByDeptID]    Script Date: 11/06/2019 3:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[sp_GetNicknameByDeptID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetNicknameByDeptID]
GO

CREATE PROCEDURE [dbo].[sp_GetNicknameByDeptID]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(50),
	@TO_DISPLAY INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE E INNER JOIN CONTACTS C ON e.EMP_ID = C.EMP_ID
						   WHERE EMAIL_ADDRESS = @EMAIL)
	DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE E INNER JOIN CONTACTS C ON e.EMP_ID = C.EMP_ID
						   WHERE EMAIL_ADDRESS = @EMAIL)

	DECLARE @guestAccount SMALLINT = 5

    -- Insert statements for procedure here
	IF @TO_DISPLAY = 1 --Get Employee by Dept and Div
		BEGIN
			SELECT EMP_ID,NICK_NAME, FIRST_NAME, CONCAT(LAST_NAME, ', ',FIRST_NAME) AS 'EMPLOYEE_NAME'
			FROM [dbo].[EMPLOYEE]
			WHERE DEPT_ID = @DEPT_ID
			AND DIV_ID = @DIV_ID 
			AND EMPLOYEE.ACTIVE <> 2
			AND GRP_ID != @guestAccount --guest account cannot be retrieved
			ORDER BY LAST_NAME ASC
		END
	ELSE -- Get Employee by Div
		BEGIN
			SELECT EMP_ID,NICK_NAME, FIRST_NAME, CONCAT(LAST_NAME, ', ',FIRST_NAME) AS 'EMPLOYEE_NAME'
			FROM [dbo].[EMPLOYEE]
			WHERE DEPT_ID = @DEPT_ID AND EMPLOYEE.ACTIVE <> 2
			AND GRP_ID != @guestAccount --guest account cannot be retrieved
			ORDER BY LAST_NAME ASC
		END
END

GO


