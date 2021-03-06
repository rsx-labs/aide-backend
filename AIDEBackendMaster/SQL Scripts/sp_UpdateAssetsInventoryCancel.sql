USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetsInventoryCancel]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateAssetsInventoryCancel] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@EMP_ID INT,
	@DATE_ASSIGNED DATETIME,
	@STATUS int,
	@COMMENTS text
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE [dbo].[ASSETS_INVENTORY]
	SET [EMP_ID] = @EMP_ID,
		[STATUS] = 1,
		[APPROVAL] = 1
	WHERE ASSET_ID = @ASSET_ID

	UPDATE [dbo].[ASSETS]
	SET [STATUS] = 1
	WHERE [ASSET_ID] = @ASSET_ID

	
	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = @STATUS,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS_INVENTORY'
END

GO
