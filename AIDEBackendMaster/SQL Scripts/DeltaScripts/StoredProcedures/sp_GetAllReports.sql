USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllReports]    Script Date: 2/07/2020 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAllReports'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetAllReports]
    END
GO


CREATE PROCEDURE [dbo].[sp_GetAllReports]

AS

BEGIN							
	
	SELECT REPORT_ID, OPT_ID, DESCRIPTION, [MODULE ID] as MODULE_ID , VALUE AS FILE_PATH
	from [dbo].REPORTS

END



GO


