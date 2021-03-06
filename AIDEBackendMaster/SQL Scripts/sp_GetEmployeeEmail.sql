USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeEmail]    Script Date: 6/10/2019 2:48:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetEmployeeEmail]
	-- Add the parameters for the stored procedure here
	@EMAIL varchar(100)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT C.EMAIL_ADDRESS AS WORK_EMAIL,E.FIRST_NAME AS FNAME, E.LAST_NAME AS LNAME FROM CONTACTS C INNER JOIN EMPLOYEE E ON C.EMP_ID = E.EMP_ID WHERE C.EMAIL_ADDRESS2 = @EMAIL
END 
