USE [AIDE]
GO

/****** Object:  View [dbo].[vw_ActionList]    Script Date: 1/13/2020 5:07:37 AM ******/
SET ANSI_NULLS ON
GO


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('dbo.vw_ActionList'))
BEGIN
   PRINT 'Dropping old version of vw_ActionList'
   Drop View dbo.vw_ActionList
END
GO

SET QUOTED_IDENTIFIER ON
GO

	CREATE VIEW [dbo].[vw_ActionList] AS
	
	Select act.ACTREF as ActionID,
			act.ACT_MESSAGE as [Action],
			emp.EMP_ID as EmployeeID,
			(emp.LAST_NAME + ', ' + emp.FIRST_NAME + ' ' + emp.MIDDLE_NAME) as EmployeeName,
			format(convert(date,act.DATE_CREATED,10),'MM/dd/yyyy') as DateCreated,
			format(convert(date,act.DUE_DATE,10),'MM/dd/yyyyy') as DueDate,
			act.DATE_CLOSED as DateClosed,
			emp.DIV_ID as DivisionID,
			div.DESCR as Division,
			emp.DEPT_ID as DepartmentID,
			div.DESCR as Department,
			act.ACT_STATUS as [Status],
			emp.ACTIVE as IsActive,
			Month(act.DUE_DATE) as [Month],
			Year(act.DUE_DATE) as [Year],
			dbo.fn_getFiscalYear(act.DUE_DATE, act.DUE_DATE) as FiscalYear
	From ACTIONLIST act
		inner join EMPLOYEE emp 
			on act.EMP_ID = emp.EMP_ID
		inner join DEPARTMENT dept
			on dept.DEPT_ID = emp.DEPT_ID
		inner join DIVISION div
			on emp.DIV_ID = div.DIV_ID

GO


