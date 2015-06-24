CREATE TABLE [dbo].[Tasks]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [projectID] INT NOT NULL, 
    [name] NVARCHAR(50) NOT NULL,
	CONSTRAINT [FK_projectID] FOREIGN KEY (projectID) REFERENCES [dbo].[Projects] ([id])
)
