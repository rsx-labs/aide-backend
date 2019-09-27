USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetStatusResourcePlanner]    Script Date: 09/27/2019 10:25:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetStatusResourcePlanner'))
    BEGIN
        DROP PROCEDURE [dbo].[sp_GetStatusResourcePlanner]
    END
GO
CREATE PROCEDURE [dbo].[sp_GetStatusResourcePlanner]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @PERM_ID INT = (SELECT GRP_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

	IF @PERM_ID = 1 -- MANAGER LEVEL
		BEGIN
			SELECT A.DESCR, A.STATUS
			FROM STATUS A 
			where A.STATUS_ID IN (7,9)
			ORDER BY A.STATUS_ID, A.STATUS ASC
		END
	ELSE
		BEGIN
			SELECT A.DESCR, A.STATUS
			FROM STATUS A 
			where A.STATUS_ID IN (7,9) AND A.STATUS != 7
			ORDER BY A.STATUS_ID, A.STATUS ASC
		END
END


