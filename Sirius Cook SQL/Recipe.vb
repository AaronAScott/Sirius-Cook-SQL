Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class Recipe
    '**************************************************
    ' SiriusCook SQL Recipe class (Recipe object)
    ' RECIPE.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
    '**************************************************

    ' Declare variables local to this module.

    Public Servings As Integer
    Public Name As String
    Public Blurb As String
    Public Author As String
    Public Category As String
    Public Procedure As String
    Public Ingredients As Collection
    Public Display As System.Windows.Forms.PictureBox

    ' Declare variables local to this module

    Private mDb As SqlConnection

    '**************************************************
    '
    ' The class is destroyed
    '
    '**************************************************
    Protected Overrides Sub Finalize()
        Ingredients = Nothing
        MyBase.Finalize()
    End Sub
    '*************************************************
    '
    ' The database connection property is queried.
    '
    '*************************************************
    '************************************************
    '
    ' The database connection property is set
    '
    '************************************************
    Public Property Db() As SqlConnection
        Get
            Db = mDb
        End Get
        Set(ByVal Value As SqlConnection)
            mDb = Value
        End Set
    End Property

    '**************************************************
    '
    ' Property to return a text version of the
    ' ingredients of the recipe.
    '
    '**************************************************
    Public ReadOnly Property IngredientsText() As String
        Get

            ' Declare variables

            Dim jj As Integer
            Dim zx0 As String = ""

            ' Begin loop of assembling the text.

            For jj = 1 To Ingredients.Count()
                zx0 = zx0 & CStr(Ingredients.Item(jj).Quantity) & " " & Ingredients.Item(jj).UnitOfMeasure & " " & Ingredients.Item(jj).IngredientName & vbCrLf
            Next jj

            ' Return the text

            IngredientsText = zx0

        End Get
    End Property

    '**************************************************
    '
    ' The class in instantiated.
    '
    '**************************************************
    Public Sub New()
        MyBase.New()
        Ingredients = New Collection
    End Sub
End Class