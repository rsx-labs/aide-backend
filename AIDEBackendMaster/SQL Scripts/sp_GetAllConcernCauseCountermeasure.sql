USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllConcernCauseCountermeasure]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllConcernCauseCountermeasure]
@EMAILADDRESS varchar(max),

@OFFSETVAL int,
@NEXTVAL int

AS
DECLARE		
			@GENERATEDREF_ID varchar(max),
			@countPlusOne int,
			@GetDateNow varchar(max),
			@num varchar(max),
			@counts varchar(10)=(SELECT COUNT(DATE_RAISED) FROM [dbo].[Concern_Cause_Countermeasure]),
				
			@getType varchar(max)= (	
					SELECT							
					dbo.PERMISSION_GROUP.DESCR AS PERMISSION
					

FROM            dbo.EMPLOYEE INNER JOIN
                         dbo.CONTACTS ON 
						 dbo.EMPLOYEE.EMP_ID = dbo.CONTACTS.EMP_ID 						
						 INNER JOIN
                         dbo.PERMISSION_GROUP 
						 ON dbo.EMPLOYEE.GRP_ID = dbo.PERMISSION_GROUP.GRP_ID 
						

 WHERE dbo.CONTACTS.EMAIL_ADDRESS = @EMAILADDRESS),
 @getEMPID varchar(max) = (
					SELECT			
						dbo.EMPLOYEE.NICK_NAME
					
			    
FROM            dbo.EMPLOYEE INNER JOIN
                         dbo.CONTACTS ON 
						 dbo.EMPLOYEE.EMP_ID = dbo.CONTACTS.EMP_ID 
						

 WHERE dbo.CONTACTS.EMAIL_ADDRESS =  @EMAILADDRESS);
 


	SET @countPlusOne = 1 + CONVERT(int, @counts)		
	SET @num = CONVERT(varchar(max), @countPlusOne)
	SET @GetDateNow = CONVERT(VARCHAR(10),GETDATE(),103)
	SET @GENERATEDREF_ID = 'C'+ @num +'-' + @GetDateNow
	
	
BEGIN
		
		if @getType = 'Manager' 

		BEGIN 

				SELECT DISTINCT  
		A.[ID],
		A.[REF_ID], 
		A.[CONCERN],
		A.[CAUSE], 
		A.[COUNTERMEASURE], 
		E.NICK_NAME as EMP_ID , 
		
			 
	STUFF((SELECT  ', ' + CAST(a.ACTREF AS VARCHAR(MAX))
    FROM ACTION_REFERNCE_3CS a JOIN CONCERN_CAUSE_COUNTERMEASURE c  On (a.REF_ID = c.REF_ID)  where a.REF_ID =b.REF_ID
    FOR XML PATH(''),TYPE 
    ).value('.','VARCHAR(MAX)') 
  ,1,2,'') as ACT_REFERENCE,
		A.[DUE_DATE],
		A.DATE_RAISED,
		D.DESCR
			
	FROM STATUS D, [dbo].[Concern_Cause_Countermeasure] A LEFT JOIN ACTION_REFERNCE_3CS b ON A.REF_ID = b.REF_ID,
	dbo.EMPLOYEE E INNER JOIN dbo.CONTACTS F ON E.EMP_ID = F.EMP_ID
	WHERE A.EMP_ID = E.EMP_ID AND D.STATUS_ID = 8 AND D.STATUS = A.STATUS 
	AND E.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAILADDRESS) 
	AND E.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAILADDRESS)
	ORDER BY A.DATE_RAISED DESC
	OFFSET @OFFSETVAL ROWS FETCH NEXT @NEXTVAL ROWS ONLY

		END


		ELSE


		BEGIN


		SELECT DISTINCT  
		A.[ID],
		A.[REF_ID], 
		A.[CONCERN],
		A.[CAUSE], 
		A.[COUNTERMEASURE], 
		E.NICK_NAME as EMP_ID , 
		
			 
	STUFF((SELECT  ', ' + CAST(a.ACTREF AS VARCHAR(MAX))
    FROM ACTION_REFERNCE_3CS a JOIN CONCERN_CAUSE_COUNTERMEASURE c  On (a.REF_ID = c.REF_ID)  where a.REF_ID =b.REF_ID
    FOR XML PATH(''),TYPE 
    ).value('.','VARCHAR(MAX)') 
  ,1,2,'') as ACT_REFERENCE,
		A.[DUE_DATE],
		A.DATE_RAISED,
		D.DESCR
	
	FROM STATUS D, [dbo].[Concern_Cause_Countermeasure] A LEFT JOIN ACTION_REFERNCE_3CS b ON A.REF_ID = b.REF_ID,
	dbo.EMPLOYEE E INNER JOIN dbo.CONTACTS F ON E.EMP_ID = F.EMP_ID
	WHERE A.EMP_ID = E.EMP_ID AND D.STATUS_ID = 8 AND D.STATUS = A.STATUS 
	AND E.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAILADDRESS) 
	AND E.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					 ON A.EMP_ID = B.EMP_ID WHERE B.EMAIL_ADDRESS = @EMAILADDRESS)
	ORDER BY A.DATE_RAISED DESC
	OFFSET @OFFSETVAL ROWS FETCH NEXT @NEXTVAL ROWS ONLY
	END
END
GO
