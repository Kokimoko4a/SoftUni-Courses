 SELECT  a.Id
		 ,a.Manufacturer
		 ,a.FlightHours
		,COUNT(*) 
		AS FlightDestinationsCount
		,ROUND(AVG(TicketPrice),2)
		AS AvgPrice
 FROM Aircraft AS a 
 JOIN FlightDestinations AS fs
 ON
 a.Id = fs.AircraftId
 GROUP BY a.Id,a.Manufacturer,a.FlightHours
 HAVING COUNT(*) >=2
 ORDER BY COUNT(*) DESC,a.Id