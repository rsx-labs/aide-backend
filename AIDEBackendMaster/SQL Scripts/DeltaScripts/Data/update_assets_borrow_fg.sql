USE AIDE

UPDATE dbo.[ASSETS] SET BORROW_FG = 1 WHERE 
ASSET_TAG IN	('CCE0017791', 
				'CCE0020713', 
				'CCEI601264', 
				'CN0011154', 
				'CCE0005863', 
				'LVGDC000003', 
				'LVGDC000004', 
				'CN0011160', 
				'SPEFY190114', 
				'SPEFY190115')
