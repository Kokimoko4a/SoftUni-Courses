/*•	Id – unique number. For every person there will be no more than 231-1 people (auto incremented).
•	Name – full name of the person. There will be no more than 200 Unicode characters (not null).
•	Picture – image with size up to 2 MB (allow nulls).
•	Height – in meters. Real number precise up to 2 digits after floating point (allow nulls).
•	Weight – in kilograms. Real number precise up to 2 digits after floating point (allow nulls).
•	Gender – possible states are m or f (not null).
•	Birthdate – (not null).
•	Biography – detailed biography of the person. It can contain max allowed Unicode characters (allow nulls).*/

CREATE TABLE People(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) NULL,
	[Height] DECIMAL NULL,
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME NOT NULL,
	Biography NVARCHAR(MAX)

)

INSERT INTO People  VALUES
('A',NULL,NULL,'m',2023-01-13,NULL),
('G',NULL,NULL,'m',2023-01-13,NULL),
('H',NULL,NULL,'m',2023-01-13,NULL),
('K',NULL,NULL,'m',2023-01-13,NULL),
('L',NULL,NULL,'m',2023-01-13,NULL)
