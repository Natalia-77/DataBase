IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[Employeers]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[Employeers] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(100),CHECK (LEN(Name)>0),
    [City] nvarchar(100),CHECK (LEN(City)>0)	
	)'

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[Products]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[Products] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,	
	[ProductName] nvarchar(100),CHECK (LEN(ProductName)>0),
    [Price] money NOT NULL	
	)'

	IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[Orders]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TABLE [dbo].[Orders] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY,	
	[Number] INT NOT NULL,
	[EmployeersId] INT NOT NULL FOREIGN KEY ([EmployeersId]) REFERENCES [dbo].[Employeers]([Id]),
	[ProductsId] INT NOT NULL FOREIGN KEY ([ProductsId]) REFERENCES [dbo].[Products]([Id])
	)'


