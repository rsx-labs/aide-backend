USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAssignedProjectsByField]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAssignedProjectsByField]
	@FieldName varchar(100),
	@Value varchar(1000)
AS

	DECLARE @query varchar(2000);

	SET @query = 'SELECT [EMP_ID], [PROJ_ID], [DATE_CREATED], [START_PERIOD], [END_PERIOD] FROM [dbo].[ASSIGNED_PROJECTS] WHERE [' + @FieldName  + '] = ''' + @Value + ''''
	EXEC(@query)



GO
