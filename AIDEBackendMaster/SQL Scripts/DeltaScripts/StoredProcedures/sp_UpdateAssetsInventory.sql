USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetsInventory]    Script Date: 12/09/2019 6:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateAssetsInventory'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateAssetsInventory]
    END
GO
CREATE PROCEDURE [dbo].[sp_UpdateAssetsInventory] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@PREVIOUS_ID INT,
	@TRANSFER_ID INT,
	@DATE_ASSIGNED DATETIME,
	@STATUS int,
	@COMMENTS text,
	@APPROVAL INT
AS

DECLARE @GRP_ID INT = (SELECT GRP_ID FROM EMPLOYEE WHERE EMP_ID = @TRANSFER_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here

	UPDATE [dbo].[ASSETS_INVENTORY]
	SET [EMP_ID] = @TRANSFER_ID,
		[STATUS] = @STATUS,
		[DATE_ASSIGNED] = @DATE_ASSIGNED,
		[COMMENTS] = @COMMENTS,
		[APPROVAL] = @APPROVAL
	WHERE ASSET_ID = @ASSET_ID

	UPDATE [dbo].[ASSETS]
	SET [STATUS] = @STATUS,
		[EMP_ID] = @TRANSFER_ID,
		[PREVIOUS_ID] = @PREVIOUS_ID
	WHERE [ASSET_ID] = @ASSET_ID

	
	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
		 @EMPID = @TRANSFER_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = @STATUS,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS_INVENTORY'
END
