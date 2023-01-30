 SELECT c.CountryCode
        ,COUNT(*)
 FROM Countries AS c 
 JOIN MountainsCountries AS mc
 ON
 c.CountryCode = mc.CountryCode
 WHERE c.CountryName IN ('United States','Russia','Bulgaria')
 GROUP BY c.CountryCode
