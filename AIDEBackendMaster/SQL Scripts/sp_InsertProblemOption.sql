USE [AIDE]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[sp_InsertProblemOption]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertProblemOption]
GO

CREATE PROCEDURE [dbo].[sp_InsertProblemOption]
	@PROBLEM_ID INT,
	@OPTION_DESCR VARCHAR(MAX) 

AS

INSERT [dbo].[PROBLEM_OPTION]
(
	[PROBLEM_ID],
	[OPTION_DESCR]
)
VALUES
(
	@PROBLEM_ID,
	@OPTION_DESCR
)




GO
