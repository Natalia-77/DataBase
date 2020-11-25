IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblGroupsStudents]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblGroupsStudents] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[GroupId] INT NOT NULL FOREIGN KEY ([GroupId]) REFERENCES [dbo].[tblGroups]([Id]),
    [StudentId] INT NOT NULL FOREIGN KEY ([StudentId]) REFERENCES [dbo].[tblStudents]([Id])	
	)'


