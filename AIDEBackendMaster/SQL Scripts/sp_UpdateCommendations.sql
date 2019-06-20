USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCommendations]    Script Date: 6/20/2019 1:27:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateCommendations]
	-- Add the parameters for the stored procedure here
	@COMMEND_ID INT,
	@DEPT_ID INT,
	@EMPLOYEE VARCHAR(MAX),
	@PROJECT VARCHAR(20),
	@DATE_SENT DATE,
	@SENT_BY VARCHAR(MAX),
	@REASON VARCHAR(MAX)
AS
DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @DEPT_ID),
		@DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @DEPT_ID),
		@EMP_ID INT = @DEPT_ID

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Update statement starts here
	UPDATE [dbo].COMMENDATIONS SET EMPLOYEE = @EMPLOYEE, PROJECT = @PROJECT, DATE_SENT = @DATE_SENT,
	SENT_BY = @SENT_BY, REASON = @REASON, EMP_ID = @EMP_ID
	WHERE COMMEND_ID = @COMMEND_ID 
	AND EMP_ID IN (SELECT EMP_ID FROM EMPLOYEE WHERE DIV_ID = @DIVID AND DEPT_ID = @DEPTID)

END 
