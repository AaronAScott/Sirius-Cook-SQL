Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.ServiceProcess
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

		If Not DontProcessChangeEvent Then pnlPreview1.Invalidate()

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

		If Not DontProcessChangeEvent Then pnlPreview1.Invalidate()

	End Sub


	'**************************************************
	'
	' The Print button is clicked.
	'
	'**************************************************
	Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click

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

		pnlPreview1.Invalidate()

	End Sub

	'**************************************************
	'
	' A card size option is selected.
	'
	'**************************************************
	Private Sub optCardSize_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optCardSize_1.CheckedChanged, optCardSize_2.CheckedChanged, optCardSize_3.CheckedChanged

		' Declare variables

		Dim Origin3x5 As New Point(107, 112)
		Dim Origin4x6 As New Point(45, 55)
		Dim Origin5x7 As New Point(10, 10)

		' Determine the card size from the option checked.

		If eventSender.Checked Then
			If eventSender Is optCardSize_1 Then
				mWidth = 5
				mHeight = 3
				pnlMargins.Location = Origin3x5
			ElseIf eventSender Is optCardSize_2 Then
				mWidth = 6
				mHeight = 4
				pnlMargins.Location = Origin4x6
			Else
				mWidth = 7
				mHeight = 5
				pnlMargins.Location = Origin5x7
			End If

			' Resize the preview panels for the selected size.  Resize the margin ruler.
			' Reposition the card side options.  Force everything to redraw.

			pnlPreview1.Left = pnlMargins.Left
			pnlPreview1.Top = pnlMargins.Top + pnlMargins.Height
			pnlPreview2.Location = pnlPreview1.Location
			Picture2.Top = pnlPreview1.Top
			pnlPreview1.Height = dpiY * mHeight
			pnlPreview1.Width = dpiX * mWidth
			pnlPreview2.Height = pnlPreview1.Height
			pnlPreview2.Width = pnlPreview1.Width
			pnlMargins.Width = pnlPreview1.Width
			optCardSide_Front.Top = pnlPreview1.Top + pnlPreview1.Height - 2
			optCardSide_Front.Left = pnlMargins.Left - 2
			optCardSide_Back.Top = optCardSide_Front.Top
			optCardSide_Back.Left = pnlMargins.Left + optCardSide_Front.Width - 4
			pnlMargins.Invalidate()
			pnlPreview1.Invalidate()
			pnlPreview2.Invalidate()
		End If

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
		Else
			pnlPreview1.Visible = False
			pnlPreview2.Visible = True
		End If

		' Redraw the recipe

		pnlPreview1.Invalidate()
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

		' Force the recipe to redraw.  Always redraw panel 1, even if it's not visible,
		' because we can't redraw panel 2 until panel 1 is "full".

		pnlPreview1.Invalidate()
		If optCardSide_Back.Checked Then pnlPreview2.Invalidate()

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

		Dim renderer As New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ToolTip.Balloon.Normal)
		Dim zx0 As String = "This recipe may require printing on both sides of the card."
		Dim rectangle1 As New Rectangle(50, 50, e.Graphics.MeasureString(zx0, sender.Font).Width, e.Graphics.MeasureString(zx0, sender.Font).Height * 2)
		Dim g As Graphics = e.Graphics

		' Preview the recipe

		TwoSided = False
		If PreviewRecipe() = False Then ' Could not preview entire recipe

			' Display a tool tip telling the user than the recipe will
			' require two sides.

			'TwoSided = True
			'renderer.DrawBackground(g, rectangle1)
			'g.DrawString(zx0, Me.Font, Brushes.Blue, rectangle1.X, rectangle1.Y + (rectangle1.Height - g.MeasureString("X", Me.Font).Height) / 2)
		End If

	End Sub
	'**************************************************

	' The "favorite recipe" check box is clicked.

	'**************************************************
	Private Sub chkFavorite_Click(sender As Object, e As EventArgs) Handles chkFavorite.Click
		IsFavorite = chkFavorite.Checked
		pnlPreview1.Invalidate()
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
		Dim g As Graphics
		Dim p As Panel
		Dim srcRect As New Rectangle(55, 60, 523, 457)
		Dim destRect As Rectangle

		' Create fonts scaled to match the card that will be printed.

		Dim fH As New System.Drawing.Font("Lucida Handwriting", mFontSize + 2)
		Dim fI As New System.Drawing.Font(mFontName, mFontSize - 2, FontStyle.Italic)
		Dim fSI As New System.Drawing.Font(mFontName, CSng(mFontSize - 3.5), FontStyle.Italic)
		Dim fT As New System.Drawing.Font(mFontName, mFontSize + 2, FontStyle.Bold)
		Dim fN As New System.Drawing.Font(mFontName, mFontSize + 0.4)
		Dim fB As New System.Drawing.Font(mFontName, mFontSize, FontStyle.Italic)

		' Start with side 1.

		g = pnlPreview1.CreateGraphics
		p = pnlPreview1

		' Get the line height

		Dim LineHeight As Single = g.MeasureString("X", fN).Height
		INDENT = g.MeasureString("X", fN).Width

		' Draw the graphic to the "card"

		On Error Resume Next
		If mCardStyle > 0 Then g.DrawImage(Choose(mCardStyle, My.Resources.Recipe1, My.Resources.recipe2, My.Resources.Recipe3, My.Resources.Recipe4, My.Resources.Recipe5, My.Resources.Recipe6, My.Resources.Recipe7, My.Resources.Recipe8, My.Resources.Recipe9, My.Resources.Recipe10, My.Resources.Recipe11, My.Resources.Recipe12, My.Resources.Recipe14, My.Resources.Recipe15), 0, 0, p.Width, p.Height)

		' If the recipe is marked as a favorite, draw the "favorite" image.

		destRect = New Rectangle(p.Width - 150, 0, 150, 134)
		If IsFavorite Then g.DrawImage(Image2.Image, destRect, srcRect, GraphicsUnit.Pixel)
		On Error GoTo 0

		' Print the heading centered in the form.

		yy = 0
		mHeadingMargin = (p.Width - g.MeasureString(Heading, fH).Width) / 2 / dpiX
		g.DrawString(Heading, fH, Brushes.Black, mHeadingMargin * dpiX, yy)
		yy = yy + LineHeight * 1.5


		' Print the recipe name centered in the form.

		zx0 = GetR(mRec, "RecipeName")
		mLeftMargin = (p.Width - g.MeasureString(zx0, fT).Width) / 2 / dpiX
		g.DrawString(zx0, fT, Brushes.Black, mLeftMargin * dpiX, yy)
		yy = yy + LineHeight


		' Print author name, centered, and food category and servings.  If
		' this recipe is to be marked as "favorite", we need to move all
		' those items down by one line so as not to print on top of the graphic.

		zx0 = GetR(mRec, "Author")
		If zx0 <> "" Then g.DrawString(zx0, fI, Brushes.Black, (p.Width - g.MeasureString(zx0, fI).Width) / 2, yy)
		yy = yy + LineHeight * 1.5
		If IsFavorite Then yy += LineHeight

		zx0 = GetR(mRec, "Category")
		g.DrawString(zx0, fN, Brushes.Black, mProcedureMargin * dpiX, yy)
		If Val(GetR(mRec, "Servings")) > 0 Then
			zx0 = "Servings: " & GetR(mRec, "Servings")
			g.DrawString(zx0, fN, Brushes.Black, p.Width - g.MeasureString(zx0 & "XX", fN).Width, yy)
		End If
		yy = yy + LineHeight * 1.5

		' Print the blurb

		zx0 = GetR(mRec, "Blurb")
		While zx0 <> ""
			ii = p.Width - mProcedureMargin * dpiX
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
			zx1 = WordWrap(g, fN, zx0, p.Width / 2 - INDENT)
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
				g.DrawString(Ing(jj), fN, Brushes.Black, (p.Width / 2) + (mIngredientMargin * dpiX), yy)
				yy = yy + LineHeight
			End If
		Next jj
		If Col1Y > yy Then yy = Col1Y ' Begin printing procedure at lowest Y coordinate of ingredients
		yy += LineHeight * 2

		' Print the procedure.

		zx0 = GetR(mRec, "Procedure")
		While zx0 <> "" And yy < p.Height - LineHeight * 2
			ii = p.Width - (mProcedureMargin * dpiX)
			g.DrawString(WordWrap(g, fN, zx0, ii), fN, Brushes.Black, mProcedureMargin * dpiX, yy)
			yy = yy + LineHeight
		End While

		' If there is more to print, print a continued message at the bottom of the preview,
		' and print the remainder on the second preview panel.

		If zx0 <> "" Then
			g.DrawString("Continued on reverse side", fSI, Brushes.Black, mProcedureMargin * dpiX, yy)

			' Get the graphics to the second side panel.

			g = pnlPreview2.CreateGraphics
			p = pnlPreview2

			' Print any remaining text on the second panel.

			yy = 0
			While zx0 <> "" And yy < p.Height - LineHeight * 2
				ii = p.Width - (mProcedureMargin * dpiX)
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

		' Set the panel sizes to the card size.

		'g = Me.CreateGraphics
		dpiX = 100 ' g.dpix
		dpiY = 100 ' g.dpiy
		'g.Dispose()

		' Default card size is 4 x 6.

		optCardSize_2.Checked = True
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

		cmdPrint.Enabled = False
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

		' Put up status message

		frmMain.StatusLabel.Text = "Printing " & GetR(mRec, "RecipeName") & "..."
		System.Windows.Forms.Application.DoEvents() '  Allow time to update

		' Set the event handler for printing

		AddHandler Prn.PrintPage, AddressOf PrintRecipeCard_PagePrint

		' Set the document name

		Prn.DocumentName = GetR(mRec, "RecipeName")

		' Get the print options

		frmMain.PrintDialog1.Document = frmMain.PrintDocument1
		frmMain.PrintDialog1.PrinterSettings.Collate = True
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
		cmdPrint.Enabled = True

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

			Dim jj As Integer

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
			mWidth = GetR(mRec, "CardWidth")
			mScale = GetR(mRec, "Scale")
			mFontSize = GetR(mRec, "FontSize")
			mFontName = GetR(mRec, "FontName")
			mCardStyle = GetR(mRec, "CardStyle")
			IsFavorite = GetR(mRec, "Favorite")

			' Set default values for margins, height and width for any option
			' not set.

			If mHeight = 0 Then mHeight = 4
			If mWidth = 0 Then mWidth = 6
			If mHeight = 3 Then
				optCardSize_1.Checked = True
			ElseIf mHeight = 4 Then
				optCardSize_2.Checked = True
			Else
				optCardSize_3.Checked = True
			End If
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

End Class