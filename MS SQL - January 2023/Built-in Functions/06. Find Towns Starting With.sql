/*Create a SQL query that finds all towns with names starting with 'M', 'K', 'B' or 'E'. Order the result alphabetically by town name*/
USE SoftUni

SELECT * FROM Towns
 WHERE [Name] LIKE 'M%'
  OR [Name] LIKE 'K%'
   OR [Name] LIKE 'B%'
    OR [Name] LIKE 'E%'
	 ORDER BY [Name] ASC