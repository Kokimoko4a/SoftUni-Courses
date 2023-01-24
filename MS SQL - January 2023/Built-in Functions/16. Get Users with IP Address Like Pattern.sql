USE [Diablo]

SELECT [USERNAME],
	   [IpAddress]
	    AS [IP Address]
	     FROM [Users]
	WHERE [IpAddress] LIKE '___.1_%._%.___'
	 ORDER BY [USERNAME]