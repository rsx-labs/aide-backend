USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllProblemImplement'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllProblemImplement]
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAllProblemImplement]
	-- Add the parameters for the stored procedure here

AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT IMPLEMENT_ID, PROBLEM_ID, OPTION_ID, IMPLEMENT_DESCR, IMPLEMENT_ASSIGNEE, IMPLEMENT_VALUE 
	FROM PROBLEM_IMPLEMENT
	--WHERE PROBLEM_ID = @PROBLEM_ID AND OPTION_ID = @OPTION_ID

END
