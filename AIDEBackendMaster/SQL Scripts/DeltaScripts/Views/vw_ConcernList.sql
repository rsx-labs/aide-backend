USE [AIDE]
GO

/****** Object:  View [dbo].[vw_ConcernList]    Script Date: 1/22/2020 5:10:17 AM ******/
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_ConcernList'))
BEGIN
   PRINT 'Dropping old version of vw_ConcernList'
   Drop View dbo.vw_ConcernList
END
GO

SET QUOTED_IDENTIFIER ON
GO





	CREATE VIEW [dbo].[vw_ConcernList] AS
	
	Select concern.REF_ID as ConcernID,
			concern.CONCERN as Concern,
			concern.CAUSE as Cause,
			concern.COUNTERMEASURE as CounterMeasure,
			concern.EMP_ID as RaisedByID,
			(emp.LAST_NAME + ', '+ emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as RaisedBy,
			format(convert(date,concern.DATE_RAISED,10),'MM/dd/yyy') as DateRaised,
			format(convert(date,concern.DUE_DATE,10),'MM/dd/yyyy') as DueDate,
			emp.DIV_ID as DivisionID,
			div.DESCR as Division,
			emp.DEPT_ID as DepartmentID,
			div.DESCR as Department,
			concern.STATUS as [StatusID],
			stat.Descr as [Status],
			emp.ACTIVE as IsActive,
			Month(concern.DUE_DATE) as [Month],
			Year(concern.DUE_DATE) as [Year],
			dbo.fn_getFiscalYear(concern.DUE_DATE, concern.DUE_DATE) as FiscalYear
	From CONCERN_CAUSE_COUNTERMEASURE concern
		inner join EMPLOYEE emp 
			on concern.EMP_ID = emp.EMP_ID
		inner join DEPARTMENT dept
			on dept.DEPT_ID = emp.DEPT_ID
		inner join DIVISION div
			on emp.DIV_ID = div.DIV_ID
		inner join [Status] stat
			on concern.STATUS = stat.STATUS and stat.STATUS_NAME = '3C''s'






GO


