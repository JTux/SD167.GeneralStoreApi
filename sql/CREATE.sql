CREATE DATABASE GeneralStoreDb
GO

USE GeneralStoreDb
GO

CREATE SCHEMA dev
GO

CREATE SCHEMA prod
GO

CREATE TABLE dev.Products
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL,
    [QuantityInStock] INT NOT NULL CHECK (QuantityInStock >= 0),
    [Price] FLOAT NOT NULL
)

CREATE TABLE dev.Customers
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE dev.Transactions
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [ProductId] INT NOT NULL,
    [CustomerId] INT NOT NULL,
    [Quantity] INT NOT NULL CHECK (Quantity > 0),
    [DateOfTransaction] DATETIME NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES dev.Products(Id),
    FOREIGN KEY (CustomerId) REFERENCES dev.Customers(Id),
)
GO