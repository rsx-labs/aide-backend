USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllProblemSolution'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllProblemSolution]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllProblemSolution]
	-- Add the parameters for the stored procedure here
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT SOLUTION_ID, PROBLEM_ID, OPTION_ID, SOLUTION_DESCR 
	FROM PROBLEM_SOLUTION
	--WHERE PROBLEM_ID = @PROBLEM_ID AND OPTION_ID = @OPTION_ID

END
