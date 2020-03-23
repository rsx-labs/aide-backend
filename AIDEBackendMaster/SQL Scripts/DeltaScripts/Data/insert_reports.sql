USE [AIDE]
GO
SET IDENTITY_INSERT [dbo].[REPORTS] ON 

GO

DELETE from REPORTS
GO

INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (1, 1001, 1000, N'Contact List', N'\ReportsCommands\generatecontactlistreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (2, 1002, 1000, N'Outstanding task', N'\ReportsCommands\generateoutstandingtaskreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (3, 1003, 1000, N'Asset Inventory', N'\ReportsCommands\generateassetinventoryreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (4, 1003, 1000, N'Project Billability', N'\ReportsCommands\generateprojectbillabilityreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (5, 1004, 1000, N'Employee Billability', N'\ReportsCommands\generateemployeebillabilityreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (6, 1005, 1000, N'Skills Matrix', N'\ReportsCommands\generateskillsmatrix.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (7, 1006, 1000, N'Status Reports', N'\ReportsCommands\generatestatusreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (8, 1007, 1000, N'Resource Planner', N'\ReportsCommands\generateresourceplanner.bat')
GO
SET IDENTITY_INSERT [dbo].[REPORTS] OFF
GO
