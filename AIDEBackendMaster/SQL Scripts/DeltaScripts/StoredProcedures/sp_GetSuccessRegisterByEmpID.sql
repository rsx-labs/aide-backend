USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSuccessRegisterByEmpID]    Script Date: 11/20/2019 6:21:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetSuccessRegisterByEmpID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetSuccessRegisterByEmpID]
GO

CREATE PROCEDURE [dbo].[sp_GetSuccessRegisterByEmpID]
	-- Add the parameters for the stored procedure here
	@EMAIL VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT *
	FROM [dbo].[SUCCESSREGISTER] a 
	INNER JOIN [dbo].[EMPLOYEE] b 
	ON a.emp_id = b.emp_id 
	INNER JOIN [dbo].[CONTACTS] c
	ON b.EMP_ID = c.EMP_ID
	WHERE c.EMAIL_ADDRESS = @EMAIL
	ORDER BY a.DATE_INPUT DESC
END

