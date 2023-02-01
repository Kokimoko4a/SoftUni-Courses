 CREATE OR ALTER PROC usp_GetTownsStartingWith @TownName VARCHAR(MAX)
 AS
 SELECT Name
 FROM Towns
 WHERE Name LIKE CONCAT(@TownName,'%')

 EXECUTE usp_GetTownsStartingWith 'bE'