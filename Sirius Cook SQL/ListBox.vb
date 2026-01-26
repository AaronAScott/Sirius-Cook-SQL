Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Friend Class frmListBox
	Inherits System.Windows.Forms.Form
	'**********************************************************
	' Recordset Lookup form for Visual Basic SQL Programs
	' LISTBOX.VB
	' Written: April 2007
	' Updated: February 2021
	' Updated: July 2025
	' Copyright (C) 1994-2025 Sirius Software  All Rights Reserved
	'**********************************************************

	' Define variables local to this module

	Private INDENT As Single
	Private CurrentRowIndex As Integer
	Private DisplayLines As New DisplayLine
	Private MyDA As New SqlDataAdapter
	Private MyDS As New DataSet
	Private MyTable As New DataTable
	Private CurrentRow As DataRow

	' Create a type for one display column and dimension
	' an array of columns

	Private Structure typColumn
		Dim Field As String
		Dim Caption As String
		Dim ColumnWidth As Single
		Dim AorDSort As String
		Dim ColumnFormat As String
		Dim Sorted As Boolean
	End Structure
	Private Column() As typColumn

	Private ColumnHeaders As New Collection
	Private DontProcessChangeEvent As Boolean
	Private MAXLINES As Integer
	Private SelectItem As Integer
	Private CurrentTopOfDisplay As Integer
	Private TableName As String

	Private DatabaseFileName As String
	Private ReturnKey As Object
	Private OriginalRecordset As String
	Private RecordsetName As String
	Private SelectClause As String
	Private WhereClause As String
	Private OrderByClause As String
	Private SearchText As String
	Private TitleText As String
	Private PromptText As String
	Private ListBoxPromptText As String
	Private ReturnFieldName As String
	Private SearchFieldName As String
	Private FieldListText As String
	Private NewIndex As Integer
	Private MarginWidth As Single
	Private CancelSearch As Boolean

	' Declare variables which are the properties of this
	' object

	Public Db As SqlConnection

	' ********************************************************
	'
	' The form is unloaded. Clear the number of the selected
	' item.
	'
	' ********************************************************
	Private Sub frmListBox_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Declare variables

		Dim c As Control

		' Close and destroy the data access objects

		MyDA.Dispose()
		MyDS.Dispose()
		MyTable.Dispose()

		' Remove the event handlers for the buttons.

		For Each c In Me.Controls
			If TypeOf (c) Is Button AndAlso c.Name.IndexOf("Header_") > 0 Then RemoveHandler c.Click, AddressOf btnColumnHeader_Click
		Next c


	End Sub

	'*********************************************************
	'
	' One of the colunmn header buttons is clicked.
	' Sort on that column and redisplay the records.  This
	' event is bound at run time.

	'*********************************************************
	Private Sub btnColumnHeader_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

		' Declare variables

		Dim Index As Integer
		Dim jj As Integer
		Dim xx As Integer
		Dim SQLStmt As String
		Dim zx0 As String
		Dim b As Button
		Dim f As Font
		Static LastColumnClicked As Integer

		' Get the index of the button clicked.

		Index = GetControlIndex(eventSender)

		' Reset all columns to indicate they are NOT sorted.

		For Each b In ColumnHeaders
			If jj = Index Then
				Column(jj).Sorted = True
				f = New Font(b.Font, FontStyle.Bold)
				b.Font = f
			Else
				Column(jj).Sorted = False
				f = New Font(b.Font, FontStyle.Regular)
				b.Font = f
			End If
		Next b

		' If we have clicked the same column twice in a row,
		' toggle the sort from ascending to descending, or
		' vice versa

		If Index = LastColumnClicked Then
			If Column(Index).AorDSort = "DESC" Or Column(Index).AorDSort = "" Then Column(Index).AorDSort = "ASC" Else Column(Index).AorDSort = "DESC"
		Else
			Column(Index).AorDSort = "ASC"
		End If
		LastColumnClicked = Index

		' Reset the search field

		SearchField = Column(Index).Field
		Label1.Text = Column(Index).Caption & ":"

		' Assemble a new SQL statement

		If SelectClause = "" Then
			If Not FieldList.ToUpper.Contains(ReturnField.ToUpper) Then
				SQLStmt = "SELECT " & FieldList & "," & ReturnField & " FROM " & TableName & " ORDER BY " & Column(Index).Field & " " & Column(Index).AorDSort
			Else
				SQLStmt = "SELECT " & FieldList & " FROM " & TableName & " ORDER BY " & Column(Index).Field & " " & Column(Index).AorDSort
			End If
		Else
			On Error Resume Next
			zx0 = MyTable.Rows(0)(ReturnField)
			If Err.Number = 3265 Then ' Item not found in collection
				xx = SelectClause.ToUpper.IndexOf("FROM")
				SQLStmt = "SELECT " & FieldList & "," & ReturnField & " " & SelectClause.Substring(xx) & " " & WhereClause & " ORDER BY " & Column(Index).Field & " " & Column(Index).AorDSort
			Else
				SQLStmt = SelectClause & " FROM " & TableName & WhereClause & " ORDER BY " & Column(Index).Field & " " & Column(Index).AorDSort
			End If
			On Error GoTo 0
		End If
		MyDS.Clear()
		MyDA.SelectCommand = New SqlCommand(SQLStmt, Db)
		MyDA.Fill(MyDS, "Table")
		ReadRecords()
		If txtSearchFor.Text <> "" Then txtSearchFor.Text = "" Else DisplayRecords()


		' Set the focus to the search box

		txtSearchFor.Focus()

	End Sub

	'**********************************************************
	'
	' A key is pressed. If the up arrow, scroll the selection
	' bar up. If the down arrow, scroll down.
	'
	'**********************************************************
	Private Sub frmListBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

		' Declare variables

		Dim KeyCode As Integer = e.KeyCode

		' See if we have a keystroke we need to process

		Select Case KeyCode
			Case Keys.Up
				If SelectItem >= 0 Then
					SelectItem -= 1
					DisplayRecords()
				Else
					If VScroll1.Value > VScroll1.Minimum Then
						VScroll1.Value = VScroll1.Value - 1
						SelectItem = -1
						DisplayRecords()
					End If
				End If
			Case Keys.Down
				If SelectItem < MAXLINES Then
					SelectItem += 1
					DisplayRecords()
				Else
					If VScroll1.Value < (VScroll1.Maximum - VScroll1.LargeChange) Then
						VScroll1.Value = VScroll1.Value + 1
						SelectItem = MAXLINES - 1
						DisplayRecords()
					End If
				End If
			Case Keys.Prior
				If VScroll1.Value > VScroll1.Minimum + MAXLINES - 1 Then VScroll1.Value = VScroll1.Value - (MAXLINES - 1)
			Case Keys.Next
				If VScroll1.Value < (VScroll1.Maximum - VScroll1.LargeChange) - (MAXLINES - 1) Then VScroll1.Value = VScroll1.Value + MAXLINES - 1
			Case Keys.Escape
				CancelSearch = True
		End Select

	End Sub
	'**********************************************************
	'
	' The Okay button is clicked.
	'
	'**********************************************************
	Private Sub btnOkay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSelect.Click

		' Check that a valid item was selected, not a blank part
		' of the picture

		If SelectItem >= 0 Then

			' Read in the selected Record record Accessing it by
			' the bookmark. Put the "return field"'s value into the
			' text field where the frmListbox.lookup function will
			' return it (it will then unload the form).

			CurrentRow = MyTable.Rows(DisplayLines.Items(SelectItem).Bookmark)
			ReturnKey = GetR(CurrentRow, ReturnFieldName)

			Me.Close()
		End If
	End Sub

	'*********************************************************
	'
	' The cancel button is clicked.  Clear the text field
	' so the GetCertificateNum$ function will return a null ID.
	'
	'*********************************************************
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		ReturnKey = Nothing
		Me.Close()
	End Sub

	'**********************************************************
	'
	' The "search" button is clicked. Show the search form.
	'
	'**********************************************************
	Private Sub btnSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSearch.Click

		' Declare variables.

		Static SavedRecordset As String = ""

		' Hide this form while we bring up the search form.

		Me.Hide()

		' If we haven't saved the original recordset, do so now.  This
		' is so that, if a search doesn't yield any results, we can search
		' again from the original list box recordset. Otherwise, the modified
		' recordset returned by the search form would make further searches
		' impossible.

		If SavedRecordset = "" Then SavedRecordset = OriginalRecordset

		' Load the search form and set the properties.  Always pass
		' the search form the original recordset, since it returns
		' a modified value to this form as the results of its search.

		Dim r As New frmListBoxSearch
		r.ParentListBox = Me
		r.mDb = Db
		r.Recordset = SavedRecordset

		' Show the search form.  If the user makes a search, the
		' form will create a new series of command data and put
		' it into the Label1 caption.  The change event thus
		' triggered will update the list box.

		r.ShowDialog()

		' Show this form again.

		Me.Show()

	End Sub
	' ********************************************************
	'
	' An item is double-clicked.  Call the routine executed
	' by the Okay button.
	'
	' ********************************************************
	Private Sub Picture1_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Picture1.DoubleClick
		btnOkay_Click(btnSelect, New System.EventArgs())
	End Sub

	' ********************************************************
	'
	' The mouse button is pressed in the picture box.
	' Determine from the coordinates which line was clicked
	' and highlight that line if not blank
	'
	' ********************************************************
	Private Sub Picture1_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Picture1.MouseDown

		' Declare variables

		Dim jj As Integer
		Dim Button As Integer = eventArgs.Button \ &H100000
		Dim Shift As Integer = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y

		' Make sure the button which was pressed is the left button.

		If Button = 1 And DisplayLines.Items(0).Line <> "" Then

			' If a previous item was selected, unselect it now

			If SelectItem >= 0 Then DisplayOneLine(SelectItem)

			' Calculate the Display line based upon the Y coordinate
			' of where the mouse was clicked.

			' Get the selected line.

			For jj = 0 To MAXLINES - 1
				If Y >= DisplayLines.Items(jj).Bounds.Y And Y <= DisplayLines.Items(jj).Bounds.Y + DisplayLines.Items(jj).Bounds.Height Then
					SelectItem = jj
					Exit For
				End If
			Next jj

			' Display the line as selected.

			If DisplayLines.Items(SelectItem).Line <> "" Then
				DisplayOneLine(SelectItem, True)
			Else
				SelectItem = -1
			End If

			' Enable or disable the Okay button, depending
			' on whether there is a valid selection or not

			If SelectItem <> 0 Then
				btnSelect.Enabled = True
			Else
				btnSelect.Enabled = False
			End If
		End If
	End Sub


	'**********************************************************
	'
	' The "Search For" field has got the focus. Select the text.
	'
	'**********************************************************
	Private Sub txtSearchFor_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearchFor.Enter
		txtSearchFor.SelectionStart = 0
		txtSearchFor.SelectionLength = Len(txtSearchFor.Text)
	End Sub


	'**********************************************************
	'
	' The "Search For" field has changed.
	'
	'**********************************************************
	Private Sub txtSearchFor_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtSearchFor.TextChanged

		Dim jj As Integer
		Dim zx As String
		Dim SearchDirection As String
		Dim TCode As TypeCode

		' Lock the field while we do this

		txtSearchFor.ReadOnly = True

		' Determine the search direction based on the sort
		' sequence (ascending or descending)

		SearchDirection = ">=" ' Default
		For jj = 0 To UBound(Column, 1)
			If Column(jj).Sorted Then
				If Column(jj).AorDSort = "DESC" Then SearchDirection = "<=" Else SearchDirection = ">="
				Exit For
			End If
		Next jj

		' Search for the supplied string

		If MyTable.Rows.Count > 0 Then TCode = Type.GetTypeCode(MyTable.Rows(0)(SearchField).GetType)
		If TCode = TypeCode.String Then
			zx = "'" & txtSearchFor.Text & "'"
		Else
			If txtSearchFor.Text <> "" Then zx = Format(Val(txtSearchFor.Text)) Else zx = "Null"
		End If
		If CurrentRowIndex >= MyTable.Rows.Count Then CurrentRowIndex = 0
		CurrentRowIndex = Find(MyTable, SearchField & SearchDirection & zx)

		' If we get a "no match" we are greater than the greatest or less than
		' the least match, so (since the recordset is appropriately sorted so that
		' the last record is where we can no longer find a match), move to the
		' last record in the recordset as the closest match.

		If CurrentRowIndex = NOMATCH Then CurrentRowIndex = MyTable.Rows.Count - 1

		' Build a new list that begins with the current row at the
		' top of the display, if possible.  Otherwise, the new list
		' will go to the end of file, and the selected line
		' will move down from the top of the display.

		DontProcessChangeEvent = True
		CurrentTopOfDisplay = CurrentRowIndex
		SelectItem = StartNewListFromSearchMatch()
		VScroll1.Value = CurrentRowIndex
		DontProcessChangeEvent = False

		' Display the new list

		DisplayRecords()
		If SelectItem >= 0 Then DisplayOneLine(SelectItem, True)

		' Unlock the field

		txtSearchFor.ReadOnly = False
	End Sub

	'**********************************************************

	' Sub to refill the display array from the starting
	' point of our search, and return the index of the
	' display array which holds the searched-for value.

	'**********************************************************
	Private Function StartNewListFromSearchMatch() As Integer

		' Declare variables

		Dim jj As Integer
		Dim ii As Integer
		Dim xx As Integer
		Dim MatchRowNumber As Integer

		' Clear the display array to begin

		DisplayLines.Clear()

		' Remember the current row index, since it is the index of
		' the record that first matched our search criteria.

		xx = CurrentRowIndex

		' If the located record is too close to the end of the recordset
		' to completely fill the display, move it back, if possible, to
		' allow a completely filled display.  If not, well, that's just
		' the way it will have to be.

		If CurrentRowIndex + MAXLINES - 1 >= MyTable.Rows.Count Then
			If MyTable.Rows.Count >= MAXLINES Then
				CurrentRowIndex = MyTable.Rows.Count - MAXLINES
			ElseIf MyTable.Rows.Count > 0 Then
				CurrentRowIndex = 0
			End If
		End If

		' Now fill in the display array

		MatchRowNumber = -1 ' Reset
		If CurrentRowIndex < MyTable.Rows.Count Then
			jj = CurrentRowIndex
			ii = 0
			Do

				' Watch for the line on which the searched-for criteria appears
				' in the list, and set the selected item to that line.

				If xx = jj And MatchRowNumber = -1 Then MatchRowNumber = ii ' Select the row on which our matching value resides.

				' Fill the display array
				DisplayLines.Items(ii).Line = BuildDisplayLine(MyTable.Rows(jj))
				DisplayLines.Items(ii).Bookmark = jj

				' Increment row pointers.

				ii += 1
				jj += 1
			Loop While jj < MyTable.Rows.Count And ii < MAXLINES
		End If

		' Return the row number where the searched-for value lies.

		Return MatchRowNumber
	End Function

	'**********************************************************
	'
	' The scroll bar has been moved.
	'
	'**********************************************************
	Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll

		' Declare variables

		Dim xx As Integer

		' Make sure we are supposed to process this event.

		If Not DontProcessChangeEvent Then

			' Clear the selected item

			SelectItem = -1

			' Get the amount of the change in the scroll bar value.

			xx = System.Math.Abs(CurrentTopOfDisplay - eventArgs.NewValue)

			' Move the number or records difference between the old
			' position and the new position.

			If eventArgs.NewValue > CurrentTopOfDisplay Then
				MoveDown(xx)
			ElseIf eventArgs.NewValue < CurrentTopOfDisplay Then
				MoveUp(xx)
			End If

			' Remember the new position of the first record in the
			' display

			CurrentTopOfDisplay = eventArgs.NewValue
		End If

	End Sub

	'**********************************************************
	'
	' The picture box must be redrawn
	'
	'**********************************************************
	Private Sub Picture1_Paint1(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Picture1.Paint

		' Declare variables


		Dim jj As Integer
		Dim b As Button

		' Display Record records.  For each line, clear the
		' picture box with a rectangle and reset x and y before
		' writing the new line.

		For jj = 0 To MAXLINES - 1
			DisplayOneLine(jj, False, e.Graphics)
		Next jj

		' If an item is selected, display it in a menubar

		If SelectItem >= 0 Then DisplayOneLine(SelectItem, True, e.Graphics)

		'If the window is not filled, make the scroll bar invisible

		b = btnColumnHeader_6
		If DisplayLines.Items(MAXLINES - 1).Line = "" Then
			VScroll1.Visible = False
			b.Visible = False
		Else
			VScroll1.Visible = True
			b.Visible = True
		End If

	End Sub

	'**********************************************************
	'
	' Sub to move down a certain number of lines.
	'
	'**********************************************************
	Private Sub MoveDown(ByRef LinesDown As Integer)

		' Declare variables

		Dim ii As Integer
		Dim xx As Integer

		Try
			' If a previous item was selected, unselect it now

			If SelectItem >= 0 Then DisplayOneLine(SelectItem)

			' Position to the last record row number using the bookmark.

			If DisplayLines.Items(MAXLINES - 1).Line <> "" Then
				xx = DisplayLines.Items(MAXLINES - 1).Bookmark

				' Clear the display data

				DisplayLines.Clear()

				' Add the number of lines we are to move to the row number.

				xx += LinesDown

				' If the new row number is larger than the largest row number, 
				' set it to the largest row number.

				If xx >= MyTable.Rows.Count Then xx = MyTable.Rows.Count - 1

				' Now set the current top of the list to the row number minus MAXLINES.

				CurrentTopOfDisplay = xx - (MAXLINES - 1)
				xx = CurrentTopOfDisplay

				' From the start of the new list, get the record information of that row.

				DisplayLines.Items(0).Line = BuildDisplayLine(MyTable.Rows(CurrentTopOfDisplay))
				DisplayLines.Items(0).Bookmark = CurrentTopOfDisplay

				' Now read in MAXLINES -1 more lines to fill the display array.

				For ii = 1 To MAXLINES - 1

					' Advance record row number by 1.

					xx += 1

					' Make sure we are still using valid row numbers.

					If xx >= MyTable.Rows.Count Then Exit For

					' We found another record.  Shuffle the entries to the
					' top, discarding the first entry.  Add the new entry to
					' the bottom.

					DisplayLines.Items(ii).Line = BuildDisplayLine(MyTable.Rows(xx))
					DisplayLines.Items(ii).Bookmark = xx
				Next ii

				' Now redraw the list.

				Picture1.Invalidate()
			End If
		Catch e As Exception
			MsgBox("MoveDown failed." & vbCrLf & e.Message, MsgBoxStyle.Exclamation, "Check List")
		End Try

	End Sub

	'**********************************************************
	'
	' Sub to move up a specified number of lines.
	'
	'**********************************************************
	Private Sub MoveUp(ByRef LinesUp As Integer)

		' Declare variables

		Dim xx As Integer

		Try
			' If a previous item was selected, unselect it now

			If SelectItem >= 0 Then DisplayOneLine(SelectItem)

			' Position to the first record row number using the bookmark.

			If DisplayLines.Items(0).Line <> "" Then
				xx = DisplayLines.Items(0).Bookmark

				' Clear the display data

				DisplayLines.Clear()

				' Subtract the number of lines we are to move to the row number.

				xx -= LinesUp

				' If the new row number is less than zero, set it to zero.

				If xx < 0 Then xx = 0

				' Now set the current top of the list to the row number.

				CurrentTopOfDisplay = xx

				' From the start of the new list, get the record information of that row.

				DisplayLines.Items(0).Line = BuildDisplayLine(MyTable.Rows(CurrentTopOfDisplay))
				DisplayLines.Items(0).Bookmark = CurrentTopOfDisplay

				' Now read in MAXLINES -1 more lines to fill the display array.

				For ii = 1 To MAXLINES - 1

					' Advance record row number by 1.

					xx += 1

					' Make sure we are still using valid row numbers.

					If xx >= MyTable.Rows.Count Then Exit For

					' We found another record.  Shuffle the entries to the
					' top, discarding the first entry.  Add the new entry to
					' the bottom.

					DisplayLines.Items(ii).Line = BuildDisplayLine(MyTable.Rows(xx))
					DisplayLines.Items(ii).Bookmark = xx
				Next ii

				' Now redraw the list.

				Picture1.Invalidate()
			End If

		Catch e As Exception
			MsgBox("MoveUp failed." & vbCrLf & e.Message, MsgBoxStyle.Exclamation, "Check List")
		End Try
	End Sub
	'*********************************************************
	'
	' Sub to read a screenful of Record records from the
	' specified name on.
	'
	'*********************************************************
	Private Sub ReadRecords()

		' Declare variables

		Dim jj As Integer

		' Clear the display array

		DisplayLines.Clear()

		' Set an error trap for problems with the table

		On Error GoTo TableErr

		' Read in the dataset records. Save "MaxLines" of them for
		' display in the window.

		jj = 0
		If MyTable.Rows.Count > 0 Then
			Do
				DisplayLines.Items(jj).Line = BuildDisplayLine(MyTable.Rows(jj))
				DisplayLines.Items(jj).Bookmark = jj
				jj += 1
			Loop While jj < MyTable.Rows.Count And jj < MAXLINES
		End If

		' Set the values for the scroll bar

		If MyTable.Rows.Count > 0 Then
			CurrentRowIndex = 0
			VScroll1.Minimum = 0
			If MyTable.Rows.Count > MAXLINES Then
				VScroll1.Maximum = MyTable.Rows.Count - 1
			Else
				VScroll1.Maximum = VScroll1.LargeChange
			End If
		Else
			VScroll1.Minimum = 0
			VScroll1.Maximum = VScroll1.LargeChange
		End If

		Exit Sub

		' Trap for errors accessing the table

TableErr:
		Resume te1
te1:
	End Sub

	'**********************************************************
	'
	' Function to build a display line from a record
	'
	'**********************************************************
	Private Function BuildDisplayLine(ByRef dr As DataRow) As String

		' Declare variables

		Dim jj As Integer
		Dim FieldType As System.TypeCode
		Dim zx0, zx1 As String

		' Assemble the display line based upon the field types
		' of the displayed columns

		zx0 = ""
		zx1 = ""
		On Error GoTo BuildErr
		For jj = 0 To UBound(Column, 1)

			' Get a text representation of the field's data, based
			' upon the field type

			FieldType = Type.GetTypeCode(MyTable.Columns(Column(jj).Field).DataType)
			If Column(jj).Caption <> "" Then
				If FieldType = TypeCode.Double Or FieldType = TypeCode.Single Then
					If Not IsDBNull(dr(Column(jj).Field)) Then
						If Column(jj).ColumnFormat = "" Then
							If dr(Column(jj).Field) / 100 <> Int(dr(Column(jj).Field) / 100) Then zx1 = Format(dr(Column(jj).Field) / 100, "####.##") Else zx1 = Format(dr(Column(jj).Field) / 100, "######")
						Else
							zx1 = Format(GetR(dr(Column(jj).Field) / 100, Column(jj).ColumnFormat))
						End If
					Else
						zx1 = ""
					End If
				ElseIf FieldType = TypeCode.DateTime Then
					If Not IsDBNull(dr(Column(jj).Field)) Then
						zx1 = Format(dr(Column(jj).Field), " mm/dd/yy ")
					Else
						zx1 = ""
					End If
				ElseIf FieldType = TypeCode.Int16 Or FieldType = TypeCode.Int32 Or FieldType = TypeCode.Int64 Then
					If Not IsDBNull(dr(Column(jj).Field)) Then
						If Column(jj).ColumnFormat = "" Then
							zx1 = GetR(dr, Column(jj).Field)
						Else
							zx1 = Format(GetR(dr, Column(jj).Field), Column(jj).ColumnFormat)
						End If
					Else
						zx1 = ""
					End If
				Else
					zx1 = SRep(GetR(dr, Column(jj).Field), 1, vbCrLf, " ").Trim
				End If

				' Accumulate the fields in the display string

				If jj > 0 Then zx0 = zx0 & vbTab
				zx0 &= zx1
			End If
		Next jj

		' Reentry point if errors occur building the line

Finish:
		On Error GoTo 0
		BuildDisplayLine = zx0
		Exit Function

		' Trap for errors accessing a record

BuildErr:
		If Err.Number = 3167 Then zx0 = "*** DELETED ***"
		Resume Finish
	End Function

	'*********************************************************
	'
	' Sub to display the current display array in the picture
	'
	'*********************************************************
	Public Sub DisplayRecords(Optional ByRef Rebuild As Boolean = False)

		' Declare variables

		Dim jj As Integer

		' See if we are to rebuild the recordset

		If Rebuild Then ReadRecords()

		'If the window is not filled, make the scroll bar invisible

		If DisplayLines.Items(MAXLINES - 1).Line = "" Then VScroll1.Visible = False Else VScroll1.Visible = True

		' Display Record records.  For each line, clear the
		' picture box with a rectangle and reset x and y before
		' writing the new line.

		For jj = 0 To MAXLINES - 1
			DisplayOneLine(jj)
		Next jj

		' If an item is selected, display it in a menubar

		If SelectItem < 0 Or SelectItem > MAXLINES - 1 Then
			SelectItem = -1
		ElseIf DisplayLines.Items(SelectItem).Line <> "" Then
			DisplayOneLine(SelectItem, True)
		Else
			SelectItem = -1
		End If

	End Sub

	'**********************************************************
	'
	' Sub to display the new selection bar on the
	' now-selected line, when the page does not change
	'
	'**********************************************************
	Private Sub DisplayOneLine(ByRef ItemNo As Integer, Optional ByVal Selected As Boolean = False, Optional g As Graphics = Nothing)

		Dim jj As Integer
		Dim x As Single
		Dim zx0 As String
		Dim zx1 As String
		Dim b As Button
		Dim yy As TypeCode
		Dim f As Font = Picture1.Font
		Dim bH As New SolidBrush(SystemColors.Highlight)
		Dim bB As New SolidBrush(SystemColors.Window)
		Dim bN As SolidBrush
		Dim TextSize As System.Drawing.SizeF
		Dim gr As Graphics

		' If we were not passes a graphics, create one from the picture box.

		If g Is Nothing Then gr = Picture1.CreateGraphics Else gr = g

		' Draw a box in the normal window color if not selected, or the
		' highlight color if selected, to clear the line, then set
		' our drawing position.

		If Not Selected Then
			gr.FillRectangle(bB, DisplayLines.Items(ItemNo).Bounds)
		Else
			gr.FillRectangle(bH, DisplayLines.Items(ItemNo).Bounds)
		End If

		' Create the brush to print the text.
		' If the line is normal status, use black for a normal line and
		' white for a selected line; if urgent, use red.
		' If the line is disabled (which means the account numbers have
		' not yet been verified), use gray.

		If Selected Then bN = New SolidBrush(SystemColors.HighlightText) Else bN = New SolidBrush(SystemColors.WindowText)

		' Begin drawing the line column by column

		zx0 = DisplayLines.Items(ItemNo).Line
		jj = 0
		Do While zx0 <> ""
			b = ColumnHeaders(jj + 1)
			zx1 = TextTrim(gr, ParseString(zx0, vbTab), Column(jj).ColumnWidth - MarginWidth, f)
			TextSize = gr.MeasureString(zx1, f)
			yy = Type.GetTypeCode(MyTable.Rows(0)(Column(jj).Field).GetType)
			If yy = TypeCode.Double Or yy = TypeCode.Single Or yy = TypeCode.Int16 Or yy = TypeCode.Int32 Or yy = TypeCode.Int64 Then
				x = b.Left + b.Width - TextSize.Width - INDENT
				gr.DrawString(zx1, f, bN, x, DisplayLines.Items(ItemNo).Bounds.Y)
			Else
				x = b.Left
				gr.DrawString(zx1, f, bN, x, DisplayLines.Items(ItemNo).Bounds.Y)
			End If
			jj += 1
		Loop

		' Dispose of items we've create.

		bH.Dispose()
		bB.Dispose()
		bN.Dispose()
		If g Is Nothing Then gr.Dispose()

	End Sub
	'**********************************************************
	'
	' Function to look up a record by means of the supplied
	' parameters and return whatever ID is requested for it.
	' Input: Title       =  The title of the lookup window
	'        SrchPrompt  =  The prompt for the search field.
	'        ColumnList  =  The column headings to display,separated by commas
	'        SQL         =  The SQL Statement to select records.
	'        KeyFld      =  The name of the field to return as a
	'                        unique record ID.
	'        DefSrch     =  The default value for the search field.
	'        SrchFld     =  The name of the field to search.
	'        FldList     =  The list of fields to be displayed, with
	'                        a comma between each. The name of each
	'                        field may have a specific width appended
	'                        with a filter character, e.g. MyField|10
	'                        plus an optional format field appended with
	'                        another filter character.
	'
	'**********************************************************
	Public Function Lookup(ByRef Db As SqlConnection, ByRef Title As String, ByRef SrchPrompt As String, ByRef ColumnList As String, ByRef SQL As String, ByRef KeyFld As String, ByRef DefaultSrch As String, ByRef SrchFld As String, ByRef FldList As String) As Object

		' Declare variables

		Dim TotalColumnWidth As Integer
		Dim ButtonLeft As Integer
		Dim j1 As Integer
		Dim jj As Integer
		Dim t As Single
		Dim wx As String
		Dim zx As String
		Dim SelectClause As String ' Local instance hides module-level instance.
		Dim ErrList As New Text.StringBuilder
		Dim b As Button

		' Set the size  of the maximum number of lines in the DisplayLines.

		Picture1.Font = New Font("Arial", 8.25)
		t = TextHeight(Picture1, "X")
		MAXLINES = Picture1.ClientRectangle.Height / t
		DisplayLines.Size = MAXLINES
		INDENT = TextWidth(Picture1, "XX")

		' Clear the NewIndex counter

		NewIndex = 0

		' Replace semicolons, if used, with commas as field separators.

		FldList = FldList.Replace(";", ",")
		ColumnList = ColumnList.Replace(";", ",")

		' Get the supplied data connection.  This is a local value of Db, so
		' it can be separate from the global Db; for example, to perform
		' a lookup into a separate database.

		If Not Db Is Nothing Then Me.Db = Db

		' If the database object is not set, exit and do
		' nothing.

		If Me.Db Is Nothing Then Return -1

		' Make sure the select statement contains either "*" or the names
		' of all the fields specified as arguments.

		SelectClause = Regex.Match(SQL, "(?i)SELECT\s+(.*?)\s+FROM").Groups(1).Value
		If Not SelectClause.Contains("*") Then
			If Not SelectClause.ToLower.Contains(KeyFld.ToLower) Then ErrList.Append("SELECT statement does not include key field '" & KeyFld & "'." & vbCrLf)
			If Not SelectClause.ToLower.Contains(SrchFld.ToLower) Then ErrList.Append("SELECT statement does not include search field '" & SrchFld & "'." & vbCrLf)
			wx = FldList
			Do While wx <> ""
				zx = ParseString(wx)
				If Not SelectClause.ToLower.Contains(ParseString(zx, "|").ToLower) Then ErrList.Append("SELECT statement does not include display field '" & zx & "'." & vbCrLf)
			Loop

			' If we found errors, report them and exit.

			If ErrList.Length > 0 Then
				MsgBox(ErrList.ToString, MsgBoxStyle.Information, "Lookup Box Argument Errors")
				Return Nothing
			End If
		End If

		' Fill in the lookup parameters, except the field list, which
		' cannot be done until we have the table opened, and THAT
		' cannot happen until the Recordset property is set.

		With Me
			.Title = Title
			.Prompt = SrchPrompt
			.ListBoxPrompt = ColumnList
			.Recordset = SQL
			.ReturnField = KeyFld
			.SearchID = DefaultSrch
			.SearchField = SrchFld
		End With

		' Get the dataset and records table

		MyDS.Clear()
		MyDA.SelectCommand = New SqlCommand(SQL, Db)
		MyDA.Fill(MyDS, "Table")
		MyTable = MyDS.Tables("Table")

		' NOW we can set the field list property

		Me.FieldList = FldList

		' Set the default value of the lookup function

		Lookup = 0

		' Get the width of the margin for each column

		MarginWidth = TextWidth(Picture1, "X")

		' Make visible the column buttons 1 through what-
		' ever and fill in their descriptions.

		ButtonLeft = Picture1.Left
		TotalColumnWidth = 0
		j1 = 0
		For jj = 0 To UBound(Column, 1)
			System.Windows.Forms.Application.DoEvents()

			' create a new button and add it to the columnheaders collection

			b = New Button

			' Calculate the overall width of the window, set the
			' position of each button and keep track of where
			' the next button begins ("left" property)

			TotalColumnWidth = TotalColumnWidth + Column(jj).ColumnWidth
			b.Left = ButtonLeft
			ButtonLeft = ButtonLeft + Column(jj).ColumnWidth

			' Set remaining button properties

			With b
				.Text = Column(jj).Caption
				.Width = Column(jj).ColumnWidth
				.Top = Picture1.Top - 24
				.Name = "btnColumnHeader_" & j1
				.FlatStyle = FlatStyle.Flat
			End With

			' Set the event handler for the button and add it to the ColumnHeaders collection

			Me.Controls.Add(b)
			AddHandler b.Click, AddressOf btnColumnHeader_Click
			ColumnHeaders.Add(b)

			j1 += 1 ' Keep track of buttons
		Next jj

		' If necessary, make the window and form wider to display
		' all columns, then reposition the scroll bar and buttons.

		Me.Height = 420
		If TotalColumnWidth > Picture1.Width Then
			Picture1.Width = TotalColumnWidth
			Me.Width = Picture1.Left + Picture1.Width + btnSelect.Width + 50
			VScroll1.Left = Picture1.Left + Picture1.Width
			btnSelect.Left = Picture1.Left + Picture1.Width + 25
			btnCancel.Left = Picture1.Left + Picture1.Width + 25
			btnSearch.Left = Picture1.Left + Picture1.Width + 25

			' Make the last button as wide as the remaining
			' width of the window

		ElseIf TotalColumnWidth < Picture1.Width Then
			b = New Button
			b.Width = Picture1.Width - TotalColumnWidth
			b.Visible = True
			b.Enabled = False
			b.Left = ButtonLeft
			b.Top = Picture1.Top - 24
			b.Name = "btnColumnHeader_" & j1
			b.FlatStyle = FlatStyle.Flat

			' Set the event handler for the button and add it to the ColumnHeaders collecxtion

			Me.Controls.Add(b)
			AddHandler b.Click, AddressOf btnColumnHeader_Click
			ColumnHeaders.Add(b)
		End If

		' Make the button over the scroll bar visible

		b = btnColumnHeader_6
		b.Width = VScroll1.Width
		b.Left = ButtonLeft
		b.Visible = True
		b.Enabled = False

		' Calculate the boundries of each line. The "Clear" method of the
		' DisplayLines class will not erase these bounds, once set.  To
		' completely reset DisplayLines, use the Size property.

		For jj = 0 To MAXLINES - 1
			DisplayLines.Items(jj).Bounds.X = 0
			DisplayLines.Items(jj).Bounds.Width = Picture1.ClientRectangle.Width
			DisplayLines.Items(jj).Bounds.Y = jj * t
			DisplayLines.Items(jj).Bounds.Height = t
		Next


		' Read the record list

		ReadRecords()

		' Set the indicator for the top of the display

		CurrentTopOfDisplay = 0
		VScroll1.Value = 0

		' Set the values for the scroll bar

		VScroll1.Minimum = 0
		VScroll1.SmallChange = 1
		VScroll1.Maximum = MyTable.Rows.Count - 1
		VScroll1.LargeChange = MAXLINES

		' If the list box is not empty, select the first item
		' as default

		If DisplayLines.Items(0).Line <> "" Then
			SelectItem = 0
			btnSelect.Enabled = True
		Else
			SelectItem = -1
			btnSelect.Enabled = False
		End If

		' Set the value of the search field to be the default

		If SearchID <> "" Then txtSearchFor.Text = SearchID
		On Error GoTo 0

		' Center the window

		Me.Left = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - Me.ClientRectangle.Width) / 2

		' Display the form modally

		Me.ShowDialog()

		' Return the key

		Lookup = Me.SelectedItemKey

	End Function

	'**************************************************
	'
	' The recordset property.
	'
	'**************************************************

	Public Property Recordset() As String
		Get

			Recordset = RecordsetName

		End Get
		Set(ByVal Value As String)

			' If we've passed a blank recordset, just to clear things out,
			' then do nothing

			If Value = "" Then
				OriginalRecordset = ""
				Exit Property
			End If

			' Store the new recordset name

			RecordsetName = Value

			' Clear the dataset.

			MyDS.Clear()

			' Get the recordset property.  It consists of an SQL
			' statement to create the recordset.

			' If no valid SQL statement is found, display an error message
			' and exit the property.

			On Error GoTo DataErr
			If RecordsetName.ToUpper.IndexOf("SELECT") < 0 Then
				MsgBox("No valid SQL Statement supplied.", MsgBoxStyle.Exclamation, "Recordset Let Property")
				Exit Property
			End If

			' Remember the text of the SQL statement the first time only.

			OriginalRecordset = RecordsetName

			' Begin parsing the SQL statement to extract the table name, where, and order by clauses.

			SelectClause = Regex.Match(RecordsetName, "(?i)\b(SELECT\s+.*?)(?=\s+FROM\b)").Groups(1).Value
			TableName = Regex.Match(RecordsetName, "(?i)\bFROM\s+(.*?)(?=\bWHERE\b|\bGROUP\b|\bORDER\b|\bSELECT\b|$)").Groups(1).Value
			WhereClause = Regex.Match(RecordsetName, "(?i)(WHERE\s+.*?)(?=\s+ORDER\s+BY|$)").Groups(1).Value
			OrderByClause = Regex.Match(RecordsetName, "(?i)(ORDER\s+BY\s+.*)").Groups(1).Value

			' Create the Recordset

			MyDA.SelectCommand = New SqlCommand(RecordsetName, Db)
			MyDA.Fill(MyDS, "Table")

			Exit Property

			' Trap for errors on data access

DataErr:
			Resume de1
de1:

		End Set
	End Property

	'**************************************************
	'
	' The Lookup title is queried.
	'
	'*************************************************

	'**************************************************
	'
	' The lookup title property is set
	'
	'**************************************************
	Public Property Title() As String
		Get
			Title = TitleText
		End Get
		Set(ByVal Value As String)
			TitleText = Value
			Me.Text = TitleText
		End Set
	End Property

	'**************************************************
	'
	' The Search ID property is queried.
	'
	'**************************************************

	'**************************************************
	'
	' The Search ID property is set.
	'
	'**************************************************
	Public Property SearchID() As String
		Get
			SearchID = SearchText
		End Get
		Set(ByVal Value As String)
			SearchText = Value
		End Set
	End Property


	'**************************************************
	'
	' The ConnectionString property.
	'
	'**************************************************

	Public Property ConnectionString() As String
		Get

			If Db Is Nothing Then ConnectionString = "" Else ConnectionString = Db.ConnectionString

		End Get
		Set(ByVal Value As String)

			' Save the database file name

			DatabaseFileName = Value

			' If the new value is empty, close and destroy the
			' database variable, if there is one.

			If DatabaseFileName = "" Then
				Db.Close()

				' Otherwise, attempt to open the specified database.

			Else
				Dim cs As New SqlConnectionStringBuilder()
				cs.Add("Data Source", ServerName)
				cs.Add("AttachDbFilename", DatabaseFileName)
				cs.Add("Integrated Security", True)
				cs.Add("Connect Timeout", "15")
				Db.ConnectionString = cs.ConnectionString
				Db.Open()
			End If

			Exit Property

			' Trap for errors opening the database

CantOpen:
			Db = Nothing
			DatabaseFileName = ""
			Resume Next

		End Set
	End Property


	'**************************************************
	'
	' The selected item key is queried.
	'
	'**************************************************
	Public ReadOnly Property SelectedItemKey() As Object
		Get
			SelectedItemKey = ReturnKey
		End Get
	End Property



	'**************************************************
	'
	' The field list property.
	'
	'**************************************************

	Public Property FieldList() As String
		Get
			FieldList = FieldListText
		End Get
		Set(ByVal Value As String)

			' Declare variables

			Dim FldWidth As Integer
			Dim p1 As Integer
			Dim p2 As Integer
			Dim xx As Integer
			Dim yy As Integer
			Dim zz As Integer
			Dim FldFormat As String
			Dim zx0 As String
			Dim zx1 As String
			Dim TCode As TypeCode

			' Save the field list in the local variable

			FieldListText = Value

			' Replace any (legal) semicolons with commas

			zx0 = Value.Replace(";", ",")

			' Parse the field list for the list of columns

			Try
				xx = 0
				Do

					' Extract the name of the field and save it as the
					' name of the field and column header, if no column
					' header is yet defined.

					If xx > UBound(Column, 1) Then ReDim Preserve Column(xx)
					zx1 = ParseString(zx0)
					Column(xx).Field = zx1
					If Column(xx).Caption = "" Then Column(NewIndex).Caption = ParseString(zx1, "|")

					' If the field is the same as the search field, make it sorted

					zx1 = Column(xx).Field
					If SearchField = ParseString(zx1, "|") Then
						Column(xx).AorDSort = "ASC"
						Column(xx).Sorted = True
					Else
						Column(xx).AorDSort = ""
						Column(xx).Sorted = False
					End If

					' Look for filter characters which mark optional specifiers for a
					' field.

					p1 = Column(xx).Field.IndexOf("|")
					p2 = Column(xx).Field.IndexOf("|", p1 + 1)

					' Look for optional field widths and/or field formats

					FldWidth = 0
					FldFormat = ""
					If p1 > 0 Then
						FldWidth = Val(Column(xx).Field.Substring(p1 + 1))
						If p2 >= 0 Then FldFormat = Column(xx).Field.Substring(p2 + 1)
						Column(xx).Field = Column(xx).Field.Substring(0, Column(xx).Field.IndexOf("|"))
					End If
					Column(xx).ColumnFormat = FldFormat

					' Determine how wide the column is to be.  A specific
					' width may be specified after each field name
					' by appending a filter and the width (e.g. MyField|25)

					If MyTable.Rows.Count > 0 Then
						TCode = Type.GetTypeCode(MyTable.Rows(0)(Column(xx).Field).GetType)
						If FldWidth > 0 Then
							yy = FldWidth
						ElseIf TCode = TypeCode.String Then
							yy = Len(MyTable.Rows(0)(Column(xx).Field)) ' Since strings come with trailing blanks to the length of the field this tells us the length.
							If yy > 30 Then yy = 30
						ElseIf TCode = TypeCode.DateTime Then
							yy = 10
						Else
							yy = 9
						End If
					Else
						yy = 9
					End If

					' Set the column width

					zz = TextWidth(Picture1, New String("X", yy))
					If zz < TextWidth(Picture1, Column(xx).Caption & "XX") Then zz = TextWidth(Picture1, Column(xx).Caption & "XX")

					' Store the column width

					Column(xx).ColumnWidth = zz
					xx += 1

				Loop While zx0 <> ""
			Catch ex As Exception
				MsgBox(ex.Message)
			End Try

		End Set
	End Property

	'**************************************************
	'
	' The prompt property.
	'
	'**************************************************

	Public Property Prompt() As String
		Get
			Prompt = PromptText
		End Get
		Set(ByVal Value As String)

			PromptText = Value
			Label1.Text = PromptText

		End Set
	End Property

	'**************************************************
	'
	' The return field name property.
	'
	'**************************************************

	Public Property ReturnField() As String
		Get
			ReturnField = ReturnFieldName
		End Get
		Set(ByVal Value As String)
			ReturnFieldName = Value
		End Set
	End Property

	'**************************************************
	'
	' The list box prompt property.
	'
	'**************************************************

	Public Property ListBoxPrompt() As String
		Get
			ListBoxPrompt = ListBoxPromptText
		End Get
		Set(ByVal Value As String)

			' Declare variables

			Dim zx0 As String
			Dim xx As Integer

			' Save the new value in the local variable

			ListBoxPromptText = Value

			' Make sure the columns collection contains at
			' least one item.

			If NewIndex = 0 Then ReDim Column(1)

			' Replace any (legal) semicolons with commas

			zx0 = Value
			zx0 = SRep(zx0, 1, ";", ",")

			' Parse the field list for the list of columns

			xx = 0
			Do

				' Extract the name of the field and save it as the
				' name of the column header.

				If xx > UBound(Column, 1) Then ReDim Preserve Column(xx)
				Column(xx).Caption = ParseString(zx0)
				xx += 1

			Loop While zx0 <> ""

		End Set
	End Property

	'**************************************************
	'
	' The search field property.
	'
	'**************************************************

	Public Property SearchField() As String
		Get
			SearchField = SearchFieldName
		End Get
		Set(ByVal Value As String)
			SearchFieldName = Value
		End Set
	End Property

End Class
