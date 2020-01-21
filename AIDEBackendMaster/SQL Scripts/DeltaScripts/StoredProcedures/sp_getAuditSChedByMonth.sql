USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAuditSChedByMonth]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getAuditSChedByMonth'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getAuditSChedByMonth
    END
GO

CREATE PROCEDURE [dbo].[sp_getAuditSChedByMonth]
       -- Add the parameters for the stored procedure here
  
AS
BEGIN
	DECLARE @MONTHTODAY DATETIME = MONTH(GETDATE())

       SET NOCOUNT ON;
	   	
    SELECT CONCAT(CONVERT(VARCHAR,WAS.PERIOD_START, 107),' - ', CONVERT(VARCHAR,WAS.PERIOD_END,107)) AS AUDITSCHED_MONTH FROM WORKPLACE_AUDIT_SCHEDULE WAS WHERE MONTH(WAS.PERIOD_START) = @MONTHTODAY
    
END

GO
