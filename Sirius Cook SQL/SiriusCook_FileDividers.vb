Option Strict Off
Option Explicit On
Imports vb = Microsoft.VisualBasic
Imports System.Data.SqlClient
Friend Class frmFileDividers
    Inherits System.Windows.Forms.Form
    '**************************************************
    ' SiriusCook SQL Card File Dividers options form
    ' SIRIUSCOOK_FILEDIVIDERS.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
    '**************************************************

    ' Define the text of the tip window

    Const TipTitle As String = "Printing Card File Dividers"
    Const TipText As String = "A feature of the SiriusCook program is that it can print card file dividers for your recipe box.  You may select to print a divider for every food category you have defined while entering your recipes, or for only selected categories; for instance if you just want to reprint a damaged or missing divider card.\par\par You may also enter a list of tab names for which to print dividers not dependent upon food categories you have created.\par\par When printing these dividers, it is recommended to use \i\cf1 Card Stock\cf0\plain\f3 , instead of regular paper.\par\par You should feed the card stock into your printer in a direct feed and not from any tray that may turn the paper over: card stock seldom bends well enough for any such feed avenue.\par\par The program will print multiple images of dividers on a single piece of card stock, depending on the divider size selected: a \cf1 3x5\cf0  divider will print 3 to an 8½ x 11 inch page, while you will get only 2 to a page of the \cf1 4x6\cf0  size."
    Const ControlItem = "ShowDividerTips"

    ' Declare variables local to this module

    Private IterateCategories As Integer
    Private IterateColors As Integer
    Private IterateTabs As Integer
    Private MaxTabs As Integer
    Private mTabHeight As Single
    Private mTabWidth As Single
    Private mHeight As Single
    Private mWidth As Single
    Private LeftMargin As Single
    Private RightMargin As Single
    Private WorkingWidth As Single
    Private BOTTOMMARGIN As Single
    Private TOPMARGIN As Single
    Private INDENT As Single
    Private LINEHEIGHT As Single

    Private fntNormal As Font
    Private bN As SolidBrush
    Private pN As Pen

    Private mParentID As Integer
    '**************************************************
    '
    ' Sub to fill the list box with defined categories
    '
    '**************************************************
    Private Sub FillDefined()

        ' Declare variables

        Dim ii As Integer
        Dim RecipesDS As New DataSet
        Dim lRec As DataTable

        ' Fill the list box with the defined categories

        List1.Items.Clear()
        RecipesDA.SelectCommand.CommandText = "SELECT DISTINCT [Category] FROM tblRecipes WHERE ParentID=" & mParentID & " ORDER BY [Category]"
        RecipesDS.Clear()
        RecipesDA.Fill(RecipesDS, "Table")
        lRec = RecipesDS.Tables("Table")

        If lRec.Rows.Count > 0 Then
            ii = 0
            Do
                List1.Items.Add(GetR(lRec.Rows(ii), "Category"))
                ii += 1
            Loop While ii < lRec.Rows.Count
        End If
        RecipesDS.Dispose()

    End Sub

    '**************************************************
    '
    ' Sub to fill the list box with user-defined categories
    ' that may not exist in the cookbook, but that the
    ' user wants printed.
    '
    '**************************************************
    Private Sub FillSpecial()

        ' Declare variables

        Dim xx As Integer
        Dim zx As String

        ' Get the special list

        zx = GetControlItem("Dividers" & mParentID)
        List1.Items.Clear()
        While zx <> ""
            xx = List1.Items.Add(ParseString(zx, vbCrLf))
            List1.SetItemChecked(xx, True)
        End While

    End Sub

    '**************************************************
    '
    ' Method to print the file dividers
    '
    '**************************************************
    Public Sub ShowDividerDialog(ByRef lParentID As Integer)

        ' fill the list box with the defined categories

        mParentID = lParentID
        FillDefined()

        ' Show the form

        Me.ShowDialog()

    End Sub

    '**************************************************
    '
    ' Event Handler for the PrintDocument object
    '
    '**************************************************
    Private Sub PrintDividers_PagePrint(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs)

        ' Declare variables

        Dim MoreCategories As Boolean
        Dim ii As Integer
        Dim x As Single
        Dim y As Single
        Dim Penwidth As Single
        Dim TabOffset As Single
        Dim g As Graphics = ev.Graphics

        ' Set the unit of measure for the page

        If Option1_0.Checked = True Then
            g.PageUnit = GraphicsUnit.Inch
            mTabHeight = 0.25
            mTabWidth = 1.25
            Penwidth = 1 / g.DpiX
        Else
            g.PageUnit = GraphicsUnit.Millimeter
            mTabHeight = 6.35
            mTabWidth = 31.75
            Penwidth = 25.4 / g.DpiX
        End If
        mHeight = CSng(Text1_0.Text)
        mWidth = CSng(Text1_1.Text)

        ' Create our printing tools

        fntNormal = New Font("Arial", 10)
        If Not chkColoredTabs.Checked Then bN = New SolidBrush(Color.Black) Else bN = New SolidBrush(Color.GhostWhite)
        pN = New Pen(System.Drawing.Color.Black, Penwidth)

        ' Set margin values

        INDENT = g.MeasureString("X", fntNormal).Width
        LINEHEIGHT = g.MeasureString("X", fntNormal).Height
        RightMargin = ev.PageBounds.Right - 6 * INDENT
        LeftMargin = INDENT
        WorkingWidth = RightMargin - LeftMargin
        BOTTOMMARGIN = ev.PageBounds.Bottom / 100 - LINEHEIGHT * 2
        TOPMARGIN = ev.PageBounds.Top / 100

        ' Calculate the maximum number of tab positions that
        ' fit on a card

        MaxTabs = Fix(mWidth / mTabWidth)

        ' Remember the start position, which must be at
        ' least as far down the page as the tab height

        x = LeftMargin
        y = mTabHeight + LINEHEIGHT

        ' Begin printing a divider for each selected category

        Do While IterateCategories < List1.Items.Count And y + mTabHeight + mHeight < BOTTOMMARGIN
            If List1.GetItemChecked(IterateCategories) Or Option2_0.Checked = True Then
                TabOffset = IterateTabs * mTabWidth + INDENT
                DrawDivider(g, List1.Items(IterateCategories), TabOffset, x, y)
                IterateTabs = IterateTabs + 1
                If IterateTabs = MaxTabs Then IterateTabs = 0
            End If
            IterateCategories = IterateCategories + 1
        Loop

        ' If we are printing selected categories, look ahead to see if there are any more
        ' items checked, before we indicate whether or not there are more pages to print.

        If Option2_0.Checked Then
            If IterateCategories < List1.Items.Count Then MoreCategories = True Else MoreCategories = False
        Else
            MoreCategories = False
            For ii = IterateCategories To List1.Items.Count - 1
                If List1.GetItemChecked(ii) Then MoreCategories = True

            Next ii
        End If

        ' Flag if we haven't printed all the cards

        If MoreCategories Then ev.HasMorePages = True Else ev.HasMorePages = False

        ' Dispose of objects we've created

        fntNormal = Nothing
        bN = Nothing
        pN = Nothing

    End Sub
    '**************************************************
    '
    ' Sub to print one divider
    '
    '**************************************************
    Private Sub DrawDivider(ByVal g As Graphics, ByVal Title As String, ByVal TabOffset As Single, ByRef x As Single, ByRef y As Single)

        ' Declare variables

        Dim w As Single
        Dim xx As Single
        Dim p As Single = pN.Width * 60
        Dim bC As SolidBrush
        Dim c As System.Drawing.Color
        Dim r As New Drawing2D.GraphicsPath

        ' Left edge to tab

        xx = x
        If TabOffset > 0 Then
            g.DrawLine(pN, x, y + mTabHeight, TabOffset, y + mTabHeight)
            xx = TabOffset
        End If

        ' pick a color for the colored tabs

        IterateColors = IterateColors + 1
        If IterateColors > 10 Then IterateColors = 1
        c = Choose(IterateColors, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Green, System.Drawing.Color.DarkGoldenrod, System.Drawing.Color.IndianRed, System.Drawing.Color.SaddleBrown, System.Drawing.Color.DarkViolet, System.Drawing.Color.Orange, System.Drawing.Color.Crimson, System.Drawing.Color.Salmon, System.Drawing.Color.Navy)
        bC = New SolidBrush(c)

        ' Tab and top edge. We use a graphics path, as this is a complex shape with
        ' rounded edges on the tabs.

        w = g.MeasureString(Title, fntNormal).Width
        If w < mTabWidth Then w = mTabWidth
        r.AddLine(xx, y + mTabHeight, xx, y + p)
        r.AddArc(xx, y, p, p, 180, 90)
        r.AddLine(xx + p, y, xx + w - p, y)
        r.AddArc(xx + w - p, y, p, p, 270, 90)
        r.AddLine(xx + w, y + p, xx + w, y + mTabHeight)
        g.DrawPath(pN, r)
        If chkColoredTabs.Checked Then
            r.AddLine(xx + w, y + mTabHeight, xx, y + mTabHeight)
            g.FillPath(bC, r)
        End If
        g.DrawLine(pN, xx + w, y + mTabHeight, mWidth + INDENT, y + mTabHeight)
        g.DrawString(Title, fntNormal, bN, xx + (w - g.MeasureString(Title, fntNormal).Width) / 2, y + (mTabHeight - g.MeasureString(Title, fntNormal).Height) / 2)

        ' Left edge

        g.DrawLine(pN, x, y + mTabHeight, x, y + mTabHeight + mHeight)

        ' Right edge

        g.DrawLine(pN, mWidth + INDENT, y + mTabHeight, mWidth + INDENT, y + mTabHeight + mHeight)

        ' Bottom edge

        g.DrawLine(pN, x, y + mTabHeight + mHeight, mWidth + INDENT, y + mTabHeight + mHeight)

        ' Advance the Y coordinate for the card just printed

        y = y + mTabHeight + mHeight + LINEHEIGHT

        ' Destroy the objects we created

        bC.Dispose()
        r.Dispose()
    End Sub

    '**************************************************
    '
    ' The form is loaded.
    '
    '**************************************************
    Private Sub frmFileDividers_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        ' Set the default form size (4x6 card)

        Text1_0.Text = GetControlItem("DividerHeight", "4")
        Text1_1.Text = GetControlItem("DividerWidth", "6")

        ' If not turned off, show the tips window

        If GetControlItem(ControlItem, "1") = "1" Then
            frmTips.TipTitle = TipTitle
            frmTips.TipText = TipText
            frmTips.ControlItem = ControlItem
            frmTips.Show()
        End If
    End Sub

    '**************************************************
    '
    ' The form is closed.
    '
    '**************************************************
    Private Sub frmFileDividers_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        PutControlItem("DividerHeight", Text1_0.Text)
        PutControlItem("DividerWidth", Text1_1.Text)

    End Sub


    '**************************************************
    '
    ' The Units option box is clicked.
    '
    '**************************************************
    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1_0.CheckedChanged, Option1_1.CheckedChanged

        If eventSender.Checked Then
            If eventSender Is Option1_0 Then
                Label2_0.Text = "In."
                Label2_1.Text = "In."
            Else
                Label2_0.Text = "mm."
                Label2_1.Text = "mm."
            End If
        End If
    End Sub
    '**************************************************
    '
    ' The Add button is clicked.
    '
    '**************************************************
    Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click

        ' Declare variables

        Dim xx As Integer

        ' Add the item.

        If txtEnteredList.Text <> "" Then
            xx = List1.Items.Add(Capitalize((txtEnteredList.Text)))
            List1.SetItemChecked(xx, True)

            ' Save the new list

            SaveSpecialCategories()

            ' Refill the list

            FillSpecial()

            ' Clear the entry field and return to it

            txtEnteredList.Text = ""
            On Error Resume Next
            txtEnteredList.Focus()
            On Error GoTo 0
        End If

    End Sub


    '**************************************************
    '
    ' One of the options is clicked.
    '
    '**************************************************
    Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2_0.CheckedChanged, Option2_1.CheckedChanged, Option2_2.CheckedChanged

        If eventSender.Checked Then

            cmdAdd.Enabled = False
            txtEnteredList.Enabled = False
            If Option2_0.Checked = True Then
                List1.Enabled = False
                FillDefined()
            Else
                List1.Enabled = True
                If Option2_1.Checked = True Then
                    FillDefined()
                Else
                    cmdAdd.Enabled = True
                    txtEnteredList.Enabled = True
                    FillSpecial()
                End If
            End If

        End If
    End Sub

    '**************************************************
    '
    ' The Close button is clicked.
    '
    '**************************************************
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub


    '**************************************************
    '
    ' The Print button is clicked.
    '
    '**************************************************
    Private Sub cmdPrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrint.Click, cmdPreview.Click

        ' Declare variables

        Dim Prn As Printing.PrintDocument = frmMain.PrintDocument1

        ' Disable the print button while we do this

        cmdPrint.Enabled = False
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        ' Create a new printer object

        AddHandler Prn.PrintPage, AddressOf PrintDividers_PagePrint
        frmMain.PrintPreviewDialog1.Document = Prn

        ' Initialize variables

        IterateCategories = 0
        IterateTabs = 0
        IterateColors = 0

        ' Set the document name

        Prn.DocumentName = "Recipe File Dividers"

        ' Put up status message

        frmMain.StatusLabel.Text = "Printing File Dividers..."
        System.Windows.Forms.Application.DoEvents() '  Allow time to update

        ' Get the print options

        frmMain.PrintDialog1.Document = frmMain.PrintDocument1
        frmMain.PrintDialog1.PrinterSettings.Collate = True
        If frmMain.PrintDialog1.ShowDialog = DialogResult.OK Then
            If eventSender Is cmdPreview Then
                frmMain.PrintPreviewDialog1.ShowDialog()
            Else
                Prn.Print()
            End If
        End If
        RemoveHandler Prn.PrintPage, AddressOf PrintDividers_PagePrint


        ' Restore the mousepointer and reenable the print button

        Me.Cursor = System.Windows.Forms.Cursors.Default
        cmdPrint.Enabled = True

        ' Clear status message

        frmMain.StatusLabel.Text = ""
        System.Windows.Forms.Application.DoEvents() '  Allow time to update

    End Sub



    '**************************************************
    '
    ' TOne of the Up/Down controls is clicked.
    '
    '**************************************************
    Private Sub NumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged

        ' Declare variables

        Dim xx As Integer

        xx = Val(Text1_0.Text)
        If Option1_0.Checked = True Then
            xx = xx - 1
            If xx < 3 Then xx = 11
            If xx = 10 Then xx = 5
            Text1_0.Text = CStr(xx)
            If xx = 3 Then Text1_1.Text = "5"
            If xx = 4 Then Text1_1.Text = "6"
            If xx = 5 Then Text1_1.Text = "8"
            If xx = 11 Then Text1_1.Text = "8.5"
        Else
            xx = xx - 1
            If xx < 3 * 25.4 Then xx = 11 * 25.4
            If xx = 254 Then xx = 5 * 25.4
            Text1_0.Text = CStr(xx)
            If xx = 3 * 25.4 Then Text1_1.Text = FormatNumber(5 * 25.4, 2)
            If xx = 4 * 25.4 Then Text1_1.Text = FormatNumber(6 * 25.4, 2)
            If xx = 5 * 25.4 Then Text1_1.Text = FormatNumber(8 * 25.4, 2)
            If xx = 11 * 25.4 Then Text1_1.Text = FormatNumber(8.5 * 25.4, 2)
        End If
    End Sub

    '**************************************************
    '
    ' One of the card size fields has changed.
    '
    '**************************************************
    Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1_0.TextChanged, Text1_1.TextChanged

        ' Get the card height or width

        If eventSender Is Text1_0 Then mHeight = Val(Text1_0.Text)
        If eventSender Is Text1_1 Then mWidth = Val(Text1_1.Text)

    End Sub


    '**************************************************
    '
    ' Sub to save the special categoies
    '
    '**************************************************
    Private Sub SaveSpecialCategories()

        ' Declare variables

        Dim jj As Integer
        Dim zx As String

        ' Accumulate a string of the special categories

        zx = ""
        For jj = 0 To List1.Items.Count - 1
            If List1.GetItemChecked(jj) Then
                If zx <> "" Then zx = zx & vbCrLf
                zx = zx & List1.Items(jj)
            End If
        Next jj

        ' Save the special list

        PutControlItem("Dividers" & mParentID, zx)

    End Sub

End Class