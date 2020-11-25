IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblCurators]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblCurators] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar (100) NOT NULL CHECK (LEN(Name) > 0) ,
	[Surname] nvarchar (100) NOT NULL CHECK (LEN(Surname) > 0),		
	)'
