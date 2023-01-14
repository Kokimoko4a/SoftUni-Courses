CREATE DATABASE CarRental 

/*•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
*/

CREATE TABLE Categories(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(100) ,
	DailyRate INT ,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

CREATE TABLE Cars(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(50),
	Model VARCHAR (30),
	CarYear DATETIME,
	CategoryId INT,
	Doors INT,
	Picture VARCHAR(MAX),
	Condition CHAR(4),
	Available BIT
)

--Employees (Id, FirstName, LastName, Title, Notes)

CREATE TABLE Employees (
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Title VARCHAR(30),
	Notes VARCHAR(MAX)
)

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(50),
	Address VARCHAR(50),
	City VARCHAR(100),
	ZIPCode VARCHAR(50),
	Notes VARCHAR(MAX)
)

--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATETIME,
	EndDate DATETIME,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus CHAR(4),
	Notes VARCHAR(MAX)
)

--Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
INSERT INTO Categories VALUES
('A',1,1,1,1),
('A',1,1,1,1),
('A',1,1,1,1)

--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
INSERT INTO Cars VALUES
('KKK','D','H',01-01-2022,1,4,'JJJ','N',0),
('KKK','D','H',01-01-2022,1,4,'JJJ','N',0),
('KKK','D','H',01-01-2022,1,4,'JJJ','N',0)

--Employees (Id, FirstName, LastName, Title, Notes)
INSERT INTO Employees VALUES
('A','F','G','FFFFF'),
('A','F','G','FFFFF'),
('A','F','G','FFFFF')


--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
INSERT INTO Customers VALUES
('GGGG','FH','Rudozem - 12','Rudozem','222','EBASI QKOTO'),
('GGGG','FH','Rudozem - 12','Rudozem','222','EBASI QKOTO'),
('GGGG','FH','Rudozem - 12','Rudozem','222','EBASI QKOTO')


--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
INSERT INTO RentalOrders VALUES
(1,1,2,2,3,3,5,01-01-2022, 01-01-2023,333,5,250,'D','MNOGO QKO'),
(1,1,2,2,3,3,5,01-01-2022, 01-01-2023,333,5,250,'D','MNOGO QKO'),
(1,1,2,2,3,3,5,01-01-2022, 01-01-2023,333,5,250,'D','MNOGO QKO')

