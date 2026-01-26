Public Class frmTips
    '**************************************************
    ' SiriusCook SQL Print File Divider Tips
    ' SIRIUSCOOK_TIPS.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
    '**************************************************

    ' Properties of the tip window.  The TipTitle and TipText may contain RTF codes; but not the "prelude" or closing brace.

    Public TipTitle As String
    Public TipText As String
    Public ControlItem As String

    '**************************************************

    ' The "Show Tips on Startup" check box has changed.

    '**************************************************
    Private Sub chkShowTips_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowTips.CheckedChanged
        If ControlItem <> "" Then
            If sender.Checked Then PutControlItem(ControlItem, "1") Else PutControlItem(ControlItem, "0")
        End If
    End Sub

    '**************************************************

    ' The form is loaded

    '**************************************************
    Private Sub frmTips_Load(sender As Object, e As EventArgs) Handles Me.Load


        ' Set the tables (color and font) for starting RTF text.

        Dim RTFPrelude As String = "{\rtf1\ansi\deff0\deftab720{\fonttbl{\f0\fswiss MS Sans Serif;}{\f1\froman\fcharset2 Symbol;}{\f2\fswiss MS Sans Serif;}{\f3\froman Times New Roman;}}{\colortbl\red0\green0\blue0;red0\green0\blue255;\red0\green255\blue0;\red255\green0\blue0;\red255\green0\blue255;}\deflang1033\pard\plain\f3\fs21 "
        Dim zx0 As String
        Dim zx1 As String


        ' If the tip is turned off, close before showing.

        If GetControlItem(ControlItem, "0") = "0" Then Me.Close()

        ' Assemble the entire tip text now.  The title gets a large 28 pt font size,
        ' and is printed, centered, in bold.

        zx0 = "\fs28\b\qc " & TipTitle & "\plain\f3\par\par "
        zx1 = "\ql " & TipText

        ' Add the "end of all text" closing space/brace and display the tip

        RichTextBox1.Rtf = RTFPrelude & zx0 & zx1 & " }"

        ' Set the window color to the theme color.

        Me.BackColor = Choose(ProgramColorTheme(ThemeItem.BackgroundColorNumber), SystemColors.Control, Color.FromArgb(255, 189, 182, 255), Color.Tan)

        ' Make this a top level window

        Me.TopMost = True
    End Sub


End Class