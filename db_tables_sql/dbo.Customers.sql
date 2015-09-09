CREATE TABLE [dbo].[Customers]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL, 
    [mail] NVARCHAR(50) NULL, 
    [phone] NVARCHAR(50) NULL
)
