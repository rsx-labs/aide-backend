USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSuccessRegisterBySearch]    Script Date: 11/20/2019 6:21:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetSuccessRegisterBySearch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetSuccessRegisterBySearch]
GO

create PROCEDURE [dbo].[sp_GetSuccessRegisterBySearch]
	-- Add the parameters for the stored procedure here
	@INPUT VARCHAR(MAX),
	@EMAIL VARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.ID,a.EMP_ID,a.DATE_INPUT,a.DETAILSOFSUCCESS,a.ADDITIONALINFORMATION,a.WHOSINVOLVE,b.FIRST_NAME AS 'NICK_NAME',b.DEPT_ID 
	FROM [dbo].[SUCCESSREGISTER] a INNER JOIN [dbo].[EMPLOYEE] b 
	on a.emp_id = b.emp_id 
	WHERE (b.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
						ON a.EMP_ID = b.EMP_ID
						WHERE b.EMAIL_ADDRESS = @EMAIL)
		AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE a INNER JOIN CONTACTS b 
						ON a.EMP_ID = b.EMP_ID
						WHERE b.EMAIL_ADDRESS = @EMAIL))
		AND ((a.[DETAILSOFSUCCESS] LIKE '%' + @INPUT + '%' ) OR
		  (a.[WHOSINVOLVE] LIKE '%' + @INPUT + '%') OR
		  (a.[ID] LIKE '%' + @INPUT + '%') OR
		  (a.[ADDITIONALINFORMATION] LIKE '%' + @INPUT + '%') OR
		  (b.[FIRST_NAME] LIKE '%' + @INPUT + '%'))
	ORDER BY a.DATE_INPUT desc
END
