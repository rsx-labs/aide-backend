USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateProject]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateProject]
	@PROJ_ID int,
	@PROJ_NAME varchar(20),
	@CATEGORY smallint,
	@BILLABILITY smallint

AS

UPDATE [dbo].[PROJECT]
SET
	[PROJ_ID] = @PROJ_ID,
	[PROJ_NAME] = @PROJ_NAME,
	[CATEGORY] = @CATEGORY,
	[BILLABILITY] = @BILLABILITY
 WHERE 
	[PROJ_ID] = @PROJ_ID



GO
