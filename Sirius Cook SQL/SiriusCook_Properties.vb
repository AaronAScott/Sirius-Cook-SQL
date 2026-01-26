Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmProperties
	Inherits System.Windows.Forms.Form
	'**********************************************************
	' SiriusCook SQL Program Properties form
	' SIRIUSCOOK_PROPERTIES.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2017 Sirius Software
	' All Rights Reserved
	'**********************************************************


	'**************************************************
	'
	' The form is loaded.
	'
	'**************************************************
	Private Sub Properties_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		' Make sure a database is open before attempting to
		' fill tabs.

		' Fill the first tab (cook's name)

		If DbOpen = True Then
			Text1.Text = GetControlItem("CooksName")
			Text2.Text = GetControlItem("StreetAddress")
			Text3.Text = GetControlItem("MailingAddress")
			Text4.Text = GetControlItem("City")

			' Make the first tab active

			TabControl1.SelectedTab = TabPage1
		End If

		' Fill the "global" tab. This is available even when
		' there is no open database.

		Text5.Text = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpen", "")
		Text6.Text = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "BackupPath", "")
		Check1_1.Checked = CBool(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpenLast", "False"))
		chkQuietBackup.Checked = CBool(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "QuietBackup", "True"))
		If GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", "0") = "0" Then optTransport_0.Checked = True Else optTransport_1.Checked = True
		txtEmail.Text = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailAddress")
		txtLogin.Text = Encrypt(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "1"))
		txtPassword.Text = Encrypt(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "2"))
		txtPort.Text = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "3")
		chkUseSSL.Checked = CBool(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "4", "False"))

		' If no database is open, disable the first tab.

		If Not DbOpen Then TabPage1.Enabled = False Else TabPage1.Enabled = True

	End Sub

	'**************************************************
	'
	' The "okay" button is clicked.  Save the values
	' and close the form.
	'
	'**************************************************
	Private Sub cmdOkay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOkay.Click
		cmdApply_Click(cmdApply, New System.EventArgs())
		Me.Close()
	End Sub

	'**********************************************************
	'
	' The "apply" button is clicked.  Write out the
	' cook's name and address info.
	'
	'**********************************************************
	Private Sub cmdApply_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdApply.Click

		' Declare variables

		Dim Msg As String = ""
		Dim zx0 As String = ""

		' Check that a valid Email address is entered if
		' the Net.mail option is selected.

		If optTransport_1.Checked = True Then
			If Not ValidateEmailAddress(txtEmail.Text, Msg, 2) Then ' Check server address, not email address
				MsgBox("Invalid Server Address for Net.mail." & vbCrLf & Msg, MsgBoxStyle.Information, "Program Properties")
				Exit Sub
			End If
		End If

		' Get the Cook's name/address information and write it
		' out to the control table first

		If DbOpen = True Then
			PutControlItem("CooksName", (Text1.Text))
			PutControlItem("StreetAddress", (Text2.Text))
			PutControlItem("MailingAddress", (Text3.Text))
			PutControlItem("City", (Text4.Text))

			' Flag that the database has changed

			DatabaseChanged = True

			' Redisplay the user name

			frmMain.UserLabel.Text = "User: " & Text1.Text

		End If

		' Save the contents of the "global" tab

		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpen", Text5.Text)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "BackupPath", Text6.Text)
		BackupPath = Text6.Text
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "AutoOpenLast", CStr(Check1_1.Checked))
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Databases", "QuietBackup", CStr(chkQuietBackup.Checked))
		If optTransport_0.Checked = True Then zx0 = "0" Else zx0 = "1"
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", zx0)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailAddress", txtEmail.Text)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "1", Encrypt(txtLogin.Text))
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "2", Encrypt(txtPassword.Text))
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "3", txtPort.Text)
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "4", CStr(chkUseSSL.Checked))

	End Sub
	'**************************************************
	'
	' Sub to browse SQL databases for the auto-open
	' database.
	'
	'**************************************************
	Private Sub cmdBrowseDb_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowseDB.Click

		' Declare variables

		Dim zx0 As String


		' Get the current directory (the common dialog box may
		' change it).

		zx0 = CurDir()

		' Use the common dialog open box to get the file name.

		frmMain.OpenFileDialog1.Filter = "SQL Databases (*.mdf)|*.MDF|All Files (*.*)|*.*"
		frmMain.OpenFileDialog1.FilterIndex = 1
		frmMain.OpenFileDialog1.ShowReadOnly = False
		frmMain.OpenFileDialog1.CheckFileExists = True
		frmMain.OpenFileDialog1.CheckPathExists = True
		frmMain.OpenFileDialog1.DefaultExt = "MDF"
		frmMain.OpenFileDialog1.FileName = ""
		frmMain.OpenFileDialog1.Title = "Select Auto-open Database"

		' Get the name of the database to be opened.

		frmMain.OpenFileDialog1.ShowDialog()
		If frmMain.OpenFileDialog1.FileName <> "" Then
			Text5.Text = frmMain.OpenFileDialog1.FileName

			' Restore the current directory

			ChDir(zx0)
		End If

	End Sub

	'**************************************************
	'
	' Sub to browse directories for the backup path.
	' database.
	'
	'**************************************************
	Private Sub cmdBrowseDir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBrowseDir.Click

		frmMain.FolderBrowserDialog1.SelectedPath = Datapath
		frmMain.FolderBrowserDialog1.ShowNewFolderButton = True
		frmMain.FolderBrowserDialog1.ShowDialog()
		If Not frmMain.FolderBrowserDialog1.SelectedPath = "" Then Text6.Text = frmMain.FolderBrowserDialog1.SelectedPath
	End Sub



	'**********************************************************
	'
	' The Cancel button is clicked.  Just unload the form.
	'
	'**********************************************************
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

		Me.Close()

	End Sub

	'*********************************************************
	'
	' A Text field has got the focus.  Set the select text
	' to encompass the entire line
	'
	'*********************************************************
	Private Sub Text1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.Enter, Text2.Enter, Text3.Enter, Text4.Enter, Text5.Enter, Text6.Enter, txtEmail.Enter
		eventSender.SelectionStart = 0
		eventSender.SelectionLength = Len(eventSender.Text)
	End Sub


	'*********************************************************

	' The Email Transport type has changed.

	'*********************************************************
	Private Sub optTransport_0_CheckedChanged(sender As Object, e As EventArgs) Handles optTransport_0.CheckedChanged

		' Disable the email server name field for Outlook option

		If sender.Checked Then
			lblEmail.Enabled = False
			txtEmail.Enabled = False
			lblLogin.Enabled = False
			txtLogin.Enabled = False
			lblPassword.Enabled = False
			txtPassword.Enabled = False
			lblPort.Enabled = False
			txtPort.Enabled = False
			lblUseSSL.Enabled = False
			chkUseSSL.Enabled = False

			' Enable information needed for ASP email option.

		Else
			lblEmail.Enabled = True
			txtEmail.Enabled = True
			lblLogin.Enabled = True
			txtLogin.Enabled = True
			lblPassword.Enabled = True
			txtPassword.Enabled = True
			lblPort.Enabled = True
			txtPort.Enabled = True
			lblUseSSL.Enabled = True
			chkUseSSL.Enabled = True
		End If
	End Sub

End Class