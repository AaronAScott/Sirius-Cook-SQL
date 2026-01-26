Public Class DisplayLine
    '***************************************************************
    ' Accounts Payable SQL DisplayLine class
    ' DISPLAYLINE.VB
    ' Written: December 2016
    ' Updated: November 2017
    ' Programmer: Aaron Scott
    ' Copyright 2016-2017 Sirius Software All Rights Reserved.
    '****************************************************************
    ' NOTE: this class differs from the version used in Microsoft Access projects, 
    ' in that the "Bookmark" property of an ADODB database requires a type of
    ' "double", while SQL databases are reference by "row numbers" of an array,
    ' and need only an integer type.

    ' This class is used in all displays of datasets.
    ' It encapsulates the information needed to display a line
    ' and navigate the recordset, as well as a method to
    ' clear the lines without erasing the screen boundries, which therefore
    ' only need to be set one time.

    ' Declare variables local to this module

    Private mSize As Integer

    ' Declare variables that are properties of this class.

    Public Items() As mItem

    Public Structure mItem
        Dim Line As String
        Dim Bookmark As Integer
        Dim Bounds As Rectangle
        Dim Selected As Char
    End Structure

    '****************************************************************

    ' Method to clear the array of line data, but not the screen
    ' bounds in which it is displayed.

    '****************************************************************

    Public Sub Clear()

        ' Declare variables

        Dim jj As Integer

        ' Loop through the array, clearing only the lines.

        For jj = 0 To mSize
            Items(jj).Line = ""
            Items(jj).Bookmark = -1
            Items(jj).Selected = ""
        Next jj

    End Sub
    '****************************************************************

    ' Method to clear the just the selection data, but not the screen
    ' bounds in which it is displayed or lines or bookmarks.

    '****************************************************************

    Public Sub ClearSelections()

        ' Declare variables

        Dim jj As Integer

        ' Loop through the array, clearing only the selections.

        For jj = 1 To mSize
            Items(jj).Selected = ""
        Next jj

    End Sub

    '****************************************************************

    ' The Size property.  Setting this redimensions the array, which
    ' will clear out screen bounds as well.

    '****************************************************************
    Public Property Size As Integer

        Get
            Size = mSize
        End Get
        Set(value As Integer)
            mSize = value
            ReDim Items(value)
        End Set
    End Property

End Class
