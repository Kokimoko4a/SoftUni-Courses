 INSERT INTO Passengers 
 SELECT CONCAT(FirstName,' ',LastName),
		CONCAT(FirstName,LastName,'@gmail.com')
 FROM Pilots
 WHERE Id BETWEEN 5 AND 15



