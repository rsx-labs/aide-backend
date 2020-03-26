USE [AIDE]
GO

/****** Object:  View [dbo].[vw_StatusReport]    Script Date: 09/25/2019 6:25:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_StatusReport'))
BEGIN
   PRINT 'Dropping old version of vw_StatusReport'
   Drop View dbo.vw_StatusReport
END
GO


CREATE VIEW [dbo].[vw_StatusReport]
AS
SELECT      project.PROJ_NAME AS Project, 
            wReport.WR_PROJ_CODE AS ProjectCode, 
            reworkStatus.DESCR AS Rework, 
            wReport.WR_REF_ID AS ReferenceID,
            wReport.WR_SUBJECT AS Description, 
            severity.DESCR AS Severity, 
            isnull(incidentType.DESCR,'Others') AS IncidentType, 
            employee.FIRST_NAME + ' ' + employee.LAST_NAME AS AssignedEmpolyee, 
            phaseType.DESCR AS Phase, 
            status.DESCR AS Status, 
            format(convert(date,wReport.WR_DATE_STARTED,10),'MM/dd/yyyy') AS DateStarted, 
			format(convert(date,wReport.WR_DATE_TARGET,10),'MM/dd/yyyy') AS TargetDate, 
			format(convert(date,wReport.WR_DATE_FINISHED,10),'MM/dd/yyyy') AS CompletedDate,  
            wReport.WR_EFFORT_EST AS EffortEstimate, 
            wReport.WR_ACT_EFFORT_WK AS ActualWeekWork, 
            wReport.WR_ACT_EFFORT AS ActualEffort, 
            wReport.WR_COMMENTS AS Comments, 
            wReport.WR_INBOUND_CONTACTS AS InboundContacts, 
            week.WEEK_START AS WeekRangeStart, 
            week.WEEK_END AS WeekRangeEnd, 
            week.WEEK_ID AS WeekRangeId, 
            project.PROJ_ID AS ProjectId,
            incharge.DEPT_ID as DepartmentID, 
            incharge.DIV_ID as DivisionID,
            employee.EMP_ID as EmployeeID
FROM        dbo.PROJECT AS project INNER JOIN
            dbo.WEEKLY_REPORT AS wReport 
                ON project.PROJ_ID = wReport.WR_PROJ_ID INNER JOIN
            dbo.vw_Employees AS employee 
                ON employee.EMP_ID = wReport.WR_EMP_ID LEFT OUTER JOIN
            dbo.STATUS AS incidentType 
                ON incidentType.STATUS = wReport.WR_INC_TYPE 
                    AND incidentType.STATUS_NAME = 'TASK_TYPE' LEFT OUTER JOIN
            dbo.STATUS AS phaseType 
                ON phaseType.STATUS = wReport.WR_PHASE 
                    AND phaseType.STATUS_NAME = 'PHASE' LEFT OUTER JOIN
            dbo.STATUS AS status 
                ON status.STATUS = wReport.WR_STATUS 
                    AND status.STATUS_NAME = 'TASK_STATUS' LEFT OUTER JOIN
            dbo.STATUS AS reworkStatus 
                ON reworkStatus.STATUS = wReport.WR_REWORK 
                    AND reworkStatus.STATUS_NAME = 'REWORK' LEFT OUTER JOIN
            dbo.STATUS AS severity 
                ON severity.STATUS = wReport.WR_INC_TYPE 
                    AND severity.STATUS_NAME = 'SEVERITY' INNER JOIN
            dbo.WEEK_RANGE AS week 
                ON week.WEEK_ID = wReport.WR_WEEK_RANGE_ID LEFT OUTER JOIN
            dbo.EMPLOYEE AS incharge
                ON  incharge.EMP_ID = project.EMP_ID
WHERE   wReport.WR_DELETE_FG = 0


GO


