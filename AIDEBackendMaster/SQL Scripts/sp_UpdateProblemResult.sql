USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblemResult]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblemResult]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblemResult] 
	-- Add the parameters for the stored procedure here
	@RESULT_ID INT,
	@PROBLEM_ID INT,
	@OPTION_ID INT,
	@RESULT_DESCR VARCHAR(255),
	@RESULT_VALUE VARCHAR(255)
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM_RESULT]
		SET [RESULT_DESCR] = @RESULT_DESCR,
			[RESULT_VALUE] = @RESULT_VALUE			
		WHERE [PROBLEM_ID] = @PROBLEM_ID AND [OPTION_ID] = @OPTION_ID 
			AND [RESULT_ID] = @RESULT_ID
	
END