USE [AIDE]
GO

DELETE FROM [dbo].[OPTION]
DBCC CHECKIDENT ('OPTION', RESEED, 0)

INSERT INTO [dbo].[OPTION]([ModuleID],[FunctionID],[Description],[Value])
	VALUES	(1, 1,	'Email Notification - Allow sending of email notification [0=False 1=True]', '0'),
			(2,	2,	'Missing Resource Plan - Checking Time config [Time]',	'10:00:00 AM'),
			(2,	2,	'Missing Resource Plan - Email notification data [2 arguments]',	'The following employees have missing entry/ies in resource planner today., Please update it immediately.'),		
			(3,	3,	'Missing Weekly Report - Checking Date and time config [Day of week, Time]',	'1,10:00:00 AM'),
			(3,	3,	'Missing Weekly Report - Email notification data [2 arguments]',	'Weekly report from week, was not yet submitted. Please submit it immediately'),
			(2, 4,	'Attendance - Checking of Afternoon time', '14:00:00'),
			(2, 5,	'Attendance - Checking of Afternoon time end','13:59:59.000'),
			(1, 1,	'Email Notification - Allow sending of email notification in Resource Planner [0=False 1=True]', '0'),
			(1, 1,	'Email Notification - Allow sending of email notification in Weekly Report [0=False 1=True]', '0'),
			(1, 1,	'Email Notification - Allow sending of email notification in Asset Inventory, [0=False 1=True]', '0'),
			(1, 1,	'Email Notification - Allow sending of email notification in Contacts [0=False 1=True]', '0'),
			(1, 1,	'Email Notification - Allow sending of email notification in Skills Matrix [0=False 1=True]', '0'),
			(2,	2,	'Missing Resource Plan - Checking day config [1=Mon 2=Tue 3=Wed 4=Thu 5=Fri 6=Sat 7=Sun]',	'1,2,3,4,5'),
			(4, 6,	'App Config - Event Startup ID from Event Viewer', '1'),
			(4, 8,	'App Config - Default email address used for login.', 'c.lim@fujitsu.com'),
			(5,	9,	'Asset Inventory - Email notification data for assigning asset [1 argument]',	'An asset has been assigned to you. Please verify if the information is correct.'),
			(5,	10,	'Asset Inventory - Email notification data for verifying asset [2 arguments]',	'The asset below that was assigned to,has been verified. It is now waiting for your approval.'),
			(5,	11,	'Asset Inventory - Email notification data for approving asset [3 arguments]',	'The asset below that was assigned to,has been,by'),
			(5,	9,	'Asset Inventory - Email notification data for assigning asset [2 arguments]',	'The asset below was returned by,. Please verify if the information is correct.'),
			(6, 12,	'Contact List - Number of records per page in datagrid', '10'),
			(7, 12,	'Task Monitoring - Number of records per page in datagrid', '5'),
			(3, 12,	'Weekly Report - Number of records per page in datagrid', '10'),
			(8, 12,	'3Cs - Number of records per page in datagrid', '5'),
			(9, 12,	'Action List - Number of records per page in datagrid', '10'),
			(10, 12,	'Lessons Learnt - Number of records per page in datagrid', '5'),
			(11, 12,	'Success Registers - Number of records per page in datagrid', '10'),
			(12, 12,	'Assets - Number of records per page in datagrid', '10'),
			(5, 12,	'Assets Inventory - Number of records per page in datagrid', '10'),
			(13, 12,	'Assets History - Number of records per page in datagrid', '10'),
			(14, 12,	'Assets Borrowing - Number of records per page in datagrid', '10'),
			(15, 12,	'Projects - Number of records per page in datagrid', '5'),
			(16, 12,	'Tracker - Number of records per page in datagrid', '10'),
			(6,	13,	'Update Contact List - Checking datetime config [Day, Time]',	'1,09:00:00 AM'),
			(6,	13,	'Update Contact List - Email notification data [2 arguments]',	'You have not yet updated your contact information for this month of ,. Please update it immediately.'),
			(17, 14, 'Update Skill Matrix - Checking datetime config [Day, Time]',	'1,09:00:00 AM'),
			(17, 14, 'Update Skill Matrix - Email notification data [2 arguments]',	'You have not yet updated your skills information for this month of ,. Please update it immediately.'),
			(18, 15, 'Email Notification - Allow sending of email notification in Workplace Audit [0=False 1=True]', '0'),
			(18, 15, 'Update Workplace Audit - Checking Time config [Time]',	'08:00:00 AM'),
			(18, 15, 'Update Workplace Audit - Checking daily config [1=Mon 2=Tue 3=Wed 4=Thu 5=Fri 6=Sat 7=Sun]',	'1,2,3,4,5'),
			(18, 15, 'Update Workplace Audit - Checking weekly config, [Day of Week]',	'1'),
			(18, 15, 'Update Workplace Audit - Checking monthly config, [Day of Month]',	'1'),
			(18, 15, 'Update Workplace Audit - Update Workplace Audit data [2 arguments]',	'You are assigned as the,. Please check the Workplace Audit board for more details.'),
			(6, 16, 'Contact List - Default employee photo path', '\\FPI-HYPERV-002\Users\Public\Pictures\AIDE\EmployeePhotos\')



DELETE FROM [dbo].[OPTION_MODULE]
DBCC CHECKIDENT ('OPTION_MODULE', RESEED, 0)

INSERT INTO [dbo].[OPTION_MODULE]([Description])
	VALUES	('Email Notification'),
			('Resource Planner'),
			('Weekly Report'),
			('App Config'),
			('Assets Inventory'),
			('Contact List'),
			('Task Monitoring'),
			('3Cs'),
			('Action List'),
			('Lessons Learnt'),
			('Success Registers'),
			('Assets'),
			('Assets History'),
			('Assets Borrowing'),
			('Projects'),
			('Tracker'),
			('Skills Matrix'),
			('Workplace Audit')

DELETE FROM [dbo].[OPTION_FUNCTION]
DBCC CHECKIDENT ('OPTION_FUNCTION', RESEED, 0)

INSERT INTO [dbo].[OPTION_FUNCTION]([Description])
	VALUES	('Enable Sending Email'),
			('Missing Resource Planner Daily'),
			('Missing Weekly Report'),
			('Check Afternoon Time'),
			('Check Afternoon Time End'),
			('Event Startup ID'),
			('Event Login ID'),
			('Default Email Address'),
			('Asset Inventory Movement (Assign)'),
			('Asset Inventory Movement (Verify)'),
			('Asset Inventory Movement (Approval)'),
			('Default Number of records in Datagrid'),
			('Update Contact List'),
			('Update Skill Matrix'),
			('Update Workplace Audit'),
			('Default employee photo path')





GO
