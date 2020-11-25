
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblGroups]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblGroups] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](100) NOT NULL,
	[Year] [int] NOT NULL CHECK (Year >= 1 AND Year <= 5),
	[DepartmentId] INT NOT NULL FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[tblDepartments]([Id])	
	)'