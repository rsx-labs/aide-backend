USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsByStatus]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllAssetsByStatus]
	-- Add the parameters for the stored procedure here
	@STATUS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @STATUS = 1 --ASSIGNED
		BEGIN
			SELECT * FROM  ASSETS
			WHERE STATUS = 1
			ORDER BY ASSET_DESC DESC
		END
	ELSE --UNASSIGNED
		BEGIN
			SELECT * FROM  ASSETS
			WHERE STATUS = 2
			ORDER BY ASSET_DESC DESC
		END

END

GO
