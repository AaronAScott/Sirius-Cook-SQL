Public Class frmMaintainLinks
    '*******************************************************************
    ' SiriusCook Maintain Recipe Links form (frmMaintainLinks)
    ' SIRIUSCOOK_MAINTAINLINKS.VB
    ' Written: December 2018
    ' Programmer: Aaron Scott
    ' Copyright 2018 Sirius Software All Rights Reserved
    '*******************************************************************

    ' Declare variables local to this module.

    Private SelectedRecipeID As Integer
    Private LinksDS As New DataSet
    Private LinksTable As DataTable

	'*******************************************************************

	' The form is loaded.

	'*******************************************************************
	Private Sub frmMaintainLinks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		' Get the list of defined links.

		GetLinks()

	End Sub
	'*******************************************************************

	' The form is closed.

	'*******************************************************************
	Private Sub frmMaintainLinks_FormClosed(sender As Object, e As EventArgs) Handles MyBase.FormClosed

		' Destroy objects we've created.

		LinksDS.Dispose()

	End Sub

	'*******************************************************************

	' The form is closed.

	'*******************************************************************
	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub

	'*******************************************************************

	' An item is selected from the list box.

	'*******************************************************************
	Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

		' Declare variables.

		Dim xx As Integer
		Dim zx As String
		Dim f As frmAddLink

		' If an existing link was selected, move its data into the field
		' so it can be edited.

		If ListBox1.SelectedIndex > 0 Then
			zx = ListBox1.Items(ListBox1.SelectedIndex)
			SelectedRecipeID = Val(ParseString(zx, vbTab))
			xx = Find(LinksTable, "ID=" & SelectedRecipeID)
			If xx <> NOMATCH Then TextBox1.Text = LinksTable.Rows(xx)("LinkText")

			' Enable the link text textbox and the save, delete and cancel buttons.

			EnableControls(True)

			' If "Add New Link" was selected, display the new link dialog.

		Else
			SelectedRecipeID = 0
			TextBox1.Text = ""
			f = New frmAddLink
			f.ShowDialog()
			GetLinks()
		End If


	End Sub

	'*******************************************************************

	' The cancel button is clicked.

	'*******************************************************************
	Private Sub btnCancel_Click1(sender As Object, e As EventArgs) Handles btnCancel.Click

		EnableControls(False)
		SelectedRecipeID = 0
		TextBox1.Text = ""

	End Sub

	'*******************************************************************

	' The delete button is clicked.

	'*******************************************************************
	Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

		' Declare variables

		Dim xx As Integer

		' Find the record of the link to delete.

		xx = Find(LinksTable, "ID=" & SelectedRecipeID)
		If xx <> NOMATCH Then
			LinksTable.Rows(xx).Delete()
			LinksDA.Update(LinksTable)
		End If

		' Clear the fields and disable the controls.

		SelectedRecipeID = 0
		TextBox1.Text = ""
		EnableControls(False)

	End Sub

	'*******************************************************************

	' The save button is clicked.

	'*******************************************************************
	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

		' Declare variables

		Dim xx As Integer

		' Find the record of the link to save.

		xx = Find2(LinksTable, "ID=" & SelectedRecipeID)
		If xx <> NOMATCH Then
			LinksTable.Rows(xx)("LinkText") = TextBox1.Text
			LinksDA.Update(LinksTable)
		End If

		' Clear the fields and disable the controls.

		SelectedRecipeID = 0
		TextBox1.Text = ""
		EnableControls(False)

		' Recreate the list of links.

		GetLinks()

	End Sub

	'*******************************************************************

	' Sub to enable/disable the form's controls.

	'*******************************************************************
	Private Sub EnableControls(State As Boolean)
		Label2.Enabled = State
		TextBox1.Enabled = State
		btnSave.Enabled = State
		btnDelete.Enabled = State
		btnCancel.Enabled = State

	End Sub
	'*******************************************************************

	' Sub to fill the list box with the list of defined links.

	'*******************************************************************
	Private Sub GetLinks()

		' Declare variables

		Dim jj As Integer

		' Fill the list box.

		ListBox1.Items.Clear()
		ListBox1.Items.Add("0" & vbTab & "(Add New Link)")
		LinksDS.Clear()
		LinksDA.Fill(LinksDS, "Table")
		LinksTable = LinksDS.Tables("Table")
		If LinksTable.Rows.Count > 0 Then
			For jj = 0 To LinksTable.Rows.Count - 1
				ListBox1.Items.Add(LinksTable.Rows(jj)("ID") & vbTab & LinksTable.Rows(jj)("LinkText"))
			Next jj
		End If

	End Sub

	Private Sub ListBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox1.DrawItem

		Dim g As Graphics = e.Graphics
		Dim xx As String
		Dim zx As String = ListBox1.Items(e.Index)

		' Draw the background of the ListBox control for each item.

		' Extract and discard the link record ID.

		xx = ParseString(zx, vbTab)

		e.DrawBackground()

		g.DrawString(zx, e.Font, New SolidBrush(e.ForeColor), e.Bounds)


	End Sub
End Class