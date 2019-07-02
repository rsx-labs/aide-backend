USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTasksByPrimaryKey]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteTasksByPrimaryKey]
	@TASK_ID int,
	@EMP_ID int
AS

DELETE FROM [dbo].[TASKS]
 WHERE 
	[TASK_ID] = @TASK_ID AND 
	[EMP_ID] = @EMP_ID



GO
