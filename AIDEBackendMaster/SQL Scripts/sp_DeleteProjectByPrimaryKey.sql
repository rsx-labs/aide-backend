USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProjectByPrimaryKey]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteProjectByPrimaryKey]
	@PROJ_ID int
AS

DELETE FROM [dbo].[PROJECT]
 WHERE 
	[PROJ_ID] = @PROJ_ID



GO
