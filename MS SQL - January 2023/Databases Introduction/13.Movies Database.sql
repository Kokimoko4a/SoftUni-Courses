/*•	Directors (Id, DirectorName, Notes)
•	Genres (Id, GenreName, Notes)
•	Categories (Id, CategoryName, Notes)
•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
*/

CREATE TABLE Directors(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(100),
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT IDENTITY PRIMARY KEY  NOT NULL,
	GenreName NVARCHAR(100),
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(100),
	Notes VARCHAR(MAX)
)


CREATE TABLE Movies(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME NOT NULL,
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Directors VALUES 
('A','A'),
('A','A'),
('A','A'),
('A','A'),
('A','A')

INSERT INTO Genres VALUES 
('A','A'),
('A','A'),
('A','A'),
('A','A'),
('A','A')

INSERT INTO Categories VALUES
('A','A'),
('A','A'),
('A','A'),
('A','A'),
('A','A')

--Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)

INSERT INTO Movies VALUES 
('a',1,01-01-2020,3,4,3,3,NULL),
('a',1,01-01-2020,3,4,3,3,NULL),
('a',1,01-01-2020,3,4,3,3,NULL),
('a',1,01-01-2020,3,4,3,3,NULL),
('a',1,01-01-2020,3,4,3,3,NULL)
