Imports System.Data.SqlClient
Public Class frmAddLink
    '************************************************************
    ' SiriusCook Add Recipe Link form.
    ' SIRIUSCOOK_ADDLINK.VB
    ' Written: December 2018
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2018 Sirius Software All Rights Reserved
    '************************************************************

    ' Declare variables local to this module.

    Private LinkRecipeID As Integer
    Private RecipesDS As New DataSet
    Private RecipesTable As DataTable


    '************************************************************

    ' The form is loaded.

    '************************************************************
    Private Sub frmAddLink_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Get the recipes data set sirted by ID.  We can then use a binary search
        ' on the IDs to find a selected recipe.

        RecipesDA.SelectCommand.CommandText = "SELECT * FROM tblRecipes ORDER BY ID"
        RecipesDA.Fill(RecipesDS, "Table")
        RecipesTable = RecipesDS.Tables("Table")
        RecipesDA.SelectCommand = RecipesSelectCommand()

        ' Clear any existing recipe selection.

        LinkRecipeID = 0
        txtLinkRecipeName.Text = ""
        btnOkay.Enabled = False

    End Sub

    '************************************************************

    ' The form is closed.

    '************************************************************
    Private Sub frmAddLink_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        RecipesDS.Dispose()
    End Sub
    '************************************************************

    ' The Browse databases button is clicked.

    '************************************************************
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        ' Display a list box and get the ID of the recipe to link to.

        Dim xx As Integer
        Dim l As New frmListBox
          LinkRecipeID = l.Lookup(DB, "Link Recipes", "Linked Recipe:", "Title,Category,Recipe", "SELECT tblRecipes.ID, tblCookbooks.Title, tblRecipes.Category,tblRecipes.RecipeName FROM tblCookbooks INNER JOIN tblRecipes ON tblRecipes.ParentID=tblCookbooks.ID ORDER BY Title,Category,RecipeName", "ID", "", "Title", "Title|20,Category|12,RecipeName|30")

          ' If a recipe was selected, display its name.  Because we've sorted the
          ' recipe table by ID, we can use "Find2", which uses a binary search,
          ' making it much faster.

          xx = Find2(RecipesTable, "ID=" & LinkRecipeID)
        If xx <> NOMATCH Then txtLinkRecipeName.Text = GetR(RecipesTable.Rows(xx), "RecipeName")

        ' Enable the Okay button.

        btnOkay.Enabled = True

    End Sub
    '************************************************************

    ' The Okay button is clicked.

    '************************************************************
    Private Sub btnOkay_Click(sender As Object, e As EventArgs) Handles btnOkay.Click

        ' Declare variables

        Dim zx As String = ""
        Dim Command As sqlcommand

        ' Insert a new link into the links table.

        Try
            Command = New SqlCommand("INSERT INTO tblLinks (LinkedID,LinkText) VALUES(" & LinkRecipeID & ",'" & txtLinkText.Text & "')", DB)
            Command.ExecuteNonQuery()
        Catch ex As Exception
            If ex.HResult = -2146232060 Then zx = "That link already exists." Else zx = ex.Message
            MsgBox(zx, MsgBoxStyle.Information, "Add Link to Recipe")
        End Try

    End Sub

End Class