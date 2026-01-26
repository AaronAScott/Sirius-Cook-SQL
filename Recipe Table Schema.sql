CREATE TABLE [dbo].[tblRecipes]
(
     [ID]  INT NOT NULL PRIMARY KEY IDENTITY (1,1),
     [ParentID]  INT NOT NULL,
     [Title]  NVARCHAR(50) NOT NULL,
     [Blurb]  NVARCHAR(255) NOT NULL,
     [Author]  NVARCHAR(20) NOT NULL,
     [Category]  NVARCHAR(20) NOT NULL,
     [Servings]  NVARCHAR(8) NOT NULL,
     [CardStyle]  NVARCHAR(50) NOT NULL,
     [CardWidth]  INT NOT NULL DEFAULT ((0)),
     [CardHeight]  INT NOT NULL DEFAULT ((0)),
     [LeftMargin]  FLOAT NOT NULL DEFAULT ((0)),
     [IngredientsMargin]  FLOAT NOT NULL DEFAULT ((0)),
     [ProcedureMargin]  FLOAT NOT NULL DEFAULT ((0)),
     [Heading Margin]  FLOAT NOT NULL DEFAULT ((0)),
     [FontSize]  INT NOT NULL DEFAULT ((0)),
     [FontName]  NVARCHAR(30) NOT NULL,
     [Procedure]  TEXT NOT NULL,
     [Scale]  NVARCHAR(1) NOT NULL,
     [Favorite]  BIT NOT NULL DEFAULT ((0)),
     CONSTRAINT [Relation1] FOREIGN KEY ([ParentID]) REFERENCES [tblCookbooks]([ID]) ON UPDATE CASCADE ON DELETE CASCADE
)
CREATE NONCLUSTERED INDEX Author ON [tblRecipes] (Author ASC);
CREATE NONCLUSTERED INDEX Category ON [tblRecipes] (Category ASC);
CREATE NONCLUSTERED INDEX Name ON [tblRecipes] (Title ASC);
CREATE NONCLUSTERED INDEX ParentID ON [tblRecipes] (ParentID ASC);
