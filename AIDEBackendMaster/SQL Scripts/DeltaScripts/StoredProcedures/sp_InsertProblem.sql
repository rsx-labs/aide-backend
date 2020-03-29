USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertProblem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertProblem]
GO

CREATE PROCEDURE [dbo].[sp_InsertProblem]
	@EMP_ID INT,
	@PROBLEM_DESCR VARCHAR(MAX),
	@PROBLEM_INVOLVE VARCHAR(MAX) 

AS

INSERT [dbo].[PROBLEM]
(
	[EMP_ID],
	[PROBLEM_DESCR],
	[PROBLEM_INVOLVE]
)
VALUES
(
	@EMP_ID,
	@PROBLEM_DESCR,
	@PROBLEM_INVOLVE
)




GO
