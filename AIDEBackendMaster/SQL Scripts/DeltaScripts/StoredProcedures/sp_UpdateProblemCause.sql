USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblemCause]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblemCause]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblemCause] 
	-- Add the parameters for the stored procedure here
	@CAUSE_ID INT,
	@PROBLEM_ID INT,
	@CAUSE_DESCR VARCHAR(50),
	@CAUSE_WHY VARCHAR(255)
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM_CAUSE]
		SET [CAUSE_WHY] = @CAUSE_WHY, 
			[CAUSE_DESCR] = @CAUSE_DESCR					
		WHERE [PROBLEM_ID] = @PROBLEM_ID AND [CAUSE_ID] = @CAUSE_ID
	
END