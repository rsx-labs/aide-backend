USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuditSched]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:           <Author,,Name>
-- Create date: <Create Date,,>
-- Description:      <Description,,>
-- =============================================


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetAuditSched'))
    BEGIN
        DROP PROCEDURE [dbo].sp_GetAuditSched
    END
GO

CREATE PROCEDURE [dbo].[sp_GetAuditSched]
       -- Add the parameters for the stored procedure here
       @EMP_ID INT,
       @YEAR INT
AS
BEGIN
       -- SET NOCOUNT ON added to prevent extra result sets from
       -- interfering with SELECT statements.
       SET NOCOUNT ON;

       DECLARE @DEPTID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
       DECLARE @DIVID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
       DECLARE @LSTYR INT, @YRTODAY INT
   
       SET @LSTYR =  @YEAR + 1

    -- Insert statements for procedure here
       SELECT A.* FROM WORKPLACE_AUDIT_SCHEDULE A 
       INNER JOIN EMPLOYEE B ON A.EMP_ID = B.EMP_ID
       WHERE B.DEPT_ID = @DEPTID AND B.DIV_ID = @DIVID 
              AND YEAR(A.FY_START) BETWEEN @YEAR AND @LSTYR
       ORDER BY A.FY_WEEK
END

GO
