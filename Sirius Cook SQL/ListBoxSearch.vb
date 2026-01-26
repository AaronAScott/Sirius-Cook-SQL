Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Friend Class frmListBoxSearch
	Inherits System.Windows.Forms.Form
	'**********************************************************
	' Table Search Form for Visual Basic programs.
	' LISTBOXSEARCH.VB
	' Written: April 2007
	' Updated: July 2025
	' Programmer: Aaron Scott
	' Copyright (C) 1994-2025 Sirius Software All Rights Reserved
	'**********************************************************

	' Define the variables local to this module

	Private DatabaseFileName As String
	Private RecordsetName As String
	Private TableName As String
	Private SelectClause As String
	Private WhereClause As String
	Private OrderByClause As String
	Private MyDA As New SqlDataAdapter
	Private MyDS As New DataSet
	Private MyTable As New DataTable
	Private CurrentRow As DataRow

	' Define variables which are properties of this
	' object

	Public ParentListBox As frmListBox
	Public mDb As SqlConnection

	'**************************************************
	'
	' The database name property is queried.
	'
	'**************************************************


	'**************************************************
	'
	' The database name property is set.
	'
	'**************************************************
	Public Property Databasename() As String
		Get

			Databasename = DatabaseFileName

		End Get
		Set(ByVal Value As String)

			' Save the database file name

			DatabaseFileName = Value

			' If the new value is empty, close and destroy the
			' database variable, if there is one.

			If DatabaseFileName = "" Then
				mDb.Close()
				mDb = Nothing
			End If

			Exit Property

			' Trap for errors opening the database

CantOpen:
			mDb = Nothing
			DatabaseFileName = ""
			Resume Next

		End Set
	End Property
	'**************************************************
	'
	' The recordset property
	'
	'**************************************************
	Public Property Recordset() As String
		Get
			Recordset = RecordsetName
		End Get
		Set(ByVal Value As String)

			' Declare variables

			Dim jj As Integer
			Dim zz As Integer
			Dim mRec As New SqlDataAdapter
			Dim mDS As New DataSet

			' Save the new value in our local variable

			RecordsetName = Value

			' If no select statement is found then get table
			' name.

			zz = RecordsetName.ToUpper.IndexOf("SELECT")
			If zz < 0 Then
				SelectClause = ""

				' If an index was specified, the table name is  before
				' the comma.  Otherwise, a table name is all we've got.

				If RecordsetName.Contains(",") Then
					TableName = RecordsetName.Substring(RecordsetName.IndexOf(",")).Trim
				Else
					TableName = RecordsetName.Trim
				End If

				' Open the table with no select and no sort options.

				mRec.SelectCommand = New SqlCommand("SELECT * FROM " & TableName, mDb)

				' Otherwise extract needed information from the
				' SQL statement.

			Else

				' Begin parsing the SQL statement to extract the table name, where, and order by clauses.

				SelectClause = Regex.Match(RecordsetName, "(?i)SELECT\s+(.*?)\s+FROM").Groups(1).Value
				TableName = Regex.Match(RecordsetName, "(?i)FROM\s+([^\s]+)").Groups(1).Value
				WhereClause = Regex.Match(RecordsetName, "(?i)WHERE\s+(.*?)\s*(ORDER BY|$)").Groups(1).Value
				OrderByClause = Regex.Match(RecordsetName, "(?i)ORDER BY\s+(.*)").Groups(1).Value

				' Open the table

				mRec.SelectCommand = New SqlCommand(SelectClause & " " & WhereClause & " " & OrderByClause, mDb)
			End If

			' Display the name of the table

			Label2.Text = TableName

			' Fill the combo box with the names of fields in
			' this recordset

			If Not (mDb Is Nothing) Then
				Try
					Combo1.Items.Clear()
					mRec.Fill(mDS, "Table")
					For jj = 0 To mDS.Tables("Table").Columns.Count - 1
						Combo1.Items.Add(mDS.Tables("Table").Columns(jj).ColumnName)
					Next jj
					If Combo1.Items.Count > 0 Then Combo1.SelectedIndex = 0
				Catch ex As Exception
					MsgBox("Failed to build Search recordset." & vbCrLf & ex.Message, MsgBoxStyle.Information, "Search Failure")
				End Try
			End If

			' Dispose of objects we've created.

			mRec.Dispose()
			mDS.Dispose()

		End Set
	End Property
	'**********************************************************
	'
	' The search button is selected.
	'
	'**********************************************************
	Private Sub cmdSearch_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSearch.Click

		' Declare variables

		Dim zx1 As String = ""

		' Assemble an SQL statement depending upon the search type.

		' The search is on the start of the field

		If Option1_0.Checked = True Then
			WhereClause = " WHERE Left([" & Combo1.SelectedItem & "], " & CStr(Text1.Text.Length) & ") = '" & Text1.Text & "'"

			' The search is on the entire field

		ElseIf Option1_1.Checked = True Then
			If Option2_0.Checked = True Then zx1 = " = "
			If Option2_1.Checked = True Then zx1 = " >= "
			If Option2_2.Checked = True Then zx1 = " <= "
			WhereClause = " WHERE [" & Combo1.SelectedItem & "]" & zx1 & "'" & Text1.Text & "'"

			' The search is on any part of the field.

		Else
			WhereClause = " WHERE [" & Combo1.SelectedItem & "] LIKE ('%" & Text1.Text & "%')"
		End If

		' Reset the "Where" property of the list form

		ParentListBox.Recordset = SelectClause & WhereClause & " " & OrderByClause

		' Redisplay the new list

		ParentListBox.DisplayRecords(True)

		' Changing that property triggers an event which will
		' update the window.  We're done.  It's Miller Time.
		' Unload the form.

		Me.Close()

	End Sub

	'**********************************************************
	'
	' The cancel button is clicked. Unload the form.
	'
	'**********************************************************
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		Me.Close()
	End Sub
	'**********************************************************
	'
	' One of the Search Type options is selected.
	'
	'**********************************************************
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1_0.CheckedChanged, Option1_1.CheckedChanged, Option1_2.CheckedChanged

		If eventSender.Checked Then

			' If the "Start of Field" option is selected, disable
			' all the "Match Fields" options

			If eventSender Is Option1_0 Then
				Option2_0.Enabled = False
				Option2_1.Enabled = False
				Option2_2.Enabled = False
			End If

			' If the "Entire Field" option is selected, enable all the
			' "Match Fields" options

			If eventSender Is Option1_1 Then
				Option2_0.Enabled = True
				Option2_1.Enabled = True
				Option2_2.Enabled = True
			End If

			' If the "Any Part of Field" option is selected, disable
			' the "Match Fields" options

			If eventSender Is Option1_2 Then
				Option2_0.Enabled = False
				Option2_1.Enabled = False
				Option2_2.Enabled = False
			End If

		End If
	End Sub

	'**********************************************************
	'
	' The text in the search box has changed.
	'
	'**********************************************************
	Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged

		' If the search for text is not blank, enable the search
		' button.  Otherwise, disable it.

		If Text1.Text <> "" Then cmdSearch.Enabled = True Else cmdSearch.Enabled = False

	End Sub

End Class