USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertProblemCause]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertProblemCause]
GO

CREATE PROCEDURE [dbo].[sp_InsertProblemCause]
	@PROBLEM_ID INT,
	@CAUSE_DESCR VARCHAR(50),
	@CAUSE_WHY VARCHAR(MAX) 

AS

INSERT [dbo].[PROBLEM_CAUSE]
(
	[PROBLEM_ID],
	[CAUSE_DESCR],
	[CAUSE_WHY]
)
VALUES
(
	@PROBLEM_ID,
	@CAUSE_DESCR,
	@CAUSE_WHY
)




GO
