Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmSelectBackup
	Inherits System.Windows.Forms.Form
	'**********************************************************
	' Sirius Cook SQL Backup Selection
	' SIRIUSCOOK_SELECTBACKUP.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1993-2017 Sirius Software All Rights Reserved
	'**********************************************************

	' Declare variables which are properties of this form

	Public SelectedBackup As String

	'************************************************************************************

	' The form is loaded

	'************************************************************************************
	Private Sub frmSelectBackup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		' Declare variables

		Dim zx As String
		Dim dt As Date

		' Fill the listbox with the names and dates of the backups

		ListBox1.Items.Clear()
		For Each zx In My.Computer.FileSystem.GetFiles(BackupPath, FileIO.SearchOption.SearchTopLevelOnly, "*.mdf.sc.sun", "*.mdf.sc.mon", "*.mdf.sc.tue", "*.mdf.sc.wed", "*.mdf.sc.thu", "*.mdf.sc.fri", "*.mdf.sc.sat")
			dt = My.Computer.FileSystem.GetFileInfo(zx).LastWriteTime
			ListBox1.Items.Add(SRep(zx, 1, BackupPath, "", 1) & vbTab & CStr(dt.Date) & vbTab & dt.Hour & ":" & Format(dt.Minute, "00"))
		Next zx

	End Sub
	'************************************************************************************

	' An item is selected from the list box

	'************************************************************************************
	Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
		cmdOkay.Enabled = True
	End Sub

	'************************************************************************************

	' An item is double-clicked

	'************************************************************************************
	Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
		cmdOkay_Click(cmdOkay, New System.EventArgs)
	End Sub

	'************************************************************************************

	' The Okay button is clicked

	'************************************************************************************
	Private Sub cmdOkay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOkay.Click

		' Strip off the date and time of the selected backup.

		SelectedBackup = ParseString(ListBox1.SelectedItem, vbTab)

		' Return an Okay dialog result and close the window.

		Me.DialogResult = Windows.Forms.DialogResult.OK

		Me.Close()

	End Sub
	'************************************************************************************

	' Sub to perform the drawing of the Backup Selection list box.

	'************************************************************************************
	Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem

		' Declare variables

		Dim DBNameRect As New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width * 0.6, e.Bounds.Height)
		Dim BackupDateRect As New RectangleF(e.Bounds.X + e.Bounds.Width * 0.6, e.Bounds.Y, e.Bounds.Width * 0.2, e.Bounds.Height)
		Dim BackupTimeRect As New RectangleF(e.Bounds.X + e.Bounds.Width * 0.8, e.Bounds.Y, e.Bounds.Width * 0.2, e.Bounds.Height)
		Dim zx As String
		Dim DBName As String
		Dim BackupDate As String
		Dim BackupTime As String
		Dim bN As Brush
		Dim f As Font
		Dim fB As New Font("Arial", 8, FontStyle.Bold)

		' Draw the background of the ListBox control for each item.

		e.DrawBackground()

		'Parse the item to extract the description and OnHand

		zx = sender.Items(e.Index).ToString
		DBName = ParseString(zx, vbTab)
		BackupDate = ParseString(zx, vbTab)
		BackupTime = zx

		' Set the drawing color and font

		bN = Brushes.Black
		f = e.Font

		' If the "item" is a long dash, then draw a line across for the item

		If sender.Items(e.Index).ToString = Chr(151) Then
			e.Graphics.DrawLine(Pens.Blue, e.Bounds.X, CInt(e.Bounds.Y + e.Bounds.Height / 2), e.Bounds.X + e.Bounds.Width, CInt(e.Bounds.Y + e.Bounds.Height / 2))

			' Draw the current item text based on the current Font and the custom brush settings.

		Else
			e.Graphics.DrawString(DBName, f, bN, DBNameRect)
			e.Graphics.DrawString(BackupDate, f, bN, BackupDateRect.X + BackupDateRect.Width - e.Graphics.MeasureString(BackupDate & "X", f).Width, BackupDateRect.Y)
			e.Graphics.DrawString(BackupTime, f, bN, BackupTimeRect.X + BackupTimeRect.Width - e.Graphics.MeasureString(BackupTime & "X", f).Width, BackupTimeRect.Y)
		End If

		' If the ListBox has focus, draw a focus rectangle around the selected item.

		e.DrawFocusRectangle()

		' Dispose of objects we've created

		fB.Dispose()

	End Sub

End Class