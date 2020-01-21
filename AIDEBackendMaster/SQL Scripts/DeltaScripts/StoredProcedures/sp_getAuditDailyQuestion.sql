USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getAuditDailyQuestion]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_getAuditDailyQuestion'))
    BEGIN
        DROP PROCEDURE [dbo].sp_getAuditDailyQuestion
    END
GO

CREATE PROCEDURE [dbo].[sp_getAuditDailyQuestion]
       -- Add the parameters for the stored procedure here
  
AS
BEGIN

       SET NOCOUNT ON;

    
       SELECT  E.NICK_NAME, WAQ.AUDIT_QUESTIONS, WAQ.AUDIT_QUESTIONS_GROUP, WAD.FY_WEEK, WAD.DT_CHECKED , WAO.OWNER
			FROM WORKPLACE_AUDIT_QUESTIONS WAQ 
			INNER JOIN WORKPLACE_AUDIT_DAILY WAD 
				ON WAQ.AUDIT_QUESTIONS_ID = WAD.AUDIT_QUESTIONS_ID 
			INNER JOIN EMPLOYEE E 
				ON E.EMP_ID = WAD.EMP_ID
			INNER JOIN WORKPLACE_AUDIT_OWNER WAO 
				ON WAD.AUDIT_QUESTIONS_ID = WAO.AuditQuestionID
			WHERE WAQ.AUDIT_QUESTIONS_GROUP = 1
END

GO
