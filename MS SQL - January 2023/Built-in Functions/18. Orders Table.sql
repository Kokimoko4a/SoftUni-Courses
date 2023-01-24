USE [Orders]

SELECT [ProductName],
	   [OrderDate]
	    as [Order Date],
		 DATEADD(DAY,3,[OrderDate])
		  AS [Pay Due],
		    DATEADD(MONTH,1,[OrderDate])
			 AS [Deliver Due]
	FROM [Orders]