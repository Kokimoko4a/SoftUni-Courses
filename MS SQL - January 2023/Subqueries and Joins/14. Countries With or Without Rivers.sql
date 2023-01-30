 SELECT TOP(5)
      CountryName
	  ,r.RiverName
 FROM (
 SELECT CountryName
	    ,CountryCode
 FROM Countries
 WHERE ContinentCode = 'AF'
 ) AS c
 LEFT JOIN CountriesRivers AS cr
 ON
 c.CountryCode = cr.CountryCode
 LEFT JOIN Rivers AS r
 ON
 cr.RiverId = r.Id
 ORDER BY c.CountryName
 
