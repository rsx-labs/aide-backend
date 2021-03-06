USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSabaXref]    Script Date: 10/31/2019 2:33:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_UpdateSabaXref]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].sp_UpdateSabaXref
GO

CREATE PROCEDURE [dbo].[sp_UpdateSabaXref] 
@SABA_ID INT,
@EMP_ID INT,  
@DATE_COMPLETED DATE
AS

BEGIN

UPDATE SABA_XREF SET 
DATE_COMPLETED = CONVERT(nvarchar, @DATE_COMPLETED , 23) 
WHERE SABA_ID = @SABA_ID AND EMP_ID = @EMP_ID

END