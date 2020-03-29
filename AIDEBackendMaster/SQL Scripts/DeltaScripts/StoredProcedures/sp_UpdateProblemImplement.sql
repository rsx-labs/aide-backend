USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblemImplement]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblemImplement]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblemImplement] 
	-- Add the parameters for the stored procedure here
	@IMPLEMENT_ID INT,
	@PROBLEM_ID INT,
	@OPTION_ID INT,
	@IMPLEMENT_DESCR VARCHAR(255),
	@IMPLEMENT_ASSIGNEE INT,
	@IMPLEMENT_VALUE VARCHAR(255)
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM_IMPLEMENT]
		SET [IMPLEMENT_DESCR] = @IMPLEMENT_DESCR,
			[IMPLEMENT_ASSIGNEE] = @IMPLEMENT_ASSIGNEE,
			[IMPLEMENT_VALUE] = @IMPLEMENT_VALUE			
		WHERE [PROBLEM_ID] = @PROBLEM_ID AND [OPTION_ID] = @OPTION_ID 
			AND [IMPLEMENT_ID] = @IMPLEMENT_ID
	
END