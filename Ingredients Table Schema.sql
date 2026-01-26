CREATE TABLE [dbo].[tblIngredients]
(

     [ID]  INT NOT NULL PRIMARY KEY IDENTITY (1,1),
     [ParentID]  INT NOT NULL,
     [Quantity]  FLOAT NOT NULL DEFAULT ((0)),
     [UnitOfMeasure]  NVARCHAR(10) NOT NULL DEFAULT (('')),
     [IngredientName]  TEXT NOT NULL,
     CONSTRAINT [Relation2] FOREIGN KEY ([ParentID]) REFERENCES [tblRecipes]([ID]) ON UPDATE CASCADE ON DELETE CASCADE

)
     CREATE NONCLUSTERED INDEX ParentID ON [tblIngredients] (ParentID ASC);
