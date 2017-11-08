DELETE FROM [ACCollector].[dbo].[Release];
DELETE FROM [ACCollector].[dbo].[Game];

-- Animal Forest
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('Animal Forest');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Dōbutsu no Mori', 'N64', '2001-04-14');
GO

-- Animal Forest+
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('Animal Forest+');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest+');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Dōbutsu no Mori+', 'GCN', '2001-12-14'),
(@GameId, 'CHN', 'Dòngwù Sēnlín', 'iQue', '2006-06-01');
GO

-- Animal Crossing
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('Animal Crossing');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'Animal Crossing');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'NA', 'Animal Crossing', 'GCN', '2002-09-15'),
(@GameId, 'AU', 'Animal Crossing', 'GCN', '2003-10-17'),
(@GameId, 'EU', 'Animal Crossing', 'GCN', '2004-09-24');
GO

-- Animal Forest e+
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('Animal Forest e+');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest e+');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Dōbutsu no Mori e+', 'GCN', '2003-06-27');
GO

-- Animal Crossing: Wild World
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('Wild World');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'Wild World');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Oideyo Dōbutsu no Mori', 'NDS', '2005-11-23'),
(@GameId, 'NA', 'Animal Crossing: Wild World', 'NDS', '2005-12-05'),
(@GameId, 'AU', 'Animal Crossing: Wild World', 'NDS', '2005-12-08'),
(@GameId, 'EU', 'Animal Crossing: Wild World', 'NDS', '2006-03-31');
GO

-- Animal Crossing: City Folk
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('City Folk');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'City Folk');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Machi e ikō yo: Dōbutsu no Mori', 'Wii', '2008-11-20'),
(@GameId, 'NA', 'Animal Crossing: City Folk', 'Wii', '2008-11-16'),
(@GameId, 'AU', 'Animal Crossing: Let''s Go to the City', 'Wii', '2008-11-04'),
(@GameId, 'EU', 'Animal Crossing: Let''s Go to the City', 'Wii', '2008-11-05');
GO

-- Animal Crossing: New Leaf
DECLARE @GameId UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game]([Name]) VALUES ('New Leaf');
SET @GameId = (SELECT [GameId] from [ACCollector].[dbo].[Game] Where Name = 'New Leaf');
INSERT INTO [ACCollector].[dbo].[Release]([GameId], [RegionCode], [Title], [PlatformCode], [ReleaseDate]) VALUES
(@GameId, 'JP', 'Tobidase Dōbutsu no Mori', '3DS', '2012-11-08'),
(@GameId, 'KOR', 'Animal Crossing: New Leaf', '3DS', '2013-02-07'),
(@GameId, 'NA', 'Animal Crossing: New Leaf', '3DS', '2013-06-09'),
(@GameId, 'AU', 'Animal Crossing: New Leaf', '3DS', '2013-06-15'),
(@GameId, 'EU', 'Animal Crossing: New Leaf', '3DS', '2013-06-14');
GO

