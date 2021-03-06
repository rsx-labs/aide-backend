USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTasksByEmpID]    Script Date: 09/26/2019 7:35:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetTasksByEmpID]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM TASKS A
	INNER JOIN STATUS B ON A.STATUS = B.STATUS
	WHERE EMP_ID = @EMP_ID 
	AND A.STATUS <> 3 AND A.STATUS <> 4 
	AND B.STATUS_ID = 3 
	--AND DATEPART(wk, A.DATE_CREATED) = DATEPART(wk, GETDATE())
END 
