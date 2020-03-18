USE [AIDE]
GO

DELETE FROM [dbo].[OPTION]
DBCC CHECKIDENT ('OPTION', RESEED, 0)

INSERT INTO [dbo].[OPTION]([ModuleID],[FunctionID],[Description],[Value])
	VALUES	(1, 1,	'Email Notification - Allow sending of email notification, 0=False 1=True', '1'),
			(2,	2,	'Missing Resource Plan - Checking Time config',	'09:59:59 AM'),
			(2,	2,	'Missing Resource Plan - Email notification data',	'The following employees have missing entry/ies in resource planner today., Please update it immediately.'),		
			(3,	3,	'Missing Weekly Report - Checking Date and time config',	'1,10:00:00 AM'),
			(3,	3,	'Missing Weekly Report - Email notification data',	'Weekly report from week, was not yet submitted. Please submit it immediately'),
			(2, 4,	'Attendance - Checking of Afternoon time', '14:00:00'),
			(2, 5,	'Attendance - Checking of Afternoon time end','13:59:59.000'),
			(1, 1,	'Email Notification - Allow sending of email notification in Resource Planner, 0=False 1=True', '1'),
			(1, 1,	'Email Notification - Allow sending of email notification in Weekly Report, 0=False 1=True', '1'),
			(1, 1,	'Email Notification - Allow sending of email notification in Asset Inventory, 0=False 1=True', '1'),
			(1, 1,	'Email Notification - Allow sending of email notification in Contacts, 0=False 1=True', '1'),
			(1, 1,	'Email Notification - Allow sending of email notification in Skills Matrix, 0=False 1=True', '1'),
			(2,	2,	'Missing Resource Plan - Checking day config, 1=Mon 2=Tue 3=Wed 4=Thu 5=Fri 6=Sat 7=Sun',	'1,2,3,4,5'),
			(4, 6,	'App Config - Event Startup ID from Event Viewer', '1'),
			(4, 8,	'App Config - Default email address used for login.', 'c.lim@fujitsu.com'),
			(5,	9,	'Asset Inventory - Email notification data for assigning asset',	'An asset has been assigned to you. Please verify if the information is correct.'),
			(5,	10,	'Asset Inventory - Email notification data for verifying asset',	'The asset below that was assigned to,has been verified. It is now waiting for your approval.'),
			(5,	11,	'Asset Inventory - Email notification data for approving asset',	'The asset below that was assigned to,has been,by'),
			(5,	9,	'Asset Inventory - Email notification data for assigning asset',	'The asset below was returned by,. Please verify if the information is correct.')


DELETE FROM [dbo].[OPTION_MODULE]
DBCC CHECKIDENT ('OPTION_MODULE', RESEED, 0)

INSERT INTO [dbo].[OPTION_MODULE]([Description])
	VALUES	('Email Notification'),
			('Resource Planner'),
			('Weekly Report'),
			('App Config'),
			('Asset Inventory')

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
			('Asset Inventory Movement (Approval)')

GO
