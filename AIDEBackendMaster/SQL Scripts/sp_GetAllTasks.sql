USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTasks]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllTasks]
AS

	SELECT 
		*
	FROM [dbo].[TASKS] 
GO
