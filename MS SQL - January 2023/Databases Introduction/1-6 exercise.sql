CREATE DATABASE Minions

--Minions (Id, Name, Age). Then add a new table Towns (Id, Name). Set Id columns of both tables to be primary key as constraint.


CREATE TABLE Minions(
	Id INT PRIMARY KEY NOT NULL,
	Name VARCHAR(100) NULL,
	Age INT 
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY NOT NULL,
	Name VARCHAR(100) NULL
)

-- Change the structure of the Minions table to have a new column TownId that would be of the same type as the Id column in Towns table. Add a new constraint that makes TownId foreign key and references to Id column in Towns table.

ALTER TABLE Minions 
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--1	Sofia
--2	Plovdiv
--3	Varna

INSERT INTO Towns 
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions 
VALUES (1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Stewart',NULL,2)


SELECT * FROM Minions
SELECT * FROM Towns

TRUNCATE TABLE Minions

DROP DATABASE Minions
