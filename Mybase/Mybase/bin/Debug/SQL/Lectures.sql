IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblLectures]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblLectures] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Date] date NOT NULL CHECK(Date > GETDATE()),
	[SubjectId] INT NOT NULL FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[tblSubjects]([Id]),
    [TeacherId] INT NOT NULL FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[tblTeachers]([Id])	
	)'