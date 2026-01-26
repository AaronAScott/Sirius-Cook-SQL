Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.Data.SqlClient

Friend Class Library
    '******************************************************************
    ' SiriusCook SQL Library Class
    ' LIBRARY.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
    '******************************************************************

    ' Declare variables which are the properties of
    ' this class.

    Public CookBooks As Collection

    '*****************************************************************
    '
    ' The database name property is queried
    '
    '*****************************************************************
    Public ReadOnly Property DatabaseName() As String
        Get

            DatabaseName = DB.Database

        End Get
    End Property
    '****************************************************************
    '
    ' The item property is queried.  THIS IS THE
    ' DEFAULT MEMBER OF THE LIBRARY CLASS.
    ' BEFORE CHANGING THE "PUBLIC" TO "FRIEND" OR
    ' "PRIVATE" YOU MUST REMOVE THE DEFAULT STATUS.
    '
    '****************************************************************
    Default Public ReadOnly Property Item(ByVal ID As Integer) As Cookbook
        Get

            ' Declare variables

            Dim lCookbook As Cookbook

            ' set the default return value of the Item property

            Item = Nothing

            ' See if the Recipe ID is blank and
            ' raise an error if so.

            If ID = 0 Then
                Err.Raise(vbObjectError + 1001, "Library.ItemGet", "Cookbook ID required.")
            End If

            ' Loop through each cookbook in the collection and return
            ' the one with the specified ID

            For Each lCookbook In CookBooks
                If lCookbook.BookID = ID Then
                    Item = lCookbook
                    Exit For
                End If
            Next lCookbook

            Exit Property

            ' Trap for errors

GetError:
            Err.Raise(Err.Number, "Library.ItemGet")

        End Get
    End Property
    '****************************************************************
    '
    ' The count property is queried
    '
    '****************************************************************
    Public ReadOnly Property Count() As Integer
        Get

            ' Declare variables

            Dim RecipesDS As New DataSet
            Dim lRec As DataTable
            Dim rcnt As Integer

            ' Open the Recipe table and get the count of rows.

            RecipesDA.Fill(RecipesDS, "Table")
            lRec = RecipesDS.Tables("Table")
            rcnt = lRec.Rows.Count

            ' Dispose of the dataset

            RecipesDS.Dispose()

            ' Return the Recipe record count 

            Count = rcnt

        End Get
    End Property

    '******************************************************************
    '
    ' The library show method.
    '
    '******************************************************************
    Friend Sub Show()

        ' Declare variables

        Dim jj As Integer
        Dim zx0 As String
        Dim zx1 As String
        Dim NextBookX As Integer
        Dim p As PictureBox
        Dim xx As Integer
        Dim RM As Object
        Dim bm As Bitmap = Nothing

        ' Build the library

        If DbOpen Then BuildLibrary()

        ' Our insert position is just to the right of the left bookend.

        NextBookX = frmMain.picBookshelf_0.Left + frmMain.picBookshelf_0.ClientRectangle.Width

        ' Make sure we have at least one cookbook.

        If Not CookBooks Is Nothing Then

            ' if the properties of any cookbook have changed, rebuild the
            ' library.

            For jj = 1 To CookBooks.Count()
                If CookBooks.Item(jj).PropertiesChanged Then
                    BuildLibrary()
                    Exit For
                End If
            Next jj

            ' Remove all picture boxes before displaying, or
            ' re-displaying the cookbooks collection. If the book
            ' being removed has the bookmark over it, move it
            ' back to the bookend.

            If Not frmMain.picBookshelf Is Nothing Then
                For Each p In frmMain.picBookshelf
                    RemoveHandler p.Click, AddressOf frmMain.picBookshelf_Click
                    RemoveHandler p.DoubleClick, AddressOf frmMain.picBookshelf_DoubleClick
                    RemoveHandler p.MouseDown, AddressOf frmMain.picBookshelf_MouseDown
                    RemoveHandler p.MouseMove, AddressOf frmMain.picBookshelf_MouseMove
                    RemoveHandler p.Paint, AddressOf frmMain.picBookshelf_Paint
                    frmMain.Controls.Remove(p)
                Next p
                frmMain.picBookshelf = Nothing
            End If
            frmMain.picBookshelf = New Collection


            ' Load PictureBoxs for each of the cookbooks.

            For jj = 1 To CookBooks.Count()
                p = New PictureBox
                frmMain.picBookshelf.Add(p, CStr(jj))
                frmMain.Controls.Add(p)
                CookBooks.Item(jj).Display = p
                AddHandler p.Click, AddressOf frmMain.picBookshelf_Click
                AddHandler p.DoubleClick, AddressOf frmMain.picBookshelf_DoubleClick
                AddHandler p.MouseDown, AddressOf frmMain.picBookshelf_MouseDown
                AddHandler p.MouseMove, AddressOf frmMain.picBookshelf_MouseMove
                AddHandler p.Paint, AddressOf frmMain.picBookshelf_Paint
            Next jj

            ' Put the books' pictures into the boxes and adjust the
            ' screen postions. picBookshelf_0 is the left bookend, and
            ' picBookshelf_1 is the right bookend. The books themselves
            ' are stored in the picBookshelf collection.
            ' When printing a book, we vary the
            ' Y position just a bit, randomly, to make the books
            ' appear more 3-dimensionally

            For jj = 1 To CookBooks.Count
                p = CookBooks(jj).Display
                With p
                    If CookBooks.Item(jj).ImageStyle = 0 Then
                        bm = My.Resources.DefaultBook
                    Else
                        Select Case CookBooks.Item(jj).ImageStyle
                            Case 1
                                bm = My.Resources.Book1
                            Case 2
                                bm = My.Resources.Book2
                            Case 3
                                bm = My.Resources.Book3
                            Case 4
                                bm = My.Resources.Book4
                            Case 5
                                bm = My.Resources.Book5
                            Case 6
                                bm = My.Resources.Book6
                            Case 7
                                bm = My.Resources.Book7
                            Case 8
                                bm = My.Resources.Book8
                        End Select

                    End If
                    bm.MakeTransparent(Color.Black)
                    .BorderStyle = BorderStyle.None
                    .BackgroundImage = bm
                    .Width = bm.PhysicalDimension.Width
                    .Height = bm.PhysicalDimension.Height
                    .Left = NextBookX
                    .Top = frmMain.picBookshelf_0.Top + frmMain.picBookshelf_0.Height - p.ClientRectangle.Height + Rnd(VB.Timer()) * 10
                    .ContextMenuStrip = frmMain.mnuContextMenu1
                End With

                ' Advance the left margin for the next picture box and
                ' assign the picture box to the cookbook object.

                NextBookX = NextBookX + p.Width

                CookBooks.Item(jj).Display.Visible = True
                If CookBooks.Item(jj).Selected = True Then ResetBookmark(p)

            Next jj

            ' If we have no library open, remove any pictures from a
            ' previously-open library, if any

        ElseIf Not frmMain.picBookshelf Is Nothing Then
            For Each p In frmMain.picBookshelf
                RemoveHandler p.Click, AddressOf frmMain.picBookshelf_Click
                RemoveHandler p.DoubleClick, AddressOf frmMain.picBookshelf_DoubleClick
                RemoveHandler p.MouseDown, AddressOf frmMain.picBookshelf_MouseDown
                RemoveHandler p.MouseMove, AddressOf frmMain.picBookshelf_MouseMove
                RemoveHandler p.Paint, AddressOf frmMain.picBookshelf_Paint
                If frmMain.Image1.Parent Is p Then frmMain.Controls.Remove(p)
            Next p
            frmMain.picBookshelf = Nothing
            ResetBookmark() ' Passing "nothing" moves bookmark back to left bookend
        End If

        ' show the final bookend

        frmMain.picBookshelf_1.Left = NextBookX
        On Error GoTo 0
    End Sub

    '****************************************************************

    ' The library Close method.

    '****************************************************************
    Public Sub Close()
        CookBooks = Nothing
        Show()
    End Sub
    '****************************************************************
    '
    ' Method to remove a cookbook from the cookbooks
    ' "collection"
    '
    '****************************************************************
    Public Sub RemoveCookbook(ByRef ID As Integer)

        ' Declare variables

        Dim xx As Integer
        Dim CookbooksDS As New DataSet
        Dim lBook As DataTable

        ' See if the cookbook ID is blank and
        ' raise an error if so.

        If ID = 0 Then
            Err.Raise(vbObjectError + 1001, "Cookbook.Recipes", "Recipe ID required.")
        End If

        ' Look up the record for the cookbook ID.  If it
        ' does not exist, raise an error.

        CookbooksDA.SelectCommand = CookbooksSelectCommand(ID)
        CookbooksDA.Fill(CookbooksDS, "Table")
        lBook = CookbooksDS.Tables("Table")

        ' Get the row ID of the book.

        xx = Find(lBook, "ID=" & ID)
        If xx <> NOMATCH Then
            Try
                lBook.Rows(xx).Delete()
                CookbooksDA.Update(CookbooksDS)
            Catch ex As Exception
                Err.Raise(ex.HResult, "Cookbook.Recipes", ex.Message)
            End Try
        Else
            Err.Raise(vbObjectError + 1002, "Cookbook.Recipes", "Recipe ID not found")
        End If

        ' Dispose of the dataset.

        CookbooksDS.Dispose()

        ' Delete the book from the library

        CookBooks.Remove(CStr(ID))

        ' Rebuild the library

        BuildLibrary()

    End Sub


    '****************************************************************
    '
    ' Method to add a new cookbook to the
    ' cookbooks "collection".
    '
    '****************************************************************
    Public Sub AddCookbook()

        ' Declare variables

        Dim CookbooksDS As New DataSet
        Dim lBook As DataTable
        Dim lBk As Cookbook
        Dim Transaction As SqlTransaction
        Dim dr As DataRow

        ' Begin a transaction

        Transaction = DB.BeginTransaction
        CookbooksDA.InsertCommand.Transaction = Transaction
        CookbooksDA.SelectCommand = CookbooksSelectCommand()
        CookbooksDA.SelectCommand.Transaction = Transaction
        CookbooksDA.Fill(CookbooksDS, "Table")
        lBook = CookbooksDS.Tables("Table")

        ' Add a new cookbook record.

        Try
            dr = lBook.NewRow
            dr("Title") = "Cookbook Title"
            dr("Category") = "Food Category"
            dr("ImageStyle") = 1
            dr("DisplayOrder") = lBook.Rows.Count + 1
            dr("Selected") = False
            lBook.Rows.Add(dr)
            CookbooksDA.Update(CookbooksDS)
            Transaction.Commit()

            ' Add the new record to the cookbooks collection.

            lBk = New Cookbook
            lBk.BookID = dr("ID") ' This will open the book
            lBk.Author = GetR(dr, "Author")
            lBk.Title = GetR(dr, "Title")
            lBk.Category = GetR(dr, "Category")
            lBk.Password = GetR(dr, "Password")
            lBk.ImageStyle = dr("ImageStyle")
            lBk.DisplayOrder = dr("DisplayOrder")
            lBk.Selected = dr("Selected")
            CookBooks.Add(lBk, CStr(dr("ID")))

            ' Now set the properties of the new cookbook

            lBk.ChangeProperties()

        Catch ex As Exception
            Err.Raise(ex.HResult, "Cookbook.AddCookbook", ex.Message)
        End Try

        ' Dispose of the dataset and transaction

        CookbooksDS.Dispose()
        Transaction.Dispose()

    End Sub

    '****************************************************************************************
    '
    ' Sub to build a library when a database changes.
    '
    '****************************************************************************************
    Private Sub BuildLibrary()

        ' Declare variables

        Dim ii As Integer
        Dim lBk As Cookbook
        Dim CookbooksDS As New DataSet
        Dim lBook As DataTable
        Dim dr As DataRow

        ' Put up a status message while we do this.

        frmMain.StatusLabel.Text = "Loading library..."
        System.Windows.Forms.Application.DoEvents() '  Allow time to update

        ' Refresh the cookbooks collection

        CookBooks = Nothing
        CookBooks = New Collection

        ' Open the cookbooks table and read in the names
        ' of the books.

        CookbooksDA.SelectCommand = CookbooksSelectCommand()
        CookbooksDA.Fill(CookbooksDS, "Table")
        lBook = CookbooksDS.Tables("Table")

        ' Add each cookbook to the cookbooks collection.

        If lBook.Rows.Count > 0 Then
            ii = 0
            Do
                dr = lBook.Rows(ii)
                lBk = New Cookbook
                lBk.BookID = dr("ID") ' This will open the book
                lBk.Author = GetR(dr, "Author")
                lBk.Title = GetR(dr, "Title")
                lBk.Category = GetR(dr, "Category")
                lBk.Password = GetR(dr, "Password")
                lBk.ImageStyle = dr("ImageStyle")
                lBk.DisplayOrder = dr("DisplayOrder")
                lBk.Selected = dr("Selected")
                CookBooks.Add(lBk, CStr(dr("ID")))
                ii += 1
            Loop While ii < lBook.Rows.Count
        End If

        ' Close the cookbooks table

        CookbooksDS.Dispose()

        ' Clear status message.

        frmMain.StatusLabel.Text = ""
        System.Windows.Forms.Application.DoEvents() '  Allow time to update

    End Sub

    '**************************************************************************************
    '
    ' Sub to return the "bookmark" graphic to the
    ' top of the left bookend.
    '
    '**************************************************************************************
    Friend Sub ResetBookmark(Optional ByRef p As PictureBox = Nothing)

        ' Declare variables

        Dim Index As Integer
        Dim SelectedBookend As PictureBox

        ' Save the selected bookend

        SelectedBookend = p

        ' Set the image1 control's "container" to be the first
        ' bookend if no index is specified.  Otherwise, move it
        ' to the right edge of the graphic for the specified
        ' bookend.

        If Not SelectedBookend Is Nothing Then

            ' Determine what the index into the library the selected PictureBox represents

            For Index = 1 To CookBooks.Count
                If SelectedBookend Is CookBooks.Item(Index).Display Then Exit For
            Next Index

            frmMain.Image1.Parent = SelectedBookend
            frmMain.Image1.SetBounds(SelectedBookend.ClientRectangle.Width / 3, Choose(CookBooks.Item(Index).ImageStyle + 1, 27, 22, 27, 24, 21, 19, 20, 27, 20), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        Else
            frmMain.Image1.Parent = frmMain.picBookshelf_0
            frmMain.Image1.SetBounds(frmMain.picBookshelf_0.ClientRectangle.Width - 40, 0, 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
        End If
        System.Windows.Forms.Application.DoEvents() '  Allow time to update

    End Sub
End Class