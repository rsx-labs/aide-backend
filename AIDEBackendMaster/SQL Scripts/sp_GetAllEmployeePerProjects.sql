USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmployeePerProjects]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllEmployeePerProjects]
	-- Add the parameters for the stored procedure here
	@PROJ_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT A.EMP_ID, CONCAT(B.FIRST_NAME, ' ', B.LAST_NAME) AS 'NICK_NAME'
	FROM ASSIGNED_PROJECTS A INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE PROJ_ID = @PROJ_ID
	
END

GO
