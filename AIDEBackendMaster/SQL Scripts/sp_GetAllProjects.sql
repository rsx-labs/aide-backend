USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProjects]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllProjects]
@Emp_ID int = null
AS

DECLARE @DEPT_ID VARCHAR(MAX) = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @Emp_ID)
DECLARE @DIV_ID VARCHAR(MAX) = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @Emp_ID)

	SELECT A.[PROJ_ID], A.[PROJ_NAME], A.[CATEGORY], A.[BILLABILITY]
	FROM [dbo].[PROJECT] A
	INNER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID
	WHERE A.DSPLY_FLG = 1 
	AND B.DEPT_ID = @DEPT_ID AND DIV_ID = @DIV_ID




GO
