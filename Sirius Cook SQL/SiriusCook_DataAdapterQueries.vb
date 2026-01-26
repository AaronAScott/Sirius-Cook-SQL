Imports System.Data.SqlClient
Module SiriusCook_DataAdapterQueries
	'*******************************************************************
	' SiriusCook SQL Data Adapter functions.
	' SIRIUSCOOK_DATAADAPTERQUERIES.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright 2017 Sirius Software All Rights Reserved

	'*******************************************************************

	' Declare the global data adapters

	Public ServerName As String
	Public CookbooksDA As New SqlDataAdapter
	Public RecipesDA As New SqlDataAdapter
	Public ControlDA As New SqlDataAdapter
	Public IngredientsDA As New SqlDataAdapter
	Public LinksDA As New SqlDataAdapter
	Public ImagesDA As New SqlDataAdapter


	'*******************************************************************

	' Function to return the connection string to the current database

	'*******************************************************************
	Public Function MyConnectionString() As String

		'Get the server name.  The default is the 2019 version of SQL Server Express.

		ServerName = "(LocalDB)\" & GetSetting("SiriusSoftwareGlobal", "SQLServer", "InstanceName", "MSSQLLocalDB")

		' For security purposes, and to ensure the connection string is
		' correct, use a connection string builder.

		Dim cs As New SqlConnectionStringBuilder

		' Build the connection string.

		cs.Add("Data Source", ServerName)
		cs.Add("AttachDbFilename", Databasename)
		cs.Add("Integrated Security", True)
		cs.Add("Connect Timeout", "15")

		Return cs.ConnectionString

	End Function
	'*******************************************************************

	' Function to return the insert SQL command to insert a record
	' into the cookbooks table.

	'*******************************************************************
	Public Function CookbooksInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[tblCookbooks] ([Title], [Author], [Category], [Password], [ImageStyle], [DisplayOrder], [Selected]) VALUES (@Title, @Author, @Category, @Password, @ImageStyle, @DisplayOrder, @Selected);" & vbCrLf & "SELECT Id, Title, Author, Category, Password, ImageStyle, DisplayOrder, Selected FROM tblCookbooks WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title")
		Command.Parameters.Add("@Author", SqlDbType.NVarChar, 50, "Author")
		Command.Parameters.Add("@Category", SqlDbType.NVarChar, 20, "Category")
		Command.Parameters.Add("@Password", SqlDbType.NVarChar, 20, "Password")
		Command.Parameters.Add("@ImageStyle", SqlDbType.Int, 4, "ImageStyle")
		Command.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4, "DisplayOrder")
		Command.Parameters.Add("@Selected", SqlDbType.Bit, 1, "Selected")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the update SQL command to update a record
	' in the cookbooks table.

	'*******************************************************************
	Public Function CookbooksUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[tblCookbooks] SET [Title]=@Title, [Author]=@Author, [Category]=@Category, [Password]=@Password, [ImageStyle]=@ImageStyle, [DisplayOrder]=@DisplayOrder, [Selected]=@Selected WHERE [Id]=@Id; SELECT Id, Title, Author, Category, Password, ImageStyle, DisplayOrder, Selected FROM tblCookbooks WHERE [Id]=@Original_Id", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Title", SqlDbType.NVarChar, 50, "Title")
		Command.Parameters.Add("@Author", SqlDbType.NVarChar, 50, "Author")
		Command.Parameters.Add("@Category", SqlDbType.NVarChar, 20, "Category")
		Command.Parameters.Add("@Password", SqlDbType.NVarChar, 20, "Password")
		Command.Parameters.Add("@ImageStyle", SqlDbType.Int, 4, "ImageStyle")
		Command.Parameters.Add("@DisplayOrder", SqlDbType.Int, 4, "DisplayOrder")
		Command.Parameters.Add("@Selected", SqlDbType.Bit, 1, "Selected")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the update SQL command to delete a record
	' from the cookbooks table.

	'*******************************************************************
	Public Function CookbooksDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[tblCookbooks] WHERE [Id] = @Original_Id", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the delete query.

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the select SQL command for the cookbooks table.

	'*******************************************************************
	Public Function CookbooksSelectCommand(Optional ID As Integer = 0) As SqlCommand

		' Declare variables

		Dim WhereClause As String = ""
		Dim Command As SqlCommand

		' If an ID is passed, get only that cookbook.

		If ID > 0 Then WhereClause = " WHERE ID=" & ID
		Command = New SqlCommand("SELECT * FROM tblCookbooks" & WhereClause & " ORDER BY DisplayOrder ASC", DB)

		Return Command

	End Function
	'*******************************************************************

	' Function to return the select SQL command for the recipes table.

	'*******************************************************************
	Public Function RecipesSelectCommand(Optional ParentID As Integer = 0) As SqlCommand

		' Declare variables

		Dim WhereClause As String = ""
		Dim Command As SqlCommand

		' If a parent ID was specified, get only the ingredients for that parent ID

		If ParentID > 0 Then WhereClause = " WHERE ParentID=" & ParentID

		Command = New SqlCommand("SELECT * FROM tblRecipes" & WhereClause & " ORDER BY Category ASC, RecipeName ASC", DB)
		Return Command
	End Function

	'*******************************************************************

	' Function to return the insert SQL command for the recipes table.

	'*******************************************************************
	Public Function RecipesInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[tblRecipes] ([ParentID], [RecipeName], [Blurb], [Author], [Category], [Servings], [CardStyle], [CardWidth], [CardHeight], [LeftMargin], [IngredientsMargin], [ProcedureMargin], [Heading Margin], [FontSize], [FontName], [Procedure], [Scale], [Favorite], [DateAdded], [Notes]) VALUES (@ParentID, @RecipeName, @Blurb, @Author, @Category, @Servings, @CardStyle, @CardWidth, @CardHeight, @LeftMargin, @IngredientsMargin, @ProcedureMargin, @HeadingMargin, @FontSize, @FontName, @Procedure, @Scale, @Favorite, @DateAdded, @Notes);" & vbCrLf & "SELECT Id, ParentID, RecipeName, Blurb, Author, Category, Servings, CardStyle, CardWidth, CardHeight, LeftMargin, IngredientsMargin, ProcedureMargin, [Heading Margin], FontSize, FontName, [Procedure], Scale, Favorite, DateAdded, [Notes] FROM tblRecipes WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@RecipeName", SqlDbType.NVarChar, 50, "RecipeName")
		Command.Parameters.Add("@Blurb", SqlDbType.NVarChar, 255, "Blurb")
		Command.Parameters.Add("@Author", SqlDbType.NVarChar, 50, "Author")
		Command.Parameters.Add("@Category", SqlDbType.NVarChar, 100, "Category")
		Command.Parameters.Add("@Servings", SqlDbType.NVarChar, 8, "Servings")
		Command.Parameters.Add("@CardStyle", SqlDbType.Int, 4, "CardStyle")
		Command.Parameters.Add("@CardWidth", SqlDbType.Real, 7, "CardWidth")
		Command.Parameters.Add("@CardHeight", SqlDbType.Real, 7, "CardHeight")
		Command.Parameters.Add("@LeftMargin", SqlDbType.Float, 8, "LeftMargin")
		Command.Parameters.Add("@IngredientsMargin", SqlDbType.Float, 8, "IngredientsMargin")
		Command.Parameters.Add("@ProcedureMargin", SqlDbType.Float, 8, "ProcedureMargin")
		Command.Parameters.Add("@HeadingMargin", SqlDbType.Float, 8, "Heading Margin")
		Command.Parameters.Add("@FontSize", SqlDbType.Int, 4, "FontSize")
		Command.Parameters.Add("@FontName", SqlDbType.NVarChar, 30, "FontName")
		Command.Parameters.Add("@Procedure", SqlDbType.Text, 4096, "Procedure")
		Command.Parameters.Add("@Scale", SqlDbType.NVarChar, 1, "Scale")
		Command.Parameters.Add("@Favorite", SqlDbType.Bit, 1, "Favorite")
		Command.Parameters.Add("@DateAdded", SqlDbType.Date, 4, "DateAdded")
		Command.Parameters.Add("@Notes", SqlDbType.NVarChar, 2048, "Notes")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the update SQL command for the recipes table.

	'*******************************************************************
	Public Function RecipesUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[tblRecipes] SET [ParentID] = @ParentID, [RecipeName] = @RecipeName, [Blurb] = @Blurb, [Author] = @Author, [Category] = @Category, [Servings] = @Servings, [CardStyle] = @CardStyle, [CardWidth] = @CardWidth, [CardHeight] = @CardHeight, [LeftMargin] = @LeftMargin, [IngredientsMargin] = @IngredientsMargin, [ProcedureMargin] = @ProcedureMargin, [Heading Margin] = @HeadingMargin, [FontSize] = @FontSize, [FontName] = @FontName, [Procedure] = @Procedure, [Scale] = @Scale, [Favorite] = @Favorite, [DateAdded]=@DateAdded, [Notes]=@Notes WHERE [Id] = @Original_Id;SELECT Id, ParentID, RecipeName, Blurb, Author, Category, Servings, CardStyle, CardWidth, CardHeight, LeftMargin, IngredientsMargin, ProcedureMargin, [Heading Margin], FontSize, FontName, [Procedure], Scale, Favorite, DateAdded, Notes FROM tblRecipes WHERE (Id = @Id)", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@RecipeName", SqlDbType.NVarChar, 50, "RecipeName")
		Command.Parameters.Add("@Blurb", SqlDbType.NVarChar, 255, "Blurb")
		Command.Parameters.Add("@Author", SqlDbType.NVarChar, 50, "Author")
		Command.Parameters.Add("@Category", SqlDbType.NVarChar, 100, "Category")
		Command.Parameters.Add("@Servings", SqlDbType.NVarChar, 8, "Servings")
		Command.Parameters.Add("@CardStyle", SqlDbType.Int, 4, "CardStyle")
		Command.Parameters.Add("@CardWidth", SqlDbType.Real, 7, "CardWidth")
		Command.Parameters.Add("@CardHeight", SqlDbType.Real, 7, "CardHeight")
		Command.Parameters.Add("@LeftMargin", SqlDbType.Float, 8, "LeftMargin")
		Command.Parameters.Add("@IngredientsMargin", SqlDbType.Float, 8, "IngredientsMargin")
		Command.Parameters.Add("@ProcedureMargin", SqlDbType.Float, 8, "ProcedureMargin")
		Command.Parameters.Add("@HeadingMargin", SqlDbType.Float, 8, "Heading Margin")
		Command.Parameters.Add("@FontSize", SqlDbType.Int, 4, "FontSize")
		Command.Parameters.Add("@FontName", SqlDbType.NVarChar, 30, "FontName")
		Command.Parameters.Add("@Procedure", SqlDbType.Text, 4096, "Procedure")
		Command.Parameters.Add("@Scale", SqlDbType.NVarChar, 1, "Scale")
		Command.Parameters.Add("@Favorite", SqlDbType.Bit, 1, "Favorite")
		Command.Parameters.Add("@DateAdded", SqlDbType.Date, 4, "DateAdded")
		Command.Parameters.Add("@Notes", SqlDbType.NVarChar, 2048, "Notes")

		Return Command

	End Function


	'*******************************************************************

	' Function to return the delete SQL command to delete a record
	' from the recipes table.

	'*******************************************************************
	Public Function RecipesDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[tblRecipes] WHERE [Id] = @Original_Id", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		Return Command

	End Function
	'*******************************************************************

	' Function to return the insert SQL command to insert a record
	' into the ingredients table.

	'*******************************************************************
	Public Function IngredientsInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[tblIngredients] ([ParentID], [Quantity], [UnitOfMeasure], [IngredientName]) VALUES (@ParentID, @Quantity, @UnitOfMeasure, @IngredientName);SELECT Id, ParentID, Quantity, UnitOfMeasure, IngredientName FROM tblIngredients WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@Quantity", SqlDbType.Float, 8, "Quantity")
		Command.Parameters.Add("@UnitOfMeasure", SqlDbType.NVarChar, 10, "UnitOfMeasure")
		Command.Parameters.Add("@IngredientName", SqlDbType.Text, 4096, "IngredientName")

		Return Command

	End Function
	'*******************************************************************

	' Function to return the insert SQL command to select records
	' from the ingredients table.

	'*******************************************************************
	Public Function IngredientsSelectCommand(Optional ParentID As Integer = 0) As SqlCommand

		' Declare variables

		Dim WhereClause As String = ""
		Dim Command As SqlCommand

		' If a parent ID was specified, get only the ingredients for that parent ID

		If ParentID > 0 Then WhereClause = " WHERE ParentID=" & ParentID
		Command = New SqlCommand("SELECT * FROM [dbo].tblIngredients " & WhereClause & " ORDER BY ParentID", DB)

		Return Command

	End Function

	'*******************************************************************

	' Function to return the insert SQL command to update a record
	' in the ingredients table.

	'*******************************************************************
	Public Function IngredientsUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[tblIngredients] SET [ParentID]=@ParentID, [Quantity]=@Quantity, [UnitOfMeasure]=@UnitOfMeasure, [IngredientName]=@IngredientName WHERE [Id]=@Original_ID;SELECT Id, ParentID, Quantity, UnitOfMeasure, IngredientName FROM tblIngredients WHERE [Id] = @Id", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@Quantity", SqlDbType.Float, 8, "Quantity")
		Command.Parameters.Add("@UnitOfMeasure", SqlDbType.NVarChar, 10, "UnitOfMeasure")
		Command.Parameters.Add("@IngredientName", SqlDbType.Text, 4096, "IngredientName")

		Return Command

	End Function
	'*******************************************************************

	' Function to return the insert SQL command to delete a record
	' from the ingredients table.

	'*******************************************************************
	Public Function IngredientsDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[tblIngredients] WHERE [Id] = @Original_Id", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		Return Command

	End Function
	'*******************************************************************

	' Function to return the select SQL command to select records
	' from the Control table.

	'*******************************************************************
	Public Function ControlSelectCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("Select * FROM [dbo].[Control] ORDER BY ItemName", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		Return Command

	End Function

	'*******************************************************************

	' Function to return the insert SQL command to insert a record
	' into the control table.

	'*******************************************************************
	Public Function ControlInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[Control] ([ItemName],[Value]) VALUES (@ItemName,@Value);SELECT Id, ItemName,Value FROM Control WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ItemName", SqlDbType.NVarChar, 20, "ItemName")
		Command.Parameters.Add("@Value", SqlDbType.NVarChar, 2048, "Value")
		Command.CommandType = CommandType.Text

		Return Command

	End Function

	'*******************************************************************

	' Function to return the update SQL command to update a record
	' in the Control table.

	'*******************************************************************
	Public Function ControlUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[Control] SET [ItemName]=@ItemName, [Value]=@Value WHERE [Id] = @Original_Id", DB)

		' Set the command type

		Command.CommandType = CommandType.Text

		' Set the parameters for the query

		Command.Parameters.Add("@ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@ItemName", SqlDbType.NVarChar, 20, "ItemName")
		Command.Parameters.Add("@Value", SqlDbType.NVarChar, 2048, "Value")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the delete SQL command to delete a record
	' from the Control table.

	'*******************************************************************
	Public Function ControlDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[Control] WHERE [Id] = @Original_Id", DB)

		' Set the parameters for the query

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		' Set the command type

		Command.CommandType = CommandType.Text

		Return Command

	End Function
	'*******************************************************************

	' Function to return the SELECT SQL command to select records
	' from the Links table.

	'*******************************************************************
	Public Function LinksSelectCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("SELECT * FROM [dbo].[tblLinks] ORDER BY LinkText", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		Return Command

	End Function

	'*******************************************************************

	' Function to return the INSERT SQL command to insert a record
	' into the Links table.

	'*******************************************************************
	Public Function LinksInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[tblLinks] ([LinkedID],[LinkText]) VALUES (@LinkedID,@LinkText);" & vbCrLf & " SELECT ID,ParentID,LinkedID,LinkText FROM tblLinks WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@LinkedID", SqlDbType.Int, 4, "LinkedID")
		Command.Parameters.Add("@LinkText", SqlDbType.NChar, 50, "LinkText")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the UPDATE SQL command to update a record
	' in the Links table.

	'*******************************************************************
	Public Function LinksUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[tblLinks] SET [LinkedID]=@LinkedID,[LinkText]=@LinkText WHERE [Id]=@Id;" & vbCrLf & " SELECT ID,LinkedID,LinkText FROM tblLinks WHERE [Id]=@Original_Id", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the update query.

		Command.Parameters.Add("@Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@LinkedID", SqlDbType.Int, 4, "LinkedID")
		Command.Parameters.Add("@LinkText", SqlDbType.NChar, 50, "LinkText")


		Return Command

	End Function

	'*******************************************************************

	' Function to return the DELETE SQL command to delete a record
	' from the Links table.

	'*******************************************************************
	Public Function LinksDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[tblLinks] WHERE [Id] = @Original_ID", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the delete query.

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		Return Command

	End Function
	'*******************************************************************

	' Function to return the SELECT SQL command to select records
	' from the tblImages table.

	'*******************************************************************
	Public Function ImagesSelectCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("SELECT * FROM [dbo].[tblImages] ORDER BY [ParentID]", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		Return Command

	End Function

	'*******************************************************************

	' Function to return the INSERT SQL command to insert a record
	' into the tblImages table.

	'*******************************************************************
	Public Function ImagesInsertCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("INSERT INTO [dbo].[tblImages] ([ParentID],[DocumentImage]) VALUES (@ParentID,@DocumentImage);" & vbCrLf & " SELECT ID,ParentID,DocumentImage FROM tblImages WHERE (Id = SCOPE_IDENTITY())", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the insert query.

		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@DocumentImage", SqlDbType.VarBinary, -1, "DocumentImage")

		Return Command

	End Function

	'*******************************************************************

	' Function to return the UPDATE SQL command to update a record
	' in the tblImages table.

	'*******************************************************************
	Public Function ImagesUpdateCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("UPDATE [dbo].[tblImages] SET [ParentID]=@ParentID,[DocumentImage]=@DocumentImage WHERE [Id]=@Id;" & vbCrLf & " SELECT ID,ParentID,DocumentImage FROM tblImages WHERE [Id]=@Original_Id", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the update query.

		Command.Parameters.Add("@Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@Original_Id", SqlDbType.Int, 4, "ID")
		Command.Parameters.Add("@ParentID", SqlDbType.Int, 4, "ParentID")
		Command.Parameters.Add("@DocumentImage", SqlDbType.VarBinary, -1, "DocumentImage")


		Return Command

	End Function

	'*******************************************************************

	' Function to return the DELETE SQL command to delete a record
	' from the tblImages table.

	'*******************************************************************
	Public Function ImagesDeleteCommand() As SqlCommand

		' Declare variables

		Dim Command = New SqlCommand("DELETE FROM [dbo].[tblImages] WHERE [Id] = @Original_ID", DB)

		' Set command type

		Command.CommandType = CommandType.Text

		' Add the parameters for the delete query.

		Command.Parameters.Add("@Original_ID", SqlDbType.Int, 4, "ID")

		Return Command

	End Function

	'*******************************************************************

	' Sub to initialize the global data adapters.

	'*******************************************************************
	Public Sub InitializeDataAdapters()

		CookbooksDA.SelectCommand = CookbooksSelectCommand()
		CookbooksDA.InsertCommand = CookbooksInsertCommand()
		CookbooksDA.UpdateCommand = CookbooksUpdateCommand()
		CookbooksDA.DeleteCommand = CookbooksDeleteCommand()

		RecipesDA.SelectCommand = RecipesSelectCommand()
		RecipesDA.InsertCommand = RecipesInsertCommand()
		RecipesDA.UpdateCommand = RecipesUpdateCommand()
		RecipesDA.DeleteCommand = RecipesDeleteCommand()

		IngredientsDA.SelectCommand = IngredientsSelectCommand()
		IngredientsDA.InsertCommand = IngredientsInsertCommand()
		IngredientsDA.UpdateCommand = IngredientsUpdateCommand()
		IngredientsDA.DeleteCommand = IngredientsDeleteCommand()

		LinksDA.SelectCommand = LinksSelectCommand()
		LinksDA.InsertCommand = LinksInsertCommand()
		LinksDA.UpdateCommand = LinksUpdateCommand()
		LinksDA.DeleteCommand = LinksDeleteCommand()

		ControlDA.SelectCommand = ControlSelectCommand()
		ControlDA.InsertCommand = ControlInsertCommand()
		ControlDA.UpdateCommand = ControlUpdateCommand()
		ControlDA.DeleteCommand = ControlDeleteCommand()

		ImagesDA.SelectCommand = ImagesSelectCommand()
		ImagesDA.InsertCommand = ImagesInsertCommand()
		ImagesDA.UpdateCommand = ImagesUpdateCommand()
		ImagesDA.DeleteCommand = ImagesDeleteCommand()

	End Sub

	'*******************************************************************

	' Sub to detach the global data adapters from the database.

	'*******************************************************************
	Public Sub DetachDataAdapters()

		CookbooksDA.SelectCommand.Connection = Nothing
		CookbooksDA.InsertCommand.Connection = Nothing
		CookbooksDA.UpdateCommand.Connection = Nothing
		CookbooksDA.DeleteCommand.Connection = Nothing
		CookbooksDA.TableMappings.Clear()

		RecipesDA.SelectCommand.Connection = Nothing
		RecipesDA.InsertCommand.Connection = Nothing
		RecipesDA.UpdateCommand.Connection = Nothing
		RecipesDA.DeleteCommand.Connection = Nothing
		RecipesDA.TableMappings.Clear()

		IngredientsDA.SelectCommand.Connection = Nothing
		IngredientsDA.InsertCommand.Connection = Nothing
		IngredientsDA.UpdateCommand.Connection = Nothing
		IngredientsDA.DeleteCommand.Connection = Nothing
		IngredientsDA.TableMappings.Clear()

		LinksDA.SelectCommand.Connection = Nothing
		LinksDA.InsertCommand.Connection = Nothing
		LinksDA.UpdateCommand.Connection = Nothing
		LinksDA.DeleteCommand.Connection = Nothing
		LinksDA.TableMappings.Clear()

		ControlDA.SelectCommand.Connection = Nothing
		ControlDA.InsertCommand.Connection = Nothing
		ControlDA.UpdateCommand.Connection = Nothing
		ControlDA.DeleteCommand.Connection = Nothing
		ControlDA.TableMappings.Clear()

		ImagesDA.SelectCommand.Connection = Nothing
		ImagesDA.InsertCommand.Connection = Nothing
		ImagesDA.UpdateCommand.Connection = Nothing
		ImagesDA.DeleteCommand.Connection = Nothing
		ImagesDA.TableMappings.Clear()
	End Sub

End Module
