USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAllAssignedProjects]    Script Date: 11/19/2019 5:38:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_DeleteAllAssignedProjects]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_DeleteAllAssignedProjects]
GO

CREATE PROCEDURE [dbo].[sp_DeleteAllAssignedProjects]
	@PROJ_ID int
AS
DELETE FROM [dbo].[ASSIGNED_PROJECTS] WHERE PROJ_ID = @PROJ_ID