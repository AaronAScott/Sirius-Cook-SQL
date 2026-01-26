CREATE TABLE [dbo].[tblLinks]
(
     [ID]  INT  NOT NULL IDENTITY (1,1),
     [ParentID]  INT  NOT NULL,
     [LinkedID]  INT  NOT NULL,
     [LinkText]  NCHAR (50) NOT NULL,
     PRIMARY KEY CLUSTERED ([ID] ASC),
CONSTRAINT Relation3 FOREIGN KEY (ParentID) 
    REFERENCES tblRecipes (ID) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)

