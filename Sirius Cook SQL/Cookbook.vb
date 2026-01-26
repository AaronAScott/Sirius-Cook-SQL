Option Strict Off
Option Explicit On
Imports System.Runtime.InteropServices
Imports System.Data.SqlClient

Friend Class Cookbook
	'**************************************************
	' SiriusCook SQL Cookbook class (Cookbook object)
	' COOKBOOK.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2022 Sirius Software All Rights Reserved
	'**************************************************

	' Define variables which are properties of this class

	Public Selected As Boolean
	Public PropertiesChanged As Boolean
	Public Recipes As Collection

	' Define variables local to this module

	Private CookbooksDS As New DataSet
	Private RecipesDS As New DataSet
	Private CategoriesDS As New DataSet
	Private mBook As DataRow
	Private mRec As DataTable
	Private mIng As DataTable
	Private mCategories As DataTable
	Private mPict As PictureBox
	Private mBookID As Integer
	Private mImageStyle As Integer
	Private mDisplayOrder As Integer
	Private mTitle As String
	Private mAuthor As String
	Private mCategory As String
	Private mPassword As String


	'**************************************************
	'
	' The cookbook Author is set
	'
	'**************************************************
	'**************************************************
	'
	' The cookbook Author is queried
	'
	'**************************************************
	Public Property Author() As String
		Get
			Author = mAuthor
		End Get
		Set(ByVal Value As String)
			mAuthor = Value
		End Set
	End Property
	'**************************************************
	'
	' The book ID (which is the Primary Key of the cookbook
	' object's record in tblCookBooks in the database)
	' is set. 
	'
	'**************************************************
	Public Property BookID() As Integer
		Get
			BookID = mBookID
		End Get
		Set(ByVal Value As Integer)

			' Declare variables

			Dim ii As Integer = 0

			' Remember the ID of this book

			mBookID = Value

			' Get the specified cookbook.

			If Not mBook Is Nothing Then CookbooksDS.Clear()
			CookbooksDA.SelectCommand = CookbooksSelectCommand(Value)
			CookbooksDA.Fill(CookbooksDS, "Table")
			mBook = CookbooksDS.Tables("Table").Rows(0) ' Only one book will be returned

			' Build a dataset of recipes belonging to this
			' cookbook.

			RecipesDA.SelectCommand = RecipesSelectCommand(Value)

			On Error GoTo TryAgain
			Do
				RecipesDA.Fill(RecipesDS, "Table")
			Loop While ii > 0 And ii < 3

			' If we failed to open the recipe table, raise an error.

			If ii = 3 Then
				mBookID = -1
				Err.Raise(vbObjectError + 513, "Could not open recipes table")
			Else
				mRec = RecipesDS.Tables("Table")
				RecipesDA.SelectCommand.CommandText = "SELECT DISTINCT Category FROM tblRecipes WHERE ParentID=" & mBook("ID") & " ORDER BY Category"
				RecipesDA.Fill(CategoriesDS, "Table")
				mCategories = CategoriesDS.Tables("Table")
			End If

			Exit Property
TryAgain:
			ii += 1
			Resume Next


		End Set
	End Property

	'**************************************************
	'
	' The cookbook category is set.
	'
	'**************************************************
	'**************************************************
	'
	' The cookbook Category is queried.
	'
	'**************************************************
	Public Property Category() As String
		Get
			Category = mCategory
		End Get
		Set(ByVal Value As String)
			mCategory = Value
		End Set
	End Property
	'**************************************************
	'
	' The display property is queried.
	'
	'**************************************************

	'**************************************************
	'
	' The Display picture box object is set
	'
	'**************************************************
	Public Property Display() As PictureBox
		Get
			Display = mPict
		End Get
		Set(ByVal Value As PictureBox)

			' Set the local Picture box variable to the
			' picture box this object will output to, if any.

			mPict = Value

		End Set
	End Property

	'**************************************************
	'
	' The cookbook Password is set
	'
	'**************************************************
	Public WriteOnly Property Password() As String
		Set(ByVal Value As String)
			mPassword = Value
		End Set
	End Property

	'**************************************************
	'
	' The cookbook title is set
	'
	'**************************************************
	'**************************************************
	'
	' The cookbook Title is queried.
	'
	'**************************************************
	Public Property Title() As String
		Get
			Title = mTitle
		End Get
		Set(ByVal Value As String)
			mTitle = Value
		End Set
	End Property

	'**************************************************
	'
	' The ImageStyle property is queried
	'
	'**************************************************

	'**************************************************
	'
	' The ImageStyle property is set.
	'
	'**************************************************
	Public Property ImageStyle() As Integer
		Get
			ImageStyle = mImageStyle
		End Get
		Set(ByVal Value As Integer)
			mImageStyle = Value
		End Set
	End Property
	'**************************************************
	'
	' The DisplayOrder property is queried
	'
	'**************************************************

	'**************************************************
	'
	' The DisplayOrder property is set.
	'
	'**************************************************
	Public Property DisplayOrder() As Integer
		Get
			DisplayOrder = mDisplayOrder
		End Get
		Set(ByVal Value As Integer)
			mDisplayOrder = Value
		End Set
	End Property
	'**************************************************
	'
	' Function to return a flag as to whether a
	' given password is valid for this book.
	'
	'***************************************************
	Public Function ValidatePassword(ByRef PWD As String) As Boolean

		If PWD = mPassword Then
			ValidatePassword = True
		Else
			ValidatePassword = False
		End If

	End Function

	'**************************************************
	'
	' Method to open the cookbook.
	'
	'**************************************************
	Public Sub OpenBook(Optional ByRef RecipeID As Integer = 0)

		' Declare variables.

		Dim Cancel As Boolean
		Dim xx As Integer
		Dim wx As String
		Dim zx As String
		Dim CategoryList As New SortedList

		' If this book is password protected, request
		' the password.

		If mPassword <> "" Then
			Do
				frmPassword.ShowDialog()
				Cancel = frmPassword.Cancel
				If Not Cancel And Not ValidatePassword(frmPassword.Password) Then
					MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "Open Cookbook")
				End If
			Loop While Cancel = False And Not ValidatePassword(frmPassword.Password)
			frmPassword.Close()
			If Cancel Then Exit Sub
		End If

		' Create a list of all the categories declared by the recipes.

		For xx = 0 To mCategories.Rows.Count - 1
			zx = mCategories.Rows(xx)("Category")
			Do While zx <> ""
				wx = ParseString(zx)
				If Not CategoryList.Contains(wx) Then CategoryList.Add(wx, "")
			Loop
		Next xx

		' If the cookbook is empty, call the routine to add
		' a new recipe.  Otherwise display the table of
		' contents.

		Dim b As New frmOpenBook(mBookID)
		b.Text = Title
		b.mBook = mBook
		b.mIng = mIng
		b.mCategory = CategoryList
		b.MyCookbook = Me
		If mRec.Rows.Count > 0 Then
			If RecipeID = 0 Then
				b.ShowTOC()
			Else
				b.ShowRecipes(ID:=RecipeID)
			End If
		Else
			b.NewRecipe()
		End If
		b.Show()

	End Sub

	'**************************************************
	'
	' Method to display the book's title on its "spine".
	'
	'**************************************************
	Public Sub PrintTitle(g As Graphics)

		' Declare variables.

		Dim FontBold As Boolean
		Dim FontItalic As Boolean
		Dim FontRotated As Boolean
		Dim FontSize As Integer
		Dim FontColor As Integer
		Dim x As Integer
		Dim y As Integer
		Dim FontName As String = ""
		Dim zx0 As String
		Dim zx1 As String
		Dim f As Font = Nothing
		Dim xx As FontStyle
		Dim b As SolidBrush
		Dim LineHeight As Single
		Dim fs As FontStyle
		Dim rt As RotatedText

		' Display the tile except for imagestyle "0"--the default book.
		' Other properties are based upon the book style.

		If ImageStyle > 0 Then
			FontRotated = Choose(ImageStyle, True, False, False, True, False, False, True, False)
			FontSize = Choose(ImageStyle, 14, 12, 14, 14, 14, 14, 14, 12)
			FontName = Choose(ImageStyle, "Times New Roman", "Arial", "Times New Roman", "CAC Moose", "Arial", "Barbedor T", "Arial", "Monotype Corsiva")
			FontItalic = Choose(ImageStyle, True, True, False, True, True, False, False, True)
			FontBold = Choose(ImageStyle, True, True, True, True, True, False, True, False)
			FontColor = Choose(ImageStyle, RGB(255, 255, 255), RGB(0, 0, 0), RGB(0, 0, 0), RGB(0, 0, 128), RGB(255, 255, 255), RGB(255, 255, 255), RGB(128, 0, 0), RGB(64, 255, 255))
			' Decide if we need to print the title horizontally or
			' vertically. If we can print at least 10 characters
			' across, then print horizontally.

			zx0 = Title
			If Not FontRotated Then

				' Create the font with which to print the title

				If FontItalic Then xx = FontStyle.Italic
				If FontBold Then xx = xx + FontStyle.Bold
				f = New Font(FontName, FontSize, xx)
				b = New SolidBrush(System.Drawing.ColorTranslator.FromWin32(FontColor))
				LineHeight = g.MeasureString("X", f).Height
				y = mPict.ClientRectangle.Height / 6
				While zx0 <> ""
					zx1 = WordWrap(g, f, zx0, mPict.ClientRectangle.Width * 0.8)
					x = (mPict.ClientRectangle.Width - g.MeasureString(zx1, f).Width) / 2
					g.DrawString(zx1, f, b, x, y)
					y = y + LineHeight
				End While
				y = mPict.ClientRectangle.Height / 2
				zx0 = Author
				While zx0 <> ""
					zx1 = WordWrap(g, f, zx0, mPict.ClientRectangle.Width * 0.8)
					x = (mPict.ClientRectangle.Width - g.MeasureString(zx1, f).Width) / 2
					g.DrawString(zx1, f, b, x, y)
					y = y + LineHeight
				End While

				' Dispose of objects we've created

				f.Dispose()
				b.Dispose()


				'For narrow "books", print along the spine.

			Else

				' Assemble the text for the spine and call the rotated print routine.

				f = New Font(FontName, FontSize, xx)
				zx0 = zx0 & "      " & Author
				zx1 = WordWrap(g, f, zx0, CDbl(mPict.ClientRectangle.Height))
				x = Choose(ImageStyle, 45, 30, 30, 70, 45, 40, 35, 30) + mPict.ClientRectangle.X
				y = Choose(ImageStyle, 40, 40, 40, 40, 40, 40, 50, 40) + mPict.ClientRectangle.Y
				fs = FontStyle.Regular
				If FontBold Then fs = fs And FontStyle.Bold
				If FontItalic Then fs = fs And FontStyle.Italic
				rt = New RotatedText(zx1, f, 90, New Point(x, y))
				rt.Print(g)
			End If

		End If


	End Sub
	'**************************************************
	'
	' Method to change the properties of the cookbook.
	'
	'**************************************************
	Public Sub ChangeProperties()

		' Declare variables

		Dim Cancel As Boolean
		Dim ii As Integer
		Dim jj As Integer
		Dim BookID As Integer
		Dim OldDisplayOrder As Integer
		Dim lBook As DataTable

		' If this book is password protected, request
		' the password.

		If mPassword <> "" Then
			Do
				frmPassword.ShowDialog()
				Cancel = frmPassword.Cancel
				If Not Cancel And Not ValidatePassword((frmPassword.Password)) Then
					MsgBox("Invalid Password", MsgBoxStyle.Exclamation, "Change Cookbook Properties")
				End If
			Loop While Cancel = False And Not ValidatePassword((frmPassword.Password))
			frmPassword.Close()
			If Cancel Then Exit Sub
		End If

		' Load the cookbook properties form.
		' Set the current properties into the entry fields.

		CookbookProperties.Text1.Text = mTitle
		CookbookProperties.Text2.Text = mAuthor
		CookbookProperties.Text3.Text = mCategory
		CookbookProperties.Text4.Text = Encrypt(mPassword)
		CookbookProperties.Text5.Text = Encrypt(mPassword)
		CookbookProperties.Text6.Text = mDisplayOrder
		OldDisplayOrder = mDisplayOrder ' Need to watch in case this changes
		CookbookProperties.ImageStyle = mImageStyle

		' If the cookbook is the default cookbook, disable
		' all the entry fields, except the cover.

		If mCategory = "_Default" Then
			CookbookProperties.Text1.Enabled = False
			CookbookProperties.Text2.Enabled = False
			CookbookProperties.Text3.Enabled = False
			CookbookProperties.Text4.Enabled = False
			CookbookProperties.Text5.Enabled = False
			CookbookProperties.Text6.Enabled = False
			CookbookProperties.Label1.Enabled = False
			CookbookProperties.Label2.Enabled = False
			CookbookProperties.Label3.Enabled = False
			CookbookProperties.Label4.Enabled = False
			CookbookProperties.Label5.Enabled = False
			CookbookProperties.Label6.Enabled = False
		End If

		' Show the form

		CookbookProperties.ShowDialog()

		' Get the new values for the properties, unless
		' it is the default cookbook.  Do not allow an
		' underscore in the category--only the default
		' category may use that.

		If Not CookbookProperties.Cancel Then
			PropertiesChanged = True
			If mCategory <> "_Default" Then
				mTitle = CookbookProperties.Text1.Text
				mAuthor = CookbookProperties.Text2.Text
				mCategory = SRep(CookbookProperties.Text3.Text, 1, "_", "")
				mPassword = Encrypt(CookbookProperties.Text4.Text)
				mDisplayOrder = CookbookProperties.Text6.Text
			End If
			mImageStyle = CookbookProperties.ImageStyle

			' Update the database

			Try
				mBook("Title") = mTitle
				mBook("Author") = mAuthor
				mBook("Category") = mCategory
				mBook("Password") = mPassword
				mBook("ImageStyle") = mImageStyle
				mBook("DisplayOrder") = mDisplayOrder
				CookbooksDA.Update(CookbooksDS)
				BookID = mBook("ID")
				DatabaseChanged = True
			Catch ex As Exception
				MsgBox("Update failed." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Update Cookbook Properties")
			End Try
		End If

		' If the display order changed, reorder all the cookbooks to reflect the
		' edited book's new display position.

		If mDisplayOrder <> OldDisplayOrder Then
			CookbooksDS.Clear()
			CookbooksDA.SelectCommand = CookbooksSelectCommand()
			CookbooksDA.Fill(CookbooksDS, "Table")
			lBook = CookbooksDS.Tables("Table")
			If lBook.Rows.Count > 0 Then
				ii = 1 ' Skip past the default book (row 0), always display position 1
				jj = 2 ' Renumber counter, beginning after default book

				' Begin renumbering the cookbooks until we come to the newly-changed position.  We'll have a duplicate,
				' so do nothing if we have the book just repositioned.  If it's the book formerly at that position,'
				' then, unless it is the last book in the bookshelf, number it after the book with the new position.
				' If its former position was at the end of the bookshelf, renumber it according to the books
				' "behind" the new position.

				Do While ii < lBook.Rows.Count
					If lBook(ii)("DisplayOrder") = mDisplayOrder Then
						If lBook(ii)("ID") <> mBookID Then
							If mDisplayOrder < lBook.Rows.Count Then jj = mDisplayOrder + 1
							lBook(ii)("DisplayOrder") = jj
							jj += 1
						End If
					Else
						lBook(ii)("DisplayOrder") = jj
						jj += 1
					End If
					ii += 1
				Loop
			End If
			CookbooksDA.Update(lBook)
		End If

		' Unload the properties form

		CookbookProperties.Close()

	End Sub


End Class