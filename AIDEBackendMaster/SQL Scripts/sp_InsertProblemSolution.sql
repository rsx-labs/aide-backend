USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertProblemSolution]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertProblemSolution]
GO

CREATE PROCEDURE [dbo].[sp_InsertProblemSolution]
	@PROBLEM_ID INT,
	@OPTION_ID INT,
	@SOLUTION_DESCR VARCHAR(MAX) 

AS

INSERT [dbo].[PROBLEM_SOLUTION]
(
	[PROBLEM_ID],
	[OPTION_ID],
	[SOLUTION_DESCR]
)
VALUES
(
	@PROBLEM_ID,
	@OPTION_ID,
	@SOLUTION_DESCR
)




GO
