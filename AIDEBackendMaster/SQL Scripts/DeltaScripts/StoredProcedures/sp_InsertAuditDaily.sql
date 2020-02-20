USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAuditDaily]    Script Date: 10/11/2019 6:04:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertAuditDaily]
	-- Add the parameters for the stored procedure here
	@AUDIT_QUESTIONS_ID INT,
	@EMP_ID INT,
	@FY_WEEK INT,
	@DT_CHECKED DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO WORKPLACE_AUDIT_DAILY
	VALUES (@AUDIT_QUESTIONS_ID, @EMP_ID, @FY_WEEK, @DT_CHECKED,0)

END
