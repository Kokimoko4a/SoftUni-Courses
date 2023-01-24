USE [Diablo]

SELECT [Name] as [Game],
	    CASE
		  WHEN DATEPART(HOUR,[START]) >=0 AND DATEPART(HOUR,[START])<12 THEN 'Morning'
		  WHEN DATEPART(HOUR,[START]) >=12 AND DATEPART(HOUR,[START])<18 THEN 'Afternoon'
		  WHEN DATEPART(HOUR,[START]) >=18 AND DATEPART(HOUR,[START])<24 THEN 'Evening'	 
		  END
		    AS [Part of the Day],

		  CASE
		   WHEN [DURATION] <=3 THEN 'Extra Short'
		   WHEN [Duration] >=4 AND [Duration] <=6 THEN 'Short'
		   WHEN [DURATION] >6 THEN 'Long'
		   ELSE 'Extra Long'
		   END
		    AS [Duration]
	FROM Games 
	 ORDER BY [Game]
	 ,[Duration]
	 ,[Part of the Day]
