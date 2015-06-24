CREATE TABLE [dbo].[Adresses]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [city] NVARCHAR(50) NOT NULL, 
    [zip] NVARCHAR(50) NOT NULL, 
    [customerID] INT NULL,
	CONSTRAINT [FK_CustomerID] FOREIGN KEY ([customerID]) REFERENCES [dbo].[Customers] ([id])
)
