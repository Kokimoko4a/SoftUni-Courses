USE Geography

SELECT CountryName
  ,CountryCode
  ,CASE
 [CurrencyCode] WHEN 'EUR' THEN 'Euro'
 ELSE 'Not Euro' 
END
 FROM Countries
 ORDER BY [CountryName]