 SELECT p.FullName
		,COUNT(*)
		AS CountOfAircraft
		,SUM(TicketPrice)
		AS TotalPayed
 FROM Passengers AS p
 JOIN FlightDestinations AS fs
 ON
 p.Id = fs.PassengerId
 JOIN Aircraft AS a
 ON
 fs.AircraftId = a.Id
 WHERE LEFT(p.FullName,2) LIKE '%a'
 GROUP BY p.FullName
 HAVING COUNT(*) >= 2
 ORDER BY p.FullName
