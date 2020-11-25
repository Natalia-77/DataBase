IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblStudents]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblStudents] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(100) NOT NULL CHECK(LEN(Name) > 0),
	[Rating] INT NOT NULL CHECK(Rating >= 0 AND Rating <= 5),
    [Surname] nvarchar(100) NOT NULL CHECK(LEN(Surname) > 0)
	)'

