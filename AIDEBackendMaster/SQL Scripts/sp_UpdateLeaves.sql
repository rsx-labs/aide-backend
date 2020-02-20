USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsHistory]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM dbo.sysobjects where id = object_id(N'[dbo].[sp_UpdateLeaves]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_UpdateLeaves]
GO

CREATE PROCEDURE [dbo].[sp_UpdateLeaves] 
	@EMP_ID INT,
	@LEAVE_TYPE INT,
	@LEAVE_DATE DATETIME,
	@DATE_ENTRY DATETIME
AS
	DECLARE @UPDATED_DATE DATETIME = (SELECT DATEADD(HOUR, 4, @DATE_ENTRY))

	UPDATE ATTENDANCE SET 
	DATE_ENTRY = @UPDATED_DATE 
	WHERE EMP_ID = @EMP_ID 
	AND STATUS = @LEAVE_TYPE 
	AND DATE_ENTRY = @LEAVE_DATE 





