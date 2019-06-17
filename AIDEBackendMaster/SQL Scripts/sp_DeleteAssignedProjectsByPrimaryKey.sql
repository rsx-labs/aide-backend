USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAssignedProjectsByPrimaryKey]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteAssignedProjectsByPrimaryKey]
	@EMP_ID int,
	@PROJ_ID int
AS

DELETE FROM [dbo].[ASSIGNED_PROJECTS]
 WHERE 
	[EMP_ID] = @EMP_ID AND 
	[PROJ_ID] = @PROJ_ID



GO
