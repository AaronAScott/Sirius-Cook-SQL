CREATE TABLE [dbo].[Control]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [ItemName] NCHAR(20) UNIQUE NOT NULL, 
    [Value] NVARCHAR(2048) NULL
)

CREATE INDEX [ItemName] ON [dbo].[Control] ([ItemName])
