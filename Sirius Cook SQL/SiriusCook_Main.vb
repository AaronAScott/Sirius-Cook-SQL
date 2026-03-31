Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Imports VB = Microsoft.VisualBasic

Friend Class frmMain
	Inherits System.Windows.Forms.Form
	'**************************************************
	' SiriusCook SQL SQL Main form
	' SIRIUSCOOK_MAIN.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2018 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables that are the properties of this module

	Public picBookshelf As Collection
	Public gLibrary As New Library

	' Declare variables local to this module.

	Private IsInitializing As Boolean

	'**********************************************************
	'
	' The form is loaded.  Initialize the program
	'
	'**********************************************************
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		' Declare variables

		Dim zx As String
		Dim zx0 As String
		Dim MainWinState, MainWinWidth, MainWinTop, MainWinLeft, MainWinHeight As Integer

		' Indicate the main form is initialing.

		IsInitializing = True

		' Set the global variables for the name of the system,
		' the name of the database and the version

		ProgramName = "Sirius Cook SQL"
		Version = CStr(My.Application.Info.Version.Major) & "." & CStr(My.Application.Info.Version.Minor) & CStr(My.Application.Info.Version.Build) & CStr(My.Application.Info.Version.MinorRevision)
		DBVersion = "1.08"
		Dependencies.Add(New Dependency("PromptedTextBox", "dll", "PromptedTextBox"))
		Dependencies.Add(New Dependency("SE_MailSender", "dll", "SE_MailSender"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "SiriusCook Master.mdf.template"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "Microsoft.Web.WebView2.Core.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "Microsoft.Web.WebView2.WinForms.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "Microsoft.Web.WebView2.Wpf.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "BouncyCastle.Cryptography.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "MailKit.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "MimeKit.dll"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "Recipes.mdf"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "README.md"))
		Dependencies.Add(New Dependency("SiriusCookSQL", "file", "LICENSE.md"))

		' Check for program updates first thing.

		CheckForUpdates()

		' Show the logo while we start up

		Logo.lblVersion.Text = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		Logo.Show()
		System.Windows.Forms.Application.DoEvents()

		' Get the path to the program.

		ProgramPath = AddDirSeparator(My.Application.Info.DirectoryPath)

		' Get the saved main window sizes, if any

		zx = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "MainWindow", "Size", "0,0,0,1042,727,0")
		MainWinState = Val(ParseString(zx))
		MainWinLeft = Val(ParseString(zx))
		MainWinTop = Val(ParseString(zx))
		MainWinWidth = Val(ParseString(zx))
		MainWinHeight = Val(zx)

		' Set the size of the main window from the saved sizes

		If MainWinState = 0 Then
			If MainWinHeight > 0 Then Me.Height = MainWinHeight
			If MainWinWidth > 0 Then Me.Width = MainWinWidth
			Me.Top = MainWinTop
			Me.Left = MainWinLeft
		Else
			Me.WindowState = MainWinState
		End If

		' Get the location of the backup databases

		BackupPath = AddDirSeparator(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "BackupPath", My.Application.Info.DirectoryPath))

		' See if there is an auto-open database specified.

		Databasename = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpen", "")

		' If auto-open last is set up, then open that instead

		zx0 = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpenLast")
		If zx0 = "True" Then
			zx0 = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "MRUList", "1", "")
			If zx0 <> "" Then Databasename = zx0
		End If

		' Get the database name from the command line, if
		' supplied.  This overrides any auto-open database.

		If VB.Command() <> "" Then Databasename = VB.Command()

		' If the database name was supplied, open it now

		If Databasename <> "" Then DbOpen = OpenADatabase(Databasename, False)

		' Set the background color of the "bookshelf"

		Me.BackColor = Choose(Val(ProgramColorTheme(ThemeItem.MainWindow)), Color.Black, SystemColors.Window, Color.FromArgb(255, 189, 182, 255), Color.Tan)

		' If the database is open, assign it to the library
		' object.

		If DbOpen Then
			gLibrary.Show()
			ResetScrollBar()
		End If

		' Display the MRU menu items, if there are any

		FillMRU()

		' Set the minimum and maximum for the scroll bar

		HScroll1.Minimum = -Screen.GetBounds(HScroll1).Width
		HScroll1.Maximum = Screen.GetBounds(HScroll1).Width
		HScroll1.Value = 0 ' Center the thumb

		' Indicate the main form is finished initialing.

		IsInitializing = False
	End Sub

	'**********************************************************
	'
	' The main form is about to be unloaded.
	'
	'**********************************************************
	Private Sub frmMain_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

		' Declare variables


		If IsInitializing Then eventArgs.Cancel = True

		' If the user has changed the database, see if they
		' want to back it up

		If DbOpen = True AndAlso DatabaseChanged = True AndAlso Not CBool(GetControlItem("IsTestDB", "False")) Then

			' If the user has changed the database, see if they
			' want to back it up

			If DbOpen And DatabaseChanged = True Then
				If MsgBox("You have updated the database (" & LCase(Databasename) & ").  Do you want to back it up before exiting?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "Exit " & ProgramName) = MsgBoxResult.Yes Then BackupDatabase(Databasename)
			End If

		End If

	End Sub
	'**********************************************************
	'
	' The form is unloaded.
	'
	'**********************************************************
	Private Sub frmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Declare variables

		Dim zx As String
		Dim MainWinState, MainWinWidth As Integer
		Dim MainWinTop, MainWinLeft, MainWinHeight As Integer

		' Save the size of the main window

		MainWinHeight = Me.Height ' MainWinHeight
		MainWinWidth = Me.Width ' MainWinWidth
		MainWinState = Me.WindowState ' MainWinState
		MainWinTop = Me.Top ' MainWinTop
		MainWinLeft = Me.Left ' MainWinLeft
		zx = CStr(MainWinState) & "," & CStr(MainWinLeft) & "," & CStr(MainWinTop) & "," & CStr(MainWinWidth) & "," & CStr(MainWinHeight)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "MainWindow", "Size", zx)

		' Close the database if it is open

		If DbOpen Then CloseDatabase()

		' Unload all forms

		For jj = My.Application.OpenForms.Count - 1 To 0 Step -1
			If Not My.Application.OpenForms.Item(jj) Is Me Then My.Application.OpenForms(jj).Close()
		Next jj

	End Sub
	'**********************************************************
	'
	' The close database menu option is clicked.
	'
	'**********************************************************
	Public Sub CloseFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCloseFile.Click

		' Declare variables

		Dim p As PictureBox

		' Close the database and destroy the library's database
		' object, which closes the libary.  Then show the empty
		' library (which has just the two bookends.)
		' Return the bookmark to the left bookend.

		If Not picBookshelf Is Nothing Then
			For Each p In picBookshelf
				RemoveHandler p.Click, AddressOf picBookshelf_Click
				RemoveHandler p.DoubleClick, AddressOf picBookshelf_DoubleClick
				RemoveHandler p.MouseDown, AddressOf picBookshelf_MouseDown
				RemoveHandler p.MouseMove, AddressOf picBookshelf_MouseMove
				RemoveHandler p.Paint, AddressOf picBookshelf_Paint
				Me.Controls.Remove(p)
			Next
			picBookshelf = Nothing
		End If
		CloseDatabase()
		gLibrary.Close()

	End Sub
	'***************************************************************
	'
	' The Help Contents menu option is selected.
	'
	'***************************************************************
	Public Sub mnuHelpContents_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Help.ShowHelpIndex(Me, ProgramPath & "Contents.htm")
	End Sub
	'***************************************************************
	'
	' The Getting Started help menu option is selected.
	'
	'***************************************************************
	Public Sub mnuGettingStarted_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		Help.ShowHelpIndex(Me, ProgramPath & "Getting Started.htm")
	End Sub
	'**************************************************
	'
	' The "About" menu option is selected.
	'
	'**************************************************
	Public Sub mnuAbout_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuAbout.Click
		About.ShowDialog()
	End Sub
	'***********************************************************************

	' The View Readme menu option is selected.

	'***********************************************************************
	Private Sub mnuViewReadme_Click(sender As Object, e As EventArgs) Handles mnuViewReadMe.Click

		' Create a viwer.  If the user sets the "EditMDFiles" value, using the Control Table Editor,
		' to "True", they will be able to both view and edit .md files.

		Dim f As New frmMDViewer
		Dim zx As String = My.Application.Info.DirectoryPath & "\Readme.md"
		f.LoadFile(zx)
		f.Text = "Viewing " & Path.GetFileName(zx)

		If DbOpen Then f.EnableEditing = CBool(GetControlItem("EditMDFiles", "False"))
		f.ShowDialog()

	End Sub
	'***********************************************************************

	' The View licenses menu option is selected.

	'***********************************************************************
	Private Sub mnuViewLicense_Click(sender As Object, e As EventArgs) Handles mnuViewLicense.Click

		' Create a viwer.  If the user sets the "EditMDFiles" value, using the Control Table Editor,
		' to "True", they will be able to both view and edit .md files.

		Dim f As New frmMDViewer
		Dim zx As String = My.Application.Info.DirectoryPath & "\license.md"
		f.LoadFile(zx)
		f.Text = "Viewing " & Path.GetFileName(zx)

		f.EnableEditing = CBool(GetControlItem("EditMDFiles", "False"))
		f.Show()

	End Sub



	'**************************************************
	'
	' Sub to backup the database to a separate
	' directory.
	'
	'**************************************************
	Public Sub BackupDatabase_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuBackupDatabase.Click
		LaunchProcess("Backup")
	End Sub

	'**********************************************************
	'
	' The exit menu option is clicked.  Unload the form
	'
	'**********************************************************
	Public Sub Exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuExit.Click
		Me.Close()
	End Sub

	'**************************************************
	'
	' The form is resized.
	'
	'**************************************************
	Private Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize

		' Declare variables

		Dim p As PictureBox

		' If we resize the main form, redisplay each cookbook at a slightly different random height, to
		' create a more real appearance of books on a shelf.

		picBookshelf_0.Top = Me.ClientRectangle.Height - HScroll1.Height - picBookshelf_0.ClientRectangle.Height - 10
		picBookshelf_1.Top = picBookshelf_0.Top
		If picBookshelf IsNot Nothing Then
			For Each p In picBookshelf
				p.Top = picBookshelf_0.Top + picBookshelf_0.Height - p.ClientRectangle.Height - Rnd(VB.Timer()) * 10
			Next p
		End If
	End Sub
	'**************************************************
	'
	' The cookbook properties menu option is selected.
	'
	'**************************************************
	Public Sub mnuCookbookProperties_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuCookbookProperties.Click

		' Declare variables

		Dim jj As Integer

		' Find the selected cookbook

		For jj = 1 To gLibrary.CookBooks.Count()
			If gLibrary.CookBooks.Item(jj).Selected Then
				gLibrary.CookBooks.Item(jj).ChangeProperties()
				If gLibrary.CookBooks.Item(jj).PropertiesChanged Then

					' Refresh the library

					gLibrary.Show()

					' Reset the bookmark

					gLibrary.ResetBookmark()

					' Reset the scroll bar

					ResetScrollBar()

					Exit For
				End If
			End If
		Next jj
	End Sub

	'**********************************************************
	'
	' The "Remove from library" menu option is clicked.
	'
	'**********************************************************
	Public Sub mnuDeleteBook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuDeleteBook.Click

		' Declare variables

		Dim jj As Integer
		Dim xx As Integer

		' Check to make sure user is not trying to delete the default
		' cookbook.

		For jj = 1 To gLibrary.CookBooks.Count()
			If gLibrary.CookBooks.Item(jj).Selected = True Then
				If gLibrary.CookBooks.Item(jj).Category = "_Default" Then
					MsgBox("You cannot delete the default cookbook.", MsgBoxStyle.Exclamation, "Remove Cookbook from Library")
					Exit Sub
				End If
			End If
		Next jj

		' See if the user wants to move all recipes to another
		' cookbook.

		xx = MsgBox("Do you want to move all recipes from the selected cookbook to another cookbook before removing the selected cookbook from the library?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel + MsgBoxStyle.DefaultButton2, "Remove Cookbook from Library")
		If xx = MsgBoxResult.Cancel Then
			Exit Sub
		ElseIf xx = MsgBoxResult.Yes Then
			For jj = 1 To gLibrary.CookBooks.Count()
				If gLibrary.CookBooks.Item(jj).Selected = True Then
					If MoveRecipes(gLibrary.CookBooks.Item(jj).BookID) Then
						Exit For
					End If
					Exit For
				End If
			Next jj
		End If


		' Verify that the user wants to delete the selected
		' cookbook.

		If MsgBox("Removing a cookbook from the library is an irreversible process.  Are you sure you want to remove this cookbook?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Remove Cookbook from Library") = MsgBoxResult.Yes Then
			For jj = 1 To gLibrary.CookBooks.Count()
				If gLibrary.CookBooks.Item(jj).Selected = True Then

					' Remove the selected cookbook and redisplay the library.

					xx = gLibrary.CookBooks.Item(jj).BookID
					gLibrary.RemoveCookbook(xx)
					gLibrary.Show()
					ResetScrollBar()
					Exit For
				End If
			Next jj
		End If

	End Sub

	'**************************************************
	'
	' The "Move Recipes" menu item is selected.
	'
	'**************************************************
	Public Sub mnuMoveRecipes_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuMoveRecipes.Click

		' Declare variables

		Dim jj As Integer

		' Find the selected cookbook and call the Move Recipes routine.

		For jj = 1 To gLibrary.CookBooks.Count()
			If gLibrary.CookBooks.Item(jj).Selected = True Then
				MoveRecipes(gLibrary.CookBooks.Item(jj).BookID)
				gLibrary.CookBooks.Item(jj).PropertiesChanged = True ' Will cause library to rebuild
				gLibrary.Show()
				Exit For
			End If
		Next jj

	End Sub


	'**************************************************
	'
	' The "New Cookbook" menu item is selected.
	'
	'**************************************************
	Public Sub mnuNewBook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuNewBook.Click

		' Create the new cookbook

		gLibrary.AddCookbook()

		' Refresh the library

		gLibrary.Show()

		' Reset the scroll bar

		ResetScrollBar()

	End Sub

	'**********************************************************
	'
	' The "Open Book" menu option is clicked.
	'
	'**********************************************************
	Public Sub mnuOpenBook_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpenBook.Click

		' Declare variables

		Dim jj As Integer

		' Determine which book is the selected book and
		' open it.

		For jj = 1 To gLibrary.CookBooks.Count()
			If gLibrary.CookBooks.Item(jj).Selected = True Then
				gLibrary.CookBooks.Item(jj).OpenBook()
			End If
		Next jj
		gLibrary.Show()

	End Sub

	'**************************************************
	'
	' The search library menu option is selected.
	'
	'**************************************************
	Public Sub mnuSearchLibrary_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSearchLibrary.Click

		frmSearchLibrary.Show()

	End Sub
	'**************************************************
	'
	' One of the Most Recently Used database menu
	' items is clicked.
	'
	'**************************************************
	Public Sub MRU_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MRU1.Click, MRU2.Click, MRU3.Click, MRU4.Click

		' Declare variables

		Dim zx As String = eventSender.ToString

		' Get the name of the selected database and open it.

		Databasename = Mid(zx, 4)
		DbOpen = OpenADatabase(Databasename, False)

		' Assign the database to the library object

		If DbOpen Then
			gLibrary.Show()
			ResetScrollBar()
		End If

	End Sub
	'**************************************************
	'
	' The "new database" menu option is selected.
	'
	'**************************************************
	Public Sub NewFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuNewFile.Click

		' Build a new database

		CreateNewDatabase()

		' Assign the database to the library object

		If DbOpen Then
			gLibrary.Show()
			ResetScrollBar()
		End If

	End Sub
	'**********************************************************
	'
	' The Open database menu option is clicked.
	'
	'**********************************************************
	Public Sub OpenFile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuOpenFile.Click
		LaunchProcess("OpenDatabase")
	End Sub

	'**************************************************
	'
	' Event handler for the books on the bookshelf, click event.
	'
	'**************************************************
	Public Sub picBookshelf_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

		' Enable the "Open" and "Delete" menu items.

		EnableCookbookOptions(True)

	End Sub

	'**************************************************
	'
	' Event handler for the books on the bookshelf, double-click event.
	' This is bound at run time.
	'
	'**************************************************
	Public Sub picBookshelf_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
		mnuOpenBook_Click(mnuOpenBook, New System.EventArgs())
	End Sub


	'***************************************************
	'
	' Event handler for the books on the bookshelf, mouse down event.
	' This is bound at run time.
	'
	'***************************************************
	Public Sub picBookshelf_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)

		' Declare variables

		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = eventArgs.X
		Dim Y As Single = eventArgs.Y
		Dim jj As Integer

		' Make sure it is a book clicked and not a bookend,
		' then make it the selected book.  Either a right,
		' left or even center click is acceptable to mark
		' the book as "selected".

		If Not picBookshelf Is Nothing Then
			For jj = 1 To gLibrary.CookBooks.Count()
				If gLibrary.CookBooks.Item(jj).Display Is eventSender Then

					' Mark the book as the currently selected book.

					gLibrary.CookBooks.Item(jj).Selected = True
					gLibrary.ResetBookmark(eventSender)
				Else
					gLibrary.CookBooks.Item(jj).Selected = False
				End If
			Next jj
		End If


	End Sub

	'************************************************
	'
	' Event Handler for the Recent and Favorites menu items Click event.
	' This is bound at run time.
	'
	'************************************************
	Public Sub mnuRecent_ItemClick(ByVal eventsender As System.Object, ByVal eventArgs As EventArgs)

		' Declare variables

		Dim RecID As Integer
		Dim BookID As String
		Dim zx As String
		Dim lbook As Cookbook

		' Get the book and recipe ID from the Tag property of the clicked-on menu item.

		zx = eventsender.tag
		BookID = ParseString(zx)
		RecID = CInt(zx)

		' Get the specified book from the library and open it to the selected recipe.

		lbook = gLibrary.CookBooks.Item(BookID)
		lbook.OpenBook(RecID)
	End Sub
	'************************************************
	'
	' Event Handler for the books on the bookshelf. Mouse Move event.
	' This is bound at run time.
	'
	'************************************************
	Public Sub picBookshelf_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs)

		' Declare variables

		Dim jj As Integer

		' If the mouse has moved over the default cookbook, make the "restore defaults" context
		' menu item visible.  If not the default cookbook, make that item invisible.

		If Not picBookshelf Is Nothing Then
			For jj = 1 To gLibrary.CookBooks.Count()
				If gLibrary.CookBooks.Item(jj).Display Is eventSender Then
					If gLibrary.CookBooks.Item(jj).Category = "_Default" Then mnuRestoreDefaults.Visible = True Else mnuRestoreDefaults.Visible = False
				End If
			Next jj
		End If


	End Sub
	'**********************************************************

	' Event Handler for the books on the bookshelf, paint event.
	' This is bound at run time.

	'**********************************************************
	Public Sub picBookshelf_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs)

		' Find the cookbook that controls this PictureBox, and call the routine to draw the cookbook
		' title on the PictureBox, over the picture of a book edge.

		Dim jj As Integer
		For jj = 1 To gLibrary.CookBooks.Count
			If gLibrary.CookBooks.Item(jj).display Is eventSender Then gLibrary.CookBooks.Item(jj).PrintTitle(eventArgs.Graphics)
		Next jj

	End Sub

	'**********************************************************
	'
	' The "Properties" menu option is clicked.
	' Load the Properties form
	'
	'**********************************************************
	Public Sub ShowProperties_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuProperties.Click
		LaunchProcess("Properties")
	End Sub


	'**************************************************
	'
	' The scroll bar has changed.  Move the books left
	' or right
	'
	'**************************************************
	Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
		Select Case eventArgs.Type
			Case System.Windows.Forms.ScrollEventType.EndScroll

				' Declare variables

				Dim NextBookLeft As Integer
				Dim p As PictureBox

				' Shift the pictures left or right, depending on
				' which way the thumbwheel went.

				picBookshelf_0.Left = -HScroll1.Value
				NextBookLeft = picBookshelf_0.Left + picBookshelf_0.Width
				If Not picBookshelf Is Nothing Then
					For Each p In picBookshelf
						p.Left = NextBookLeft
						NextBookLeft = NextBookLeft + p.Width
					Next p
				End If
				picBookshelf_1.Left = NextBookLeft
		End Select

	End Sub
	'**********************************************************

	' The Organize Database History menu option is selected.

	'**********************************************************
	Public Sub OrganizeDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOrganizeDB.Click
		frmOrganizeMRU.ShowDialog()
	End Sub

	'**************************************************
	'
	' The control table editor menu option is selected.
	'
	'**************************************************
	Private Sub mnuControlTableEditor_Click(sender As Object, e As EventArgs) Handles mnuControlTableEditor.Click
		frmControlTableEditor.Show()
	End Sub
	'**************************************************
	'
	' The registry editor menu option is selected.
	'
	'**************************************************
	Private Sub mnuRegistryEditor_Click(sender As Object, e As EventArgs) Handles mnuRegistry.Click
		frmRegistryEditor.Show()
	End Sub
	'**********************************************************

	' The "Set Workstation ID" menu option is selected.

	'**********************************************************
	Private Sub mnuSetWSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSetWSID.Click

		' Declare variables

		Dim zx As String
		If MsgBox("If the " & ProgramName & " program will be used in a networked environment, each computer that accesses the database must have a unique Workstation ID (""WSID"") to prevent settings conflicts.  The default WSID for a computer is 001. The current WSID of this computer is " & WSID() & ".  Would you like to change the WSID of this computer?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, ProgramName) = MsgBoxResult.Yes Then
			zx = InputBox("Enter the 3-character Workstation ID to be used on this computer.", "Set Workstation ID", WSID())
			System.Environment.SetEnvironmentVariable("WSID", zx)
		End If
	End Sub
	'**********************************************************

	' The "Maintain Recipe Links" menu option is selected.

	'**********************************************************
	Private Sub mnuMaintainLinks_Click(sender As Object, e As EventArgs) Handles mnuMaintainLinks.Click
		frmMaintainLinks.Show()
	End Sub
	'**********************************************************

	' The "Restore Database" menu option is selected.

	'**********************************************************
	Private Sub mnuRestoreDatabase_Click(sender As Object, e As EventArgs) Handles mnuRestoreDatabase.Click
		LaunchProcess("RestoreDatabase")
	End Sub
	'**********************************************************

	' The Compact Database menu option is selected.

	'**********************************************************
	Private Sub CompactDatabase_Click(sender As Object, e As EventArgs) Handles mnuCompactDatabase.Click
		CompactDatabase()
	End Sub

	'**********************************************************

	' The Context Menu Items

	'**********************************************************
	Private Sub mnuPOPOpenBook_Click(sender As Object, e As EventArgs) Handles mnuPOPOpenBook.Click
		mnuOpenBook_Click(mnuOpenBook, New System.EventArgs())
	End Sub

	Private Sub mnuPOPProperties_Click(sender As Object, e As EventArgs) Handles mnuPOPProperties.Click
		mnuCookbookProperties_Click(mnuCookbookProperties, New System.EventArgs)
	End Sub

	Private Sub mnuPOPRemove_Click(sender As Object, e As EventArgs) Handles mnuPOPRemove.Click
		mnuDeleteBook_Click(mnuDeleteBook, New System.EventArgs())
	End Sub
	'**********************************************************

	' The Change Theme menu is selected.

	'**********************************************************
	Private Sub mnuTheme_Click(sender As Object, e As EventArgs) Handles mnuTheme.Click
		LaunchProcess("Theme")
	End Sub
	'**********************************************************

	' The Restore Defaults menu is selected.

	'**********************************************************
	Private Sub mnuRestoreDefaults_Click(sender As Object, e As EventArgs) Handles mnuRestoreDefaults.Click

		' Declare variables

		Dim jj As Integer
		Dim Command As New SqlCommand

		' Reset the book image back to its default

		Command.Connection = DB
		Command.CommandText = "UPDATE tblCookbooks SET ImageStyle = 0 WHERE Category='_Default'"
		Command.CommandType = CommandType.Text
		Command.ExecuteNonQuery()

		' Set the propertieschanged flag so the library will be rebuilt

		For jj = 1 To gLibrary.CookBooks.Count()
			If gLibrary.CookBooks.Item(jj).Selected Then
				gLibrary.CookBooks.Item(jj).PropertiesChanged = True
			End If
		Next jj

		' Refresh the library

		gLibrary.Show()
	End Sub
	'**************************************************
	'
	' Sub to reset the scroll bar when a book is added,
	' deleted, or its properties have changed.
	'
	'**************************************************
	Private Sub ResetScrollBar()

		' Declare variables

		Dim BookshelfWidth As Integer
		Dim NextBookPos As Integer
		Dim jj As Integer
		Dim xx As Integer
		Dim p As PictureBox

		' Calculate the new width of the bookshelf

		If Not picBookshelf Is Nothing Then
			BookshelfWidth = picBookshelf_0.Width + picBookshelf_1.Width
			For Each p In picBookshelf
				BookshelfWidth = BookshelfWidth + p.ClientRectangle.Width
			Next p

			' Now calculate where the bookshelf must begin to be centered
			' on the screen.

			xx = (Me.ClientRectangle.Width - BookshelfWidth) / 2

			' Set the left bookend to be at that point, and all books
			' to follow.

			picBookshelf_0.Left = xx
			NextBookPos = picBookshelf_0.Left + picBookshelf_0.ClientRectangle.Width
			For jj = 1 To picBookshelf.Count
				picBookshelf(jj).Left = NextBookPos
				NextBookPos = NextBookPos + picBookshelf(jj).ClientRectangle.Width
			Next jj
			picBookshelf_1.Left = NextBookPos

		End If

		' Now center the scrollbutton

		HScroll1.Value = 0

	End Sub
	'**********************************************************
	'
	' Sub to launch a process.  This  may be called from
	' anyplace in the project to launch something.
	'
	'**********************************************************
	Public Sub LaunchProcess(ByVal Process As String)

		' Declare variables

		Dim zx As String

		' Get a form of the process name that has no spaces and
		' is all lower case.

		zx = LCase(SRep(Process, 1, " ", ""))

		' Look for a matching process in our list to begin.

		Select Case zx

			Case "controltableeditor"
				frmControlTableEditor.ShowDialog()
			Case "newdatabase"
				CreateNewDatabase()
			Case "opendatabase"
				OpenDB()
				If DbOpen Then
					gLibrary.Show()
					ResetScrollBar()
				End If
			Case "properties"
				frmProperties.ShowDialog()
			Case "backup"
				If BackupDatabase(Databasename) = BackupResult.Succeeded Then
					BackupRestoreStatus.Image = My.Resources.Backup
					BackupRestoreStatus.Text = "Backup completed"
					My.Application.DoEvents()
				Else
					BackupRestoreStatus.Image = My.Resources.Backup
					BackupRestoreStatus.Text = "Backup failed."
					My.Application.DoEvents()
				End If
				DbOpen = OpenADatabase(Databasename) ' Reopen database
				If DbOpen Then
					gLibrary.Show()
					ResetScrollBar()
				End If
			Case "restoredatabase"
				RestoreDatabase()
			Case "theme"
				frmTheme.ShowDialog()
			Case "shutdown"
				Me.Close()
			Case Else
				MsgBox("No process """ & Process & """ is available.", vbInformation, "Launch Process")
		End Select
	End Sub

	'**********************************************************

	' The backup/restore status message has changed.

	'**********************************************************
	Private Sub BackupRestoreStatus_TextChanged(sender As Object, e As EventArgs) Handles BackupRestoreStatus.TextChanged

		' Enable the timer, which will erase any message after 1 minute.

		timBackupStatus.Enabled = True

	End Sub

	'**********************************************************

	' A minute has passes since a message was placed in the
	' backup/restore status message.  Clear the message and
	' disable the timer.

	'**********************************************************
	Private Sub timBackupStatus_Tick(sender As Object, e As EventArgs) Handles timBackupStatus.Tick
		BackupRestoreStatus.Image = Nothing
		BackupRestoreStatus.Text = ""
		timBackupStatus.Enabled = False
	End Sub
	'**********************************************************
	'
	' Sub to restore the database.
	'
	'**********************************************************
	Private Sub RestoreDatabase()

		' Declare variables

		Dim zx As String
		Dim Destination As String

		' Have the user select the backup from which the database is to be restored.

		frmSelectBackup.ShowDialog()
		If frmSelectBackup.DialogResult = Windows.Forms.DialogResult.OK Then
			zx = frmSelectBackup.SelectedBackup
			If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
				Destination = FolderBrowserDialog1.SelectedPath
				If SiriusCook_Module1.RestoreDatabase(Destination, zx) Then
					BackupRestoreStatus.Image = My.Resources.Backup
					BackupRestoreStatus.Text = "Restore completed"
					My.Application.DoEvents()
				Else
					BackupRestoreStatus.Image = My.Resources.Backup
					BackupRestoreStatus.Text = "Restore failed."
					My.Application.DoEvents()
				End If
			End If
		End If

	End Sub	   '**********************************************************
	'
	' Sub to open a database
	'
	'**********************************************************
	Private Sub OpenDB()

		' Declare variables

		Dim zx0 As String

		' Get the current directory (the common dialog box may
		' change it).

		zx0 = CurDir()

		' Use the common dialog open box to get the file name.

		Me.OpenFileDialog1.Filter = "SQL Databases (*.MDF)|*.MDF|All Files (*.*)|*.*"
		Me.OpenFileDialog1.FileName = ""
		Me.OpenFileDialog1.FilterIndex = 1
		Me.OpenFileDialog1.DefaultExt = "MDF"
		Me.OpenFileDialog1.Title = "Open " & ProgramName & " Database"
		If Me.OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
			Databasename = Me.OpenFileDialog1.FileName

			' Restore the current directory

			ChDir(zx0)

			' Open the specified database

			DbOpen = OpenADatabase(Databasename, False)

		End If
	End Sub
	'**********************************************************

	' Sub to force the library to be recreated

	'**********************************************************
	Public Sub RefreshLibrary()
		gLibrary.Show()	' This will rebuild the library if anything changed
	End Sub

End Class