USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAssets]    Script Date: 12/10/2019 1:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertAssets'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_InsertAssets]
    END
GO

CREATE PROCEDURE [dbo].[sp_InsertAssets]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@ASSET_DESC varchar(20),
	@MANUFACTURER varchar(20),
	@MODEL_NO varchar(50),
	@SERIAL_NO varchar(50),
	@ASSET_TAG varchar(20),
	@DATE_PURHCASED DATETIME,
	@STATUS int = 0,
	@OTHER_INFO text,
	@ASSIGNEDTO INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	INSERT [dbo].[ASSETS]
	(
		[ASSET_DESC],
		[MANUFACTURER],
		[MODEL_NO],
		[SERIAL_NO],
		[ASSET_TAG],
		[DATE_PURCHASED],
		[STATUS],
		[OTHER_INFO],
		[EMP_ID]
	)
	VALUES
	(
		@ASSET_DESC,
		@MANUFACTURER,
		@MODEL_NO,
		@SERIAL_NO,
		@ASSET_TAG,
		@DATE_PURHCASED,
		1,
		@OTHER_INFO,
		@EMP_ID
	)
	

	DECLARE @DATE DATETIME= GETDATE(),
			@ASSET_ID_ INT = (SELECT MAX(ASSET_ID) FROM ASSETS),
			@ASSIGNED_TO INT = @ASSIGNEDTO

	

	--INSERT LOGS TO HISTORY
	EXEC sp_InsertAssetHistory
		 @EMPID = @EMP_ID,
		 @ASSETID = @ASSET_ID_,
		 @STATS = 7, --Created
		 @DATEASSIGNED = @DATE,
		 @TABLENAME = N'ASSETS'

	--ASSIGN NEWLY CREATED TO MANAGER(ASSIGNEDTO)
	EXEC [dbo].[sp_InsertAssetsInventory]
		@EMPID = @ASSIGNED_TO,
		@ASSET_ID = @ASSET_ID_,
		@STATUS = 1,
		@DATE_ASSIGNED = @DATE,
		@COMMENTS = NULL
END
