IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblGroupsCurators]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblGroupsCurators] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[CuratorId] INT NOT NULL FOREIGN KEY ([CuratorId]) REFERENCES [dbo].[tblCurators]([Id]),
	[GroupId] INT NOT NULL FOREIGN KEY ([GroupId]) REFERENCES [dbo].[tblGroups]([Id]),
	)'

