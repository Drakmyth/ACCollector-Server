USE master;
GO

CREATE DATABASE ACCollector
GO

USE [ACCollector]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Game] (
    [GameId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Game_GameId DEFAULT NEWSEQUENTIALID(),
    [Name] VARCHAR (60) NOT NULL,
	CONSTRAINT PK_Game PRIMARY KEY CLUSTERED (GameId)
);
GO

CREATE TABLE [dbo].[Region] (
	[RegionCode] VARCHAR(3) NOT NULL,
	[Description] VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Region PRIMARY KEY CLUSTERED (RegionCode)
);
GO

INSERT INTO [dbo].[Region](RegionCode, Description) VALUES
('JP', 'Japan'),
('NA', 'North America'),
('EU', 'Europe'),
('AU', 'Australasia'),
('KOR', 'South Korea'),
('CHN', 'China');
GO

CREATE TABLE [dbo].[Platform] (
	[PlatformCode] VARCHAR(4) NOT NULL,
	[Description] VARCHAR(40) NOT NULL,
	CONSTRAINT PK_Platform PRIMARY KEY CLUSTERED (PlatformCode)
);
GO

INSERT INTO [dbo].[Platform](PlatformCode, Description) VALUES
('N64', 'Nintendo 64'),
('GCN', 'Nintendo Gamecube'),
('iQue', 'iQue Player'),
('NDS', 'Nintendo DS'),
('Wii', 'Nintendo Wii'),
('3DS', 'Nintendo 3DS');
GO

CREATE TABLE [dbo].[Release] (
    [ReleaseId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Release_ReleaseId DEFAULT NEWSEQUENTIALID(),
    [GameId] UNIQUEIDENTIFIER NOT NULL,
	[RegionCode] VARCHAR(3) NOT NULL,
	[Title] NVARCHAR(60) NOT NULL,
	[PlatformCode] VARCHAR(4) NOT NULL,
	[ReleaseDate] DATETIME2 NOT NULL
	CONSTRAINT PK_Release PRIMARY KEY CLUSTERED (ReleaseId),
	CONSTRAINT FK_Release_Game_GameId FOREIGN KEY (GameId) REFERENCES [dbo].[Game](GameId),
	CONSTRAINT FK_Release_Region_RegionCode FOREIGN KEY (RegionCode) REFERENCES [dbo].[Region](RegionCode),
	CONSTRAINT FK_Release_Platform_PlatformCode FOREIGN KEY (PlatformCode) REFERENCES [dbo].[Platform](PlatformCode)
);
GO