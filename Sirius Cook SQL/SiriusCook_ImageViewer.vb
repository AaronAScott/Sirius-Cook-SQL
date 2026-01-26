Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.SqlClient
Imports System.Math
Imports VB = Microsoft.VisualBasic
Public Class frmImageViewer
	'************************************************************
	' Sirius Cook Image Viewer
	' SIRIUSCOOK_IMAGEVIEWER.VB
	' Written: April 2021
	' Programmer: Aaron Scott
	' Copyright 2021 Sirius Software All Rights Reserved
	'************************************************************

	' Declare variables local to this module

	Private DontProcessChangeEvent As Boolean
	Private ImageModified As Boolean
	Private mImageParentID As Integer
	Private DeskewAngle As Single
	Private OriginalImageData As MemoryStream
	Private WorkingImage As Image
	Private ImagesDS As New DataSet
	Private ImagesTable As DataTable
	Private ImageSize As Size


	'************************************************************

	' The form is loaded.

	'************************************************************
	Private Sub frmImageiewer_Load(sender As Object, e As EventArgs) Handles Me.Load

		' Declare variables

		Dim zx As String
		Dim Rect As Rectangle

		' Display the status

		frmMain.StatusLabel.Text = "Loading table..."
		System.Windows.Forms.Application.DoEvents()

		' Get saved window state

		zx = GetSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "ImgViewer", "Position", "0,0")
		If Me.WindowState = System.Windows.Forms.FormWindowState.Normal Then

			' Before using the positions, make sure they are valid

			Rect = My.Computer.Screen.WorkingArea
			If Val(zx) >= 0 And Val(zx) <= Rect.Width - Me.Width Then
				Me.Top = Val(ParseString(zx))
				Me.Left = Val(zx)
			End If
		End If

		' Clear the status

		frmMain.StatusLabel.Text = ""
		System.Windows.Forms.Application.DoEvents()

	End Sub
	'************************************************************

	' The form is getting ready to close.

	'************************************************************
	Private Sub frmImageViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

		' Declare variables.

		Dim ms As New MemoryStream

		' If the image has changed, see if the user wants to save it.

		If ImageModified Then
			If MsgBox("The image has changed.  Do you want to save the changes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Save Image") = MsgBoxResult.Yes Then

				' Convert the image to a byte array and save it back to the images table.
				' The current image is always row 0, since there is only one image allowed per recipe.

				Try

					If WorkingImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg) Then WorkingImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
					If WorkingImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff) Then WorkingImage.Save(ms, System.Drawing.Imaging.ImageFormat.Tiff)
					If WorkingImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) Then WorkingImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
					If WorkingImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp) Then WorkingImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
					If WorkingImage.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp) Then WorkingImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
					ImagesTable.Rows(0)("DocumentImage") = ms.ToArray
					ImagesDA.Update(ImagesTable)

				Catch ex As Exception
					MsgBox("Save Image failed." & vbCrLf & ex.Message, MsgBoxStyle.Information, "Save Image")
				End Try
			End If
		End If

	End Sub

	'************************************************************

	' The form is closed.

	'************************************************************
	Private Sub frmImageViewer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

		' Declare variables

		Dim zx As String

		' Remember the window state

		If Me.Top > 0 And Me.Left > 0 Then
			zx = Me.Top & "," & Me.Left
			SaveSetting("Sirius" & SRep(ProgramName, 1, " ", ""), "ImgViewer", "Position", zx)
		End If

		' Dispose of the datasets.

		ImagesDS.Dispose()
	End Sub

	'************************************************************

	' The picture box is resized.

	'************************************************************
	Private Sub PictureBox1_Resize(sender As Object, e As EventArgs) Handles PictureBox1.Resize

		' Declare variables

		Dim p As PictureBox = CType(sender, PictureBox)

		' Don't resize anything until the image has been created.

		If WorkingImage Is Nothing Then Exit Sub

		' See how big we can make the enclosing panel.  If the picture is too big, we'll make
		' the scrollbars visible, so the image can be scrolled inside the panel.

		If p.Width + VScrollBar1.Width + Panel2.Width + 70 > Me.MaximumSize.Width Then
			Panel1.Width = Me.MaximumSize.Width - VScrollBar1.Width - Panel2.Width - 70
			HScrollBar1.Visible = True
			HScrollBar1.Maximum = p.Width - Panel1.Width
		Else
			Panel1.Width = p.Width
			HScrollBar1.Visible = False
		End If
		VScrollBar1.Left = Panel1.Left + Panel1.Width
		Panel2.Left = VScrollBar1.Left + VScrollBar1.Width + 20

		If p.Height + HScrollBar1.Height + 87 > Me.MaximumSize.Height Then
			Panel1.Height = Me.MaximumSize.Height - HScrollBar1.Height - 87
			VScrollBar1.Visible = True
			VScrollBar1.Maximum = p.Height - Panel1.Height
		Else
			Panel1.Height = p.Height
			VScrollBar1.Visible = False
		End If

		' Resize and reposition the scrollbars to match the panel.

		HScrollBar1.Width = Panel1.Width
		HScrollBar1.Top = Panel1.Top + Panel1.Height
		HScrollBar1.Value = HScrollBar1.Minimum
		VScrollBar1.Left = Panel1.Left + Panel1.Width
		VScrollBar1.Height = Panel1.Height
		VScrollBar1.Value = VScrollBar1.Minimum

		' Reposition the image in the upper-left corner of the panel.

		p.Location = New Point(0, 0)

		' See if we need to resize the form.

		Me.Width = Panel1.Width + VScrollBar1.Width + Panel2.Width + 70
		Me.Height = Panel1.Height + HScrollBar1.Height + 87
		Panel2.Height = Me.Height - 80

	End Sub
	'************************************************************

	' The Zoom scrollbar value has changed.

	'************************************************************
	Private Sub hsbZoom_Scroll(sender As Object, e As ScrollEventArgs) Handles hsbZoom.Scroll

		' Make sure we've finished scrolling before resizing anything.

		If e.Type = ScrollEventType.EndScroll Then

			' Change the size of the picture box.  This will trigger a resize event that
			' will resize and reposition all the other parts of the form.

			If Not WorkingImage Is Nothing Then
				PictureBox1.Width = ImageSize.Width * hsbZoom.Value / 100
				PictureBox1.Height = ImageSize.Height * hsbZoom.Value / 100
				PictureBox1.Invalidate()
			End If

		End If

		' Display the angle value of the setting

		lblZoomPercent.Text = hsbZoom.Value & "%"
		System.Windows.Forms.Application.DoEvents()

	End Sub
	'************************************************************

	' The horizontal scrollbar value has changed.

	'************************************************************
	Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
		PictureBox1.Left = -HScrollBar1.Value
	End Sub
	'************************************************************

	' The vertical scrollbar value has changed.

	'************************************************************
	Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
		PictureBox1.Top = -VScrollBar1.Value
	End Sub
	'************************************************************

	' The paint event for the image.

	'************************************************************
	Private Sub Image_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint

		' Declare variables

		Dim p As PictureBox = CType(sender, PictureBox)
		Dim g As Graphics = e.Graphics

		' Size the picture box to have the same proportions as the image.

		PictureBox1.Height = PictureBox1.Width * (WorkingImage.Height / WorkingImage.Width)

		' Draw the image.

		g.DrawImage(WorkingImage, 0, 0, p.Width, p.Height)

	End Sub
	'************************************************************

	' The Exit button is clicked.

	'************************************************************
	Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles btnClose.Click

		Me.Close()

	End Sub
	'************************************************************

	' The flip vertical menu option is selected.

	'************************************************************
	Private Sub mnuFlipV_Click(sender As Object, e As EventArgs) Handles mnuFlipV.Click


		' Set the caption of the undo menu item.

		mnuUndo.Text = "&Undo Flip/Rotate"

		' Flip the image.

		WorkingImage.RotateFlip(RotateFlipType.RotateNoneFlipY)

		' Force the image to redraw.

		PictureBox1.Invalidate()

		' Flag that the image has been changed.

		ImageModified = True

		' Enable the undo menu options

		mnuUndo.Enabled = True

	End Sub

	'************************************************************

	' The Flip horizontal menu option is selected.

	'************************************************************
	Private Sub mnuFlipH_Click(sender As Object, e As EventArgs) Handles mnuFlipH.Click

		' Set the caption of the undo menu item.

		mnuUndo.Text = "&Undo Flip/Rotate"

		' Rotate the image in the currently selected tab.

		WorkingImage.RotateFlip(RotateFlipType.RotateNoneFlipX)

		' Force the image to redraw.

		PictureBox1.Invalidate()

		' Flag that the image has been changed.

		ImageModified = True

		' Enable the undo menu options

		mnuUndo.Enabled = True

	End Sub


	'************************************************************

	' The Rotate Left menu option is selected.

	'************************************************************
	Private Sub mnuRotateLeft_Click(sender As Object, e As EventArgs) Handles mnuRotateLeft.Click

		' Set the caption of the undo menu item.

		mnuUndo.Text = "&Undo Flip/Rotate"

		' Flip the image in the currently selected tab.

		WorkingImage.RotateFlip(RotateFlipType.Rotate90FlipXY)

		' Force the image to redraw.

		PictureBox1.Invalidate()

		' Flag that the image has been changed and save back the changed image.

		ImageModified = True

		' Enable the undo menu options

		mnuUndo.Enabled = True

	End Sub

	'************************************************************

	' The Rotate Right menu option is selected.

	'************************************************************
	Private Sub mnuRotateRight_Click(sender As Object, e As EventArgs) Handles mnuRotateRight.Click

		' Set the caption of the undo menu item.

		mnuUndo.Text = "Undo Flip/Rotate"

		' Rotate the image in the currently selected tab.

		WorkingImage.RotateFlip(RotateFlipType.Rotate90FlipNone)

		' Force the image to redraw.

		PictureBox1.Invalidate()

		' Flag that the image has been changed and save back the changed image.

		ImageModified = True

		' Enable the undo menu options

		mnuUndo.Enabled = True

	End Sub
	'************************************************************

	' The de-skew menu option is selected.

	'************************************************************
	Private Sub mnuDeskew_Click(sender As Object, e As EventArgs) Handles mnuDeskew.Click

		' Set the caption of the undo menu item.

		mnuUndo.Text = "&Undo Skew Correction"

		' Enable the skew adjust control

		GroupBox1.Enabled = True

		' Enable the undo menu options

		mnuUndo.Enabled = True

	End Sub

	'************************************************************

	' The undo menu option is selected.

	'************************************************************
	Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click

		' Restore the orignal image

		WorkingImage = Image.FromStream(OriginalImageData)

		' Force a redraw of the displayed page

		PictureBox1.Invalidate()

		' Disable the undo menu options

		mnuUndo.Enabled = False

		' Reset the skew adjust value

		DontProcessChangeEvent = True ' We don't want to do anything in the trackbar change event
		TrackBar1.Value = 0
		DontProcessChangeEvent = False
		GroupBox1.Enabled = False

	End Sub
	'************************************************************

	' The skew adjust trackbar control, which controls the angle of
	' skew correction, has changed.

	'************************************************************
	Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged

		' Declare variables.

		Dim OriginalImage As Image = Image.FromStream(OriginalImageData)

		' Using the original image, rotate it by the value of the trackbar,
		' which represents .01 degree changes.

		DeskewAngle = TrackBar1.Value / 100
		If Not DontProcessChangeEvent Then
			WorkingImage = RotateImage(OriginalImage, DeskewAngle)
			PictureBox1.Invalidate()
			ImageModified = True
		End If

		' If the de-skew angle is not zero, enable the Undo menu item.

		If TrackBar1.Value <> 0 Then mnuUndo.Enabled = True Else mnuUndo.Enabled = False

		' Display the angle value of the setting

		lblSkewAngle.Text = VB.Format(TrackBar1.Value / 100, ".00")
		System.Windows.Forms.Application.DoEvents()


	End Sub

	'************************************************************

	' Function to rotate an image by a specified angle.

	'************************************************************
	Private Function RotateImage(Img As Image, Angle As Single) As Image

		' Declare variables

		Dim RotatedImage As New Bitmap(Img.Width, Img.Height)
		Dim g As Graphics = Graphics.FromImage(RotatedImage)
		Dim Rect As New Rectangle(0, 0, Img.Width, Img.Height)
		Dim Image As Image

		' Set the rotation point to the center in the matrix

		g.TranslateTransform(RotatedImage.Width / 2, RotatedImage.Height / 2)

		' Fill the new image with all white before we draw the rotated image.

		g.FillRectangle(Brushes.White, Rect)

		' Rotate the image

		g.RotateTransform(Angle, Drawing2D.MatrixOrder.Append)

		' Restore rotation point in the matrix

		g.TranslateTransform(-RotatedImage.Width / 2, -RotatedImage.Height / 2)

		' Draw the image on the bitmap

		g.DrawImage(Img, Rect, 0, 0, Img.Width, Img.Height, GraphicsUnit.Pixel)

		' Return the rotated image and dispose of the local bitmap.

		Image = Drawing.Image.FromHbitmap(RotatedImage.GetHbitmap)
		RotatedImage.Dispose()

		Return Image

	End Function
	'************************************************************

	' The View method.  This is called from the main form, and
	' passes us the image's parent ID.

	'************************************************************
	Public Sub View(ByVal ParentID As Integer)

		' Declare variables

		Dim Data() As Byte

		' Save the image Parent ID

		mImageParentID = ParentID

		' Set up the data adapter for the images table.

		ImagesDA.SelectCommand = New SqlCommand("SELECT * FROM tblImages WHERE ParentID=" & mImageParentID, DB)
		ImagesDA.UpdateCommand = ImagesUpdateCommand()
		ImagesDS.Clear()
		ImagesDA.Fill(ImagesDS, "Table")
		ImagesTable = ImagesDS.Tables("Table")

		' Convert the data for the current page to an image.
		' The images are stored in module-level variables, and will
		' be displayed by the Paint event for the picture box controls.

		If ImagesTable.Rows.Count > 0 Then
			Data = ImagesTable.Rows(0)("DocumentImage")
			OriginalImageData = New MemoryStream(Data)

			' Get the working image.  The original image data memory stream
			' will allow us to undo any changes.

			WorkingImage = Image.FromStream(OriginalImageData)

			' Initialize the deskew angle.

			DeskewAngle = 0.0

			' Set the maximum size of the form to be just smaller than the display.

			Me.MaximumSize = New Size(Screen.GetWorkingArea(Me.Location).Width - 40, Screen.GetWorkingArea(Me.Location).Height - 100)

			' Get and save the image size.  Size the picturebox to fit it.

			ImageSize = New Size(WorkingImage.Width, WorkingImage.Height)

			' Determine if we can show the picture full size.

			If ImageSize.Width <= Me.MaximumSize.Width * 0.9 And ImageSize.Height < Me.MaximumSize.Height * 0.9 Then
				PictureBox1.Size = ImageSize

				' If not, we'll start with the image at half size.
			Else
				hsbZoom.Value = 50 ' This will resize the picture.
				lblZoomPercent.Text = "50%"
				PictureBox1.Width = ImageSize.Width * hsbZoom.Value / 100
				PictureBox1.Height = ImageSize.Height * hsbZoom.Value / 100
			End If

			' Show the form

			Me.Show()
		End If
	End Sub


End Class