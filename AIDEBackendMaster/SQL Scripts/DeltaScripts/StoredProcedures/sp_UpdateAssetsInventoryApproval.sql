USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetsInventoryApproval]    Script Date: 12/06/2019 3:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateAssetsInventoryApproval'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateAssetsInventoryApproval]
    END
GO

CREATE PROCEDURE [dbo].[sp_UpdateAssetsInventoryApproval] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@EMP_ID INT,
	@STATUS INT,
	@APPROVAL int,
	@COMMENTS text
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	UPDATE [dbo].[ASSETS_INVENTORY]
	SET [APPROVAL] = @APPROVAL,
		[STATUS]=@STATUS,
		[EMP_ID]=@EMP_ID,
		[COMMENTS]=@COMMENTS
	WHERE ASSET_ID = @ASSET_ID

	UPDATE [dbo].[ASSETS]
	SET [STATUS] = @STATUS,
		[EMP_ID]= @EMP_ID
	WHERE [ASSET_ID] = @ASSET_ID
	
	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = @APPROVAL,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS_INVENTORY'
END
