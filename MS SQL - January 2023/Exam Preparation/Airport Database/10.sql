 SELECT a.AirportName
		,fs.Start
		AS DayTime
		,fs.TicketPrice
		,p.FullName
		,ac.Manufacturer
		,ac.Model
 FROM FlightDestinations AS fs
 JOIN Airports AS a
 ON
 fs.AirportId = a.Id
 JOIN Passengers AS p
 ON
 fs.PassengerId = p.Id
 JOIN Aircraft AS ac
 ON
 fs.AircraftId = ac.Id
 WHERE DATEPART(HOUR,fs.Start) BETWEEN 6 AND 20
 AND
 fs.TicketPrice > 2500
 ORDER BY ac.Model
