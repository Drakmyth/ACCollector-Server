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

CREATE TABLE [dbo].[IslandStatus] (
	IslandStatus VARCHAR(10) NOT NULL
	CONSTRAINT PK_IslandStatus PRIMARY KEY CLUSTERED (IslandStatus)
);
GO

INSERT INTO [dbo].[IslandStatus](IslandStatus) VALUES
('None'),
('Available'),
('Exclusive');
GO

CREATE TABLE [dbo].[Size] (
	Size VARCHAR(10) NOT NULL
	CONSTRAINT PK_Size PRIMARY KEY CLUSTERED (Size)
);
GO

INSERT INTO [dbo].[Size](Size) VALUES
('Tiny'),
('Small'),
('Medium'),
('Large'),
('Very Large'),
('Huge'),
('Long'),
('Fin');
GO

CREATE TABLE [dbo].[Release] (
    [ReleaseId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Release_ReleaseId DEFAULT NEWSEQUENTIALID(),
    [GameId] UNIQUEIDENTIFIER NOT NULL,
	[RegionCode] VARCHAR(3) NOT NULL,
	[Title] NVARCHAR(60) NOT NULL,
	[PlatformCode] VARCHAR(4) NOT NULL,
	[ReleaseDate] DATETIME2 NOT NULL
	CONSTRAINT PK_Release PRIMARY KEY CLUSTERED (ReleaseId),
	CONSTRAINT FK_Release_Game_GameId FOREIGN KEY (GameId) REFERENCES [dbo].[Game](GameId) ON DELETE CASCADE,
	CONSTRAINT FK_Release_Region_RegionCode FOREIGN KEY (RegionCode) REFERENCES [dbo].[Region](RegionCode),
	CONSTRAINT FK_Release_Platform_PlatformCode FOREIGN KEY (PlatformCode) REFERENCES [dbo].[Platform](PlatformCode)
);
GO

CREATE TABLE [dbo].[Bug] (
	[BugId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Bug_BugId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[SalePrice] INT NOT NULL,
	[Location] VARCHAR(10) NOT NULL,
	[IslandStatus] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Bug PRIMARY KEY CLUSTERED (BugId),
	CONSTRAINT FK_Bug_Game_GameId FOREIGN KEY (GameId) REFERENCES [dbo].[Game](GameId) ON DELETE CASCADE,
	CONSTRAINT FK_Bug_IslandStatus_IslandStatus FOREIGN KEY (IslandStatus) REFERENCES [dbo].[IslandStatus](IslandStatus),
	CONSTRAINT CHK_Bug_SalePrice CHECK (SalePrice >= 0)
);
GO

CREATE TABLE [dbo].[BugAvailability] (
	[BugId] UNIQUEIDENTIFIER NOT NULL,
	[StartMonth] INT NOT NULL,
	[StartHour] INT NOT NULL,
	[EndMonth] INT NOT NULL,
	[EndHour] INT NOT NULL,
	[StartsMidMonth] BIT NOT NULL CONSTRAINT DF_BugAvailability_StartsMidMonth DEFAULT 0,
	[EndsMidMonth] BIT NOT NULL CONSTRAINT DF_BugAvailability_EndsMidMonth DEFAULT 0
	CONSTRAINT PK_BugAvailability PRIMARY KEY CLUSTERED (BugId)
	CONSTRAINT FK_BugAvailability_Bug_BugId FOREIGN KEY (BugId) REFERENCES [dbo].[Bug](BugId) ON DELETE CASCADE,
	CONSTRAINT CHK_BugAvailability_StartMonth CHECK (StartMonth >= 1 AND StartMonth <= 12),
	CONSTRAINT CHK_BugAvailability_StartHour CHECK (StartHour >= 0 AND StartHour <= 23),
	CONSTRAINT CHK_BugAvailability_EndMonth CHECK (EndMonth >= 1 AND EndMonth <= 12),
	CONSTRAINT CHK_BugAvailability_EndHour CHECK (EndHour >= 0 AND EndHour <= 23)
);
GO

CREATE TABLE [dbo].[Fish] (
	[FishId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Fish_FishId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[SalePrice] INT NOT NULL,
	[Size] VARCHAR(10) NOT NULL,
	[Location] VARCHAR(10) NOT NULL,
	[IslandStatus] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Fish PRIMARY KEY CLUSTERED (FishId),
	CONSTRAINT FK_Fish_Game_GameId FOREIGN KEY (GameId) REFERENCES [dbo].[Game](GameId) ON DELETE CASCADE,
	CONSTRAINT FK_Fish_Size_Size FOREIGN KEY (Size) REFERENCES [dbo].[Size](Size),
	CONSTRAINT FK_Fish_IslandStatus_IslandStatus FOREIGN KEY (IslandStatus) REFERENCES [dbo].[IslandStatus](IslandStatus),
	CONSTRAINT CHK_Fish_SalePrice CHECK (SalePrice >= 0)
);
GO

CREATE TABLE [dbo].[FishAvailability] (
	[FishId] UNIQUEIDENTIFIER NOT NULL,
	[StartMonth] INT NOT NULL,
	[StartHour] INT NOT NULL,
	[EndMonth] INT NOT NULL,
	[EndHour] INT NOT NULL,
	[StartsMidMonth] BIT NOT NULL CONSTRAINT DF_FishAvailability_StartsMidMonth DEFAULT 0,
	[EndsMidMonth] BIT NOT NULL CONSTRAINT DF_FishAvailability_EndsMidMonth DEFAULT 0
	CONSTRAINT PK_FishAvailability PRIMARY KEY CLUSTERED (FishId)
	CONSTRAINT FK_FishAvailability_Fish_FishId FOREIGN KEY (FishId) REFERENCES [dbo].[Fish](FishId) ON DELETE CASCADE,
	CONSTRAINT CHK_FishAvailability_StartMonth CHECK (StartMonth >= 1 AND StartMonth <= 12),
	CONSTRAINT CHK_FishAvailability_StartHour CHECK (StartHour >= 0 AND StartHour <= 23),
	CONSTRAINT CHK_FishAvailability_EndMonth CHECK (EndMonth >= 1 AND EndMonth <= 12),
	CONSTRAINT CHK_FishAvailability_EndHour CHECK (EndHour >= 0 AND EndHour <= 23)
);
GO