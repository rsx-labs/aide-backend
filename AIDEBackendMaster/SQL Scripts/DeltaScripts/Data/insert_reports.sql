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
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (9, 1008, 1000, N'3Cs Report', N'\ReportsCommands\generateconcernslistreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (10, 1009, 1000, N'Actions List Report', N'\ReportsCommands\generateactionlistreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (11, 1010, 1000, N'Lessons Learnt Report', N'\ReportsCommands\generatelessonlearntreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (12, 1011, 1000, N'Success Register Report', N'\ReportsCommands\generatesuccessregisterreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (13, 1012, 1000, N'Commendations Report', N'\ReportsCommands\generatecommendationlistreport.bat')
GO
SET IDENTITY_INSERT [dbo].[REPORTS] OFF
GO
