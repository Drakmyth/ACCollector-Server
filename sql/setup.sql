USE [master];
GO

CREATE DATABASE [ACCollector]
GO

CREATE TABLE [ACCollector].[dbo].[Game] (
    [GameId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Game_GameId DEFAULT NEWSEQUENTIALID(),
    [Name] VARCHAR (60) NOT NULL,
	CONSTRAINT PK_Game PRIMARY KEY CLUSTERED ([GameId]),
	CONSTRAINT UNQ_Game_Name UNIQUE ([Name])
);
GO

CREATE TABLE [ACCollector].[dbo].[Region] (
	[RegionCode] VARCHAR(3) NOT NULL,
	[Description] VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Region PRIMARY KEY CLUSTERED ([RegionCode])
);
GO

INSERT INTO [ACCollector].[dbo].[Region]([RegionCode], [Description]) VALUES
('JP', 'Japan'),
('NA', 'North America'),
('EU', 'Europe'),
('AU', 'Australasia'),
('KOR', 'South Korea'),
('CHN', 'China');
GO

CREATE TABLE [ACCollector].[dbo].[Platform] (
	[PlatformCode] VARCHAR(4) NOT NULL,
	[Description] VARCHAR(40) NOT NULL,
	CONSTRAINT PK_Platform PRIMARY KEY CLUSTERED ([PlatformCode])
);
GO

INSERT INTO [ACCollector].[dbo].[Platform]([PlatformCode], [Description]) VALUES
('N64', 'Nintendo 64'),
('GCN', 'Nintendo Gamecube'),
('iQue', 'iQue Player'),
('NDS', 'Nintendo DS'),
('Wii', 'Nintendo Wii'),
('3DS', 'Nintendo 3DS');
GO

CREATE TABLE [ACCollector].[dbo].[IslandStatus] (
	[IslandStatus] VARCHAR(10) NOT NULL
	CONSTRAINT PK_IslandStatus PRIMARY KEY CLUSTERED ([IslandStatus])
);
GO

INSERT INTO [ACCollector].[dbo].[IslandStatus]([IslandStatus]) VALUES
('None'),
('Available'),
('Exclusive');
GO

CREATE TABLE [ACCollector].[dbo].[FishSize] (
	[Size] VARCHAR(10) NOT NULL
	CONSTRAINT PK_FishSize PRIMARY KEY CLUSTERED ([Size])
);
GO

INSERT INTO [ACCollector].[dbo].[FishSize]([Size]) VALUES
('Tiny'),
('Small'),
('Medium'),
('Large'),
('Very Large'),
('Huge'),
('Long'),
('Fin');
GO

CREATE TABLE [ACCollector].[dbo].[ArtType] (
	[Type] VARCHAR(10) NOT NULL
	CONSTRAINT PK_ArtType PRIMARY KEY CLUSTERED ([Type])
);
GO

INSERT INTO [ACCollector].[dbo].[ArtType]([Type]) VALUES
('Painting'),
('Sculpture');
GO

CREATE TABLE [ACCollector].[dbo].[ArtSource] (
	[Source] VARCHAR(10) NOT NULL
	CONSTRAINT PK_ArtSource PRIMARY KEY CLUSTERED ([Source])
);
GO

INSERT INTO [ACCollector].[dbo].[ArtSource]([Source]) VALUES
('Crazy Redd'),
('Spotlight');
GO

CREATE TABLE [ACCollector].[dbo].[FossilGroup] (
	[Group] VARCHAR(20) NOT NULL
	CONSTRAINT PK_FossilGroup PRIMARY KEY CLUSTERED ([Group])
);
GO

INSERT INTO [ACCollector].[dbo].[FossilGroup]([Group]) VALUES
('Ankylosaurus'),
('Apatosaurus'),
('Archelon'),
('Dimetrodon'),
('Diplodocus'),
('Ichthyosaur'),
('Iguanodon'),
('Mammoth'),
('Megacerops'),
('Pachycephalosaurus'),
('Parasaur'),
('Plesiosaur'),
('Pteranodon'),
('Sabretooth Tiger'),
('Seismosaur'),
('Stegosaur'),
('Spinosaurus'),
('Styracosaurus'),
('Triceratops'),
('Tyrannosaurus Rex'),
('Velociraptor'),
('Standalone');
GO

CREATE TABLE [ACCollector].[dbo].[Release] (
    [ReleaseId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Release_ReleaseId DEFAULT NEWSEQUENTIALID(),
    [GameId] UNIQUEIDENTIFIER NOT NULL,
	[RegionCode] VARCHAR(3) NOT NULL,
	[Title] NVARCHAR(60) NOT NULL,
	[PlatformCode] VARCHAR(4) NOT NULL,
	[ReleaseDate] DATETIME2 NOT NULL
	CONSTRAINT PK_Release PRIMARY KEY CLUSTERED ([ReleaseId]),
	CONSTRAINT FK_Release_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_Release_Region_RegionCode FOREIGN KEY ([RegionCode]) REFERENCES [ACCollector].[dbo].[Region]([RegionCode]),
	CONSTRAINT FK_Release_Platform_PlatformCode FOREIGN KEY ([PlatformCode]) REFERENCES [ACCollector].[dbo].[Platform]([PlatformCode])
);
GO

CREATE TABLE [ACCollector].[dbo].[BugLocation] (
	[Location] VARCHAR(15) NOT NULL
	CONSTRAINT PK_BugLocation PRIMARY KEY CLUSTERED ([Location])
);
GO

INSERT INTO [ACCollector].[dbo].[BugLocation]([Location]) VALUES
('Air'),
('Trees'),
('Ground'),
('Flowers'),
('Grass'),
('Water'),
('Rocks'),
('Trash'),
('Candy'),
('Villagers'),
('Snowballs'),
('Outdoor Lights');
GO

CREATE TABLE [ACCollector].[dbo].[FishLocation] (
	[Location] VARCHAR(15) NOT NULL
	CONSTRAINT PK_FishLocation PRIMARY KEY CLUSTERED ([Location])
);
GO

INSERT INTO [ACCollector].[dbo].[FishLocation]([Location]) VALUES
('River'),
('River Pool'),
('River Mouth'),
('Waterfall'),
('Holding Pond'),
('Ocean');
GO

CREATE TABLE [ACCollector].[dbo].[Bug] (
	[BugId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Bug_BugId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[InGameId] INT NOT NULL,
	[Name] VARCHAR(40) NOT NULL,
	[SalePrice] INT NOT NULL,
	[Location] VARCHAR(15) NOT NULL,
	[IslandStatus] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Bug PRIMARY KEY CLUSTERED ([BugId]),
	CONSTRAINT FK_Bug_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_Bug_BugLocation_Location FOREIGN KEY ([Location]) REFERENCES [ACCollector].[dbo].[BugLocation]([Location]),
	CONSTRAINT FK_Bug_IslandStatus_IslandStatus FOREIGN KEY ([IslandStatus]) REFERENCES [ACCollector].[dbo].[IslandStatus]([IslandStatus]),
	CONSTRAINT UNQ_Bug_GameId_InGameId UNIQUE ([GameId], [InGameId]),
	CONSTRAINT CHK_Bug_SalePrice CHECK ([SalePrice] >= 0)
);
GO

CREATE TABLE [ACCollector].[dbo].[Fish] (
	[FishId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Fish_FishId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[InGameId] INT NOT NULL,
	[Name] VARCHAR(40) NOT NULL,
	[SalePrice] INT NOT NULL,
	[Size] VARCHAR(10) NOT NULL,
	[Location] VARCHAR(15) NOT NULL,
	[IslandStatus] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Fish PRIMARY KEY CLUSTERED ([FishId]),
	CONSTRAINT FK_Fish_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_Fish_FishSize_Size FOREIGN KEY ([Size]) REFERENCES [ACCollector].[dbo].[FishSize]([Size]),
	CONSTRAINT FK_Fish_FishLocation_Location FOREIGN KEY ([Location]) REFERENCES [ACCollector].[dbo].[FishLocation]([Location]),
	CONSTRAINT FK_Fish_IslandStatus_IslandStatus FOREIGN KEY ([IslandStatus]) REFERENCES [ACCollector].[dbo].[IslandStatus]([IslandStatus]),
	CONSTRAINT UNQ_Fish_GameId_InGameId UNIQUE ([GameId], [InGameId]),
	CONSTRAINT CHK_Fish_SalePrice CHECK ([SalePrice] >= 0)
);
GO

CREATE TABLE [ACCollector].[dbo].[DeepSeaCreature] (
	[DeepSeaCreatureId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_DeepSeaCreature_DeepSeaCreatureId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[InGameId] INT NOT NULL,
	[Name] VARCHAR(40) NOT NULL,
	[SalePrice] INT NOT NULL,
	[Size] VARCHAR(10) NOT NULL,
	[IslandStatus] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_DeepSeaCreature PRIMARY KEY CLUSTERED ([DeepSeaCreatureId]),
	CONSTRAINT FK_DeepSeaCreature_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_DeepSeaCreature_FishSize_Size FOREIGN KEY ([Size]) REFERENCES [ACCollector].[dbo].[FishSize]([Size]),
	CONSTRAINT FK_DeepSeaCreature_IslandStatus_IslandStatus FOREIGN KEY ([IslandStatus]) REFERENCES [ACCollector].[dbo].[IslandStatus]([IslandStatus]),
	CONSTRAINT UNQ_DeepSeaCreature_GameId_InGameId UNIQUE ([GameId], [InGameId]),
	CONSTRAINT CHK_DeepSeaCreature_SalePrice CHECK ([SalePrice] >= 0)
);
GO

CREATE TABLE [ACCollector].[dbo].[Art] (
	[ArtId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Art_ArtId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(40) NOT NULL,
	[PurchasePrice] INT NOT NULL,
	[SalePrice] INT NOT NULL,
	[Type] VARCHAR(10) NOT NULL,
	[Source] VARCHAR(10) NOT NULL,
	CONSTRAINT PK_Art PRIMARY KEY CLUSTERED ([ArtId]),
	CONSTRAINT FK_Art_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_Art_ArtType_Type FOREIGN KEY ([Type]) REFERENCES [ACCollector].[dbo].[ArtType]([Type]),
	CONSTRAINT FK_Art_ArtSource_Source FOREIGN KEY ([Source]) REFERENCES [ACCollector].[dbo].[ArtSource]([Source]),
	CONSTRAINT CHK_Art_PurchasePrice CHECK ([PurchasePrice] >= 0),
	CONSTRAINT CHK_Art_SalePrice CHECK ([SalePrice] >= 0)
);
GO

CREATE TABLE [ACCollector].[dbo].[Fossil] (
	[FossilId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Fossil_FossilId DEFAULT NEWSEQUENTIALID(),
	[GameId] UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(40) NOT NULL,
	[SalePrice] INT NOT NULL,
	[Group] VARCHAR(20) NOT NULL,
	CONSTRAINT PK_Fossil PRIMARY KEY CLUSTERED ([FossilId]),
	CONSTRAINT FK_Fossil_Game_GameId FOREIGN KEY ([GameId]) REFERENCES [ACCollector].[dbo].[Game]([GameId]) ON DELETE CASCADE,
	CONSTRAINT FK_Fossil_FossilGroup_Group FOREIGN KEY ([Group]) REFERENCES [ACCollector].[dbo].[FossilGroup]([Group]),
	CONSTRAINT CHK_Fossil_SalePrice CHECK ([SalePrice] >= 0)
);
GO

CREATE TABLE [ACCollector].[dbo].[Availability] (
	[AvailabilityId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Availability_AvailabilityId DEFAULT NEWSEQUENTIALID(),
	[StartMonth] INT NOT NULL,
	[StartHour] INT NOT NULL,
	[EndMonth] INT NOT NULL,
	[EndHour] INT NOT NULL,
	[StartsMidMonth] BIT NOT NULL CONSTRAINT DF_Availability_StartsMidMonth DEFAULT 0,
	[EndsMidMonth] BIT NOT NULL CONSTRAINT DF_Availability_EndsMidMonth DEFAULT 0
	CONSTRAINT PK_Availability PRIMARY KEY CLUSTERED ([AvailabilityId]),
	CONSTRAINT CHK_Availability_StartMonth CHECK ([StartMonth] >= 1 AND [StartMonth] <= 12),
	CONSTRAINT CHK_Availability_StartHour CHECK ([StartHour] >= 0 AND [StartHour] <= 23),
	CONSTRAINT CHK_Availability_EndMonth CHECK ([EndMonth] >= 1 AND [EndMonth] <= 12),
	CONSTRAINT CHK_Availability_EndHour CHECK ([EndHour] >= 0 AND [EndHour] <= 23)
);
GO

CREATE TABLE [ACCollector].[dbo].[BugAvailability] (
	[BugId] UNIQUEIDENTIFIER NOT NULL,
	[AvailabilityId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT PK_BugAvailability PRIMARY KEY CLUSTERED ([BugId], [AvailabilityId]),
	CONSTRAINT FK_BugAvailability_Bug_BugId FOREIGN KEY ([BugId]) REFERENCES [ACCollector].[dbo].[Bug]([BugId]) ON DELETE CASCADE,
	CONSTRAINT FK_BugAvailability_Availability_AvailabilityId FOREIGN KEY ([AvailabilityId]) REFERENCES [ACCollector].[dbo].[Availability]([AvailabilityId]) -- TODO: Delete Trigger to clean up Availability
);
GO

CREATE TABLE [ACCollector].[dbo].[FishAvailability] (
	[FishId] UNIQUEIDENTIFIER NOT NULL,
	[AvailabilityId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT PK_FishAvailability PRIMARY KEY CLUSTERED ([FishId], [AvailabilityId])
	CONSTRAINT FK_FishAvailability_Fish_FishId FOREIGN KEY ([FishId]) REFERENCES [ACCollector].[dbo].[Fish]([FishId]) ON DELETE CASCADE,
	CONSTRAINT FK_FishAvailability_Availability_AvailabilityId FOREIGN KEY ([AvailabilityId]) REFERENCES [ACCollector].[dbo].[Availability]([AvailabilityId]) -- TODO: Delete Trigger to clean up Availability
);
GO

CREATE TABLE [ACCollector].[dbo].[DeepSeaCreatureAvailability] (
	[DeepSeaCreatureId] UNIQUEIDENTIFIER NOT NULL,
	[AvailabilityId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT PK_DeepSeaCreatureAvailability PRIMARY KEY CLUSTERED ([DeepSeaCreatureId], [AvailabilityId])
	CONSTRAINT FK_DeepSeaCreatureAvailability_DeepSeaCreature_DeepSeaCreatureId FOREIGN KEY ([DeepSeaCreatureId]) REFERENCES [ACCollector].[dbo].[DeepSeaCreature]([DeepSeaCreatureId]) ON DELETE CASCADE,
	CONSTRAINT FK_DeepSeaCreatureAvailability_Availability_AvailabilityId FOREIGN KEY ([AvailabilityId]) REFERENCES [ACCollector].[dbo].[Availability]([AvailabilityId]) -- TODO: Delete Trigger to clean up Availability
);
GO

CREATE TABLE [ACCollector].[dbo].[Note] (
	[NoteId] UNIQUEIDENTIFIER NOT NULL CONSTRAINT DF_Note_NoteId DEFAULT NEWSEQUENTIALID(),
	[Message] VARCHAR(255) NOT NULL,
	CONSTRAINT PK_Note PRIMARY KEY CLUSTERED ([NoteId])
);
GO

CREATE TABLE [ACCollector].[dbo].[BugNote] (
	[BugId] UNIQUEIDENTIFIER NOT NULL,
	[NoteId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT PK_BugNote PRIMARY KEY CLUSTERED ([BugId], [NoteId]),
	CONSTRAINT FK_BugNote_Bug_BugId FOREIGN KEY ([BugId]) REFERENCES [ACCollector].[dbo].[Bug]([BugId]) ON DELETE CASCADE,
	CONSTRAINT FK_BugNote_Note_NoteId FOREIGN KEY ([NoteId]) REFERENCES [ACCollector].[dbo].[Note]([NoteId]) -- TODO: Delete Trigger to clean up Note
);
GO

CREATE TABLE [ACCollector].[dbo].[FishNote] (
	[FishId] UNIQUEIDENTIFIER NOT NULL,
	[NoteId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT PK_FishNote PRIMARY KEY CLUSTERED ([FishId], [NoteId]),
	CONSTRAINT FK_FishNote_Fish_FishId FOREIGN KEY ([FishId]) REFERENCES [ACCollector].[dbo].[Fish]([FishId]) ON DELETE CASCADE,
	CONSTRAINT FK_FishNote_Note_NoteId FOREIGN KEY ([NoteId]) REFERENCES [ACCollector].[dbo].[Note]([NoteId]) -- TODO: Delete Trigger to clean up Note
);
GO

CREATE TABLE [ACCollector].[dbo].[DeepSeaCreatureNote] (
	[DeepSeaCreatureId] UNIQUEIDENTIFIER NOT NULL,
	[NoteId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT PK_DeepSeaCreatureNote PRIMARY KEY CLUSTERED ([DeepSeaCreatureId], [NoteId]),
	CONSTRAINT FK_DeepSeaCreatureNote_DeepSeaCreature_DeepSeaCreatureId FOREIGN KEY ([DeepSeaCreatureId]) REFERENCES [ACCollector].[dbo].[DeepSeaCreature]([DeepSeaCreatureId]) ON DELETE CASCADE,
	CONSTRAINT FK_DeepSeaCreatureNote_Note_NoteId FOREIGN KEY ([NoteId]) REFERENCES [ACCollector].[dbo].[Note]([NoteId]) -- TODO: Delete Trigger to clean up Note
);
GO