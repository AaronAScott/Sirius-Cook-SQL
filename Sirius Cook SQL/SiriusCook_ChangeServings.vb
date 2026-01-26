Imports System.Data.SqlClient
Imports vb = Microsoft.VisualBasic
Public Class SiriusCook_ChangeServings
    '***********************************************************************
    ' SiriusCook SQL Change Servings form
    ' SIRIUSCOOK_CHANGERECIPES.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright 2017 Sirius Software All Rights Reserved
    '***********************************************************************

    ' Declare variables that are the public properties of this form.

    Public SavedModifiedRecipe As Boolean = False

    ' Declare variables local to this module

    Private mRecID As Integer
    Private RecipesDS As New DataSet
    Private RecipesTable As DataTable
    Private mRec As DataRow
    Private UndoIngredientChanges As Collection
    Private UndoServingsChanges As String
    Private UndoRecipeName As String
    Private Const Caution As String = "Note that while it is usually easy to increase a recipe, cutting one down may result in unmanageable quantities." & vbCrLf & "In this event, you will have to rely on your experience, with the adjusted quantities as shown as a guide." & vbCrLf & "You can save the recipe (it will create a new recipe) and edit it as your experience indicates."

    ' Define text for the tip window

    Const TipTitle As String = "Increasing or Decrease Servings in a Recipe"
    Const TipText As String = "The recipe preview now shows your original recipe adjusted up or down in size as you requested.\par\par If you are unhappy with the conversion, press \cf1 Ctrl-Z \cf0 to undo the changes.\par\par If you are satisfied with the modified recipe, you may do two things:\par\par\fs35\bullet\fs21\cf1  Save the recipe.  It will be saved as a new recipe, and your orignal recipe will remain unchanged.  To the recipe name will be added ""(small portion)"" or ""(large portion)"" to distinguish it from the original recipe.  If you wish to make further changes manually—the procedure may need to be modified, for example—you must save the recipe and edit it in the recipe window.\par\par\cf0\fs35\bullet\fs21\cf1  You may print the recipe as it appears in the preview if you do not plan to save it to the cookbook as a new recipe.  When you click the ""Print"" button, a preview of the recipe will appear, from which you may select paper, printer, turn on or off headings and footers, etc. and print the modified recipe.  This is a good choice if you plan on making the recipe in this adapted quantity only this one time.\par\par "
    Const ControlItem As String = "ChangeServingsTip"

    ' Create a structure in which we will hold each ingredient

    Private Structure Ingredient
        Dim Text As String
        Dim Quantity As Double
        Dim UnitOfMeasure As String
        Dim IngredientName As String
    End Structure

    ' Create a structure in which we can hold the recipe to which we
    ' will be making changes.

    Private Structure RecipeRecord
        Dim ID As Integer
        Dim Category As String
        Dim Author As String
        Dim RecipeName As String
        Dim Blurb As String
        Dim Servings As String
        Dim Procedure As String
        Dim Ingredients As Collection
    End Structure
    Private LocalRecipe As New RecipeRecord



    '************************************************************************************

    ' The form is loaded.

    '************************************************************************************
    Private Sub SiriusCook_ChangeServings_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Declare variables

        Dim FormLeft As Integer
        Dim FormTop As Integer
        Dim FormWindowState As Short
        Dim zx As String

        ' Get the saved open Form window positions, if any

        zx = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "ChangeServings", "Position", "0,0,0")
        FormLeft = Val(zx)
        zx = Mid(zx, InStr(1, zx, ",") + 1, Len(zx))
        FormTop = Val(zx)
        zx = Mid(zx, InStr(1, zx, ",") + 1, Len(zx))
        FormWindowState = Val(zx)

        ' Set the size of the main window from the saved sizes

        If FormWindowState = 0 Then
            Me.Top = FormTop
            Me.Left = FormLeft
        Else
            Me.WindowState = FormWindowState
        End If

    End Sub
    '************************************************************************************

    ' The form is closed.

    '************************************************************************************
    Private Sub SiriusCook_ChangeServings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        ' Declare variables

        Dim zx As String

        ' Save the window size and position

        zx = CStr(Me.Left) & "," & CStr(Me.Top) & "," & CStr(Me.WindowState)
        SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "ChangeServings", "Position", zx)

        ' Dispose of the dataset.

        RecipesDS.Dispose()

    End Sub
    '***********************************************************************

    ' Watch for the user pressing Ctrl-Z to undo changes made to a recipe.

    '***********************************************************************
    Private Sub SiriusCook_ChangeServings_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.Control And e.KeyCode = Keys.Z Then
            LocalRecipe.Ingredients = UndoIngredientChanges
            LocalRecipe.Servings = UndoServingsChanges
            LocalRecipe.RecipeName = UndoRecipeName
            WebBrowser1.DocumentText = FormatHTML()
            btnSave.Enabled = False
        End If

    End Sub

    '***********************************************************************

    ' The Close button is clicked.

    '***********************************************************************
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    '***********************************************************************

    ' Of of the servings quantity text boxes has changed.

    '***********************************************************************
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, TextBox2.TextChanged

        ' Enable the radio button that indicates we are changing the recipe by servings quantity.

        If Not RadioButton1.Checked Then RadioButton1.Checked = True

        ' Clear the warning about reducing the recipe if we are increasing it or display it
        ' if we are decreasing it.

        If Val(TextBox2.Text) >= Val(TextBox1.Text) Then Label7.Text = "" Else Label7.Text = Caution
    End Sub

    '***********************************************************************

    ' The "Increase recipe" option is changed.

    '***********************************************************************
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not RadioButton2.Checked Then RadioButton2.Checked = True
    End Sub
    '***********************************************************************

    ' The "Decrease recipe" option is changed.

    '***********************************************************************
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If Not RadioButton3.Checked Then RadioButton3.Checked = True
    End Sub

    '***********************************************************************

    ' The "Decrease recipe" radio button has changed state.

    '***********************************************************************
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        If sender Is RadioButton3 And sender.Checked Then Label7.Text = Caution Else Label7.Text = ""
    End Sub
    '***********************************************************************

    ' The "Calculate" button is clicked.

    '***********************************************************************
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click

        ' Calculate and display the adjusted recipe.

        CalculateNewAmounts()

        ' Enable the Save button

        btnSave.Enabled = True

        ' Show the tips about this process.

        frmTips.TipTitle = TipTitle
        frmTips.TipText = TipText
        frmTips.ControlItem = ControlItem
        frmTips.ShowDialog()

    End Sub

    '***********************************************************************

    ' The "Print" button is clicked.

    '***********************************************************************
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        WebBrowser1.ShowPrintPreviewDialog()
    End Sub
    '***********************************************************************

    ' The "Save" button is clicked.

    '***********************************************************************
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' Save the recipe.

        SaveRecipe()

        ' Disable the Save button.

        btnSave.Enabled = False

        ' Indicate we've saved the modified recipe to the cookbook.

        SavedModifiedRecipe = True

    End Sub

    '***********************************************************************

    ' Sub to calculate the new ingredient sizes.
    '
    '***********************************************************************
    Private Sub CalculateNewAmounts()

        ' Declare variables

        Dim Factor As Single
        Dim zx As String
        Dim ChangeName As String = ""
        Dim Ing As Ingredient
        Dim IList As New Collection

        ' Determine what our factor is: up or down and by how much.

        If RadioButton1.Checked Then Factor = Val(TextBox2.Text) / Val(TextBox1.Text)
        If RadioButton2.Checked Then Factor = Choose(ComboBox1.SelectedIndex + 1, 1.5, 2.0, 3.0)
        If RadioButton3.Checked Then Factor = Choose(ComboBox2.SelectedIndex + 1, 0.75, 0.67, 0.5)

        ' Save recipe information in case we need to undo the changes.

        UndoIngredientChanges = LocalRecipe.Ingredients
        UndoServingsChanges = LocalRecipe.Servings
        UndoRecipeName = LocalRecipe.RecipeName

        ' Determine the text to add to the recipe name if it is saved as a new recipe.

        If Factor < 1.0 Then ChangeName = " (Reduced Portion)" Else ChangeName = " (Increased Portion)"

        ' Add the modifier to the local recipe name.

        LocalRecipe.RecipeName += ChangeName

        ' Loop through each ingredient in the ingredients list.

        For Each Ing In LocalRecipe.Ingredients

            ' First calculate the new amount.

            Ing.Quantity *= Factor

            ' Determine if the units of measure need to change.

            ' Check units if we are increasing the recipe.

            If Val(TextBox2.Text) > Val(TextBox1.Text) Or RadioButton2.Checked Then

                ' If the unit of measure is tsp. see if we need to change the unit
                ' to tbsp.

                If Ing.UnitOfMeasure = "tsp." And Ing.Quantity >= 3 Then
                    Ing.Quantity /= 3 ' convert to tablespoons
                    Ing.UnitOfMeasure = "tbsp."
                End If

                ' If the unit of measure is tbsp, see if we need to change the unit to oz.

                If Ing.UnitOfMeasure = "tbsp." And Ing.Quantity > 3 Then
                    Ing.Quantity /= 2 ' convert to oz.
                    Ing.UnitOfMeasure = "oz."
                End If

                ' Check units if we are decreasing the recipe.

            Else


                ' If the ingredient is "egg" or "eggs", we need to only allow partial eggs as far
                ' as half an egg.  Less will always be changed to half.

                If vb.Left(Ing.IngredientName, 3) = "egg" Then
                    If Ing.Quantity <= 0.5 Then Ing.Quantity = 0.5 Else Ing.Quantity = Math.Round(Ing.Quantity + 0.1)
                End If

                ' If the unit of measure is tsp. we may need to change the units.

                If Ing.UnitOfMeasure = "tsp." Then
                    If Ing.Quantity <= 0.0625 Then
                        Ing.Quantity = 0
                        Ing.UnitOfMeasure = ""
                        Ing.IngredientName = "Pinch " & Ing.IngredientName
                    ElseIf Ing.Quantity > 3 Then
                        Ing.UnitOfMeasure = "tbsp."
                        Ing.Quantity /= 3.0
                    End If
                End If

                ' Convert tbsp. to tsp. if less than 1 tbsp.

                If Ing.UnitOfMeasure = "tbsp." Then
                    If Ing.Quantity < 1 Then
                        Ing.Quantity *= 3.0 ' Convert to tsp.
                        Ing.UnitOfMeasure = "tsp."
                    End If
                End If

                ' Convert oz. to tbsp. if less than 2 oz.

                If Ing.UnitOfMeasure = "oz." Then
                    If Ing.Quantity < 2 Then
                        Ing.UnitOfMeasure = "tbsp."
                        Ing.Quantity /= 3.0
                    End If
                End If

                ' Convert less than 1/4 to oz. tbsp. or tsp.

                If Ing.UnitOfMeasure = "cup" Or Ing.UnitOfMeasure = "cups" Then
                    If Ing.Quantity <= 0.0625 Then ' Less than 1/16 cup
                        Ing.Quantity = Ing.Quantity * 6 ' Covert to tsp.
                        Ing.UnitOfMeasure = "tsp."
                    ElseIf Ing.Quantity <= 0.25 Then ' Less than 1/8 cup
                        Ing.Quantity = Ing.Quantity * 16 ' Covert to tbsp.
                        Ing.UnitOfMeasure = "tbsp."
                    ElseIf Ing.Quantity < 1 Then ' any odd amounts, conver to oz.
                        If Ing.Quantity <> 0.25 And Ing.Quantity <> 0.5 And Ing.Quantity <> 0.75 And Not (Ing.Quantity >= 0.3333 And Ing.Quantity < 0.34) And Not (Ing.Quantity >= 0.6666 And Ing.Quantity < 0.68) Then
                            Ing.Quantity = Ing.Quantity * 8 ' convert to oz.
                            Ing.UnitOfMeasure = "oz."
                        Else
                            Ing.UnitOfMeasure = "cup" ' make sure it's singular
                        End If

                    End If
                End If

                ' Convert less than 1/4 lb. to oz.

                If Ing.UnitOfMeasure = "Lb." Then
                    If Ing.Quantity < 0.25 Then
                        Ing.Quantity = Ing.Quantity * 16 ' Convert to oz.
                        Ing.UnitOfMeasure = "oz."
                    End If
                End If
            End If

            zx = ""
            If Ing.Quantity > 0 Then zx = FormatFraction(Ing.Quantity) & " " & Ing.UnitOfMeasure & " "
            zx += Ing.IngredientName
            Ing.Text = zx
            IList.Add(Ing)
        Next Ing

        ' Replace the ingredients in the local recipe

        LocalRecipe.Servings = TextBox2.Text
        LocalRecipe.Ingredients = IList

        ' Now rebuild the recipe and display the changed quantities

        WebBrowser1.DocumentText = FormatHTML()
    End Sub

    '***********************************************************************

    ' Sub to save the recipe back as a new recipe.

    '***********************************************************************
    Private Sub SaveRecipe()

        ' Declare variables

        Dim dr As DataRow
        Dim Transaction As SqlTransaction

        ' Begin a transaction

        Transaction = DB.BeginTransaction
        RecipesDA.InsertCommand.Transaction = Transaction
        IngredientsDA.InsertCommand.Transaction = Transaction
        IngredientsDA.SelectCommand.Transaction = Transaction

        ' Add the recipe with the new ingredient amounts.

        Try
            dr = RecipesTable.NewRow

            ' Fill in fields in the new recipe that the user doesn't directly enter.

            dr("ParentID") = mRec("ParentID")
            dr("CardStyle") = mRec("CardStyle")
            dr("CardWidth") = mRec("CardWidth")
            dr("CardHeight") = mRec("CardHeight")
            dr("LeftMargin") = mRec("LeftMargin")
            dr("Heading Margin") = mRec("Heading Margin")
            dr("IngredientsMargin") = mRec("IngredientsMargin")
            dr("ProcedureMargin") = mRec("ProcedureMargin")
            dr("FontSize") = 8
            dr("FontName") = "Arial"
            dr("Scale") = ""
            dr("Favorite") = 0

            ' Get the recipe information from the local copy.

            dr("RecipeName") = LocalRecipe.RecipeName
            dr("Category") = LocalRecipe.Category
            dr("Author") = LocalRecipe.Author
            dr("Blurb") = LocalRecipe.Blurb
            dr("Servings") = LocalRecipe.Servings
            dr("Procedure") = LocalRecipe.Procedure
            RecipesTable.Rows.Add(dr)

            RecipesDA.Update(RecipesTable)


            ' Get the new recipe ID into the local copy.

            LocalRecipe.ID = dr("ID")

            ' Save the recipe's ingredients

            SaveIngredients()

            ' Commit the transaction.

            Transaction.Commit()

        Catch ex As Exception
            MsgBox("Update Failed." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Save Recipe")
            Transaction.Rollback()
        End Try

    End Sub
    '**************************************************
    '
    ' Sub to save the ingredients, received in text
    ' format, to a recipe's attached records.
    '
    '**************************************************
    Public Sub SaveIngredients()

        ' Declare variables

        Dim Ing As Ingredient
        Dim IngredientsDS As New DataSet
        Dim dr As DataRow
        Dim lIngred As DataTable


        ' Create a dataset of the ingredients table

        IngredientsDA.Fill(IngredientsDS, "Table")
        lIngred = IngredientsDS.Tables("Table")


        ' Begin looping through the ingredients of the modified

        For Each Ing In LocalRecipe.Ingredients

            ' Write the ingredient record.

            Try
                dr = lIngred.NewRow
                dr("ParentID") = LocalRecipe.id
                dr("Quantity") = Ing.Quantity
                dr("UnitOfMeasure") = Ing.UnitOfMeasure
                dr("IngredientName") = Ing.IngredientName
                lIngred.Rows.Add(dr)
                IngredientsDA.Update(IngredientsDS)
            Catch ex As Exception
                MsgBox("Update Failed." & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Save Recipe")
            End Try
        Next Ing

    End Sub
    '***********************************************************************
    '
    ' Function to return the recipe formatted to send
    ' as an HTML-format file attachment.
    '
    '***********************************************************************
    Private Function FormatHTML() As String


        ' Declare variables

        Dim ii As Integer
        Dim RowCount As Integer
        Dim HTML As String

        ' Define the initial HTML string

        HTML = "<html>" & vbCrLf
        HTML += "<style> body { font-family: " & mRec("FontName") & ";} </style>" & vbCrLf
        HTML += "<body>" & vbCrLf
        HTML += "<Title>" & LocalRecipe.RecipeName & "</Title>"

        ' Assemble the RecipeName, author (if there
        ' is one) into the HTML string. Add the category
        ' and servings.

        HTML += "<table width=""100%"" border=""0"">" & vbCrLf
        HTML += "<tr><td width=""100%""><font size=""4""><center><strong>" & LocalRecipe.RecipeName & "</strong></center></font></td></tr>" & vbCrLf
        If LocalRecipe.Author <> "" Then HTML += "<tr><td width=""100%""><font size=""2"" face=""Times New Roman""><center><em>" & LocalRecipe.Author & "</em></center></font></td></tr></table>" & vbCrLf
        HTML += "<table width=""100%"" border=""0"">" & vbCrLf
        HTML += "<tr>" & vbCrLf
        HTML += "<td width=50% style=""text-align:left;font-size:12;"">" & LocalRecipe.Category & "</td><td width=50% style=""text-align:right;font-size:12;"">Servings: " & LocalRecipe.Servings & "</td>" & vbCrLf
        HTML += "</tr></font></table><br>" & vbCrLf

        ' Assemble a list of the ingredients

        HTML += "<table width=""100%"" border=""0"" <font size=""2"">" & vbCrLf
        If LocalRecipe.Ingredients.Count / 2 <> Int(LocalRecipe.Ingredients.Count / 2) Then RowCount = LocalRecipe.Ingredients.Count / 2 + 0.5 Else RowCount = LocalRecipe.Ingredients.Count / 2
        ii = 1
        Do
            HTML += "<tr>"
            HTML += "<td width=""50%""><font size=""2"">" & LocalRecipe.Ingredients(ii).Text & "</font></td>" & vbCrLf
            If ii + RowCount <= LocalRecipe.Ingredients.Count Then HTML += "<td width=""50%""><font size=""2"">" & LocalRecipe.Ingredients(ii + RowCount).text & "</font></td>" & vbCrLf
            HTML += "</tr>"
            ii += 1
        Loop While ii <= RowCount
        HTML += "</table></font>" & vbCrLf

        HTML += "<p><font size=""2"">" & LocalRecipe.Procedure & "</font></p>" & vbCrLf

        ' Add the close of the html

        HTML += "</body>" & vbCrLf
        HTML += "</html>" & vbCrLf
        FormatHTML = HTML

    End Function

    '***********************************************************************
    '
    ' Function to return collection of the recipe's ingredients
    ' Input:   RecipeID = The ID of the recipe record.
    '
    '***********************************************************************
    Public Function IngredientsList(ByRef RecipeID As Integer) As Collection

        ' Declare variables

        Dim ii As Integer
        Dim zx0 As String = ""
        Dim IngredientsDS As New DataSet
        Dim lIngred As DataTable
        Dim Ing As New Collection
        Dim Ingredient As Ingredient

        ' Create a dynaset of ingredients belonging to this
        ' recipe.

        IngredientsDA.SelectCommand = IngredientsSelectCommand(RecipeID)
        IngredientsDA.Fill(IngredientsDS, "Table")
        lIngred = IngredientsDS.Tables("Table")

        ' Begin assembling the text

        ii = 0
        If lIngred.Rows.Count > 0 Then
            Do
                Ingredient = New Ingredient
                zx0 = ""
                If lIngred.Rows(ii)("Quantity") > 0 Then zx0 = FormatFraction(lIngred.Rows(ii)("Quantity")) & " " & GetR(lIngred.Rows(ii), "UnitOfMeasure") & " "
                zx0 += GetR(lIngred.Rows(ii), "IngredientName")
                Ingredient.Text = zx0
                Ingredient.Quantity = lIngred.Rows(ii)("Quantity")
                Ingredient.UnitOfMeasure = GetR(lIngred.Rows(ii), "UnitOfMeasure")
                Ingredient.IngredientName = GetR(lIngred.Rows(ii), "IngredientName")
                Ing.Add(Ingredient)
                ii += 1
            Loop While ii < lIngred.Rows.Count
        End If
        IngredientsDS.Dispose()

        ' Return the collection of ingredients

        IngredientsList = Ing

    End Function
    '***********************************************************************

    ' The RecID property.  Setting this value to the ID of a recipe will
    ' cause the recipe to be read in and the form shown.

    '***********************************************************************
    Public Property RecID As Integer
        Get
            RecID = mRecID
        End Get
        Set(value As Integer)

            ' Declare variables

            Dim xx As Integer


            ' Save the supplied record ID.

            mRecID = value

            ' Get the dataset of recipes.

            RecipesDA.SelectCommand = RecipesSelectCommand()
            RecipesDA.Fill(RecipesDS, "Table")
            RecipesTable = RecipesDS.Tables("Table")

            ' Look for the recipe with the specified ID

            xx = Find(RecipesTable, "ID=" & mRecID)
            If xx <> NOMATCH Then
                mRec = RecipesTable.Rows(xx)

                ' Save the recipe in our working copy.

                LocalRecipe.ID = mRec("ID")
                LocalRecipe.Category = mRec("Category")
                LocalRecipe.Author = mRec("Author")
                LocalRecipe.RecipeName = mRec("RecipeName")
                LocalRecipe.Servings = mRec("Servings")
                LocalRecipe.Blurb = mRec("Blurb")
                LocalRecipe.Procedure = mRec("Procedure")
                LocalRecipe.Ingredients = IngredientsList(mRecID)

                ' Format the recipe, and place the servings, if any are
                ' supplied, in the "from" servings text box.

                WebBrowser1.DocumentText = FormatHTML()
                If mRec("Servings") <> "" Then
                    TextBox1.Text = GetR(mRec, "Servings")
                    TextBox2.Text = GetR(mRec, "Servings")
                Else
                    RadioButton2.Checked = True
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                End If
            End If
        End Set
    End Property

End Class