Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmSearchLibrary
	Inherits System.Windows.Forms.Form
	'**********************************************************
	' SiriusCook SQL Search Library form
	' SIRIUSCOOK_SEARCHLIBRARY.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 2000-2017 Sirius Software All Rights Reserved
	'**********************************************************

	' Define variables local to this module

	Private SelectedID As Integer
	Private RecipesDS As New DataSet
	Private CookbooksDS As New DataSet
	Private mRecipes As DataTable
	Private mCookbooks As DataTable
	Private MAXLINES As Integer
	Private INDENT As Integer
	Private CurrentTopOfDisplay As Integer
	Private CurrentRecipeRow As Integer
	Private SortSequence As Integer
	Private SelectItem As Integer
	Private DisplayedFields As Integer
	Private mDisplayMode As Integer
	Private NewIndex As Integer
	Private KeyboardCommand As Boolean
	Private RecordSource As String
	Private Where As String
	Private OrderBy As String

	' Create a type for one display line and dimension
	' an array of display lines

	Private Structure typDLine
		Dim Text As String
		Dim ToolTipText As String
		Dim Bookmark As Double
		Dim Enabled As Boolean
		Dim ID As Integer
	End Structure
	Private DisplayLine() As typDLine

	' Create a type for one display column and dimension
	' an array of columns

	Private Structure typColumn
		Dim Field As String
		Dim Caption As String
		Dim ColWidth As Integer
		Dim AorDSort As String
		Dim Justify As Integer
		Dim Sorted As Boolean
	End Structure
	Private Column() As typColumn

	'********************************************************
	'
	' The form is loaded.
	'
	'********************************************************
	Private Sub frmSearchLibrary_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		' Declare variables

		Dim g As Graphics = Picture1.CreateGraphics

		' Calculate how many lines the picture can hold

		MAXLINES = Picture1.ClientRectangle.Height \ g.MeasureString("X", Picture1.Font).Height

		' Calculate the width of each column's margin

		INDENT = g.MeasureString("X", Picture1.Font).Width

		' Initialize the list

		Clear()

		' Set up the two displayed columns

		ReDim Column(3)
		Column(1).Field = "RecipeName"
		Column(1).ColWidth = btnHeader_0.Width
		Column(1).AorDSort = "ASC"
		SortSequence = 1
		Column(2).Field = "Author"
		Column(2).ColWidth = btnHeader_1.Width
		Column(2).AorDSort = "ASC"
		Column(3).Field = "Title"
		Column(3).ColWidth = btnHeader_2.Width
		Column(3).AorDSort = "ASC"

		' Open the cookbooks table

		CookbooksDA.SelectCommand = CookbooksSelectCommand()
		CookbooksDA.Fill(CookbooksDS, "Table")
		mCookbooks = CookbooksDS.Tables("Table")

	End Sub

	'********************************************************
	'
	' The form is unloaded. Clear the number of the selected
	' item.
	'
	'********************************************************
	Private Sub frmSearchLibrary_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Clear selected item

		SelectItem = 0
		SelectedID = 0

		' close the open tables

		CookbooksDS.Dispose()
		RecipesDS.Dispose()

	End Sub

	'********************************************************
	'
	' The find button is clicked.
	'
	'********************************************************
	Private Sub btnFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnFind.Click

		' Declare variables

		Dim xx As String
		Dim zx As String
		Dim zx0 As String
		Dim zx1 As String
		Dim zx2 As String
		Dim Bool As String

		' Create the recordsource and order-by statements

		RecordSource = "SELECT DISTINCT RecipeName,tblRecipes.Author,Title,TblRecipes.ID FROM (tblRecipes INNER JOIN tblCookbooks ON tblRecipes.ParentID=tblCookbooks.ID) INNER JOIN tblIngredients ON tblRecipes.ID=tblIngredients.ParentID"
		OrderBy = " ORDER BY RecipeName,Author,Title"

		' Create the Where statement, based on whether we are to look for all
		' words, any word or the exact text.

		zx2 = ""
		Where = ""
		If Option1_1.Checked = True Then Bool = " OR " Else Bool = " AND "
		zx = Text1.Text
		If Not Option1_2.Checked Then
			Do While zx <> ""
				xx = ParseString(zx, " ")
				zx0 = ""
				zx1 = ""
				If zx2 <> "" Then zx2 = zx2 & Bool
				zx2 = zx2 & "("
				If Check1_0.Checked Then zx0 = " CHARINDEX( '" & xx & "', [RecipeName],1) >0"
				If Check1_1.Checked Then
					If zx0 <> "" Then zx1 = " OR "
					zx1 = zx1 & " CHARINDEX('" & xx & "',[IngredientName],1)>0"
				End If
				If Check1_2.Checked Then
					If zx0 <> "" Then zx1 = " OR "
					zx1 = zx1 & " CHARINDEX('" & xx & "',[Procedure],1)>0"
				End If
				zx2 = zx2 & zx0 & zx1 & ")"
			Loop
		Else
			zx0 = ""
			zx1 = ""
			If Check1_0.Checked Then zx0 = " CHARINDEX( '" & zx & "', [RecipeName],1) >0"
			If Check1_1.Checked Then
				If zx0 <> "" Then zx1 = " OR "
				zx1 = zx1 & " CHARINDEX('" & zx & "',[IngredientName],1)>0"
			End If
			If Check1_2.Checked Then
				If zx0 <> "" Then zx1 = " OR "
				zx1 = zx1 & " CHARINDEX('" & zx & "',[Procedure],1)>0"
			End If
			zx2 = zx2 & zx0 & zx1
		End If


		If zx2 <> "" Then Where = " WHERE " & zx2

		' Read in the matching records

		ReadRecords()

		' Invalidate the display.  This will cause it to be redrawn.

		Picture1.Invalidate()

	End Sub

	'**********************************************************
	'
	' The Show Recipe button is clicked.
	'
	'**********************************************************
	Private Sub btnShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnShow.Click

		' Declare variables

		Dim RecID As Integer
		Dim RecipesDS As New DataSet
		Dim lRec As DataTable
		Dim lBook As Cookbook

		' Display the search form

		RecID = SelectedID
		RecipesDA.SelectCommand.CommandText = "SELECT ParentID FROM tblRecipes WHERE ID=" & RecID
		RecipesDA.Fill(RecipesDS, "Table")
		lRec = RecipesDS.Tables("Table")
		If lRec.Rows.Count > 0 AndAlso lRec.Rows(0)("ParentID") > 0 Then
			lBook = frmMain.gLibrary.CookBooks.Item(CStr(lRec.Rows(0)("ParentID")))
			lBook.OpenBook(RecID)
		End If
		RecipesDS.Dispose()
	End Sub

	'**********************************************************
	'
	' The Close button is clicked.
	'
	'**********************************************************
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub


	'**********************************************************
	'
	' A new sort sequence selected.  Read in a new list
	'
	'**********************************************************
	Private Sub btnHeader_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnHeader_0.Click, btnHeader_1.Click, btnHeader_2.Click

		' Declare variables

		Dim jj As Integer
		Dim j1 As Integer
		Dim index As Integer = GetControlIndex(eventSender)

		' Get the current sort sequence of the selected
		' column.
		' Toggle the sort of the selected column, IF the
		' same sort sequence is selected as last time (the
		' same column was clicked twice).

		j1 = 0
		For jj = 1 To 3
			j1 = j1 + 1
			If j1 - 1 = index Then
				If SortSequence = index + 1 Then
					If Column(jj).AorDSort = "DESC" Then Column(jj).AorDSort = "ASC" Else Column(jj).AorDSort = "DESC"
				End If
				Exit For
			End If
		Next jj

		' Remember the button clicked.

		SortSequence = index + 1

		' Assemble an SQL "ORDER BY" clause which will sort
		' by the selected field--ascending or descending.

		OrderBy = " ORDER BY " & Column(j1).Field & " " & Column(j1).AorDSort & ";"

		' Read in a complete screenful of records (or as
		' many as exist)

		ReadRecords()

		' Clear any selection and display the records

		SelectItem = 0
		SelectedID = 0
		Picture1.Invalidate()

		' Reset the position to the top of the Recordset

		VScroll1.Value = 1

	End Sub

	'*********************************************************
	'
	' Sub to display the current display array in the picture
	'
	'*********************************************************
	Private Sub DisplayRecords(g As Graphics)

		' Declare variables

		Dim jj As Integer

		' Display records.  For each line, clear the
		' picture box with a rectangle and reset x and y before
		' writing the new line.

		For jj = 1 To MAXLINES
			DisplayOneLine(g, jj)
		Next jj

		' If an item is selected, display it in a menubar

		If SelectItem > 0 Then DisplayOneLine(g, SelectItem, True)

		'If the window is not filled, make the scroll bar invisible

		If DisplayLine(MAXLINES).Text = "" Then
			VScroll1.Visible = False
		Else
			VScroll1.Visible = True
		End If

	End Sub

	'**********************************************************
	'
	' A key is pressed. If the up arrow, scroll the selection
	' bar up. If the down arrow, scroll down.
	'
	'**********************************************************
	Private Sub frmSearchLibrary_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Integer = eventArgs.KeyCode
		Dim Shift As Integer = eventArgs.KeyData \ &H10000

		Select Case KeyCode
			Case Windows.Forms.Keys.Up
				If SelectItem > 1 Then
					DisplayOneLine(Picture1.CreateGraphics, SelectItem)
					SelectItem = SelectItem - 1
					DisplayOneLine(Picture1.CreateGraphics, SelectItem, True)
				Else
					KeyboardCommand = True
					If VScroll1.Value > VScroll1.Minimum Then VScroll1.Value = VScroll1.Value - 1
					KeyboardCommand = False
				End If
			Case Windows.Forms.Keys.Down
				If SelectItem < MAXLINES Then
					If DisplayLine(SelectItem + 1).Text <> "" Then
						DisplayOneLine(Picture1.CreateGraphics, SelectItem)
						SelectItem = SelectItem + 1
						DisplayOneLine(Picture1.CreateGraphics, SelectItem, True)
					End If
				Else
					KeyboardCommand = True
					If VScroll1.Value < (VScroll1.Maximum - VScroll1.LargeChange + 1) Then VScroll1.Value = VScroll1.Value + 1
					KeyboardCommand = False
				End If
			Case Windows.Forms.Keys.Prior
				KeyboardCommand = True
				If VScroll1.Value > VScroll1.Minimum + MAXLINES Then VScroll1.Value = VScroll1.Value - MAXLINES
				KeyboardCommand = False
			Case Windows.Forms.Keys.Next
				KeyboardCommand = True
				If VScroll1.Value < (VScroll1.Maximum - VScroll1.LargeChange + 1) - MAXLINES Then VScroll1.Value = VScroll1.Value + MAXLINES
				KeyboardCommand = False
		End Select

	End Sub

	'**********************************************************
	'
	' The mouse has moved over the search form
	'
	'**********************************************************
	Private Sub frmSearchLibrary_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
		On Error Resume Next
		Text1.Focus()
		On Error GoTo 0
	End Sub
	'********************************************************
	'
	' A recipe is selected.
	'
	'********************************************************
	Private Sub Picture1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture1.Click
		btnShow.Enabled = True
	End Sub

	'********************************************************
	'
	' An item is double-clicked.  This is the same
	' as clicking the Open button.
	'
	'********************************************************
	Private Sub Picture1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture1.DoubleClick
		btnShow_Click(btnShow, New System.EventArgs())
	End Sub

	'********************************************************
	'
	' The mouse button is pressed in the picture box.
	' Determine from the coordinates which line was clicked
	' and highlight that line if not blank
	'
	'********************************************************
	Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseDown

		Dim Button As Integer = eventArgs.Button \ &H100000
		Dim Shift As Integer = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim g As Graphics = Picture1.CreateGraphics()

		' Make sure the button which was pressed is the
		' left or right button only and that there is at
		' least one item in the window to select.

		If Button <> 4 And DisplayLine(1).Text <> "" Then

			' If a previous item was selected, unselect it now

			If SelectItem > 0 Then DisplayOneLine(g, SelectItem)

			' Calculate the Display line based upon the Y coordinate
			' of where the mouse was clicked.

			SelectItem = Fix(Y / g.MeasureString(DisplayLine(1).Text, Picture1.Font).Height) + 1
			If SelectItem = 0 Then SelectItem = 1
			If SelectItem > MAXLINES Then SelectItem = MAXLINES

			' Display the selected item

			If DisplayLine(SelectItem).Text <> "" Then
				DisplayOneLine(g, SelectItem, True)

				' Make the selected record current and save its
				' "keyfield" value in the property "SelectedID"

				On Error Resume Next
				CurrentRecipeRow = DisplayLine(SelectItem).Bookmark
				SelectedID = DisplayLine(SelectItem).ID
				On Error GoTo 0

			Else
				SelectItem = 0
				SelectedID = 0
			End If
		End If

		' Dispose of objects we've created.

		g.Dispose()

	End Sub

	'********************************************************
	'
	' The mouse has moved over the picture box.

	'********************************************************
	Private Sub Picture1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseMove

		Dim Button As Integer = eventArgs.Button \ &H100000
		Dim Shift As Integer = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim x As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim g As Graphics = Picture1.CreateGraphics

		' Declare variables

		Dim xx As Integer
		Static LastRow As Integer

		' Get the entry number over which the mouse is hovering.

		xx = Fix(Y / g.MeasureString("X", Picture1.Font).Height) + 1
		If xx = 0 Then xx = 1
		If xx > MAXLINES Then xx = MAXLINES

		' Display the selected item

		If xx <> LastRow Then
			ToolTip1.SetToolTip(Picture1, "")
			If xx >= LBound(DisplayLine, 1) And xx <= UBound(DisplayLine, 1) Then
				If DisplayLine(xx).Text <> "" Then ToolTip1.SetToolTip(Picture1, DisplayLine(xx).ToolTipText)
			End If
			LastRow = xx
		End If

		' Dispose of objects we've created.

		g.Dispose()

	End Sub


	'*********************************************************
	'
	' A paint event has ocurred.  Display the records.
	'
	'*********************************************************
	Private Sub Picture1_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles Picture1.Paint
		Call DisplayRecords(eventArgs.Graphics)
	End Sub


	'**********************************************************
	'
	' The scroll bar has been moved.
	'
	'**********************************************************
	Private Sub VScroll1_Scroll1(sender As Object, e As ScrollEventArgs) Handles VScroll1.Scroll

		' Declare variables

		Dim xx As Integer

		Select Case e.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll

				' Get the amount of the change in the scroll bar value.

				xx = System.Math.Abs(CurrentTopOfDisplay - e.NewValue)

				' If our movement came from a keyboard command, and we are
				' moving more than 1 line at a time, clear the selected
				' item.

				If KeyboardCommand And xx > 1 Then SelectItem = 0

				' See if scroll was up or down.

				If e.NewValue > CurrentTopOfDisplay Then

					' Move down.  Move the selection bar up to compensate,
					' until it hits the top, unless the movement is coming
					' from the keyboard (it manages the selected item itself).

					If Not KeyboardCommand And SelectItem > 0 Then
						SelectItem = SelectItem - xx
						If SelectItem < 1 Then SelectItem = 1
					End If

					' Move down the number of records difference between the old
					' position and the new position.

					MoveDown(xx)

					' Move up:

				Else

					' Move the selector bar down to compensate, until it
					' hits the bottom, unless the movement is coming
					' from the keyboard (it manages the selected item itself).

					If Not KeyboardCommand And SelectItem > 0 Then
						SelectItem = SelectItem + xx
						If SelectItem > MAXLINES Then SelectItem = MAXLINES
					End If

					' Move up the number of records difference between the old
					' position and the new position.

					MoveUp(xx)
				End If

				' Remember the new position of the first record in the
				' display

				CurrentTopOfDisplay = e.NewValue
		End Select

	End Sub
	'*********************************************************
	'
	' Sub to read a screenful of records from the
	' recordset
	'
	'*********************************************************
	Private Sub ReadRecords()


		' Declare variables

		Dim NewLargeChange As Integer
		Dim jj As Integer
		Dim SQLStmt As String
		Dim lTotal As New Object

		' Put on the "wait" mouse pointer

		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

		' Clear the display array

		ReDim DisplayLine(MAXLINES)

		' Rebuild the Recordset

		SQLStmt = RecordSource & " " & Where & " " & OrderBy
		On Error GoTo SQLError
		RecipesDS.Clear()
		RecipesDA.SelectCommand.CommandText = SQLStmt
		RecipesDA.Fill(RecipesDS, "Table")
		mRecipes = RecipesDS.Tables("Table")

		' Read in the records. Save "MaxLines" of them for
		' display in the window.

		If mRecipes.Rows.Count > 0 Then
			CurrentRecipeRow = 0
			jj = 0
			Do
				jj = jj + 1
				DisplayLine(jj).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
				DisplayLine(jj).ToolTipText = ""
				DisplayLine(jj).Bookmark = CurrentRecipeRow
				DisplayLine(jj).Enabled = True
				DisplayLine(jj).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
				CurrentRecipeRow += 1
			Loop While CurrentRecipeRow < mRecipes.Rows.Count And jj < MAXLINES
		End If

		' Set the indicator for the top of the display

		CurrentTopOfDisplay = 1

		' Get the number of records and set the min and max for
		' the scroll bar.

		If mRecipes.Rows.Count > 0 Then
			CurrentRecipeRow = mRecipes.Rows.Count - 1
			VScroll1.Minimum = 1
			If mRecipes.Rows.Count - MAXLINES + 1 > 1 Then VScroll1.Maximum = (mRecipes.Rows.Count - MAXLINES + 1 + VScroll1.LargeChange - 1) Else VScroll1.Maximum = (1 + VScroll1.LargeChange - 1)
		Else
			VScroll1.Minimum = 1
			VScroll1.Maximum = (1 + VScroll1.LargeChange - 1)
		End If
		VScroll1.SmallChange = 1
		NewLargeChange = MAXLINES
		VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
		VScroll1.LargeChange = NewLargeChange
		VScroll1.Value = 1

		' Clear any selection and display the records

EndRead:

		SelectItem = 0
		SelectedID = 0
		DisplayRecords(Picture1.CreateGraphics)

		' Put on the normal mouse pointer

		Me.Cursor = System.Windows.Forms.Cursors.Default
		On Error GoTo 0
		Exit Sub

		' Trap for errors reading records

SQLError:
		MsgBox("Bad SQL Parameter(s)." & vbCrLf & ErrorToString(), MsgBoxStyle.Exclamation, "Search Library")
		Resume EndRead
	End Sub

	'**********************************************************
	'
	' Sub to scroll the selection bar down.
	'
	'**********************************************************
	Private Sub ScrollDown()

		' Declare variables

		Dim jj As Integer

		' Set an error trap

		On Error GoTo MoveError

		' If a previous item was selected, unselect it now

		If SelectItem > 0 Then DisplayOneLine(Picture1.CreateGraphics, SelectItem)

		' Try to read in another record to fill the bottom of the
		' list

		If DisplayLine(MAXLINES).Text <> "" Then
			CurrentRecipeRow = DisplayLine(MAXLINES).Bookmark
			CurrentRecipeRow += 1
			If CurrentRecipeRow < mRecipes.Rows.Count Then

				' We found another record.  Shuffle the entries to the
				' top, discarding the first entry.  Add the new entry to
				' the bottom and display them.

				For jj = 1 To MAXLINES - 1
					DisplayLine(jj).Text = DisplayLine(jj + 1).Text
					DisplayLine(jj).ToolTipText = DisplayLine(jj + 1).ToolTipText
					DisplayLine(jj).Bookmark = DisplayLine(jj + 1).Bookmark
					DisplayLine(jj).Enabled = DisplayLine(jj + 1).Enabled
					DisplayLine(jj).ID = DisplayLine(jj + 1).ID
				Next jj
				DisplayLine(MAXLINES).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
				DisplayLine(MAXLINES).ToolTipText = ""
				DisplayLine(MAXLINES).Bookmark = CurrentRecipeRow
				DisplayLine(MAXLINES).Enabled = True
				DisplayLine(MAXLINES).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
			End If
		End If
		On Error GoTo 0
		Exit Sub

MoveError:
		DisplayLine(MAXLINES).Text = ""
		DisplayLine(MAXLINES).Bookmark = 0
		DisplayLine(MAXLINES).Enabled = True
		DisplayLine(MAXLINES).ID = 0
		Resume ME1
ME1:

	End Sub

	'**********************************************************
	'
	' Sub to move the selection bar up by one
	'
	'**********************************************************
	Private Sub ScrollUp()

		' Declare variables

		Dim jj As Integer

		' Set an error trap

		On Error GoTo MoveError

		' If a previous item was selected, unselect it now

		If SelectItem > 0 Then DisplayOneLine(Picture1.CreateGraphics, SelectItem)

		' Try to read in a previous record to fill the top of the
		' list

		If DisplayLine(1).Text <> "" Then
			CurrentRecipeRow = DisplayLine(1).Bookmark
			CurrentRecipeRow -= 1
			If CurrentRecipeRow >= 0 Then

				' We found another record.  Shuffle the entries to the
				' bottom, discarding the last entry.  Add the new entry to
				' the top and display them.

				For jj = MAXLINES To 2 Step -1
					DisplayLine(jj).Text = DisplayLine(jj - 1).Text
					DisplayLine(jj).ToolTipText = DisplayLine(jj - 1).ToolTipText
					DisplayLine(jj).Bookmark = DisplayLine(jj - 1).Bookmark
					DisplayLine(jj).Enabled = DisplayLine(jj - 1).Enabled
					DisplayLine(jj).ID = DisplayLine(jj - 1).ID
				Next jj
				DisplayLine(1).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
				DisplayLine(1).ToolTipText = ""
				DisplayLine(1).Bookmark = CurrentRecipeRow
				DisplayLine(1).Enabled = True
				DisplayLine(1).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
			End If
		End If
		On Error GoTo 0
		Exit Sub

MoveError:
		DisplayLine(1).Text = ""
		DisplayLine(1).Bookmark = 0
		DisplayLine(1).Enabled = True
		DisplayLine(1).ID = 0
		Resume ME1
ME1:

	End Sub

	'**********************************************************
	'
	' Sub to move down a certain number of lines.
	'
	'**********************************************************
	Private Sub MoveDown(ByRef LinesDown As Integer)

		' Declare variables

		Dim jj As Integer

		' Set an error trap

		On Error GoTo MoveError

		' Position to the last record using the bookmark

		If DisplayLine(MAXLINES).Text <> "" Then
			CurrentRecipeRow = DisplayLine(MAXLINES).Bookmark

			' Attempt to read forward to next record

			CurrentRecipeRow += 1

			' If we found at least one more record, proceed to read
			' forward.

			If CurrentRecipeRow < mRecipes.Rows.Count Then
				CurrentRecipeRow = DisplayLine(MAXLINES).Bookmark

				' If the number of lines to move down is greater than one
				' screenfull, read forward that many lines LESS one
				' screenfull before reading the next screen. Then stuff
				' that record's bookmark into the end of the display array
				' so the subsequent scroll down calls will start from it.

				If LinesDown > MAXLINES Then
					For jj = 1 To LinesDown - MAXLINES
						CurrentRecipeRow += 1
						LinesDown = LinesDown - 1
						If CurrentRecipeRow >= mRecipes.Rows.Count Then Exit For
					Next jj
					If CurrentRecipeRow < mRecipes.Rows.Count Then
						DisplayLine(MAXLINES).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
						DisplayLine(MAXLINES).ToolTipText = ""
						DisplayLine(MAXLINES).Bookmark = CurrentRecipeRow
						DisplayLine(MAXLINES).Enabled = True
						DisplayLine(MAXLINES).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
					End If
				End If

				' Now read in "LinesDown" number of lines.

				For jj = 1 To LinesDown
					ScrollDown()
				Next jj
				DisplayRecords(Picture1.CreateGraphics)
			End If
		End If

		' The selected item bar must now point to a new item

		If DisplayLine(SelectItem).Text <> "" Then
			CurrentRecipeRow = DisplayLine(SelectItem).Bookmark
			SelectedID = DisplayLine(SelectItem).ID
		End If

		On Error GoTo 0
		Exit Sub

MoveError:
		Resume ME1
ME1:

	End Sub

	'**********************************************************
	'
	' Sub to move up a specified number of lines.
	'
	'**********************************************************
	Private Sub MoveUp(ByRef LinesUp As Integer)

		' Declare variables

		Dim jj As Integer

		' Set an error trap

		On Error GoTo MoveError

		' Position to the first record using the bookmark

		If DisplayLine(1).Text <> "" Then
			CurrentRecipeRow = DisplayLine(1).Bookmark

			' Attempt to read backward to next record

			CurrentRecipeRow -= 1

			' If we found at least one more record, proceed to read
			' backward.

			If CurrentRecipeRow >= 0 Then
				CurrentRecipeRow = DisplayLine(1).Bookmark

				' If the number of lines to move up is greater than one
				' screen full, read backward that many lines LESS one
				' screen full before reading the next screen.  Then put
				' that record's bookmark into the first element of the
				' display array so that the subsequent scroll up will
				' start from that record.

				If LinesUp > MAXLINES Then
					For jj = 1 To LinesUp - MAXLINES
						CurrentRecipeRow -= 1
						LinesUp = LinesUp - 1
						If CurrentRecipeRow < 0 Then Exit For
					Next jj
					If CurrentRecipeRow >= 0 Then
						DisplayLine(1).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
						DisplayLine(1).ToolTipText = ""
						DisplayLine(1).Bookmark = CurrentRecipeRow
						DisplayLine(1).Enabled = True
						DisplayLine(1).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
					End If
				End If

				' Now read in "LinesUp" number of lines.

				For jj = 1 To LinesUp
					ScrollUp()
				Next jj
				DisplayRecords(Picture1.CreateGraphics)
			End If
		End If

		' The selected item bar must now point to a new item

		If DisplayLine(SelectItem).Text <> "" Then
			CurrentRecipeRow = DisplayLine(SelectItem).Bookmark
			SelectedID = DisplayLine(SelectItem).ID
		End If

		On Error GoTo 0
		Exit Sub

MoveError:
		Resume ME1
ME1:

	End Sub



	'**************************************************
	'
	' Sub to re-build the display lines for each record
	' currently in the display, to show changed data.
	'
	'**************************************************
	Public Sub RefreshDisplay(ByRef Rebuild As Boolean)

		' Put on a "wait" mouse pointer

		Me.Cursor = Cursors.WaitCursor

		' Do a "readrecords" instead, in case records
		' have been added or deleted.

		If Rebuild Then ReadRecords() Else RefreshRecords()
		DisplayRecords(Picture1.CreateGraphics)

		'If the window is not filled, make the scroll bar invisible

		If DisplayLine(MAXLINES).Text = "" Then
			VScroll1.Visible = False
			btnHeader_2.Visible = False
		Else
			VScroll1.Visible = True
			btnHeader_2.Visible = True
		End If

		' Put on normal mouse pointer

		Me.Cursor = Cursors.Default

	End Sub



	'***********************************************************************
	'
	' Sub to clear the list
	'
	'***********************************************************************
	Public Sub Clear()


		' Redimension an array of typDLine structures

		ReDim DisplayLine(MAXLINES)

		' Redimension an array of typColumn structures

		ReDim Column(1)

		' clear the count of displayed columns and all
		' columns

		DisplayedFields = 0
		NewIndex = 0 ' Always the left-most column for graphics

		' Clear the current selection and the current sort
		' sequence

		SelectItem = 0
		SelectedID = 0
		SortSequence = 0

		' Force the picture to redraw

		Picture1.Invalidate()
	End Sub

	'*********************************************************
	'
	' Sub to refresh all the records in the display only
	'
	'*********************************************************
	Private Sub RefreshRecords()

		' Declare variables

		Dim jj As Integer

		' Get and rebuild each display line

		On Error GoTo RecErr
		For jj = 1 To MAXLINES
			If DisplayLine(jj).Text <> "" Then
				CurrentRecipeRow = DisplayLine(jj).Bookmark
				DisplayLine(jj).Text = BuildDisplayLine(mRecipes.Rows(CurrentRecipeRow))
				DisplayLine(jj).ID = mRecipes.Rows(CurrentRecipeRow)("ID")
			End If
		Next jj
		On Error GoTo 0
		Exit Sub

		' If we get any error rebuilding the line, rebuild the
		' entire display instead.

RecErr:
		ReadRecords()
		Exit Sub
	End Sub

	'**********************************************************
	'
	' Function to build a display line from a record
	'
	'**********************************************************
	Private Function BuildDisplayLine(ByRef i As DataRow) As String

		' Declare variables

		Dim zx0 As String = ""

		' Now begin assembling the display string column by column

		On Error GoTo BuildErr
		zx0 = TextTrim(Picture1, GetR(i, "RecipeName"), Column(1).ColWidth - INDENT) & Chr(9)
		zx0 &= TextTrim(Picture1, GetR(i, "Author"), Column(2).ColWidth - INDENT) & Chr(9)
		zx0 &= TextTrim(Picture1, GetR(i, "Title"), Column(3).ColWidth - INDENT)


Finish:
		On Error GoTo 0
		BuildDisplayLine = zx0
		Exit Function

		' Trap for errors accessing a record

BuildErr:
		Resume Finish
	End Function
	'**********************************************************
	'
	' Function to trim text to a specified width.  This works
	' much like theWordWrap function, but breaks anywhere, and
	' not at word boundries.
	'
	'**********************************************************
	Private Function TextTrim(ByVal Device As Object, ByVal Text As String, ByVal FitInWidth As Integer) As String

		' Declare variables

		Dim jj As Integer
		Dim zx0 As String
		Dim g As Graphics = Device.CreateGraphics

		' Begin trimming down the text until it is less than or
		' equal to the specified width.

		zx0 = ""
		For jj = Len(Text) To 0 Step -1
			If g.MeasureString(VB.Left(Text, jj), Device.font).Width <= FitInWidth Then
				zx0 = VB.Left(Text, jj)
				Exit For
			End If
		Next jj
		TextTrim = zx0

	End Function

	'**********************************************************
	'
	' Sub to clear the menu bar over a selection
	'
	'**********************************************************
	Private Sub DisplayOneLine(ByVal g As Graphics, ByRef SelectItem As Integer, Optional ByRef Selected As Boolean = False)

		' Declare variables

		Dim x As Single
		Dim y As Single
		Dim w As Single
		Dim LineHeight As Integer
		Dim yy As Object
		Dim zx0 As String
		Dim zx1 As String
		Dim f As Font = Picture1.Font
		Dim bH As New SolidBrush(SystemColors.Highlight)
		Dim bB As New SolidBrush(SystemColors.Window)
		Dim bN As SolidBrush
		Dim TextSize As System.Drawing.SizeF
		Dim b As Button


		' Make sure we have a line to display
		Try
			If DisplayLine(SelectItem).Text <> "" Then

				' Calculate the height of a line

				LineHeight = g.MeasureString("X", f).Height

				' Draw a box in the normal window color if not selected, or the
				' highlight color if selected, to clear the line, then set
				' our drawing position.


				y = (SelectItem - 1) * LineHeight
				x = 0
				w = Picture1.Width
				If Not Selected Then
					g.FillRectangle(bB, x, y, w, LineHeight)
				Else
					g.FillRectangle(bH, x, y, w, LineHeight)
				End If

				' Create the brush to print the text.

				If Selected Then bN = New SolidBrush(SystemColors.HighlightText) Else bN = New SolidBrush(SystemColors.WindowText)

				' Begin drawing the line column by column

				zx0 = DisplayLine(SelectItem).Text
				b = btnHeader_0
				zx1 = TextTrim(Picture1, ParseString(zx0, Chr(9)), b.Width)
				TextSize = g.MeasureString(zx1, f)

				' Check if the 1st field is string or numeric.  Right-justify numeric fields.

				yy = mRecipes.Rows(DisplayLine(SelectItem).Bookmark)(Column(1).Field)
				If TypeOf (yy) Is Double Or TypeOf (yy) Is Single Or TypeOf (yy) Is Integer Then
					x = b.Left + b.Width - TextSize.Width - INDENT
					g.DrawString(zx1, f, bN, x, y)
				Else
					x = b.Left
					g.DrawString(zx1, f, bN, x, y)
				End If
				b = btnHeader_1
				zx1 = TextTrim(Picture1, ParseString(zx0, Chr(9)), b.Width)
				TextSize = g.MeasureString(zx1, Picture1.Font)

				' Check if the 2nd field is string or numeric.  Right-justify numeric fields.

				yy = mRecipes.Rows(DisplayLine(SelectItem).Bookmark)(Column(2).Field)
				If TypeOf (yy) Is Double Or TypeOf (yy) Is Single Or TypeOf (yy) Is Integer Then
					x = b.Left + b.Width - TextSize.Width - INDENT
					g.DrawString(zx1, f, bN, x, y)
				Else
					x = b.Left
					g.DrawString(zx1, f, bN, x, y)
				End If
				b = btnHeader_2
				zx1 = TextTrim(Picture1, ParseString(zx0, Chr(9)), b.Width)

				' Check if the 3rd field is string or numeric.  Right-justify numeric fields.

				yy = mRecipes.Rows(DisplayLine(SelectItem).Bookmark)(Column(3).Field)
				If TypeOf (yy) Is Double Or TypeOf (yy) Is Single Or TypeOf (yy) Is Integer Then
					x = b.Left + b.Width - TextSize.Width - INDENT
				Else
					x = b.Left
				End If
				g.DrawString(zx1, f, bN, x, y)
				bN.Dispose()
			End If

		Catch e As Exception
			MsgBox(e.Message)
		Finally

			bH.Dispose()
			bB.Dispose()

		End Try
	End Sub

End Class