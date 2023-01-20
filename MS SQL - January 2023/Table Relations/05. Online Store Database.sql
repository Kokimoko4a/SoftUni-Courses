CREATE DATABASE [Online Store]

USE [Online Store]

CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY NOT NULL PRIMARY KEY,
	Name VARCHAR(100) NOT NULL
)

CREATE TABLE Cities
(
	CityID INT IDENTITY NOT NULL PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	Birthday DATETIME NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders 
(
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY(OrderID,ItemID)
)