IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblGroupsLectures]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblGroupsLectures] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[GroupId] INT NOT NULL FOREIGN KEY ([GroupId]) REFERENCES [dbo].[tblGroups]([Id]),
    [LectureId] INT NOT NULL FOREIGN KEY ([LectureId]) REFERENCES [dbo].[tblLectures]([Id])	
	)'

