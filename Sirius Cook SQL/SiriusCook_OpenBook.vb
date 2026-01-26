Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml.Linq
Imports PromptedTextBox
Friend Class frmOpenBook
	Inherits System.Windows.Forms.Form
	'**************************************************
	' SiriusCook SQL SQL Open Cookbook form
	' SIRIUSCOOK_OPENBOOK.VB
	' Written: November 2017
	' Updated: November 2023
	' Updated: July 2025
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2025 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables which are properties of this
	' form

	Public BookID As Integer
	Public MyCookbook As Cookbook
	Public RecipesDS As New DataSet
	Public IngredientsDS As New DataSet
	Public mIng As DataTable
	Public mImg As DataTable
	Public mBook As DataRow
	Public mCategory As SortedList

	' Declare variables local to this module

	Private DontProcessEvent As Boolean
	Private PageOverflow As Boolean
	Private IngredientsChanged As Boolean
	Private BeginLink As Boolean
	Private CurrentRecipeRow As Integer
	Private mDisplayMode As Integer
	Private mPaneNo As Integer
	Private mPage1Y As Integer
	Private mPage2Y As Integer
	Private mLineHeight As Integer
	Private mPageNo As Integer
	Private mPage1Left As Integer
	Private mPage1Right As Integer
	Private mPage2Left As Integer
	Private mPage2Right As Integer
	Private mBottomMargin As Integer
	Private mTabColumn As Integer
	Private rMode As Integer
	Private IngredientsText As String
	Private ProcedureText As String
	Private mZones As Collection
	Private mBookmarks As Collection
	Private mIngredientLinks As Collection
	Private mProcedureLinks As Collection
	Private LinksDS As New DataSet
	Private LinksTable As DataTable
	Private ImagesDS As New DataSet
	Private ImagesTable As DataTable
	Private LeftTabImage As Image
	Private RightTabImage As Image
	Private ImageAttr As New System.Drawing.Imaging.ImageAttributes
	Private toc As TableOfContents

	' Direction constants

	Private Const PreviousCategory As Integer = -99
	Private Const PreviousRecipe As Integer = -1
	Private Const Beginning As Integer = 0
	Private Const NextRecipe As Integer = 1
	Private Const NextCategory As Integer = 99


	'**************************************************
	'
	' The form is loaded.  Assign the background picture
	' to the image control, which can stretch or shrink
	' it as we resize the form.
	'
	'**************************************************
	Private Sub OpenBook_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load


		' Declare variables

		Dim BookLeft As Integer
		Dim BookTop As Integer
		Dim BookWindowState As Short
		Dim zx As String

		' Get the saved open book window positions, if any

		zx = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "OpenBook", "Position", "0,0,0")
		BookLeft = Val(zx)
		zx = Mid(zx, InStr(1, zx, ",") + 1, Len(zx))
		BookTop = Val(zx)
		zx = Mid(zx, InStr(1, zx, ",") + 1, Len(zx))
		BookWindowState = Val(zx)

		' Turn off the design borders of the display fields

		lblTitle.BorderStyle = BorderStyle.None
		lblAuthor.BorderStyle = BorderStyle.None
		lblBlurb.BorderStyle = BorderStyle.None
		lblCategory.BorderStyle = BorderStyle.None
		lblServings.BorderStyle = BorderStyle.None
		pnlIngredients.BorderStyle = BorderStyle.None
		pnlProcedure.BorderStyle = BorderStyle.None

		' Set the size of the main window from the saved sizes

		If BookWindowState = 0 Then
			Me.Top = BookTop
			Me.Left = BookLeft
		Else
			Me.WindowState = BookWindowState
		End If


		' Display the book name and statistics

		lblBookTitle.Text = GetR(mBook, "Title")
		lblBookAuthor.Text = "By " & GetR(mBook, "Author") & vbCrLf & vbCrLf & CStr(toc.RecipesTable.Rows.Count) & " Recipe(s)"
		ShowStatistics()

	End Sub

	'**************************************************
	'
	' The form is unloaded
	'
	'**************************************************
	Private Sub OpenBook_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Declare variables

		Dim zx As String

		' Save the window size and position

		zx = CStr(Me.Left) & "," & CStr(Me.Top) & "," & CStr(Me.WindowState)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "OpenBook", "Position", zx)

		' If we have done anything to change the cookbook, then refresh the library

		If MyCookbook.PropertiesChanged Then frmMain.RefreshLibrary()

		' Dispose of objects we've created.

		LinksDS.Dispose()
		ImagesDS.Dispose()

	End Sub

	'**************************************************
	'
	' Sub to enable/disable the edit menu items.
	'
	'**************************************************
	Private Sub EnableEditMenuItems(ByRef State As Boolean)

		mnuCopyText.Enabled = State
		mnuCutText.Enabled = State
		mnuPasteText.Enabled = State

	End Sub

	'*******************************************************
	'
	' The "Save Recipe" button is clicked.
	'
	'*******************************************************
	Private Sub btnSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSave.Click

		' Make sure that a name and category have been entered.

		If txtTitle.Text = "" Then
			MsgBox("You must enter the recipe name.", MsgBoxStyle.Information, "Save Recipe")
			On Error Resume Next
			txtTitle.Focus()
			On Error GoTo 0
			Exit Sub
		End If

		If txtCategory.Text = "" Then
			MsgBox("You must enter the food category.", MsgBoxStyle.Information, "Save Recipe")
			On Error Resume Next
			txtCategory.Focus()
			On Error GoTo 0
			Exit Sub
		End If

		If txtIngredients.Text = "" Then
			MsgBox("You must enter at least one ingredient.", MsgBoxStyle.Information, "Save Recipe")
			On Error Resume Next
			txtIngredients.Focus()
			On Error GoTo 0
			Exit Sub
		End If

		If txtProcedure.Text = "" Then
			MsgBox("You must enter the procedure.", MsgBoxStyle.Information, "Save Recipe")
			On Error Resume Next
			txtProcedure.Focus()
			On Error GoTo 0
			Exit Sub
		End If

		' Save the recipe.

		SaveRecipe()
		EnableEditMenuItems(False)

	End Sub

	'****************************************************
	'
	' The Cancel button is clicked.  Return to the
	' Display Recipe mode.
	'
	'****************************************************
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		DisplayMode(2)
		If rMode = ADDRECORD Then ShowTOC()
		EnableEditMenuItems(False)
		LinkToolStripMenuItem.Visible = False
	End Sub

	'**************************************************

	' The main form is painted.  Draw a line for appearance sake
	' above and below the status label.

	'**************************************************
	Private Sub frmOpenBook_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

		' Declare variables.

		Dim g As Graphics = e.Graphics

		' Draw the lines.

		Dim p = New Pen(Brushes.DarkBlue, 3)
		g.DrawLine(p, lblStatistics.Left, lblStatistics.Top - 8, lblStatistics.Left + lblStatistics.Width, lblStatistics.Top - 8)
		g.DrawLine(p, lblStatistics.Left, lblStatistics.Top + lblStatistics.Height + 5, lblStatistics.Left + lblStatistics.Width, lblStatistics.Top + lblStatistics.Height + 5)

		' Clean up.

		p.Dispose()

	End Sub

	'****************************************************************
	'
	' The Next Category icon is clicked.
	'
	'****************************************************************
	Private Sub imgNextCat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles imgNextCat.Click
		If mDisplayMode > 0 Then
			ShowRecipes(NextCategory)
		Else
			ShowRecipes(Beginning)
		End If
	End Sub

	'****************************************************************
	'
	' The mouse is clicked
	'
	'****************************************************************
	Private Sub imgNextCat_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles imgNextCat.MouseDown
		imgNextCat.Image = frmMain.ImageList3.Images("CategoryRightClick.ico")
	End Sub


	'****************************************************************
	'
	' The mouse is released
	'
	'****************************************************************
	Private Sub imgNextCat_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles imgNextCat.MouseUp
		imgNextCat.Image = frmMain.ImageList3.Images("CategoryRight.ico")
	End Sub

	'****************************************************************
	'
	' The Previous Category icon is clicked.
	'
	'****************************************************************
	Private Sub imgPrevCat_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles imgPrevCat.Click
		If mDisplayMode > 0 Then
			ShowRecipes(PreviousCategory)
		End If
	End Sub

	'****************************************************************
	'
	' The mouse is clicked
	'
	'****************************************************************
	Private Sub imgPrevCat_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles imgPrevCat.MouseDown
		imgPrevCat.Image = frmMain.ImageList3.Images("CategoryLeftClick.ico")
	End Sub

	'****************************************************************
	'
	' The mouse is released
	'
	'****************************************************************
	Private Sub imgPrevCat_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles imgPrevCat.MouseUp
		imgPrevCat.Image = frmMain.ImageList3.Images("CategoryLeft.ico")
	End Sub


	'**************************************************
	'
	' The Copy Recipe (text format) menu item is selected.
	'
	'**************************************************
	Public Sub mnuCopyRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCopyRecipe.Click

		' Declare variables

		Dim ii As Integer
		Dim jj As Integer
		Dim kk As Integer
		Dim ll As Single
		Dim DisplayWidth As Single
		Dim zx0 As String = ""
		Dim zx1 As String = ""
		Dim zx2 As String = ""
		Dim Ing(60) As String
		Dim g As Graphics = pnlContents.CreateGraphics

		' Calculate the width of a six-inch "card" in pixels

		DisplayWidth = 6 * g.DpiX ' Width inches of emailed recipe converted to logical units

		' Get the text of the ingredient list

		zx0 = FormatIngredients(toc.Item(CurrentRecipeRow)("ID"))

		' Break the ingredient list into separate lines of
		' half the width of the email with a 1/4" space
		' between the two columns

		ii = 0
		While zx0 <> ""
			zx1 = WordWrap(g, Me.Font, zx0, (DisplayWidth / 2) - 0.25)
			ii = ii + 1
			Ing(ii) = zx1
		End While

		' Determine the width of the longest line in the first
		' column of the ingredients and add a 1/4" space
		' to that.

		ll = 0
		kk = Int(ii / 2 + 0.5)
		For jj = 1 To kk
			If g.MeasureString(Ing(jj), pnlContents.Font).Width > ll Then ll = g.MeasureString(Ing(jj), pnlContents.Font).Width
		Next jj
		ll = ll + 0.25

		' Assemble a list of the ingredients, padding the first column
		' as needed with spaces to make the second column line up
		' evenly on the left

		zx0 = ""
		For jj = 1 To kk
			If Ing(jj) <> "" Then
				While g.MeasureString(Ing(jj), pnlContents.Font).Width < ll
					Ing(jj) = Ing(jj) & Chr(9)
				End While
			End If
			zx0 = zx0 & Ing(jj)
			If Ing(jj + kk) <> "" Then zx0 = zx0 & Ing(jj + kk)
			zx0 = zx0 & vbCrLf
		Next jj

		' Assemble the entire recipe now: name, author (if there
		' is one) the now-formatted ingredient list and the
		' procedure.

		zx1 = ""
		zx1 = zx1 & New String(" ", (DisplayWidth - g.MeasureString(toc(CurrentRecipeRow)("RecipeName"), pnlContents.Font).Width / 2 / g.MeasureString(" ", pnlContents.Font).Width)) & toc(CurrentRecipeRow)("RecipeName") & vbCrLf
		If GetR(toc(CurrentRecipeRow), "Author") <> "" Then zx2 = New String(" ", (DisplayWidth - g.MeasureString(toc(0)("Author"), pnlContents.Font).Width) / 2 / g.MeasureString(" ", pnlContents.Font).Width) & toc(CurrentRecipeRow)("Author") & vbCrLf
		zx0 = zx1 & zx2 & vbCrLf & zx0 & vbCrLf
		zx2 = toc(CurrentRecipeRow)("Procedure")
		While zx2 <> ""
			zx0 = zx0 & WordWrap(g, pnlContents.Font, zx2, DisplayWidth) & vbCrLf
		End While

		' Place the formatted ingredient list into the clipboard.

		My.Computer.Clipboard.Clear()
		My.Computer.Clipboard.SetText(zx0)

	End Sub
	'**************************************************
	'
	' The Copy Recipe (Exahange format) item is selected.
	'
	'**************************************************
	Public Sub mnuCopyExchange_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCopyExchange.Click

		' Declare variables

		Dim xx As Integer
		Dim zx0 As String
		Dim zx1 As String
		Dim ImageData() As Byte
		Dim MS As MemoryStream

		' Get the text of the ingredient list

		zx0 = FormatIngredients(toc(CurrentRecipeRow)("ID"))

		' Assemble the header text

		zx1 = "[Header]" & vbCrLf

		' Assemble the entire recipe now: RecipeName, author (if there
		' is one) the now-formatted ingredient list and the
		' procedure.

		zx1 = zx1 & "RecipeName=" & GetR(toc(CurrentRecipeRow), "RecipeName") & vbCrLf
		zx1 = zx1 & "Category=" & toc(CurrentRecipeRow)("Category") & vbCrLf
		zx1 = zx1 & "Blurb=" & GetR(toc(CurrentRecipeRow), "Blurb") & vbCrLf
		zx1 = zx1 & "Author=" & GetR(toc(CurrentRecipeRow), "Author") & vbCrLf
		zx1 = zx1 & "Procedure=" & GetR(toc(CurrentRecipeRow), "Procedure") & vbCrLf
		zx1 = zx1 & vbCrLf
		zx1 = zx1 & "[Ingredients]" & vbCrLf
		zx1 = zx1 & zx0 & vbCrLf


		' See if there is an image for this recipe.

		xx = Find2(ImagesTable, "ParentID=" & toc(CurrentRecipeRow)("ID"))
		If xx <> NOMATCH Then

			' Get the image data and convert it to an image.

			ImageData = ImagesTable.Rows(xx)("DocumentImage")
			MS = New MemoryStream(ImageData)


			' Convert the image data to a Base64 string.

			zx0 = EncodeBase64(ImageData, 0) ' Could also use built-in Convert.ToBase64String
			'zx0 = Convert.ToBase64String(ImageData, Base64FormattingOptions.None)
			zx1 &= "[Image]" & vbCrLf & zx0

		End If

		' Place the formatted ingredient list into the clipboard.

		My.Computer.Clipboard.Clear()
		My.Computer.Clipboard.SetText(zx1)

	End Sub
	'**************************************************
	'
	' The Copy Text menu item is selected.
	'
	'**************************************************
	Public Sub mnuCopyText_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCopyText.Click

		My.Computer.Clipboard.Clear()
		My.Computer.Clipboard.SetText(CType(Me.ActiveControl, TextBox).SelectedText)

	End Sub


	'**************************************************
	'
	' The Cut Text menu item is selected.
	'
	'**************************************************
	Public Sub mnuCutText_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCutText.Click

		My.Computer.Clipboard.Clear()
		If TypeOf (Me.ActiveControl) Is TextBox Then
			My.Computer.Clipboard.SetText(CType(Me.ActiveControl, TextBox).SelectedText)
			CType(Me.ActiveControl, TextBox).SelectedText = ""
		End If
	End Sub


	'**************************************************
	'
	' The Paste Text menu item is selected.
	'
	'**************************************************
	Public Sub mnuPasteText_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPasteText.Click

		' Declare variables

		Dim zx0 As String
		Dim zx1 As String

		' Get the text from the active control and the text
		' from the clipboard.

		zx0 = Me.ActiveControl.Text
		zx1 = My.Computer.Clipboard.GetText

		' Insert the text into the control's data

		If zx0 <> "" Then
			zx0 = VB.Left(zx0, CType(Me.ActiveControl, TextBox).SelectionStart) & zx1 & Mid(zx0, CType(Me.ActiveControl, TextBox).SelectionStart + 1)
		Else
			zx0 = zx1
		End If

		' Replace the control's data with the modified
		' string

		CType(Me.ActiveControl, TextBox).Text = zx0

	End Sub


	'**************************************************
	'
	' The Print Dividers menu option is selected.
	'
	'**************************************************
	Public Sub mnuPrintDividers_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrintDividers.Click

		' Declare variables

		Dim ID As Integer

		' Load the options form and fill the listbox with
		' the categories from the current cookbook.

		Dim FD As New frmFileDividers
		ID = mBook("ID")
		FD.ShowDividerDialog(ID)

	End Sub


	'***********************************************
	'
	' The Table of Contents tab is clicked.
	'
	'***********************************************
	Private Sub imgTOC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles imgTOC.Click

		' Show the table of contents tab, move all alphabetic
		' tabs to the right and display the table of contents.

		ShowTOC() ' Start at beginning

	End Sub
	'***********************************************
	'
	' One of the Tabs is clicked.
	'
	'***********************************************
	Private Sub imgTabs_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As MouseEventArgs) Handles imgLeftTabs.MouseDown, imgRightTabs.MouseDown

		' Declare variables

		Dim TabIndex As Integer
		Dim I As PictureBox = CType(eventSender, PictureBox)

		' Determine which tab location was clicked on by the coordinates clicked.

		If eventSender Is imgLeftTabs Then
			If eventArgs.X < I.Width / 2 Then
				TabIndex = eventArgs.Y / 33 + 0.5
			Else
				TabIndex = (eventArgs.Y - 15) / 33 + 11.5
			End If
		Else
			If eventArgs.X < I.Width / 2 Then
				TabIndex = eventArgs.Y / 33 + 0.5
			Else
				TabIndex = (eventArgs.Y - 15) / 33 + 11.5
			End If
		End If

		' Select the tab

		If TabIndex < 1 Then TabIndex = 1
		If TabIndex > 22 Then TabIndex = 22

		SelectTab(TabIndex)

		' Display the recipe.

		' Show the first recipe for the selected alphabetic character of the tab.

		ShowRecipes(StartLetter:=Mid("ABCDEFGHIJKLMNOPQRSTUX", TabIndex, 1))

	End Sub


	'**************************************************
	'
	' The "Edit" Recipe menu option is selected
	'
	'**************************************************
	Public Sub mnuEditRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEditRecipe.Click
		EditRecipe()
	End Sub

	'**************************************************
	'
	' The Email recipe menu option is selected.
	'
	'**************************************************
	Public Sub mnuEmailRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuEmailRecipe.Click, mnuPEmailRecipe.Click
		frmEmail.Recipe = toc(CurrentRecipeRow)
		frmEmail.Show()
	End Sub

	'**************************************************
	'
	' The "New" Recipe menu option is selected
	'
	'**************************************************
	Public Sub mnuNewRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuNewRecipe.Click
		NewRecipe()
	End Sub


	'****************************************************
	'
	' The Paste Recipe menu option is selected.
	'
	'****************************************************
	Public Sub mnuPasteRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPasteRecipe.Click

		' Declare variables

		Dim NewRecipeID As Integer
		Dim zx0 As String
		Dim zx1 As String
		Dim Process As String = ""
		Dim dr As DataRow
		Dim ImageData() As Byte = Nothing
		Dim Transaction As SqlTransaction = Nothing

		' Get the clipboard contents

		If My.Computer.Clipboard.ContainsText() Then
			zx0 = My.Computer.Clipboard.GetText

			' See if the contents are a recipe in Exchange Format.

			If zx0.ToLower.Contains("<recipe>") Then


				' Get the recipe information from the XML document in the clipboard.
				Try
					Process = "parsing Exchange Data"
					Dim xmlText As String = Clipboard.GetText()
					Dim doc As XDocument = XDocument.Parse(xmlText)

					' Access header information
					Dim header = doc.Root.Element("header")
					Dim recipeName As String = header?.Element("recipename")?.Value
					Dim category As String = header?.Element("category")?.Value
					Dim blurb As String = header?.Element("blurb")?.Value
					Dim author As String = header?.Element("author")?.Value
					Dim servings As String = header?.Element("servings")?.Value
					Dim imageBase64 As String = header?.Element("image")?.Value

					' Read ingredients
					Dim ingredients As New List(Of String)
					For Each ing In doc.Root.Elements("ingredient")
						ingredients.Add(ing.Value)
					Next ing

					' Read procedure
					Dim procedureText As String = doc.Root.Element("procedure")?.Value

					'Read Notes

					Dim notesText As String = doc.Root.Element("notes")?.Value

					' Begin a transaction.

					Process = "Creating transction"
					Transaction = DB.BeginTransaction
					RecipesDA.UpdateCommand.Transaction = Transaction
					RecipesDA.SelectCommand.Transaction = Transaction
					RecipesDA.InsertCommand.Transaction = Transaction
					IngredientsDA.InsertCommand.Transaction = Transaction
					IngredientsDA.SelectCommand.Transaction = Transaction
					IngredientsDA.UpdateCommand.Transaction = Transaction

					' Add a new recipe record, parsing the exchange format
					' text to get the header fields.

					Process = "adding recipe record"
					dr = toc.NewRow
					dr("ParentID") = mBook("ID")
					dr("RecipeName") = recipeName
					dr("Blurb") = blurb
					dr("Author") = author
					dr("Category") = category
					If servings = "" Then dr("Servings") = 0 Else dr("Servings") = servings
					dr("Procedure") = procedureText
					dr("Notes") = notesText

					' Fill in fields not pasted.

					dr("CardStyle") = 0
					dr("CardWidth") = 0
					dr("CardHeight") = 0
					dr("LeftMargin") = 0
					dr("IngredientsMargin") = 0
					dr("ProcedureMargin") = 0
					dr("Heading Margin") = 0
					dr("FontSize") = 9
					dr("FontName") = "Arial"
					dr("Scale") = ""
					dr("Favorite") = False
					dr("DateAdded") = Now.Date

					' Now save the recipe record

					Process = "saving recipe record"

					toc.AddRecipe(dr)

					' Get the ID of the record just added.

					NewRecipeID = dr("ID")

					' Save the recipe's ingredients

					Process = "Saving ingredients"
					zx1 = ""
					For Each ing In ingredients
						zx1 &= ing & vbCrLf
					Next ing
					SaveIngredients(dr, zx1)



					' See if there is an image attached.

					If imageBase64 <> "" Then
						Process = "converting image"
						ImageData = Convert.FromBase64String(imageBase64)
					End If

					' If there is an image, add it to the images table.

					If Not ImageData Is Nothing AndAlso ImageData.Length > 0 Then
						Process = "saving Image"
						ImagesDA.InsertCommand.Transaction = Transaction
						dr = ImagesTable.NewRow
						dr("ParentID") = NewRecipeID
						dr("DocumentImage") = ImageData
						ImagesTable.Rows.Add(dr)
						ImagesDA.Update(ImagesTable)
					End If

					' Commit the transaction and mark the database as changed.

					Transaction.Commit()
					DatabaseChanged = True

					' Update the display of the statistics.

					ShowStatistics()

					' Destroy the bookmarks collection so the
					' table of contents will be rebuilt when displayed,
					' to show any newly-added records, or those which
					' now belong in a different food category.

					mBookmarks = Nothing

					' Display the recipe again.

					ShowRecipes(ID:=NewRecipeID)
				Catch ex As Exception
					MsgBox($"Paste failed while {Process}." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Paste Recipe")
					If Transaction IsNot Nothing Then Transaction.Rollback()
				End Try

			End If
		End If

		' Rebuild the recent menu.

		FillRecentMenu(False)
		FillRecentMenu(True)

	End Sub

	'****************************************************
	'
	' The Paste Image menu option is selected.
	'
	'****************************************************
	Public Sub mnuPasteImage_Click(ByVal sender As Object, e As EventArgs) Handles mnuPasteImage.Click

		' Declare variables.

		Dim FileName As String = ""
		Dim di As DataRow
		Dim ms As MemoryStream
		Dim i As Image
		Dim s As Size

		' Get the image from the clipboard.

		i = Clipboard.GetImage

		' Put the image into the picture box, and resize the blurb to allow it to
		' be seen.

		PictureBox1.Image = i
		txtBlurb.Width = 227
		PictureBox1.Visible = True

		' Add the new page to the images database.

		Try
			di = ImagesTable.NewRow
			di("ParentID") = toc(CurrentRecipeRow)("ID")

			' Check the size of the image and if it's larger than 1.5 MB, size it down.

			ms = New MemoryStream
			If PictureBox1.Image.Width * PictureBox1.Image.Height * 4 > 1500000 Then ' Calculate size of image, 32-bit color.
				s = GetResizedDimensions(PictureBox1.Image)
				Dim bitmp As New Bitmap(PictureBox1.Image, s)
				bitmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
			Else

				' Get the image as a series of bytes, based on the format.

				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
			End If
			di("DocumentImage") = ms.ToArray

			' Save the new record.

			ImagesTable.Rows.Add(di)
			ImagesDA.Update(ImagesTable)

			' Rebuild the images dataset to include the new image.

			ImagesDS.Clear()
			ImagesDA.Fill(ImagesDS, "Table")
			ImagesTable = ImagesDS.Tables("Table")

			' Indicate the database has changed.

			DatabaseChanged = True

			' Refresh the page.

			ShowRecipe()

		Catch ex As Exception
			MsgBox("Paste Image failed." & vbCrLf & ex.Message, MsgBoxStyle.Information, "Add Image To Recipe")

		End Try


	End Sub
	'**************************************************
	'
	' The "Print" Recipe menu option is selected.
	'
	'**************************************************
	Public Sub mnuPrintRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuPrintRecipe.Click, mnuPPrintRecipe.Click
		PrintRecipe()
	End Sub


	'**************************************************
	'
	' The "Remove" Recipe menu option is selected.
	'
	'**************************************************
	Public Sub mnuRemoveRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuRemoveRecipe.Click
		RemoveRecipe()
	End Sub


	'**************************************************
	'
	' The "Save" Recipe menu option is selected
	'
	'**************************************************
	Public Sub mnuSaveRecipe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveRecipe.Click
		btnSave_Click(eventSender, eventArgs)
	End Sub

	'*******************************************************
	'
	' One of the entry fields has got the focus.
	'
	'*******************************************************
	Private Sub Text_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtTitle.Enter, txtCategory.Enter, txtAuthor.Enter, txtBlurb.Enter, txtServings.Enter, txtIngredients.Enter, txtProcedure.Enter

		' Make sure no text is selected.

		eventSender.SelectionStart = 0
		eventSender.SelectionLength = 0
		EnableEditMenuItems(True)
	End Sub

	'*******************************************************
	'
	' A key is pressed in one of the entry fields.
	'
	'*******************************************************
	Private Sub Text_KeyDown_(sender As Object, e As KeyEventArgs) Handles txtProcedure.KeyDown, txtIngredients.KeyDown, txtTitle.KeyDown, txtBlurb.KeyDown, txtAuthor.KeyDown, txtNotes.KeyDown

		If e.KeyCode = Keys.Insert AndAlso e.Shift Then CType(sender, PromptedTextBox.PromptedTextBox).SelectedText = Clipboard.GetText

	End Sub
	'*******************************************************
	'
	' One of the entry fields has received a keystroke.
	'
	'*******************************************************
	Private Sub Text_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIngredients.KeyPress, txtProcedure.KeyPress, txtNotes.KeyPress


		' Declare variables

		Dim ii As Integer
		Dim KeyAscii As Integer = Asc(e.KeyChar)
		Dim xx As Integer
		Dim t As PromptedTextBox.PromptedTextBox = sender
		Dim zx As String = t.Text
		Dim LastChar As String = ""
		Dim Last2Chars As String = ""
		Dim Last4Chars As String = ""
		Dim Last5Chars As String = ""
		Dim Last6Chars As String = ""

		' Get the various amounts of text before the insertion point.

		If zx.Length > 0 And t.SelectionStart >= 1 Then LastChar = zx.Substring(t.SelectionStart - 1, 1)
		If zx.Length >= 2 And t.SelectionStart >= 2 Then Last2Chars = zx.Substring(t.SelectionStart - 2, 2)
		If zx.Length >= 4 And t.SelectionStart >= 4 Then Last4Chars = zx.Substring(t.SelectionStart - 4, 4)
		If zx.Length >= 5 And t.SelectionStart >= 5 Then Last5Chars = zx.Substring(t.SelectionStart - 5, 5)
		If zx.Length >= 6 And t.SelectionStart >= 6 Then Last6Chars = zx.Substring(t.SelectionStart - 6, 6)

		' Get the location of where we are typing.

		ii = t.SelectionStart

		On Error Resume Next

		' Watch for special commonly-used French words, like Saute, Puree and Flambe.  Correct
		' the spelling to be proper.

		If KeyAscii <> 8 Then ' don't do this on a backspace
			If LCase(e.KeyChar) = "e" Then
				If Last4Chars = "saut" Then KeyAscii = 233 ' "é"
				If Last4Chars = "pure" Then KeyAscii = 233 ' "é"
				If Last4Chars = "blas" Then KeyAscii = 233 ' "é"
				If Last6Chars = "on app" Then KeyAscii = 233 ' "é"
				If Last4Chars = " pat" Then
					t.SelectionStart = ii - 4
					t.SelectionLength = 4
					t.SelectedText = " pât"
					KeyAscii = 233 ' "é"
				End If

				If Last6Chars = "souffl" Then KeyAscii = 233 ' "é"
				If Last5Chars = "canap" Then KeyAscii = 233 ' "é"
				If Last5Chars = "flamb" Then KeyAscii = 233 ' "é"
				If Last5Chars = "d’etr" Then
					t.SelectionStart = ii - 5
					t.SelectionLength = 5
					t.SelectedText = "d’êtr"
				End If
			ElseIf LCase(e.KeyChar) = "u" Then
				If Last6Chars = "deja v" Then
					t.SelectionStart = ii - 6
					t.SelectionLength = 6
					t.SelectedText = "déjà v"
				End If
				If Last6Chars = "iramis" Then KeyAscii = 249 ' ù

			ElseIf LCase(e.KeyChar) = "n" Then
				If Last6Chars = "soupco" Then
					t.SelectionStart = ii - 6
					t.SelectionLength = 6
					t.SelectedText = "soupço"
				End If

			ElseIf LCase(e.KeyChar) = "a" Then
				If Last4Chars = " ser" Then KeyAscii = 225 ' á
			End If


			' This is done only for the category field.

			If t Is txtCategory Then
				If KeyAscii = 32 Or KeyAscii = Asc(";") Then KeyAscii = Asc(",")
			End If


			' In the procedure field, watch for oven temperatures and
			' add a degree symbol automatically.

			If t Is txtProcedure Then
				xx = Val(Mid(zx, Len(zx) - 1, 2) & Chr(KeyAscii))
				If xx >= 100 And xx <= 500 Then
					t.Text = zx & Chr(KeyAscii)
					KeyAscii = 186 ' Degree symbol
					t.SelectionStart = Len(zx) + 1
				End If
			End If

			' Watch for two dashes and convert them to a double-dash

			If KeyAscii = Asc("-") And VB.Right(zx, 1) = "-" Then
				t.Text = VB.Left(zx, Len(zx) - 1)
				KeyAscii = 151 ' Code for long dash
				t.SelectionStart = Len(zx) + 1
			End If
			On Error GoTo 0

			' Watch for fractions and convert them, like "3/4" becomes "¾".

			If KeyAscii >= 49 And KeyAscii <= 57 And LastChar = "/" Then
				xx = Val(Chr(KeyAscii))
				Select Case Last2Chars
					Case "1/"
						If xx = 2 Then KeyAscii = 189
						If xx = 3 Then KeyAscii = 8531
						If xx = 4 Then KeyAscii = 188
						If xx = 8 Then KeyAscii = 8539
					Case "2/"
						If xx = 3 Then KeyAscii = 8532
					Case "3/"
						If xx = 4 Then KeyAscii = 190
						If xx = 8 Then KeyAscii = 8540
					Case "5/"
						If xx = 8 Then KeyAscii = 8541
				End Select
				t.SelectionStart -= 2
				t.SelectionLength = 2
				t.SelectedText = ""
			End If

		End If


			e.KeyChar = ChrW(KeyAscii)
		If KeyAscii = 0 Then
			e.Handled = True
		End If
	End Sub

	'**************************************************

	' The contents of the ingredients entry box have changed.

	'**************************************************
	Private Sub txtIngredients_TextChanged(sender As Object, e As EventArgs) Handles txtIngredients.TextChanged

		' Set the flag to indicate the ingredients have changed.
		' When saving a recipe, we won't delete and re-create the
		' ingredients if these do not change.

		IngredientsChanged = True

	End Sub
	'**************************************************

	' The category entry box is exited.

	'**************************************************
	Private Sub txtCategory_Leave(sender As Object, e As EventArgs) Handles txtCategory.Leave
		txtCategory.Text = Capitalize(txtCategory.Text)
	End Sub

	'**************************************************
	'
	' The Ingredients pane is scrolled.
	'
	'**************************************************
	Private Sub VScrollBar1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll

		' Do nothing until scrolling has stopped

		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll

				' Declare variables

				Dim jj As Short
				Dim xx As String
				Dim zx As String
				Dim g As Graphics = pnlIngredients.CreateGraphics

				' Strip off one line and display the rest

				zx = FormatIngredients(toc(CurrentRecipeRow)("ID"))
				For jj = 1 To eventArgs.NewValue
					xx = WordWrap(g, pnlIngredients.Font, zx, pnlIngredients.Width)
				Next jj
				IngredientsText = zx
				pnlIngredients.Invalidate()
				g.Dispose()
		End Select

	End Sub
	'**************************************************
	'
	' The scroll bar for the procedure text has changed.
	'
	'**************************************************
	Private Sub VScrollBar2_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar2.Scroll

		' Do nothing until scrolling has stopped

		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll

				' Declare variables

				Dim jj As Short
				Dim xx As String
				Dim zx As String
				Dim g As Graphics = pnlProcedure.CreateGraphics

				' Strip off one line and display the rest

				zx = GetR(toc(CurrentRecipeRow), "Procedure")
				If GetR(toc(CurrentRecipeRow), "Notes") <> "" Then zx &= vbCrLf & vbCrLf & "Notes: " & GetR(toc(CurrentRecipeRow), "Notes")
				For jj = 1 To eventArgs.NewValue
					xx = WordWrap(g, pnlProcedure.Font, zx, CDbl(pnlProcedure.Width))
				Next jj
				ProcedureText = zx
				pnlProcedure.Invalidate()
				g.Dispose()
		End Select

	End Sub
	'**************************************************
	'
	' The main panel needs to be redrawn.
	'
	'**************************************************
	Private Sub PanelMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlContents.Paint

		' Declare variables

		Dim zx As String
		Dim LastCategory As String = ""

		' Do nothing if not in Table of Contents display mode, or if we don't want
		' to process the paint event at this time.

		If mDisplayMode > 0 Or DontProcessEvent Then Exit Sub

		' Initialize the pane number and overflow flags before drawing the left hand page

		mPaneNo = 1
		PageOverflow = False
		mZones = Nothing
		mZones = New Collection

		' Print the page title on the left hand page

		PrintPageTitle(mPaneNo, e.Graphics)

		' Begin printing the table of contents from the
		' beginning, or from the next item in the file.

		If mCategory.Count > 0 Then
			CurrentRecipeRow = mBookmarks.Item(CStr(mPageNo)).FirstRecord
			Do


				' Print the recipe titles.  When  we fill the first pane, move to the second.
				' When we fill the second, we are done until the user clicks "next" or "previous".

				Do
					' If the category has changed, print a subheading

					zx = (toc(CurrentRecipeRow)("Category"))
					If Not zx.Contains(LastCategory) OrElse LastCategory = "" Then
						PageOverflow = PrintCategory(mPaneNo, e.Graphics)
						If Not PageOverflow Then PageOverflow = PrintRecipeName(mPaneNo, e.Graphics)
					Else
						PageOverflow = PrintRecipeName(mPaneNo, e.Graphics)
					End If
					If PageOverflow And mPaneNo = 2 Then Exit Do
					If PageOverflow And mPaneNo = 1 Then mPaneNo = 2
				Loop While PageOverflow

				' If we didn't hit the end of the page, remember this record category and position.

				If Not PageOverflow Then
					LastCategory = toc(CurrentRecipeRow)("Category")
					mBookmarks.Item(CStr(mPageNo)).LastRecord = CurrentRecipeRow

					' Move to the next record.

					CurrentRecipeRow += 1
				End If
			Loop While CurrentRecipeRow < toc.Count And Not PageOverflow


		End If


	End Sub
	'***************************************************************

	' The mouse is pressed in the table of contents
	'
	'****************************************************************
	Private Sub PanelMain_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlContents.MouseDown

		'  Declare variables

		Dim pz As PrintZone

		' Find the printzone clicked on, and save its recipe id.  If the left button was
		' clicked, show the recipe

		If Not mZones Is Nothing Then
			For Each pz In mZones
				If e.X >= pz.x1 And e.X <= pz.x2 And e.Y >= pz.y1 And e.Y <= pz.y2 Then
					If e.Button = Windows.Forms.MouseButtons.Left Then
						ShowRecipes(Bookmark:=pz.Bookmark)
						Exit For
					Else ' A right click would bring up the context menu.  Make the selected recipe current so the context menu can work with it.
						CurrentRecipeRow = pz.Bookmark
					End If
				End If
			Next pz
		End If

	End Sub
	'****************************************************************
	'
	' The mouse is clicked. Alternate the image from red to green.
	'
	'****************************************************************
	Private Sub imgNext_MouseDown(ByVal Sender As Object, ByVal eventArgs As MouseEventArgs) Handles imgNext.MouseDown
		Sender.Image = frmMain.ImageList3.Images("RecipeRightClick.ico")
	End Sub
	'****************************************************************
	'
	' The mouse is released. Alternate the image from green to red.
	'
	'****************************************************************
	Private Sub imgNext_MouseUp(ByVal Sender As Object, ByVal eventArgs As MouseEventArgs) Handles imgNext.MouseUp
		Sender.image = frmMain.ImageList3.Images("RecipeRight.ico")
	End Sub

	'**************************************************
	'
	' The Next Page button is clicked.
	'
	'**************************************************

	Private Sub imgNext_Click(sender As Object, e As EventArgs) Handles imgNext.Click

		' Declare variables

		Dim xx As Integer
		Dim en As Integer
		Dim lBM As Bookmark

		' See if we are displaying the Table of Contents or recipes

		If mDisplayMode = 0 Then ' Displaying the TOC

			' Increase the page number.

			mPageNo += 1

			' See if we are at the end of the file

			If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then

				' See if a bookmark already exists for the new page, by attempting to access its "first mnurecord" property.

				On Error Resume Next
				xx = mBookmarks.Item(CStr(mPageNo)).FirstRecord
				en = Err.Number
				On Error GoTo 0

				' If a bookmark for the new page does not already exist, create a new bookmark and add it to the collection

				If en = 5 Then
					lBM = New Bookmark
					lBM.FirstRecord = CurrentRecipeRow ' Where we left off after drawing last page of table of contents.
					mBookmarks.Add(lBM, CStr(mPageNo))
				Else
					CurrentRecipeRow = xx
				End If

				' Reset the pane back to the left hand side and invalidate the form, so it will be redrawn with the next group
				' of recipes in the table of contents.

				mPaneNo = 1
				mPage1Y = 0
				mPage2Y = 0
				PageOverflow = False

				pnlContents.Invalidate()

				' We are displaying individual recipes

			Else
				ShowRecipes(Beginning)
			End If

		Else
			ShowRecipes(NextRecipe)
		End If


	End Sub

	'****************************************************************
	'
	' The mouse is clicked on the Previous Recipe button.
	' Alternate the image from red to green.
	'
	'****************************************************************
	Private Sub imgPrev_MouseDown(sender As Object, e As MouseEventArgs) Handles imgPrev.MouseDown
		sender.image = frmMain.ImageList3.Images("RecipeLeftClick.ico")
	End Sub

	'****************************************************************
	'
	' The mouse is released on the Previous Recipe button.
	' Alternate the image from green to red.
	'
	'****************************************************************
	Private Sub imgPrev_MouseUp(sender As Object, e As MouseEventArgs) Handles imgPrev.MouseUp
		sender.image = frmMain.ImageList3.Images("RecipeLeft.ico")
	End Sub
	'**************************************************
	'
	' The Previous Page button is clicked.
	'
	'**************************************************

	Private Sub imgPrev_Click(sender As Object, e As EventArgs) Handles imgPrev.Click

		' See what display mode we are in

		If mDisplayMode = 0 Then ' Displaying TOC

			' Decrease the page number.

			If mPageNo > 1 Then
				mPageNo = mPageNo - 1

				' Reset the pane back to the left hand side and invalidate the form, so it will be redrawn with the next group
				' of recipes in the table of contents.

				mPaneNo = 1
				mPage1Y = 0
				mPage2Y = 0
				PageOverflow = False

				' Force the panel to be redrawn

				pnlContents.Invalidate()
			End If

			' If in recipes display mode

		ElseIf mDisplayMode = 2 Then ' Displaying recipes
			ShowRecipes(PreviousRecipe)
		End If

	End Sub


	'**************************************************

	' The Move Recipe menu item is clicked.

	'**************************************************
	Private Sub mnuMoveRecipe_Click(sender As Object, e As EventArgs) Handles mnuMoveRecipe.Click

		' Declare variables

		Dim RecipeID As Integer

		' Make sure the user wants to do this.

		If MsgBox("Are you sure you want to move this recipe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Move Recipe") = MsgBoxResult.Yes Then

			' Get the ID of the recipe to be moved, and call the routine to move it.

			RecipeID = toc(CurrentRecipeRow)("ID")
			MoveRecipe(RecipeID)

			' Rebuild the recipes dataset to reflect the change.

			toc.Refresh()

			mBookmarks = Nothing ' Destroy bookmarks so they will be recreated
			If mDisplayMode = 0 Or toc.Count = 0 Then
				ShowTOC()
			Else
				ShowRecipes(NextRecipe)
			End If

			' Flag that the database has changed

			DatabaseChanged = True
			ShowStatistics()
			MyCookbook.PropertiesChanged = True
		End If

	End Sub


	'**************************************************

	' The Add Image menu option is selected.

	'**************************************************
	Private Sub mnuAddImage_Click(sender As Object, e As EventArgs) Handles mnuAddImage.Click

		' Declare variables.

		Dim FileName As String = ""
		Dim di As DataRow
		Dim ms As MemoryStream

		' Get the name of the file to be imported.

		frmMain.OpenFileDialog1.FileName = ""
		frmMain.OpenFileDialog1.Filter = "JPEG File (*.JPG)|*.jpg|BMP File (*.bmp)|*.bmp|PNG File (*.PNG)|*.png|TIFF File (*.tif)|*.tif"
		frmMain.OpenFileDialog1.FilterIndex = 1
		frmMain.OpenFileDialog1.Title = "Import Image File"
		If frmMain.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

			' Get the file name specified

			FileName = frmMain.OpenFileDialog1.FileName

			' Put the image into the picture box, and resize the blurb to allow it to
			' be seen.

			PictureBox1.Load(FileName)
			txtBlurb.Width = 227
			PictureBox1.Visible = True

			' Add the new page to the images database.

			Try
				di = ImagesTable.NewRow
				di("ParentID") = toc(CurrentRecipeRow)("ID")

				' Get the image as a series of bytes, based on the format.

				ms = New MemoryStream
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp) ' This gets image data from any image from any source
				If PictureBox1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp) Then PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
				di("DocumentImage") = ms.ToArray

				' Save the new record.

				ImagesTable.Rows.Add(di)
				ImagesDA.Update(ImagesTable)

				' Rebuild the images dataset to include the new image.

				ImagesDS.Clear()
				ImagesDA.Fill(ImagesDS, "Table")
				ImagesTable = ImagesDS.Tables("Table")

				' Indicate the database has changed.

				DatabaseChanged = True

				' Refresh the page.

				ShowRecipe()

			Catch ex As Exception
				MsgBox("Add Image failed." & vbCrLf & ex.Message, MsgBoxStyle.Information, "Add Image To Recipe")

			End Try

		End If

	End Sub
	'**************************************************

	' The Delete Image menu option is selected.

	'**************************************************
	Private Sub mnuDeleteImage_Click(sender As Object, e As EventArgs) Handles mnuDeleteImage.Click

		' Declare variables.

		Dim Command As SqlCommand

		' Make sure the user wants to delete the image.

		If MsgBox("Are you sure you want to delete this image?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Delete Image") = MsgBoxResult.Yes Then

			Try

				' Build a command to delete the attached image and execute it. 

				Command = New SqlCommand("DELETE FROM tblImages WHERE ParentID=" & toc(CurrentRecipeRow)("ID"), DB)
				Command.ExecuteNonQuery()

				' Rebuild the images dataset to reflect the deleted record.

				ImagesDS.Clear()
				ImagesDA.Fill(ImagesDS, "Table")
				ImagesTable = ImagesDS.Tables("Table")

				' Refresh the recipe

				ShowRecipe()

				' Indicate the database has changed.

				DatabaseChanged = True

			Catch ex As Exception
				MsgBox("Delete image failed" & vbCrLf & ex.Message, MsgBoxStyle.Information, "Delete Image")
			End Try
		End If

	End Sub
	'**************************************************

	' The image preview box is clicked.

	'**************************************************
	Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

		' Create a new image viewer and view the recipe's image.

		Dim IV As New frmImageViewer
		IV.View(toc(CurrentRecipeRow)("ID"))

	End Sub
	'**************************************************

	' The Change Servings menu option is selected.

	'**************************************************
	Private Sub mnuChangeServings_Click(sender As Object, e As EventArgs) Handles mnuChangeServings.Click

		' Declare variables

		Dim fCS As New SiriusCook_ChangeServings

		' Load the ID of the recipe we'll be modifying into the form and
		' show it.

		fCS.RecID = toc(CurrentRecipeRow)("ID")
		fCS.ShowDialog()

		' The user may just print the modified copy, or save it.  See if
		' they saved it.

		If fCS.SavedModifiedRecipe Then

			' Rebuild the recipes dataset to reflect the change.

			toc.Refresh()

			' Redisplay the cookbook with the changes.

			mBookmarks = Nothing ' Destroy bookmarks so they will be recreated
			If mDisplayMode = 0 Or toc.Count = 0 Then
				ShowTOC()
			Else
				ShowRecipes(NextRecipe)
			End If

			' Mode is edit now regardless

			rMode = MODIFYRECORD

			' Display the recipe again.

			ShowRecipes(Bookmark:=CurrentRecipeRow)

			' Flag that the database has changed

			DatabaseChanged = True

			' Update the displayed record count

			ShowStatistics()

		End If
	End Sub
	'****************************************************************

	' The Link to another recipe menu option is selected.

	'****************************************************************
	Private Sub mnuLink_Click(sender As Object, e As EventArgs) Handles mnuLink.Click

		' Declare variables

		Dim zx As String

		' Make sure we are entering or editing a recipe.

		If mDisplayMode = 1 Then

			' See if any text has already been selected, and if not, tell the user to select it now.

			If txtProcedure.SelectedText = "" And txtIngredients.SelectedText = "" Then
				MsgBox("Select the text you wish To become the link To another recipe.", MsgBoxStyle.Information, "Insert Link")
				BeginLink = True
			Else
				If txtIngredients.SelectedText <> "" Then zx = txtIngredients.SelectedText Else zx = txtProcedure.SelectedText
				frmAddLink.txtLinkText.Text = zx
				frmAddLink.ShowDialog()
				PerformStartup() ' Do this again to rebuild the links table.
				BeginLink = False
			End If
		End If

	End Sub

	'****************************************************************

	' The maintain links menu option is selected.

	'****************************************************************
	Private Sub mnuMaintainLinks_Click(sender As Object, e As EventArgs) Handles mnuMaintainLinks.Click
		frmMaintainLinks.ShowDialog()
		IngredientsText = FormatIngredients(toc(CurrentRecipeRow)("ID"))
		ProcedureText = GetR(toc(CurrentRecipeRow), "Procedure")
		pnlIngredients.Invalidate()
		pnlProcedure.Invalidate()
	End Sub
	'**************************************************

	' Sub to redraw the Table of Contents tab.

	'**************************************************
	Private Sub imgTOC_Paint(sender As Object, e As PaintEventArgs) Handles imgTOC.Paint

		' Declare variables

		Dim i As Image = My.Resources.Tab0
		Dim p As PictureBox = sender
		Dim g As Graphics = e.Graphics

		' Get the rectangle of the picture box we'll draw into.

		Dim r As New Rectangle(0, 0, p.Width, p.Height)

		' Draw the image.

		g.DrawImage(i, r, 0, 0, i.Width, i.Height, GraphicsUnit.Pixel, ImageAttr)

	End Sub

	'**************************************************

	' Sub to redraw the ingredients display panel.

	'**************************************************
	Private Sub pnlIngredients_Paint(sender As Object, e As PaintEventArgs) Handles pnlIngredients.Paint

		' Declare variables.

		Dim ii As Integer
		Dim jj As Integer
		Dim s As Integer
		Dim x As Integer
		Dim y As Integer
		Dim w As Double
		Dim xx As String
		Dim zx As String
		Dim link As PrintZone
		Dim fN As New Font("Times New Roman", 12)
		Dim fL As New Font("Times New Roman", 12, FontStyle.Underline)
		Dim g As Graphics = e.Graphics

		' Clear out any print zones that hold links to other recipes.

		mIngredientLinks = New Collection

		' Get the current text to be displayed.  This is determined by the setting of VScroll1.

		zx = IngredientsText

		' Get the width into which we'll be writing, and initialize the vertical position.

		w = sender.Width
		y = 0
		s = g.MeasureString(" ", fN).Width

		' Begin a loop of printing lines of text.

		Do While zx <> ""

			' Initialize the horizontal position for this line, begin with the assumption that the
			' line contains no link to another recipe, and get the line of text that will fit
			' in the print width.

			x = 0
			xx = WordWrap(g, fN, zx, w)

			' See if the line contains any link text.

			If LinksTable.Rows.Count > 0 Then
				For jj = 0 To LinksTable.Rows.Count - 1
					ii = InStr(1, xx, GetR(LinksTable.Rows(jj), "LinkText"), CompareMethod.Text)

					' If we found a link, then print out the text up to the link text in black,
					' the link in blue, underlined,and the rest of the line in black.

					If ii > 0 Then
						g.DrawString(VB.Left(xx, ii - 1), fN, Brushes.Black, x, y)
						x += (g.MeasureString(VB.Left(xx, ii - 1), fN).Width)
						g.DrawString(GetR(LinksTable.Rows(jj), "LinkText"), fL, Brushes.Blue, x, y)

						' Create a new PrintZone object that will remember the location of this
						' link on the panel.

						link = New PrintZone
						link.x1 = x
						link.y1 = y
						x += (g.MeasureString(GetR(LinksTable.Rows(jj), "LinkText"), fN).Width)
						link.x2 = x

						' Finish creating the link print zone object and add it to the collection.

						link.y2 = y + g.MeasureString(GetR(LinksTable.Rows(jj), "LinkText"), fN).Height
						link.Bookmark = LinksTable.Rows(jj)("LinkedID")
						mIngredientLinks.Add(link)

						' Strip off the portion of the line already printed.

						xx = Mid(xx, ii + Len(GetR(LinksTable.Rows(jj), "LinkText")))

					End If
				Next jj

			End If

			' Print the rest of the line normally.

			g.DrawString(xx, fN, Brushes.Black, x, y)

			' Advance the vertical position by the line height.

			y += g.MeasureString("X", fN).Height

		Loop

	End Sub
	'**************************************************

	' The mouse is pressed inside the recipe display panel.

	'**************************************************

	Private Sub pnlIngredients_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlIngredients.MouseDown

		' Declare variables

		Dim pz As PrintZone
		Dim b As Cookbook
		Dim RecipesDS As New DataSet
		Dim lRec As DataTable


		' Look through any print zones containing links to other recipes and
		' see if the mouse was pressed inside one.

		If Not mIngredientLinks Is Nothing Then
			For Each pz In mIngredientLinks
				If e.X >= pz.x1 And e.X <= pz.x2 And e.Y >= pz.y1 And e.Y <= pz.y2 Then
					RecipesDA.SelectCommand.CommandText = "Select ParentID FROM tblRecipes WHERE ID=" & pz.Bookmark
					RecipesDA.Fill(RecipesDS, "Table")
					lRec = RecipesDS.Tables("Table")
					If lRec.Rows.Count > 0 AndAlso lRec.Rows(0)("ParentID") > 0 Then
						b = frmMain.gLibrary.CookBooks.Item(CStr(lRec.Rows(0)("ParentID")))
						b.OpenBook(pz.Bookmark)
					End If
					RecipesDS.Dispose()
				End If
			Next pz
		End If
	End Sub
	'**************************************************

	' Sub to redraw the Procedure panel.

	'**************************************************
	Private Sub pnlProcedure_Paint(sender As Object, e As PaintEventArgs) Handles pnlProcedure.Paint

		' Declare variables.

		Dim ii As Integer
		Dim jj As Integer
		Dim w As Integer
		Dim x As Integer
		Dim y As Integer
		Dim RecipeID As Integer
		Dim ww As String
		Dim xx As String
		Dim yy As String
		Dim zx As String
		Dim link As PrintZone = Nothing
		Dim f As Font
		Dim b As SolidBrush
		Dim fN As New Font("Times New Roman", 12)
		Dim fL As New Font("Times New Roman", 12, FontStyle.Underline)
		Dim g As Graphics = e.Graphics

		' Clear out any print zones that hold links to other recipes.

		mProcedureLinks = New Collection

		' Get the current text to be displayed.  This is determined by the setting of VScroll2.

		zx = ProcedureText

		' Look for occurrences of any link text in the procedure text, and replace them with
		' start/stop codes for the displayed link.  The resulting procedure text will look like
		' this: "some normal text <H Ref=1234>Link Text</H> some more normal text."

		If LinksTable.Rows.Count > 0 Then
			For jj = 0 To LinksTable.Rows.Count - 1
				ii = InStr(1, zx, GetR(LinksTable.Rows(jj), "LinkText"), CompareMethod.Text)
				If ii > 0 Then
					xx = "<H Ref=" & LinksTable.Rows(jj)("LinkedID") & ">" & GetR(LinksTable.Rows(jj), "LinkText") & "</H>"
					zx = SRep(zx, 1, GetR(LinksTable.Rows(jj), "LinkText"), xx, CompareMethod.Text)
				End If
			Next jj
		End If

		' Get the width into which we'll be writing, and initialize the vertical position.

		w = sender.Width
		y = 0

		' Begin with the normal font and color

		f = fN
		b = Brushes.Black

		' Begin a loop of printing lines of text.

		Do While zx <> "" And y + 20 < pnlProcedure.Height

			' Initialize the horizontal position for this line, and get the first/next
			' line from the procedure text.

			x = 0
			xx = WordWrapEx(g, fN, zx, w)

			' Begin printing the current line.

			Do While xx <> ""

				' Look for link start code.  It must precede any stop code or we ignore it, as it
				' could be the beginning of another link past the current one.

				If (xx.Contains("<H") And Not xx.Contains("</H>")) Or (xx.IndexOf("</H>") > xx.IndexOf("<H") And xx.Contains("<H")) Then
					ii = xx.IndexOf("<H")

					' Get the portion of the line up to the start code.

					If ii > 0 Then ww = xx.Substring(0, ii) Else ww = xx

					' If the portion we are going to print contains a line stop code, strip
					' out the stop code.

					ii = xx.IndexOf("</H")
					If ii >= 1 Then xx = xx.Substring(ii)

					' If we found a link start code, then print the line up to the code in a normal font and color.

					g.DrawString(ww, f, b, x, y)

					' Advance the x coordinate to the point where the normal text ended.

					x += g.MeasureString(ww, fN).Width

					' Now extract the recipe ID, if present.  Strip the rest of the start code
					' from the line.

					ii = xx.IndexOf("Ref=")
					If ii >= 0 Then
						RecipeID = Val(xx.Substring(ii + 4))
						ii = xx.IndexOf(">")
						If ii < xx.Length - 1 Then xx = xx.Substring(ii + 1) Else xx = ""
					Else
						ii = InStr(1, xx, ">")
						If ii = 0 Then xx = ""
					End If

					' Start a PrintZone object.

					link = New PrintZone
					link.x1 = x
					link.y1 = y
					link.y2 = y + g.MeasureString("X", fN).Height
					link.Bookmark = RecipeID

					' Now set the font to the underline font and the color to blue.

					f = fL
					b = Brushes.Blue

					' Look for a link stop code.

				ElseIf xx.Contains("</H>") Then

					' Print the link text with the underline font, in blue.

					ii = xx.IndexOf("</H>")
					yy = xx.Substring(0, ii)
					g.DrawString(yy, f, b, x, y)

					' Advance the x position to the end of the link text.

					x += g.MeasureString(yy, f).Width

					' Complete any incomplete PrintZone item and add it to the collection,
					' and set the  PrintZone object to nothing, so we know we don't
					' have an incomplete one started.

					If Not link Is Nothing Then
						link.x2 = x + g.MeasureString(yy, f).Width
						mProcedureLinks.Add(link)
						link = Nothing

						' If we have no existing PrintZone item (the link may have spanned two lines),
						' create a  new one that starts at the beginning of the line and ends
						' where the link stop code is.  Add it to the collection, then set it
						' to nothing so we know we don't have an incomplete one started.

					Else
						link = New PrintZone
						link.x1 = 0
						link.x2 = x
						link.y1 = y
						link.y2 = y + g.MeasureString("X", fN).Height
						link.Bookmark = RecipeID
						mProcedureLinks.Add(link)
						link = Nothing
					End If

					' Strip off the portion of the line to the end of the link stop code.

					xx = xx.Substring(ii + 4) ' Remove </H>
					If xx = "" And w > x Then xx = WordWrap(g, fN, zx, w - x) ' Get enough more text to finish the line.

					' Return to the normal font and color.

					f = fN
					b = Brushes.Black

					' If there is no link start or stop code left in the line, just print the line normally.
				Else
					g.DrawString(xx, f, b, x, y)

					' If there is an unfinished PrintZone, complete it and add it to the collection, then
					' set it to nothing, so we know we don't have an unfinished one.

					If Not link Is Nothing Then
						link.x2 = x + g.MeasureString(xx, fN).Width
						mProcedureLinks.Add(link)
						link = Nothing
					End If

					' Clear out the rest of the string that we've printed.

					xx = ""
				End If
			Loop

			' Advance the vertical position by the line height.

			y += g.MeasureString("X", fN).Height

		Loop

	End Sub
	'**************************************************

	' The mouse is pressed inside the procedure text panel.

	'**************************************************

	Private Sub pnlProcedure_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlProcedure.MouseDown

		' Declare variables

		Dim pz As PrintZone
		Dim b As Cookbook
		Dim RecipesDS As New DataSet
		Dim lRec As DataTable

		' Look through any print zones containing links to other recipes and
		' see if the mouse was pressed inside one.

		If Not mProcedureLinks Is Nothing Then
			For Each pz In mProcedureLinks
				If e.X >= pz.x1 And e.X <= pz.x2 And e.Y >= pz.y1 And e.Y <= pz.y2 Then
					b = New Cookbook
					RecipesDA.SelectCommand.CommandText = "Select ParentID FROM tblRecipes WHERE ID=" & pz.Bookmark
					RecipesDA.Fill(RecipesDS, "Table")
					lRec = RecipesDS.Tables("Table")
					If lRec.Rows.Count > 0 AndAlso lRec.Rows(0)("ParentID") > 0 Then
						b = frmMain.gLibrary.CookBooks.Item(CStr(lRec.Rows(0)("ParentID")))
						b.OpenBook(pz.Bookmark)
					End If
					RecipesDS.Dispose()
				End If
			Next pz
		End If
	End Sub
	'**************************************************

	' The tab picture boxes are repainted.

	'**************************************************
	Private Sub picTabs_Paint(sender As Object, e As PaintEventArgs) Handles imgLeftTabs.Paint, imgRightTabs.Paint

		' Declare variables

		Dim g As Graphics = e.Graphics

		' Get the rectangle of the picture box we'll draw into.

		Dim r As New Rectangle(0, 0, sender.Width, sender.Height)

		' Draw the image.

		If sender Is imgLeftTabs Then
			g.DrawImage(LeftTabImage, r, 0, 0, LeftTabImage.Width, LeftTabImage.Height, GraphicsUnit.Pixel, ImageAttr)
		Else
			g.DrawImage(RightTabImage, r, 0, 0, RightTabImage.Width, RightTabImage.Height, GraphicsUnit.Pixel, ImageAttr)
		End If
	End Sub
	'**************************************************

	' The View Recipe menu option is clicked.

	'**************************************************
	Private Sub mnuPViewRecipe_Click(sender As Object, e As EventArgs) Handles mnuPViewRecipe.Click, mnuViewRecipe.Click

		Dim f As New frmViewRecipe

		f.Show(toc(CurrentRecipeRow), toc.RecipesTable)
	End Sub
	'**************************************************

	' The edit menu has just opened.

	'**************************************************
	Private Sub EditMenu_DropDownOpening(sender As Object, e As EventArgs) Handles EditMenu.DropDownOpening

		' Disable clipboard-dependent features until we see if there is any
		' valid content in it.

		mnuPasteRecipe.Enabled = False
		mnuPasteImage.Enabled = False

		' Check for a recipe in the clipboard.

		If Clipboard.ContainsText() Then
			Dim clipText As String = Clipboard.GetText()
			mnuPasteRecipe.Enabled = clipText.ToLower.Contains("<recipe>")
		End If

		' Check for an image in the clipboard.

		If My.Computer.Clipboard.ContainsImage Then mnuPasteImage.Enabled = True

	End Sub
	'**************************************************

	' One of the export menus was selected.

	'**************************************************
	Private Sub mnuExportHTML1_Click(sender As Object, e As EventArgs) Handles mnuExportHTML1.Click, mnuExportHTML2.Click, mnuExportRTF1.Click, mnuExportRTF2.Click, mnuExchange.Click

		' Declare variables

		Dim zx As String = ""
		Dim FileName As String

		' See which format is selected.

		If sender Is mnuExportHTML1 Then
			zx = FormatHTML(toc(CurrentRecipeRow))
			frmMain.SaveFileDialog1.Filter = "HTML Files (*.html; *.htm)|*.html;*.htm"
		ElseIf sender Is mnuExportHTML2 Then
			zx = FormatHTMLMobile(toc(CurrentRecipeRow))
			frmMain.SaveFileDialog1.Filter = "HTML Files (*.html; *.htm)|*.html;*.htm"
		ElseIf sender Is mnuExportRTF1 Then
			zx = FormatRTF(toc(CurrentRecipeRow))
			frmMain.SaveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"
		ElseIf sender Is mnuExportRTF2 Then
			zx = FormatRTFMobile(toc(CurrentRecipeRow))
			frmMain.SaveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"
		Else
			zx = FormatExchange(toc(CurrentRecipeRow))
			frmMain.SaveFileDialog1.Filter = "XML Files (*.xml)|*.xml"
		End If

		' Get the save file name.

		frmMain.SaveFileDialog1.Title = "Export Recipe To File"
		frmMain.SaveFileDialog1.OverwritePrompt = True
		frmMain.SaveFileDialog1.InitialDirectory = "%USERPROFILE%\Desktop"
		frmMain.SaveFileDialog1.FileName = toc(CurrentRecipeRow)("RecipeName")
		If frmMain.SaveFileDialog1.ShowDialog = DialogResult.OK Then
			FileName = frmMain.SaveFileDialog1.FileName
			Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
			System.IO.File.WriteAllText(FileName, zx, utf8WithoutBom)
		End If

	End Sub
	'**************************************************
	'
	' Sub to fill the entry fields with the contents
	' of the current recipe.
	'
	'**************************************************
	Private Sub FillFields()

		' Declare variables

		Dim dr As DataRow

		' Set/Reset the autocomplete collection for categories.

		txtCategory.AutoCompleteMode = AutoCompleteMode.Append
		txtCategory.AutoCompleteCustomSource = toc.CategoryList
		txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource

		' Get the record from the table of contents information.

		dr = toc(CurrentRecipeRow)
		If dr IsNot Nothing Then


			' Put the information from the recipe into the entry fields.

			DontProcessEvent = True ' Prevents TextChanged routines from working yet.
			txtTitle.Text = GetR(dr, "RecipeName")
			txtCategory.Text = GetR(dr, "Category")
			txtAuthor.Text = GetR(dr, "Author")
			txtBlurb.Text = GetR(dr, "Blurb")
			txtServings.Text = GetR(dr, "Servings")
			txtIngredients.Text = FormatIngredients(dr("ID"))
			txtProcedure.Text = GetR(dr, "Procedure")
			txtNotes.Text = GetR(dr, "Notes")
			DontProcessEvent = False

			' Clear the flag that indicates if the ingredients have changed.

			IngredientsChanged = False
		End If

	End Sub
	'****************************************************
	'
	' Sub to edit the current recipe.
	'
	'****************************************************
	Public Sub EditRecipe()

		' Make link menu visible

		LinkToolStripMenuItem.Visible = True

		' Fill the entry fields with current values

		FillFields()

		' Make the entry area "containers" visible

		DisplayMode(1)

		' Enable the Save menu item

		mnuSaveRecipe.Enabled = True

		' Set the edit mode

		rMode = MODIFYRECORD

	End Sub
	'****************************************************
	'
	' Method to show the the table of contents collections
	'
	'****************************************************
	Public Sub ShowTOC()

		' Declare variables

		Dim ii As Integer
		Dim lBM As Bookmark

		' Calculate the boundaries of the left and right pages

		mPage1Left = pnlContents.ClientRectangle.Width * 0.06
		mPage1Right = pnlContents.ClientRectangle.Width * 0.42
		mPage2Left = pnlContents.ClientRectangle.Width * 0.55
		mPage2Right = pnlContents.ClientRectangle.Width * 0.9
		mBottomMargin = pnlContents.ClientRectangle.Height * 0.9

		' Set the flag to prevent the TOC panel from painting yet.

		DontProcessEvent = True

		' Make the table of contents panes visible

		DisplayMode(0)

		' Select the TOC tab

		SelectTab(0)

		' Create a new collection of bookmarks.

		mBookmarks = Nothing
		mBookmarks = New Collection

		' Initialize the locations for the left and right pages

		mPage1Y = 0
		mPage2Y = 0

		' Begin printing the table of contents on the left hand page, pane 1

		mPaneNo = 1
		mPageNo = 1

		' Reset the current row to "BOF".

		CurrentRecipeRow = -1

		' Create the first bookmark for the table of contents.  Subsequent bookmarks will
		' be created when the user clicks the "Next page" button.

		mPageNo = 1
		If toc.Count > 0 Then
			ii = 0
			lBM = New Bookmark
			lBM.DisplayPageNo = mPageNo
			lBM.FirstRecord = ii
			mBookmarks.Add(lBM, CStr(lBM.DisplayPageNo))
		End If


		' Disable the menu options.

		EnableMenus(False)

		' Disable the Save menu item.

		mnuSaveRecipe.Enabled = False

		' Disable the copy recipe menu item

		mnuCopyRecipe.Enabled = False
		mnuCopyExchange.Enabled = False

		' Allow events to process again.

		DontProcessEvent = False

		' Redraw the table of contents.

		pnlContents.Invalidate()

	End Sub

	'****************************************************

	' Sub to print the page title on the
	' left-hand pane.

	'****************************************************
	Private Sub PrintPageTitle(p1 As Integer, g As Graphics)

		' Declare variables

		Dim x As Integer
		Dim zx0 As String
		Dim f As New Font("Arial", 10, FontStyle.Bold)
		Dim b As New SolidBrush(Color.Black)

		' Draw the page title on the left pane

		zx0 = "Table Of Contents"
		If mPageNo > 1 Then zx0 = zx0 & " (con't)"
		x = mPage1Left + (mPage1Right - mPage1Left - g.MeasureString(zx0, f).Width) / 2
		mLineHeight = g.MeasureString("X", f).Height
		g.DrawString(zx0, f, b, x, 25)
		mPage1Y = 25 + 1.5 * mLineHeight
		mPage2Y = mPage1Y ' The right hand pane begins on same y coordinate as left hand pane

		' Delete objects we created

		f.Dispose()
		b.Dispose()


	End Sub

	'****************************************************

	' Sub to print the category on the page when
	' a new category is encountered in the file.

	'****************************************************
	Private Function PrintCategory(p As Integer, g As Graphics) As Boolean

		' Declare variables

		Dim x As Integer
		Dim y As Integer
		Dim zx As String = toc(CurrentRecipeRow)("Category")
		Dim f As New Font("Arial", 10, FontStyle.Bold)
		Dim b As New SolidBrush(Color.Black)

		'Check which pane we are drawing on, and draw the category name

		If p = 1 Then
			y = mPage1Y
			If mPage1Y + 3 * mLineHeight < mBottomMargin Then
				x = mPage1Left + (mPage1Right - mPage1Left - g.MeasureString(zx, f).Width) / 2
				g.DrawString(zx, f, b, x, y)
				y = y + 1.5 * mLineHeight
				mPage1Y = y
				Return False
			Else
				Return True
			End If
		Else
			y = mPage2Y
			If mPage2Y + 3 * mLineHeight < mBottomMargin Then
				x = mPage2Left + (mPage2Right - mPage2Left - g.MeasureString(zx, f).Width) / 2
				g.DrawString(zx, f, b, x, y)
				y = y + 1.5 * mLineHeight
				mPage2Y = y
				Return False
			Else
				Return True
			End If
		End If

		' Destroy objects we've created

		f.Dispose()
		b.Dispose()

	End Function

	'****************************************************

	' Sub to print the name of the recipe.

	'****************************************************
	Private Function PrintRecipeName(p1 As Integer, g As Graphics) As Boolean

		' Declare variables

		Dim PageOverflow As Boolean
		Dim y As Integer
		Dim xx As Integer
		Dim x As Double
		Dim w As Double
		Dim zx0 As String
		Dim zx1 As String
		Dim lZ As New PrintZone
		Dim fN As New Font("Arial", 8)
		Dim fI As New Font("Arial", 8, FontStyle.Italic)
		Dim b As New SolidBrush(Color.Black)

		' Record the upper left coordinates of the name in
		' a print zone.

		If p1 = 1 Then ' On first, or left-hand "page"
			lZ.x1 = mPage1Left
			lZ.x2 = mPage1Right
		Else
			lZ.x1 = mPage2Left
			lZ.x2 = mPage2Right
		End If

		If p1 = 1 Then lZ.y1 = mPage1Y Else lZ.y1 = mPage2Y
		lZ.Bookmark = CurrentRecipeRow

		' Print the text of the recipe name. Only the actual name will be selectable.

		PageOverflow = CheckForPaneChg(p1)
		If Not PageOverflow Then
			zx0 = toc(CurrentRecipeRow)("RecipeName")
			If p1 = 1 Then w = mPage1Right - mPage1Left Else w = mPage2Right - mPage2Left
			y = lZ.y1
			zx1 = WordWrap(g, fN, zx0, w)
			g.DrawString(zx1, fN, b, lZ.x1, y)
			x = lZ.x1 + g.MeasureString(zx1, fN).Width ' Calculate where to print author.

			' If there is an author name, print it after the
			' RecipeName.

			w -= (g.MeasureString(zx1, fN).Width + 20) ' Calculate room left on the line past the title, leaving a little room
			If GetR(toc(CurrentRecipeRow), "Author") <> "" Then
				zx0 = WordWrap(g, fN, "  " & GetR(toc(CurrentRecipeRow), "Author"), w)
				g.DrawString(zx0, fI, b, x, y)
				x += g.MeasureString(zx0, fI).Width
			End If

			' Print a trailer of periods and the "page" number if we
			' have no more of the name to print.

			zx1 = CStr(CurrentRecipeRow + 1)
			If p1 = 1 Then
				xx = mPage1Right - g.MeasureString(zx1, fN).Width
			Else
				xx = mPage2Right - g.MeasureString(zx1, fN).Width
			End If
			w = g.MeasureString(".", fN).Width
			While x < xx
				g.DrawString(".", fN, b, x, y)
				x = x + w
			End While
			g.DrawString(zx1, fN, b, xx, y)
			lZ.x2 = xx
			y = y + mLineHeight
		End If

		' Save the bottom right point of the rectangle and add it to the zones collection.

		lZ.y2 = y ' Saved bottom right corner of title
		mZones.Add(lZ)

		' Save the current Y position

		If p1 = 1 Then mPage1Y = y Else mPage2Y = y

		' Delete objects we've created

		fN.Dispose()
		fI.Dispose()
		b.Dispose()

		' Return the PageOverflow condition

		Return PageOverflow
	End Function

	'****************************************************

	' Sub to check for a "change of pages" in the table of contents

	'****************************************************
	Private Function CheckForPaneChg(p As Integer) As Boolean

		If p = 1 Then
			If mPage1Y + mLineHeight > mBottomMargin Then
				Return True
			Else
				Return False
			End If
		Else
			If mPage2Y + mLineHeight > mBottomMargin Then
				Return True
			Else
				Return False
			End If
		End If

	End Function

	'****************************************************
	'
	' Sub to enable the entry panes for the cookbook
	' Input:  Mode = The Display Mode where:
	'                 0 = Table of Contents
	'                 1 = Add Recipe
	'                 2 = Existing Recipes
	'
	'****************************************************
	Private Sub DisplayMode(ByVal Mode As Integer)

		' Save the display mode

		mDisplayMode = Mode

		' Make the specified "pane" visible others
		' invisible.  When all panels are invisible, only the table of contents
		' panel, PanelMain, is visible.

		Select Case Mode
			Case 0 ' The Table of Contents is displayed
				pnlDisplayRecipe.Visible = False
				pnlEditRecipe.Visible = False
				pnlContents.ContextMenuStrip = ContextMenuStrip1

			Case 1 ' Edit recipe
				pnlDisplayRecipe.Visible = False
				pnlEditRecipe.Visible = True
				txtTitle.Focus()
				pnlContents.ContextMenuStrip = Nothing

			Case 2  ' Display recipe
				pnlDisplayRecipe.Visible = True
				pnlEditRecipe.Visible = False
				pnlContents.ContextMenuStrip = Nothing

		End Select

	End Sub

	'****************************************************
	'
	' Sub to display the recipes section of the cookbook.
	'
	'****************************************************
	Public Sub ShowRecipes(Optional ByRef Direction As Integer = 0, Optional ByRef StartLetter As String = "", Optional ByRef Bookmark As Integer = -1, Optional ID As Integer = 0)

		' Declare variables

		Dim xx As Integer
		Dim zz As String
		Dim zx0 As String
		Dim zx1 As String

		' Make the recipes panes visible

		DisplayMode(2)

		' If a start letter is specified, which refers to the
		' first category that begins with that letter,move to that
		' place in the dataset
		Debug.Print("Show Recipes start: " & CurrentRecipeRow)
		If StartLetter <> "" Then
			xx = toc.FindCategory(StartLetter)
			If xx <> NOMATCH Then
				CurrentRecipeRow = xx
				zz = toc(CurrentRecipeRow)("Category").ToUpper.Chars(0)
				zx0 = toc(CurrentRecipeRow)("Category") ' Get current category
				If ((zz = "U" Or zz = "V" Or zz = "W") And StartLetter = "U") Or ((zz = "X" Or zz = "Y" Or zz = "Z") And StartLetter = "X") Or zz = StartLetter Then
					ShowRecipe(zx0)
				Else
					ClearRecipe(StartLetter)
				End If
			Else
				ClearRecipe(StartLetter)
			End If

			' If a bookmark (which is a row number in the table of contents entries)
			' is specified, display that record.

		ElseIf Bookmark >= 0 Then
			zx0 = "" ' clear current category
			CurrentRecipeRow = Bookmark
			ShowRecipe(zx0)


			' If a record id is specified, get the first row
			' number for that record.

		ElseIf ID > 0 Then
			For xx = 0 To toc.Count - 1
				If toc(xx)("ID") = ID Then
					CurrentRecipeRow = xx
					ShowRecipe("")
					Exit For
				End If
			Next xx

			' If no start letter is specified, then move to
			' the beginning, previous or next recipe depending
			' upon the direction specified.

		ElseIf toc.Count > 0 Then

			' If we are moving from a valid row, then remember its category.
			' Otherwise, clear the category.

			If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then
				zx0 = toc(CurrentRecipeRow)("Category")
			Else
				zx0 = "" ' Watch current category
			End If

			' Determine what direction we are to move.

			Select Case Direction
				Case Beginning
					CurrentRecipeRow = 0
				Case PreviousCategory
					If CurrentRecipeRow >= 0 Then
						zx0 = toc(CurrentRecipeRow)("Category")
						Do While CurrentRecipeRow >= 0 AndAlso toc(CurrentRecipeRow)("Category") = zx0
							CurrentRecipeRow -= 1
							If CurrentRecipeRow < 0 Then
								ShowTOC()
								Exit Sub
							End If
						Loop
						If CurrentRecipeRow >= 0 Then
							zx1 = toc(0)("Category")
							If zx0.Substring(0, 1) <> zx1.Substring(0, 1) Then SelectTab(zx1.Substring(0, 1))
						End If
					End If
				Case PreviousRecipe
					If CurrentRecipeRow >= 0 Then
						zx0 = toc(CurrentRecipeRow)("Category")
						CurrentRecipeRow -= 1
						If CurrentRecipeRow < 0 Then
							ShowTOC()
							Exit Sub
						Else
							zx1 = toc(CurrentRecipeRow)("Category")
							If zx0.Substring(0, 1) <> zx1.Substring(0, 1) Then SelectTab(zx1.Substring(0, 1))
						End If
					End If
				Case NextCategory
					If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then
						zx0 = toc(CurrentRecipeRow)("Category")
						Do While CurrentRecipeRow < toc.Count AndAlso toc(CurrentRecipeRow)("Category") = zx0
							CurrentRecipeRow += 1
						Loop
						If CurrentRecipeRow < toc.Count Then
							zx1 = toc(CurrentRecipeRow)("Category")
							If zx0.Substring(0, 1) <> zx1.Substring(0, 1) Then SelectTab(zx1.Substring(0, 1))
						End If
					End If
				Case NextRecipe
					If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then
						zx0 = toc(CurrentRecipeRow)("Category")
						CurrentRecipeRow += 1
					End If
					If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then
						zx1 = toc(CurrentRecipeRow)("Category")
						If zx0.Substring(0, 1) <> zx1.Substring(0, 1) Then SelectTab(zx1.Substring(0, 1))
					End If
					If CurrentRecipeRow >= toc.Count Then ShowTOC()
			End Select

			' Stuff the entry fields with the recipe

			If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then ShowRecipe(toc(CurrentRecipeRow)("Category"))
		End If
		Debug.Print("Show Recipes end: " & CurrentRecipeRow)

		' Show this form.

		Me.Show()



	End Sub

	'****************************************************

	' Sub to display a recipe's information

	'****************************************************
	Private Sub ShowRecipe(Optional ByVal Category As String = "")

		' Declare variables

		Dim xx As Integer
		Dim ImageData() As Byte
		Dim ms As MemoryStream

		Debug.Print("Show Recipe: " & CurrentRecipeRow)
		' If we received one of the direction specifiers, move as specified.

		If Category = CStr(Beginning) And toc.Count > 0 Then CurrentRecipeRow = 0
		If Category = CStr(NextRecipe) And CurrentRecipeRow < toc.Count - 1 Then CurrentRecipeRow += 1

		' Make sure we have a valid row number.

		If CurrentRecipeRow >= 0 And CurrentRecipeRow < toc.Count Then

			' Fill the display fields with the recipe.

			lblTitle.Text = toc(CurrentRecipeRow)("RecipeName")
			lblCategory.Text = Capitalize(toc(CurrentRecipeRow)("Category"))
			lblBlurb.Text = GetR(toc(CurrentRecipeRow), "Blurb")
			lblAuthor.Text = GetR(toc(CurrentRecipeRow), "Author")
			lblServings.Text = toc(CurrentRecipeRow)("Servings")

			' If the recipe has an attached image, resize the blurb box to show
			' the picture box, and fill it with the image.  Otherwise, clear the picture box
			' and make the blurb box the same size as the others.

			xx = Find2(ImagesTable, "ParentID=" & toc(CurrentRecipeRow)("ID"))
			If xx <> NOMATCH Then

				' Narrow the blurb to reveal the picture box beneath.

				lblBlurb.Width = 227
				PictureBox1.Visible = True

				' Convert the data for the current page to an image.
				' The images are stored in module-level variables, and will
				' be displayed by the Paint event for the picture box controls.

				ImageData = ImagesTable.Rows(xx)("DocumentImage")
				ms = New MemoryStream(ImageData)
				PictureBox1.Image = Image.FromStream(ms)

				' Disable the Add Image menu option (we can have only one per recipe),
				' and enable the Delete Image menu option.

				mnuAddImage.Enabled = False
				mnuDeleteImage.Enabled = True

			Else
				mnuAddImage.Enabled = True
				mnuDeleteImage.Enabled = False
				lblBlurb.Width = lblAuthor.Width
				PictureBox1.Visible = False
			End If

			' Save the ingredients and procedure text in variables from which they will
			' be printed.  These cannot be just dumped into a display field, since they
			' require special handling to print contained links.

			IngredientsText = FormatIngredients(toc(CurrentRecipeRow)("ID"))
			ProcedureText = GetR(toc(CurrentRecipeRow), "Procedure")
			If GetR(toc(CurrentRecipeRow), "Notes") <> "" Then ProcedureText &= vbCrLf & vbCrLf & "Notes: " & GetR(toc(CurrentRecipeRow), "Notes")

			' If the current category has moved to a new starting letter,
			' update the alphabetic tabs

			If Category = "" OrElse Category.Substring(0, 1).ToLower <> GetR(toc(CurrentRecipeRow), "Category").substring(0, 1).tolower Then
				SelectTab(GetR(toc(CurrentRecipeRow), "Category").substring(0, 1))
			End If

			' Enable the Edit, Print and Delete menu items.

			EnableMenus(True)

			' Enable the copy recipe menu item

			mnuCopyRecipe.Enabled = True
			mnuCopyExchange.Enabled = True

			' Cause the procedure text panel to be displayed.

			pnlIngredients.Invalidate()
			pnlProcedure.Invalidate()

		End If

	End Sub

	'**********************************************************

	' Function to return the longest string which will print
	' in the specified width, and trim that portion off the
	' supplied string.

	' This is a special version of the library WordWrap function,
	' in that it returns hyperlinks, but doesn't include their
	' length in the length of the returned text, as they won't be printed.
	'**********************************************************
	Public Function WordWrapEx(g As Graphics, F As Font, ByRef Text As String, wd As Integer) As String

		' Declare variables

		Dim jj As Integer
		Dim wWord As Integer
		Dim wText As Integer
		Dim wLink As Integer
		Dim xx As String
		Dim zx As String

		' Replace any CrLf characters with just Lf

		Text = Text.Replace(vbCrLf, vbLf)

		' Begin accumulating the return text, word by word, until we would
		' exceed the width of the space.

		zx = ""
		wText = 0
		Do
			xx = GetNextWordEx(Text) ' Get next word in text.

			' If the word is a hyperlink, don't add its length to the length of the returned line.

			If xx.StartsWith("<") And xx.EndsWith(">") Then
				wWord = 0
				wLink = g.MeasureString(xx, F).Width
			Else
				wWord = g.MeasureString(xx, F).Width
				wLink = 0
			End If

			' Adding the word would make the text too long.

			If wText + wWord > wd Then
				If wText > 0 Then ' Boundary test, in case final word is still too long.
					Return zx.TrimStart ' width okay, return it.
				Else
					' In case the remaining text contains a single, too-long word, break it wherever
					' we need to to fit.

					For jj = xx.Length - 1 To 0 Step -1
						If g.MeasureString(xx.Substring(0, jj), F).Width <= wd Then
							If jj < Text.Length - 1 Then Text = Text.Substring(jj + 1) Else Text = ""
							Return xx.Substring(0, jj + 1)
						End If
					Next jj
				End If

				' Accumulate the word and remeasure the text.
			Else
				If xx.Length <= Text.Length Then Text = Text.Substring(xx.Length) Else Text = ""
				zx &= xx
				wText = g.MeasureString(zx, F).Width - wLink

				' If the word ends with vbLf, return it.
				If zx.EndsWith(vbLf) Then Return zx.TrimStart
			End If
		Loop While Text <> ""

		Return zx
	End Function

	'**********************************************************

	' Function to parse a line of text and return the next word
	' followed by any of a list of characters that make good
	' breakpoints in wrapped text.

	' This is a special version of the library GetNextWord
	' function, which doesn't add the width of hypertext to
	' the width of the returned line.

	'**********************************************************)
	Private Function GetNextWordEx(Text As String) As String

		' Declare variables.

		Dim ii As Integer
		Dim jj As Integer
		Dim BreakChars As String = " ,:;.\/-_" & vbLf

		' Loop through the supplied text looking for a breaking
		' character, and return the text up to and including
		' that character.

		For jj = 0 To Text.Length - 1
			If BreakChars.Contains(Text.Chars(jj)) Then
				Return Text.Substring(0, jj + 1)
			Else
				If Text.Chars(jj) = "<" And jj < Text.Length - 1 AndAlso Text.Chars(jj + 1) <> "<<" Then
					If jj > 0 Then
						Return Text.Substring(0, jj)
					Else
						ii = Text.IndexOf(">", jj + 1)
						If ii - jj + 1 <= Text.Length Then Return Text.Substring(0, ii + 1) Else Return Text
					End If
				End If
			End If
		Next jj
		Return Text

	End Function
	'****************************************************

	' Sub to clear a recipe's data

	'****************************************************
	Private Sub ClearRecipe(ByVal StartLetter As String)

		lblTitle.Text = ""
		lblAuthor.Text = ""
		lblCategory.Text = ""
		lblBlurb.Text = ""
		IngredientsText = ""
		ProcedureText = ""
		pnlIngredients.Invalidate()
		pnlProcedure.Invalidate()

		' If the current category has moved to a new starting letter,
		' update the alphabetic tabs

		If StartLetter <> "" Then SelectTab(StartLetter)

		' Disable the Edit, Save, Print and Delete buttons

		EnableMenus(False)

		' Disable the copy recipe menu item

		mnuCopyRecipe.Enabled = False
		mnuCopyExchange.Enabled = False

	End Sub



	'**************************************************
	'
	' Sub to clear the entry fields for a recipe
	'
	'**************************************************
	Private Sub ClearFields()

		' Clear all fields.

		txtTitle.Text = ""
		txtCategory.Text = ""
		txtAuthor.Text = ""
		txtBlurb.Text = ""
		txtServings.Text = ""
		txtIngredients.Text = ""
		txtProcedure.Text = ""

		' Set/Reset the autocomplete collection for categories.

		txtCategory.AutoCompleteMode = AutoCompleteMode.Append
		txtCategory.AutoCompleteCustomSource = toc.CategoryList
		txtCategory.AutoCompleteSource = AutoCompleteSource.CustomSource

	End Sub

	'****************************************************
	'
	' Sub to enable or disable menu options for a current
	' recipe.
	'
	'****************************************************
	Private Sub EnableMenus(ByRef State As Boolean)

		mnuViewRecipe.Enabled = State
		mnuEditRecipe.Enabled = State
		mnuPrintRecipe.Enabled = State
		mnuEmailRecipe.Enabled = State
		mnuMoveRecipe.Enabled = State
		mnuRemoveRecipe.Enabled = State
		mnuExport.Enabled = State
	End Sub

	'**************************************************************
	'
	' Sub to select a tab, 0 for table of contents, or
	' 1-24 for the letter tabs.  The letter itself may also
	' be used.
	'
	'**************************************************************
	Private Sub SelectTab(ByRef TabNo As Object)

		' Declare variables

		Dim Index As Integer
		Dim zx0 As String

		If TypeOf (TabNo) Is String Then
			zx0 = VB.Left(LCase(TabNo), 1)
			If zx0 >= "a" And zx0 <= "t" Then
				Index = InStr("abcdefghijklmnopqrst", zx0, CompareMethod.Binary)
			ElseIf zx0 >= "u" And zx0 <= "w" Then
				Index = 21
			Else
				Index = 22
			End If
		Else
			Index = TabNo
		End If

		' See which tab is selected.

		' If the table of contents tab is selected, move all
		' alphabetic tabs to the right side of the "book"

		If Index = 0 Then ' The Table of Contents tab
			LeftTabImage = My.Resources.TabBlank
			RightTabImage = My.Resources.TOC ' This is all the tabs, a-z
		Else
			LeftTabImage = Choose(Index, My.Resources.TabA_L, My.Resources.TabB_L, My.Resources.TabC_L, My.Resources.TabD_L, My.Resources.TabE_L, My.Resources.TabF_L, My.Resources.TabG_L, My.Resources.TabH_L, My.Resources.TabI_L, My.Resources.TabJ_L, My.Resources.TabK_L, My.Resources.TabL_L, My.Resources.TabM_L, My.Resources.TabN_L, My.Resources.TabO_L, My.Resources.TabP_L, My.Resources.TabQ_L, My.Resources.TabR_L, My.Resources.TabS_L, My.Resources.TabT_L, My.Resources.TabUVW_L, My.Resources.TabXYZ_L)
			RightTabImage = Choose(Index, My.Resources.TabA_R, My.Resources.TabB_R, My.Resources.TabC_R, My.Resources.TabD_R, My.Resources.TabE_R, My.Resources.TabF_R, My.Resources.TabG_R, My.Resources.TabH_R, My.Resources.TabI_R, My.Resources.TabJ_R, My.Resources.TabK_R, My.Resources.TabL_R, My.Resources.TabM_R, My.Resources.TabN_R, My.Resources.TabO_R, My.Resources.TabP_R, My.Resources.TabQ_R, My.Resources.TabR_R, My.Resources.TabS_R, My.Resources.TabT_R, My.Resources.TabUVW_R, My.Resources.TabBlank)
			imgLeftTabs.Invalidate()
			imgRightTabs.Invalidate()
		End If

	End Sub

	'**************************************************
	'
	' Sub to prepare for a new recipe
	'
	'**************************************************
	Public Sub NewRecipe()

		' Invalidate the current recipe row number.

		CurrentRecipeRow = -1

		' Make the entry area "containers" visible

		DisplayMode(1)

		' Set the edit mode

		rMode = ADDRECORD

		' Make link menu visible

		LinkToolStripMenuItem.Visible = True

		' Show this form

		Me.Show()

		' Clear the entry fields.

		ClearFields()

	End Sub

	'**************************************************
	'
	' Sub to remove the current recipe
	'
	'**************************************************
	Private Sub RemoveRecipe()

		' Declare variables

		Dim Transaction As SqlTransaction
		Dim Command As SqlCommand

		' Make sure the user wants to do this.

		If MsgBox("Are you sure you want to remove this recipe?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Remove Recipe from Book") = MsgBoxResult.Yes Then

			' Begin a transaction

			Transaction = DB.BeginTransaction
			RecipesDA.UpdateCommand.Transaction = Transaction
			RecipesDA.SelectCommand.Transaction = Transaction
			RecipesDA.DeleteCommand.Transaction = Transaction
			IngredientsDeleteCommand.Transaction = Transaction

			' Remove the recipe

			Try

				' Delete the ingredients.

				Command = New SqlCommand("DELETE FROM tblIngredients WHERE ParentID=" & toc(CurrentRecipeRow)("ID"), DB)
				Command.Transaction = Transaction
				Command.ExecuteNonQuery()

				' Delete any links that reference this recipe.

				Command = New SqlCommand("DELETE FROM tblLinks WHERE LinkedID=" & toc(CurrentRecipeRow)("ID"), DB)
				Command.Transaction = Transaction
				Command.ExecuteNonQuery()

				' Delete this recipe.

				Command = New SqlCommand("DELETE FROM tblRecipes WHERE ID=" & toc(CurrentRecipeRow)("ID"), DB)
				Command.Transaction = Transaction
				Command.ExecuteNonQuery()

				CurrentRecipeRow = -1 ' We no longer have a valid row.

				' Commit the transaction

				Transaction.Commit()

				' Rebuild the dataset

				toc.Refresh()

				' Redisplay the table of contents.

				mBookmarks = Nothing ' Destroy bookmarks so they will be recreated
				ShowTOC()

				' Flag that the database has changed

				DatabaseChanged = True
			Catch ex As Exception
				MsgBox("Remove recipe failed." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Remove Recipe")
				Transaction.Rollback()
			End Try

		End If

		' Rebuild the favorites and recent menus.

		FillRecentMenu(False)
		FillFavoritesMenu(False)
		FillRecentMenu(True)
		FillFavoritesMenu(True)

	End Sub

	'**************************************************
	'
	' Sub to display the Recipe Card printer for the
	' current recipe.
	'
	'**************************************************
	Private Sub PrintRecipe()

		' Declare variables

		Dim DA As New SqlDataAdapter
		Dim DS As New DataSet
		Dim DT As DataTable

		' Display the recipe card printer

		Dim f As New frmRecipeCard
		f.Recipe = toc(CurrentRecipeRow)
		f.ShowDialog()

		' Retrieve the saved (and possibly changed) values for card size
		' and refresh those in the current record.

		DA.SelectCommand = New SqlCommand("SELECT CardHeight,CardWidth FROM tblRecipes WHERE ID=" & toc(CurrentRecipeRow)("ID"), DB)
		DA.Fill(DS, "Table")
		DT = DS.Tables("Table")
		If DT.Rows.Count > 0 Then
			toc(CurrentRecipeRow)("CardWidth") = DT.Rows(0)("CardWidth") ' Only one row possible
			toc(CurrentRecipeRow)("CardHeight") = DT.Rows(0)("CardHeight")
		End If

		' Destroy our objects.

		DA.Dispose()
		DS.Dispose()
		DT.Dispose()

		' Mark the database as changed.

		DatabaseChanged = True

	End Sub

	'**************************************************
	'
	' Sub to save the new or updated recipe.
	'
	'**************************************************
	Private Sub SaveRecipe()

		' Declare variables

		Dim xx As Integer
		Dim NewRecipeID As Integer
		Dim zx As String = ""
		Dim OldCategory As String = ""
		Dim dr As DataRow
		Dim Transaction As SqlTransaction
		Dim Command As New SqlCommand

		' Begin a transaction

		Transaction = DB.BeginTransaction
		RecipesDA.UpdateCommand.Transaction = Transaction
		RecipesDA.InsertCommand.Transaction = Transaction
		IngredientsDA.InsertCommand.Transaction = Transaction
		IngredientsDA.UpdateCommand.Transaction = Transaction
		IngredientsDA.SelectCommand.Transaction = Transaction


		' Add or update the recipe record.

		Try
			If rMode = ADDRECORD Then
				dr = toc.NewRow

				' Fill in fields in the new recipe that the user doesn't directly enter.

				dr("ParentID") = mBook("ID")
				dr("CardStyle") = 0
				dr("CardWidth") = 6 ' Default to 4x6 card
				dr("CardHeight") = 4
				dr("LeftMargin") = 0
				dr("Heading Margin") = 0
				dr("IngredientsMargin") = 0
				dr("ProcedureMargin") = 0
				dr("FontSize") = 10
				dr("FontName") = "Arial"
				dr("Scale") = ""
				dr("Favorite") = 0
				dr("DateAdded") = Now.Date

			Else
				' Get the newly-added record from the TOC

				dr = toc(CurrentRecipeRow)
				OldCategory = dr("Category")
			End If

			' Get the recipe information from the user.

			dr("RecipeName") = txtTitle.Text
			dr("Category") = Capitalize(txtCategory.Text)
			dr("Author") = txtAuthor.Text
			dr("Blurb") = txtBlurb.Text
			dr("Servings") = txtServings.Text
			If txtProcedure.Text <> "" Then zx = StandardizeUnits(txtProcedure.Text) Else zx = ""
			dr("Procedure") = zx
			dr("Notes") = txtNotes.Text
			If rMode = ADDRECORD Then toc.AddRecipe(dr)
			RecipesDA.Update(toc.RecipesTable)

			' Save the recipe ID, whether or not it was just added.

			NewRecipeID = dr("ID")

			' If the ingredients have not changed, we will not rewrite them.

			If IngredientsChanged Then

				' Delete any existing ingredient records before beginning.

				Command.Transaction = Transaction
				Command.Connection = DB
				Command.CommandText = "DELETE FROM tblIngredients WHERE ParentID=" & dr("ID")
				Command.CommandType = CommandType.Text
				Command.ExecuteNonQuery()

				' Save the recipe's ingredients

				SaveIngredients(dr, txtIngredients.Text)
			End If

			' Commit the transaction.

			Transaction.Commit()

			' If we've added a recipe, we must rebuild the recipes dataset to reflect the change.

			If rMode = ADDRECORD OrElse dr("Category") <> OldCategory Then
				toc.Refresh() ' Rebuild the table of content to reflect the new category of the recipe.
				mBookmarks = Nothing ' Destroy so they'll be recreated

				' Refresh the library.

				frmMain.RefreshLibrary()

				' Make the recipe the current recipe.

				For xx = 0 To toc.Count - 1
					If toc(xx)("ID") = NewRecipeID Then
						CurrentRecipeRow = xx
						SelectTab(GetR(dr, "Category").substring(0, 1))
						Exit For
					End If
				Next xx
			End If

			' Display the new or modified recipe.

			ShowRecipes(Bookmark:=CurrentRecipeRow)

			' Mode is edit now regardless

			rMode = MODIFYRECORD

			' Flag that the database has changed

			DatabaseChanged = True

			' Clear all the entry fields for the next recipe.  Set the Dont Process
			' flag to prevent any TextChanged events from functioning.

			DontProcessEvent = True
			txtTitle.Clear()
			txtCategory.Clear()
			txtAuthor.Clear()
			txtBlurb.Clear()
			txtServings.Clear()
			txtIngredients.Clear()
			txtProcedure.Clear()
			DontProcessEvent = False

			' Make link menu invisible

			LinkToolStripMenuItem.Visible = False

			' Update the displayed record count

			ShowStatistics()

			' Clear and refill the Recent menu, to reflect this new or updated recipe.

			FillRecentMenu(False)
			FillRecentMenu(True)
		Catch ex As Exception
			MsgBox("Update Failed." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Save Recipe")
			Transaction.Rollback()
		End Try

	End Sub
	'**************************************************

	' Sub to display the book statistics

	'**************************************************
	Private Sub ShowStatistics()
		lblStatistics.Text = CStr(toc.Count) & " Recipe(s)"
	End Sub

	'**************************************************

	' Sub to prepare the form for use.

	'**************************************************
	Private Sub PerformStartup()

		' Declare variables

		Dim ii As Integer = 0

		' Build the table of contents

		toc = New TableOfContents(BookID)

		' Get all the links from one recipe to another.

		LinksDA.SelectCommand = LinksSelectCommand()
		LinksDS.Clear()

		On Error GoTo TryAgain
		Do
			LinksDA.Fill(LinksDS, "Table")
		Loop While ii > 0 And ii < 3

		' If we've opened the links table successfully, try to open the images table.

		If ii < 3 Then

			LinksTable = LinksDS.Tables("Table")

			' Get the images table

			ii = 0
			ImagesDA.SelectCommand = ImagesSelectCommand()
			ImagesDS.Clear()
			Do
				ImagesDA.Fill(ImagesDS, "Table")
			Loop While ii > 0 And ii < 3
			ImagesTable = ImagesDS.Tables("Table")
		End If

		' Set the Image Attributes object to make black transparent.

		ImageAttr.SetColorKey(Color.Black, Color.FromArgb(255, 10, 10, 64))

		' Set the initial tabs images.

		LeftTabImage = My.Resources.TabBlank
		RightTabImage = My.Resources.TOC


TryAgain:

		ii += 1
		Resume Next

	End Sub


End Class