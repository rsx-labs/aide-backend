USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllProblems'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllProblems]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllProblems]
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
	
	SELECT P.PROBLEM_ID, P.EMP_ID, (E.FIRST_NAME + ' ' + E.LAST_NAME) AS 'EMPLOYEE_NAME', P.PROBLEM_DESCR, P.PROBLEM_INVOLVE 
	FROM PROBLEM P INNER JOIN EMPLOYEE E
		ON P.EMP_ID = E.EMP_ID 
	WHERE E.GRP_ID != 5 AND E.DIV_ID = @DIV_ID AND E.DEPT_ID = @DEPT_ID

END
