USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblemSolution]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblemSolution]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblemSolution] 
	-- Add the parameters for the stored procedure here
	@SOLUTION_ID INT,
	@PROBLEM_ID INT,
	@OPTION_ID INT,
	@SOLUTION_DESCR VARCHAR(255)
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM_SOLUTION]
		SET [SOLUTION_DESCR] = @SOLUTION_DESCR				
		WHERE [PROBLEM_ID] = @PROBLEM_ID AND [OPTION_ID] = @OPTION_ID 
			AND [SOLUTION_ID] = @SOLUTION_ID
	
END