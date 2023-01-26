/*Select all animals and their type. Extract name, animal type and birth date (in format 'dd.MM.yyyy'). Order the result by animal‘s name (ascending).*/

SELECT [Name]
	   ,[at].AnimalType
	   ,FORMAT([BirthDate],'dd.MM.yyyy')
	    AS [BirthDate]
 FROM Animals AS a 
  JOIN AnimalTypes AS [at]
   ON a.AnimalTypeId = [at].Id 
ORDER BY [Name]