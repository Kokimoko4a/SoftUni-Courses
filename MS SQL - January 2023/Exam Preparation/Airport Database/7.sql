 SELECT TOP(20)
		fs.Id 
		AS DestinationId
		,[Start]
		,p.FullName
		,a.AirportName
		,TicketPrice
 FROM FlightDestinations AS fs
 JOIN Passengers AS p
 ON
 fs.PassengerId = p.Id
 JOIN Airports AS a
 ON
 fs.AirportId = a.Id
 WHERE DAY(fs.Start) % 2 = 0
 ORDER BY fs.TicketPrice DESC, a.AirportName


