USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateKPITargets]    Script Date: 9/12/2019 9:05:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateKPITargets'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateKPITargets]
    END
GO
CREATE PROCEDURE [dbo].[sp_UpdateKPITargets]
	@ID INT,
	@EMP_ID INT,
	@SUBJECT varchar(50), 
	@DESCRIPTION varchar(255)
AS

BEGIN
	UPDATE KPI_TARGETS 
	SET SUBJECT=@SUBJECT, 
	DESCRIPTION=@DESCRIPTION
	WHERE ID=@ID
	AND EMP_ID = @EMP_ID
END 

