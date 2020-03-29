USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllProblemResult'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllProblemResult]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllProblemResult]
	-- Add the parameters for the stored procedure here
	@PROBLEM_ID INT,
	@OPTION_ID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT PROBLEM_ID, OPTION_ID, IMPLEMENT_DESCR, SUM(CONVERT(INT,IMPLEMENT_VALUE)) 
	FROM PROBLEM_IMPLEMENT
	WHERE PROBLEM_ID = @PROBLEM_ID AND OPTION_ID = @OPTION_ID
	GROUP BY PROBLEM_ID,OPTION_ID,IMPLEMENT_DESCR


END
