SELECT [Name]
       ,YEAR([BirthDate]) AS [AnimalType]
	   ,[AnimalType]
 FROM [Animals] AS [a]
  JOIN AnimalTypes as [aT]
   ON a.AnimalTypeId = [aT].Id
   WHERE YEAR([a].[BirthDate]) <=2022 AND YEAR([a].[BirthDate]) >=2018 AND
    [AnimalType] NOT LIKE 'Birds'
	 AND [a].[OwnerId] IS NULL
   ORDER BY [a].[Name]