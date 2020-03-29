USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_UpdateProblemOption]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateProblemOption]
GO

CREATE PROCEDURE [dbo].[sp_UpdateProblemOption] 
	-- Add the parameters for the stored procedure here
	@OPTION_ID INT,
	@PROBLEM_ID INT,
	@OPTION_DESCR VARCHAR(255)
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		UPDATE [dbo].[PROBLEM_OPTION]
		SET [OPTION_DESCR] = @OPTION_DESCR				
		WHERE [PROBLEM_ID] = @PROBLEM_ID AND [OPTION_ID] = @OPTION_ID
	
END