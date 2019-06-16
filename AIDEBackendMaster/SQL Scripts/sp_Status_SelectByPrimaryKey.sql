USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_Status_SelectByPrimaryKey]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Status_SelectByPrimaryKey]
@STATUS_ID smallint
AS

	SELECT 
		[STATUS_ID], [STATUS_NAME], [DESCR], [STATUS]
	FROM [dbo].[STATUS]
	WHERE 
		STATUS_ID = @STATUS_ID


GO
