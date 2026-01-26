Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices

Public Class frmViewRecipe
	'**************************************************
	' SiriusCook SQL View Recipe form
	' SIRIUSCOOK_VIEWRECIPE.VB
	' Written: November 2023
	' Updated: July 2025
	' Programmer: Aaron Scott
	' Copyright (C) 1997-2025 Sirius Software All Rights Reserved
	'**************************************************

	' Declare function that will let this form block screensaver and shutdown.

	<DllImport("kernel32.dll", SetLastError:=True)>
	Private Shared Function SetThreadExecutionState(ByVal esFlags As EXECUTION_STATE) As EXECUTION_STATE
	End Function

	<Flags()>
	Private Enum EXECUTION_STATE As Integer
		ES_CONTINUOUS = &H80000000
		ES_DISPLAY_REQUIRED = &H2
		ES_SYSTEM_REQUIRED = &H1
		' Add ES_AWAYMODE_REQUIRED if using media playback scenarios
	End Enum

	' Declare variables local to this module

	Private mViewedRecipeIndex As Integer = 0
	Private mRecipeTable As DataTable
	Private mRec As DataRow
	Private LinksDS As New DataSet
	Private LinksTable As DataTable
	Private RecipeCollection As New List(Of DataRow)

	'**************************************************

	' The form is loaded.

	'**************************************************
	Private Sub frmViewRecipe_Load(sender As Object, e As EventArgs) Handles Me.Load

		' Always view a recipe full-screen.

		Me.WindowState = FormWindowState.Maximized

		' Prevent screen blackout or timeouts.

		SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_DISPLAY_REQUIRED)

	End Sub

	'**************************************************

	' The Close icon is clicked.

	'**************************************************
	Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

		' Restore the ability for the screen to timeout

		SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)

		Me.Close()
	End Sub
	'**************************************************

	' The form is resized.

	'**************************************************
	Private Sub frmViewRecipe_Resize(sender As Object, e As EventArgs) Handles Me.Resize

		' Adjust the position of the close icon, and the width of the recipe title label.

		PictureBox2.Left = Me.Width - 54
		picNext.Left = PictureBox2.Left - 57
		lblRecipeName.Width = picNext.Left - lblRecipeName.Left - 8

	End Sub
	'**************************************************

	' The close context menu item is clicked.

	'**************************************************
	Private Sub mnuClose_Click(sender As Object, e As EventArgs) Handles mnuClose.Click
		Me.Close()
	End Sub
	'**************************************************

	' The minimize context menu item is clicked.

	'**************************************************
	Private Sub mnuMinimize_Click(sender As Object, e As EventArgs) Handles mnuMinimize.Click
		Me.WindowState = FormWindowState.Minimized
	End Sub
	'**************************************************

	' The zoom context menu item is clicked.

	'**************************************************
	Private Sub mnuZoom_Click(sender As Object, e As EventArgs) Handles mnu80.Click, mnu90.Click, mnu100.Click, mnu125.Click, mnu150.Click

		' Get the zoom factor from the name of the menu item.

		Dim ii As Integer = CInt(CType(sender, ToolStripMenuItem).Name.Substring(3))
		WebView21.ZoomFactor = ii / 100

		' Rebuild the webpage for the next virtual size and display it.

		WebView21.NavigateToString(FormatHTML(mRec))
	End Sub
	'**************************************************
	'
	' Function to return the recipe formatted to view
	' in a web browser.
	'
	'**************************************************
	Private Function FormatHTML(mRec As DataRow) As String


		' Declare variables

		Dim ii As Integer
		Dim jj As Integer
		Dim Lines As Integer
		Dim DisplayWidth As Integer
		Dim zx0 As String
		Dim zx1 As String
		Dim Ing(100) As String
		Dim HTML As String
		Dim g As Graphics = WebView21.CreateGraphics

		' Define the initial HTML string

		HTML = "<html>" & vbCrLf
		HTML &= "<meta charset=""ISO-8859-1"">"
		HTML &= "<body style=""font-family:Arial, Helvetica, sans-serif"">" & vbCrLf

		' Assemble the author (if there
		' is one) and blurb into the HTML string

		If GetR(mRec, "Author") <> "" Then HTML &= "<center><em>" & mRec("Author") & "</em></center>" & vbCrLf
		If GetR(mRec, "Blurb") <> "" Then HTML &= "<center><em><small>" & mRec("Blurb") & "</small></em></center>" & vbCrLf
		HTML &= "<br><br>" & vbCrLf

		' Get the width of the display.

		DisplayWidth = WebView21.Width / WebView21.ZoomFactor

		' Get the text of the ingredients

		zx0 = ReplaceUnicode(FormatIngredients(mRec("ID"), Lines), UnicodeSubstitute.HTML)

		' Break the ingredient list into separate lines of
		' half the width of the email with a space
		' between the two columns

		ii = 1
		While zx0 <> "" And ii <= Lines
			zx1 = ParseString(zx0, vbCrLf)
			Ing(ii) = zx1
			ii = ii + 1
		End While

		' Assemble a list of the ingredients

		ii = Int(Lines / 2) + 1
		HTML &= "<table width=""100%"" border=""0"">" & vbCrLf
		For jj = 1 To ii
			HTML &= "   <tr>" & vbCrLf
			If Ing(jj) <> "" Then
				HTML &= "      <td width=""45%"">" & "&nbsp;&nbsp;&nbsp;&nbsp;" & Ing(jj) & "</td>" & vbCrLf
			End If
			If jj + ii < Ing.Count Then HTML &= "      <td width=""45%"">" & Ing(jj + ii) & "</td>" & vbCrLf
			HTML &= "   </tr>" & vbCrLf
		Next jj
		HTML &= "</table><p>" & vbCrLf

		' Add the procedure.

		HTML &= "<table width=""100%"" border=""0"">" & vbCrLf
		zx0 = mRec("Procedure")
		While zx0 <> ""
			zx1 = ParseString(zx0, vbCrLf)
			HTML &= "    <tr>" & vbCrLf
			HTML &= "      <td width=""100%"">" & "&nbsp;&nbsp;&nbsp;&nbsp;" & zx1 & "</td>"
			HTML &= "   </tr>" & vbCrLf
		End While
		HTML &= "</table><p>" & vbCrLf


		' Add the close of the html

		HTML &= vbCrLf
		HTML &= "</body>" & vbCrLf
		HTML &= "</html>" & vbCrLf
		FormatHTML = HTML

		' Delete objects we've created

		g.Dispose()

	End Function

	'**************************************************

	' Overload the Show method to display a recipe.

	'**************************************************
	Public Overloads Async Sub Show(Recipe As DataRow, RecipeTable As DataTable)

		' Declare variables

		Dim ii As Integer
		Dim zx As String
		Dim dr As DataRow()

		' Save the recipe table

		mRecipeTable = RecipeTable

		' Get the recipe into our local variable, and display the title.

		mRec = Recipe
		lblRecipeName.Text = Recipe("RecipeName")

		' Wait for the WebView control to initialize.

		Await WebView21.EnsureCoreWebView2Async

		' Open the links table

		LinksDA.Fill(LinksDS, "Table")
		LinksTable = LinksDS.Tables("Table")

		' Get the recipe, formatted into HTML and navigate to it.

		RecipeCollection.Add(Recipe)
		zx = FormatHTML(Recipe)
		WebView21.NavigateToString(zx)

		' If the recipe contains any of the link text items, open the linked recipe as well.

		For ii = 0 To LinksTable.Rows.Count - 1
			If zx.ToLower.Contains(GetR(LinksTable.Rows(ii), "LinkText").tolower) Then
				dr = mRecipeTable.Select("ID=" & LinksTable.Rows(ii)("LinkedID"))
				If dr.Count > 0 Then AddRecipe(dr(0))
			End If
		Next ii

		LinksDS.Dispose()
		LinksTable.Dispose()

		Me.Show()

	End Sub

	'**************************************************

	' Event handler for the form paint event.

	'**************************************************
	Private Sub frmViewRecipe_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

		picAddRecipe.Invalidate()
		picPrevious.Invalidate()
		picNext.Invalidate()

	End Sub
	'**************************************************

	' Event handler for the "Add Recipe" icon.

	'**************************************************
	Private Sub picAddRecipe_Paint(sender As Object, e As PaintEventArgs) Handles picAddRecipe.Paint

		' Declare variables.

		Dim l1 As New Point(0, -8)
		Dim l2 As New Point(l1.X + 2, l1.Y + 2)
		Dim g As Graphics = e.Graphics
		Dim f As New Font("Arial", 32)

		' Draw dropshadow

		Using b As New SolidBrush(Color.FromArgb(100, 100, 100, 100))
			g.DrawString("+", f, b, l2)
		End Using

		' Draw Plus sign icon.
		Using b As New SolidBrush(Color.FromArgb(255, 0, 255, 0))
			g.DrawString("+", f, b, l1)
		End Using

		' Cleanup

		f.Dispose()
	End Sub
	'**************************************************

	' Event handler for the Previous Recipe icon.

	'**************************************************
	Private Sub picPrevious_Paint(sender As Object, e As PaintEventArgs) Handles picPrevious.Paint

		' Declare variables.

		Dim l1 As New Point(4, 4)
		Dim l2 As New Point(l1.X + 2, l1.Y + 2)
		Dim g As Graphics = e.Graphics
		Dim f As New Font("Wingdings 3", 16)

		' Draw the dropshadow

		Using b As New SolidBrush(Color.FromArgb(100, 100, 100, 100))
			g.DrawString("á", f, b, l2) ' left arrow in Wingdings 3; draw drop shadow
		End Using

		' Draw the arrow in red if enabled or dark gray if not enabled.

		Using b As New SolidBrush(If(picPrevious.Enabled, Color.FromArgb(255, 0, 0, 255), Color.DarkGray))
			g.DrawString("á", f, b, l1)
		End Using

		' Cleanup

		f.Dispose()
	End Sub
	'**************************************************

	' Event handler for the Next Recipe icon.

	'**************************************************
	Private Sub picNext_Paint(sender As Object, e As PaintEventArgs) Handles picNext.Paint

		' Declare variables.

		Dim l1 As New Point(4, 4)
		Dim l2 As New Point(l1.X + 2, l1.Y + 2)
		Dim g As Graphics = e.Graphics
		Dim f As New Font("Wingdings 3", 16)

		' Draw the dropshadow

		Using b As New SolidBrush(Color.FromArgb(100, 100, 100, 100))
			g.DrawString("â", f, b, l2) ' left arrow in Wingdings 3; draw drop shadow
		End Using

		' Draw the arrow in red if enabled or dark gray if not enabled.

		Using b As New SolidBrush(If(picNext.Enabled, Color.FromArgb(255, 0, 0, 255), Color.DarkGray))
			g.DrawString("â", f, b, l1)
		End Using

		' Cleanup

		f.Dispose()
	End Sub
	'**************************************************

	' The Previous Recipe icon was clicked.

	'**************************************************
	Private Sub picPrevious_Click(sender As Object, e As EventArgs) Handles picPrevious.Click

		' Declare variables

		Dim zx As String

		' Move to the previous recipe and display it.

		If ViewedRecipeIndex > 0 Then
			ViewedRecipeIndex -= 1
			zx = FormatHTML(RecipeCollection(ViewedRecipeIndex))
			lblRecipeName.Text = RecipeCollection(ViewedRecipeIndex)("RecipeName")
			WebView21.NavigateToString(zx)
		End If

	End Sub
	'**************************************************

	' The Next Recipe icon was clicked.

	'**************************************************
	Private Sub picNext_Click(sender As Object, e As EventArgs) Handles picNext.Click

		' Declare variables

		Dim zx As String

		' Move to the next recipe and display it.

		If ViewedRecipeIndex < RecipeCollection.Count - 1 Then
			ViewedRecipeIndex += 1
			zx = FormatHTML(RecipeCollection(ViewedRecipeIndex))
			lblRecipeName.Text = RecipeCollection(ViewedRecipeIndex)("RecipeName")
			WebView21.NavigateToString(zx)
		End If

	End Sub
	'**************************************************

	' The Add Recipe icon was clicked.

	'**************************************************
	Private Sub picAddRecipe_Click(sender As Object, e As EventArgs) Handles picAddRecipe.Click

		' Declare variables.

		Dim ii As Integer
		Dim zx As String
		Dim l As New frmListBox
		Dim dr As DataRow()


		' Display a lookup box to allow the user to select a recipe.

		ii = l.Lookup(DB, "Select Recipe to View", "Recipe Name", "RecipeName,Category", "SELECT ID,RecipeName,Category FROM tblRecipes ORDER BY RecipeName", "ID", "", "RecipeName", "RecipeName|30,Category|20")

		' If a recipe is selected, add it to the collection and display it.

		If ii > 0 Then
			dr = mRecipeTable.Select("ID=" & ii)
			If dr.Count > 0 Then
				AddRecipe(dr(0))
				zx = FormatHTML(dr(0))
				lblRecipeName.Text = dr(0)("RecipeName")
				WebView21.NavigateToString(zx)
				ViewedRecipeIndex = RecipeCollection.Count - 1
			End If
		End If
	End Sub
	'**************************************************

	' Sub to add a recipe to the collection.

	'**************************************************
	Private Sub AddRecipe(recipe As DataRow)

		RecipeCollection.Add(recipe)
		picNext.Enabled = True
		picNext.Invalidate()

	End Sub
	'**************************************************

	' The ViewedRecipeIndex property

	'**************************************************
	Private Property ViewedRecipeIndex() As Integer
		Get
			ViewedRecipeIndex = mViewedRecipeIndex
		End Get
		Set(value As Integer)

			' Depending on the value of the new index, enable or disable the previous
			' and next recipe icons.

			mViewedRecipeIndex = value
			picNext.Enabled = False
			picPrevious.Enabled = False
			If value < RecipeCollection.Count - 1 Then picNext.Enabled = True
			If value > 0 Then picPrevious.Enabled = True
			picPrevious.Invalidate()
			picNext.Invalidate()
		End Set
	End Property
End Class