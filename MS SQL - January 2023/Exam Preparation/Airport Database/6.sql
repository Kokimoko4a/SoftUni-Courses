 SELECT p.FirstName
		,p.LastName
		,a.Manufacturer
		,a.Model
		,a.FlightHours
 FROM Pilots AS p
 JOIN PilotsAircraft AS ps
 ON
 p.Id = ps.PilotId
 JOIN Aircraft AS a
 ON
 ps.AircraftId = a.Id
 WHERE a.FlightHours IS NOT NULL
 AND
 a.FlightHours<304
 ORDER BY a.FlightHours DESC, p.FirstName