USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetContactListByEmpID]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_GetContactListByEmpID]
	-- Add the parameters for the stored procedure here
	@EMPID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT *
	FROM [dbo].[EMPLOYEE] b 
	INNER JOIN [dbo].[CONTACTS] a 
	ON a.emp_id = b.emp_id 
	INNER JOIN [dbo].[POSITION] c
	ON b.POS_ID = c.POS_ID
	WHERE a.EMP_ID = @EMPID
	ORDER BY b.LAST_NAME
END

GO
