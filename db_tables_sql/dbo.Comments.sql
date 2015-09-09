CREATE TABLE [dbo].[Comments]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [taskID] INT NOT NULL, 
    [text] TEXT NOT NULL,
	CONSTRAINT [FK_taskID] FOREIGN KEY ([taskID]) REFERENCES [dbo].[Projects] ([id])
)
