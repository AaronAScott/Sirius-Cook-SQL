Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports MailKit
Imports MimeKit
Imports SE_MailSender

Friend Class frmEmail
	Inherits System.Windows.Forms.Form
	'**************************************************
	' SiriusCook SQL Email Recipe form (frmEmail)
	' SIRIUSCOOK_EMAIL.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1997-202 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables which are local to this module

	Private mRec As DataRow
	Private ImagesDS As New DataSet
	Private ImagesTable As DataTable


	'**************************************************
	'
	' The form is loaded.
	'
	'**************************************************
	Private Sub frmEmail_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		' Declare variables

		Dim zx0 As String = ""
		Dim se As New SE_MailSender.SE_MailSender
		Dim cl As AutoCompleteStringCollection

		' If using .NET mail, make sure the sender's information is specified.

		If GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", "1") = "1" Then
			If Not ValidateEmailAddress(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailAddress"), zx0, 2) Then
				MsgBox("No valid sender Email address has been provided.  Select ""Properties"" under the File menu and enter a valid Email address.  Then try this function again.", MsgBoxStyle.Information, "Invalid Sender Email Address")
				cmdSend.Enabled = False
			End If
		End If

		' Fill in the sender's email address field

		txtEmail.Text = GetControlItem("LastEmailAddress")
		txtSender.Text = GetControlItem("SendersEmail" & WSID(), "")

		' We are using Sirius Email

		If GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", "0") = "0" Then
			se = New SE_MailSender.SE_MailSender
			cl = se.Contacts()
			txtName.AutoCompleteCustomSource = cl
		End If

		' Default to HTML format.

		Option1_2.Checked = True

	End Sub

	'**************************************************
	'
	' The form is unloaded.
	'
	'**************************************************
	Private Sub frmEmail_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

		' Save the last email address used.

		PutControlItem("LastEmailAddress", txtEmail.Text)

		' Dispose of datasets we've used.

		ImagesDS.Dispose()

	End Sub
	'**************************************************
	'
	' The Send button is clicked.
	'
	'**************************************************
	Private Sub cmdSend_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSend.Click

		' Declare variables

		Dim zx0 As String = ""
		Dim objNewMail As New MailKit.Net.Smtp.SmtpClient
		Dim Msg As MimeMessage
		Dim bb As New BodyBuilder
		Dim Sender As MailboxAddress

		' Make sure the user has supplied a recipient name

		If txtName.Text = "" And txtEmail.Text = "" Then
			MsgBox("You must specify a recipient name or email address.", MsgBoxStyle.Information, "Email a Recipe")
			Exit Sub
		End If


		' Make sure the user has supplied a sender email address

		If txtSender.Text = "" Then
			MsgBox("You must specify the sender's email address.", MsgBoxStyle.Information, "Email a Recipe")
			Exit Sub
		End If

		' Check the email address.

		If Not ValidateEmailAddress(txtEmail.Text, zx0) Then
			MsgBox("Not a valid Email address." & vbCrLf & zx0, MsgBoxStyle.Information, "Email Recipe")
			txtEmail.Focus()
			Exit Sub
		End If

		' Disable the Send button to prevent reentrancy problems

		cmdSend.Enabled = False

		' Show the "wait" mouse cursor

		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

		' Start error trapping.

		Try

			' create a new message.  We use the MimeMessage object regardless of the
			' sending mechanism.

			Msg = New MimeMessage
			Sender = New MailboxAddress(GetControlItem("CooksName"), txtSender.Text)
			Msg.From.Add(Sender) ' Specify sender's email address"
			Msg.Sender = Sender
			Msg.To.Add(New MailboxAddress(txtName.Text, txtEmail.Text))

			' Specify sender's email address in the BCC field when using Sirius Email, so it gets a copy back.

			If GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", "0") = "0" Then Msg.Bcc.Add(Sender)
			Msg.Subject = txtSubject.Text

			' If the format is RTF, save it in a temporary
			' file and attach the file

			If Option1_1.Checked = True Then
				chkIncludeImage.Enabled = False
				zx0 = FormatRTF(mRec)
				My.Computer.FileSystem.WriteAllText(Datapath & "\Recipe.rtf", zx0, False)
				bb.TextBody = txtMessage.Text
				bb.Attachments.Add(Datapath & "\Recipe.rtf")
				Msg.Body = bb.ToMessageBody

				' If the format is HTML, send that format

			ElseIf Option1_2.Checked = True Then
				chkIncludeImage.Enabled = True
				zx0 = FormatHTML(mRec)
				My.Computer.FileSystem.WriteAllText(Datapath & "\Recipe.html", zx0, False)
				bb.TextBody = txtMessage.Text
				bb.Attachments.Add(Datapath & "\Recipe.html")
				Msg.Body = bb.ToMessageBody

				' If the format is Exchange format, place it in the body of the email,
				' in the special format

			Else
				chkIncludeImage.Enabled = True
				zx0 = FormatExchange(mRec)
				If txtMessage.Text <> "" Then zx0 = txtMessage.Text & vbCrLf & vbCrLf & zx0
				bb.TextBody = zx0
				Msg.Body = bb.ToMessageBody
			End If

			' Send the message.
			' See if we are using Sirius Email for Email

			If GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailTransport", "0") = "0" Then

				Dim se As New SE_MailSender.SE_MailSender
				se.SendEmail(Msg)

					' If we are using MailKit

				Else

				' Connect to the SMTP server

				Try
					objNewMail.Connect(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "EmailAddress"), CInt(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "3")), CBool(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "4", "False")))
					objNewMail.Authenticate(Encrypt(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", "1")), Encrypt(GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Settings", 2)))
					objNewMail.Timeout = 300000 ' 5 minutes
					objNewMail.AuthenticationMechanisms.Remove("XOAUTH2")

					' Send the email.

					objNewMail.Send(Msg)

					' Catch errors .

				Catch ex2 As Exception
					MsgBox("Error trying to send email from Local MailKit." & vbCrLf & ex2.Message, MsgBoxStyle.Information, "Send Email")
				End Try

				' Close the connection.

				objNewMail.Disconnect(True)


				' Send the message


				objNewMail.Dispose()
				Msg.Dispose()
			End If

			' Trap for errors.

		Catch ex As Exception
			MsgBox("An error occurred attempting to send email." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Email Recipe Failure")
		End Try

		' Save the sender's email address

		PutControlItem("SendersEmail" & WSID(), txtSender.Text)

		' Show the normal mouse cursor

		Me.Cursor = Cursors.Default

		' Reenable the Send button

		cmdSend.Enabled = True

	End Sub
	'**************************************************

	' One of the email type options is selected.

	'**************************************************
	Private Sub Option1_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) Handles Option1_1.Click, Option1_2.Click, Option1_3.Click

		' If the HTML or Exchange formats are selected, enable the Include Image check box.

		If Option1_2.Checked Or Option1_3.Checked Then chkIncludeImage.Enabled = True Else chkIncludeImage.Enabled = False

	End Sub

	'**************************************************
	'
	' The Close button is clicked.
	'
	'**************************************************
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub


	'**************************************************
	'
	' One of the entry fields has got the focus.
	'
	'**************************************************
	Private Sub Text1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtName.Enter, txtEmail.Enter, txtSubject.Enter, txtMessage.Enter
		eventSender.SelectionStart = 0
		eventSender.SelectionLength = Len(eventSender.Text)
	End Sub

	'**************************************************

	' The Name text box is exited.

	'**************************************************
	Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave

		' Declare variables.

		Dim zx As String = txtName.Text

		txtName.Text = ParseString(zx, vbTab)
		txtEmail.Text = zx.Replace("<", "").Replace(">", "").Trim

	End Sub

	'**************************************************
	'
	' The Recipe property is queried
	'
	'**************************************************

	'**************************************************
	'
	' The Recipe property is set
	'
	'**************************************************
	Public Property Recipe() As DataRow
		Get
			Recipe = mRec
		End Get
		Set(ByVal Value As DataRow)

			' Set the local recordset to the new value

			mRec = Value
		End Set
	End Property

End Class