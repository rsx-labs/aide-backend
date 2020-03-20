USE [AIDE]
GO
SET IDENTITY_INSERT [dbo].[REPORTS] ON 

GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (1, 1001, 1000, N'Contact List', N'E:\BatchCommands\generatecontactlistreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (2, 1002, 1000, N'Outstanding task', N'E:\BatchCommands\generateoutstandingtaskreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (3, 1003, 1000, N'Asset Inventory', N'E:\BatchCommands\generateassetinventoryreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (4, 1003, 1000, N'Project Billability', N'E:\BatchCommands\generateprojectbillabilityreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (5, 1004, 1000, N'Employee Billability', N'E:\BatchCommands\generateemployeebillabilityreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (6, 1005, 1000, N'Skills Matrix', N'E:\BatchCommands\generateskillsmatrix.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (7, 1006, 1000, N'Status Reports', N'E:\BatchCommands\generatestatusreport.bat')
GO
INSERT [dbo].[REPORTS] ([REPORT_ID], [OPT_ID], [MODULE ID], [DESCRIPTION], [VALUE]) VALUES (8, 1007, 1000, N'Resource Planner', N'E:\BatchCommands\generateresourceplanner.bat')
GO
SET IDENTITY_INSERT [dbo].[REPORTS] OFF
GO
