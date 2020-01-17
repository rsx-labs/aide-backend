USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLogoffTime]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_InsertLogoffTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_InsertLogoffTime]
GO

CREATE PROCEDURE [dbo].[sp_InsertLogoffTime] 
	@EMP_ID INT
AS

BEGIN
	DECLARE @COUNT AS INT = (SELECT COUNT(*) FROM ATTENDANCE WHERE EMP_ID = @EMP_ID AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, GETDATE()) AND LOGOFF_TIME != NULL)

	IF @COUNT = 0 
		BEGIN
			UPDATE ATTENDANCE SET LOGOFF_FLG = 1, LOGOFF_TIME = GETDATE() 
			FROM ATTENDANCE 
			WHERE EMP_ID = @EMP_ID AND CONVERT(DATE, DATE_ENTRY) = CONVERT(DATE, GETDATE())
		END
END



