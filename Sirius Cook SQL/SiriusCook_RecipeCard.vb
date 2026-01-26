Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.ServiceProcess
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions

Friend Class frmRecipeCard
	Inherits System.Windows.Forms.Form
	'**************************************************
	' SiriusCook SQL Print Recipe card options form
	' SIRIUSCOOK_RECIPECARD.VB
	' Written: November 2017
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2018 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables which are local to this module

	Private IsStarted As Boolean = False
	Private IsSideTwo As Boolean
	Private TwoSided As Boolean
	Private IsFavorite As Boolean
	Private dpiX As Integer
	Private dpiY As Integer
	Private lRec As DataRow
	Private mRec As DataRow
	Private DontProcessChangeEvent As Boolean
	Private Heading As String = ""
	Private ProcedureText As String = ""
	Private mCardStyle As Integer
	Private mLeftMargin As Single
	Private mHeadingMargin As Single
	Private mIngredientMargin As Single
	Private mProcedureMargin As Single
	Private mWidth As Single
	Private mHeight As Single
	Private INDENT As Single
	Private mScale As String
	Private mFontSize As Short
	Private mFontName As String
	Private Links As New Collection
	Private ListBoxData As New Collection
	Private LinksDS As New DataSet
	Private LinksTable As DataTable


	'**************************************************
	'
	' The form is loaded.
	'
	'**************************************************
	Private Sub RecipeCard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

		' Perform startup functions if they have not been performed yet.

		If Not IsStarted Then PerformStartup()

	End Sub
	'**************************************************
	'
	' The form is closed.
	'
	'**************************************************
	Private Sub RecipeCard_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.FormClosed

		' Destroy objects we have created.

		LinksDS.Dispose()

	End Sub


	'***************************************************
	'
	' A font size is selected
	'
	'***************************************************
	Private Sub Combo1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo1.SelectedIndexChanged

		If Combo1.SelectedIndex >= 0 Then
			mFontSize = Val(Combo1.SelectedItem)
		End If

		' Automatically preview the new size

		If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()

	End Sub


	'***************************************************
	'
	' A new font name is selected.
	'
	'***************************************************
	Private Sub Combo2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo2.SelectedIndexChanged

		' Save the font name

		mFontName = Combo2.SelectedItem

		' Automatically preview the new size

		If Not DontProcessChangeEvent Then
			If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()
		End If

	End Sub


	'**************************************************
	'
	' The Print button is clicked.
	'
	'**************************************************
	Private Sub btnPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnPrint.Click

		' Print the recipe card

		PrintRecipeCard()

	End Sub


	'**************************************************
	'
	' The exit button is clicked.
	'
	'**************************************************
	Private Sub btnExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnExit.Click

		' Save the settings with the recipe.

		SaveRecipeSettings()

		' Reset the flag that shows things are started, and close the form.

		IsStarted = False
		Me.Close()
	End Sub

	'**************************************************
	'
	' A bitmap file is selected for the card background.
	'
	'**************************************************
	Private Sub List1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles List1.SelectedIndexChanged

		mCardStyle = List1.SelectedIndex

		' Display the new background

		If Not DontProcessChangeEvent Then
			If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()
		End If
	End Sub

	'**************************************************
	'
	' A card size option is selected.
	'
	'**************************************************
	Private Sub cmbCardSize_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbCardSize.SelectedIndexChanged

		' Declare variables

		Dim zx As String
		Dim Origin3x5 As New Point(107, 112)
		Dim Origin4x6 As New Point(45, 55)
		Dim Origin5x7 As New Point(10, 10)
		Dim Origin8x11 As New Point(30, 0)

		' Determine the card size from the paper size selected.

		zx = cmbCardSize.SelectedItem.ToString.ToLower.Replace(" ", "")
		Dim pattern As String = "(\d+(?:\.\d+)?)\s*[x×]\s*(\d+(?:\.\d+)?)"
		Dim m As Match = Regex.Match(zx, pattern, RegexOptions.IgnoreCase)

		' Extract the page height and width from the name.  If letter was selected,
		' we have to reverse them, because it's ALWAYS expressed as 8.5 x 11, whereas
		' cards are always expressed as 4 x 6 or similar.

		If m.Success Then
			If m.Groups(1).Value = "8.5" Then
				mHeight = 11
				mWidth = 8.5
			Else
				mHeight = Val(m.Groups(1).Value)
				mWidth = Val(m.Groups(2).Value)
			End If
		End If

		' Determine the origin point for drawing from the card size

		Select Case mWidth
			Case 5
				pnlMargins.Location = Origin3x5
			Case 6
				pnlMargins.Location = Origin4x6
			Case 7
				pnlMargins.Location = Origin5x7
			Case 8
				pnlMargins.Location = Origin8x11
		End Select

		' Resize the preview panels for the selected size.  Resize the margin ruler.
		' Reposition the card side options.  Force everything to redraw.

		pnlPreview1.Left = pnlMargins.Left
		pnlPreview1.Top = pnlMargins.Top + pnlMargins.Height
		pnlPreview2.Location = pnlPreview1.Location
		Picture2.Top = pnlPreview1.Top

		' When sizing the preview panels, we have to watch for letter size, as 
		' that size needs to be scaled down in actual size.

		If mHeight = 11 Then
			' Fit the page vertically
			pnlPreview1.Height = Panel1.Height

			' Maintain the 8.5:11 aspect ratio
			pnlPreview1.Width = CInt(Panel1.Height * (8.5 / 11))

		Else
			' Cards: size panel to actual screen pixels
			pnlPreview1.Height = dpiY * mHeight
			pnlPreview1.Width = dpiX * mWidth
		End If

		' Convert height and width to hundredths of an inch.

		mWidth *= 100
		mHeight *= 100

		' Set the size of the preview panel and location of front/back tabs

		pnlPreview2.Height = pnlPreview1.Height
		pnlPreview2.Width = pnlPreview1.Width
		pnlMargins.Width = pnlPreview1.Width
		optCardSide_Front.Top = pnlPreview1.Top + pnlPreview1.Height - 2
		optCardSide_Front.Left = pnlMargins.Left - 2
		optCardSide_Back.Top = optCardSide_Front.Top
		optCardSide_Back.Left = pnlMargins.Left + optCardSide_Front.Width - 4

		' Force a redraw of the preview panels.

		pnlMargins.Invalidate()
		pnlPreview1.Invalidate()
		pnlPreview2.Invalidate()

	End Sub

	'**************************************************
	'
	' The margin type options are changed.
	'
	'**************************************************
	Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2_0.CheckedChanged, Option2_1.CheckedChanged

		' Adjust the margin indicators to show the current value

		pnlMargins.Invalidate()
	End Sub
	'**************************************************

	' The card side option has changed.

	'**************************************************
	Private Sub optCardSide_CheckedChanged(sender As Object, e As EventArgs) Handles optCardSide_Front.CheckedChanged, optCardSide_Back.CheckedChanged

		' Make the appropriate panel visible and the other invisible

		If sender Is optCardSide_Front Then
			pnlPreview1.Visible = True
			pnlPreview2.Visible = False
			pnlPreview1.Invalidate()
		Else
			pnlPreview1.Visible = False
			pnlPreview2.Visible = True
			pnlPreview2.Invalidate()
		End If

	End Sub

	'**************************************************
	'
	' The heading field has got the focus.  Select the
	' text.
	'
	'**************************************************
	Private Sub Text2_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.Enter

		' Move cursor to end of current text.

		Text2.SelectionStart = Len(Text2.Text)

	End Sub

	'**************************************************
	'
	' The heading field has lost the focus.  Save its
	' value.
	'
	'**************************************************
	Private Sub Text2_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.Leave

		' Remember the heading

		Heading = Text2.Text
		SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Recipe", "Heading", Text2.Text)


	End Sub
	'**************************************************

	' The mouse is pressed in the margin "ruler" panel

	'**************************************************
	Private Sub pnlMargins_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlMargins.MouseDown

		' Calculate the new margin position by the relationship:
		' xPosition/pnlmargins.width = NewMarginValue/numericupdown2

		If Option2_0.Checked Then mIngredientMargin = e.X * mWidth / pnlMargins.Width
		If Option2_1.Checked Then mProcedureMargin = e.X * mWidth / pnlMargins.Width

		' Because the printer requires a minimum margin, don't allow a margin of less than .25"

		If mIngredientMargin < 0.25 Then mIngredientMargin = 0.25
		If mProcedureMargin < 0.25 Then mProcedureMargin = 0.25

		' Force the margins "ruler" to redraw

		pnlMargins.Invalidate()

		' Force the recipe to redraw.

		If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()

	End Sub
	'**************************************************

	' The Margin setting panel needs to be redrawn.

	'**************************************************
	Private Sub pnlMargins_Paint(sender As Object, e As PaintEventArgs) Handles pnlMargins.Paint

		' Declare variables

		Dim ii As Integer
		Dim CardWidth As Single = mWidth
		Dim m As Single
		Dim x1 As Single
		Dim x2 As Single = pnlMargins.Left + pnlMargins.Width
		Dim y1 As Single = pnlMargins.Height / 2
		Dim y2 As Single = pnlMargins.Height
		Dim pa As New Drawing2D.GraphicsPath
		Dim PointsPerEighthInch As Single
		Dim b As New SolidBrush(Color.Blue)
		Dim p As New Pen(Brushes.Black, 2)
		Dim g As Graphics = e.Graphics

		' See what margin is selected and calculate its scaled position from the relationship:
		' DrawAtX / pnlMargins.width = MarginValue/CardSize

		If CardWidth > 100 Then CardWidth /= 100
		If Option2_0.Checked Then m = mIngredientMargin / CardWidth * pnlMargins.Width
		If Option2_1.Checked Then m = mProcedureMargin / CardWidth * pnlMargins.Width

		' Move the margin line to match

		Picture2.Left = pnlPreview1.Left + m

		' Make the margin line the same height as the preview panel.

		Picture2.Height = pnlPreview1.Height

		' Calculate a conversion for eighth-inch markers, pretending the width of the panel is the width of the card.

		PointsPerEighthInch = 0.125 / CardWidth * pnlMargins.Width

		' Begin drawing the markers

		x1 = 0
		p.Width = 1
		ii = 0
		Do While x1 < pnlMargins.Width
			If ii = 0 Then
				g.DrawLine(p, x1, 0, x1, y2)
			ElseIf ii = 2 Or ii = 4 Or ii = 6 Then
				g.DrawLine(p, x1, y1, x1, y2)
			Else
				g.DrawLine(p, x1, y1 + (y2 - y1) / 2, x1, y2)
			End If
			x1 = x1 + PointsPerEighthInch
			ii = ii + 1
			If ii = 8 Then ii = 0
		Loop

		' Now draw a symbol to represent the current margin setting.
		' We use a graphics path, since we are drawing a triangle.

		pa.AddLine(m - 4, y1, m + 4, y1)
		pa.AddLine(m + 4, y1, m, y2)
		pa.AddLine(m, y2, m - 4, y1)
		g.DrawPath(p, pa)
		g.FillPath(b, pa)

		' Dispose of objects we created

		b.Dispose()
		p.Dispose()
		pa.Dispose()

	End Sub

	'**************************************************
	'
	' Sub to paint the display panel
	'
	'**************************************************
	Private Sub PnlPreview_Paint(sender As Object, e As PaintEventArgs) Handles pnlPreview1.Paint, pnlPreview2.Paint

		' Declare variables

		PreviewRecipe()

	End Sub
	'**************************************************

	' The "favorite recipe" check box is clicked.

	'**************************************************
	Private Sub chkFavorite_Click(sender As Object, e As EventArgs) Handles chkFavorite.CheckedChanged
		IsFavorite = chkFavorite.Checked
		If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()
	End Sub
	'**************************************************

	' The "Include Notes" check box is clicked.

	'**************************************************
	Private Sub chkIncludeNotes_Click(sender As Object, e As EventArgs) Handles chkIncludeNotes.CheckedChanged
		If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()
	End Sub
	'**************************************************

	' The "Landscape Orientation" check box is clicked.

	'**************************************************
	Private Sub chkLandscape_CheckedChanged(sender As Object, e As EventArgs) Handles chkLandscape.CheckedChanged

		' Set the landscape mode.  We must set it for both the printer driver and the document itself.

		frmMain.PrintDocument1.DefaultPageSettings.Landscape = chkLandscape.Checked
		frmMain.PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = chkLandscape.Checked

		If optCardSide_Front.Checked Then pnlPreview1.Invalidate() Else pnlPreview2.Invalidate()
	End Sub
	'**************************************************
	'
	' Method to preview the recipe card
	'
	'**************************************************
	Public Function PreviewRecipe() As Boolean

		' Declare variables

		Dim OneSidedCard As Boolean = True
		Dim ii As Integer
		Dim jj As Integer
		Dim ll As Integer
		Dim Lines As Integer
		Dim y As Single
		Dim yy As Single
		Dim Col1Y As Single
		Static zx0 As String
		Dim zx1 As String
		Dim Ing(100) As String
		Dim p As Panel
		Dim srcRect As New Rectangle(55, 60, 523, 457)
		Dim destRect As Rectangle
		Dim g As Graphics

		Dim CardWidth As Single = mWidth
		Dim CardHeight As Single = mHeight
		If CardWidth > 100 Then CardWidth /= 100
		If CardHeight > 100 Then CardHeight /= 100


		' Determine the scale factor for displaying the recipe.

		Dim ScaleX = pnlPreview1.Width / (CardWidth * dpiX)
		Dim ScaleY = pnlPreview1.Height / (CardHeight * dpiY)
		Dim PageScale As Single = 1

		' If the page size is 8½ x 11, we need a page scaler

		If CardHeight = 11 Then PageScale = 1 / ScaleY

		' Create fonts scaled to match the card that will be printed.

		Dim fH As New System.Drawing.Font("Lucida Handwriting", mFontSize)
		Dim fI As New System.Drawing.Font(mFontName, mFontSize, FontStyle.Italic)
		Dim fSI As New System.Drawing.Font(mFontName, CSng(mFontSize), FontStyle.Italic)
		Dim fT As New System.Drawing.Font(mFontName, mFontSize, FontStyle.Bold)
		Dim fN As New System.Drawing.Font(mFontName, mFontSize)
		Dim fB As New System.Drawing.Font(mFontName, mFontSize, FontStyle.Italic)

		' Scale the graphics to match the printer.

		g = pnlPreview1.CreateGraphics
		g.ScaleTransform(ScaleX, ScaleY)
		p = pnlPreview1

		' Get the line height

		Dim LineHeight As Single = g.MeasureString("X", fN).Height
		INDENT = g.MeasureString("X", fN).Width

		' Draw the graphic to the "card"

		On Error Resume Next
		If mCardStyle > 0 Then g.DrawImage(Choose(mCardStyle, My.Resources.Recipe1, My.Resources.recipe2, My.Resources.Recipe3, My.Resources.Recipe4, My.Resources.Recipe5, My.Resources.Recipe6, My.Resources.Recipe7, My.Resources.Recipe8, My.Resources.Recipe9, My.Resources.Recipe10, My.Resources.Recipe11, My.Resources.Recipe12, My.Resources.Recipe14, My.Resources.Recipe15), 0, 0, p.Width, p.Height)

		' If the recipe is marked as a favorite, draw the "favorite" image.

		destRect = New Rectangle(p.Width * PageScale - 150, 0, 150, 134)
		If IsFavorite Then g.DrawImage(Image2.Image, destRect, srcRect, GraphicsUnit.Pixel)
		On Error GoTo 0

		' Print the heading centered in the form.

		yy = 0
		mHeadingMargin = (p.Width * PageScale - g.MeasureString(Heading, fH).Width) / 2 / dpiX
		g.DrawString(Heading, fH, Brushes.Black, mHeadingMargin * dpiX, yy)
		yy = yy + LineHeight * 1.5


		' Print the recipe name centered in the form.

		zx0 = GetR(mRec, "RecipeName")
		mLeftMargin = (p.Width * PageScale - g.MeasureString(zx0, fT).Width) / 2 / dpiX
		g.DrawString(zx0, fT, Brushes.Black, mLeftMargin * dpiX, yy)
		yy = yy + LineHeight


		' Print author name, centered, and food category and servings.  If
		' this recipe is to be marked as "favorite", we need to move all
		' those items down by one line so as not to print on top of the graphic.

		zx0 = GetR(mRec, "Author")
		If zx0 <> "" Then g.DrawString(zx0, fI, Brushes.Black, (p.Width * PageScale - g.MeasureString(zx0, fI).Width) / 2, yy)
		yy = yy + LineHeight * 1.5
		If IsFavorite Then yy += LineHeight

		zx0 = GetR(mRec, "Category")
		g.DrawString(zx0, fN, Brushes.Black, mProcedureMargin * dpiX, yy)
		If Val(GetR(mRec, "Servings")) > 0 Then
			zx0 = "Servings: " & GetR(mRec, "Servings")
			g.DrawString(zx0, fN, Brushes.Black, p.Width * PageScale - g.MeasureString(zx0 & "XX", fN).Width, yy)
		End If
		yy = yy + LineHeight * 1.5

		' Print the blurb

		zx0 = GetR(mRec, "Blurb")
		While zx0 <> ""
			ii = p.Width * PageScale - mProcedureMargin * dpiX
			g.DrawString(WordWrap(g, fB, zx0, ii), fB, Brushes.Black, mProcedureMargin * dpiX, yy)
			yy = yy + LineHeight
		End While
		yy = yy + LineHeight

		' Get the text of the ingredient list.  The variable
		' "Lines" will be returned with the number of ingredient
		' lines so we can split them roughly into two columns.

		zx0 = FormatIngredients(mRec("ID"), Lines)

		' Break the ingredient list into separate lines of
		' half the width of the email with a 1/4" space
		' between the two columns

		ii = 0
		While zx0 <> ""
			zx1 = WordWrap(g, fN, zx0, p.Width * PageScale / 2 - INDENT)
			ii = ii + 1
			Ing(ii) = zx1
		End While

		' Print the ingredients, half the lines in each column.

		Lines = ii ' "ii" contains the number of WORD-WRAPPED lines!
		ll = Fix(Lines / 2 + 0.5)
		y = yy
		For jj = 1 To ll
			If Ing(jj) <> "" Then
				g.DrawString(Ing(jj), fN, Brushes.Black, mIngredientMargin * dpiX, yy)
				yy = yy + LineHeight
			End If
		Next jj
		Col1Y = yy ' Remember how far down column1 went
		yy = y
		For jj = ll + 1 To Lines
			If Ing(jj) <> "" Then
				g.DrawString(Ing(jj), fN, Brushes.Black, (p.Width * PageScale / 2) + (mIngredientMargin * dpiX), yy)
				yy = yy + LineHeight
			End If
		Next jj
		If Col1Y > yy Then yy = Col1Y ' Begin printing procedure at lowest Y coordinate of ingredients
		yy += LineHeight * 2

		' Print the procedure, and optionally the notes.

		zx0 = GetR(mRec, "Procedure")
		If chkIncludeNotes.Checked Then zx0 &= vbCrLf & vbCrLf & "Notes: " & GetR(mRec, "Notes")
		While zx0 <> "" And yy < p.Height * PageScale - LineHeight * 2
			ii = p.Width * PageScale - (mProcedureMargin * dpiX)
			g.DrawString(WordWrap(g, fN, zx0, ii), fN, Brushes.Black, mProcedureMargin * dpiX, yy)
			yy = yy + LineHeight
		End While

		' If there is more to print, print a continued message at the bottom of the preview,
		' and print the remainder on the second preview panel.

		If zx0 <> "" Then
			g.DrawString("Continued on reverse side", fSI, Brushes.Black, mProcedureMargin * dpiX, yy)

			' Get the graphics to the second side panel.

			g = pnlPreview2.CreateGraphics
			g.ScaleTransform(scaleX, scaleY) ' Scale to printer resolution
			p = pnlPreview2

			' Print any remaining text on the second panel.

			yy = 0
			While zx0 <> "" And yy < p.Height * PageScale - LineHeight * 2
				ii = p.Width * PageScale - (mProcedureMargin * dpiX)
				g.DrawString(WordWrap(g, fN, zx0, ii), fN, Brushes.Black, mProcedureMargin * dpiX, yy)
				yy = yy + LineHeight
			End While

			' Return false to indicate the recipe didn't fit on one side.

			OneSidedCard = False
		End If

		' Delete the objects we've created

		fN.Dispose()
		fT.Dispose()
		fI.Dispose()
		fH.Dispose()
		fB.Dispose()

		' Return False if we were not able to preview the entire recipe

		Return OneSidedCard


	End Function

	'**************************************************
	'
	' Sub to print the recipe card
	'
	'**************************************************
	Private Sub PrintRecipeCard()

		' Declare variables

		Dim IncludeLinkedRecipes As Boolean = False
		Dim jj As Integer
		Dim xx As Integer
		Dim zx As String
		Dim ps As PaperSize = Nothing
		Dim Prn As Printing.PrintDocument = frmMain.PrintDocument1
		Dim f As New frmSelectLinkedRecipes
		Dim RecipesDS As DataSet
		Dim RecipesTable As DataTable
		'Dim PrintSpooler As ServiceController = New ServiceController("Spooler", "Laptop1")

		' See if the recipe contains any links to other recipes.

		If LinksTable.Rows.Count > 0 Then
			zx = FormatIngredients(mRec("ID")) & vbCrLf & GetR(mRec, "Procedure")
			For jj = 0 To LinksTable.Rows.Count - 1
				If InStr(zx, GetR(LinksTable.Rows(jj), "LinkText"), CompareMethod.Text) > 0 Then
					f.CheckedListBox1.Items.Add(LinksTable.Rows(jj)("LinkText"))
					ListBoxData.Add(LinksTable.Rows(jj)("LinkedID"))
				End If
			Next jj
			If ListBoxData.Count > 0 Then f.ShowDialog()
			If f.DialogResult = Windows.Forms.DialogResult.OK Then IncludeLinkedRecipes = True
		End If

		' Disable the print button while we do this

		btnPrint.Enabled = False
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

		' Put up status message

		frmMain.StatusLabel.Text = "Printing " & GetR(mRec, "RecipeName") & "..."
		System.Windows.Forms.Application.DoEvents() '  Allow time to update

		' Set the event handler for printing

		AddHandler Prn.PrintPage, AddressOf PrintRecipeCard_PagePrint

		' Set the document name

		Prn.DocumentName = GetR(mRec, "RecipeName")

		' Get the selected paper size.

		Dim desiredName As String = cmbCardSize.SelectedItem.ToString()

		For Each ps In frmMain.PrintDocument1.PrinterSettings.PaperSizes
			If ps.PaperName.Equals(desiredName, StringComparison.OrdinalIgnoreCase) Then
				frmMain.PrintDocument1.DefaultPageSettings.PaperSize = ps
				Exit For
			End If
		Next ps

		' Get the print options

		frmMain.PrintDialog1.Document = frmMain.PrintDocument1
		frmMain.PrintDialog1.PrinterSettings.Collate = True

		' Because of a behavior in WinForms, we must set the paper size in both DefaultPageSettings
		' as well as PrinterSettings.DefaultPageSettings.
		' The Print dialog reads from PrinterSettings.DefaultPageSettings.
		' The actual print job reads from DefaultPageSettings.

		If Not ps Is Nothing Then
			frmMain.PrintDocument1.DefaultPageSettings.PaperSize = ps
			frmMain.PrintDocument1.PrinterSettings.DefaultPageSettings.PaperSize = ps
		End If

		' Same with landscape mode: we must set it in both places.

		frmMain.PrintDocument1.DefaultPageSettings.Landscape = chkLandscape.Checked
		frmMain.PrintDocument1.PrinterSettings.DefaultPageSettings.Landscape = chkLandscape.Checked

		' See if the user said to print.

		If frmMain.PrintDialog1.ShowDialog = DialogResult.OK Then

			' Print the current recipe first.

			lRec = mRec
			IsSideTwo = False
			Prn.Print()

			' Indicate if we have to print the rest of the procedure on the second side.  

			If ProcedureText <> "" Then
				IsSideTwo = True
				If MsgBox("Turn card over for printing second side, or click Cancel to stop printing.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, Prn.DocumentName) = MsgBoxResult.Ok Then
					Prn.Print()
				ElseIf IncludeLinkedRecipes Then
					If MsgBox("Do you want to cancel all linked recipes also?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Prn.DocumentName) = MsgBoxResult.Yes Then IncludeLinkedRecipes = False
				End If
			End If

			' Now, if the user has selected to print any linked recipes, print those.

			If IncludeLinkedRecipes Then

				' Get a copy of the recipes dataset.

				RecipesDS = New DataSet
				RecipesDA.SelectCommand = New SqlCommand("SELECT * FROM tblRecipes ORDER BY ID", DB)
				RecipesDA.Fill(RecipesDS, "Table")
				RecipesTable = RecipesDS.Tables("Table")
				RecipesDA.SelectCommand = RecipesSelectCommand()

				' For each linked recipe we are going to print, get the recipe record.

				For jj = 0 To f.CheckedListBox1.CheckedItems.Count - 1
					xx = Find2(RecipesTable, "ID=" & ListBoxData(f.CheckedListBox1.CheckedIndices(jj) + 1))
					If xx <> NOMATCH Then

						' Get the recipe into a local data row.

						lRec = RecipesTable.Rows(xx)

						' Set the document name

						Prn.DocumentName = GetR(lRec, "RecipeName")

						' Print the first side of the card.

						IsSideTwo = False
						Prn.Print()

						' Indicate if we have to print the rest of the procedure on the second side.  

						If ProcedureText <> "" Then
							IsSideTwo = True
							If MsgBox("Turn card over for printing second side, or click Cancel to stop printing.", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, Prn.DocumentName) = MsgBoxResult.Cancel Then Exit For
							Prn.Print()
						End If
					End If
				Next jj

				' Destroy objects we've created.

				RecipesDS.Dispose()
			End If
		End If

		' Restart the print spooler.

		'PrintSpooler.Start()

		RemoveHandler Prn.PrintPage, AddressOf PrintRecipeCard_PagePrint

		' Restore the mousepointer and reenable the print button

		Me.Cursor = System.Windows.Forms.Cursors.Default
		btnPrint.Enabled = True

		' Clear status message

		frmMain.StatusLabel.Text = ""
		System.Windows.Forms.Application.DoEvents() '  Allow time to update

	End Sub


	'**************************************************
	'
	' Sub to print a page of the recipe card
	'
	'**************************************************
	Private Sub PrintRecipeCard_PagePrint(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)

		' Declare variables

		Dim ii As Integer
		Dim jj As Integer
		Dim ll As Integer
		Dim Lines As Integer
		Dim y As Single
		Static yy As Single
		Dim Col1Y As Single
		Dim CWidth As Single
		Dim CHeight As Single
		Dim Margin As Single
		Static zx0 As String
		Dim zx1 As String
		Dim Ing(60) As String
		Dim srcRect As New Rectangle(53, 58, 523, 457)
		Dim destRect As Rectangle
		Dim g As Graphics = ev.Graphics

		Dim fH As New System.Drawing.Font("Lucida Handwriting", mFontSize + 2)
		Dim fI As New System.Drawing.Font(mFontName, mFontSize - 2, FontStyle.Italic)
		Dim fSI As New System.Drawing.Font(mFontName, CSng(mFontSize - 3.5), FontStyle.Italic)
		Dim fT As New System.Drawing.Font(mFontName, mFontSize + 2, FontStyle.Bold)
		Dim fN As New System.Drawing.Font(mFontName, mFontSize - 0.25)
		Dim fB As New System.Drawing.Font("Times New Roman", mFontSize, FontStyle.Italic)

		' Get the line height

		Dim LineHeight As Single = g.MeasureString("X", fN).Height
		INDENT = g.MeasureString("X", fN).Width

		' Get the card size in pixels, based on the screen resolution.

		CWidth = mWidth * dpiX
		CHeight = mHeight * dpiY

		' If we are printing the second side of a card, skip most of this

		If Not IsSideTwo Then

			' Draw the selected graphic to the, if any.

			On Error Resume Next
			If mCardStyle > 0 Then g.DrawImage(Choose(mCardStyle, My.Resources.Recipe1, My.Resources.recipe2, My.Resources.Recipe3, My.Resources.Recipe4, My.Resources.Recipe5, My.Resources.Recipe6, My.Resources.Recipe7, My.Resources.Recipe8, My.Resources.Recipe9, My.Resources.Recipe10, My.Resources.Recipe11, My.Resources.Recipe12, My.Resources.Recipe14, My.Resources.Recipe15), 0, 0, CWidth, CHeight)
			On Error GoTo 0

			' If the recipe is marked as a favorite, draw the "favorite" image.

			On Error Resume Next
			destRect = New Rectangle(CWidth - 177, 0, 150, 134)
			If IsFavorite Then g.DrawImage(Image2.Image, destRect, srcRect, GraphicsUnit.Pixel)
			On Error GoTo 0

			' Print the heading centered in the form.

			yy = 0
			mHeadingMargin = (CWidth - g.MeasureString(Heading, fH).Width) / 2 / dpiX
			g.DrawString(Heading, fH, Brushes.Black, mHeadingMargin * dpiX, yy)
			yy = yy + LineHeight * 1.5


			' Print the recipe name.

			zx0 = GetR(lRec, "RecipeName")
			mLeftMargin = (CWidth - g.MeasureString(zx0, fT).Width) / 2 / dpiX
			g.DrawString(zx0, fT, Brushes.Black, mLeftMargin * dpiX, yy)
			yy = yy + LineHeight


			' Print author name, centered, and food category and servings.  If
			' this recipe is to be marked as "favorite", we need to move all
			' those items down by one line so as not to print on top of the graphic.

			zx0 = GetR(lRec, "Author")
			If zx0 <> "" Then g.DrawString(zx0, fI, Brushes.Black, (CWidth - g.MeasureString(zx0, fI).Width) / 2, yy)
			yy = yy + LineHeight * 1.5
			If IsFavorite Then yy += LineHeight

			Margin = mProcedureMargin - 0.25
			If Margin < 0 Then Margin = 0
			zx0 = GetR(lRec, "Category")
			g.DrawString(zx0, fN, Brushes.Black, Margin * dpiX, yy)
			If Val(GetR(lRec, "Servings")) > 0 Then
				zx0 = "Servings: " & GetR(lRec, "Servings")
				g.DrawString(zx0, fN, Brushes.Black, CWidth - g.MeasureString(zx0 & "XXXX", fN).Width, yy)
			End If
			yy = yy + LineHeight * 1.5

			' Print the blurb

			zx0 = GetR(lRec, "Blurb")
			While zx0 <> ""
				ii = CWidth - Margin * dpiX - INDENT
				g.DrawString(WordWrap(g, fB, zx0, ii), fB, Brushes.Black, Margin * dpiX, yy)
				yy = yy + LineHeight
			End While
			yy = yy + LineHeight

			' Get the text of the ingredient list.  The variable
			' "Lines" will return with the number of ingredient
			' lines, which allows us to split the list into
			' two columns evenly.

			zx0 = FormatIngredients(lRec("ID"), Lines)

			' Break the ingredient list into separate lines of
			' half the width of the email with a 1/4" space
			' between the two columns

			ii = 0
			Margin = mIngredientMargin - 0.25 ' Printer has a .25" margin at x=0
			If Margin < 0 Then Margin = 0
			While zx0 <> ""
				zx1 = WordWrap(g, fN, zx0, (CWidth / 2.1) - (Margin * dpiX))
				ii = ii + 1
				Ing(ii) = zx1
			End While

			' Print the ingredients

			Lines = ii ' "ii" contains the number of WORD-WRAPPED lines!
			ll = Fix(Lines / 2 + 0.5)
			y = yy
			For jj = 1 To ll
				If Ing(jj) <> "" Then
					g.DrawString(Ing(jj), fN, Brushes.Black, Margin * dpiX, yy)
					yy = yy + LineHeight
				End If
			Next jj
			Col1Y = yy ' Remember lowest Y point of column1
			yy = y
			For jj = ll + 1 To Lines
				If Ing(jj) <> "" Then
					g.DrawString(Ing(jj), fN, Brushes.Black, (CWidth / 2.1) + (Margin * dpiX), yy)
					yy = yy + LineHeight
				End If
			Next jj
			If Col1Y > yy Then yy = Col1Y ' Begin procedure at lowest Y coordinate of ingredients
			yy = yy + LineHeight

			' Get the text of the procedure.

			ProcedureText = GetR(lRec, "Procedure")
			If chkIncludeNotes.Checked Then ProcedureText &= vbCrLf & vbCrLf & "Notes: " & GetR(mRec, "Notes")

			' On side two, start at the top of the card.
		Else
			yy = 0
		End If

		' Print the procedure.

		yy += LineHeight / 2
		Margin = mProcedureMargin - 0.25 ' Printer has a .25" margin at x=0
		If Margin < 0 Then Margin = 0
		While ProcedureText <> "" And yy <= CHeight - LineHeight * 3
			ii = CWidth - Margin * dpiX - INDENT
			g.DrawString(WordWrap(g, fN, ProcedureText, ii), fN, Brushes.Black, Margin * dpiX, yy)
			yy = yy + LineHeight
		End While

		' If there is more to print, print a continued message at the bottom of the card

		If ProcedureText <> "" Then
			g.DrawString("Continued on reverse side", fSI, Brushes.Black, Margin * dpiX, yy)
		End If

		' Delete the objects we've created

		fN.Dispose()
		fT.Dispose()
		fI.Dispose()
		fSI.Dispose()
		fH.Dispose()
		fB.Dispose()

		' Always indicate there is no more to print.  If the recipe requires a second side, this procedure
		' will be called a second time.  This allows the spooler to print the first side without
		' waiting for the second side.

		ev.HasMorePages = False
	End Sub

	'**************************************************

	' Sub to save the settings to the recipe's file.

	'**************************************************
	Private Sub SaveRecipeSettings()

		' Declare variables

		Dim SQLStmt As String
		Dim Command As SqlCommand
		Dim Transaction As SqlTransaction

		' Assemble the update query command text.

		SQLStmt = "UPDATE tblRecipes SET CardStyle='" & mCardStyle & "',CardWidth=" & mWidth & ",CardHeight=" & mHeight & ",Scale='" & mScale & "',FontName='" & mFontName & "',FontSize=" & mFontSize & ",LeftMargin=" & mLeftMargin & ",[Heading Margin]=" & mHeadingMargin & ",IngredientsMargin=" & mIngredientMargin & ",ProcedureMargin=" & mProcedureMargin & ",Favorite=" & CInt(chkFavorite.Checked) & " WHERE ID=" & mRec("ID")

		' Set up the command

		Command = New SqlCommand(SQLStmt, DB)

		' Begin a transaction.

		Transaction = DB.BeginTransaction
		Command.Transaction = Transaction

		' Execute the query to update the recipe.
		Try
			Command.ExecuteNonQuery()
			Transaction.Commit()
		Catch e As Exception
			MsgBox("Error printing recipe" & vbCrLf & e.Message, MsgBoxStyle.Exclamation, "Print Recipe")
			Transaction.Rollback()
		End Try

		' Clear and rebuild the "favorites" menu to reflect the change.

		FillFavoritesMenu(False)
		FillFavoritesMenu(True)

	End Sub
	'**************************************************

	' Function to test for "approximately equal to"

	'**************************************************
	Private Function Approx(a As Integer, b As Integer, Optional tol As Integer = 3) As Boolean
		Return Math.Abs(a - b) <= tol
	End Function
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

			' Declare variables

			Dim ii As Integer
			Dim jj As Integer
			Dim allowed As String() = {"3x5", "3 x 5", "3.5x5", "3.5 x 5", "4x6", "4 x 6", "5x7", "5 x 7", "8.5x11", "8.5 x 11"}

			' Set the local recordset to the new value

			mRec = Value

			' If startup has not been performed, do that now

			If Not IsStarted Then PerformStartup()

			' Get the saved values for margins, heading, card size
			' font name, font size, etc.

			mLeftMargin = GetR(mRec, "LeftMargin")
			mIngredientMargin = GetR(mRec, "IngredientsMargin")
			mProcedureMargin = GetR(mRec, "ProcedureMargin")
			mHeadingMargin = GetR(mRec, "Heading Margin")
			mHeight = GetR(mRec, "CardHeight")
			If mHeight < 100 Then mHeight *= 100
			mWidth = GetR(mRec, "CardWidth")
			If mWidth < 100 Then mWidth *= 100
			mScale = GetR(mRec, "Scale")
			mFontSize = GetR(mRec, "FontSize")
			mFontName = GetR(mRec, "FontName")
			mCardStyle = GetR(mRec, "CardStyle")
			IsFavorite = GetR(mRec, "Favorite")

			' If the recipe has never been printed before, the height and width will be zero.
			' Set them to the default 4 x 6.

			If mWidth = 0 Then
				mWidth = 600
				mHeight = 400
			End If

			' If the width > height, then select landscape mode.

			If mWidth > mHeight Then chkLandscape.Checked = True

			' Fill the supported card sizes list box.

			cmbCardSize.Items.Clear()
			For Each ps As PaperSize In frmMain.PrintDocument1.PrinterSettings.PaperSizes
				Dim name As String = ps.PaperName.ToLower()

				' See if the paper size name contains the allowed descriptors.

				For jj = 0 To allowed.Count - 1
					If allowed.Any(Function(a) name.Contains(a)) Then
						ii = cmbCardSize.Items.Add(ps.PaperName)

						' If the current paper size matches the last-used size, select it as the default.
						' Because we don't know, due to landscape mode, whether height and width are
						' swapped, just make sure both height and width both match.

						If (Approx(ps.Width, mWidth) AndAlso Approx(ps.Height, mHeight) OrElse (Approx(ps.Width, mHeight) AndAlso Approx(ps.Height, mWidth))) Then
							cmbCardSize.SelectedIndex = ii
						End If
						Exit For
					End If
				Next jj
			Next ps

			If mIngredientMargin = 0 Then mIngredientMargin = 0.1
			If mProcedureMargin = 0 Then mProcedureMargin = 0.1
			If mFontSize = 0 Then mFontSize = 9
			If mFontName = "" Then mFontName = "Arial"
			chkFavorite.Checked = IsFavorite

			' Get the saved value of the text of the header

			Heading = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "Recipe", "Heading", "")
			If Heading = "" Then Heading = "From the Kitchen of " & GetControlItem("CooksName")
			Text2.Text = Heading

			' Select the card image, if any, from the list box

			List1.SelectedIndex = mCardStyle

			' Select the the font size from the list box

			DontProcessChangeEvent = True
			For jj = 0 To Combo1.Items.Count - 1
				If Val(Combo1.Items(jj)) = mFontSize Then
					Combo1.SelectedIndex = jj
					Exit For
				End If
			Next jj


			' Select the font name from the list box

			For jj = 0 To Combo2.Items.Count - 1
				If Combo2.Items(jj) = mFontName Then
					Combo2.SelectedIndex = jj
					Exit For
				End If
			Next jj
			DontProcessChangeEvent = False

			' Select the ingredients margin type as default

			Option2_0.Checked = True

		End Set
	End Property

	'**************************************************

	' Sub to prepare the form

	'**************************************************
	Private Sub PerformStartup()

		' Add the images from the resources first

		List1.Items.Clear()
		List1.Items.Add("(None)")
		List1.Items.Add("Recipe1")
		List1.Items.Add("Recipe2")
		List1.Items.Add("Recipe3")
		List1.Items.Add("Recipe4")
		List1.Items.Add("Recipe5")
		List1.Items.Add("Recipe6")
		List1.Items.Add("Recipe7")
		List1.Items.Add("Recipe8")
		List1.Items.Add("Recipe9")
		List1.Items.Add("Recipe10")
		List1.Items.Add("Recipe11")
		List1.Items.Add("Recipe12")
		List1.Items.Add("Recipe13")
		List1.Items.Add("Recipe14")
		List1.Items.Add("Recipe15")

		' Set the default margin selection to "Ingredients Margin".

		Option2_0.Checked = True

		' Fill the font list box with the names of
		' installed fonts

		FillFontList(Combo2)

		' Get the screen resolution.

		dpiX = Me.CreateGraphics().DpiX
		dpiY = Me.CreateGraphics().DpiY

		' Set the back side panel to the same size
		' as the front size panel.

		pnlPreview2.Height = pnlPreview1.Height
		pnlPreview2.Width = pnlPreview1.Width

		' Force the margins "ruler" to resize

		pnlMargins.Width = pnlPreview1.Width
		pnlMargins.Invalidate()

		' Get the links table.

		LinksDS.Clear()
		LinksDA.Fill(LinksDS, "Table")
		LinksTable = LinksDS.Tables("Table")

		' Flag that startup has completed.

		IsStarted = True
	End Sub

End Class