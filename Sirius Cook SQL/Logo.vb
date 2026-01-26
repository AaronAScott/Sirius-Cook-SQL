Option Strict Off
Option Explicit On
Friend Class Logo
	Inherits System.Windows.Forms.Form
	'**********************************************************
    ' SiriusCook SQL Logo form
    ' LOGO.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
	'
    ' Copyright (C) 1996-2017 Sirius Software
	' All Rights Reserved
	'**********************************************************


	'**************************************************
	'
	' The form is loaded.
	'
	'**************************************************
	Private Sub Logo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		' Make the window a top-most window.

        Me.TopMost = True

		' Set the version and product name labels.

		lblVersion.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & My.Application.Info.Version.Build & My.Application.Info.Version.MinorRevision
		lblCopyright.Text = My.Application.Info.Copyright
		lblProductName.Text = My.Application.Info.Title & " " & My.Application.Info.CompanyName
	End Sub
	
	'**************************************************
	'
	' If the logo is clicked, unload the logo
	'
	'**************************************************
    Private Sub Frame1_Click()
        Me.Close()
    End Sub
	
	'**************************************************
	'
	' If any key is pressed, unload the logo
	'
	'**************************************************
	Private Sub Logo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Integer = Asc(eventArgs.KeyChar)
		Me.Close()
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	'**********************************************************
	'
	' The timer has "clicked"
	'
	'**********************************************************
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        Me.Close()
	End Sub
End Class