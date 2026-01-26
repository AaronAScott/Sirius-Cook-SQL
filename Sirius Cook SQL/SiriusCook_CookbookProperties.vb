Option Strict Off
Option Explicit On
Friend Class CookbookProperties
	Inherits System.Windows.Forms.Form
	'**************************************************
    ' SiriusCook SQL Cookbook Properties form
    ' SIRIUSCOOK_COOKBOOKPROPERTIES.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables which are the properties of
	' this form.
	
	Public Cancel As Boolean
	
	' Declare variables local to this module
	
    Private mImageStyle As Integer
	'**************************************************
	'
	' The Okay button is clicked.
	'
	'**************************************************
    Private Sub cmdOkay_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOkay.Click

        ' Verify the password

        If Text4.Text <> Text5.Text Then
            MsgBox("You have not verified the password correctly.  Please try again.", MsgBoxStyle.Exclamation, "Cookbook Properties")
            Text5.Focus()
            Exit Sub
        End If

        ' Make sure the user doesn't try to position a book at position 1, which is reserved for
        ' the default book; or a position greater than the number of books.

        If Val(Text6.Text) = 1 Then
            MsgBox("Position 1 is reserved for the Default cookbook.", MsgBoxStyle.Exclamation, "Invalid book position")
            Text6.Focus()
            Exit Sub
        ElseIf Val(Text6.Text) > frmMain.picBookshelf.Count Then
            MsgBox("You entered a position which exceeds the number of books on the shelf.", MsgBoxStyle.Exclamation, "Invalid book position")
            Text6.Focus()
            Exit Sub
        End If

        ' Clear the cancel flag and hide the form

        Cancel = False
        Me.Hide()

    End Sub


    '**************************************************
    '
    ' The cancel button is clicked.
    '
    '**************************************************
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Cancel = True
        Me.Hide()
    End Sub


    '**************************************************

    ' The form is closing.

    '**************************************************
    Private Sub CookbookProperties_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Remove the handlers for each book image that
        ' the user may select for a cookbook.

        Dim p As PictureBox
        For Each p In Panel1.Controls
            RemoveHandler p.Click, AddressOf Bookedge_Click
        Next p
    End Sub


    '**************************************************
    '
    ' The form is loaded.
    '
    '**************************************************
    Private Sub CookbookProperties_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Declare variables

        Dim jj As Integer
        Dim PicLeft As Integer
        Dim bm As Bitmap
        Dim pb As PictureBox

        ' Load the available images into the book cover
        ' selector.

        PicLeft = 10 ' starting point to show images, ignoring the first one, which is the default book

        For jj = 1 To 8
            bm = Choose(jj, My.Resources.Book1, My.Resources.Book2, My.Resources.Book3, My.Resources.Book4, My.Resources.Book5, My.Resources.Book6, My.Resources.Book7, My.Resources.Book8)
            bm.MakeTransparent(Color.Black)
            pb = New PictureBox
            pb.BackgroundImage = bm
            'pb.BackColor = frmMain.BackColor
            pb.Left = PicLeft
            pb.Top = 10
            pb.Height = Panel1.Height - 20
            pb.Width = bm.Width
            Panel1.Controls.Add(pb)
            AddHandler pb.Click, AddressOf Bookedge_Click
            PicLeft = PicLeft + pb.Width + 10
        Next jj

        ' Set the scroll bar to the number of images.

        HScroll1.LargeChange = Panel1.Width
        HScroll1.SmallChange = Panel1.Width / 4
        HScroll1.Minimum = 0
        HScroll1.Maximum = 5 * HScroll1.LargeChange

    End Sub
    '**************************************************
    '
    ' The cookbook cover design scroll bar is clicked.
    '
    '**************************************************
    Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll

        ' Declare variables

        Dim jj As Integer

        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll

                ' Move all the covers to the left or right, depending
                ' on the scroll

                Panel1.Controls(0).Left = -eventArgs.NewValue
                For jj = 1 To 7
                    Panel1.Controls(jj).Left = Panel1.Controls(jj - 1).Left + Panel1.Controls(jj - 1).Width + 10
                Next jj
        End Select
    End Sub


    '**************************************************
    '
    ' A book design is selected.  This is bound
    ' at run time.
    '
    '**************************************************
    Private Sub Bookedge_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

        ' Declare variables

        Dim p As PictureBox
        Dim jj As Integer
        Dim Index As Integer

        ' Determine the image style from the panel clicked on.

        jj = 0
        For Each p In Panel1.Controls
            jj = jj + 1
            If p Is eventSender Then Index = jj
        Next p

        ' Save the index as the ImageStyle property

        ImageStyle = Index
    End Sub


    '**************************************************
    '
    ' One of the text fields has got the focus.
    '
    '**************************************************
    Private Sub Text_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.Enter, Text2.Enter, Text3.Enter, Text4.Enter, Text5.Enter, Text6.Enter
        eventSender.SelectionStart = 0
        eventSender.SelectionLength = Len(eventSender.Text)
    End Sub

    '**************************************************
    '
    ' The ImageStyle property is queried.
    '
    '**************************************************

    '**************************************************
    '
    ' The ImageStyle property is set.
    '
    '**************************************************
    Public Property ImageStyle() As Object
        Get
            ImageStyle = mImageStyle
        End Get
        Set(ByVal Value As Object)

            ' Declare variables

            Dim pb As PictureBox

            ' Remember the current image style

            mImageStyle = Value

            ' Clear the border on all images

            For Each pb In Panel1.Controls
                pb.BorderStyle = System.Windows.Forms.BorderStyle.None
            Next pb

            ' Turn the border on on the selected image style

            If mImageStyle > 0 And Panel1.Controls.Count > 0 Then
                CType(Panel1.Controls(mImageStyle - 1), PictureBox).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            End If
        End Set
    End Property

End Class