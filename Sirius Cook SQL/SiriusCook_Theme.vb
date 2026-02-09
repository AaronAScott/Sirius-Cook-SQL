Public Class frmTheme
    '*******************************************************************
    ' SiriusCook SQL Color Theme window
    ' SIRIUSCOOK_THEME.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright 2017 Sirius Software All Rights Reserved
    '*******************************************************************

    ' Declare variables local to this module

    Private DontProcessChangeEvent As Boolean
    Private CurrentTheme As String
    Private MainWindowColorNumber As Integer
    Private BackgroundColorNumber As Integer
    Private TextColorNumber As Integer
    Private FontNumber As Integer
    Private b1 As SolidBrush
    Private b2 As SolidBrush
    Private f1 As SolidBrush
    Private f2 As SolidBrush
    Private f3 As SolidBrush
    Private fDefault As Font
    Private fL As Font

    '*******************************************************************

    ' The form is loaded.

    '*******************************************************************
    Private Sub frmTheme_Load(sender As Object, e As EventArgs) Handles Me.Load

		' Declare variables.

		fDefault = New Font("MS Sans Serif", 6)
		fL = New Font("Arial", 8)

		' Place the demo text into the label.

		Label1.Text = "A backup for database c:\databases\recipes.Mdf has been scheduled." & vbCrLf & vbCrLf & "Backup will be saved in Z:\Backups\recipes.mdf.Wed." & vbCrLf & vbCrLf & "Would you like to perform this backup now?  If you select ""No"" the backup will not be performed, but will remain scheduled.  If you wish to cancel the backup entirely, click ""Cancel""."

		' Get the theme number, and separate out the font number and the color
		' numbers.  The theme number is a hex value from 0x1111 to 0x4342. 

		' The main window color number is the 2^3 value.
		' The background color number is the 2^2 value, the text
		' color number is the 2^1 value and the font number the 2^0
		' column.  There are 4 main window colors, three background colors,
		' four font colors and two text sizes, for a total of 48 variations in the theme.

		CurrentTheme = ProgramColorTheme
		MainWindowColorNumber = Val(Mid(CurrentTheme, 3, 1))
		BackgroundColorNumber = Val(Mid(CurrentTheme, 4, 1))
		TextColorNumber = Val(Mid(CurrentTheme, 5, 1))
		FontNumber = Val(Mid(CurrentTheme, 6, 1))

		' Set the appropriate radio buttons based on the theme values.

		DontProcessChangeEvent = True
		If FontNumber = 1 Then RadioButton1.Checked = True Else RadioButton2.Checked = True
		If BackgroundColorNumber = 1 Then RadioButton3.Checked = True
		If BackgroundColorNumber = 2 Then RadioButton4.Checked = True
		If BackgroundColorNumber = 3 Then RadioButton5.Checked = True
		If TextColorNumber = 1 Then RadioButton6.Checked = True
		If TextColorNumber = 2 Then RadioButton7.Checked = True
		If TextColorNumber = 3 Then RadioButton8.Checked = True
		If TextColorNumber = 4 Then RadioButton9.Checked = True
		If MainWindowColorNumber = 1 Then RadioButton10.Checked = True
		If MainWindowColorNumber = 2 Then RadioButton11.Checked = True
		If MainWindowColorNumber = 3 Then RadioButton12.Checked = True
		If MainWindowColorNumber = 4 Then RadioButton13.Checked = True
		DontProcessChangeEvent = False

		' Display the effect of these selections

		DisplayThemeSelections()

	End Sub

	'*******************************************************************

	' The save button is clicked.

	'*******************************************************************
	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

		' Declare variables.

		Dim zx As String

		' Get the values of each part of the format.

		If RadioButton1.Checked Then FontNumber = 1
		If RadioButton2.Checked Then FontNumber = 2
		If RadioButton3.Checked Then BackgroundColorNumber = 1
		If RadioButton4.Checked Then BackgroundColorNumber = 2
		If RadioButton5.Checked Then BackgroundColorNumber = 3
		If RadioButton6.Checked Then TextColorNumber = 1
		If RadioButton7.Checked Then TextColorNumber = 2
		If RadioButton8.Checked Then TextColorNumber = 3
		If RadioButton9.Checked Then TextColorNumber = 4
		If RadioButton10.Checked Then MainWindowColorNumber = 1
		If RadioButton11.Checked Then MainWindowColorNumber = 2
		If RadioButton12.Checked Then MainWindowColorNumber = 3
		If RadioButton13.Checked Then MainWindowColorNumber = 4

		' Assemble the new theme value and save it. The theme looks like "0x1221".

		zx = "0x" & CStr(MainWindowColorNumber) & CStr(BackgroundColorNumber) & CStr(TextColorNumber) & CStr(FontNumber)
		ProgramColorTheme = zx

		' Update the main window color

		frmMain.BackColor = Choose(MainWindowColorNumber, Color.Black, SystemColors.Window, Color.FromArgb(255, 189, 182, 255), Color.Tan)


	End Sub

	'*******************************************************************

	' The close button is clicked.

	'*******************************************************************
	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		' Close this form

		Me.Close()
	End Sub


	'*******************************************************************

	' Event handler for the 13 radio buttons that change theme components.

	'*******************************************************************
	Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click, RadioButton2.Click, RadioButton3.Click, RadioButton4.Click, RadioButton5.Click, RadioButton6.Click, RadioButton7.Click, RadioButton8.Click, RadioButton9.Click, RadioButton10.Click, RadioButton11.Click, RadioButton12.Click, RadioButton13.Click

		' Do nothing here if we are changing the values and don't want
		' this event processed.

		If Not DontProcessChangeEvent Then

			' Declare variables.

			Dim r As RadioButton = CType(sender, RadioButton)

			' Only respond to checked values.  Get the change to the
			' theme values they represent.

			If r.Checked Then
				If sender Is RadioButton1 Then FontNumber = 1
				If sender Is RadioButton2 Then FontNumber = 2
				If sender Is RadioButton3 Then BackgroundColorNumber = 1
				If sender Is RadioButton4 Then BackgroundColorNumber = 2
				If sender Is RadioButton5 Then BackgroundColorNumber = 3
				If sender Is RadioButton6 Then TextColorNumber = 1
				If sender Is RadioButton7 Then TextColorNumber = 2
				If sender Is RadioButton8 Then TextColorNumber = 3
				If sender Is RadioButton9 Then TextColorNumber = 4
				If sender Is RadioButton10 Then MainWindowColorNumber = 1
				If sender Is RadioButton11 Then MainWindowColorNumber = 2
				If sender Is RadioButton12 Then MainWindowColorNumber = 3
				If sender Is RadioButton13 Then MainWindowColorNumber = 4
			End If

			' Display the new theme in the preview.

			DisplayThemeSelections()
		End If


	End Sub
	'*******************************************************************

	' Sub to update the colors of the preview display to reflect
	' changes made to the theme by the user.

	'*******************************************************************
	Private Sub DisplayThemeSelections()

		Panel3.BackColor = Choose(MainWindowColorNumber, Color.Black, SystemColors.Window, Color.FromArgb(255, 189, 182, 255), Color.Tan)
		Panel2.BackColor = Choose(BackgroundColorNumber, SystemColors.Window, Color.FromArgb(255, 182, 189, 255), Color.Tan)
		Label1.ForeColor = Choose(TextColorNumber, SystemColors.WindowText, Color.DarkBlue, Color.DarkGoldenrod, Color.White)
		Label1.Font = Choose(FontNumber, fDefault, fL)

		' Set the MsgBox font and color

		MsgBoxTheme.FontSize = Choose(ProgramColorTheme(ThemeItem.FontNumber), 0, 12)
		MsgBoxTheme.BackColor = Choose(ProgramColorTheme(ThemeItem.BackgroundColorNumber), SystemColors.Window, Color.FromArgb(255, 182, 189, 255), Color.Tan)
		MsgBoxTheme.ForeColor = Choose(ProgramColorTheme(ThemeItem.TextColorNumber), Color.Black, Color.DarkBlue, Color.DarkGoldenrod, Color.White)
	End Sub

End Class