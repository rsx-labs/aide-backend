USE [AIDE]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetNicknameByDeptID]    Script Date: 11/06/2019 3:04:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

    -- Insert statements for procedure here

	IF @TO_DISPLAY = 1 --Get Employee by Dept and Div
		BEGIN
			SELECT EMP_ID,NICK_NAME, FIRST_NAME, CONCAT(LAST_NAME, ',',FIRST_NAME) AS 'EMPLOYEE_NAME'
			FROM [dbo].[EMPLOYEE]
			WHERE DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
							 ON a.EMP_ID = b.EMP_ID
							 WHERE b.EMAIL_ADDRESS = @EMAIL)
				and DIV_ID = (SELECT DIV_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
							  ON a.EMP_ID = b.EMP_ID 
							  WHERE b.EMAIL_ADDRESS = @EMAIL) AND EMPLOYEE.ACTIVE <> 2
			ORDER BY LAST_NAME ASC
		END
	ELSE -- Get Employee by Div
		BEGIN
			SELECT EMP_ID,NICK_NAME, CONCAT(LAST_NAME, ',',FIRST_NAME) AS 'EMPLOYEE_NAME'
			FROM [dbo].[EMPLOYEE]
			WHERE DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
							 ON a.EMP_ID = b.EMP_ID
							 WHERE b.EMAIL_ADDRESS = @EMAIL) AND EMPLOYEE.ACTIVE <> 2
			ORDER BY LAST_NAME ASC
		END
END

GO


