SELECT CONCAT([o].[Name],'-',[a].[Name]) AS [OwnersAnimals]
       ,[o].[PhoneNumber]
	   ,[ac].[CageId]
 FROM Owners AS o
 JOIN [Animals] AS a  
   ON o.Id = a.OwnerId
   JOIN [AnimalsCages] AS ac ON ac.AnimalId = a.Id
    WHERE [a].AnimalTypeId = 1
ORDER BY [o].Name, [a].Name DESC