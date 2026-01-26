<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmRecipeCard
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Combo2 As System.Windows.Forms.ComboBox
    Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents btnExit As System.Windows.Forms.Button
	Public WithEvents btnPrint As System.Windows.Forms.Button
	Public WithEvents Text2 As System.Windows.Forms.TextBox
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents Option2_1 As System.Windows.Forms.RadioButton
	Public WithEvents Option2_0 As System.Windows.Forms.RadioButton
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecipeCard))
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.pnlMargins = New System.Windows.Forms.Panel()
		Me.List1 = New System.Windows.Forms.ListBox()
		Me.Image2 = New System.Windows.Forms.PictureBox()
		Me.Combo2 = New System.Windows.Forms.ComboBox()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnPrint = New System.Windows.Forms.Button()
		Me.Text2 = New System.Windows.Forms.TextBox()
		Me.Combo1 = New System.Windows.Forms.ComboBox()
		Me.Frame2 = New System.Windows.Forms.GroupBox()
		Me.Option2_1 = New System.Windows.Forms.RadioButton()
		Me.Option2_0 = New System.Windows.Forms.RadioButton()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.chkFavorite = New System.Windows.Forms.CheckBox()
		Me.optCardSide_Back = New System.Windows.Forms.RadioButton()
		Me.optCardSide_Front = New System.Windows.Forms.RadioButton()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Picture2 = New System.Windows.Forms.PictureBox()
		Me.pnlPreview2 = New System.Windows.Forms.Panel()
		Me.pnlPreview1 = New System.Windows.Forms.Panel()
		Me.chkIncludeNotes = New System.Windows.Forms.CheckBox()
		Me.chkLandscape = New System.Windows.Forms.CheckBox()
		Me.Frame1 = New System.Windows.Forms.GroupBox()
		Me.cmbCardSize = New System.Windows.Forms.ComboBox()
		CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Frame2.SuspendLayout()
		Me.Panel1.SuspendLayout()
		CType(Me.Picture2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		'
		'pnlMargins
		'
		Me.pnlMargins.BackColor = System.Drawing.SystemColors.Control
		Me.pnlMargins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pnlMargins.Location = New System.Drawing.Point(10, 7)
		Me.pnlMargins.Name = "pnlMargins"
		Me.pnlMargins.Size = New System.Drawing.Size(672, 18)
		Me.pnlMargins.TabIndex = 37
		Me.ToolTip1.SetToolTip(Me.pnlMargins, "Click on a point along the ruler to set the selected margin.")
		'
		'List1
		'
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = False
		Me.List1.ItemHeight = 14
		Me.List1.Location = New System.Drawing.Point(720, 28)
		Me.List1.Name = "List1"
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Size = New System.Drawing.Size(165, 134)
		Me.List1.TabIndex = 27
		Me.ToolTip1.SetToolTip(Me.List1, "Select an image to print on the background of the recipe card.")
		'
		'Image2
		'
		Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
		Me.Image2.Location = New System.Drawing.Point(727, 440)
		Me.Image2.Name = "Image2"
		Me.Image2.Size = New System.Drawing.Size(134, 100)
		Me.Image2.TabIndex = 39
		Me.Image2.TabStop = False
		Me.ToolTip1.SetToolTip(Me.Image2, "Select a background image from the listbox below.")
		Me.Image2.Visible = False
		'
		'Combo2
		'
		Me.Combo2.BackColor = System.Drawing.SystemColors.Window
		Me.Combo2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Combo2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Combo2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Combo2.Location = New System.Drawing.Point(912, 101)
		Me.Combo2.Name = "Combo2"
		Me.Combo2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Combo2.Size = New System.Drawing.Size(125, 22)
		Me.Combo2.Sorted = True
		Me.Combo2.TabIndex = 21
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.SystemColors.Control
		Me.btnExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
		Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnExit.Location = New System.Drawing.Point(912, 405)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnExit.Size = New System.Drawing.Size(125, 53)
		Me.btnExit.TabIndex = 23
		Me.btnExit.Text = "&Exit"
		Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'btnPrint
		'
		Me.btnPrint.BackColor = System.Drawing.SystemColors.Control
		Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
		Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnPrint.Location = New System.Drawing.Point(912, 339)
		Me.btnPrint.Name = "btnPrint"
		Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnPrint.Size = New System.Drawing.Size(125, 53)
		Me.btnPrint.TabIndex = 22
		Me.btnPrint.Text = "&Print"
		Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btnPrint.UseVisualStyleBackColor = False
		'
		'Text2
		'
		Me.Text2.AcceptsReturn = True
		Me.Text2.BackColor = System.Drawing.SystemColors.Control
		Me.Text2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text2.Font = New System.Drawing.Font("Lucida Handwriting", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Text2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text2.Location = New System.Drawing.Point(720, 197)
		Me.Text2.MaxLength = 0
		Me.Text2.Name = "Text2"
		Me.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text2.Size = New System.Drawing.Size(317, 23)
		Me.Text2.TabIndex = 1
		Me.Text2.TabStop = False
		Me.Text2.Text = "From the Kitchen of "
		'
		'Combo1
		'
		Me.Combo1.BackColor = System.Drawing.SystemColors.Window
		Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Combo1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Combo1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Combo1.Items.AddRange(New Object() {"6", "8", "9", "10", "11", "12", "13", "14", "15", "16"})
		Me.Combo1.Location = New System.Drawing.Point(912, 48)
		Me.Combo1.Name = "Combo1"
		Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Combo1.Size = New System.Drawing.Size(65, 22)
		Me.Combo1.TabIndex = 19
		'
		'Frame2
		'
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Controls.Add(Me.Option2_1)
		Me.Frame2.Controls.Add(Me.Option2_0)
		Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.Location = New System.Drawing.Point(912, 235)
		Me.Frame2.Name = "Frame2"
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Size = New System.Drawing.Size(121, 98)
		Me.Frame2.TabIndex = 12
		Me.Frame2.TabStop = False
		Me.Frame2.Text = "&Margins"
		'
		'Option2_1
		'
		Me.Option2_1.BackColor = System.Drawing.SystemColors.Control
		Me.Option2_1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option2_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option2_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option2_1.Location = New System.Drawing.Point(8, 52)
		Me.Option2_1.Name = "Option2_1"
		Me.Option2_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option2_1.Size = New System.Drawing.Size(105, 17)
		Me.Option2_1.TabIndex = 16
		Me.Option2_1.Text = "&Procedure"
		Me.Option2_1.UseVisualStyleBackColor = False
		'
		'Option2_0
		'
		Me.Option2_0.BackColor = System.Drawing.SystemColors.Control
		Me.Option2_0.Checked = True
		Me.Option2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Option2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option2_0.Location = New System.Drawing.Point(8, 24)
		Me.Option2_0.Name = "Option2_0"
		Me.Option2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option2_0.Size = New System.Drawing.Size(105, 17)
		Me.Option2_0.TabIndex = 15
		Me.Option2_0.TabStop = True
		Me.Option2_0.Text = "&Ingredients"
		Me.Option2_0.UseVisualStyleBackColor = False
		'
		'Label7
		'
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Location = New System.Drawing.Point(913, 83)
		Me.Label7.Name = "Label7"
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.Size = New System.Drawing.Size(65, 17)
		Me.Label7.TabIndex = 20
		Me.Label7.Text = "Font &Name"
		'
		'Label6
		'
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Location = New System.Drawing.Point(717, 181)
		Me.Label6.Name = "Label6"
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.Size = New System.Drawing.Size(49, 13)
		Me.Label6.TabIndex = 0
		Me.Label6.Text = "&Heading"
		'
		'Label5
		'
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Location = New System.Drawing.Point(909, 28)
		Me.Label5.Name = "Label5"
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.Size = New System.Drawing.Size(65, 17)
		Me.Label5.TabIndex = 18
		Me.Label5.Text = "&Font Size"
		'
		'chkFavorite
		'
		Me.chkFavorite.BackColor = System.Drawing.SystemColors.Control
		Me.chkFavorite.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkFavorite.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkFavorite.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkFavorite.Location = New System.Drawing.Point(912, 145)
		Me.chkFavorite.Name = "chkFavorite"
		Me.chkFavorite.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkFavorite.Size = New System.Drawing.Size(125, 17)
		Me.chkFavorite.TabIndex = 38
		Me.chkFavorite.Text = "Mark as &Favorite"
		Me.chkFavorite.UseVisualStyleBackColor = False
		'
		'optCardSide_Back
		'
		Me.optCardSide_Back.Appearance = System.Windows.Forms.Appearance.Button
		Me.optCardSide_Back.AutoSize = True
		Me.optCardSide_Back.Location = New System.Drawing.Point(75, 503)
		Me.optCardSide_Back.Name = "optCardSide_Back"
		Me.optCardSide_Back.Size = New System.Drawing.Size(67, 24)
		Me.optCardSide_Back.TabIndex = 44
		Me.optCardSide_Back.TabStop = True
		Me.optCardSide_Back.Text = "Card Back"
		Me.optCardSide_Back.UseVisualStyleBackColor = True
		'
		'optCardSide_Front
		'
		Me.optCardSide_Front.Appearance = System.Windows.Forms.Appearance.Button
		Me.optCardSide_Front.AutoSize = True
		Me.optCardSide_Front.Checked = True
		Me.optCardSide_Front.Location = New System.Drawing.Point(10, 503)
		Me.optCardSide_Front.Name = "optCardSide_Front"
		Me.optCardSide_Front.Size = New System.Drawing.Size(68, 24)
		Me.optCardSide_Front.TabIndex = 43
		Me.optCardSide_Front.TabStop = True
		Me.optCardSide_Front.Text = "Card Front"
		Me.optCardSide_Front.UseVisualStyleBackColor = True
		'
		'Label3
		'
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.Label3.Location = New System.Drawing.Point(717, 12)
		Me.Label3.Name = "Label3"
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.Size = New System.Drawing.Size(125, 13)
		Me.Label3.TabIndex = 25
		Me.Label3.Text = "Card &Background"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel1.Controls.Add(Me.Picture2)
		Me.Panel1.Controls.Add(Me.pnlPreview2)
		Me.Panel1.Controls.Add(Me.pnlPreview1)
		Me.Panel1.Controls.Add(Me.optCardSide_Back)
		Me.Panel1.Controls.Add(Me.optCardSide_Front)
		Me.Panel1.Controls.Add(Me.pnlMargins)
		Me.Panel1.Location = New System.Drawing.Point(17, 12)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(693, 530)
		Me.Panel1.TabIndex = 45
		'
		'Picture2
		'
		Me.Picture2.BackColor = System.Drawing.SystemColors.Window
		Me.Picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Picture2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Picture2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Picture2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Picture2.Location = New System.Drawing.Point(3, 25)
		Me.Picture2.Name = "Picture2"
		Me.Picture2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Picture2.Size = New System.Drawing.Size(1, 285)
		Me.Picture2.TabIndex = 45
		Me.Picture2.TabStop = False
		'
		'pnlPreview2
		'
		Me.pnlPreview2.BackColor = System.Drawing.SystemColors.Window
		Me.pnlPreview2.Location = New System.Drawing.Point(9, 25)
		Me.pnlPreview2.Name = "pnlPreview2"
		Me.pnlPreview2.Size = New System.Drawing.Size(672, 479)
		Me.pnlPreview2.TabIndex = 47
		'
		'pnlPreview1
		'
		Me.pnlPreview1.BackColor = System.Drawing.SystemColors.Window
		Me.pnlPreview1.Location = New System.Drawing.Point(10, 25)
		Me.pnlPreview1.Name = "pnlPreview1"
		Me.pnlPreview1.Size = New System.Drawing.Size(672, 480)
		Me.pnlPreview1.TabIndex = 46
		'
		'chkIncludeNotes
		'
		Me.chkIncludeNotes.Location = New System.Drawing.Point(912, 168)
		Me.chkIncludeNotes.Name = "chkIncludeNotes"
		Me.chkIncludeNotes.Size = New System.Drawing.Size(125, 17)
		Me.chkIncludeNotes.TabIndex = 46
		Me.chkIncludeNotes.Text = "&Include Notes"
		Me.chkIncludeNotes.UseVisualStyleBackColor = True
		'
		'chkLandscape
		'
		Me.chkLandscape.AutoSize = True
		Me.chkLandscape.Location = New System.Drawing.Point(7, 70)
		Me.chkLandscape.Name = "chkLandscape"
		Me.chkLandscape.Size = New System.Drawing.Size(135, 18)
		Me.chkLandscape.TabIndex = 47
		Me.chkLandscape.Text = "&Landscape Orientation"
		Me.chkLandscape.UseVisualStyleBackColor = True
		'
		'Frame1
		'
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Controls.Add(Me.chkLandscape)
		Me.Frame1.Controls.Add(Me.cmbCardSize)
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.Location = New System.Drawing.Point(720, 235)
		Me.Frame1.Name = "Frame1"
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Size = New System.Drawing.Size(182, 98)
		Me.Frame1.TabIndex = 2
		Me.Frame1.TabStop = False
		Me.Frame1.Text = "Card Si&ze"
		'
		'cmbCardSize
		'
		Me.cmbCardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbCardSize.FormattingEnabled = True
		Me.cmbCardSize.Location = New System.Drawing.Point(7, 24)
		Me.cmbCardSize.Name = "cmbCardSize"
		Me.cmbCardSize.Size = New System.Drawing.Size(158, 22)
		Me.cmbCardSize.TabIndex = 0
		'
		'frmRecipeCard
		'
		Me.AcceptButton = Me.btnExit
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.btnExit
		Me.ClientSize = New System.Drawing.Size(1061, 550)
		Me.Controls.Add(Me.chkIncludeNotes)
		Me.Controls.Add(Me.Frame2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Text2)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.Frame1)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnPrint)
		Me.Controls.Add(Me.Image2)
		Me.Controls.Add(Me.chkFavorite)
		Me.Controls.Add(Me.Combo2)
		Me.Controls.Add(Me.List1)
		Me.Controls.Add(Me.Combo1)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label5)
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Location = New System.Drawing.Point(166, 78)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmRecipeCard"
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Print a Recipe Card"
		CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame2.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		CType(Me.Picture2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.Frame1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents pnlMargins As System.Windows.Forms.Panel
	Friend WithEvents optCardSide_Back As System.Windows.Forms.RadioButton
	Friend WithEvents optCardSide_Front As System.Windows.Forms.RadioButton
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents pnlPreview2 As System.Windows.Forms.Panel
	Friend WithEvents pnlPreview1 As System.Windows.Forms.Panel
	Friend WithEvents chkFavorite As System.Windows.Forms.CheckBox
	Friend WithEvents Image2 As System.Windows.Forms.PictureBox
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Picture2 As System.Windows.Forms.PictureBox
	Friend WithEvents chkIncludeNotes As CheckBox
	Friend WithEvents chkLandscape As CheckBox
	Public WithEvents Frame1 As GroupBox
	Friend WithEvents cmbCardSize As ComboBox
#End Region
End Class