USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAssetsBorrowing]    Script Date: 2/07/2019 1:24:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_InsertAssetsBorrowing'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_InsertAssetsBorrowing]
    END
GO

CREATE PROCEDURE [dbo].[sp_InsertAssetsBorrowing]
	-- Add the parameters for the stored procedure here
	@EMP_ID int,
	@ASSET_ID int,
	@ASSET_BORROWING_ID int,
	@STATUS int,
	@TRANS_FG int,
	@TRANS_DATE DATETIME,
	@COMMENTS text,
	@APPROVAL int

AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @DATE_TRANS datetime


	-- 10 for request
	-- 11 for approve
	-- 12 for reject
	-- 
	IF @TRANS_FG = 10
	BEGIN
		SET @DATE_TRANS = 10
			INSERT [dbo].[ASSETS_BORROWING]
	(
		[EMP_ID],
		[ASSET_ID],
		[STATUS],
		[COMMENTS],
		[APPROVAL]
	)
	VALUES
	(
		@EMP_ID,
		@ASSET_ID,
		@STATUS,
		@COMMENTS,
		@APPROVAL


	)

			UPDATE ASSETS 
			SET
				BORROW_STATUS = 1
			
			WHERE
				ASSET_ID = @ASSET_ID

	END

	ELSE IF @TRANS_FG =11
	BEGIN
		IF @APPROVAL = 2
		BEGIN
		
			UPDATE ASSETS_BORROWING
			SET
				STATUS = @STATUS,
				APPROVAL = @APPROVAL
			WHERE 
				ASSET_BORROWING_ID = @ASSET_BORROWING_ID
		
			UPDATE ASSETS 
			SET
				BORROW_STATUS = 0
			
			WHERE
				ASSET_ID = @ASSET_ID
		END

		ELSE
		BEGIN
		
			UPDATE ASSETS_BORROWING
			SET
				DATE_BORROWED = @TRANS_DATE,
				STATUS = @STATUS,
				APPROVAL = @APPROVAL 

			WHERE 
				ASSET_BORROWING_ID = @ASSET_BORROWING_ID

			UPDATE ASSETS 
			SET
				BORROW_STATUS = 1
			
			WHERE
				ASSET_ID = @ASSET_ID
				
		END
	END

	ELSE IF @TRANS_FG = 12
	BEGIN
		UPDATE ASSETS_BORROWING
		SET
		DATE_RETURNED = @TRANS_DATE,
		STATUS = @STATUS,
		APPROVAL = @APPROVAL 

		Where 
		ASSET_BORROWING_ID = @ASSET_BORROWING_ID

			UPDATE ASSETS 
			SET
				BORROW_STATUS = 0
			
			WHERE
				ASSET_ID = @ASSET_ID
	END
	
	--DECLARE @DATE DATETIME= GETDATE(),
	--		@EMP_ID_ INT = @EMPID

	--EXEC sp_InsertAssetHistory
	--	 @EMPID = @EMP_ID_,
	--	 @ASSETID = @ASSET_ID,
	--	 @STATS = @STATUS,
	--	 @DATEASSIGNED = @DATE,
	--	 @TABLENAME = N'ASSETS_INVENTORY'

	--END
 
	--INSERT [dbo].[ASSETS_BORROWING]
	--(
	--	[EMP_ID],
	--	[ASSET_ID],
	--	[STATUS],
	--	[DATE_BORROWED],
	--	[DATE_RETURNED],
	--	[COMMENTS],
	--	[APPROVAL]
	--)
	--VALUES
	--(
	--	@EMPID,
	--	@ASSET_ID,
	--	@STATUS,
		
	--	@DATE_ASSIGNED,
	--	@COMMENTS,
	--	0
	--)

	--DECLARE @DATE DATETIME= GETDATE(),
	--		@EMP_ID_ INT = @EMPID

	--EXEC sp_InsertAssetHistory
	--	 @EMPID = @EMP_ID_,
	--	 @ASSETID = @ASSET_ID,
	--	 @STATS = @STATUS,
	--	 @DATEASSIGNED = @DATE,
	--	 @TABLENAME = N'ASSETS_INVENTORY'
END




GO
