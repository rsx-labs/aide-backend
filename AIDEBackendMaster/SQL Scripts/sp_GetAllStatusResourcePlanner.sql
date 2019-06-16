USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllStatusResourcePlanner]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllStatusResourcePlanner]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.DESCR, A.STATUS
	FROM STATUS A 
	where A.STATUS_ID = 7 or a.STATUS_ID = 6
END



GO
