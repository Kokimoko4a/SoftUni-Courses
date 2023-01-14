CREATE DATABASE SoftUni

/*•	Towns (Id, Name)
•	Addresses (Id, AddressText, TownId)
•	Departments (Id, Name)
•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
*/

CREATE TABLE Towns(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50)

)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY NOT NULL IDENTITY,
	AddressText VARCHAR(100),
	TownId INT FOREIGN KEY REFERENCES TOWNS(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50)
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50),
	MiddleName VARCHAR(50),
	LastName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATETIME NOT NULL,
	Salary DECIMAL NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)
