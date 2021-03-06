USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetInventory]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateAssetInventory] 
	-- Add the parameters for the stored procedure here
	@ASSET_INVENTORY_ID tinyint,
	@EMP_ID int,
	@DEPARTMENT varchar(50),
	@BUILDING_FLOOR varchar(50),
	@ASSET_DESCRIPTION varchar(20),
	@MANUFACTURER varchar(20),
	@MODEL_NO varchar(50),
	@SERIAL_NO varchar(50),
	@ASSET_TAG varchar(20),
	@STATUS int,
	@DATE_ASSIGNED DATETIME,
	@COMMENTS text

AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE [dbo].[ASSETS_INVENTORY]
	SET [EMP_ID] = @EMP_ID,
		[DEPARTMENT] = @DEPARTMENT,
		[BUILDING/FLOOR] = @BUILDING_FLOOR,
		[ASSET_DESCRIPTION] = @ASSET_DESCRIPTION,
		[MANUFACTURER] = @MANUFACTURER,
		[MODEL_NO] = @MODEL_NO,
		[SERIAL_NO] = @SERIAL_NO,
		[ASSET_TAG] = @ASSET_TAG,
		[STATUS] = @STATUS,
		[DATE_ASSIGNED] = @DATE_ASSIGNED,
		[COMMENTS] = @COMMENTS

	WHERE [EMP_ID] = @EMP_ID AND ASSET_INVENTORY_ID = @ASSET_INVENTORY_ID
END

GO
