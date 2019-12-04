USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAnnouncements]    Script Date: 07/25/2019 9:59:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllDivision]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sp_GetAllDivision]
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllDivision]
	-- Add the parameters for the stored procedure here
	@DEPTID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

			SELECT DIV_ID,descr as 'DIV_DESCR' 
			FROM DIVISION 
			WHERE DIV_ID > 0 AND DEPT_ID = @DEPTID
END

