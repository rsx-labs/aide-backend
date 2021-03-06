USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssets]    Script Date: 12/10/2019 3:42:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_UpdateAssets'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_UpdateAssets]
    END
GO

CREATE PROCEDURE [dbo].[sp_UpdateAssets] 
	-- Add the parameters for the stored procedure here
	@ASSET_ID INT,
	@EMP_ID INT,
	@TRANSFER_ID INT,
	@ASSET_DESC varchar(20),
	@MANUFACTURER varchar(20),
	@MODEL_NO varchar(50),
	@SERIAL_NO varchar(50),
	@ASSET_TAG varchar(20),
	@DATE_PURHCASED DATETIME,
	@STATUS int,
	@OTHER_INFO text
AS

DECLARE @GRP_ID INT = (SELECT GRP_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
DECLARE @DATE DATETIME= GETDATE()
DECLARE @STATS INT = 8


BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @GRP_ID <> 1  -- If USER 
		BEGIN
			UPDATE [dbo].[ASSETS]
			SET [ASSET_DESC] = @ASSET_DESC,
				[MANUFACTURER] = @MANUFACTURER,
				[MODEL_NO] = @MODEL_NO,
				[SERIAL_NO] = @SERIAL_NO,
				[ASSET_TAG] = @ASSET_TAG,
				[DATE_PURCHASED] = @DATE_PURHCASED, 
				[OTHER_INFO] = @OTHER_INFO,
				[PREVIOUS_ID] = @EMP_ID
			WHERE ASSET_ID = @ASSET_ID AND EMP_ID = @EMP_ID
		END
	
	ELSE IF @GRP_ID = 1 AND @TRANSFER_ID <> 0 -- IF MANAGER AND TRANSFER ASSET
		BEGIN
		SET @STATS = 10
			UPDATE [dbo].[ASSETS]
			SET [EMP_ID] = @TRANSFER_ID,
				[ASSET_DESC] = @ASSET_DESC,
				[MANUFACTURER] = @MANUFACTURER,
				[MODEL_NO] = @MODEL_NO,
				[SERIAL_NO] = @SERIAL_NO,
				[ASSET_TAG] = @ASSET_TAG,
				[DATE_PURCHASED] = @DATE_PURHCASED, 
				[OTHER_INFO] = @OTHER_INFO,
				[PREVIOUS_ID] = @EMP_ID
			WHERE ASSET_ID = @ASSET_ID

			EXEC sp_UpdateAssetsInventory
				 @ASSET_ID = @ASSET_ID,
				 @TRANSFER_ID = @TRANSFER_ID,
				 @PREVIOUS_ID = @EMP_ID,
				 @STATUS = @STATUS,
				 @DATE_ASSIGNED = @DATE,
				 @COMMENTS = @OTHER_INFO,
				 @APPROVAL = 0
		END
	ELSE
		BEGIN
			UPDATE [dbo].[ASSETS]
			SET [ASSET_DESC] = @ASSET_DESC,
				[MANUFACTURER] = @MANUFACTURER,
				[MODEL_NO] = @MODEL_NO,
				[SERIAL_NO] = @SERIAL_NO,
				[ASSET_TAG] = @ASSET_TAG,
				[DATE_PURCHASED] = @DATE_PURHCASED, 
				[OTHER_INFO] = @OTHER_INFO
			WHERE ASSET_ID = @ASSET_ID
		END
	
	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID,
		 @STATS = @STATS,
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS'
END
