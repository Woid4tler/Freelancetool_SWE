CREATE TABLE [dbo].[Projects] (
    [id]         INT           NOT NULL,
    [name]       NVARCHAR (50) NOT NULL,
    [customerID] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [FK_pCustomerID] FOREIGN KEY ([customerID]) REFERENCES [dbo].[Customers] ([id])
);

