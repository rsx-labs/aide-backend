USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsHistory]    Script Date: 10/01/2019 10:29:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_UpdateLeaves]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_UpdateLeaves]
GO

CREATE PROCEDURE [dbo].[sp_UpdateLeaves] 
	@EMP_ID INT,
	@LEAVE_TYPE INT,
	@START_DATE DATE,
	@END_DATE DATE,
	@STATUS_CD INT
AS

UPDATE RESOURCE_PLANNER SET 
STATUS_CD = @STATUS_CD 
WHERE EMP_ID = @EMP_ID and STATUS = @LEAVE_TYPE 
and CONVERT(DATE,DATE_ENTRY) between CONVERT(DATE,@START_DATE) and CONVERT(DATE,@END_DATE)

DELETE FROM ATTENDANCE
WHERE EMP_ID = @EMP_ID and 
CONVERT(DATE,DATE_ENTRY) between CONVERT(DATE,@START_DATE) and CONVERT(DATE,@END_DATE)



