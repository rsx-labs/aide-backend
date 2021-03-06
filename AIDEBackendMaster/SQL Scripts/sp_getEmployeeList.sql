USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getEmployeeList]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getEmployeeList] 


AS



SELECT        E.EMP_ID, 
			  E.FIRST_NAME, 
			  E.MIDDLE_NAME AS MIDDLE_INITIAL,
			  E.LAST_NAME, 
			  E.NICK_NAME, 
			  E.BIRTHDATE, 
			  D.DESCR AS POSITION, 
			  E.DATE_HIRED, E.STATUS, 

                         E.IMAGE_PATH, 
						 E.GRP_ID, C.EMAIL_ADDRESS, 
						 C.EMAIL_ADDRESS2, 
						 C.LOCATION, 
						 C.CEL_NO, 
						 C.LOCAL, 
						 C.HOMEPHONE, 
						 C.OTHER_PHONE, 
						 C.DT_REVIEWED

FROM         

 
			


			dbo.EMPLOYEE E INNER JOIN
                         dbo.CONTACTS C ON 
						 E.EMP_ID = C.EMP_ID 
						 INNER JOIN
                         dbo.DEPARTMENT ON
						 E.DEPT_ID = dbo.DEPARTMENT.DEPT_ID 
						 INNER JOIN
                         dbo.DIVISION ON 
						 dbo.DEPARTMENT.DIV_ID = dbo.DIVISION.DIV_ID 
						 INNER JOIN
                         dbo.POSITION D ON 
						 E.POS_ID = D.POS_ID 
						 INNER JOIN
                         dbo.PERMISSION_GROUP 
						 ON E.GRP_ID = dbo.PERMISSION_GROUP.GRP_ID 
						 INNER JOIN
                         dbo.STATUS 
						 ON E.STATUS = dbo.STATUS.STATUS


			


GO
