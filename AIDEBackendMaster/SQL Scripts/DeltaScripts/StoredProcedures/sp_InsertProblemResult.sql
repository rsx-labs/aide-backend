USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertProblemResult]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertProblemResult]
GO

CREATE PROCEDURE [dbo].[sp_InsertProblemResult]
	@PROBLEM_ID INT,
	@OPTION_ID INT,
	@RESULT_DESCR VARCHAR(255),
	@RESULT_VALUE VARCHAR(255) 

AS

INSERT [dbo].[PROBLEM_RESULT]
(
	[PROBLEM_ID],
	[OPTION_ID],
	[RESULT_DESCR],
	[RESULT_VALUE]
)
VALUES
(
	@PROBLEM_ID,
	@OPTION_ID,
	@RESULT_DESCR,
	@RESULT_VALUE
)




GO
