DELETE FROM [ACCollector].[dbo].[Release];
DELETE FROM [ACCollector].[dbo].[Game];

-- Animal Forest
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('Animal Forest');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Dōbutsu no Mori', 'N64', '2001-04-14');
GO

-- Animal Forest+
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('Animal Forest+');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest+');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Dōbutsu no Mori+', 'GCN', '2001-12-14'),
(@Id, 'CHN', 'Dòngwù Sēnlín', 'iQue', '2006-06-01');
GO

-- Animal Crossing
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('Animal Crossing');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'Animal Crossing');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'NA', 'Animal Crossing', 'GCN', '2002-09-15'),
(@Id, 'AU', 'Animal Crossing', 'GCN', '2003-10-17'),
(@Id, 'EU', 'Animal Crossing', 'GCN', '2004-09-24');
GO

-- Animal Forest e+
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('Animal Forest e+');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'Animal Forest e+');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Dōbutsu no Mori e+', 'GCN', '2003-06-27');
GO

-- Animal Crossing: Wild World
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('Wild World');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'Wild World');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Oideyo Dōbutsu no Mori', 'NDS', '2005-11-23'),
(@Id, 'NA', 'Animal Crossing: Wild World', 'NDS', '2005-12-05'),
(@Id, 'AU', 'Animal Crossing: Wild World', 'NDS', '2005-12-08'),
(@Id, 'EU', 'Animal Crossing: Wild World', 'NDS', '2006-03-31');
GO

-- Animal Crossing: City Folk
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('City Folk');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'City Folk');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Machi e ikō yo: Dōbutsu no Mori', 'Wii', '2008-11-20'),
(@Id, 'NA', 'Animal Crossing: City Folk', 'Wii', '2008-11-16'),
(@Id, 'AU', 'Animal Crossing: Let''s Go to the City', 'Wii', '2008-11-04'),
(@Id, 'EU', 'Animal Crossing: Let''s Go to the City', 'Wii', '2008-11-05');
GO

-- Animal Crossing: New Leaf
DECLARE @Id UNIQUEIDENTIFIER;
INSERT INTO [ACCollector].[dbo].[Game](Name) VALUES ('New Leaf');
SET @Id = (SELECT GameId from [ACCollector].[dbo].[Game] Where Name = 'New Leaf');
INSERT INTO [ACCollector].[dbo].[Release](GameId, RegionCode, Title, PlatformCode, ReleaseDate) VALUES
(@Id, 'JP', 'Tobidase Dōbutsu no Mori', '3DS', '2012-11-08'),
(@Id, 'KOR', 'Animal Crossing: New Leaf', '3DS', '2013-02-07'),
(@Id, 'NA', 'Animal Crossing: New Leaf', '3DS', '2013-06-09'),
(@Id, 'AU', 'Animal Crossing: New Leaf', '3DS', '2013-06-15'),
(@Id, 'EU', 'Animal Crossing: New Leaf', '3DS', '2013-06-14');
GO