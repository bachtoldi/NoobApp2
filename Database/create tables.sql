CREATE DATABASE [NoobApp]

USE [NoobApp]

CREATE TABLE [User] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[DisplayName] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Event] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(100) UNIQUE NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL
)

CREATE TABLE [Item] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL,
	[Image] NVARCHAR(MAX) NULL
)

CREATE TABLE [AttendanceType] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [EventAttendance] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_EventId] INT FOREIGN KEY REFERENCES [Event] ([Id]) NOT NULL,
	[FK_AttendanceTypeId] INT FOREIGN KEY REFERENCES [AttendanceType] ([Id]) NOT NULL,
	[Price] FLOAT NOT NULL
)

CREATE TABLE [UserAttendance] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_EventAttendanceId] INT FOREIGN KEY REFERENCES [EventAttendance] ([Id]) NOT NULL,
	[FK_UserId] INT FOREIGN KEY REFERENCES [User] ([Id]) NOT NULL
)

CREATE TABLE [Inventory] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_EventId] INT FOREIGN KEY REFERENCES [Event] ([Id]) NOT NULL,
	[FK_ItemId] INT FOREIGN KEY REFERENCES [Item] ([Id]) NOT NULL,
	[Price] FLOAT NOT NULL
)

CREATE TABLE [Purchase] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FK_InventoryId] INT FOREIGN KEY REFERENCES [Inventory] ([Id]) NOT NULL,
	[FK_UserId] INT FOREIGN KEY REFERENCES [User] ([Id]) NOT NULL,
	[Amount] INT NOT NULL
)