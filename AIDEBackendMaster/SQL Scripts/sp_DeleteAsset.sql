USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAsset]    Script Date: 12/10/2019 3:35:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteAsset'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_DeleteAsset]
    END
GO

CREATE PROCEDURE [dbo].[sp_DeleteAsset]
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@OTHER_INFO text
AS

DECLARE @EMP_ID INT = (SELECT EMP_ID FROM ASSETS WHERE ASSET_ID = @ASSET_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN
		UPDATE ASSETS 
		SET [STATUS] = 5,
			[OTHER_INFO] = @OTHER_INFO
		WHERE ASSET_ID = @ASSET_ID
	END

	DECLARE @DATE DATETIME= GETDATE()

	EXEC sp_InsertAssetHistory
			@EMPID = @EMP_ID,
			@ASSETID = @ASSET_ID,
			@STATS = 9, --DELETED
			@DATEASSIGNED = @DATE,
			@TABLENAME = N'ASSETS_INVENTORY'
END
