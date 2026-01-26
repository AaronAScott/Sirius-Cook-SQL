Imports System.Net
Imports vb = Microsoft.VisualBasic
Public Class TableOfContents
	'**************************************************
	' SiriusCook SQL Table of Contents class 
	' TABLEOFCONTENTS.VB
	' Written: October 2022
	' Updated: July 2025 for Version 4.0
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2025 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables local to this module.

	Private mBookID As Integer
	Private CatList() As String
	Private RecipesDS As New DataSet
	Private LastRecordAdded As DataRow

	Private Structure RecipeEntry
		Dim Category As String
		Dim RecipeName As String
		Dim ID As Integer
	End Structure
	Private RecipeList As New SortedList(Of String, RecipeEntry)

	Public RecipesTable As DataTable
	'**************************************************

	' The New call: build the table of contents of recipes.

	'**************************************************
	Public Sub New(BookID As Integer)

		' Declare variables.

		Dim ii As Integer

		' Open the recipe table for the book.

		mBookID = BookID
		RecipesDA.SelectCommand = RecipesSelectCommand(BookID)
		RecipesDS.Clear()
		RecipesDA.Fill(RecipesDS, "Table")
		RecipesTable = RecipesDS.Tables("Table")

		' Add each recipe to our category/recipe list

		If RecipesTable.Rows.Count > 0 Then
			For ii = 0 To RecipesTable.Rows.Count - 1
				AddToTOC(RecipesTable.Rows(ii))
			Next ii
		End If

	End Sub

	'**************************************************

	' Method to add a record to the recipe table.

	'**************************************************
	Public Sub AddRecipe(lRec As DataRow)

		' Add the recipe to the recipes table.

		RecipesTable.Rows.Add(lRec)
		RecipesDA.Update(RecipesTable)
		LastRecordAdded = lRec

		' Add the recipe to the Table of Contents

		AddToTOC(lRec)

	End Sub
	'**************************************************

	' Sub to add a record to the Table Of Contents

	'**************************************************
	Private Sub AddToTOC(lrec As DataRow)

		Dim jj As Integer = 1
		Dim wx As String
		Dim xx As String = ""
		Dim zx As String
		Dim nr As DataRow
		Dim RecEntry As RecipeEntry

		' Get the recipe category from the record.  Add an entry to the table
		' of contents under each category included.

		On Error GoTo DuplicateName
		zx = lrec("Category")
		Do While zx <> ""
			wx = ParseString(zx)
			RecEntry = New RecipeEntry
			xx = ""
			With RecEntry
				.Category = wx
				.RecipeName = lrec("RecipeName")
				.ID = lrec("ID")
			End With

			' Add the category/recipe combination.

			jj = 0
			RecipeList.Add(wx & "." & RecEntry.RecipeName & xx, RecEntry)
		Loop

		Exit Sub

		' If we get a duplicate name AND category, we'll tack on a number to the name
		' to make a unique entry.

DuplicateName:
		jj += 1
		xx = " (" & jj & ")"
		Resume

	End Sub
	'**************************************************

	' The NewRow property.

	'**************************************************
	Public ReadOnly Property NewRow As DataRow
		Get
			Return RecipesTable.NewRow()
		End Get
	End Property
	'**************************************************

	' The LastAdded property

	'**************************************************
	Public ReadOnly Property LastAdded As DataRow
		Get
			Return LastRecordAdded
		End Get
	End Property

	'**************************************************

	' Read-only property to return a list of categories
	' found in the recipes.

	'**************************************************
	Public Function Categories() As String()

		' Declare variables.

		Dim ii As Integer
		Dim jj As Integer
		Dim zx As String
		Dim LastCategory As String = ""
		ReDim CatList(100)

		' For each entry in the table of contents, look at its category, and, if
		' we find a new one, add it to the list of categories.

		For ii = 0 To RecipeList.Count - 1
			zx = RecipeList.ElementAt(ii).Key
			If zx <> LastCategory Then
				CatList(jj) = zx
				jj += 1
				If jj >= CatList.Count Then ReDim Preserve CatList(jj + 9)
			End If
			LastCategory = zx
		Next ii

		' Resize the array down to leave no empty slots.

		ReDim Preserve CatList(jj - 1)
		Return CatList

	End Function
	'**************************************************

	' Function to return the list of categories as an autocomplete collection.

	'**************************************************
	Public Function CategoryList() As AutoCompleteStringCollection

		' Declare variables.

		Dim ii As Integer
		Dim zx As String
		Dim ac As New AutoCompleteStringCollection

		' For each entry in the table of contents, look at its category, and, if
		' we find a new one, add it to the list of categories.

		For ii = 0 To RecipeList.Count - 1
			zx = ParseString(RecipeList.ElementAt(ii).Key, ".")
			If Not ac.Contains(zx) Then ac.Add(zx)
		Next ii

		Return ac

	End Function
	'**************************************************

	' Property to return the nearest category name match
	' to a specified partial name.

	'**************************************************
	Public Function FindCategory(key As String) As Integer

		' Declare variables

		Dim ii As Integer
		Dim c() As String = Me.Categories

		' Loop through the categories looking for ones that match as
		' far as the length of the specified partial key.

		For ii = 0 To c.Count - 1
			If c(ii).Length >= key.Length AndAlso c(ii).Substring(0, key.Length).ToLower = key.ToLower Then
				Return ii
			End If
		Next ii
		Return NOMATCH

	End Function
	'**************************************************

	' The Item property.  This is the default property.
	' It returns a recipe record exactly as if one were
	' refrencing the datatable rows.

	'**************************************************
	Default Public ReadOnly Property Item(ii As Integer) As DataRow
		Get
			' Get the actual data row referred to by the index.

			Item = RecipesTable.Select("ID=" & RecipeList.ElementAt(ii).Value.ID)(0)
		End Get
	End Property
	'**************************************************

	' Method to rebuild the Table of Contents.

	'**************************************************
	Public Sub Refresh()

		' Declare variables

		Dim ii As Integer
		Dim jj As Integer
		Dim xx As String
		Dim RecEntry As RecipeEntry

		RecipeList = New SortedList(Of String, RecipeEntry)

		' Rebuild the recipes table to reflect changes.

		RecipesDS.Clear()
		RecipesDA.SelectCommand = RecipesSelectCommand(mBookID)
		RecipesDA.Fill(RecipesDS, "Table")
		RecipesTable = RecipesDS.Tables("Table")

		' Rebuild the table of contents

		On Error GoTo DuplicateName
		For ii = 0 To RecipesTable.Rows.Count - 1
			xx = ""
			RecEntry = New RecipeEntry
			With RecEntry
				.Category = RecipesTable.Rows(jj)("Category")
				.RecipeName = RecipesTable.Rows(ii)("RecipeName") & xx
				.ID = RecipesTable.Rows(ii)("ID")
			End With

			' Add the category/recipe combination.

			jj = 0
			RecipeList.Add(RecEntry.RecipeName & "." & RecEntry.RecipeName & xx, RecEntry)
		Next ii


		Exit Sub

		' If we get a duplicate name AND category, we'll tack on a number to the name
		' to make a unique entry.

DuplicateName:
		jj += 1
		xx = " (" & jj & ")"
		RecEntry.RecipeName = RecipesTable.Rows(ii)("RecipeName") & xx
		Resume


	End Sub
	'**************************************************

	' Function to find a row in a datatable.
	' Only one criteria may be specified.
	' Input :  Criteria = The criteria to be met.
	' Output:  The index of the first record to meet
	'          the criteria.

	'**************************************************
	Public Function FindRecipe(Criteria As String, Optional IgnoreBlanks As Boolean = False) As DataRow

		' Declare variables

		Dim jj As Integer
		Dim FieldToSearch As String = ""
		Dim xx As String = ""
		Dim zx As Object = Nothing
		Dim Compare As String = ""
		Dim CompareValue As Object = Nothing

		' Begin parsing the string

		For jj = 1 To Len(Criteria)

			' Once we encounter a comparison string, the field to search is the value before that position.

			zx = Mid(Criteria, jj, 1)
			If zx = "=" Or zx = "<" Or zx = ">" And FieldToSearch = "" Then
				FieldToSearch = Trim(vb.Left(Criteria, jj - 1))

				' Now look for the comparison operator

				xx = Mid(Criteria, jj, 2)
				If xx <> "<>" And xx <> "<=" And xx <> ">=" Then
					xx = Mid(Criteria, jj, 1)
					Compare = Mid(Criteria, jj + 1)
				Else
					Compare = Mid(Criteria, jj + 2)
				End If

				Exit For
			End If
		Next jj

		' Now convert the comparison value to a string or a value.

		If Compare.Chars(0) = "'" Then
			CompareValue = Compare.Replace("'", "").ToLower
		Else
			CompareValue = Compare
		End If

		' Begin searching the data table. If any errors occur, return a NOMATCH.

		Try
			For jj = 0 To RecipesTable.Rows.Count - 1
				zx = GetR(RecipesTable.Rows(jj), FieldToSearch) ' Lower case everything for a case-insensitive search
				If IgnoreBlanks Then zx = Trim(zx)
				Select Case xx
					Case "="
						If zx = CompareValue Then Return RecipesTable.Rows(jj)
					Case "<>"
						If zx <> CompareValue Then Return RecipesTable.Rows(jj)
					Case "<"
						If zx < CompareValue Then Return RecipesTable.Rows(jj)
					Case ">"
						If zx > CompareValue Then Return RecipesTable.Rows(jj)
					Case ">="
						If zx >= CompareValue Then Return RecipesTable.Rows(jj)
					Case "<="
						If zx <= CompareValue Then Return RecipesTable.Rows(jj)
				End Select
			Next jj
		Catch
			Return Nothing
		End Try

		' If we didn't find anything, return nothing

		Return Nothing

	End Function

	'**************************************************

	' The Count property returns the number of recipes, not entries.

	'**************************************************
	Public ReadOnly Property Count() As Integer
		Get
			Count = RecipesTable.Rows.Count
		End Get
	End Property


End Class
