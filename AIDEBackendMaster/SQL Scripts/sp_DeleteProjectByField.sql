USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteProjectByField]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteProjectByField]
	@FieldName varchar(100),
	@Value varchar(1000)
AS

	DECLARE @query varchar(2000);

	SET @query = 'DELETE FROM [dbo].[PROJECT] WHERE [' + @FieldName  + '] = ''' + @Value + ''''
	EXEC(@query)



GO
