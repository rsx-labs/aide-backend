USE [AIDE]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllEmpResourcePlanner]    Script Date: 11/06/2019 3:05:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_GetAllEmpResourcePlanner]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].sp_GetAllEmpResourcePlanner
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAllEmpResourcePlanner]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max),
	@MONTH int,
	@YEAR int
		AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select c.EMP_ID, c.LAST_NAME + ', ' + c.FIRST_NAME + ' ' + SUBSTRING(c.MIDDLE_NAME,1,1) AS EMPLOYEE_NAME, 
a.DATE_ENTRY,a.STATUS
from ATTENDANCE a 
inner join EMPLOYEE c 
on a.EMP_ID = c.EMP_ID
and c.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
and c.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
				ON A.EMP_ID = B.EMP_ID
				WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
where Month(DATE_ENTRY) = @MONTH AND Year(DATE_ENTRY) = @YEAR and c.ACTIVE <> 2
ORDER BY c.LAST_NAME
END



GO


