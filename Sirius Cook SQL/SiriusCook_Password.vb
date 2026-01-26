Option Strict Off
Option Explicit On
Friend Class frmPassword
	Inherits System.Windows.Forms.Form
	'**************************************************
    ' SiriusCook SQL Password Entry form
    ' SIRIUSCOOK_PASSWORD.VB
	' Written: November 1998
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
	'**************************************************
	

	
	' Declare variables which are properties of this
	' module.
	
	Public Cancel As Boolean
	Public Password As String
	
	
	'**************************************************
	'
	' The Okay button is clicked.
	'
	'**************************************************
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		
		Cancel = False
		Password = Encrypt((Text1.Text))
		Me.Hide()
		
	End Sub
	
	
	'**************************************************
	'
	' The cancel button is clicked.
	'
	'**************************************************
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Cancel = True
		Me.Hide()
	End Sub
End Class