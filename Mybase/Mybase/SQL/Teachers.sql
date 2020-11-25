IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblTeachers]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblTeachers] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[IsProfessor] bit NOT NULL DEFAULT 0,
	[Name] nvarchar(100) NOT NULL CHECK(LEN(Name) > 0),
	[Salary] money NOT NULL CHECK(Salary>0),
	[Surname] nvarchar (100) NOT NULL CHECK (LEN(Surname) > 0)	
	)'

