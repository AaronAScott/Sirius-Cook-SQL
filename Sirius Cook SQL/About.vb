Option Strict Off
Option Explicit On
Friend Class About
	Inherits System.Windows.Forms.Form
	'**********************************************************
    ' About Box for SiriusCook SQL
    ' ABOUT.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
	' All Rights Reserved
    '**********************************************************

    '**************************************************
    '
    ' The okay button is clicked.  Unload the form.
    '
    '**************************************************
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Me.Close()
	End Sub
	
	'**********************************************************
	'
    ' The form is loaded. Get the system resources to display.
	'
	'**********************************************************
    Private Sub About_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Declare variables

        Dim zx0 As String

        ' Fill in the labels with information about the program

        Me.Text = "About " & ProgramName
        Label2_0.Text = ProgramName
        Label2_1.Text = ProgramName
        lblTitle.Text = ProgramName & " for Windows"
        If My.Application.Info.Copyright <> "" Then lblCopyright.Text = My.Application.Info.Copyright & " " & My.Application.Info.CompanyName
        On Error Resume Next
        zx0 = CStr(FileDateTime(ProgramPath & My.Application.Info.AssemblyName & ".exe"))
        On Error GoTo 0
		lblVersion.Text = "Version " & CStr(My.Application.Info.Version.Major) & "." & CStr(My.Application.Info.Version.Minor) & CStr(My.Application.Info.Version.Build) & CStr(My.Application.Info.Version.MinorRevision) & " (" & zx0 & ")"
		lblDBVersion.Text = "Database Version " & DBVersion
        If WSID() <> "" Then lblWSID.Text = "Workstation ID: " & WSID()
        lblUser.Text = "User: " & GetControlItem("CooksName")

        System.Windows.Forms.Application.DoEvents() ' give things a chance to display
    End Sub
	

End Class