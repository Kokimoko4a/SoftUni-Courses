/*Create a SQL query that finds all towns, which do not start with 'R', 'B' or 'D'. Order the result alphabetically by name. */
USE SoftUni

SELECT * FROM Towns
 WHERE [Name] NOT LIKE 'R%'
  AND [Name] NOT LIKE 'B%'
   AND [Name] NOT LIKE 'D%'
    ORDER BY [Name] ASC