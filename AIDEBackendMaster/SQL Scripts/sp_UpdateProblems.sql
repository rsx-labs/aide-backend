USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblems]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblems]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblems] 
	-- Add the parameters for the stored procedure here
	@PROBLEM_ID INT,
	@PROBLEM_DESCR VARCHAR(MAX),
	@PROBLEM_INVOLVE VARCHAR(MAX)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM]
		SET [PROBLEM_DESCR] = @PROBLEM_DESCR,
			[PROBLEM_INVOLVE] = @PROBLEM_INVOLVE			
		WHERE [PROBLEM_ID] = @PROBLEM_ID
	
END