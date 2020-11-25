IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblDepartments]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblDepartments] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](250) NOT NULL,
	[Building] [int] NOT NULL,
	[FacultyId] INT NOT NULL FOREIGN KEY ([FacultyId]) REFERENCES [dbo].[tblFaculties]([Id])
	)'