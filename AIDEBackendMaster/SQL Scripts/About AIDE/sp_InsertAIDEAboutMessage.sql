USE [AIDE]
GO

INSERT INTO [dbo].[AIDE_MESSAGE] ([MESSAGE_ID]
           ,[SEC_ID]
           ,[MESSAGE_DESCR]
		   ,[TITLE]
           ,[ORDER_BY])
     VALUES
           (1015,20,'As technological advances are transforming workplaces at an unprecedented rate, with digitalization becoming the buzzword in the era of the Digital Workplace, it is imperative for organizations to keep up with the changing trends in order to enhance their productivity and added value services to clients and the society. Responding to the challenge of going digital and doing away with manual processing of tasks, this paper introduces and illustrates a solution that can transform the workplace of not only the Fujitsu Philippines Global Delivery Center (PH GDC), but of other organizations that also apply the Sense and Respond model. The proposed Adaptive Intelligent Dashboard for Employees (AIDE) System aims to replace the current Communication Cell Boards of organizations, which still banks on paper use and manual updating of tasks, with a Digital Communication Cell Board that is designed to be integrated with other applications and services in order to produce outputs that the team needs to be displayed. ','Abstract',1),
		   (1015,20,'Composed of three main components, namely the Employee Assist Tools, Data and Communication Services, and Dashboard Application, the AIDE system will be powered by the following technologies: .NET Core, .NET Framework 4.5, C# and VB, VSTO for Outlook Add-In, SQL Server 2014 or later, WPF and UWP, and SignalR.

Implemented effectively, the PH GDC and other organizations can help save the environment by reducing paper costs, as well as accelerate and enhance the team’s productivity and processes by providing tools to assist their activities which would otherwise have to be performed manually. With Internet of Things (IoT) also becoming a buzzword, the use of new technologies such as .NET core and Alljoyn framework can help teams leverage its capabilities, can be used for other digital projects, and can also be developed to provide a good source of data analytics.
','Abstract',2)

GO
