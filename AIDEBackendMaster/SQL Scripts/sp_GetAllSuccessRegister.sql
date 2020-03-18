USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSuccessRegisterAll]    Script Date: 11/20/2019 6:20:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetSuccessRegisterAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetSuccessRegisterAll]
GO

CREATE PROCEDURE [dbo].[sp_GetSuccessRegisterAll]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT A.ID, A.DATE_INPUT, A.EMP_ID, A.DETAILSOFSUCCESS, A.WHOSINVOLVE, 
		   A.ADDITIONALINFORMATION, B.FIRST_NAME AS 'NICK_NAME',B.DEPT_ID
	FROM [dbo].[SUCCESSREGISTER] a 
	INNER JOIN [dbo].[EMPLOYEE] b 
	on a.emp_id = b.emp_id 
	INNER JOIN [dbo].[CONTACTS] c
	ON b.EMP_ID = c.EMP_ID
	WHERE DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
					 ON a.EMP_ID = b.EMP_ID
					 WHERE b.EMAIL_ADDRESS = @EMAIL)
		and DIV_ID = (SELECT DIV_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
					  ON a.EMP_ID = b.EMP_ID 
					  WHERE b.EMAIL_ADDRESS = @EMAIL)
	ORDER BY a.DATE_INPUT desc
			
END
