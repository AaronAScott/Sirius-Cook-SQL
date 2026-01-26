CREATE TABLE [dbo].[tblCookbooks]
(
     [ID]  INT NOT NULL PRIMARY KEY IDENTITY (1,1),
     [Title]  NVARCHAR(50) NULL DEFAULT (('')),
     [Author]  NVARCHAR(50) NULL DEFAULT (('')),
     [Category]  NVARCHAR(20) NULL DEFAULT (('')),
     [Password]  NVARCHAR(20) NULL DEFAULT (('')),
     [ImageStyle]  INT NOT NULL,
     [DisplayOrder]  INT NOT NULL,
     [Selected]  BIT NOT NULL DEFAULT ((0))
)

CREATE NONCLUSTERED INDEX Author ON [tblCookbooks] (Author ASC);
CREATE NONCLUSTERED INDEX Title ON [tblCookbooks] (Title ASC);
CREATE NONCLUSTERED INDEX Index1 ON [tblCookbooks] (Category ASC,Title ASC);
