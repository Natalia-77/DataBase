
IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[tblFaculties]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[tblFaculties] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](100) NOT NULL,	
	)'