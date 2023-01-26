USE [ZOO]

SELECT [Name]
       ,[PhoneNumber]
	   ,LTRIM(RIGHT(LTRIM([Address]),LEN(LTRIM([Address]))-7)) AS [Address]
FROM  [Volunteers] AS v
 WHERE [Address] LIKE '%Sofia%' AND
  v.[departmentID] = (SELECT [vd].[Id]
  FROM [VolunteersDepartments] as [vd]
   WHERE vd.DepartmentName = 'Education program assistant' )
 ORDER BY v.Name