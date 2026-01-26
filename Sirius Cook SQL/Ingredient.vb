Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Friend Class Ingredient
	'**************************************************
    ' SiriusCook SQL Ingredient class (Ingredient object)
    ' INGREDIENT.VB
    ' Written: November 2017
    ' Programmer: Aaron Scott
    ' Copyright (C) 1997-2017 Sirius Software All Rights Reserved
	'**************************************************

	' Declare variables which are properties of this
	' class
	
	Public IngredientName As String
	Public Quantity As Single
	Public UnitOfMeasure As String
	
	' Define variables local to this module
	
    Private mDb As SqlConnection

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
End Class